using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine.AI;

[NativeHeader("Modules/AI/NavMesh/NavMesh.bindings.h")]
public sealed class NavMeshData : Object
{
	public Bounds sourceBounds
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_sourceBounds_Injected(intPtr, out var ret);
			return ret;
		}
	}

	public Vector3 position
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_position_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_position_Injected(intPtr, ref value);
		}
	}

	public Quaternion rotation
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_rotation_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_rotation_Injected(intPtr, ref value);
		}
	}

	internal bool hasHeightMeshData
	{
		[NativeMethod("HasHeightMeshData")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_hasHeightMeshData_Injected(intPtr);
		}
	}

	internal NavMeshBuildSettings buildSettings
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_buildSettings_Injected(intPtr, out var ret);
			return ret;
		}
	}

	public NavMeshData()
	{
		Internal_Create(this, 0);
	}

	public NavMeshData(int agentTypeID)
	{
		Internal_Create(this, agentTypeID);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[StaticAccessor("NavMeshDataBindings", StaticAccessorType.DoubleColon)]
	private static extern void Internal_Create([Writable] NavMeshData mono, int agentTypeID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_sourceBounds_Injected(IntPtr _unity_self, out Bounds ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_position_Injected(IntPtr _unity_self, out Vector3 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_position_Injected(IntPtr _unity_self, [In] ref Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_rotation_Injected(IntPtr _unity_self, out Quaternion ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_rotation_Injected(IntPtr _unity_self, [In] ref Quaternion value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_hasHeightMeshData_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_buildSettings_Injected(IntPtr _unity_self, out NavMeshBuildSettings ret);
}
