using System.Runtime.InteropServices;
using UnityEngine.Internal;

namespace UnityEngine;

[StructLayout(LayoutKind.Sequential)]
[ExcludeFromDocs]
internal class MyManagedObject
{
	public int value = 42;
}
