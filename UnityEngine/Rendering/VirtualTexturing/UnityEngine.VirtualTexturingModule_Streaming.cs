using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine.Rendering.VirtualTexturing;

[NativeHeader("Modules/VirtualTexturing/ScriptBindings/VirtualTexturing.bindings.h")]
[StaticAccessor("VirtualTexturing::Streaming", StaticAccessorType.DoubleColon)]
public static class Streaming
{
	[NativeThrows]
	public static void RequestRegion([NotNull] Material mat, int stackNameId, Rect r, int mipMap, int numMips)
	{
		if ((object)mat == null)
		{
			ThrowHelper.ThrowArgumentNullException(mat, "mat");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(mat);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(mat, "mat");
		}
		RequestRegion_Injected(intPtr, stackNameId, ref r, mipMap, numMips);
	}

	[NativeThrows]
	public static void GetTextureStackSize([NotNull] Material mat, int stackNameId, out int width, out int height)
	{
		if ((object)mat == null)
		{
			ThrowHelper.ThrowArgumentNullException(mat, "mat");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(mat);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(mat, "mat");
		}
		GetTextureStackSize_Injected(intPtr, stackNameId, out width, out height);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void SetCPUCacheSize(int sizeInMegabytes);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern int GetCPUCacheSize();

	[NativeThrows]
	public unsafe static void SetGPUCacheSettings(GPUCacheSetting[] cacheSettings)
	{
		Span<GPUCacheSetting> span = new Span<GPUCacheSetting>(cacheSettings);
		fixed (GPUCacheSetting* begin = span)
		{
			ManagedSpanWrapper cacheSettings2 = new ManagedSpanWrapper(begin, span.Length);
			SetGPUCacheSettings_Injected(ref cacheSettings2);
		}
	}

	[NativeThrows]
	public static GPUCacheSetting[] GetGPUCacheSettings()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		GPUCacheSetting[] result;
		try
		{
			GetGPUCacheSettings_Injected(out ret);
		}
		finally
		{
			GPUCacheSetting[] array = default(GPUCacheSetting[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void EnableMipPreloading(int texturesPerFrame, int mipCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void RequestRegion_Injected(IntPtr mat, int stackNameId, [In] ref Rect r, int mipMap, int numMips);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetTextureStackSize_Injected(IntPtr mat, int stackNameId, out int width, out int height);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetGPUCacheSettings_Injected(ref ManagedSpanWrapper cacheSettings);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetGPUCacheSettings_Injected(out BlittableArrayWrapper ret);
}
