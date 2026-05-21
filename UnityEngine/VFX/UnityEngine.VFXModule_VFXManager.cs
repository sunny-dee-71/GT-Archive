using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

namespace UnityEngine.VFX;

[NativeHeader("Modules/VFX/Public/VFXManager.h")]
[NativeHeader("Modules/VFX/Public/ScriptBindings/VFXManagerBindings.h")]
[StaticAccessor("GetVFXManager()", StaticAccessorType.Dot)]
[RequiredByNativeCode]
public static class VFXManager
{
	private static readonly VFXCameraXRSettings kDefaultCameraXRSettings = new VFXCameraXRSettings
	{
		viewTotal = 1u,
		viewCount = 1u,
		viewOffset = 0u
	};

	internal static ScriptableObject runtimeResources => Unmarshal.UnmarshalUnityObject<ScriptableObject>(get_runtimeResources_Injected());

	public static extern float fixedTimeStep
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	public static extern float maxDeltaTime
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	internal static extern uint maxCapacity
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	internal static extern float maxScrubTime
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	internal static string renderPipeSettingsPath
	{
		get
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				get_renderPipeSettingsPath_Injected(out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}
	}

	internal static extern uint batchEmptyLifetime
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern VisualEffect[] GetComponents();

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void CleanupEmptyBatches(bool force = false);

	public static void FlushEmptyBatches()
	{
		CleanupEmptyBatches(force: true);
	}

	public static VFXBatchedEffectInfo GetBatchedEffectInfo([NotNull] VisualEffectAsset vfx)
	{
		if ((object)vfx == null)
		{
			ThrowHelper.ThrowArgumentNullException(vfx, "vfx");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(vfx);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(vfx, "vfx");
		}
		GetBatchedEffectInfo_Injected(intPtr, out var ret);
		return ret;
	}

	[FreeFunction(Name = "VFXManagerBindings::GetBatchedEffectInfos", HasExplicitThis = false)]
	public static void GetBatchedEffectInfos([NotNull] List<VFXBatchedEffectInfo> infos)
	{
		if (infos == null)
		{
			ThrowHelper.ThrowArgumentNullException(infos, "infos");
		}
		GetBatchedEffectInfos_Injected(infos);
	}

	internal static VFXBatchInfo GetBatchInfo(VisualEffectAsset vfx, uint batchIndex)
	{
		GetBatchInfo_Injected(Object.MarshalledUnityObject.Marshal(vfx), batchIndex, out var ret);
		return ret;
	}

	[Obsolete("Use explicit PrepareCamera and ProcessCameraCommand instead")]
	public static void ProcessCamera(Camera cam)
	{
		PrepareCamera(cam, kDefaultCameraXRSettings);
		Internal_ProcessCameraCommand(cam, null, kDefaultCameraXRSettings, IntPtr.Zero, IntPtr.Zero);
	}

	public static void PrepareCamera(Camera cam)
	{
		PrepareCamera(cam, kDefaultCameraXRSettings);
	}

	public static void PrepareCamera([NotNull] Camera cam, VFXCameraXRSettings camXRSettings)
	{
		if ((object)cam == null)
		{
			ThrowHelper.ThrowArgumentNullException(cam, "cam");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(cam);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(cam, "cam");
		}
		PrepareCamera_Injected(intPtr, ref camXRSettings);
	}

	[Obsolete("Use ProcessCameraCommand with CullingResults to allow culling of VFX per camera")]
	public static void ProcessCameraCommand(Camera cam, CommandBuffer cmd)
	{
		Internal_ProcessCameraCommand(cam, cmd, kDefaultCameraXRSettings, IntPtr.Zero, IntPtr.Zero);
	}

	[Obsolete("Use ProcessCameraCommand with CullingResults to allow culling of VFX per camera")]
	public static void ProcessCameraCommand(Camera cam, CommandBuffer cmd, VFXCameraXRSettings camXRSettings)
	{
		Internal_ProcessCameraCommand(cam, cmd, camXRSettings, IntPtr.Zero, IntPtr.Zero);
	}

	public static void ProcessCameraCommand(Camera cam, CommandBuffer cmd, VFXCameraXRSettings camXRSettings, CullingResults results)
	{
		Internal_ProcessCameraCommand(cam, cmd, camXRSettings, results.ptr, IntPtr.Zero);
	}

	public static void ProcessCameraCommand(Camera cam, CommandBuffer cmd, VFXCameraXRSettings camXRSettings, CullingResults results, CullingResults customPassResults)
	{
		Internal_ProcessCameraCommand(cam, cmd, camXRSettings, results.ptr, customPassResults.ptr);
	}

	private static void Internal_ProcessCameraCommand([NotNull] Camera cam, CommandBuffer cmd, VFXCameraXRSettings camXRSettings, IntPtr cullResults, IntPtr customPassCullResults)
	{
		if ((object)cam == null)
		{
			ThrowHelper.ThrowArgumentNullException(cam, "cam");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(cam);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(cam, "cam");
		}
		Internal_ProcessCameraCommand_Injected(intPtr, (cmd == null) ? ((IntPtr)0) : CommandBuffer.BindingsMarshaller.ConvertToNative(cmd), ref camXRSettings, cullResults, customPassCullResults);
	}

	public static VFXCameraBufferTypes IsCameraBufferNeeded([NotNull] Camera cam)
	{
		if ((object)cam == null)
		{
			ThrowHelper.ThrowArgumentNullException(cam, "cam");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(cam);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(cam, "cam");
		}
		return IsCameraBufferNeeded_Injected(intPtr);
	}

	public static void SetCameraBuffer([NotNull] Camera cam, VFXCameraBufferTypes type, Texture buffer, int x, int y, int width, int height)
	{
		if ((object)cam == null)
		{
			ThrowHelper.ThrowArgumentNullException(cam, "cam");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(cam);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(cam, "cam");
		}
		SetCameraBuffer_Injected(intPtr, type, Object.MarshalledUnityObject.Marshal(buffer), x, y, width, height);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void SetRayTracingEnabled(bool enabled);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void RequestRtasAabbConstruction();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_runtimeResources_Injected();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_renderPipeSettingsPath_Injected(out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetBatchedEffectInfo_Injected(IntPtr vfx, out VFXBatchedEffectInfo ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetBatchedEffectInfos_Injected(List<VFXBatchedEffectInfo> infos);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetBatchInfo_Injected(IntPtr vfx, uint batchIndex, out VFXBatchInfo ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void PrepareCamera_Injected(IntPtr cam, [In] ref VFXCameraXRSettings camXRSettings);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_ProcessCameraCommand_Injected(IntPtr cam, IntPtr cmd, [In] ref VFXCameraXRSettings camXRSettings, IntPtr cullResults, IntPtr customPassCullResults);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern VFXCameraBufferTypes IsCameraBufferNeeded_Injected(IntPtr cam);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetCameraBuffer_Injected(IntPtr cam, VFXCameraBufferTypes type, IntPtr buffer, int x, int y, int width, int height);
}
