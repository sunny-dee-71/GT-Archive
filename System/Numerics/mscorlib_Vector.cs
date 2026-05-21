using System.Runtime.CompilerServices;

namespace System.Numerics;

[Intrinsic]
public static class Vector
{
	public static bool IsHardwareAccelerated
	{
		[Intrinsic]
		get
		{
			return false;
		}
	}

	[CLSCompliant(false)]
	[Intrinsic]
	public unsafe static void Widen(Vector<byte> source, out Vector<ushort> low, out Vector<ushort> high)
	{
		int count = Vector<byte>.Count;
		ushort* ptr = stackalloc ushort[count / 2];
		for (int i = 0; i < count / 2; i++)
		{
			ptr[i] = source[i];
		}
		ushort* ptr2 = stackalloc ushort[count / 2];
		for (int j = 0; j < count / 2; j++)
		{
			ptr2[j] = source[j + count / 2];
		}
		low = new Vector<ushort>(ptr);
		high = new Vector<ushort>(ptr2);
	}

	[Intrinsic]
	[CLSCompliant(false)]
	public unsafe static void Widen(Vector<ushort> source, out Vector<uint> low, out Vector<uint> high)
	{
		int count = Vector<ushort>.Count;
		uint* ptr = stackalloc uint[count / 2];
		for (int i = 0; i < count / 2; i++)
		{
			ptr[i] = source[i];
		}
		uint* ptr2 = stackalloc uint[count / 2];
		for (int j = 0; j < count / 2; j++)
		{
			ptr2[j] = source[j + count / 2];
		}
		low = new Vector<uint>(ptr);
		high = new Vector<uint>(ptr2);
	}

	[Intrinsic]
	[CLSCompliant(false)]
	public unsafe static void Widen(Vector<uint> source, out Vector<ulong> low, out Vector<ulong> high)
	{
		int count = Vector<uint>.Count;
		ulong* ptr = stackalloc ulong[count / 2];
		for (int i = 0; i < count / 2; i++)
		{
			ptr[i] = source[i];
		}
		ulong* ptr2 = stackalloc ulong[count / 2];
		for (int j = 0; j < count / 2; j++)
		{
			ptr2[j] = source[j + count / 2];
		}
		low = new Vector<ulong>(ptr);
		high = new Vector<ulong>(ptr2);
	}

	[CLSCompliant(false)]
	[Intrinsic]
	public unsafe static void Widen(Vector<sbyte> source, out Vector<short> low, out Vector<short> high)
	{
		int count = Vector<sbyte>.Count;
		short* ptr = stackalloc short[count / 2];
		for (int i = 0; i < count / 2; i++)
		{
			ptr[i] = source[i];
		}
		short* ptr2 = stackalloc short[count / 2];
		for (int j = 0; j < count / 2; j++)
		{
			ptr2[j] = source[j + count / 2];
		}
		low = new Vector<short>(ptr);
		high = new Vector<short>(ptr2);
	}

	[Intrinsic]
	public unsafe static void Widen(Vector<short> source, out Vector<int> low, out Vector<int> high)
	{
		int count = Vector<short>.Count;
		int* ptr = stackalloc int[count / 2];
		for (int i = 0; i < count / 2; i++)
		{
			ptr[i] = source[i];
		}
		int* ptr2 = stackalloc int[count / 2];
		for (int j = 0; j < count / 2; j++)
		{
			ptr2[j] = source[j + count / 2];
		}
		low = new Vector<int>(ptr);
		high = new Vector<int>(ptr2);
	}

	[Intrinsic]
	public unsafe static void Widen(Vector<int> source, out Vector<long> low, out Vector<long> high)
	{
		int count = Vector<int>.Count;
		long* ptr = stackalloc long[count / 2];
		for (int i = 0; i < count / 2; i++)
		{
			ptr[i] = source[i];
		}
		long* ptr2 = stackalloc long[count / 2];
		for (int j = 0; j < count / 2; j++)
		{
			ptr2[j] = source[j + count / 2];
		}
		low = new Vector<long>(ptr);
		high = new Vector<long>(ptr2);
	}

	[Intrinsic]
	public unsafe static void Widen(Vector<float> source, out Vector<double> low, out Vector<double> high)
	{
		int count = Vector<float>.Count;
		double* ptr = stackalloc double[count / 2];
		for (int i = 0; i < count / 2; i++)
		{
			ptr[i] = source[i];
		}
		double* ptr2 = stackalloc double[count / 2];
		for (int j = 0; j < count / 2; j++)
		{
			ptr2[j] = source[j + count / 2];
		}
		low = new Vector<double>(ptr);
		high = new Vector<double>(ptr2);
	}

