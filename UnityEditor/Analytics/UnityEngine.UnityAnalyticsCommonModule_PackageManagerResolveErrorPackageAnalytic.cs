using System;
using System.Runtime.InteropServices;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEditor.Analytics;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = true)]
public class PackageManagerResolveErrorPackageAnalytic : PackageManagerBaseAnalytic
{
	public string reason;

	public string action;

	public PackageManagerResolveErrorPackageAnalytic()
		: base("resolveErrorUserAction")
	{
	}

	[RequiredByNativeCode]
	internal static PackageManagerResolveErrorPackageAnalytic CreatePackageManagerResolveErrorPackageAnalytic()
	{
		return new PackageManagerResolveErrorPackageAnalytic();
	}
}
