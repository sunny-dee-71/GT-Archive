using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.AI;

[UsedByNativeCode]
[NativeHeader("Modules/AI/Public/NavMeshBindingTypes.h")]
public struct NavMeshBuildSource
{
	private Matrix4x4 m_Transform;

	private Vector3 m_Size;

	private NavMeshBuildSourceShape m_Shape;

	private int m_Area;

	private int m_InstanceID;

	private int m_ComponentID;

	private int m_GenerateLinks;

	public Matrix4x4 transform
	{
		get
		{
			return m_Transform;
		}
		set
		{
			m_Transform = value;
		}
	}

	public Vector3 size
	{
		get
		{
			return m_Size;
		}
		set
		{
			m_Size = value;
		}
	}

	public NavMeshBuildSourceShape shape
	{
		get
		{
			return m_Shape;
		}
		set
		{
			m_Shape = value;
		}
	}

	public int area
	{
		get
		{
			return m_Area;
		}
		set
		{
			m_Area = value;
		}
	}

	public bool generateLinks
	{
		get
		{
			return m_GenerateLinks != 0;
		}
		set
		{
			m_GenerateLinks = (value ? 1 : 0);
		}
	}

	public Object sourceObject
	{
		get
		{
			return InternalGetObject(m_InstanceID);
		}
		set
		{
			m_InstanceID = ((value != null) ? value.GetInstanceID() : 0);
		}
	}

	public Component component
	{
		get
		{
			return InternalGetComponent(m_ComponentID);
		}
		set
		{
			m_ComponentID = ((value != null) ? value.GetInstanceID() : 0);
		}
	}

	[StaticAccessor("NavMeshBuildSource", StaticAccessorType.DoubleColon)]
	private static Component InternalGetComponent(int instanceID)
	{
		return Unmarshal.UnmarshalUnityObject<Component>(InternalGetComponent_Injected(instanceID));
	}

	[StaticAccessor("NavMeshBuildSource", StaticAccessorType.DoubleColon)]
	private static Object InternalGetObject(int instanceID)
	{
		return Unmarshal.UnmarshalUnityObject<Object>(InternalGetObject_Injected(instanceID));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr InternalGetComponent_Injected(int instanceID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr InternalGetObject_Injected(int instanceID);
}
