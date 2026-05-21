using System;
using System.Runtime.InteropServices;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEditor.Analytics;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = true)]
public class PackageManagerAddPackageAnalytic : PackageManagerBaseAnalytic
{
	public PackageManagerAddPackageAnalytic()
		: base("addPackage")
	{
	}

	[RequiredByNativeCode]
	internal static PackageManagerAddPackageAnalytic CreatePackageManagerAddPackageAnalytic()
	{
		return new PackageManagerAddPackageAnalytic();
	}
}