	[Intrinsic]
	[CLSCompliant(false)]
	public unsafe static Vector<byte> Narrow(Vector<ushort> low, Vector<ushort> high)
	{
		int count = Vector<byte>.Count;
		byte* ptr = stackalloc byte[(int)(uint)count];
		for (int i = 0; i < count / 2; i++)
		{
			ptr[i] = (byte)low[i];
		}
		for (int j = 0; j < count / 2; j++)
		{
			ptr[j + count / 2] = (byte)high[j];
		}
		return new Vector<byte>(ptr);
	}

	[CLSCompliant(false)]
	[Intrinsic]
	public unsafe static Vector<ushort> Narrow(Vector<uint> low, Vector<uint> high)
	{
		int count = Vector<ushort>.Count;
		ushort* ptr = stackalloc ushort[count];
		for (int i = 0; i < count / 2; i++)
		{
			ptr[i] = (ushort)low[i];
		}
		for (int j = 0; j < count / 2; j++)
		{
			ptr[j + count / 2] = (ushort)high[j];
		}
		return new Vector<ushort>(ptr);
	}

	[Intrinsic]
	[CLSCompliant(false)]
	public unsafe static Vector<uint> Narrow(Vector<ulong> low, Vector<ulong> high)
	{
		int count = Vector<uint>.Count;
		uint* ptr = stackalloc uint[count];
		for (int i = 0; i < count / 2; i++)
		{
			ptr[i] = (uint)low[i];
		}
		for (int j = 0; j < count / 2; j++)
		{
			ptr[j + count / 2] = (uint)high[j];
		}
		return new Vector<uint>(ptr);
	}

	[Intrinsic]
	[CLSCompliant(false)]
	public unsafe static Vector<sbyte> Narrow(Vector<short> low, Vector<short> high)
	{
		int count = Vector<sbyte>.Count;
		sbyte* ptr = stackalloc sbyte[(int)(uint)count];
		for (int i = 0; i < count / 2; i++)
		{
			ptr[i] = (sbyte)low[i];
		}
		for (int j = 0; j < count / 2; j++)
		{
			ptr[j + count / 2] = (sbyte)high[j];
		}
		return new Vector<sbyte>(ptr);
	}

	[Intrinsic]
	public unsafe static Vector<short> Narrow(Vector<int> low, Vector<int> high)
	{
		int count = Vector<short>.Count;
		short* ptr = stackalloc short[count];
		for (int i = 0; i < count / 2; i++)
		{
			ptr[i] = (short)low[i];
		}
		for (int j = 0; j < count / 2; j++)
		{
			ptr[j + count / 2] = (short)high[j];
		}
		return new Vector<short>(ptr);
	}

	[Intrinsic]
	public unsafe static Vector<int> Narrow(Vector<long> low, Vector<long> high)
	{
		int count = Vector<int>.Count;
		int* ptr = stackalloc int[count];
		for (int i = 0; i < count / 2; i++)
		{
			ptr[i] = (int)low[i];
		}
		for (int j = 0; j < count / 2; j++)
		{
			ptr[j + count / 2] = (int)high[j];
		}
		return new Vector<int>(ptr);
	}

	[Intrinsic]
	public unsafe static Vector<float> Narrow(Vector<double> low, Vector<double> high)
	{
		int count = Vector<float>.Count;
		float* ptr = stackalloc float[count];
		for (int i = 0; i < count / 2; i++)
		{
			ptr[i] = (float)low[i];
		}
		for (int j = 0; j < count / 2; j++)
		{
			ptr[j + count / 2] = (float)high[j];
		}
		return new Vector<float>(ptr);
	}

	[Intrinsic]
	public unsafe static Vector<float> ConvertToSingle(Vector<int> value)
	{
		int count = Vector<float>.Count;
		float* ptr = stackalloc float[count];
		for (int i = 0; i < count; i++)
		{
			ptr[i] = value[i];
		}
		return new Vector<float>(ptr);
	}

	[Intrinsic]
	[CLSCompliant(false)]
	public unsafe static Vector<float> ConvertToSingle(Vector<uint> value)
	{
		int count = Vector<float>.Count;
		float* ptr = stackalloc float[count];
		for (int i = 0; i < count; i++)
		{
			ptr[i] = value[i];
		}
		return new Vector<float>(ptr);
	}

	[Intrinsic]
	public unsafe static Vector<double> ConvertToDouble(Vector<long> value)
	{
		int count = Vector<double>.Count;
		double* ptr = stackalloc double[count];
		for (int i = 0; i < count; i++)
		{
			ptr[i] = value[i];
		}
		return new Vector<double>(ptr);
	}

