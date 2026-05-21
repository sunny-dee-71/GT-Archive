using System;
using System.Runtime.InteropServices;
using UnityEngine.Analytics;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEditor.Analytics;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = true)]
internal class AssetExportAnalytic : AnalyticsEventBase
{
	public string package_name;

	public string error_message;

	public int items_count;

	public string[] asset_extensions;

	public bool include_upm_dependencies;

	public AssetExportAnalytic()
		: base("assetExport", 1)
	{
	}

	[RequiredByNativeCode]
	public static AssetExportAnalytic CreateAssetExportAnalytic()
	{
		return new AssetExportAnalytic();
	}
}
