using System;
using System.Runtime.InteropServices;
using UnityEngine.Analytics;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEditor.Analytics;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[RequiredByNativeCode(GenerateProxy = true)]
[ExcludeFromDocs]
internal class AssetImportAnalytic : AnalyticsEventBase
{
	public string package_name;

	public int package_import_choice;

	public AssetImportAnalytic()
		: base("assetImport", 1)
	{
	}

	[RequiredByNativeCode]
	public static AssetImportAnalytic CreateAssetImportAnalytic()
	{
		return new AssetImportAnalytic();
	}
}
