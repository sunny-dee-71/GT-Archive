using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace System.IO.Hashing;

public sealed class XxHash64 : NonCryptographicHashAlgorithm
{
	private struct State
	{
		private ulong _acc1;

		private ulong _acc2;

		private ulong _acc3;

		private ulong _acc4;

		private readonly ulong _smallAcc;

		private bool _hadFullStripe;

		internal State(ulong seed)
		{
			_acc1 = seed + 6983438078262162902L;
			_acc2 = seed + 14029467366897019727uL;
			_acc3 = seed;
			_acc4 = seed - 11400714785074694791uL;
			_smallAcc = seed + 2870177450012600261L;
			_hadFullStripe = false;
		}

		internal void ProcessStripe(ReadOnlySpan<byte> source)
		{
			source = source.Slice(0, 32);
			_acc1 = ApplyRound(_acc1, source);
			_acc2 = ApplyRound(_acc2, source.Slice(8));
			_acc3 = ApplyRound(_acc3, source.Slice(16));
			_acc4 = ApplyRound(_acc4, source.Slice(24));
			_hadFullStripe = true;
		}

		private static ulong MergeAccumulator(ulong acc, ulong accN)
		{
			acc ^= ApplyRound(0uL, accN);
			acc *= 11400714785074694791uL;
			acc += 9650029242287828579uL;
			return acc;
		}

		private readonly ulong Converge()
		{
			return MergeAccumulator(MergeAccumulator(MergeAccumulator(MergeAccumulator(BitOperations.RotateLeft(_acc1, 1) + BitOperations.RotateLeft(_acc2, 7) + BitOperations.RotateLeft(_acc3, 12) + BitOperations.RotateLeft(_acc4, 18), _acc1), _acc2), _acc3), _acc4);
		}

		private static ulong ApplyRound(ulong acc, ReadOnlySpan<byte> lane)
		{
			return ApplyRound(acc, BinaryPrimitives.ReadUInt64LittleEndian(lane));
		}

		private static ulong ApplyRound(ulong acc, ulong lane)
		{
			acc += (ulong)((long)lane * -4417276706812531889L);
			acc = BitOperations.RotateLeft(acc, 31);
			acc *= 11400714785074694791uL;
			return acc;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal readonly ulong Complete(long length, ReadOnlySpan<byte> remaining)
		{
			ulong num = (_hadFullStripe ? Converge() : _smallAcc);
			num += (ulong)length;
			while (remaining.Length >= 8)
			{
				ulong lane = BinaryPrimitives.ReadUInt64LittleEndian(remaining);
				num ^= ApplyRound(0uL, lane);
				num = BitOperations.RotateLeft(num, 27);
				num *= 11400714785074694791uL;
				num += 9650029242287828579uL;
				remaining = remaining.Slice(8);
			}
			if (remaining.Length >= 4)
			{
				ulong num2 = BinaryPrimitives.ReadUInt32LittleEndian(remaining);
				num ^= (ulong)((long)num2 * -7046029288634856825L);
				num = BitOperations.RotateLeft(num, 23);
				num *= 14029467366897019727uL;
				num += 1609587929392839161L;
				remaining = remaining.Slice(4);
			}
			for (int i = 0; i < remaining.Length; i++)
			{
				ulong num3 = remaining[i];
				num ^= num3 * 2870177450012600261L;
				num = BitOperations.RotateLeft(num, 11);
				num *= 11400714785074694791uL;
			}
			return Avalanche(num);
		}
	}

	private const int HashSize = 8;

	private const int StripeSize = 32;

	private readonly ulong _seed;

	private State _state;

	private byte[] _holdback;

	private long _length;

	public XxHash64()
		: this(0L)
	{
	}

	public XxHash64(long seed)
		: base(8)
	{
		_seed = (ulong)seed;
		Reset();
	}

	public override void Reset()
	{
		_state = new State(_seed);
		_length = 0L;
	}

	public override void Append(ReadOnlySpan<byte> source)
	{
		int num = (int)_length & 0x1F;
		if (num != 0)
		{
			int num2 = 32 - num;
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
		while (source.Length >= 32)
		{
			_state.ProcessStripe(source);
			source = source.Slice(32);
			_length += 32L;
		}
		if (source.Length > 0)
		{
			if (_holdback == null)
			{
				_holdback = new byte[32];
			}
			source.CopyTo(_holdback);
			_length += source.Length;
		}
	}

	protected override void GetCurrentHashCore(Span<byte> destination)
	{
		ulong currentHashAsUInt = GetCurrentHashAsUInt64();
		BinaryPrimitives.WriteUInt64BigEndian(destination, currentHashAsUInt);
	}

	[CLSCompliant(false)]
	public ulong GetCurrentHashAsUInt64()
	{
		int num = (int)_length & 0x1F;
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
		return Hash(new ReadOnlySpan<byte>(source), 0L);
	}

	public static byte[] Hash(byte[] source, long seed)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return Hash(new ReadOnlySpan<byte>(source), seed);
	}

	public static byte[] Hash(ReadOnlySpan<byte> source, long seed = 0L)
	{
		byte[] array = new byte[8];
		BinaryPrimitives.WriteUInt64BigEndian(value: HashToUInt64(source, seed), destination: array);
		return array;
	}

	public static bool TryHash(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten, long seed = 0L)
	{
		if (destination.Length < 8)
		{
			bytesWritten = 0;
			return false;
		}
		ulong value = HashToUInt64(source, seed);
		BinaryPrimitives.WriteUInt64BigEndian(destination, value);
		bytesWritten = 8;
		return true;
	}

	public static int Hash(ReadOnlySpan<byte> source, Span<byte> destination, long seed = 0L)
	{
		if (destination.Length < 8)
		{
			NonCryptographicHashAlgorithm.ThrowDestinationTooShort();
		}
		ulong value = HashToUInt64(source, seed);
		BinaryPrimitives.WriteUInt64BigEndian(destination, value);
		return 8;
	}

	[CLSCompliant(false)]
	public static ulong HashToUInt64(ReadOnlySpan<byte> source, long seed = 0L)
	{
		int length = source.Length;
		State state = new State((ulong)seed);
		while (source.Length >= 32)
		{
			state.ProcessStripe(source);
			source = source.Slice(32);
		}
		return state.Complete((uint)length, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static ulong Avalanche(ulong hash)
	{
		hash ^= hash >> 33;
		hash *= 14029467366897019727uL;
		hash ^= hash >> 29;
		hash *= 1609587929392839161L;
		hash ^= hash >> 32;
		return hash;
	}
}
