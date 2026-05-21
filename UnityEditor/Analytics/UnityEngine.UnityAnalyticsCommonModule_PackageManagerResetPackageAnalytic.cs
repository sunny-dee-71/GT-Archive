using System;
using System.Runtime.InteropServices;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEditor.Analytics;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = true)]
public class PackageManagerResetPackageAnalytic : PackageManagerBaseAnalytic
{
	public PackageManagerResetPackageAnalytic()
		: base("resetToDefaultDependencies")
	{
	}

	[RequiredByNativeCode]
	internal static PackageManagerResetPackageAnalytic CreatePackageManagerResetPackageAnalytic()
	{
		return new PackageManagerResetPackageAnalytic();
	}
}
