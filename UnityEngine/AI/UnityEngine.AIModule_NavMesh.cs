using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.AI;

[NativeHeader("Modules/AI/NavMeshManager.h")]
[NativeHeader("Modules/AI/NavMesh/NavMesh.bindings.h")]
[StaticAccessor("NavMeshBindings", StaticAccessorType.DoubleColon)]
[MovedFrom("UnityEngine")]
public static class NavMesh
{
	public delegate void OnNavMeshPreUpdate();

	public const int AllAreas = -1;

	public static OnNavMeshPreUpdate onPreUpdate;

	[StaticAccessor("GetNavMeshManager()")]
	public static extern float avoidancePredictionTime
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetNavMeshManager()")]
	public static extern int pathfindingIterationsPerFrame
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void ClearPreUpdateListeners()
	{
		onPreUpdate = null;
	}

	[RequiredByNativeCode]
	private static void Internal_CallOnNavMeshPreUpdate()
	{
		if (onPreUpdate != null)
		{
			onPreUpdate();
		}
	}

	public static bool Raycast(Vector3 sourcePosition, Vector3 targetPosition, out NavMeshHit hit, int areaMask)
	{
		return Raycast_Injected(ref sourcePosition, ref targetPosition, out hit, areaMask);
	}

	public static bool CalculatePath(Vector3 sourcePosition, Vector3 targetPosition, int areaMask, NavMeshPath path)
	{
		path.ClearCorners();
		return CalculatePathInternal(sourcePosition, targetPosition, areaMask, path);
	}

	private static bool CalculatePathInternal(Vector3 sourcePosition, Vector3 targetPosition, int areaMask, NavMeshPath path)
	{
		return CalculatePathInternal_Injected(ref sourcePosition, ref targetPosition, areaMask, (path == null) ? ((IntPtr)0) : NavMeshPath.BindingsMarshaller.ConvertToNative(path));
	}

	public static bool FindClosestEdge(Vector3 sourcePosition, out NavMeshHit hit, int areaMask)
	{
		return FindClosestEdge_Injected(ref sourcePosition, out hit, areaMask);
	}

	public static bool SamplePosition(Vector3 sourcePosition, out NavMeshHit hit, float maxDistance, int areaMask)
	{
		return SamplePosition_Injected(ref sourcePosition, out hit, maxDistance, areaMask);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[Obsolete("Use SetAreaCost instead.")]
	[NativeName("SetAreaCost")]
	[StaticAccessor("GetNavMeshProjectSettings()")]
	public static extern void SetLayerCost(int layer, float cost);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[Obsolete("Use GetAreaCost instead.")]
	[StaticAccessor("GetNavMeshProjectSettings()")]
	[NativeName("GetAreaCost")]
	public static extern float GetLayerCost(int layer);

	[Obsolete("Use GetAreaFromName instead.")]
	[StaticAccessor("GetNavMeshProjectSettings()")]
	[NativeName("GetAreaFromName")]
	public unsafe static int GetNavMeshLayerFromName(string layerName)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(layerName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(layerName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetNavMeshLayerFromName_Injected(ref managedSpanWrapper);
				}
			}
			return GetNavMeshLayerFromName_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[StaticAccessor("GetNavMeshProjectSettings()")]
	[NativeName("SetAreaCost")]
	public static extern void SetAreaCost(int areaIndex, float cost);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeName("GetAreaCost")]
	[StaticAccessor("GetNavMeshProjectSettings()")]
	public static extern float GetAreaCost(int areaIndex);

	[NativeName("GetAreaFromName")]
	[StaticAccessor("GetNavMeshProjectSettings()")]
	public unsafe static int GetAreaFromName(string areaName)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(areaName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(areaName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetAreaFromName_Injected(ref managedSpanWrapper);
				}
			}
			return GetAreaFromName_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[StaticAccessor("GetNavMeshProjectSettings()")]
	[NativeName("GetAreaNames")]
	public static extern string[] GetAreaNames();

