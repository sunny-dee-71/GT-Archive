using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal class BlittableStructTests
{
	public static StructInt structIntProperty
	{
		get
		{
			get_structIntProperty_Injected(out var ret);
			return ret;
		}
		set
		{
			set_structIntProperty_Injected(ref value);
		}
	}

	[NativeThrows]
	public static void ParameterStructInt(StructInt param)
	{
		ParameterStructInt_Injected(ref param);
	}

	public static void ParameterStructInt2(StructInt2 param)
	{
		ParameterStructInt2_Injected(ref param);
	}

	public static StructInt ReturnStructInt()
	{
		ReturnStructInt_Injected(out var ret);
		return ret;
	}

	[NativeThrows]
	public static void ParameterNestedBlittableStruct(StructNestedBlittable s)
	{
		ParameterNestedBlittableStruct_Injected(ref s);
	}

	public static StructNestedBlittable ReturnNestedBlittableStruct()
	{
		ReturnNestedBlittableStruct_Injected(out var ret);
		return ret;
	}

	[NativeThrows]
	public unsafe static void ParameterStructIntDynamicArray(StructInt[] param)
	{
		Span<StructInt> span = new Span<StructInt>(param);
		fixed (StructInt* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterStructIntDynamicArray_Injected(ref param2);
		}
	}

	public static StructInt[] ReturnStructIntDynamicArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		StructInt[] result;
		try
		{
			ReturnStructIntDynamicArray_Injected(out ret);
		}
		finally
		{
			StructInt[] array = default(StructInt[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[NativeThrows]
	public unsafe static void ParameterStructNestedBlittableDynamicArray(StructNestedBlittable[] param)
	{
		Span<StructNestedBlittable> span = new Span<StructNestedBlittable>(param);
		fixed (StructNestedBlittable* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterStructNestedBlittableDynamicArray_Injected(ref param2);
		}
	}

	public static StructNestedBlittable[] ReturnStructNestedBlittableDynamicArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		StructNestedBlittable[] result;
		try
		{
			ReturnStructNestedBlittableDynamicArray_Injected(out ret);
		}
		finally
		{
			StructNestedBlittable[] array = default(StructNestedBlittable[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[NativeThrows]
	public static void ParameterStructFixedBuffer(StructFixedBuffer param)
	{
		ParameterStructFixedBuffer_Injected(ref param);
	}

	public static StructFixedBuffer ReturnStructFixedBuffer()
	{
		ReturnStructFixedBuffer_Injected(out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructInt_Injected([In] ref StructInt param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructInt2_Injected([In] ref StructInt2 param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnStructInt_Injected(out StructInt ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterNestedBlittableStruct_Injected([In] ref StructNestedBlittable s);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnNestedBlittableStruct_Injected(out StructNestedBlittable ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructIntDynamicArray_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnStructIntDynamicArray_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructNestedBlittableDynamicArray_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnStructNestedBlittableDynamicArray_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructFixedBuffer_Injected([In] ref StructFixedBuffer param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnStructFixedBuffer_Injected(out StructFixedBuffer ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_structIntProperty_Injected(out StructInt ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_structIntProperty_Injected([In] ref StructInt value);
}
