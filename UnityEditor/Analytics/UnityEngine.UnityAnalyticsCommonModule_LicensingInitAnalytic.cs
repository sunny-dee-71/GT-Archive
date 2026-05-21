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
public class LicensingInitAnalytic : AnalyticsEventBase
{
	public string licensingProtocolVersion;

	public string licensingClientVersion;

	public string channelType;

	public double initTime;

	public bool isLegacy;

	public string sessionId;

	public string correlationId;

	public LicensingInitAnalytic()
		: base("license_init", 1)
	{
	}

	[RequiredByNativeCode]
	internal static LicensingInitAnalytic CreateLicensingInitAnalytic()
	{
		return new LicensingInitAnalytic();
	}
}
