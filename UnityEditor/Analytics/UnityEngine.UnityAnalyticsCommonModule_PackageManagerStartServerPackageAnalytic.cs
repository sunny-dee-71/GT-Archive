using System;
using System.Runtime.InteropServices;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEditor.Analytics;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = true)]
public class PackageManagerStartServerPackageAnalytic : PackageManagerBaseAnalytic
{
	public PackageManagerStartServerPackageAnalytic()
		: base("startPackageManagerServer")
	{
	}

	[RequiredByNativeCode]
	internal static PackageManagerStartServerPackageAnalytic CreatePackageManagerStartServerPackageAnalytic()
	{
		return new PackageManagerStartServerPackageAnalytic();
	}
}
