using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks;

[StructLayout(LayoutKind.Auto)]
[AsyncMethodBuilder(typeof(AsyncUniTaskMethodBuilder<>))]
public readonly struct UniTask<T>
{
	private sealed class IsCanceledSource : IUniTaskSource<(bool, T)>, IUniTaskSource
	{
		private readonly IUniTaskSource<T> source;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public IsCanceledSource(IUniTaskSource<T> source)
		{
			this.source = source;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public (bool, T) GetResult(short token)
		{
			if (source.GetStatus(token) == UniTaskStatus.Canceled)
			{
				return (true, default(T));
			}
			T result = source.GetResult(token);
			return (false, result);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		void IUniTaskSource.GetResult(short token)
		{
			GetResult(token);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public UniTaskStatus GetStatus(short token)
		{
			return source.GetStatus(token);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public UniTaskStatus UnsafeGetStatus()
		{
			return source.UnsafeGetStatus();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public void OnCompleted(Action<object> continuation, object state, short token)
		{
			source.OnCompleted(continuation, state, token);
		}
	}

	private sealed class MemoizeSource : IUniTaskSource<T>, IUniTaskSource
	{
		private IUniTaskSource<T> source;

		private T result;

		private ExceptionDispatchInfo exception;

		private UniTaskStatus status;

		public MemoizeSource(IUniTaskSource<T> source)
		{
			this.source = source;
		}

		public T GetResult(short token)
		{
			if (source == null)
			{
				if (exception != null)
				{
					exception.Throw();
				}
				return result;
			}
			try
			{
				result = source.GetResult(token);
				status = UniTaskStatus.Succeeded;
				return result;
			}
			catch (Exception ex)
			{
				exception = ExceptionDispatchInfo.Capture(ex);
				if (ex is OperationCanceledException)
				{
					status = UniTaskStatus.Canceled;
				}
				else
				{
					status = UniTaskStatus.Faulted;
				}
				throw;
			}
			finally
			{
				source = null;
			}
		}

		void IUniTaskSource.GetResult(short token)
		{
			GetResult(token);
		}

		public UniTaskStatus GetStatus(short token)
		{
			if (source == null)
			{
				return status;
			}
			return source.GetStatus(token);
		}

		public void OnCompleted(Action<object> continuation, object state, short token)
		{
			if (source == null)
			{
				continuation(state);
			}
			else
			{
				source.OnCompleted(continuation, state, token);
			}
		}

		public UniTaskStatus UnsafeGetStatus()
		{
			if (source == null)
			{
				return status;
			}
			return source.UnsafeGetStatus();
		}
	}

	public readonly struct Awaiter(in UniTask<T> task) : ICriticalNotifyCompletion, INotifyCompletion
	{
		private readonly UniTask<T> task = task;

		public bool IsCompleted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[DebuggerHidden]
			get
			{
				return task.Status.IsCompleted();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public T GetResult()
		{
			IUniTaskSource<T> source = task.source;
			if (source == null)
			{
				return task.result;
			}
			return source.GetResult(task.token);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public void OnCompleted(Action continuation)
		{
			IUniTaskSource<T> source = task.source;
			if (source == null)
			{
				continuation();
			}
			else
			{
				source.OnCompleted(AwaiterActions.InvokeContinuationDelegate, continuation, task.token);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public void UnsafeOnCompleted(Action continuation)
		{
			IUniTaskSource<T> source = task.source;
			if (source == null)
			{
				continuation();
			}
			else
			{
				source.OnCompleted(AwaiterActions.InvokeContinuationDelegate, continuation, task.token);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public void SourceOnCompleted(Action<object> continuation, object state)
		{
			IUniTaskSource<T> source = task.source;
			if (source == null)
			{
				continuation(state);
			}
			else
			{
				source.OnCompleted(continuation, state, task.token);
			}
		}
	}

	private readonly IUniTaskSource<T> source;

	private readonly T result;

	private readonly short token;

	public UniTaskStatus Status
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		get
		{
			if (source != null)
			{
				return source.GetStatus(token);
			}
			return UniTaskStatus.Succeeded;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[DebuggerHidden]
	public UniTask(T result)
	{
		source = null;
		token = 0;
		this.result = result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[DebuggerHidden]
	public UniTask(IUniTaskSource<T> source, short token)
	{
		this.source = source;
		this.token = token;
		result = default(T);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[DebuggerHidden]
	public Awaiter GetAwaiter()
	{
		return new Awaiter(this);
	}

	public UniTask<T> Preserve()
	{
		if (source == null)
		{
			return this;
		}
		return new UniTask<T>(new MemoizeSource(source), token);
	}

	public UniTask AsUniTask()
	{
		if (source == null)
		{
			return UniTask.CompletedTask;
		}
		if (source.GetStatus(token).IsCompletedSuccessfully())
		{
			source.GetResult(token);
			return UniTask.CompletedTask;
		}
		return new UniTask(source, token);
	}

	public static implicit operator UniTask(UniTask<T> self)
	{
		return self.AsUniTask();
	}

	public UniTask<(bool IsCanceled, T Result)> SuppressCancellationThrow()
	{
		if (source == null)
		{
			return new UniTask<(bool, T)>((false, result));
		}
		return new UniTask<(bool, T)>(new IsCanceledSource(source), token);
	}

	public override string ToString()
	{
		if (source != null)
		{
			return "(" + source.UnsafeGetStatus().ToString() + ")";
		}
		T val = result;
		if (val == null)
		{
			return null;
		}
		return val.ToString();
	}
}
