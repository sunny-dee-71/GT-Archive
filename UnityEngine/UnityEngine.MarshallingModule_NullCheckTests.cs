using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal class NullCheckTests
{
	public unsafe static void StringParameterNullAllowed(string param)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					StringParameterNullAllowed_Injected(ref managedSpanWrapper);
					return;
				}
			}
			StringParameterNullAllowed_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	public unsafe static void StringParameterNullNotAllowed([NotNull] string param)
	{
		//The blocks IL_0038 are reachable both inside and outside the pinned region starting at IL_0027. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		if (param == null)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					StringParameterNullNotAllowed_Injected(ref managedSpanWrapper);
					return;
				}
			}
			StringParameterNullNotAllowed_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	public unsafe static void ArrayParameterNullAllowed(int[] param)
	{
		Span<int> span = new Span<int>(param);
		fixed (int* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ArrayParameterNullAllowed_Injected(ref param2);
		}
	}

	public unsafe static void ArrayParameterNullNotAllowed([NotNull] int[] param)
	{
		if (param == null)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		Span<int> span = new Span<int>(param);
		fixed (int* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ArrayParameterNullNotAllowed_Injected(ref param2);
		}
	}

	[NativeThrows]
	public static void ObjectParameterNullAllowed(MarshallingTestObject param)
	{
		ObjectParameterNullAllowed_Injected(Object.MarshalledUnityObject.Marshal(param));
	}

	public static void ObjectParameterNullNotAllowed([NotNull] MarshallingTestObject param)
	{
		if ((object)param == null)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(param);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		ObjectParameterNullNotAllowed_Injected(intPtr);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void WritableObjectParameterNullAllowed([Writable] MarshallingTestObject param);

	public static void WritableObjectParameterNullNotAllowed([Writable][NotNull] MarshallingTestObject param)
	{
		if ((object)param == null)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		WritableObjectParameterNullNotAllowed_Injected(param);
	}

	[NativeThrows]
	public static void IntPtrObjectParameterNullAllowed(MyIntPtrObject param)
	{
		IntPtrObjectParameterNullAllowed_Injected((param == null) ? ((IntPtr)0) : MyIntPtrObject.BindingsMarshaller.ConvertToNative(param));
	}

	public static void IntPtrObjectParameterNullNotAllowed([NotNull] MyIntPtrObject param)
	{
		if (param == null)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		IntPtr intPtr = MyIntPtrObject.BindingsMarshaller.ConvertToNative(param);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		IntPtrObjectParameterNullNotAllowed_Injected(intPtr);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void StringParameterNullAllowed_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void StringParameterNullNotAllowed_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ArrayParameterNullAllowed_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ArrayParameterNullNotAllowed_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ObjectParameterNullAllowed_Injected(IntPtr param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ObjectParameterNullNotAllowed_Injected(IntPtr param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void WritableObjectParameterNullNotAllowed_Injected([Writable] MarshallingTestObject param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void IntPtrObjectParameterNullAllowed_Injected(IntPtr param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void IntPtrObjectParameterNullNotAllowed_Injected(IntPtr param);
}
