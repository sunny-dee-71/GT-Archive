using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal struct StructWithExternTests
{
	public int a;

	[MethodImpl(MethodImplOptions.InternalCall)]
	public extern int GetTimesTwo();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public extern void SetTimesThree();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public extern int ParameterWritable([Writable] Object unityObject);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void ParameterInt(int param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern int ReturnInt();
}
