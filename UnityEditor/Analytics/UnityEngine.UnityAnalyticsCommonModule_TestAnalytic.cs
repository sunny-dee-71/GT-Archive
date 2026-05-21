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
internal class TestAnalytic : AnalyticsEventBase
{
	public int param;

	public TestAnalytic()
		: base("TestAnalytic", 1)
	{
	}

	[RequiredByNativeCode]
	public static TestAnalytic CreateTestAnalytic()
	{
		return new TestAnalytic();
	}
}
