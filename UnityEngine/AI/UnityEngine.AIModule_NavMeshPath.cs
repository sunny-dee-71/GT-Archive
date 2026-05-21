using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.AI;

[StructLayout(LayoutKind.Sequential)]
[MovedFrom("UnityEngine")]
[NativeHeader("Modules/AI/NavMeshPath.bindings.h")]
public sealed class NavMeshPath
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(NavMeshPath navMeshPath)
		{
			return navMeshPath.m_Ptr;
		}
	}

	internal IntPtr m_Ptr;

	internal Vector3[] m_Corners;

	public Vector3[] corners
	{
		get
		{
			CalculateCorners();
			return m_Corners;
		}
	}

	public NavMeshPathStatus status
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_status_Injected(intPtr);
		}
	}

	public NavMeshPath()
	{
		m_Ptr = InitializeNavMeshPath();
	}

	~NavMeshPath()
	{
		DestroyNavMeshPath(m_Ptr);
		m_Ptr = IntPtr.Zero;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("NavMeshPathScriptBindings::InitializeNavMeshPath")]
	private static extern IntPtr InitializeNavMeshPath();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("NavMeshPathScriptBindings::DestroyNavMeshPath", IsThreadSafe = true)]
	private static extern void DestroyNavMeshPath(IntPtr ptr);

	[FreeFunction("NavMeshPathScriptBindings::GetCornersNonAlloc", HasExplicitThis = true)]
	public unsafe int GetCornersNonAlloc([Out] Vector3[] results)
	{
		//The blocks IL_002b are reachable both inside and outside the pinned region starting at IL_0014. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper results2 = default(BlittableArrayWrapper);
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			if (results != null)
			{
				fixed (Vector3[] array = results)
				{
					if (array.Length != 0)
					{
						results2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					return GetCornersNonAlloc_Injected(intPtr, out results2);
				}
			}
			return GetCornersNonAlloc_Injected(intPtr, out results2);
		}
		finally
		{
			results2.Unmarshal(ref array);
		}
	}

	[FreeFunction("NavMeshPathScriptBindings::CalculateCornersInternal", HasExplicitThis = true)]
	private Vector3[] CalculateCornersInternal()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		Vector3[] result;
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			CalculateCornersInternal_Injected(intPtr, out ret);
		}
		finally
		{
			Vector3[] array = default(Vector3[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[FreeFunction("NavMeshPathScriptBindings::ClearCornersInternal", HasExplicitThis = true)]
	private void ClearCornersInternal()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ClearCornersInternal_Injected(intPtr);
	}

	public void ClearCorners()
	{
		ClearCornersInternal();
		m_Corners = null;
	}

	private void CalculateCorners()
	{
		if (m_Corners == null)
		{
			m_Corners = CalculateCornersInternal();
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetCornersNonAlloc_Injected(IntPtr _unity_self, out BlittableArrayWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CalculateCornersInternal_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ClearCornersInternal_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern NavMeshPathStatus get_status_Injected(IntPtr _unity_self);
}
