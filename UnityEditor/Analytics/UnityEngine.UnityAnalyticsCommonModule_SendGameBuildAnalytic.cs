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
public class SendGameBuildAnalytic : AnalyticsEventBase
{
	private int navmesh_count;

	public SendGameBuildAnalytic()
		: base("navigation_gamebuild_info", 1, SendEventOptions.kAppendBuildGuid)
	{
	}

	[RequiredByNativeCode]
	internal static SendGameBuildAnalytic CreateSendGameBuildAnalytic()
	{
		return new SendGameBuildAnalytic();
	}
}
