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
public class CollabOperationAnalytic : AnalyticsEventBase
{
	public string category;

	public string operation;

	public string result;

	public long start_ts;

	public long duration;

	public CollabOperationAnalytic()
		: base("collabOperation", 1)
	{
	}

	[RequiredByNativeCode]
	internal static CollabOperationAnalytic CreateCollabOperationAnalytic()
	{
		return new CollabOperationAnalytic();
	}
}
