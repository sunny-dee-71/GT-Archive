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
public class LicensingErrorAnalytic : AnalyticsEventBase
{
	public string licensingErrorType;

	public string additionalData;

	public string errorMessage;

	public string correlationId;

	public string sessionId;

	public LicensingErrorAnalytic()
		: base("license_error", 1)
	{
	}

	[RequiredByNativeCode]
	internal static LicensingErrorAnalytic CreateLicensingErrorAnalytic()
	{
		return new LicensingErrorAnalytic();
	}
}
