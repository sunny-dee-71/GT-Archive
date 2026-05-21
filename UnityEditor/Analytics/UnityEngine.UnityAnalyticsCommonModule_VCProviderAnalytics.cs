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
public class VCProviderAnalytics : AnalyticsEventBase
{
	public string Mode;

	public VCProviderAnalytics()
		: base("versioncontrol_ProviderSettings_OnUpdate", 1)
	{
	}

	[RequiredByNativeCode]
	internal static VCProviderAnalytics CreateVCProviderAnalytics()
	{
		return new VCProviderAnalytics();
	}
}
