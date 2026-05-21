using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Tilemaps;

[NativeType(Header = "Modules/Tilemap/Public/Tilemap.h")]
[RequireComponent(typeof(Transform))]
[NativeHeader("Modules/Grid/Public/GridMarshalling.h")]
[NativeHeader("Modules/Grid/Public/Grid.h")]
[NativeHeader("Runtime/Graphics/SpriteFrame.h")]
[NativeHeader("Modules/Tilemap/Public/TilemapTile.h")]
[NativeHeader("Modules/Tilemap/Public/TilemapMarshalling.h")]
public sealed class Tilemap : GridLayout
{
	public enum Orientation
	{
		XY,
		XZ,
		YX,
		YZ,
		ZX,
		ZY,
		Custom
	}

	[RequiredByNativeCode]
	public struct SyncTile
	{
		internal Vector3Int m_Position;

		internal TileBase m_Tile;

		internal TileData m_TileData;

		public Vector3Int position => m_Position;

		public TileBase tile => m_Tile;

		public TileData tileData => m_TileData;
	}

	internal struct SyncTileCallbackSettings
	{
		internal bool hasSyncTileCallback;

		internal bool hasPositionsChangedCallback;

		internal bool isBufferSyncTile;
	}

	private bool m_BufferSyncTile;

	internal bool bufferSyncTile
	{
		get
		{
			return m_BufferSyncTile;
		}
		set
		{
			if (!value && m_BufferSyncTile != value && HasSyncTileCallback())
			{
				SendAndClearSyncTileBuffer();
			}
			m_BufferSyncTile = value;
		}
	}

	public Grid layoutGrid
	{
		[NativeMethod(Name = "GetAttachedGrid")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Grid>(get_layoutGrid_Injected(intPtr));
		}
	}

	public BoundsInt cellBounds => new BoundsInt(origin, size);

