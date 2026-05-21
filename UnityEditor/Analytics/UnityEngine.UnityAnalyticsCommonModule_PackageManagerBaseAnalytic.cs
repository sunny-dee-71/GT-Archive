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
public class PackageManagerBaseAnalytic : AnalyticsEventBase
{
	public long start_ts;

	public long duration;

	public bool blocking;

	public string package_id;

	public int status_code;

	public string error_message;

	public PackageManagerBaseAnalytic(string eventName)
		: base(eventName, 1, SendEventOptions.kAppendNone, "packageManager")
	{
	}
}
