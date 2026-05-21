using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine.Internal;

namespace UnityEngine;

public class AsyncInstantiateOperation<T> : AsyncInstantiateOperation
{
	internal new static class BindingsMarshaller
	{
		public static AsyncInstantiateOperation<T> ConvertToManaged(IntPtr ptr)
		{
			return new AsyncInstantiateOperation<T>(ptr, CancellationToken.None);
		}

		public static IntPtr ConvertToNative(AsyncInstantiateOperation<T> obj)
		{
			return obj.m_Ptr;
		}
	}

	[ExcludeFromDocs]
	public struct Awaiter(AsyncInstantiateOperation<T> op) : INotifyCompletion
	{
		private readonly Awaitable _awaitable = Awaitable.FromAsyncOperation(op);

		private readonly AsyncInstantiateOperation<T> _op = op;

		public bool IsCompleted => _awaitable.IsCompleted;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void OnCompleted(Action continuation)
		{
			_awaitable.SetContinuation(continuation);
		}

		public T[] GetResult()
		{
			_awaitable.GetAwaiter().GetResult();
			return _op.Result;
		}
	}

	public new T[] Result => (T[])(object)m_Result;

	internal AsyncInstantiateOperation(IntPtr ptr, CancellationToken cancellationToken)
		: base(ptr, cancellationToken)
	{
	}

	internal override Object[] CreateResultArray(int size)
	{
		m_Result = (Object[])(object)new T[size];
		return m_Result;
	}

	[ExcludeFromDocs]
	public Awaiter GetAwaiter()
	{
		return new Awaiter(this);
	}
}
