using System;
using System.Runtime.InteropServices;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine.Analytics;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[RequiredByNativeCode(GenerateProxy = true)]
[ExcludeFromDocs]
public class VRDeviceAnalyticBase : AnalyticsEventBase
{
	public VRDeviceAnalyticBase()
		: base("deviceStatus", 1)
	{
	}
}
