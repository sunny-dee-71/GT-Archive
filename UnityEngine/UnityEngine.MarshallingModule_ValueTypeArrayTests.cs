using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine;

[NativeType("Modules/Marshalling/MarshallingTests.h")]
internal class ValueTypeArrayTests
{
	[NativeThrows]
	public unsafe static void ParameterIntArrayReadOnly(int[] param)
	{
		Span<int> span = new Span<int>(param);
		fixed (int* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterIntArrayReadOnly_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterIntArrayWritable(int[] param)
	{
		Span<int> span = new Span<int>(param);
		fixed (int* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterIntArrayWritable_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterIntArrayEmpty(int[] param, int[] param2)
	{
		Span<int> span = new Span<int>(param);
		fixed (int* begin = span)
		{
			ManagedSpanWrapper param3 = new ManagedSpanWrapper(begin, span.Length);
			Span<int> span2 = new Span<int>(param2);
			fixed (int* begin2 = span2)
			{
				ManagedSpanWrapper param4 = new ManagedSpanWrapper(begin2, span2.Length);
				ParameterIntArrayEmpty_Injected(ref param3, ref param4);
			}
		}
	}

	public unsafe static void ParameterIntArrayNullExceptions([NotNull] int[] param)
	{
		if (param == null)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		Span<int> span = new Span<int>(param);
		fixed (int* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterIntArrayNullExceptions_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterIntMultidimensionalArray(int[,] param)
	{
		fixed (int[,] array = param)
		{
			int length;
			nint begin;
			if (param == null || (length = array.Length) == 0)
			{
				length = 0;
				begin = 0;
			}
			else
			{
				begin = (nint)Unsafe.AsPointer(ref array[0, 0]);
			}
			ManagedSpanWrapper param2 = new ManagedSpanWrapper((void*)begin, length);
			ParameterIntMultidimensionalArray_Injected(ref param2);
		}
	}

	public unsafe static void ParameterIntMultidimensionalArrayNullExceptions([NotNull] int[,] param)
	{
		if (param == null)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		fixed (int[,] array = param)
		{
			int length;
			nint begin;
			if (param == null || (length = array.Length) == 0)
			{
				length = 0;
				begin = 0;
			}
			else
			{
				begin = (nint)Unsafe.AsPointer(ref array[0, 0]);
			}
			ManagedSpanWrapper param2 = new ManagedSpanWrapper((void*)begin, length);
			ParameterIntMultidimensionalArrayNullExceptions_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterCharArrayReadOnly(char[] param)
	{
		Span<char> span = new Span<char>(param);
		fixed (char* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterCharArrayReadOnly_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterBlittableCornerCaseStructArrayReadOnly(BlittableCornerCases[] param)
	{
		Span<BlittableCornerCases> span = new Span<BlittableCornerCases>(param);
		fixed (BlittableCornerCases* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterBlittableCornerCaseStructArrayReadOnly_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterIntArrayOutAttr([Out] int[] param)
	{
		//The blocks IL_001b are reachable both inside and outside the pinned region starting at IL_0004. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper param2 = default(BlittableArrayWrapper);
		try
		{
			if (param != null)
			{
				fixed (int[] array = param)
				{
					if (array.Length != 0)
					{
						param2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					ParameterIntArrayOutAttr_Injected(out param2);
					return;
				}
			}
			ParameterIntArrayOutAttr_Injected(out param2);
		}
		finally
		{
			param2.Unmarshal(ref array);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterCharArrayOutAttr([Out] char[] param)
	{
		//The blocks IL_001b are reachable both inside and outside the pinned region starting at IL_0004. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper param2 = default(BlittableArrayWrapper);
		try
		{
			if (param != null)
			{
				fixed (char[] array = param)
				{
					if (array.Length != 0)
					{
						param2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					ParameterCharArrayOutAttr_Injected(out param2);
					return;
				}
			}
			ParameterCharArrayOutAttr_Injected(out param2);
		}
		finally
		{
			param2.Unmarshal(ref array);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterBlittableCornerCaseStructArrayOutAttr([Out] BlittableCornerCases[] param)
	{
		//The blocks IL_001b are reachable both inside and outside the pinned region starting at IL_0004. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper param2 = default(BlittableArrayWrapper);
		try
		{
			if (param != null)
			{
				fixed (BlittableCornerCases[] array = param)
				{
					if (array.Length != 0)
					{
						param2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					ParameterBlittableCornerCaseStructArrayOutAttr_Injected(out param2);
					return;
				}
			}
			ParameterBlittableCornerCaseStructArrayOutAttr_Injected(out param2);
		}
		finally
		{
			param2.Unmarshal(ref array);
		}
	}

	public static int[] ParameterIntArrayReturn()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		int[] result;
		try
		{
			ParameterIntArrayReturn_Injected(out ret);
		}
		finally
		{
			int[] array = default(int[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static int[] ParameterIntArrayReturnEmpty()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		int[] result;
		try
		{
			ParameterIntArrayReturnEmpty_Injected(out ret);
		}
		finally
		{
			int[] array = default(int[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static int[] ParameterIntArrayReturnNull()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		int[] result;
		try
		{
			ParameterIntArrayReturnNull_Injected(out ret);
		}
		finally
		{
			int[] array = default(int[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static char[] ParameterCharArrayReturn()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		char[] result;
		try
		{
			ParameterCharArrayReturn_Injected(out ret);
		}
		finally
		{
			char[] array = default(char[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static BlittableCornerCases[] ParameterBlittableCornerCaseStructArrayReturn()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		BlittableCornerCases[] result;
		try
		{
			ParameterBlittableCornerCaseStructArrayReturn_Injected(out ret);
		}
		finally
		{
			BlittableCornerCases[] array = default(BlittableCornerCases[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntArrayReadOnly_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntArrayWritable_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntArrayEmpty_Injected(ref ManagedSpanWrapper param, ref ManagedSpanWrapper param2);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntArrayNullExceptions_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntMultidimensionalArray_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntMultidimensionalArrayNullExceptions_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterCharArrayReadOnly_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterBlittableCornerCaseStructArrayReadOnly_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntArrayOutAttr_Injected(out BlittableArrayWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterCharArrayOutAttr_Injected(out BlittableArrayWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterBlittableCornerCaseStructArrayOutAttr_Injected(out BlittableArrayWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntArrayReturn_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntArrayReturnEmpty_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntArrayReturnNull_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterCharArrayReturn_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterBlittableCornerCaseStructArrayReturn_Injected(out BlittableArrayWrapper ret);
}
