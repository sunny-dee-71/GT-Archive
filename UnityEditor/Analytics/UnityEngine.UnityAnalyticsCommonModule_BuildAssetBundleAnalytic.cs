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
public class BuildAssetBundleAnalytic : AnalyticsEventBase
{
	public bool success;

	public string error;

	public BuildAssetBundleAnalytic()
		: base("unity5BuildAssetBundles", 1)
	{
	}

	[RequiredByNativeCode]
	internal static BuildAssetBundleAnalytic CreateBuildAssetBundleAnalytic()
	{
		return new BuildAssetBundleAnalytic();
	}
}
