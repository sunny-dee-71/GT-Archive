using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using UnityEngine;

[AsyncMethodBuilder(typeof(OVRTaskBuilder<>))]
public readonly struct OVRTask<TResult> : IEquatable<OVRTask<TResult>>, IDisposable
{
	private delegate void ContinueWithInvoker(Guid guid, TResult result);

	private delegate bool ContinueWithRemover(Guid guid);

	private delegate bool InternalDataRemover(Guid guid);

	private static class InternalData<T>
	{
		private static readonly Dictionary<Guid, T> Data = new Dictionary<Guid, T>();

		private static readonly InternalDataRemover Remover = Remove;

		private static readonly Action Clearer = Clear;

		public static bool TryGet(Guid taskId, out T data)
		{
			return Data.TryGetValue(taskId, out data);
		}

		public static void Set(Guid taskId, T data)
		{
			Data[taskId] = data;
			OVRTask<TResult>.InternalDataRemovers.Add(taskId, Remover);
			OVRTask<TResult>.InternalDataClearers.Add(Clearer);
		}

		private static bool Remove(Guid taskId)
		{
			return Data.Remove(taskId);
		}

		private static void Clear()
		{
			Data.Clear();
		}
	}

	private static class IncrementalResultSubscriber<T>
	{
		private static readonly Dictionary<Guid, Action<T>> Subscribers = new Dictionary<Guid, Action<T>>();

		private static readonly Action<Guid> Remover = Remove;

		private static readonly Action Clearer = Clear;

		public static void Set(Guid taskId, Action<T> subscriber)
		{
			Subscribers[taskId] = subscriber;
			OVRTask<TResult>.IncrementalResultSubscriberRemovers[taskId] = Remover;
			OVRTask<TResult>.IncrementalResultSubscriberClearers.Add(Clearer);
		}

		public static void Notify(Guid taskId, T result)
		{
			if (Subscribers.TryGetValue(taskId, out var value))
			{
				value(result);
			}
		}

		private static void Remove(Guid id)
		{
			Subscribers.Remove(id);
		}

		private static void Clear()
		{
			Subscribers.Clear();
		}
	}

	private readonly struct CombinedTaskData : IDisposable
	{
		public readonly OVRTask<List<TResult>> Task;

		private readonly HashSet<Guid> _remainingTaskIds;

		private readonly List<Guid> _originalTaskOrder;

		private readonly Dictionary<Guid, TResult> _completedTasks;

		private readonly List<TResult> _userOwnedResultList;

		private static readonly Action<TResult, CombinedTaskDataWithCompletedTaskId> _onSingleTaskCompleted = delegate(TResult result, CombinedTaskDataWithCompletedTaskId data)
		{
			data.CombinedData.OnSingleTaskCompleted(data.CompletedTaskId, result);
		};

		private void OnSingleTaskCompleted(Guid taskId, TResult result)
		{
			_completedTasks.Add(taskId, result);
			_remainingTaskIds.Remove(taskId);
			if (_remainingTaskIds.Count != 0)
			{
				return;
			}
			using (this)
			{
				_userOwnedResultList.Clear();
				foreach (Guid item in _originalTaskOrder)
				{
					_userOwnedResultList.Add(_completedTasks[item]);
				}
				Task.SetResult(_userOwnedResultList);
			}
		}

		public CombinedTaskData(IEnumerable<OVRTask<TResult>> tasks, List<TResult> userOwnedResultList)
		{
			Task = OVRTask.FromGuid<List<TResult>>(Guid.NewGuid());
			_remainingTaskIds = OVRObjectPool.HashSet<Guid>();
			_originalTaskOrder = OVRObjectPool.List<Guid>();
			_completedTasks = OVRObjectPool.Dictionary<Guid, TResult>();
			_userOwnedResultList = userOwnedResultList;
			_userOwnedResultList.Clear();
			List<OVRTask<TResult>> list;
			using (new OVRObjectPool.ListScope<OVRTask<TResult>>(out list))
			{
				foreach (OVRTask<TResult> item in tasks.ToNonAlloc())
				{
					list.Add(item);
					_remainingTaskIds.Add(item._id);
					_originalTaskOrder.Add(item._id);
				}
				if (list.Count == 0)
				{
					Task.SetResult(_userOwnedResultList);
					return;
				}
				foreach (OVRTask<TResult> item2 in list)
				{
					item2.ContinueWith(_onSingleTaskCompleted, new CombinedTaskDataWithCompletedTaskId
					{
						CompletedTaskId = item2._id,
						CombinedData = this
					});
				}
			}
		}

		public void Dispose()
		{
			OVRObjectPool.Return(_remainingTaskIds);
			OVRObjectPool.Return(_originalTaskOrder);
			OVRObjectPool.Return(_completedTasks);
		}
	}

	private struct CombinedTaskDataWithCompletedTaskId
	{
		public Guid CompletedTaskId;

		public CombinedTaskData CombinedData;
	}

	private class TaskSource : IValueTaskSource<TResult>, OVRObjectPool.IPoolObject
	{
		private ManualResetValueTaskSourceCore<TResult> _manualSource;

		public ValueTask<TResult> Task { get; private set; }

		public TResult GetResult(short token)
		{
			try
			{
				return _manualSource.GetResult(token);
			}
			finally
			{
				OVRObjectPool.Return(this);
			}
		}

		public ValueTaskSourceStatus GetStatus(short token)
		{
			return _manualSource.GetStatus(token);
		}

		public void OnCompleted(Action<object> continuation, object state, short token, ValueTaskSourceOnCompletedFlags flags)
		{
			_manualSource.OnCompleted(continuation, state, token, flags);
		}

		void OVRObjectPool.IPoolObject.OnGet()
		{
			_manualSource.Reset();
			Task = new ValueTask<TResult>(this, _manualSource.Version);
		}

		void OVRObjectPool.IPoolObject.OnReturn()
		{
		}

		public void SetResult(TResult result)
		{
			_manualSource.SetResult(result);
		}

		public void SetException(Exception exception)
		{
			_manualSource.SetException(exception);
		}
	}

	private class AwaitableSource : AwaitableCompletionSource<TResult>, OVRObjectPool.IPoolObject
	{
		public void OnGet()
		{
			Reset();
		}

		public void OnReturn()
		{
		}

		public void SetResultAndReturnToPool(in TResult result)
		{
			try
			{
				SetResult(in result);
			}
			finally
			{
				OVRObjectPool.Return(this);
			}
		}
	}

	public readonly struct Awaiter : INotifyCompletion
	{
		private readonly OVRTask<TResult> _task;

		public bool IsCompleted => _task.IsCompleted;

		internal Awaiter(OVRTask<TResult> task)
		{
			_task = task;
		}

		void INotifyCompletion.OnCompleted(Action continuation)
		{
			_task.WithContinuation(continuation);
		}

		public TResult GetResult()
		{
			return _task.GetResult();
		}
	}

	private readonly struct Callback
	{
		private static readonly Dictionary<Guid, Callback> Callbacks = new Dictionary<Guid, Callback>();

		private readonly Action<TResult> _delegate;

		public static readonly ContinueWithInvoker Invoker = Invoke;

		public static readonly ContinueWithRemover Remover = Remove;

		public static readonly Action Clearer = Clear;

		private static void Invoke(Guid taskId, TResult result)
		{
			if (Callbacks.TryGetValue(taskId, out var value))
			{
				Callbacks.Remove(taskId);
				value.Invoke(result);
			}
		}

		private static bool Remove(Guid taskId)
		{
			return Callbacks.Remove(taskId);
		}

		private static void Clear()
		{
			Callbacks.Clear();
		}

		private void Invoke(TResult result)
		{
			_delegate(result);
		}

		private Callback(Action<TResult> @delegate)
		{
			_delegate = @delegate;
		}

		public static void Add(Guid taskId, Action<TResult> @delegate)
		{
			Callbacks.Add(taskId, new Callback(@delegate));
			OVRTask<TResult>.ContinueWithInvokers.Add(taskId, Invoker);
			OVRTask<TResult>.ContinueWithRemovers.Add(taskId, Remover);
			OVRTask<TResult>.ContinueWithClearers.Add(Clearer);
		}
	}

	private readonly struct CallbackWithState<T>
	{
		private static readonly Dictionary<Guid, CallbackWithState<T>> Callbacks = new Dictionary<Guid, CallbackWithState<T>>();

		private readonly T _data;

		private readonly Action<TResult, T> _delegate;

		private static readonly ContinueWithInvoker Invoker = Invoke;

		private static readonly ContinueWithRemover Remover = Remove;

		private static readonly Action Clearer = Clear;

		private static void Invoke(Guid taskId, TResult result)
		{
			if (Callbacks.TryGetValue(taskId, out var value))
			{
				Callbacks.Remove(taskId);
				value.Invoke(result);
			}
		}

		private CallbackWithState(T data, Action<TResult, T> @delegate)
		{
			_data = data;
			_delegate = @delegate;
		}

		private static void Clear()
		{
			Callbacks.Clear();
		}

		private static bool Remove(Guid taskId)
		{
			return Callbacks.Remove(taskId);
		}

		private void Invoke(TResult result)
		{
			_delegate(result, _data);
		}

		public static void Add(Guid taskId, T data, Action<TResult, T> callback)
		{
			Callbacks.Add(taskId, new CallbackWithState<T>(data, callback));
			OVRTask<TResult>.ContinueWithInvokers.Add(taskId, Invoker);
			OVRTask<TResult>.ContinueWithRemovers.Add(taskId, Remover);
			OVRTask<TResult>.ContinueWithClearers.Add(Clearer);
		}
	}

	private static readonly HashSet<Guid> Pending;

	private static readonly Dictionary<Guid, TResult> Results;

	private static readonly Dictionary<Guid, Exception> Exceptions;

	private static readonly Dictionary<Guid, TaskSource> Sources;

	private static readonly Dictionary<Guid, AwaitableSource> AwaitableSources;

	private static readonly Dictionary<Guid, Action> Continuations;

	private static readonly Dictionary<Guid, ContinueWithInvoker> ContinueWithInvokers;

	private static readonly Dictionary<Guid, ContinueWithRemover> ContinueWithRemovers;

	private static readonly HashSet<Action> ContinueWithClearers;

	private static readonly Dictionary<Guid, InternalDataRemover> InternalDataRemovers;

	private static readonly HashSet<Action> InternalDataClearers;

	private static readonly Dictionary<Guid, Action<Guid>> IncrementalResultSubscriberRemovers;

	private static readonly HashSet<Action> IncrementalResultSubscriberClearers;

	internal static readonly Action Clear;

	internal readonly Guid _id;

	private static readonly Action<List<TResult>, OVRTask<TResult[]>> _onCombinedTaskCompleted;

	internal bool IsPending => Pending.Contains(_id);

	public bool IsCompleted => !IsPending;

	public bool IsFaulted => Exceptions.ContainsKey(_id);

	public bool HasResult => Results.ContainsKey(_id);

	internal OVRTask(Guid id)
	{
		_id = id;
	}

	static OVRTask()
	{
		Pending = new HashSet<Guid>();
		Results = new Dictionary<Guid, TResult>();
		Exceptions = new Dictionary<Guid, Exception>();
		Sources = new Dictionary<Guid, TaskSource>();
		AwaitableSources = new Dictionary<Guid, AwaitableSource>();
		Continuations = new Dictionary<Guid, Action>();
		ContinueWithInvokers = new Dictionary<Guid, ContinueWithInvoker>();
		ContinueWithRemovers = new Dictionary<Guid, ContinueWithRemover>();
		ContinueWithClearers = new HashSet<Action>();
		InternalDataRemovers = new Dictionary<Guid, InternalDataRemover>();
		InternalDataClearers = new HashSet<Action>();
		IncrementalResultSubscriberRemovers = new Dictionary<Guid, Action<Guid>>();
		IncrementalResultSubscriberClearers = new HashSet<Action>();
		Clear = delegate
		{
			Results.Clear();
			Continuations.Clear();
			Pending.Clear();
			Exceptions.Clear();
			ContinueWithInvokers.Clear();
			foreach (Action continueWithClearer in ContinueWithClearers)
			{
				continueWithClearer();
			}
			ContinueWithClearers.Clear();
			ContinueWithRemovers.Clear();
			foreach (Action internalDataClearer in InternalDataClearers)
			{
				internalDataClearer();
			}
			InternalDataClearers.Clear();
			InternalDataRemovers.Clear();
			foreach (Action incrementalResultSubscriberClearer in IncrementalResultSubscriberClearers)
			{
				incrementalResultSubscriberClearer();
			}
			IncrementalResultSubscriberClearers.Clear();
			IncrementalResultSubscriberRemovers.Clear();
			foreach (TaskSource value in Sources.Values)
			{
				OVRObjectPool.Return(value);
			}
			Sources.Clear();
			foreach (AwaitableSource value2 in AwaitableSources.Values)
			{
				OVRObjectPool.Return(value2);
			}
			AwaitableSources.Clear();
		};
		_onCombinedTaskCompleted = delegate(List<TResult> resultsFromPool, OVRTask<TResult[]> task)
		{
			TResult[] result = resultsFromPool.ToArray();
			OVRObjectPool.Return(resultsFromPool);
			task.SetResult(result);
		};
		OVRTask.RegisterType<TResult>();
	}

	internal bool AddToPending()
	{
		return Pending.Add(_id);
	}

	internal void SetInternalData<T>(T data)
	{
		InternalData<T>.Set(_id, data);
	}

	internal OVRTask<TResult> WithInternalData<T>(T data)
	{
		if (!HasResult)
		{
			InternalData<T>.Set(_id, data);
		}
		return this;
	}

	internal bool TryGetInternalData<T>(out T data)
	{
		return InternalData<T>.TryGet(_id, out data);
	}

	internal void SetException(Exception exception)
	{
		if (AwaitableSources.Remove(_id, out var value))
		{
			value.SetException(exception);
			return;
		}
		if (Sources.Remove(_id, out var value2))
		{
			value2.SetException(exception);
			return;
		}
		if (TryRemoveInternalData())
		{
			if (ContinueWithInvokers.Remove(_id, out var _))
			{
				ExceptionDispatchInfo.Capture(exception).Throw();
			}
			Exceptions.Add(_id, exception);
			TryInvokeContinuation();
			return;
		}
		throw new InvalidOperationException($"The exception {exception} cannot be set on task {_id} because it is not a valid task.", exception);
	}

	private bool TryRemoveInternalData()
	{
		if (!Pending.Remove(_id))
		{
			return false;
		}
		if (InternalDataRemovers.Remove(_id, out var value))
		{
			value(_id);
		}
		if (IncrementalResultSubscriberRemovers.Remove(_id, out var value2))
		{
			value2(_id);
		}
		return true;
	}

	private bool TryInvokeContinuation()
	{
		if (Continuations.Remove(_id, out var value))
		{
			value();
			return true;
		}
		return false;
	}

	internal void SetResult(TResult result)
	{
		TaskSource value2;
		if (AwaitableSources.Remove(_id, out var value))
		{
			value.SetResultAndReturnToPool(in result);
		}
		else if (Sources.Remove(_id, out value2))
		{
			value2.SetResult(result);
		}
		else if (TryRemoveInternalData())
		{
			if (ContinueWithInvokers.Remove(_id, out var value3))
			{
				value3(_id, result);
				return;
			}
			Results.Add(_id, result);
			TryInvokeContinuation();
		}
	}

	internal void SetIncrementalResultCallback<TIncrementalResult>(Action<TIncrementalResult> onIncrementalResultAvailable)
	{
		if (onIncrementalResultAvailable == null)
		{
			throw new ArgumentNullException("onIncrementalResultAvailable");
		}
		IncrementalResultSubscriber<TIncrementalResult>.Set(_id, onIncrementalResultAvailable);
	}

	internal void NotifyIncrementalResult<TIncrementalResult>(TIncrementalResult incrementalResult)
	{
		IncrementalResultSubscriber<TIncrementalResult>.Notify(_id, incrementalResult);
	}

	internal static OVRTask<List<TResult>> WhenAll(IEnumerable<OVRTask<TResult>> tasks, List<TResult> results)
	{
		if (tasks == null)
		{
			throw new ArgumentNullException("tasks");
		}
		if (results == null)
		{
			throw new ArgumentNullException("results");
		}
		return new CombinedTaskData(tasks, results).Task;
	}

	internal static OVRTask<TResult[]> WhenAll(IEnumerable<OVRTask<TResult>> tasks)
	{
		if (tasks == null)
		{
			throw new ArgumentNullException("tasks");
		}
		OVRTask<TResult[]> oVRTask = OVRTask.FromGuid<TResult[]>(Guid.NewGuid());
		List<TResult> results = OVRObjectPool.List<TResult>();
		WhenAll(tasks, results).ContinueWith(_onCombinedTaskCompleted, oVRTask);
		return oVRTask;
	}

	public Exception GetException()
	{
		if (!Exceptions.Remove(_id, out var value))
		{
			throw new InvalidOperationException(string.Format("Task {0} is not in a faulted state. Check with {1}", _id, "IsFaulted"));
		}
		return value;
	}

	public TResult GetResult()
	{
		if (Exceptions.Remove(_id, out var value))
		{
			ExceptionDispatchInfo.Capture(value).Throw();
		}
		if (!TryGetResult(out var result))
		{
			throw new InvalidOperationException($"Task {_id} doesn't have any available result.");
		}
		return result;
	}

	public bool TryGetResult(out TResult result)
	{
		return Results.Remove(_id, out result);
	}

	public ValueTask<TResult> ToValueTask()
	{
		TResult value;
		bool flag = Results.TryGetValue(_id, out value);
		if (!Pending.Contains(_id) && !flag)
		{
			throw new InvalidOperationException($"Task {_id} is not a valid task.");
		}
		if (Continuations.ContainsKey(_id))
		{
			throw new InvalidOperationException($"Task {_id} is already being used by an await call.");
		}
		if (ContinueWithInvokers.ContainsKey(_id))
		{
			throw new InvalidOperationException($"Task {_id} is already being used with ContinueWith.");
		}
		using (this)
		{
			if (flag)
			{
				Results.Remove(_id);
				return new ValueTask<TResult>(value);
			}
			TaskSource taskSource = OVRObjectPool.Get<TaskSource>();
			Sources.Add(_id, taskSource);
			return taskSource.Task;
		}
	}

	public Awaitable<TResult> ToAwaitable()
	{
		TResult value;
		bool flag = Results.TryGetValue(_id, out value);
		if (!Pending.Contains(_id) && !flag)
		{
			throw new InvalidOperationException($"Task {_id} is not a valid task.");
		}
		if (Continuations.ContainsKey(_id))
		{
			throw new InvalidOperationException($"Task {_id} is already being used by an await call.");
		}
		if (ContinueWithInvokers.ContainsKey(_id))
		{
			throw new InvalidOperationException($"Task {_id} is already being used with ContinueWith.");
		}
		using (this)
		{
			AwaitableSource awaitableSource = OVRObjectPool.Get<AwaitableSource>();
			if (flag)
			{
				awaitableSource.SetResult(in value);
			}
			else
			{
				AwaitableSources.Add(_id, awaitableSource);
			}
			return awaitableSource.Awaitable;
		}
	}

	public Awaiter GetAwaiter()
	{
		return new Awaiter(this);
	}

	private void WithContinuation(Action continuation)
	{
		ValidateDelegateAndThrow(continuation, "continuation");
		Continuations[_id] = continuation;
	}

	public void ContinueWith(Action<TResult> onCompleted)
	{
		ValidateDelegateAndThrow(onCompleted, "onCompleted");
		if (IsCompleted)
		{
			onCompleted(GetResult());
		}
		else
		{
			Callback.Add(_id, onCompleted);
		}
	}

	public void ContinueWith<T>(Action<TResult, T> onCompleted, T state)
	{
		ValidateDelegateAndThrow(onCompleted, "onCompleted");
		if (IsCompleted)
		{
			onCompleted(GetResult(), state);
		}
		else
		{
			CallbackWithState<T>.Add(_id, state, onCompleted);
		}
	}

	private void ValidateDelegateAndThrow(object @delegate, string paramName)
	{
		if (@delegate == null)
		{
			throw new ArgumentNullException(paramName);
		}
		if (Continuations.ContainsKey(_id))
		{
			throw new InvalidOperationException($"Task {_id} is already being used by an await call.");
		}
		if (ContinueWithInvokers.ContainsKey(_id))
		{
			throw new InvalidOperationException($"Task {_id} is already being used with ContinueWith.");
		}
		if (Sources.ContainsKey(_id))
		{
			throw new InvalidOperationException($"Task {_id} is already being used as a ValueTask.");
		}
		if (AwaitableSources.ContainsKey(_id))
		{
			throw new InvalidOperationException($"Task {_id} is already being used as an Awaitable.");
		}
	}

	public void Dispose()
	{
		Results.Remove(_id);
		Continuations.Remove(_id);
		Pending.Remove(_id);
		ContinueWithInvokers.Remove(_id);
		if (ContinueWithRemovers.TryGetValue(_id, out var value))
		{
			ContinueWithRemovers.Remove(_id);
			value(_id);
		}
		if (InternalDataRemovers.TryGetValue(_id, out var value2))
		{
			InternalDataRemovers.Remove(_id);
			value2(_id);
		}
		if (IncrementalResultSubscriberRemovers.TryGetValue(_id, out var value3))
		{
			IncrementalResultSubscriberRemovers.Remove(_id);
			value3(_id);
		}
	}

	public bool Equals(OVRTask<TResult> other)
	{
		return _id == other._id;
	}

	public override bool Equals(object obj)
	{
		if (obj is OVRTask<TResult> other)
		{
			return Equals(other);
		}
		return false;
	}

	public static bool operator ==(OVRTask<TResult> lhs, OVRTask<TResult> rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(OVRTask<TResult> lhs, OVRTask<TResult> rhs)
	{
		return !lhs.Equals(rhs);
	}

	public override int GetHashCode()
	{
		return _id.GetHashCode();
	}

	public override string ToString()
	{
		return _id.ToString();
	}
}
