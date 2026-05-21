using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[NativeHeader("MarshallingScriptingClasses.h")]
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal class PrimitiveTests
{
	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void ParameterBool(bool param1, bool param2, int param3);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void ParameterInt(int param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void ParameterOutInt(out int param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void ParameterRefInt(ref int param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern int ReturnInt();

	[NativeThrows]
	public unsafe static void ParameterIntDynamicArray(int[] param)
	{
		Span<int> span = new Span<int>(param);
		fixed (int* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterIntDynamicArray_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterIntNullableDynamicArray(int[] param)
	{
		Span<int> span = new Span<int>(param);
		fixed (int* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterIntNullableDynamicArray_Injected(ref param2);
		}
	}

	public static int[] ReturnIntDynamicArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		int[] result;
		try
		{
			ReturnIntDynamicArray_Injected(out ret);
		}
		finally
		{
			int[] array = default(int[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static int[] ReturnNullIntDynamicArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		int[] result;
		try
		{
			ReturnNullIntDynamicArray_Injected(out ret);
		}
		finally
		{
			int[] array = default(int[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static bool[] ReturnBoolDynamicArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		bool[] result;
		try
		{
			ReturnBoolDynamicArray_Injected(out ret);
		}
		finally
		{
			bool[] array = default(bool[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static char[] ReturnCharDynamicArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		char[] result;
		try
		{
			ReturnCharDynamicArray_Injected(out ret);
		}
		finally
		{
			char[] array = default(char[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntDynamicArray_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntNullableDynamicArray_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnIntDynamicArray_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnNullIntDynamicArray_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnBoolDynamicArray_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnCharDynamicArray_Injected(out BlittableArrayWrapper ret);
}
