using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.IO.Hashing;

public sealed class XxHash3 : NonCryptographicHashAlgorithm
{
	private new const int HashLengthInBytes = 8;

	private XxHashShared.State _state;

	public XxHash3()
		: this(0L)
	{
	}

	public XxHash3(long seed)
		: base(8)
	{
		XxHashShared.Initialize(ref _state, (ulong)seed);
	}

	public static byte[] Hash(byte[] source)
	{
		return Hash(source, 0L);
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

	public static int Hash(ReadOnlySpan<byte> source, Span<byte> destination, long seed = 0L)
	{
		if (!TryHash(source, destination, out var bytesWritten, seed))
		{
			NonCryptographicHashAlgorithm.ThrowDestinationTooShort();
		}
		return bytesWritten;
	}

	public static bool TryHash(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten, long seed = 0L)
	{
		if (destination.Length >= 8)
		{
			ulong value = HashToUInt64(source, seed);
			if (BitConverter.IsLittleEndian)
			{
				value = BinaryPrimitives.ReverseEndianness(value);
			}
			Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
			bytesWritten = 8;
			return true;
		}
		bytesWritten = 0;
		return false;
	}

	[CLSCompliant(false)]
	public unsafe static ulong HashToUInt64(ReadOnlySpan<byte> source, long seed = 0L)
	{
		uint length = (uint)source.Length;
		fixed (byte* reference = &MemoryMarshal.GetReference(source))
		{
			if (length <= 16)
			{
				return HashLength0To16(reference, length, (ulong)seed);
			}
			if (length <= 128)
			{
				return HashLength17To128(reference, length, (ulong)seed);
			}
			if (length <= 240)
			{
				return HashLength129To240(reference, length, (ulong)seed);
			}
			return HashLengthOver240(reference, length, (ulong)seed);
		}
	}

	public override void Reset()
	{
		XxHashShared.Reset(ref _state);
	}

	public override void Append(ReadOnlySpan<byte> source)
	{
		XxHashShared.Append(ref _state, source);
	}

	protected override void GetCurrentHashCore(Span<byte> destination)
	{
		ulong currentHashAsUInt = GetCurrentHashAsUInt64();
		BinaryPrimitives.WriteUInt64BigEndian(destination, currentHashAsUInt);
	}

	[CLSCompliant(false)]
	public unsafe ulong GetCurrentHashAsUInt64()
	{
		ulong result;
		if (_state.TotalLength > 240)
		{
			ulong* accumulators = stackalloc ulong[8];
			XxHashShared.CopyAccumulators(ref _state, accumulators);
			fixed (byte* secret = _state.Secret)
			{
				XxHashShared.DigestLong(ref _state, accumulators, secret);
				result = XxHashShared.MergeAccumulators(accumulators, secret + 11, _state.TotalLength * 11400714785074694791uL);
			}
		}
		else
		{
			fixed (byte* buffer = _state.Buffer)
			{
				result = HashToUInt64(new ReadOnlySpan<byte>(buffer, (int)_state.TotalLength), (long)_state.Seed);
			}
		}
		return result;
	}

	private unsafe static ulong HashLength0To16(byte* source, uint length, ulong seed)
	{
		switch (length)
		{
		default:
			return HashLength9To16(source, length, seed);
		case 4u:
		case 5u:
		case 6u:
		case 7u:
		case 8u:
			return HashLength4To8(source, length, seed);
		case 1u:
		case 2u:
		case 3u:
			return HashLength1To3(source, length, seed);
		case 0u:
			return XxHash64.Avalanche(seed ^ 0x8726F9105DC21DDCuL);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static ulong HashLength1To3(byte* source, uint length, ulong seed)
	{
		byte num = *source;
		byte b = source[length >> 1];
		byte b2 = source[length - 1];
		return XxHash64.Avalanche((uint)((num << 16) | (b << 24) | b2 | (int)(length << 8)) ^ (2267503259u + seed));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static ulong HashLength4To8(byte* source, uint length, ulong seed)
	{
		seed ^= (ulong)BinaryPrimitives.ReverseEndianness((uint)seed) << 32;
		uint num = XxHashShared.ReadUInt32LE(source);
		uint num2 = XxHashShared.ReadUInt32LE(source + length - 4);
		ulong num3 = 14355981877291832738uL - seed;
		return XxHashShared.Rrmxmx((num2 + ((ulong)num << 32)) ^ num3, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static ulong HashLength9To16(byte* source, uint length, ulong seed)
	{
		ulong num = 7458650908927343033L + seed;
		ulong num2 = 12634492766384443962uL - seed;
		ulong num3 = XxHashShared.ReadUInt64LE(source) ^ num;
		ulong num4 = XxHashShared.ReadUInt64LE(source + length - 8) ^ num2;
		return XxHashShared.Avalanche(length + BinaryPrimitives.ReverseEndianness(num3) + num4 + XxHashShared.Multiply64To128ThenFold(num3, num4));
	}

	private unsafe static ulong HashLength17To128(byte* source, uint length, ulong seed)
	{
		ulong num = (ulong)(length * -7046029288634856825L);
		switch ((length - 1) / 32)
		{
		default:
			num += XxHashShared.Mix16Bytes(source + 48, 4554437623014685352uL, 2111919702937427193uL, seed);
			num += XxHashShared.Mix16Bytes(source + length - 64, 3556072174620004746uL, 7238261902898274248uL, seed);
			goto case 2u;
		case 2u:
			num += XxHashShared.Mix16Bytes(source + 32, 14627906620379768892uL, 11758427054878871688uL, seed);
			num += XxHashShared.Mix16Bytes(source + length - 48, 5690594596133299313uL, 15613098826807580984uL, seed);
			goto case 1u;
		case 1u:
			num += XxHashShared.Mix16Bytes(source + 16, 8711581037947681227uL, 2410270004345854594uL, seed);
			num += XxHashShared.Mix16Bytes(source + length - 32, 10242386182634080440uL, 5487137525590930912uL, seed);
			break;
		case 0u:
			break;
		}
		num += XxHashShared.Mix16Bytes(source, 13712233961653862072uL, 2066345149520216444uL, seed);
		num += XxHashShared.Mix16Bytes(source + length - 16, 15823274712020931806uL, 2262974939099578482uL, seed);
		return XxHashShared.Avalanche(num);
	}

	private unsafe static ulong HashLength129To240(byte* source, uint length, ulong seed)
	{
		ulong num = (ulong)(length * -7046029288634856825L);
		num += XxHashShared.Mix16Bytes(source, 13712233961653862072uL, 2066345149520216444uL, seed);
		num += XxHashShared.Mix16Bytes(source + 16, 15823274712020931806uL, 2262974939099578482uL, seed);
		num += XxHashShared.Mix16Bytes(source + 32, 8711581037947681227uL, 2410270004345854594uL, seed);
		num += XxHashShared.Mix16Bytes(source + 48, 10242386182634080440uL, 5487137525590930912uL, seed);
		num += XxHashShared.Mix16Bytes(source + 64, 14627906620379768892uL, 11758427054878871688uL, seed);
		num += XxHashShared.Mix16Bytes(source + 80, 5690594596133299313uL, 15613098826807580984uL, seed);
		num += XxHashShared.Mix16Bytes(source + 96, 4554437623014685352uL, 2111919702937427193uL, seed);
		num += XxHashShared.Mix16Bytes(source + 112, 3556072174620004746uL, 7238261902898274248uL, seed);
		num = XxHashShared.Avalanche(num);
		switch ((length - 128) / 16)
		{
		default:
			num += XxHashShared.Mix16Bytes(source + 224, 13536968629829821247uL, 16163852396094277575uL, seed);
			goto case 6u;
		case 6u:
			num += XxHashShared.Mix16Bytes(source + 208, 17228863761319568023uL, 8573350489219836230uL, seed);
			goto case 5u;
		case 5u:
			num += XxHashShared.Mix16Bytes(source + 192, 7336514198459093435uL, 5216419214072683403uL, seed);
			goto case 4u;
		case 4u:
			num += XxHashShared.Mix16Bytes(source + 176, 10391458616325699444uL, 5920048007935066598uL, seed);
			goto case 3u;
		case 3u:
			num += XxHashShared.Mix16Bytes(source + 160, 15013455763555273806uL, 5046485836271438973uL, seed);
			goto case 2u;
		case 2u:
			num += XxHashShared.Mix16Bytes(source + 144, 11835586108195898345uL, 16607528436649670564uL, seed);
			goto case 1u;
		case 1u:
			num += XxHashShared.Mix16Bytes(source + 128, 9295848262624092985uL, 7914194659941938988uL, seed);
			break;
		case 0u:
			break;
		}
		num += XxHashShared.Mix16Bytes(source + length - 16, 8320639771003045937uL, 16992983559143025252uL, seed);
		return XxHashShared.Avalanche(num);
	}

	private unsafe static ulong HashLengthOver240(byte* source, uint length, ulong seed)
	{
		fixed (byte* reference = &MemoryMarshal.GetReference(XxHashShared.DefaultSecret))
		{
			byte* ptr = reference;
			if (seed != 0L)
			{
				byte* intPtr = stackalloc byte[192];
				XxHashShared.DeriveSecretFromSeed(intPtr, seed);
				ptr = intPtr;
			}
			byte* accumulators = stackalloc byte[64];
			XxHashShared.InitializeAccumulators((ulong*)accumulators);
			XxHashShared.HashInternalLoop((ulong*)accumulators, source, length, ptr);
			return XxHashShared.MergeAccumulators((ulong*)accumulators, ptr + 11, (ulong)(length * -7046029288634856825L));
		}
	}
}
