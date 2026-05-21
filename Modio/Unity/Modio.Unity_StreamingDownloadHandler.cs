using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Unity.Collections;
using UnityEngine.Networking;

namespace Modio.Unity;

internal class StreamingDownloadHandler : DownloadHandlerScript
{
	private class ChunkedStreamBuffer : Stream
	{
		private class BufferChunk : IDisposable
		{
			internal NativeArray<byte> Data { get; }

			internal int Offset { get; set; }

			internal int Length => Data.Length;

			internal bool HasData => Offset < Data.Length;

			internal int RemainingLength => Data.Length - Offset;

			internal BufferChunk(NativeArray<byte> data, int offset)
			{
				Data = data;
				Offset = offset;
			}

			public void Dispose()
			{
				Data.Dispose();
			}
		}

		private class AsyncAutoResetEvent
		{
			[StructLayout(LayoutKind.Sequential, Size = 1)]
			private struct Empty
			{
			}

			private readonly Queue<TaskCompletionSource<Empty>> _signalWaiters = new Queue<TaskCompletionSource<Empty>>();

			private bool _signaled;

			public Task WaitAsync(CancellationToken cancellationToken = default(CancellationToken))
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return Task.FromCanceled(cancellationToken);
				}
				lock (_signalWaiters)
				{
					if (_signaled)
					{
						_signaled = false;
						return Task.CompletedTask;
					}
					TaskCompletionSource<Empty> taskCompletionSource = new TaskCompletionSource<Empty>(TaskCreationOptions.RunContinuationsAsynchronously);
					if (cancellationToken.IsCancellationRequested)
					{
						taskCompletionSource.TrySetCanceled(cancellationToken);
						return taskCompletionSource.Task;
					}
					_signalWaiters.Enqueue(taskCompletionSource);
					return taskCompletionSource.Task;
				}
			}

			public void Set()
			{
				TaskCompletionSource<Empty> taskCompletionSource = null;
				lock (_signalWaiters)
				{
					if (_signalWaiters.Count > 0)
					{
						taskCompletionSource = _signalWaiters.Dequeue();
					}
					else
					{
						_signaled = true;
					}
				}
				taskCompletionSource?.TrySetResult(default(Empty));
			}
		}

		private readonly ConcurrentQueue<BufferChunk> _dataQueue = new ConcurrentQueue<BufferChunk>();

		private readonly CancellationToken _shutdownToken;

		private readonly AsyncAutoResetEvent _signal = new AsyncAutoResetEvent();

		public override bool CanRead => true;

		public override bool CanSeek => false;

		public override bool CanWrite => true;

		public override long Length => -1L;

		public override long Position { get; set; } = -1L;

		private bool IsDone { get; set; }

		internal ChunkedStreamBuffer(CancellationToken shutdownToken)
		{
			_shutdownToken = shutdownToken;
		}

		public override void Flush()
		{
			BufferChunk result;
			while (_dataQueue.TryDequeue(out result))
			{
				result.Dispose();
			}
			_dataQueue.Clear();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return ReadAsync(buffer, offset, count, CancellationToken.None).Result;
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (cancellationToken == CancellationToken.None)
			{
				cancellationToken = _shutdownToken;
			}
			int totalBytesRead = 0;
			while (totalBytesRead < count)
			{
				BufferChunk result;
				while (!_dataQueue.TryPeek(out result))
				{
					if (cancellationToken.IsCancellationRequested)
					{
						cancellationToken.ThrowIfCancellationRequested();
					}
					if (IsDone && _dataQueue.IsEmpty)
					{
						return totalBytesRead;
					}
					if (totalBytesRead > 0)
					{
						return totalBytesRead;
					}
					await _signal.WaitAsync(_shutdownToken);
				}
				int num = Math.Min(result.RemainingLength, count - totalBytesRead);
				NativeArray<byte>.Copy(result.Data, result.Offset, buffer, offset + totalBytesRead, num);
				totalBytesRead += num;
				result.Offset += num;
				if (!result.HasData)
				{
					_dataQueue.TryDequeue(out var _);
					result.Dispose();
				}
			}
			return totalBytesRead;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (!_shutdownToken.IsCancellationRequested)
			{
				int num = Math.Min(buffer.Length, count);
				NativeArray<byte> nativeArray = new NativeArray<byte>(num, Allocator.Persistent);
				NativeArray<byte>.Copy(buffer, offset, nativeArray, 0, num - offset);
				_dataQueue.Enqueue(new BufferChunk(nativeArray, 0));
				_signal.Set();
			}
		}

		public void Complete()
		{
			IsDone = true;
			_signal.Set();
		}
	}

	private readonly ChunkedStreamBuffer _streamBuffer;

	private readonly CancellationToken _cancellationToken;

	private readonly TaskCompletionSource<bool> _hasReceivedHeaders = new TaskCompletionSource<bool>();

	private UnityWebRequest _callingRequest;

	internal StreamingDownloadHandler(int bufferSize = 1048576, CancellationToken token = default(CancellationToken))
		: this(new byte[bufferSize], token)
	{
	}

	private StreamingDownloadHandler(byte[] buffer, CancellationToken token = default(CancellationToken))
		: base(buffer)
	{
		_streamBuffer = new ChunkedStreamBuffer(token);
		_cancellationToken = token;
	}

	public void SetCallingRequest(UnityWebRequest request)
	{
		_callingRequest = request;
	}

	internal Stream GetStream()
	{
		return _streamBuffer;
	}

	protected override bool ReceiveData(byte[] dataReceived, int dataLength)
	{
		if (_cancellationToken.IsCancellationRequested)
		{
			_callingRequest.Abort();
			_streamBuffer.Flush();
			_hasReceivedHeaders.TrySetCanceled();
			return true;
		}
		_streamBuffer.Write(dataReceived, 0, dataLength);
		_hasReceivedHeaders.TrySetResult(result: true);
		return true;
	}

	public async Task ResponseReceived(CancellationToken token)
	{
		await _hasReceivedHeaders.Task;
	}

	protected override void CompleteContent()
	{
		base.CompleteContent();
		_streamBuffer.Complete();
	}
}
