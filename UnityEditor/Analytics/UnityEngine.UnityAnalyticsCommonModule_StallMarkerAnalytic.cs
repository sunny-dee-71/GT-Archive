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
internal class StallMarkerAnalytic : AnalyticsEventBase
{
	public string Name;

	public bool HasProgressMarkup;

	public double Duration;

	public StallMarkerAnalytic()
		: base("editorStallMarker", 1)
	{
	}

	[RequiredByNativeCode]
	internal static StallMarkerAnalytic CreateStallMarkerAnalytic()
	{
		return new StallMarkerAnalytic();
	}
}
