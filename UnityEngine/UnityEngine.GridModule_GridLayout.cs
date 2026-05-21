using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine;

[NativeType(Header = "Modules/Grid/Public/Grid.h")]
[NativeHeader("Modules/Grid/Public/GridMarshalling.h")]
[RequireComponent(typeof(Transform))]
public class GridLayout : Behaviour
{
	public enum CellLayout
	{
		Rectangle,
		Hexagon,
		Isometric,
		IsometricZAsY
	}

	public enum CellSwizzle
	{
		XYZ,
		XZY,
		YXZ,
		YZX,
		ZXY,
		ZYX
	}

	public Vector3 cellSize
	{
		[FreeFunction("GridLayoutBindings::GetCellSize", HasExplicitThis = true)]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_cellSize_Injected(intPtr, out var ret);
			return ret;
		}
	}

	public Vector3 cellGap
	{
		[FreeFunction("GridLayoutBindings::GetCellGap", HasExplicitThis = true)]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_cellGap_Injected(intPtr, out var ret);
			return ret;
		}
	}

	public CellLayout cellLayout
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_cellLayout_Injected(intPtr);
		}
	}

	public CellSwizzle cellSwizzle
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_cellSwizzle_Injected(intPtr);
		}
	}

	[FreeFunction("GridLayoutBindings::GetBoundsLocal", HasExplicitThis = true)]
	public Bounds GetBoundsLocal(Vector3Int cellPosition)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetBoundsLocal_Injected(intPtr, ref cellPosition, out var ret);
		return ret;
	}

	public Bounds GetBoundsLocal(Vector3 origin, Vector3 size)
	{
		return GetBoundsLocalOriginSize(origin, size);
	}

	[FreeFunction("GridLayoutBindings::GetBoundsLocalOriginSize", HasExplicitThis = true)]
	private Bounds GetBoundsLocalOriginSize(Vector3 origin, Vector3 size)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetBoundsLocalOriginSize_Injected(intPtr, ref origin, ref size, out var ret);
		return ret;
	}

	[FreeFunction("GridLayoutBindings::CellToLocal", HasExplicitThis = true)]
	public Vector3 CellToLocal(Vector3Int cellPosition)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		CellToLocal_Injected(intPtr, ref cellPosition, out var ret);
		return ret;
	}

	[FreeFunction("GridLayoutBindings::LocalToCell", HasExplicitThis = true)]
	public Vector3Int LocalToCell(Vector3 localPosition)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		LocalToCell_Injected(intPtr, ref localPosition, out var ret);
		return ret;
	}

	[FreeFunction("GridLayoutBindings::CellToLocalInterpolated", HasExplicitThis = true)]
	public Vector3 CellToLocalInterpolated(Vector3 cellPosition)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		CellToLocalInterpolated_Injected(intPtr, ref cellPosition, out var ret);
		return ret;
	}

	[FreeFunction("GridLayoutBindings::LocalToCellInterpolated", HasExplicitThis = true)]
	public Vector3 LocalToCellInterpolated(Vector3 localPosition)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		LocalToCellInterpolated_Injected(intPtr, ref localPosition, out var ret);
		return ret;
	}

	[FreeFunction("GridLayoutBindings::CellToWorld", HasExplicitThis = true)]
	public Vector3 CellToWorld(Vector3Int cellPosition)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		CellToWorld_Injected(intPtr, ref cellPosition, out var ret);
		return ret;
	}

	[FreeFunction("GridLayoutBindings::WorldToCell", HasExplicitThis = true)]
	public Vector3Int WorldToCell(Vector3 worldPosition)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		WorldToCell_Injected(intPtr, ref worldPosition, out var ret);
		return ret;
	}

	[FreeFunction("GridLayoutBindings::LocalToWorld", HasExplicitThis = true)]
	public Vector3 LocalToWorld(Vector3 localPosition)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		LocalToWorld_Injected(intPtr, ref localPosition, out var ret);
		return ret;
	}

	[FreeFunction("GridLayoutBindings::WorldToLocal", HasExplicitThis = true)]
	public Vector3 WorldToLocal(Vector3 worldPosition)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		WorldToLocal_Injected(intPtr, ref worldPosition, out var ret);
		return ret;
	}

	[FreeFunction("GridLayoutBindings::GetLayoutCellCenter", HasExplicitThis = true)]
	public Vector3 GetLayoutCellCenter()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetLayoutCellCenter_Injected(intPtr, out var ret);
		return ret;
	}

	[RequiredByNativeCode]
	private void DoNothing()
	{
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_cellSize_Injected(IntPtr _unity_self, out Vector3 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_cellGap_Injected(IntPtr _unity_self, out Vector3 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern CellLayout get_cellLayout_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern CellSwizzle get_cellSwizzle_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetBoundsLocal_Injected(IntPtr _unity_self, [In] ref Vector3Int cellPosition, out Bounds ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetBoundsLocalOriginSize_Injected(IntPtr _unity_self, [In] ref Vector3 origin, [In] ref Vector3 size, out Bounds ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CellToLocal_Injected(IntPtr _unity_self, [In] ref Vector3Int cellPosition, out Vector3 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void LocalToCell_Injected(IntPtr _unity_self, [In] ref Vector3 localPosition, out Vector3Int ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CellToLocalInterpolated_Injected(IntPtr _unity_self, [In] ref Vector3 cellPosition, out Vector3 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void LocalToCellInterpolated_Injected(IntPtr _unity_self, [In] ref Vector3 localPosition, out Vector3 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CellToWorld_Injected(IntPtr _unity_self, [In] ref Vector3Int cellPosition, out Vector3 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void WorldToCell_Injected(IntPtr _unity_self, [In] ref Vector3 worldPosition, out Vector3Int ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void LocalToWorld_Injected(IntPtr _unity_self, [In] ref Vector3 localPosition, out Vector3 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void WorldToLocal_Injected(IntPtr _unity_self, [In] ref Vector3 worldPosition, out Vector3 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetLayoutCellCenter_Injected(IntPtr _unity_self, out Vector3 ret);
}
