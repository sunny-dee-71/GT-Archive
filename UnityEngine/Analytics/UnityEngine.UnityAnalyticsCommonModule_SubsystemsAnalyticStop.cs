using System;
using System.Runtime.InteropServices;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine.Analytics;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[RequiredByNativeCode(GenerateProxy = true)]
[ExcludeFromDocs]
public class SubsystemsAnalyticStop : SubsystemsAnalyticBase
{
	public SubsystemsAnalyticStop()
		: base("SubsystemStop")
	{
	}

	[RequiredByNativeCode]
	internal static SubsystemsAnalyticStop CreateSubsystemsAnalyticStop()
	{
		return new SubsystemsAnalyticStop();
	}
}