	public static NavMeshTriangulation CalculateTriangulation()
	{
		CalculateTriangulation_Injected(out var ret);
		return ret;
	}

	[Obsolete("use NavMesh.CalculateTriangulation() instead.")]
	public static void Triangulate(out Vector3[] vertices, out int[] indices)
	{
		NavMeshTriangulation navMeshTriangulation = CalculateTriangulation();
		vertices = navMeshTriangulation.vertices;
		indices = navMeshTriangulation.indices;
	}

	[Obsolete("AddOffMeshLinks has no effect and is deprecated.")]
	public static void AddOffMeshLinks()
	{
	}

	[Obsolete("RestoreNavMesh has no effect and is deprecated.")]
	public static void RestoreNavMesh()
	{
	}

	public static NavMeshDataInstance AddNavMeshData(NavMeshData navMeshData)
	{
		if (navMeshData == null)
		{
			throw new ArgumentNullException("navMeshData");
		}
		return new NavMeshDataInstance
		{
			id = AddNavMeshDataInternal(navMeshData)
		};
	}

	public static NavMeshDataInstance AddNavMeshData(NavMeshData navMeshData, Vector3 position, Quaternion rotation)
	{
		if (navMeshData == null)
		{
			throw new ArgumentNullException("navMeshData");
		}
		return new NavMeshDataInstance
		{
			id = AddNavMeshDataTransformedInternal(navMeshData, position, rotation)
		};
	}

