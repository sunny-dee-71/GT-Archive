using System;
using System.Runtime.InteropServices;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEditor.Analytics;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = true)]
public class PackageManagerEmbedPackageAnalytic : PackageManagerBaseAnalytic
{
	public PackageManagerEmbedPackageAnalytic()
		: base("embedPackage")
	{
	}

	[RequiredByNativeCode]
	internal static PackageManagerEmbedPackageAnalytic CreatePackageManagerEmbedPackageAnalytic()
	{
		return new PackageManagerEmbedPackageAnalytic();
	}
}
