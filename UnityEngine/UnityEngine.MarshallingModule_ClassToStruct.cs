using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[StructLayout(LayoutKind.Sequential)]
[NativeAsStruct]
[ExcludeFromDocs]
internal class ClassToStruct
{
	public int intField;

	public string stringField;
}
