using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine;

[NativeHeader("Modules/Terrain/Public/TerrainData.h")]
[NativeHeader("Modules/TerrainPhysics/TerrainCollider.h")]
public class TerrainCollider : Collider
{
	public TerrainData terrainData
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<TerrainData>(get_terrainData_Injected(intPtr));
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_terrainData_Injected(intPtr, MarshalledUnityObject.Marshal(value));
		}
	}

	private RaycastHit Raycast(Ray ray, float maxDistance, bool hitHoles, ref bool hasHit)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Raycast_Injected(intPtr, ref ray, maxDistance, hitHoles, ref hasHit, out var ret);
		return ret;
	}

	internal bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance, bool hitHoles)
	{
		bool hasHit = false;
		hitInfo = Raycast(ray, maxDistance, hitHoles, ref hasHit);
		return hasHit;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_terrainData_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_terrainData_Injected(IntPtr _unity_self, IntPtr value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Raycast_Injected(IntPtr _unity_self, [In] ref Ray ray, float maxDistance, bool hitHoles, ref bool hasHit, out RaycastHit ret);
}
