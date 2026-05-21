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
public class NavmeshBakingAnalytic : AnalyticsEventBase
{
	private bool new_nav_api;

	private bool bake_at_runtime;

	private int height_meshes_count;

	private int offmesh_links_count;

	public NavmeshBakingAnalytic()
		: base("navigation_navmesh_baking", 1)
	{
	}

	[RequiredByNativeCode]
	internal static NavmeshBakingAnalytic CreateNavmeshBakingAnalytic()
	{
		return new NavmeshBakingAnalytic();
	}
}
