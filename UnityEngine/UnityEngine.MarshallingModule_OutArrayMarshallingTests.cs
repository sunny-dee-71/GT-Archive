using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/OutArrayMarshallingTests.h")]
internal static class OutArrayMarshallingTests
{
	public unsafe static void OutArrayOfPrimitiveTypeWorks([Out] int[] array, int value)
	{
		//The blocks IL_001b are reachable both inside and outside the pinned region starting at IL_0004. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper array3 = default(BlittableArrayWrapper);
		try
		{
			if (array != null)
			{
				fixed (int[] array2 = array)
				{
					if (array2.Length != 0)
					{
						array3 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
					}
					OutArrayOfPrimitiveTypeWorks_Injected(out array3, value);
					return;
				}
			}
			OutArrayOfPrimitiveTypeWorks_Injected(out array3, value);
		}
		finally
		{
			array3.Unmarshal(ref array2);
		}
	}

	public unsafe static void OutArrayOfStringTypeWorks([Out] string[] array, string value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(value);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					OutArrayOfStringTypeWorks_Injected(array, ref managedSpanWrapper);
					return;
				}
			}
			OutArrayOfStringTypeWorks_Injected(array, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	public unsafe static void OutArrayOfBlittableStructTypeWorks([Out] StructInt[] array, StructInt value)
	{
		//The blocks IL_001b are reachable both inside and outside the pinned region starting at IL_0004. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper array3 = default(BlittableArrayWrapper);
		try
		{
			if (array != null)
			{
				fixed (StructInt[] array2 = array)
				{
					if (array2.Length != 0)
					{
						array3 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
					}
					OutArrayOfBlittableStructTypeWorks_Injected(out array3, ref value);
					return;
				}
			}
			OutArrayOfBlittableStructTypeWorks_Injected(out array3, ref value);
		}
		finally
		{
			array3.Unmarshal(ref array2);
		}
	}

	public static void OutArrayOfIntPtrObjectTypeWorks([Out] MyIntPtrObject[] array, MyIntPtrObject value)
	{
		OutArrayOfIntPtrObjectTypeWorks_Injected(array, (value == null) ? ((IntPtr)0) : MyIntPtrObject.BindingsMarshaller.ConvertToNative(value));
	}

	public unsafe static void OutArrayOfNestedBlittableStructTypeWorks([Out] StructNestedBlittable[] array, StructNestedBlittable value)
	{
		//The blocks IL_001b are reachable both inside and outside the pinned region starting at IL_0004. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper array3 = default(BlittableArrayWrapper);
		try
		{
			if (array != null)
			{
				fixed (StructNestedBlittable[] array2 = array)
				{
					if (array2.Length != 0)
					{
						array3 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
					}
					OutArrayOfNestedBlittableStructTypeWorks_Injected(out array3, ref value);
					return;
				}
			}
			OutArrayOfNestedBlittableStructTypeWorks_Injected(out array3, ref value);
		}
		finally
		{
			array3.Unmarshal(ref array2);
		}
	}

	public static void OutArrayOfNonBlittableTypeWorks([Out] StructWithStringIntAndFloat[] array, StructWithStringIntAndFloat value)
	{
		OutArrayOfNonBlittableTypeWorks_Injected(array, ref value);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void OutArrayOfPrimitiveTypeWorks_Injected(out BlittableArrayWrapper array, int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void OutArrayOfStringTypeWorks_Injected([Out] string[] array, ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void OutArrayOfBlittableStructTypeWorks_Injected(out BlittableArrayWrapper array, [In] ref StructInt value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void OutArrayOfIntPtrObjectTypeWorks_Injected([Out] MyIntPtrObject[] array, IntPtr value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void OutArrayOfNestedBlittableStructTypeWorks_Injected(out BlittableArrayWrapper array, [In] ref StructNestedBlittable value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void OutArrayOfNonBlittableTypeWorks_Injected([Out] StructWithStringIntAndFloat[] array, [In] ref StructWithStringIntAndFloat value);
}
