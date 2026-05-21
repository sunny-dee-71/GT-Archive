using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine.AI;

[StaticAccessor("NavMeshBuilderBindings", StaticAccessorType.DoubleColon)]
[NativeHeader("Modules/AI/Builder/NavMeshBuilder.bindings.h")]
public static class NavMeshBuilder
{
	public static void CollectSources(Bounds includedWorldBounds, int includedLayerMask, NavMeshCollectGeometry geometry, int defaultArea, bool generateLinksByDefault, List<NavMeshBuildMarkup> markups, bool includeOnlyMarkedObjects, List<NavMeshBuildSource> results)
	{
		if (markups == null)
		{
			throw new ArgumentNullException("markups");
		}
		if (results == null)
		{
			throw new ArgumentNullException("results");
		}
		includedWorldBounds.extents = Vector3.Max(includedWorldBounds.extents, 0.001f * Vector3.one);
		NavMeshBuildSource[] collection = CollectSourcesInternal(includedLayerMask, includedWorldBounds, null, useBounds: true, geometry, defaultArea, generateLinksByDefault, markups.ToArray(), includeOnlyMarkedObjects);
		results.Clear();
		results.AddRange(collection);
	}

	public static void CollectSources(Bounds includedWorldBounds, int includedLayerMask, NavMeshCollectGeometry geometry, int defaultArea, List<NavMeshBuildMarkup> markups, List<NavMeshBuildSource> results)
	{
		CollectSources(includedWorldBounds, includedLayerMask, geometry, defaultArea, generateLinksByDefault: false, markups, includeOnlyMarkedObjects: false, results);
	}

	public static void CollectSources(Transform root, int includedLayerMask, NavMeshCollectGeometry geometry, int defaultArea, bool generateLinksByDefault, List<NavMeshBuildMarkup> markups, bool includeOnlyMarkedObjects, List<NavMeshBuildSource> results)
	{
		if (markups == null)
		{
			throw new ArgumentNullException("markups");
		}
		if (results == null)
		{
			throw new ArgumentNullException("results");
		}
		NavMeshBuildSource[] collection = CollectSourcesInternal(includedLayerMask, default(Bounds), root, useBounds: false, geometry, defaultArea, generateLinksByDefault, markups.ToArray(), includeOnlyMarkedObjects);
		results.Clear();
		results.AddRange(collection);
	}

	public static void CollectSources(Transform root, int includedLayerMask, NavMeshCollectGeometry geometry, int defaultArea, List<NavMeshBuildMarkup> markups, List<NavMeshBuildSource> results)
	{
		CollectSources(root, includedLayerMask, geometry, defaultArea, generateLinksByDefault: false, markups, includeOnlyMarkedObjects: false, results);
	}

	private unsafe static NavMeshBuildSource[] CollectSourcesInternal(int includedLayerMask, Bounds includedWorldBounds, Transform root, bool useBounds, NavMeshCollectGeometry geometry, int defaultArea, bool generateLinksByDefault, NavMeshBuildMarkup[] markups, bool includeOnlyMarkedObjects)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		NavMeshBuildSource[] result;
		try
		{
			IntPtr root2 = Object.MarshalledUnityObject.Marshal(root);
			Span<NavMeshBuildMarkup> span = new Span<NavMeshBuildMarkup>(markups);
			fixed (NavMeshBuildMarkup* begin = span)
			{
				ManagedSpanWrapper markups2 = new ManagedSpanWrapper(begin, span.Length);
				CollectSourcesInternal_Injected(includedLayerMask, ref includedWorldBounds, root2, useBounds, geometry, defaultArea, generateLinksByDefault, ref markups2, includeOnlyMarkedObjects, out ret);
			}
		}
		finally
		{
			NavMeshBuildSource[] array = default(NavMeshBuildSource[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static NavMeshData BuildNavMeshData(NavMeshBuildSettings buildSettings, List<NavMeshBuildSource> sources, Bounds localBounds, Vector3 position, Quaternion rotation)
	{
		if (sources == null)
		{
			throw new ArgumentNullException("sources");
		}
		NavMeshData navMeshData = new NavMeshData(buildSettings.agentTypeID)
		{
			position = position,
			rotation = rotation
		};
		UpdateNavMeshDataListInternal(navMeshData, buildSettings, sources, localBounds);
		return navMeshData;
	}

	public static bool UpdateNavMeshData(NavMeshData data, NavMeshBuildSettings buildSettings, List<NavMeshBuildSource> sources, Bounds localBounds)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		if (sources == null)
		{
			throw new ArgumentNullException("sources");
		}
		return UpdateNavMeshDataListInternal(data, buildSettings, sources, localBounds);
	}

	private static bool UpdateNavMeshDataListInternal(NavMeshData data, NavMeshBuildSettings buildSettings, object sources, Bounds localBounds)
	{
		return UpdateNavMeshDataListInternal_Injected(Object.MarshalledUnityObject.Marshal(data), ref buildSettings, sources, ref localBounds);
	}

	public static AsyncOperation UpdateNavMeshDataAsync(NavMeshData data, NavMeshBuildSettings buildSettings, List<NavMeshBuildSource> sources, Bounds localBounds)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		if (sources == null)
		{
			throw new ArgumentNullException("sources");
		}
		return UpdateNavMeshDataAsyncListInternal(data, buildSettings, sources, localBounds);
	}

	[NativeHeader("Modules/AI/NavMeshManager.h")]
	[StaticAccessor("GetNavMeshManager().GetNavMeshBuildManager()", StaticAccessorType.Arrow)]
	[NativeMethod("Purge")]
	public static void Cancel(NavMeshData data)
	{
		Cancel_Injected(Object.MarshalledUnityObject.Marshal(data));
	}

	private static AsyncOperation UpdateNavMeshDataAsyncListInternal(NavMeshData data, NavMeshBuildSettings buildSettings, object sources, Bounds localBounds)
	{
		IntPtr intPtr = UpdateNavMeshDataAsyncListInternal_Injected(Object.MarshalledUnityObject.Marshal(data), ref buildSettings, sources, ref localBounds);
		return (intPtr == (IntPtr)0) ? null : AsyncOperation.BindingsMarshaller.ConvertToManaged(intPtr);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CollectSourcesInternal_Injected(int includedLayerMask, [In] ref Bounds includedWorldBounds, IntPtr root, bool useBounds, NavMeshCollectGeometry geometry, int defaultArea, bool generateLinksByDefault, ref ManagedSpanWrapper markups, bool includeOnlyMarkedObjects, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool UpdateNavMeshDataListInternal_Injected(IntPtr data, [In] ref NavMeshBuildSettings buildSettings, object sources, [In] ref Bounds localBounds);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Cancel_Injected(IntPtr data);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr UpdateNavMeshDataAsyncListInternal_Injected(IntPtr data, [In] ref NavMeshBuildSettings buildSettings, object sources, [In] ref Bounds localBounds);
}