	public static void RemoveNavMeshData(NavMeshDataInstance handle)
	{
		RemoveNavMeshDataInternal(handle.id);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeName("IsValidSurfaceID")]
	[StaticAccessor("GetNavMeshManager()")]
	internal static extern bool IsValidNavMeshDataHandle(int handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[StaticAccessor("GetNavMeshManager()")]
	internal static extern bool IsValidLinkHandle(int handle);

	internal static Object InternalGetOwner(int dataID)
	{
		return Unmarshal.UnmarshalUnityObject<Object>(InternalGetOwner_Injected(dataID));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[StaticAccessor("GetNavMeshManager()")]
	[NativeName("SetSurfaceUserID")]
	internal static extern bool InternalSetOwner(int dataID, int ownerID);

	internal static Object InternalGetLinkOwner(int linkID)
	{
		return Unmarshal.UnmarshalUnityObject<Object>(InternalGetLinkOwner_Injected(linkID));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeName("SetLinkUserID")]
	[StaticAccessor("GetNavMeshManager()")]
	internal static extern bool InternalSetLinkOwner(int linkID, int ownerID);

	[StaticAccessor("GetNavMeshManager()")]
	[NativeName("LoadData")]
	internal static int AddNavMeshDataInternal(NavMeshData navMeshData)
	{
		return AddNavMeshDataInternal_Injected(Object.MarshalledUnityObject.Marshal(navMeshData));
	}

	[StaticAccessor("GetNavMeshManager()")]
	[NativeName("LoadData")]
	internal static int AddNavMeshDataTransformedInternal(NavMeshData navMeshData, Vector3 position, Quaternion rotation)
	{
		return AddNavMeshDataTransformedInternal_Injected(Object.MarshalledUnityObject.Marshal(navMeshData), ref position, ref rotation);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[StaticAccessor("GetNavMeshManager()")]
	[NativeName("UnloadData")]
	internal static extern void RemoveNavMeshDataInternal(int handle);

	public static NavMeshLinkInstance AddLink(NavMeshLinkData link)
	{
		return new NavMeshLinkInstance
		{
			id = AddLinkInternal(link, Vector3.zero, Quaternion.identity)
		};
	}

	public static NavMeshLinkInstance AddLink(NavMeshLinkData link, Vector3 position, Quaternion rotation)
	{
		return new NavMeshLinkInstance
		{
			id = AddLinkInternal(link, position, rotation)
		};
	}

	public static void RemoveLink(NavMeshLinkInstance handle)
	{
		RemoveLinkInternal(handle.id);
	}

	public static bool IsLinkActive(NavMeshLinkInstance handle)
	{
		return IsOffMeshConnectionActive(handle.id);
	}

	public static void SetLinkActive(NavMeshLinkInstance handle, bool value)
	{
		SetOffMeshConnectionActive(handle.id, value);
	}

	public static bool IsLinkOccupied(NavMeshLinkInstance handle)
	{
		return IsOffMeshConnectionOccupied(handle.id);
	}

	public static bool IsLinkValid(NavMeshLinkInstance handle)
	{
		return IsValidLinkHandle(handle.id);
	}

	public static Object GetLinkOwner(NavMeshLinkInstance handle)
	{
		return InternalGetLinkOwner(handle.id);
	}

	public static void SetLinkOwner(NavMeshLinkInstance handle, Object owner)
	{
		int ownerID = ((owner != null) ? owner.GetInstanceID() : 0);
		if (!InternalSetLinkOwner(handle.id, ownerID))
		{
			Debug.LogError("Cannot set 'owner' on an invalid NavMeshLinkInstance");
		}
	}

	[StaticAccessor("GetNavMeshManager()")]
	[NativeName("AddLink")]
	internal static int AddLinkInternal(NavMeshLinkData link, Vector3 position, Quaternion rotation)
	{
		return AddLinkInternal_Injected(ref link, ref position, ref rotation);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[StaticAccessor("GetNavMeshManager()")]
	[NativeName("RemoveLink")]
	internal static extern void RemoveLinkInternal(int handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[StaticAccessor("GetNavMeshManager()")]
	internal static extern bool IsOffMeshConnectionOccupied(int handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[StaticAccessor("GetNavMeshManager()")]
	internal static extern bool IsOffMeshConnectionActive(int linkHandle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[StaticAccessor("GetNavMeshManager()")]
	internal static extern void SetOffMeshConnectionActive(int linkHandle, bool activated);

	public static bool SamplePosition(Vector3 sourcePosition, out NavMeshHit hit, float maxDistance, NavMeshQueryFilter filter)
	{
		return SamplePositionFilter(sourcePosition, out hit, maxDistance, filter.agentTypeID, filter.areaMask);
	}

	private static bool SamplePositionFilter(Vector3 sourcePosition, out NavMeshHit hit, float maxDistance, int type, int mask)
	{
		return SamplePositionFilter_Injected(ref sourcePosition, out hit, maxDistance, type, mask);
	}

	public static bool FindClosestEdge(Vector3 sourcePosition, out NavMeshHit hit, NavMeshQueryFilter filter)
	{
		return FindClosestEdgeFilter(sourcePosition, out hit, filter.agentTypeID, filter.areaMask);
	}

	private static bool FindClosestEdgeFilter(Vector3 sourcePosition, out NavMeshHit hit, int type, int mask)
	{
		return FindClosestEdgeFilter_Injected(ref sourcePosition, out hit, type, mask);
	}

	public static bool Raycast(Vector3 sourcePosition, Vector3 targetPosition, out NavMeshHit hit, NavMeshQueryFilter filter)
	{
		return RaycastFilter(sourcePosition, targetPosition, out hit, filter.agentTypeID, filter.areaMask);
	}

	private static bool RaycastFilter(Vector3 sourcePosition, Vector3 targetPosition, out NavMeshHit hit, int type, int mask)
	{
		return RaycastFilter_Injected(ref sourcePosition, ref targetPosition, out hit, type, mask);
	}

	public static bool CalculatePath(Vector3 sourcePosition, Vector3 targetPosition, NavMeshQueryFilter filter, NavMeshPath path)
	{
		path.ClearCorners();
		return CalculatePathFilterInternal(sourcePosition, targetPosition, path, filter.agentTypeID, filter.areaMask, filter.costs);
	}

	private unsafe static bool CalculatePathFilterInternal(Vector3 sourcePosition, Vector3 targetPosition, NavMeshPath path, int type, int mask, float[] costs)
	{
		IntPtr path2 = ((path == null) ? ((IntPtr)0) : NavMeshPath.BindingsMarshaller.ConvertToNative(path));
		Span<float> span = new Span<float>(costs);
		bool result;
		fixed (float* begin = span)
		{
			ManagedSpanWrapper costs2 = new ManagedSpanWrapper(begin, span.Length);
			result = CalculatePathFilterInternal_Injected(ref sourcePosition, ref targetPosition, path2, type, mask, ref costs2);
		}
		return result;
	}

	[StaticAccessor("GetNavMeshProjectSettings()")]
	public static NavMeshBuildSettings CreateSettings()
	{
		CreateSettings_Injected(out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[StaticAccessor("GetNavMeshProjectSettings()")]
	public static extern void RemoveSettings(int agentTypeID);

	public static NavMeshBuildSettings GetSettingsByID(int agentTypeID)
	{
		GetSettingsByID_Injected(agentTypeID, out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[StaticAccessor("GetNavMeshProjectSettings()")]
	public static extern int GetSettingsCount();

	public static NavMeshBuildSettings GetSettingsByIndex(int index)
	{
		GetSettingsByIndex_Injected(index, out var ret);
		return ret;
	}

	public static string GetSettingsNameFromID(int agentTypeID)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			GetSettingsNameFromID_Injected(agentTypeID, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[StaticAccessor("GetNavMeshManager()")]
	[NativeName("CleanupAfterCarving")]
	public static extern void RemoveAllNavMeshData();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool Raycast_Injected([In] ref Vector3 sourcePosition, [In] ref Vector3 targetPosition, out NavMeshHit hit, int areaMask);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool CalculatePathInternal_Injected([In] ref Vector3 sourcePosition, [In] ref Vector3 targetPosition, int areaMask, IntPtr path);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool FindClosestEdge_Injected([In] ref Vector3 sourcePosition, out NavMeshHit hit, int areaMask);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool SamplePosition_Injected([In] ref Vector3 sourcePosition, out NavMeshHit hit, float maxDistance, int areaMask);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetNavMeshLayerFromName_Injected(ref ManagedSpanWrapper layerName);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetAreaFromName_Injected(ref ManagedSpanWrapper areaName);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CalculateTriangulation_Injected(out NavMeshTriangulation ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr InternalGetOwner_Injected(int dataID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr InternalGetLinkOwner_Injected(int linkID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int AddNavMeshDataInternal_Injected(IntPtr navMeshData);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int AddNavMeshDataTransformedInternal_Injected(IntPtr navMeshData, [In] ref Vector3 position, [In] ref Quaternion rotation);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int AddLinkInternal_Injected([In] ref NavMeshLinkData link, [In] ref Vector3 position, [In] ref Quaternion rotation);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool SamplePositionFilter_Injected([In] ref Vector3 sourcePosition, out NavMeshHit hit, float maxDistance, int type, int mask);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool FindClosestEdgeFilter_Injected([In] ref Vector3 sourcePosition, out NavMeshHit hit, int type, int mask);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool RaycastFilter_Injected([In] ref Vector3 sourcePosition, [In] ref Vector3 targetPosition, out NavMeshHit hit, int type, int mask);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool CalculatePathFilterInternal_Injected([In] ref Vector3 sourcePosition, [In] ref Vector3 targetPosition, IntPtr path, int type, int mask, ref ManagedSpanWrapper costs);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CreateSettings_Injected(out NavMeshBuildSettings ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetSettingsByID_Injected(int agentTypeID, out NavMeshBuildSettings ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetSettingsByIndex_Injected(int index, out NavMeshBuildSettings ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetSettingsNameFromID_Injected(int agentTypeID, out ManagedSpanWrapper ret);
}
