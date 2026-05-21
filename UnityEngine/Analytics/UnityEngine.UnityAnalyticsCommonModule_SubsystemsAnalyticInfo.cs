using System;
using System.Runtime.InteropServices;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine.Analytics;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = true)]
public class SubsystemsAnalyticInfo : SubsystemsAnalyticBase
{
	private string id;

	private string plugin_name;

	private string version;

	private string library_name;

	public SubsystemsAnalyticInfo()
		: base("SubsystemInfo")
	{
	}

	[RequiredByNativeCode]
	internal static SubsystemsAnalyticInfo CreateSubsystemsAnalyticInfo()
	{
		return new SubsystemsAnalyticInfo();
	}
}
