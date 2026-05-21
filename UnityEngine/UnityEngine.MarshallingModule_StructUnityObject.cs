using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal struct StructUnityObject
{
	public MarshallingTestObject field;

	public int InstanceMethod([NotNull] object o)
	{
		if (o == null)
		{
			ThrowHelper.ThrowArgumentNullException(o, "o");
		}
		return InstanceMethod_Injected(ref this, o);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int InstanceMethod_Injected(ref StructUnityObject _unity_self, object o);
}
