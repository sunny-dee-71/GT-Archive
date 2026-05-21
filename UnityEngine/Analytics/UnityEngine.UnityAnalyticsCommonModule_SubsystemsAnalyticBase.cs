using System;
using System.Runtime.InteropServices;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine.Analytics;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = true)]
public class SubsystemsAnalyticBase : AnalyticsEventBase
{
	public string subsystem;

	public SubsystemsAnalyticBase(string eventName)
		: base(eventName, 1)
	{
	}
}