	[Intrinsic]
	[CLSCompliant(false)]
	public unsafe static Vector<double> ConvertToDouble(Vector<ulong> value)
	{
		int count = Vector<double>.Count;
		double* ptr = stackalloc double[count];
		for (int i = 0; i < count; i++)
		{
			ptr[i] = value[i];
		}
		return new Vector<double>(ptr);
	}

	[Intrinsic]
	public unsafe static Vector<int> ConvertToInt32(Vector<float> value)
	{
		int count = Vector<int>.Count;
		int* ptr = stackalloc int[count];
		for (int i = 0; i < count; i++)
		{
			ptr[i] = (int)value[i];
		}
		return new Vector<int>(ptr);
	}

	[CLSCompliant(false)]
	[Intrinsic]
	public unsafe static Vector<uint> ConvertToUInt32(Vector<float> value)
	{
		int count = Vector<uint>.Count;
		uint* ptr = stackalloc uint[count];
		for (int i = 0; i < count; i++)
		{
			ptr[i] = (uint)value[i];
		}
		return new Vector<uint>(ptr);
	}

	[Intrinsic]
	public unsafe static Vector<long> ConvertToInt64(Vector<double> value)
	{
		int count = Vector<long>.Count;
		long* ptr = stackalloc long[count];
		for (int i = 0; i < count; i++)
		{
			ptr[i] = (long)value[i];
		}
		return new Vector<long>(ptr);
	}

