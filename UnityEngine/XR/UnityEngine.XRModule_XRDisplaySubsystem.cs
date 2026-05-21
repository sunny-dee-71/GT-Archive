using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

namespace UnityEngine.XR;

[NativeConditional("ENABLE_XR")]
[UsedByNativeCode]
[NativeType(Header = "Modules/XR/Subsystems/Display/XRDisplaySubsystem.h")]
[NativeHeader("Modules/XR/XRPrefix.h")]
public class XRDisplaySubsystem : IntegratedSubsystem<XRDisplaySubsystemDescriptor>
{
	[Flags]
	public enum FoveatedRenderingFlags
	{
		None = 0,
		GazeAllowed = 1
	}

	public enum LateLatchNode
	{
		Head,
		LeftHand,
		RightHand
	}

	[Flags]
	public enum TextureLayout
	{
		Texture2DArray = 1,
		SingleTexture2D = 2,
		SeparateTexture2Ds = 4
	}

	public enum ReprojectionMode
	{
		Unspecified,
		PositionAndOrientation,
		OrientationOnly,
		None
	}

	[NativeHeader("Modules/XR/Subsystems/Display/XRDisplaySubsystem.bindings.h")]
	public struct XRRenderParameter
	{
		public Matrix4x4 view;

		public Matrix4x4 projection;

		public Rect viewport;

		public Mesh occlusionMesh;

		public Mesh visibleMesh;

		public int textureArraySlice;

		public Matrix4x4 previousView;

		public bool isPreviousViewValid;
	}

	[NativeHeader("Runtime/Graphics/RenderTextureDesc.h")]
	[NativeHeader("Runtime/Graphics/CommandBuffer/RenderingCommandBuffer.h")]
	[NativeHeader("Modules/XR/Subsystems/Display/XRDisplaySubsystem.bindings.h")]
	public struct XRRenderPass
	{
		private IntPtr displaySubsystemInstance;

		public int renderPassIndex;

		public RenderTargetIdentifier renderTarget;

		public RenderTextureDescriptor renderTargetDesc;

		public int renderTargetScaledWidth;

		public int renderTargetScaledHeight;

		public bool hasMotionVectorPass;

		public RenderTargetIdentifier motionVectorRenderTarget;

		public RenderTextureDescriptor motionVectorRenderTargetDesc;

		public bool shouldFillOutDepth;

		public bool spaceWarpRightHandedNDC;

		public int cullingPassIndex;

		public IntPtr foveatedRenderingInfo;

		[NativeConditional("ENABLE_XR")]
		[NativeMethod(Name = "XRRenderPassScriptApi::GetRenderParameter", IsFreeFunction = true, HasExplicitThis = true, ThrowsException = true)]
		public void GetRenderParameter(Camera camera, int renderParameterIndex, out XRRenderParameter renderParameter)
		{
			GetRenderParameter_Injected(ref this, Object.MarshalledUnityObject.Marshal(camera), renderParameterIndex, out renderParameter);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeConditional("ENABLE_XR")]
		[NativeMethod(Name = "XRRenderPassScriptApi::GetRenderParameterCount", IsFreeFunction = true, HasExplicitThis = true)]
		public extern int GetRenderParameterCount();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetRenderParameter_Injected(ref XRRenderPass _unity_self, IntPtr camera, int renderParameterIndex, out XRRenderParameter renderParameter);
	}

	[NativeHeader("Runtime/Graphics/RenderTexture.h")]
	[NativeHeader("Modules/XR/Subsystems/Display/XRDisplaySubsystem.bindings.h")]
	public struct XRBlitParams
	{
		public RenderTexture srcTex;

		public int srcTexArraySlice;

		public Rect srcRect;

		public Rect destRect;

		public IntPtr foveatedRenderingInfo;

		public bool srcHdrEncoded;

		public ColorGamut srcHdrColorGamut;

		public int srcHdrMaxLuminance;
	}

