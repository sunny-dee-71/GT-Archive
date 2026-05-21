using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine;

[NativeType(Header = "Modules/Grid/Public/Grid.h")]
[RequireComponent(typeof(Transform))]
[NativeHeader("Modules/Grid/Public/GridMarshalling.h")]
public sealed class Grid : GridLayout
{
	public new Vector3 cellSize
	{
		[FreeFunction("GridBindings::GetCellSize", HasExplicitThis = true)]
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
		[FreeFunction("GridBindings::SetCellSize", HasExplicitThis = true)]
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_cellSize_Injected(intPtr, ref value);
		}
	}

	public new Vector3 cellGap
	{
		[FreeFunction("GridBindings::GetCellGap", HasExplicitThis = true)]
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
		[FreeFunction("GridBindings::SetCellGap", HasExplicitThis = true)]
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_cellGap_Injected(intPtr, ref value);
		}
	}

	public new CellLayout cellLayout
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
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_cellLayout_Injected(intPtr, value);
		}
	}

	public new CellSwizzle cellSwizzle
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
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_cellSwizzle_Injected(intPtr, value);
		}
	}

	public Vector3 GetCellCenterLocal(Vector3Int position)
	{
		return CellToLocalInterpolated(position + GetLayoutCellCenter());
	}

	public Vector3 GetCellCenterWorld(Vector3Int position)
	{
		return LocalToWorld(CellToLocalInterpolated(position + GetLayoutCellCenter()));
	}

	[FreeFunction("GridBindings::CellSwizzle")]
	public static Vector3 Swizzle(CellSwizzle swizzle, Vector3 position)
	{
		Swizzle_Injected(swizzle, ref position, out var ret);
		return ret;
	}

	[FreeFunction("GridBindings::InverseCellSwizzle")]
	public static Vector3 InverseSwizzle(CellSwizzle swizzle, Vector3 position)
	{
		InverseSwizzle_Injected(swizzle, ref position, out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_cellSize_Injected(IntPtr _unity_self, out Vector3 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_cellSize_Injected(IntPtr _unity_self, [In] ref Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_cellGap_Injected(IntPtr _unity_self, out Vector3 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_cellGap_Injected(IntPtr _unity_self, [In] ref Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern CellLayout get_cellLayout_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_cellLayout_Injected(IntPtr _unity_self, CellLayout value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern CellSwizzle get_cellSwizzle_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_cellSwizzle_Injected(IntPtr _unity_self, CellSwizzle value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Swizzle_Injected(CellSwizzle swizzle, [In] ref Vector3 position, out Vector3 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void InverseSwizzle_Injected(CellSwizzle swizzle, [In] ref Vector3 position, out Vector3 ret);
}
