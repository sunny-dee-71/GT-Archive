using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal struct StructFixedBuffer
{
	public unsafe fixed int SomeInts[4];
}
