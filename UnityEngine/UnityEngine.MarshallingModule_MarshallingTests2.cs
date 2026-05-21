using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal class MarshallingTests2
{
	public static void ParameterNonBlittableStructReuse(StructCoreString param)
	{
		ParameterNonBlittableStructReuse_Injected(ref param);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterNonBlittableStructReuse_Injected([In] ref StructCoreString param);
}