	[NativeProperty("TilemapBoundsScripting")]
	public Bounds localBounds
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_localBounds_Injected(intPtr, out var ret);
			return ret;
		}
	}

	[NativeProperty("TilemapFrameBoundsScripting")]
	internal Bounds localFrameBounds
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_localFrameBounds_Injected(intPtr, out var ret);
			return ret;
		}
	}

	public float animationFrameRate
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_animationFrameRate_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_animationFrameRate_Injected(intPtr, value);
		}
	}

	public Color color
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_color_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_color_Injected(intPtr, ref value);
		}
	}

	public Vector3Int origin
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_origin_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_origin_Injected(intPtr, ref value);
		}
	}

	public Vector3Int size
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_size_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_size_Injected(intPtr, ref value);
		}
	}

	[NativeProperty(Name = "TileAnchorScripting")]
	public Vector3 tileAnchor
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_tileAnchor_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_tileAnchor_Injected(intPtr, ref value);
		}
	}

	public Orientation orientation
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_orientation_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_orientation_Injected(intPtr, value);
		}
	}

	public Matrix4x4 orientationMatrix
	{
		[NativeMethod(Name = "GetTileOrientationMatrix")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_orientationMatrix_Injected(intPtr, out var ret);
			return ret;
		}
		[NativeMethod(Name = "SetOrientationMatrix")]
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_orientationMatrix_Injected(intPtr, ref value);
		}
	}

	public static event Action<Tilemap, SyncTile[]> tilemapTileChanged;

	public static event Action<Tilemap, NativeArray<Vector3Int>> tilemapPositionsChanged;

	public static event Action<Tilemap, NativeArray<Vector3Int>> loopEndedForTileAnimation;

	internal static bool HasLoopEndedForTileAnimationCallback()
	{
		return Tilemap.loopEndedForTileAnimation != null;
	}

	private unsafe void HandleLoopEndedForTileAnimationCallback(int count, IntPtr positionsIntPtr)
	{
		if (HasLoopEndedForTileAnimationCallback())
		{
			void* dataPointer = positionsIntPtr.ToPointer();
			NativeArray<Vector3Int> positions = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<Vector3Int>(dataPointer, count, Allocator.Invalid);
			SendLoopEndedForTileAnimationCallback(positions);
		}
	}

	private void SendLoopEndedForTileAnimationCallback(NativeArray<Vector3Int> positions)
	{
		try
		{
			Tilemap.loopEndedForTileAnimation(this, positions);
		}
		catch (Exception exception)
		{
			Debug.LogException(exception, this);
		}
	}

	internal static bool HasSyncTileCallback()
	{
		return Tilemap.tilemapTileChanged != null;
	}

	internal static bool HasPositionsChangedCallback()
	{
		return Tilemap.tilemapPositionsChanged != null;
	}

	private void HandleSyncTileCallback(SyncTile[] syncTiles)
	{
		if (Tilemap.tilemapTileChanged != null)
		{
			SendTilemapTileChangedCallback(syncTiles);
		}
	}

	private unsafe void HandlePositionsChangedCallback(int count, IntPtr positionsIntPtr)
	{
		if (HasPositionsChangedCallback())
		{
			void* dataPointer = positionsIntPtr.ToPointer();
			NativeArray<Vector3Int> positions = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<Vector3Int>(dataPointer, count, Allocator.Invalid);
			SendTilemapPositionsChangedCallback(positions);
		}
	}

	private void SendTilemapTileChangedCallback(SyncTile[] syncTiles)
	{
		try
		{
			Tilemap.tilemapTileChanged(this, syncTiles);
		}
		catch (Exception exception)
		{
			Debug.LogException(exception, this);
		}
	}

	private void SendTilemapPositionsChangedCallback(NativeArray<Vector3Int> positions)
	{
		try
		{
			Tilemap.tilemapPositionsChanged(this, positions);
		}
		catch (Exception exception)
		{
			Debug.LogException(exception, this);
		}
	}

	internal static void SetSyncTileCallback(Action<Tilemap, SyncTile[]> callback)
	{
		tilemapTileChanged += callback;
	}

	internal static void RemoveSyncTileCallback(Action<Tilemap, SyncTile[]> callback)
	{
		tilemapTileChanged -= callback;
	}

	public Vector3 GetCellCenterLocal(Vector3Int position)
	{
		return CellToLocalInterpolated(position) + CellToLocalInterpolated(tileAnchor);
	}

	public Vector3 GetCellCenterWorld(Vector3Int position)
	{
		return LocalToWorld(CellToLocalInterpolated(position) + CellToLocalInterpolated(tileAnchor));
	}

	internal Object GetTileAsset(Vector3Int position)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<Object>(GetTileAsset_Injected(intPtr, ref position));
	}

	public TileBase GetTile(Vector3Int position)
	{
		return GetTileAsset(position) as TileBase;
	}

	public T GetTile<T>(Vector3Int position) where T : TileBase
	{
		return GetTileAsset(position) as T;
	}

	internal Object[] GetTileAssetsBlock(Vector3Int position, Vector3Int blockDimensions)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetTileAssetsBlock_Injected(intPtr, ref position, ref blockDimensions);
	}

	public TileBase[] GetTilesBlock(BoundsInt bounds)
	{
		Object[] tileAssetsBlock = GetTileAssetsBlock(bounds.min, bounds.size);
		TileBase[] array = new TileBase[tileAssetsBlock.Length];
		for (int i = 0; i < tileAssetsBlock.Length; i++)
		{
			array[i] = (TileBase)tileAssetsBlock[i];
		}
		return array;
	}

	[FreeFunction(Name = "TilemapBindings::GetTileAssetsBlockNonAlloc", HasExplicitThis = true)]
	internal int GetTileAssetsBlockNonAlloc(Vector3Int startPosition, Vector3Int endPosition, [Unmarshalled] Object[] tiles)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetTileAssetsBlockNonAlloc_Injected(intPtr, ref startPosition, ref endPosition, tiles);
	}

	public int GetTilesBlockNonAlloc(BoundsInt bounds, TileBase[] tiles)
	{
		return GetTileAssetsBlockNonAlloc(bounds.min, bounds.size, tiles);
	}

	public int GetTilesRangeCount(Vector3Int startPosition, Vector3Int endPosition)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetTilesRangeCount_Injected(intPtr, ref startPosition, ref endPosition);
	}

	[FreeFunction(Name = "TilemapBindings::GetTileAssetsRangeNonAlloc", HasExplicitThis = true)]
	internal unsafe int GetTileAssetsRangeNonAlloc(Vector3Int startPosition, Vector3Int endPosition, Vector3Int[] positions, [Unmarshalled] Object[] tiles)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Span<Vector3Int> span = new Span<Vector3Int>(positions);
		int tileAssetsRangeNonAlloc_Injected;
		fixed (Vector3Int* begin = span)
		{
			ManagedSpanWrapper positions2 = new ManagedSpanWrapper(begin, span.Length);
			tileAssetsRangeNonAlloc_Injected = GetTileAssetsRangeNonAlloc_Injected(intPtr, ref startPosition, ref endPosition, ref positions2, tiles);
		}
		return tileAssetsRangeNonAlloc_Injected;
	}

	public int GetTilesRangeNonAlloc(Vector3Int startPosition, Vector3Int endPosition, Vector3Int[] positions, TileBase[] tiles)
	{
		return GetTileAssetsRangeNonAlloc(startPosition, endPosition, positions, tiles);
	}

	internal void SetTileAsset(Vector3Int position, Object tile)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetTileAsset_Injected(intPtr, ref position, MarshalledUnityObject.Marshal(tile));
	}

	public void SetTile(Vector3Int position, TileBase tile)
	{
		SetTileAsset(position, tile);
	}

	internal unsafe void SetTileAssets(Vector3Int[] positionArray, Object[] tileArray)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Span<Vector3Int> span = new Span<Vector3Int>(positionArray);
		fixed (Vector3Int* begin = span)
		{
			ManagedSpanWrapper positionArray2 = new ManagedSpanWrapper(begin, span.Length);
			SetTileAssets_Injected(intPtr, ref positionArray2, tileArray);
		}
	}

	public void SetTiles(Vector3Int[] positionArray, TileBase[] tileArray)
	{
		SetTileAssets(positionArray, tileArray);
	}

	[NativeMethod(Name = "SetTileAssetsBlock")]
	private void INTERNAL_CALL_SetTileAssetsBlock(Vector3Int position, Vector3Int blockDimensions, Object[] tileArray)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		INTERNAL_CALL_SetTileAssetsBlock_Injected(intPtr, ref position, ref blockDimensions, tileArray);
	}

	public void SetTilesBlock(BoundsInt position, TileBase[] tileArray)
	{
		INTERNAL_CALL_SetTileAssetsBlock(position.min, position.size, tileArray);
	}

	[NativeMethod(Name = "SetTileChangeData")]
	public void SetTile(TileChangeData tileChangeData, bool ignoreLockFlags)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetTile_Injected(intPtr, ref tileChangeData, ignoreLockFlags);
	}

	[NativeMethod(Name = "SetTileChangeDataArray")]
	public void SetTiles(TileChangeData[] tileChangeDataArray, bool ignoreLockFlags)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetTiles_Injected(intPtr, tileChangeDataArray, ignoreLockFlags);
	}

	public bool HasTile(Vector3Int position)
	{
		return GetTileAsset(position) != null;
	}

	[NativeMethod(Name = "RefreshTileAsset")]
	public void RefreshTile(Vector3Int position)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		RefreshTile_Injected(intPtr, ref position);
	}

	[FreeFunction(Name = "TilemapBindings::RefreshTileAssetsNative", HasExplicitThis = true)]
	internal unsafe void RefreshTilesNative(void* positions, int count)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		RefreshTilesNative_Injected(intPtr, positions, count);
	}

	[NativeMethod(Name = "RefreshAllTileAssets")]
	public void RefreshAllTiles()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		RefreshAllTiles_Injected(intPtr);
	}

	internal void SwapTileAsset(Object changeTile, Object newTile)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SwapTileAsset_Injected(intPtr, MarshalledUnityObject.Marshal(changeTile), MarshalledUnityObject.Marshal(newTile));
	}

	public void SwapTile(TileBase changeTile, TileBase newTile)
	{
		SwapTileAsset(changeTile, newTile);
	}

	internal bool ContainsTileAsset(Object tileAsset)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return ContainsTileAsset_Injected(intPtr, MarshalledUnityObject.Marshal(tileAsset));
	}

	public bool ContainsTile(TileBase tileAsset)
	{
		return ContainsTileAsset(tileAsset);
	}

	public int GetUsedTilesCount()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetUsedTilesCount_Injected(intPtr);
	}

	public int GetUsedSpritesCount()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetUsedSpritesCount_Injected(intPtr);
	}

	public int GetUsedTilesNonAlloc(TileBase[] usedTiles)
	{
		return Internal_GetUsedTilesNonAlloc(usedTiles);
	}

	public int GetUsedSpritesNonAlloc(Sprite[] usedSprites)
	{
		return Internal_GetUsedSpritesNonAlloc(usedSprites);
	}

	[FreeFunction(Name = "TilemapBindings::GetUsedTilesNonAlloc", HasExplicitThis = true)]
	internal int Internal_GetUsedTilesNonAlloc([Unmarshalled] Object[] usedTiles)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Internal_GetUsedTilesNonAlloc_Injected(intPtr, usedTiles);
	}

	[FreeFunction(Name = "TilemapBindings::GetUsedSpritesNonAlloc", HasExplicitThis = true)]
	internal int Internal_GetUsedSpritesNonAlloc([Unmarshalled] Object[] usedSprites)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Internal_GetUsedSpritesNonAlloc_Injected(intPtr, usedSprites);
	}

	public Sprite GetSprite(Vector3Int position)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<Sprite>(GetSprite_Injected(intPtr, ref position));
	}

	public Matrix4x4 GetTransformMatrix(Vector3Int position)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetTransformMatrix_Injected(intPtr, ref position, out var ret);
		return ret;
	}

	public void SetTransformMatrix(Vector3Int position, Matrix4x4 transform)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetTransformMatrix_Injected(intPtr, ref position, ref transform);
	}

	[NativeMethod(Name = "GetTileColor")]
	public Color GetColor(Vector3Int position)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetColor_Injected(intPtr, ref position, out var ret);
		return ret;
	}

	[NativeMethod(Name = "SetTileColor")]
	public void SetColor(Vector3Int position, Color color)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetColor_Injected(intPtr, ref position, ref color);
	}

	public TileFlags GetTileFlags(Vector3Int position)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetTileFlags_Injected(intPtr, ref position);
	}

	public void SetTileFlags(Vector3Int position, TileFlags flags)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetTileFlags_Injected(intPtr, ref position, flags);
	}

	public void AddTileFlags(Vector3Int position, TileFlags flags)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		AddTileFlags_Injected(intPtr, ref position, flags);
	}

	public void RemoveTileFlags(Vector3Int position, TileFlags flags)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		RemoveTileFlags_Injected(intPtr, ref position, flags);
	}

	[NativeMethod(Name = "GetTileInstantiatedObject")]
	public GameObject GetInstantiatedObject(Vector3Int position)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<GameObject>(GetInstantiatedObject_Injected(intPtr, ref position));
	}

	[NativeMethod(Name = "GetTileObjectToInstantiate")]
	public GameObject GetObjectToInstantiate(Vector3Int position)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<GameObject>(GetObjectToInstantiate_Injected(intPtr, ref position));
	}

	[NativeMethod(Name = "SetTileColliderType")]
	public void SetColliderType(Vector3Int position, Tile.ColliderType colliderType)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetColliderType_Injected(intPtr, ref position, colliderType);
	}

	[NativeMethod(Name = "GetTileColliderType")]
	public Tile.ColliderType GetColliderType(Vector3Int position)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetColliderType_Injected(intPtr, ref position);
	}

	[NativeMethod(Name = "GetTileAnimationFrameCount")]
	public int GetAnimationFrameCount(Vector3Int position)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetAnimationFrameCount_Injected(intPtr, ref position);
	}

	[NativeMethod(Name = "GetTileAnimationFrame")]
	public int GetAnimationFrame(Vector3Int position)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetAnimationFrame_Injected(intPtr, ref position);
	}

	[NativeMethod(Name = "SetTileAnimationFrame")]
	public void SetAnimationFrame(Vector3Int position, int frame)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetAnimationFrame_Injected(intPtr, ref position, frame);
	}

	[NativeMethod(Name = "GetTileAnimationTime")]
	public float GetAnimationTime(Vector3Int position)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetAnimationTime_Injected(intPtr, ref position);
	}

	[NativeMethod(Name = "SetTileAnimationTime")]
	public void SetAnimationTime(Vector3Int position, float time)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetAnimationTime_Injected(intPtr, ref position, time);
	}

	public TileAnimationFlags GetTileAnimationFlags(Vector3Int position)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetTileAnimationFlags_Injected(intPtr, ref position);
	}

	public void SetTileAnimationFlags(Vector3Int position, TileAnimationFlags flags)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetTileAnimationFlags_Injected(intPtr, ref position, flags);
	}

	public void AddTileAnimationFlags(Vector3Int position, TileAnimationFlags flags)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		AddTileAnimationFlags_Injected(intPtr, ref position, flags);
	}

	public void RemoveTileAnimationFlags(Vector3Int position, TileAnimationFlags flags)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		RemoveTileAnimationFlags_Injected(intPtr, ref position, flags);
	}

	public void FloodFill(Vector3Int position, TileBase tile)
	{
		FloodFillTileAsset(position, tile);
	}

	[NativeMethod(Name = "FloodFill")]
	private void FloodFillTileAsset(Vector3Int position, Object tile)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		FloodFillTileAsset_Injected(intPtr, ref position, MarshalledUnityObject.Marshal(tile));
	}

	public void BoxFill(Vector3Int position, TileBase tile, int startX, int startY, int endX, int endY)
	{
		BoxFillTileAsset(position, tile, startX, startY, endX, endY);
	}

	[NativeMethod(Name = "BoxFill")]
	private void BoxFillTileAsset(Vector3Int position, Object tile, int startX, int startY, int endX, int endY)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		BoxFillTileAsset_Injected(intPtr, ref position, MarshalledUnityObject.Marshal(tile), startX, startY, endX, endY);
	}

	public void InsertCells(Vector3Int position, Vector3Int insertCells)
	{
		InsertCells(position, insertCells.x, insertCells.y, insertCells.z);
	}

	public void InsertCells(Vector3Int position, int numColumns, int numRows, int numLayers)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		InsertCells_Injected(intPtr, ref position, numColumns, numRows, numLayers);
	}

	public void DeleteCells(Vector3Int position, Vector3Int deleteCells)
	{
		DeleteCells(position, deleteCells.x, deleteCells.y, deleteCells.z);
	}

	public void DeleteCells(Vector3Int position, int numColumns, int numRows, int numLayers)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		DeleteCells_Injected(intPtr, ref position, numColumns, numRows, numLayers);
	}

	public void ClearAllTiles()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ClearAllTiles_Injected(intPtr);
	}

	public void ResizeBounds()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ResizeBounds_Injected(intPtr);
	}

	[NativeMethod(Name = "CompressBounds")]
	private void CompressTilemapBounds(bool keepEditorPreview)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		CompressTilemapBounds_Injected(intPtr, keepEditorPreview);
	}

	public void CompressBounds()
	{
		CompressTilemapBounds(keepEditorPreview: false);
	}

	[RequiredByNativeCode]
	internal void GetLoopEndedForTileAnimationCallbackSettings(ref bool hasEndLoopForTileAnimationCallback)
	{
		hasEndLoopForTileAnimationCallback = HasLoopEndedForTileAnimationCallback();
	}

	[RequiredByNativeCode]
	private void DoLoopEndedForTileAnimationCallback(int count, IntPtr positionsIntPtr)
	{
		HandleLoopEndedForTileAnimationCallback(count, positionsIntPtr);
	}

	[RequiredByNativeCode]
	internal void GetSyncTileCallbackSettings(ref SyncTileCallbackSettings settings)
	{
		settings.hasSyncTileCallback = HasSyncTileCallback();
		settings.hasPositionsChangedCallback = HasPositionsChangedCallback();
		settings.isBufferSyncTile = bufferSyncTile;
	}

	internal void SendAndClearSyncTileBuffer()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SendAndClearSyncTileBuffer_Injected(intPtr);
	}

	[RequiredByNativeCode]
	private void DoSyncTileCallback(SyncTile[] syncTiles)
	{
		HandleSyncTileCallback(syncTiles);
	}

	[RequiredByNativeCode]
	private void DoPositionsChangedCallback(int count, IntPtr positionsIntPtr)
	{
		HandlePositionsChangedCallback(count, positionsIntPtr);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_layoutGrid_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_localBounds_Injected(IntPtr _unity_self, out Bounds ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_localFrameBounds_Injected(IntPtr _unity_self, out Bounds ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_animationFrameRate_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_animationFrameRate_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_color_Injected(IntPtr _unity_self, out Color ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_color_Injected(IntPtr _unity_self, [In] ref Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_origin_Injected(IntPtr _unity_self, out Vector3Int ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_origin_Injected(IntPtr _unity_self, [In] ref Vector3Int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_size_Injected(IntPtr _unity_self, out Vector3Int ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_size_Injected(IntPtr _unity_self, [In] ref Vector3Int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_tileAnchor_Injected(IntPtr _unity_self, out Vector3 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_tileAnchor_Injected(IntPtr _unity_self, [In] ref Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Orientation get_orientation_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_orientation_Injected(IntPtr _unity_self, Orientation value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_orientationMatrix_Injected(IntPtr _unity_self, out Matrix4x4 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_orientationMatrix_Injected(IntPtr _unity_self, [In] ref Matrix4x4 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetTileAsset_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Object[] GetTileAssetsBlock_Injected(IntPtr _unity_self, [In] ref Vector3Int position, [In] ref Vector3Int blockDimensions);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetTileAssetsBlockNonAlloc_Injected(IntPtr _unity_self, [In] ref Vector3Int startPosition, [In] ref Vector3Int endPosition, Object[] tiles);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetTilesRangeCount_Injected(IntPtr _unity_self, [In] ref Vector3Int startPosition, [In] ref Vector3Int endPosition);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetTileAssetsRangeNonAlloc_Injected(IntPtr _unity_self, [In] ref Vector3Int startPosition, [In] ref Vector3Int endPosition, ref ManagedSpanWrapper positions, Object[] tiles);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetTileAsset_Injected(IntPtr _unity_self, [In] ref Vector3Int position, IntPtr tile);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetTileAssets_Injected(IntPtr _unity_self, ref ManagedSpanWrapper positionArray, Object[] tileArray);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void INTERNAL_CALL_SetTileAssetsBlock_Injected(IntPtr _unity_self, [In] ref Vector3Int position, [In] ref Vector3Int blockDimensions, Object[] tileArray);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetTile_Injected(IntPtr _unity_self, [In] ref TileChangeData tileChangeData, bool ignoreLockFlags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetTiles_Injected(IntPtr _unity_self, TileChangeData[] tileChangeDataArray, bool ignoreLockFlags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void RefreshTile_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern void RefreshTilesNative_Injected(IntPtr _unity_self, void* positions, int count);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void RefreshAllTiles_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SwapTileAsset_Injected(IntPtr _unity_self, IntPtr changeTile, IntPtr newTile);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool ContainsTileAsset_Injected(IntPtr _unity_self, IntPtr tileAsset);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetUsedTilesCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetUsedSpritesCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int Internal_GetUsedTilesNonAlloc_Injected(IntPtr _unity_self, Object[] usedTiles);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int Internal_GetUsedSpritesNonAlloc_Injected(IntPtr _unity_self, Object[] usedSprites);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetSprite_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetTransformMatrix_Injected(IntPtr _unity_self, [In] ref Vector3Int position, out Matrix4x4 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetTransformMatrix_Injected(IntPtr _unity_self, [In] ref Vector3Int position, [In] ref Matrix4x4 transform);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetColor_Injected(IntPtr _unity_self, [In] ref Vector3Int position, out Color ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetColor_Injected(IntPtr _unity_self, [In] ref Vector3Int position, [In] ref Color color);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern TileFlags GetTileFlags_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetTileFlags_Injected(IntPtr _unity_self, [In] ref Vector3Int position, TileFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void AddTileFlags_Injected(IntPtr _unity_self, [In] ref Vector3Int position, TileFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void RemoveTileFlags_Injected(IntPtr _unity_self, [In] ref Vector3Int position, TileFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetInstantiatedObject_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetObjectToInstantiate_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetColliderType_Injected(IntPtr _unity_self, [In] ref Vector3Int position, Tile.ColliderType colliderType);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Tile.ColliderType GetColliderType_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetAnimationFrameCount_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetAnimationFrame_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetAnimationFrame_Injected(IntPtr _unity_self, [In] ref Vector3Int position, int frame);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetAnimationTime_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetAnimationTime_Injected(IntPtr _unity_self, [In] ref Vector3Int position, float time);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern TileAnimationFlags GetTileAnimationFlags_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetTileAnimationFlags_Injected(IntPtr _unity_self, [In] ref Vector3Int position, TileAnimationFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void AddTileAnimationFlags_Injected(IntPtr _unity_self, [In] ref Vector3Int position, TileAnimationFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void RemoveTileAnimationFlags_Injected(IntPtr _unity_self, [In] ref Vector3Int position, TileAnimationFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void FloodFillTileAsset_Injected(IntPtr _unity_self, [In] ref Vector3Int position, IntPtr tile);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void BoxFillTileAsset_Injected(IntPtr _unity_self, [In] ref Vector3Int position, IntPtr tile, int startX, int startY, int endX, int endY);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void InsertCells_Injected(IntPtr _unity_self, [In] ref Vector3Int position, int numColumns, int numRows, int numLayers);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void DeleteCells_Injected(IntPtr _unity_self, [In] ref Vector3Int position, int numColumns, int numRows, int numLayers);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ClearAllTiles_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ResizeBounds_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CompressTilemapBounds_Injected(IntPtr _unity_self, bool keepEditorPreview);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SendAndClearSyncTileBuffer_Injected(IntPtr _unity_self);
}
