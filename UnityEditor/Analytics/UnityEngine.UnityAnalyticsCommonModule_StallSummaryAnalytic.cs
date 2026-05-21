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
public class StallSummaryAnalytic : AnalyticsEventBase
{
	public double Duration;

	public StallSummaryAnalytic()
		: base("editorStallSummary", 1)
	{
	}

	[RequiredByNativeCode]
	internal static StallSummaryAnalytic CreateStallSummaryAnalytic()
	{
		return new StallSummaryAnalytic();
	}
}
