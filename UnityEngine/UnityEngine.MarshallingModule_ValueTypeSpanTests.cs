using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine;

[NativeType("Modules/Marshalling/MarshallingTests.h")]
internal class ValueTypeSpanTests
{
	[NativeThrows]
	public unsafe static void ParameterIntReadOnlySpan(ReadOnlySpan<int> param)
	{
		ReadOnlySpan<int> readOnlySpan = param;
		fixed (int* begin = readOnlySpan)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
			ParameterIntReadOnlySpan_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterIntSpan(Span<int> param)
	{
		Span<int> span = param;
		fixed (int* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterIntSpan_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterBoolReadOnlySpan(ReadOnlySpan<bool> param)
	{
		ReadOnlySpan<bool> readOnlySpan = param;
		fixed (bool* begin = readOnlySpan)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
			ParameterBoolReadOnlySpan_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterCharReadOnlySpan(ReadOnlySpan<char> param)
	{
		ReadOnlySpan<char> readOnlySpan = param;
		fixed (char* begin = readOnlySpan)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
			ParameterCharReadOnlySpan_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterEnumReadOnlySpan(ReadOnlySpan<SomeEnum> param)
	{
		ReadOnlySpan<SomeEnum> readOnlySpan = param;
		fixed (SomeEnum* begin = readOnlySpan)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
			ParameterEnumReadOnlySpan_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterBlittableCornerCaseStructReadOnlySpan(ReadOnlySpan<BlittableCornerCases> param)
	{
		ReadOnlySpan<BlittableCornerCases> readOnlySpan = param;
		fixed (BlittableCornerCases* begin = readOnlySpan)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
			ParameterBlittableCornerCaseStructReadOnlySpan_Injected(ref param2);
		}
	}

	public static Span<int> ReturnsArrayRefWritableAsSpan(int val1, int val2, int val3)
	{
		ReturnsArrayRefWritableAsSpan_Injected(val1, val2, val3, out var ret);
		return ManagedSpanWrapper.ToSpan<int>(ret);
	}

	public static Span<int> ReturnsCoreVectorRefAsSpan(int val1, int val2, int val3)
	{
		ReturnsCoreVectorRefAsSpan_Injected(val1, val2, val3, out var ret);
		return ManagedSpanWrapper.ToSpan<int>(ret);
	}

	public static Span<int> ReturnsScriptingSpanAsSpan(int val1, int val2, int val3)
	{
		ReturnsScriptingSpanAsSpan_Injected(val1, val2, val3, out var ret);
		return ManagedSpanWrapper.ToSpan<int>(ret);
	}

	public static ReadOnlySpan<int> ReturnsArrayRefWritableAsReadOnlySpan(int val1, int val2, int val3)
	{
		ReturnsArrayRefWritableAsReadOnlySpan_Injected(val1, val2, val3, out var ret);
		return ManagedSpanWrapper.ToReadOnlySpan<int>(ret);
	}

	public static ReadOnlySpan<int> ReturnsCoreVectorRefAsReadOnlySpan(int val1, int val2, int val3)
	{
		ReturnsCoreVectorRefAsReadOnlySpan_Injected(val1, val2, val3, out var ret);
		return ManagedSpanWrapper.ToReadOnlySpan<int>(ret);
	}

	public static ReadOnlySpan<int> ReturnsArrayRefAsReadOnlySpan(int val1, int val2, int val3)
	{
		ReturnsArrayRefAsReadOnlySpan_Injected(val1, val2, val3, out var ret);
		return ManagedSpanWrapper.ToReadOnlySpan<int>(ret);
	}

	public static ReadOnlySpan<int> ReturnsScriptingReadOnlySpanAsSpan(int val1, int val2, int val3)
	{
		ReturnsScriptingReadOnlySpanAsSpan_Injected(val1, val2, val3, out var ret);
		return ManagedSpanWrapper.ToReadOnlySpan<int>(ret);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntReadOnlySpan_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntSpan_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterBoolReadOnlySpan_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterCharReadOnlySpan_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterEnumReadOnlySpan_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterBlittableCornerCaseStructReadOnlySpan_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnsArrayRefWritableAsSpan_Injected(int val1, int val2, int val3, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnsCoreVectorRefAsSpan_Injected(int val1, int val2, int val3, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnsScriptingSpanAsSpan_Injected(int val1, int val2, int val3, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnsArrayRefWritableAsReadOnlySpan_Injected(int val1, int val2, int val3, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnsCoreVectorRefAsReadOnlySpan_Injected(int val1, int val2, int val3, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnsArrayRefAsReadOnlySpan_Injected(int val1, int val2, int val3, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnsScriptingReadOnlySpanAsSpan_Injected(int val1, int val2, int val3, out ManagedSpanWrapper ret);
}
