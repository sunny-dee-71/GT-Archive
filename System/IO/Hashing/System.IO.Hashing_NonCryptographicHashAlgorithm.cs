using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace System.IO.Hashing;

public abstract class NonCryptographicHashAlgorithm
{
	private sealed class CopyToDestinationStream(NonCryptographicHashAlgorithm hash) : Stream
	{
		public override bool CanWrite => true;

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public override long Position
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			hash.Append(MemoryExtensions.AsSpan(buffer, offset, count));
		}

		public override void WriteByte(byte value)
		{
			hash.Append(new ReadOnlySpan<byte>(new byte[1] { value }));
		}

		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			hash.Append(MemoryExtensions.AsSpan(buffer, offset, count));
			return Task.CompletedTask;
		}

		public override void Flush()
		{
		}

		public override Task FlushAsync(CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}
	}

	public int HashLengthInBytes { get; }

	protected NonCryptographicHashAlgorithm(int hashLengthInBytes)
	{
		if (hashLengthInBytes < 1)
		{
			throw new ArgumentOutOfRangeException("hashLengthInBytes");
		}
		HashLengthInBytes = hashLengthInBytes;
	}

	public abstract void Append(ReadOnlySpan<byte> source);

	public abstract void Reset();

	protected abstract void GetCurrentHashCore(Span<byte> destination);

	public void Append(byte[] source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		Append(new ReadOnlySpan<byte>(source));
	}

	public void Append(Stream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		stream.CopyTo(new CopyToDestinationStream(this));
	}

	public Task AppendAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		return stream.CopyToAsync(new CopyToDestinationStream(this), 81920, cancellationToken);
	}

	public byte[] GetCurrentHash()
	{
		byte[] array = new byte[HashLengthInBytes];
		GetCurrentHashCore(array);
		return array;
	}

	public bool TryGetCurrentHash(Span<byte> destination, out int bytesWritten)
	{
		if (destination.Length < HashLengthInBytes)
		{
			bytesWritten = 0;
			return false;
		}
		GetCurrentHashCore(destination.Slice(0, HashLengthInBytes));
		bytesWritten = HashLengthInBytes;
		return true;
	}

	public int GetCurrentHash(Span<byte> destination)
	{
		if (destination.Length < HashLengthInBytes)
		{
			ThrowDestinationTooShort();
		}
		GetCurrentHashCore(destination.Slice(0, HashLengthInBytes));
		return HashLengthInBytes;
	}

	public byte[] GetHashAndReset()
	{
		byte[] array = new byte[HashLengthInBytes];
		GetHashAndResetCore(array);
		return array;
	}

	public bool TryGetHashAndReset(Span<byte> destination, out int bytesWritten)
	{
		if (destination.Length < HashLengthInBytes)
		{
			bytesWritten = 0;
			return false;
		}
		GetHashAndResetCore(destination.Slice(0, HashLengthInBytes));
		bytesWritten = HashLengthInBytes;
		return true;
	}

	public int GetHashAndReset(Span<byte> destination)
	{
		if (destination.Length < HashLengthInBytes)
		{
			ThrowDestinationTooShort();
		}
		GetHashAndResetCore(destination.Slice(0, HashLengthInBytes));
		return HashLengthInBytes;
	}

	protected virtual void GetHashAndResetCore(Span<byte> destination)
	{
		GetCurrentHashCore(destination);
		Reset();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use GetCurrentHash() to retrieve the computed hash code.", true)]
	public override int GetHashCode()
	{
		throw new NotSupportedException(System.SR.NotSupported_GetHashCode);
	}

	[DoesNotReturn]
	private protected static void ThrowDestinationTooShort()
	{
		throw new ArgumentException(System.SR.Argument_DestinationTooShort, "destination");
	}
}
