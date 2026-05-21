using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace System.IO.Hashing;

public sealed class XxHash32 : NonCryptographicHashAlgorithm
{
	private struct State
	{
		private uint _acc1;

		private uint _acc2;

		private uint _acc3;

		private uint _acc4;

		private readonly uint _smallAcc;

		private bool _hadFullStripe;

		internal State(uint seed)
		{
			_acc1 = seed + 606290984;
			_acc2 = seed + 2246822519u;
			_acc3 = seed;
			_acc4 = seed - 2654435761u;
			_smallAcc = seed + 374761393;
			_hadFullStripe = false;
		}

		internal void ProcessStripe(ReadOnlySpan<byte> source)
		{
			source = source.Slice(0, 16);
			_acc1 = ApplyRound(_acc1, source);
			_acc2 = ApplyRound(_acc2, source.Slice(4));
			_acc3 = ApplyRound(_acc3, source.Slice(8));
			_acc4 = ApplyRound(_acc4, source.Slice(12));
			_hadFullStripe = true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private readonly uint Converge()
		{
			return BitOperations.RotateLeft(_acc1, 1) + BitOperations.RotateLeft(_acc2, 7) + BitOperations.RotateLeft(_acc3, 12) + BitOperations.RotateLeft(_acc4, 18);
		}

		private static uint ApplyRound(uint acc, ReadOnlySpan<byte> lane)
		{
			acc += (uint)((int)BinaryPrimitives.ReadUInt32LittleEndian(lane) * -2048144777);
			acc = BitOperations.RotateLeft(acc, 13);
			acc *= 2654435761u;
			return acc;
		}

		internal readonly uint Complete(int length, ReadOnlySpan<byte> remaining)
		{
			uint num = (_hadFullStripe ? Converge() : _smallAcc);
			num += (uint)length;
			while (remaining.Length >= 4)
			{
				uint num2 = BinaryPrimitives.ReadUInt32LittleEndian(remaining);
				num += (uint)((int)num2 * -1028477379);
				num = BitOperations.RotateLeft(num, 17);
				num *= 668265263;
				remaining = remaining.Slice(4);
			}
			for (int i = 0; i < remaining.Length; i++)
			{
				uint num3 = remaining[i];
				num += num3 * 374761393;
				num = BitOperations.RotateLeft(num, 11);
				num *= 2654435761u;
			}
			num ^= num >> 15;
			num *= 2246822519u;
			num ^= num >> 13;
			num *= 3266489917u;
			return num ^ (num >> 16);
		}
	}

	private const int HashSize = 4;

	private const int StripeSize = 16;

	private readonly uint _seed;

	private State _state;

	private byte[] _holdback;

	private int _length;

	public XxHash32()
		: this(0)
	{
	}

	public XxHash32(int seed)
		: base(4)
	{
		_seed = (uint)seed;
		Reset();
	}

	public override void Reset()
	{
		_state = new State(_seed);
		_length = 0;
	}

	public override void Append(ReadOnlySpan<byte> source)
	{
		int num = _length & 0xF;
		if (num != 0)
		{
			int num2 = 16 - num;
			if (source.Length < num2)
			{
				source.CopyTo(MemoryExtensions.AsSpan(_holdback, num));
				_length += source.Length;
				return;
			}
			source.Slice(0, num2).CopyTo(MemoryExtensions.AsSpan(_holdback, num));
			_state.ProcessStripe(_holdback);
			source = source.Slice(num2);
			_length += num2;
		}
		while (source.Length >= 16)
		{
			_state.ProcessStripe(source);
			source = source.Slice(16);
			_length += 16;
		}
		if (source.Length > 0)
		{
			if (_holdback == null)
			{
				_holdback = new byte[16];
			}
			source.CopyTo(_holdback);
			_length += source.Length;
		}
	}

	protected override void GetCurrentHashCore(Span<byte> destination)
	{
		uint currentHashAsUInt = GetCurrentHashAsUInt32();
		BinaryPrimitives.WriteUInt32BigEndian(destination, currentHashAsUInt);
	}

	[CLSCompliant(false)]
	public uint GetCurrentHashAsUInt32()
	{
		int num = _length & 0xF;
		ReadOnlySpan<byte> remaining = ReadOnlySpan<byte>.Empty;
		if (num > 0)
		{
			remaining = new ReadOnlySpan<byte>(_holdback, 0, num);
		}
		return _state.Complete(_length, remaining);
	}

	public static byte[] Hash(byte[] source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return Hash(new ReadOnlySpan<byte>(source));
	}

	public static byte[] Hash(byte[] source, int seed)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return Hash(new ReadOnlySpan<byte>(source), seed);
	}

	public static byte[] Hash(ReadOnlySpan<byte> source, int seed = 0)
	{
		byte[] array = new byte[4];
		BinaryPrimitives.WriteUInt32BigEndian(value: HashToUInt32(source, seed), destination: array);
		return array;
	}

	public static bool TryHash(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten, int seed = 0)
	{
		if (destination.Length < 4)
		{
			bytesWritten = 0;
			return false;
		}
		uint value = HashToUInt32(source, seed);
		BinaryPrimitives.WriteUInt32BigEndian(destination, value);
		bytesWritten = 4;
		return true;
	}

	public static int Hash(ReadOnlySpan<byte> source, Span<byte> destination, int seed = 0)
	{
		if (destination.Length < 4)
		{
			NonCryptographicHashAlgorithm.ThrowDestinationTooShort();
		}
		uint value = HashToUInt32(source, seed);
		BinaryPrimitives.WriteUInt32BigEndian(destination, value);
		return 4;
	}

	[CLSCompliant(false)]
	public static uint HashToUInt32(ReadOnlySpan<byte> source, int seed = 0)
	{
		int length = source.Length;
		State state = new State((uint)seed);
		while (source.Length >= 16)
		{
			state.ProcessStripe(source);
			source = source.Slice(16);
		}
		return state.Complete(length, source);
	}
}
