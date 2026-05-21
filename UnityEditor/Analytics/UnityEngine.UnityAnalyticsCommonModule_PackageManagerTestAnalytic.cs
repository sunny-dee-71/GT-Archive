using System;
using System.Runtime.InteropServices;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEditor.Analytics;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[RequiredByNativeCode(GenerateProxy = true)]
[ExcludeFromDocs]
public class PackageManagerTestAnalytic : PackageManagerBaseAnalytic
{
	public PackageManagerTestAnalytic()
		: base("PackageManager")
	{
	}

	[RequiredByNativeCode]
	internal static PackageManagerTestAnalytic CreatePackageManagerTestAnalytic()
	{
		return new PackageManagerTestAnalytic();
	}
}
