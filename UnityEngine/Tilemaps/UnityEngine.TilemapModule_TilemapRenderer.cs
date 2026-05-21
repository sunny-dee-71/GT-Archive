using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.U2D;

namespace UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
[NativeHeader("Modules/Tilemap/TilemapRendererJobs.h")]
[NativeHeader("Modules/Grid/Public/GridMarshalling.h")]
[NativeType(Header = "Modules/Tilemap/Public/TilemapRenderer.h")]
[NativeHeader("Modules/Tilemap/Public/TilemapMarshalling.h")]
public sealed class TilemapRenderer : Renderer
{
	public enum SortOrder
	{
		BottomLeft,
		BottomRight,
		TopLeft,
		TopRight
	}

	public enum Mode
	{
		Chunk,
		Individual,
		SRPBatch
	}

	public enum DetectChunkCullingBounds
	{
		Auto,
		Manual
	}

	public Vector3Int chunkSize
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_chunkSize_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_chunkSize_Injected(intPtr, ref value);
		}
	}

	public Vector3 chunkCullingBounds
	{
		[FreeFunction("TilemapRendererBindings::GetChunkCullingBounds", HasExplicitThis = true)]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_chunkCullingBounds_Injected(intPtr, out var ret);
			return ret;
		}
		[FreeFunction("TilemapRendererBindings::SetChunkCullingBounds", HasExplicitThis = true)]
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_chunkCullingBounds_Injected(intPtr, ref value);
		}
	}

	public int maxChunkCount
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_maxChunkCount_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_maxChunkCount_Injected(intPtr, value);
		}
	}

	public int maxFrameAge
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_maxFrameAge_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_maxFrameAge_Injected(intPtr, value);
		}
	}

	public SortOrder sortOrder
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_sortOrder_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_sortOrder_Injected(intPtr, value);
		}
	}

	[NativeProperty("RenderMode")]
	public Mode mode
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_mode_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_mode_Injected(intPtr, value);
		}
	}

	public DetectChunkCullingBounds detectChunkCullingBounds
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_detectChunkCullingBounds_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_detectChunkCullingBounds_Injected(intPtr, value);
		}
	}

	public SpriteMaskInteraction maskInteraction
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_maskInteraction_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_maskInteraction_Injected(intPtr, value);
		}
	}

	[RequiredByNativeCode]
	internal void RegisterSpriteAtlasRegistered()
	{
		SpriteAtlasManager.atlasRegistered += OnSpriteAtlasRegistered;
	}

	[RequiredByNativeCode]
	internal void UnregisterSpriteAtlasRegistered()
	{
		SpriteAtlasManager.atlasRegistered -= OnSpriteAtlasRegistered;
	}

	internal void OnSpriteAtlasRegistered(SpriteAtlas atlas)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		OnSpriteAtlasRegistered_Injected(intPtr, MarshalledUnityObject.Marshal(atlas));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_chunkSize_Injected(IntPtr _unity_self, out Vector3Int ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_chunkSize_Injected(IntPtr _unity_self, [In] ref Vector3Int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_chunkCullingBounds_Injected(IntPtr _unity_self, out Vector3 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_chunkCullingBounds_Injected(IntPtr _unity_self, [In] ref Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_maxChunkCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_maxChunkCount_Injected(IntPtr _unity_self, int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_maxFrameAge_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_maxFrameAge_Injected(IntPtr _unity_self, int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern SortOrder get_sortOrder_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_sortOrder_Injected(IntPtr _unity_self, SortOrder value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Mode get_mode_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_mode_Injected(IntPtr _unity_self, Mode value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern DetectChunkCullingBounds get_detectChunkCullingBounds_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_detectChunkCullingBounds_Injected(IntPtr _unity_self, DetectChunkCullingBounds value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern SpriteMaskInteraction get_maskInteraction_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_maskInteraction_Injected(IntPtr _unity_self, SpriteMaskInteraction value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void OnSpriteAtlasRegistered_Injected(IntPtr _unity_self, IntPtr atlas);
}