	[NativeHeader("Modules/XR/Subsystems/Display/XRDisplaySubsystem.bindings.h")]
	public struct XRMirrorViewBlitDesc
	{
		private IntPtr displaySubsystemInstance;

		public bool nativeBlitAvailable;

		public bool nativeBlitInvalidStates;

		public int blitParamsCount;

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeConditional("ENABLE_XR")]
		[NativeMethod(Name = "XRMirrorViewBlitDescScriptApi::GetBlitParameter", IsFreeFunction = true, HasExplicitThis = true)]
		public extern void GetBlitParameter(int blitParameterIndex, out XRBlitParams blitParameter);
	}

	internal new static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(XRDisplaySubsystem xrDisplaySubsystem)
		{
			return xrDisplaySubsystem.m_Ptr;
		}
	}

	private HDROutputSettings m_HDROutputSettings;

	[Obsolete("singlePassRenderingDisabled{get;set;} is deprecated. Use textureLayout and supportedTextureLayouts instead.", false)]
	public bool singlePassRenderingDisabled
	{
		get
		{
			return (textureLayout & TextureLayout.Texture2DArray) == 0;
		}
		set
		{
			if (value)
			{
				textureLayout = TextureLayout.SeparateTexture2Ds;
			}
			else if ((supportedTextureLayouts & TextureLayout.Texture2DArray) > (TextureLayout)0)
			{
				textureLayout = TextureLayout.Texture2DArray;
			}
		}
	}

	public bool displayOpaque
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_displayOpaque_Injected(intPtr);
		}
	}

	public bool contentProtectionEnabled
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_contentProtectionEnabled_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_contentProtectionEnabled_Injected(intPtr, value);
		}
	}

	public float scaleOfAllViewports
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_scaleOfAllViewports_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_scaleOfAllViewports_Injected(intPtr, value);
		}
	}

	public float scaleOfAllRenderTargets
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_scaleOfAllRenderTargets_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_scaleOfAllRenderTargets_Injected(intPtr, value);
		}
	}

	public float globalDynamicScale
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_globalDynamicScale_Injected(intPtr);
		}
	}

	public float zNear
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_zNear_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_zNear_Injected(intPtr, value);
		}
	}

	public float zFar
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_zFar_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_zFar_Injected(intPtr, value);
		}
	}

	public bool sRGB
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_sRGB_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_sRGB_Injected(intPtr, value);
		}
	}

	public float occlusionMaskScale
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_occlusionMaskScale_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_occlusionMaskScale_Injected(intPtr, value);
		}
	}

	public float foveatedRenderingLevel
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_foveatedRenderingLevel_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_foveatedRenderingLevel_Injected(intPtr, value);
		}
	}

	public FoveatedRenderingFlags foveatedRenderingFlags
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_foveatedRenderingFlags_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_foveatedRenderingFlags_Injected(intPtr, value);
		}
	}

	public TextureLayout textureLayout
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_textureLayout_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_textureLayout_Injected(intPtr, value);
		}
	}

	public TextureLayout supportedTextureLayouts
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_supportedTextureLayouts_Injected(intPtr);
		}
	}

	public ReprojectionMode reprojectionMode
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_reprojectionMode_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_reprojectionMode_Injected(intPtr, value);
		}
	}

	public bool disableLegacyRenderer
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_disableLegacyRenderer_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_disableLegacyRenderer_Injected(intPtr, value);
		}
	}

	public HDROutputSettings hdrOutputSettings
	{
		get
		{
			if (m_HDROutputSettings == null)
			{
				m_HDROutputSettings = new HDROutputSettings(-1);
			}
			return m_HDROutputSettings;
		}
	}

	public event Action<bool> displayFocusChanged;

	[RequiredByNativeCode]
	private void InvokeDisplayFocusChanged(bool focus)
	{
		if (this.displayFocusChanged != null)
		{
			this.displayFocusChanged(focus);
		}
	}

	public void MarkTransformLateLatched(Transform transform, LateLatchNode nodeType)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		MarkTransformLateLatched_Injected(intPtr, Object.MarshalledUnityObject.Marshal(transform), nodeType);
	}

	public int ScaledTextureWidth(RenderTexture renderTexture)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return ScaledTextureWidth_Injected(intPtr, Object.MarshalledUnityObject.Marshal(renderTexture));
	}

	public int ScaledTextureHeight(RenderTexture renderTexture)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return ScaledTextureHeight_Injected(intPtr, Object.MarshalledUnityObject.Marshal(renderTexture));
	}

	public void SetFocusPlane(Vector3 point, Vector3 normal, Vector3 velocity)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetFocusPlane_Injected(intPtr, ref point, ref normal, ref velocity);
	}

	public void SetMSAALevel(int level)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetMSAALevel_Injected(intPtr, level);
	}

	public int GetRenderPassCount()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetRenderPassCount_Injected(intPtr);
	}

	public void GetRenderPass(int renderPassIndex, out XRRenderPass renderPass)
	{
		if (!Internal_TryGetRenderPass(renderPassIndex, out renderPass))
		{
			throw new IndexOutOfRangeException("renderPassIndex");
		}
	}

	[NativeMethod("TryGetRenderPass")]
	private bool Internal_TryGetRenderPass(int renderPassIndex, out XRRenderPass renderPass)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Internal_TryGetRenderPass_Injected(intPtr, renderPassIndex, out renderPass);
	}

	public void EndRecordingIfLateLatched(Camera camera)
	{
		if (!Internal_TryEndRecordingIfLateLatched(camera) && camera == null)
		{
			throw new ArgumentNullException("camera");
		}
	}

	[NativeMethod("TryEndRecordingIfLateLatched")]
	private bool Internal_TryEndRecordingIfLateLatched(Camera camera)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Internal_TryEndRecordingIfLateLatched_Injected(intPtr, Object.MarshalledUnityObject.Marshal(camera));
	}

	public void BeginRecordingIfLateLatched(Camera camera)
	{
		if (!Internal_TryBeginRecordingIfLateLatched(camera) && camera == null)
		{
			throw new ArgumentNullException("camera");
		}
	}

	[NativeMethod("TryBeginRecordingIfLateLatched")]
	private bool Internal_TryBeginRecordingIfLateLatched(Camera camera)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Internal_TryBeginRecordingIfLateLatched_Injected(intPtr, Object.MarshalledUnityObject.Marshal(camera));
	}

	public void GetCullingParameters(Camera camera, int cullingPassIndex, out ScriptableCullingParameters scriptableCullingParameters)
	{
		if (!Internal_TryGetCullingParams(camera, cullingPassIndex, out scriptableCullingParameters))
		{
			if (camera == null)
			{
				throw new ArgumentNullException("camera");
			}
			throw new IndexOutOfRangeException("cullingPassIndex");
		}
	}

	[NativeMethod("TryGetCullingParams")]
	[NativeHeader("Runtime/Graphics/ScriptableRenderLoop/ScriptableCulling.h")]
	private bool Internal_TryGetCullingParams(Camera camera, int cullingPassIndex, out ScriptableCullingParameters scriptableCullingParameters)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Internal_TryGetCullingParams_Injected(intPtr, Object.MarshalledUnityObject.Marshal(camera), cullingPassIndex, out scriptableCullingParameters);
	}

	[NativeMethod("TryGetAppGPUTimeLastFrame")]
	public bool TryGetAppGPUTimeLastFrame(out float gpuTimeLastFrame)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return TryGetAppGPUTimeLastFrame_Injected(intPtr, out gpuTimeLastFrame);
	}

	[NativeMethod("TryGetCompositorGPUTimeLastFrame")]
	public bool TryGetCompositorGPUTimeLastFrame(out float gpuTimeLastFrameCompositor)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return TryGetCompositorGPUTimeLastFrame_Injected(intPtr, out gpuTimeLastFrameCompositor);
	}

	[NativeMethod("TryGetDroppedFrameCount")]
	public bool TryGetDroppedFrameCount(out int droppedFrameCount)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return TryGetDroppedFrameCount_Injected(intPtr, out droppedFrameCount);
	}

	[NativeMethod("TryGetFramePresentCount")]
	public bool TryGetFramePresentCount(out int framePresentCount)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return TryGetFramePresentCount_Injected(intPtr, out framePresentCount);
	}

	[NativeMethod("TryGetDisplayRefreshRate")]
	public bool TryGetDisplayRefreshRate(out float displayRefreshRate)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return TryGetDisplayRefreshRate_Injected(intPtr, out displayRefreshRate);
	}

	[NativeMethod("TryGetMotionToPhoton")]
	public bool TryGetMotionToPhoton(out float motionToPhoton)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return TryGetMotionToPhoton_Injected(intPtr, out motionToPhoton);
	}

	[NativeMethod(Name = "UnityXRRenderTextureIdToRenderTexture", IsThreadSafe = false)]
	[NativeConditional("ENABLE_XR")]
	public RenderTexture GetRenderTexture(uint unityXrRenderTextureId)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<RenderTexture>(GetRenderTexture_Injected(intPtr, unityXrRenderTextureId));
	}

	[NativeMethod(Name = "GetTextureForRenderPass", IsThreadSafe = false)]
	[NativeConditional("ENABLE_XR")]
	public RenderTexture GetRenderTextureForRenderPass(int renderPass)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<RenderTexture>(GetRenderTextureForRenderPass_Injected(intPtr, renderPass));
	}

	[NativeConditional("ENABLE_XR")]
	[NativeMethod(Name = "GetSharedDepthTextureForRenderPass", IsThreadSafe = false)]
	public RenderTexture GetSharedDepthTextureForRenderPass(int renderPass)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<RenderTexture>(GetSharedDepthTextureForRenderPass_Injected(intPtr, renderPass));
	}

	[NativeConditional("ENABLE_XR")]
	[NativeMethod(Name = "GetPreferredMirrorViewBlitMode", IsThreadSafe = false)]
	public int GetPreferredMirrorBlitMode()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetPreferredMirrorBlitMode_Injected(intPtr);
	}

	[NativeConditional("ENABLE_XR")]
	[NativeMethod(Name = "SetPreferredMirrorViewBlitMode", IsThreadSafe = false)]
	public void SetPreferredMirrorBlitMode(int blitMode)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetPreferredMirrorBlitMode_Injected(intPtr, blitMode);
	}

	[Obsolete("GetMirrorViewBlitDesc(RenderTexture, out XRMirrorViewBlitDesc) is deprecated. Use GetMirrorViewBlitDesc(RenderTexture, out XRMirrorViewBlitDesc, int) instead.", false)]
	public bool GetMirrorViewBlitDesc(RenderTexture mirrorRt, out XRMirrorViewBlitDesc outDesc)
	{
		return GetMirrorViewBlitDesc(mirrorRt, out outDesc, -1);
	}

	[NativeConditional("ENABLE_XR")]
	[NativeMethod(Name = "QueryMirrorViewBlitDesc", IsThreadSafe = false)]
	public bool GetMirrorViewBlitDesc(RenderTexture mirrorRt, out XRMirrorViewBlitDesc outDesc, int mode)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetMirrorViewBlitDesc_Injected(intPtr, Object.MarshalledUnityObject.Marshal(mirrorRt), out outDesc, mode);
	}

	[Obsolete("AddGraphicsThreadMirrorViewBlit(CommandBuffer, bool) is deprecated. Use AddGraphicsThreadMirrorViewBlit(CommandBuffer, bool, int) instead.", false)]
	public bool AddGraphicsThreadMirrorViewBlit(CommandBuffer cmd, bool allowGraphicsStateInvalidate)
	{
		return AddGraphicsThreadMirrorViewBlit(cmd, allowGraphicsStateInvalidate, -1);
	}

	[NativeHeader("Runtime/Graphics/CommandBuffer/RenderingCommandBuffer.h")]
	[NativeConditional("ENABLE_XR")]
	[NativeMethod(Name = "AddGraphicsThreadMirrorViewBlit", IsThreadSafe = false)]
	public bool AddGraphicsThreadMirrorViewBlit(CommandBuffer cmd, bool allowGraphicsStateInvalidate, int mode)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return AddGraphicsThreadMirrorViewBlit_Injected(intPtr, (cmd == null) ? ((IntPtr)0) : CommandBuffer.BindingsMarshaller.ConvertToNative(cmd), allowGraphicsStateInvalidate, mode);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_displayOpaque_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_contentProtectionEnabled_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_contentProtectionEnabled_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_scaleOfAllViewports_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_scaleOfAllViewports_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_scaleOfAllRenderTargets_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_scaleOfAllRenderTargets_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_globalDynamicScale_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_zNear_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_zNear_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_zFar_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_zFar_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_sRGB_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_sRGB_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_occlusionMaskScale_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_occlusionMaskScale_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_foveatedRenderingLevel_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_foveatedRenderingLevel_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern FoveatedRenderingFlags get_foveatedRenderingFlags_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_foveatedRenderingFlags_Injected(IntPtr _unity_self, FoveatedRenderingFlags value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void MarkTransformLateLatched_Injected(IntPtr _unity_self, IntPtr transform, LateLatchNode nodeType);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern TextureLayout get_textureLayout_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_textureLayout_Injected(IntPtr _unity_self, TextureLayout value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern TextureLayout get_supportedTextureLayouts_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int ScaledTextureWidth_Injected(IntPtr _unity_self, IntPtr renderTexture);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int ScaledTextureHeight_Injected(IntPtr _unity_self, IntPtr renderTexture);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern ReprojectionMode get_reprojectionMode_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_reprojectionMode_Injected(IntPtr _unity_self, ReprojectionMode value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetFocusPlane_Injected(IntPtr _unity_self, [In] ref Vector3 point, [In] ref Vector3 normal, [In] ref Vector3 velocity);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetMSAALevel_Injected(IntPtr _unity_self, int level);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_disableLegacyRenderer_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_disableLegacyRenderer_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetRenderPassCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool Internal_TryGetRenderPass_Injected(IntPtr _unity_self, int renderPassIndex, out XRRenderPass renderPass);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool Internal_TryEndRecordingIfLateLatched_Injected(IntPtr _unity_self, IntPtr camera);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool Internal_TryBeginRecordingIfLateLatched_Injected(IntPtr _unity_self, IntPtr camera);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool Internal_TryGetCullingParams_Injected(IntPtr _unity_self, IntPtr camera, int cullingPassIndex, out ScriptableCullingParameters scriptableCullingParameters);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetAppGPUTimeLastFrame_Injected(IntPtr _unity_self, out float gpuTimeLastFrame);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetCompositorGPUTimeLastFrame_Injected(IntPtr _unity_self, out float gpuTimeLastFrameCompositor);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetDroppedFrameCount_Injected(IntPtr _unity_self, out int droppedFrameCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetFramePresentCount_Injected(IntPtr _unity_self, out int framePresentCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetDisplayRefreshRate_Injected(IntPtr _unity_self, out float displayRefreshRate);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetMotionToPhoton_Injected(IntPtr _unity_self, out float motionToPhoton);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetRenderTexture_Injected(IntPtr _unity_self, uint unityXrRenderTextureId);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetRenderTextureForRenderPass_Injected(IntPtr _unity_self, int renderPass);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetSharedDepthTextureForRenderPass_Injected(IntPtr _unity_self, int renderPass);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetPreferredMirrorBlitMode_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetPreferredMirrorBlitMode_Injected(IntPtr _unity_self, int blitMode);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetMirrorViewBlitDesc_Injected(IntPtr _unity_self, IntPtr mirrorRt, out XRMirrorViewBlitDesc outDesc, int mode);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool AddGraphicsThreadMirrorViewBlit_Injected(IntPtr _unity_self, IntPtr cmd, bool allowGraphicsStateInvalidate, int mode);
}
