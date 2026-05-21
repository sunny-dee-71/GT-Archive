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
public class ProjectSettingsInformationAnalytic : AnalyticsEventBase
{
	private int agent_types_count;

	private int areas_count;

	public ProjectSettingsInformationAnalytic()
		: base("navigation_project_settings_info", 1)
	{
	}

	[RequiredByNativeCode]
	internal static ProjectSettingsInformationAnalytic CreateProjectSettingsInformationAnalytic()
	{
		return new ProjectSettingsInformationAnalytic();
	}
}
