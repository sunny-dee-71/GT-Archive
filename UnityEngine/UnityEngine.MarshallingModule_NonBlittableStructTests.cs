using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal class NonBlittableStructTests
{
	[NativeThrows]
	public static void ParameterStructWithStringIntAndFloat(StructWithStringIntAndFloat param)
	{
		ParameterStructWithStringIntAndFloat_Injected(ref param);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void RefParameterStructWithStringIntAndFloat(ref StructWithStringIntAndFloat param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void OutParameterStructWithStringIntAndFloat(out StructWithStringIntAndFloat param);

	public static void ParameterStructWithStringIntAndFloat2(StructWithStringIntAndFloat2 param)
	{
		ParameterStructWithStringIntAndFloat2_Injected(ref param);
	}

	[NativeThrows]
	public static void ParameterStructWithStringIgnoredIntAndFloat(StructWithStringIgnoredIntAndFloat param)
	{
		ParameterStructWithStringIgnoredIntAndFloat_Injected(ref param);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void ParameterStructWithStringIntAndFloatArray(StructWithStringIntAndFloat[] param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern StructWithStringIntAndFloat[] ReturnStructWithStringIntAndFloatArray();

	[NativeThrows]
	public static void ParameterStructWithNonBlittableArrayField(StructWithNonBlittableArrayField param)
	{
		ParameterStructWithNonBlittableArrayField_Injected(ref param);
	}

	public static StructWithNonBlittableArrayField ReturnStructWithNonBlittableArrayField()
	{
		ReturnStructWithNonBlittableArrayField_Injected(out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void CanMarshalManagedObjectToStruct(ClassToStruct param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void CanMarshalOutManagedObjectToStruct([Out] ClassToStruct param);

	[NativeThrows]
	public static void CanMarshalStructWithNativeAsStructField(StructWithClassToStruct param)
	{
		CanMarshalStructWithNativeAsStructField_Injected(ref param);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void CanMarshalNativeAsStructArray(ClassToStruct[] param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern ClassToStruct CanUnmarshalManagedObjectFromStruct();

	public static StructWithClassToStruct CanUnmarshalStructWithNativeAsStructField()
	{
		CanUnmarshalStructWithNativeAsStructField_Injected(out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern ClassToStruct[] CanUnmarshalNativeAsStructArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructWithStringIntAndFloat_Injected([In] ref StructWithStringIntAndFloat param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructWithStringIntAndFloat2_Injected([In] ref StructWithStringIntAndFloat2 param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructWithStringIgnoredIntAndFloat_Injected([In] ref StructWithStringIgnoredIntAndFloat param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructWithNonBlittableArrayField_Injected([In] ref StructWithNonBlittableArrayField param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnStructWithNonBlittableArrayField_Injected(out StructWithNonBlittableArrayField ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanMarshalStructWithNativeAsStructField_Injected([In] ref StructWithClassToStruct param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanUnmarshalStructWithNativeAsStructField_Injected(out StructWithClassToStruct ret);
}