	[Intrinsic]
	[CLSCompliant(false)]
	public unsafe static Vector<ulong> ConvertToUInt64(Vector<double> value)
	{
		int count = Vector<ulong>.Count;
		ulong* ptr = stackalloc ulong[count];
		for (int i = 0; i < count; i++)
		{
			ptr[i] = (ulong)value[i];
		}
		return new Vector<ulong>(ptr);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<float> ConditionalSelect(Vector<int> condition, Vector<float> left, Vector<float> right)
	{
		return Vector<float>.ConditionalSelect((Vector<float>)condition, left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<double> ConditionalSelect(Vector<long> condition, Vector<double> left, Vector<double> right)
	{
		return Vector<double>.ConditionalSelect((Vector<double>)condition, left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> ConditionalSelect<T>(Vector<T> condition, Vector<T> left, Vector<T> right) where T : struct
	{
		return Vector<T>.ConditionalSelect(condition, left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> Equals<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return Vector<T>.Equals(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<int> Equals(Vector<float> left, Vector<float> right)
	{
		return (Vector<int>)Vector<float>.Equals(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<int> Equals(Vector<int> left, Vector<int> right)
	{
		return Vector<int>.Equals(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<long> Equals(Vector<double> left, Vector<double> right)
	{
		return (Vector<long>)Vector<double>.Equals(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<long> Equals(Vector<long> left, Vector<long> right)
	{
		return Vector<long>.Equals(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool EqualsAll<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return left == right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool EqualsAny<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return !Vector<T>.Equals(left, right).Equals(Vector<T>.Zero);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> LessThan<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return Vector<T>.LessThan(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<int> LessThan(Vector<float> left, Vector<float> right)
	{
		return (Vector<int>)Vector<float>.LessThan(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<int> LessThan(Vector<int> left, Vector<int> right)
	{
		return Vector<int>.LessThan(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<long> LessThan(Vector<double> left, Vector<double> right)
	{
		return (Vector<long>)Vector<double>.LessThan(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<long> LessThan(Vector<long> left, Vector<long> right)
	{
		return Vector<long>.LessThan(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool LessThanAll<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return ((Vector<int>)Vector<T>.LessThan(left, right)).Equals(Vector<int>.AllOnes);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool LessThanAny<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return !((Vector<int>)Vector<T>.LessThan(left, right)).Equals(Vector<int>.Zero);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> LessThanOrEqual<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return Vector<T>.LessThanOrEqual(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<int> LessThanOrEqual(Vector<float> left, Vector<float> right)
	{
		return (Vector<int>)Vector<float>.LessThanOrEqual(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<int> LessThanOrEqual(Vector<int> left, Vector<int> right)
	{
		return Vector<int>.LessThanOrEqual(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<long> LessThanOrEqual(Vector<long> left, Vector<long> right)
	{
		return Vector<long>.LessThanOrEqual(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<long> LessThanOrEqual(Vector<double> left, Vector<double> right)
	{
		return (Vector<long>)Vector<double>.LessThanOrEqual(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool LessThanOrEqualAll<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return ((Vector<int>)Vector<T>.LessThanOrEqual(left, right)).Equals(Vector<int>.AllOnes);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool LessThanOrEqualAny<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return !((Vector<int>)Vector<T>.LessThanOrEqual(left, right)).Equals(Vector<int>.Zero);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> GreaterThan<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return Vector<T>.GreaterThan(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<int> GreaterThan(Vector<float> left, Vector<float> right)
	{
		return (Vector<int>)Vector<float>.GreaterThan(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<int> GreaterThan(Vector<int> left, Vector<int> right)
	{
		return Vector<int>.GreaterThan(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<long> GreaterThan(Vector<double> left, Vector<double> right)
	{
		return (Vector<long>)Vector<double>.GreaterThan(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<long> GreaterThan(Vector<long> left, Vector<long> right)
	{
		return Vector<long>.GreaterThan(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GreaterThanAll<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return ((Vector<int>)Vector<T>.GreaterThan(left, right)).Equals(Vector<int>.AllOnes);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GreaterThanAny<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return !((Vector<int>)Vector<T>.GreaterThan(left, right)).Equals(Vector<int>.Zero);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> GreaterThanOrEqual<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return Vector<T>.GreaterThanOrEqual(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<int> GreaterThanOrEqual(Vector<float> left, Vector<float> right)
	{
		return (Vector<int>)Vector<float>.GreaterThanOrEqual(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<int> GreaterThanOrEqual(Vector<int> left, Vector<int> right)
	{
		return Vector<int>.GreaterThanOrEqual(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<long> GreaterThanOrEqual(Vector<long> left, Vector<long> right)
	{
		return Vector<long>.GreaterThanOrEqual(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<long> GreaterThanOrEqual(Vector<double> left, Vector<double> right)
	{
		return (Vector<long>)Vector<double>.GreaterThanOrEqual(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GreaterThanOrEqualAll<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return ((Vector<int>)Vector<T>.GreaterThanOrEqual(left, right)).Equals(Vector<int>.AllOnes);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GreaterThanOrEqualAny<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return !((Vector<int>)Vector<T>.GreaterThanOrEqual(left, right)).Equals(Vector<int>.Zero);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> Abs<T>(Vector<T> value) where T : struct
	{
		return Vector<T>.Abs(value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> Min<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return Vector<T>.Min(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> Max<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return Vector<T>.Max(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T Dot<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return Vector<T>.DotProduct(left, right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> SquareRoot<T>(Vector<T> value) where T : struct
	{
		return Vector<T>.SquareRoot(value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> Add<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return left + right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> Subtract<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return left - right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> Multiply<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return left * right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> Multiply<T>(Vector<T> left, T right) where T : struct
	{
		return left * right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> Multiply<T>(T left, Vector<T> right) where T : struct
	{
		return left * right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> Divide<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return left / right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> Negate<T>(Vector<T> value) where T : struct
	{
		return -value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> BitwiseAnd<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return left & right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> BitwiseOr<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return left | right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> OnesComplement<T>(Vector<T> value) where T : struct
	{
		return ~value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> Xor<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return left ^ right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<T> AndNot<T>(Vector<T> left, Vector<T> right) where T : struct
	{
		return left & ~right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<byte> AsVectorByte<T>(Vector<T> value) where T : struct
	{
		return (Vector<byte>)value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[CLSCompliant(false)]
	public static Vector<sbyte> AsVectorSByte<T>(Vector<T> value) where T : struct
	{
		return (Vector<sbyte>)value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[CLSCompliant(false)]
	public static Vector<ushort> AsVectorUInt16<T>(Vector<T> value) where T : struct
	{
		return (Vector<ushort>)value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<short> AsVectorInt16<T>(Vector<T> value) where T : struct
	{
		return (Vector<short>)value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[CLSCompliant(false)]
	public static Vector<uint> AsVectorUInt32<T>(Vector<T> value) where T : struct
	{
		return (Vector<uint>)value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<int> AsVectorInt32<T>(Vector<T> value) where T : struct
	{
		return (Vector<int>)value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[CLSCompliant(false)]
	public static Vector<ulong> AsVectorUInt64<T>(Vector<T> value) where T : struct
	{
		return (Vector<ulong>)value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<long> AsVectorInt64<T>(Vector<T> value) where T : struct
	{
		return (Vector<long>)value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<float> AsVectorSingle<T>(Vector<T> value) where T : struct
	{
		return (Vector<float>)value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector<double> AsVectorDouble<T>(Vector<T> value) where T : struct
	{
		return (Vector<double>)value;
	}
}
