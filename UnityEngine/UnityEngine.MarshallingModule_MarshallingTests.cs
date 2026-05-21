using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine;

internal static class MarshallingTests
{
	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("MarshallingTest::DisableMarshallingTestsVerification")]
	public static extern void DisableMarshallingTestsVerification();
}
