using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine.Internal;
using UnityEngine.Pool;

namespace UnityEngine;

[AsyncMethodBuilder(typeof(Awaitable.AwaitableAsyncMethodBuilder<>))]
public class Awaitable<T>
{
	[ExcludeFromDocs]
	public struct Awaiter(Awaitable<T> coroutine) : INotifyCompletion
	{
		private readonly Awaitable<T> _coroutine = coroutine;

		public bool IsCompleted => _coroutine._awaitable.IsCompleted;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void OnCompleted(Action continuation)
		{
			_coroutine.ContinueWith(continuation);
		}

		public T GetResult()
		{
			return _coroutine.GetResult();
		}
	}

	private static readonly ThreadLocal<ObjectPool<Awaitable<T>>> _pool = new ThreadLocal<ObjectPool<Awaitable<T>>>(() => new ObjectPool<Awaitable<T>>(() => new Awaitable<T>(), null, null, null, collectionCheck: false));

	private Awaitable _awaitable;

	private T _result;

	internal Awaitable.AwaiterCompletionThreadAffinity CompletionThreadAffinity
	{
		get
		{
			return _awaitable.CompletionThreadAffinity;
		}
		set
		{
			_awaitable.CompletionThreadAffinity = value;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void ContinueWith(Action continuation)
	{
		_awaitable.SetContinuation(continuation);
	}

	private T GetResult()
	{
		try
		{
			_awaitable.PropagateExceptionAndRelease();
			return _result;
		}
		finally
		{
			_awaitable = null;
			_result = default(T);
			_pool.Value.Release(this);
		}
	}

	internal void SetResultAndRaiseContinuation(T result)
	{
		_result = result;
		_awaitable.RaiseManagedCompletion();
	}

	internal void SetExceptionAndRaiseContinuation(Exception exception)
	{
		_awaitable.RaiseManagedCompletion(exception);
	}

	public void Cancel()
	{
		_awaitable.Cancel();
	}

	private Awaitable()
	{
	}

	internal static Awaitable<T> GetManaged()
	{
		Awaitable awaitable = Awaitable.NewManagedAwaitable();
		Awaitable<T> awaitable2 = _pool.Value.Get();
		awaitable2._awaitable = awaitable;
		return awaitable2;
	}

	[ExcludeFromDocs]
	public Awaiter GetAwaiter()
	{
		return new Awaiter(this);
	}
}
