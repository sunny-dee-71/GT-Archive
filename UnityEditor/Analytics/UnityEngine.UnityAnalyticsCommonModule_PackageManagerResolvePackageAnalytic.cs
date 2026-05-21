using System;
using System.Runtime.InteropServices;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEditor.Analytics;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[RequiredByNativeCode(GenerateProxy = true)]
[ExcludeFromDocs]
public class PackageManagerResolvePackageAnalytic : PackageManagerBaseAnalytic
{
	public string[] packages;

	public string[] package_registries;

	public string[] package_signatures;

	public string[] package_sources;

	public string[] package_types;

	public string[] package_compliance_statuses;

	public PackageManagerResolvePackageAnalytic()
		: base("resolvePackages")
	{
	}

	[RequiredByNativeCode]
	internal static PackageManagerResolvePackageAnalytic CreatePackageManagerResolvePackageAnalytic()
	{
		return new PackageManagerResolvePackageAnalytic();
	}
}
