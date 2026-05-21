using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal class ManagedObjectTests
{
	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern MyManagedObject ParameterManagedObject(MyManagedObject param);

	[NativeThrows]
	public static StructManagedObject ParameterStructManagedObject(StructManagedObject param)
	{
		ParameterStructManagedObject_Injected(ref param, out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern MyManagedObject[] ReturnNullManagedObjectArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern MyManagedObject[] ParameterManagedObjectVector(MyManagedObject[] param);

	[NativeThrows]
	public static StructManagedObjectVector ParameterStructManagedObjectVector(StructManagedObjectVector param)
	{
		ParameterStructManagedObjectVector_Injected(ref param, out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructManagedObject_Injected([In] ref StructManagedObject param, out StructManagedObject ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructManagedObjectVector_Injected([In] ref StructManagedObjectVector param, out StructManagedObjectVector ret);
}
