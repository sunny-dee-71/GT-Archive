using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.Rendering;

namespace UnityEngine.AMD;

public class GraphicsDevice
{
	private static GraphicsDevice sGraphicsDeviceInstance;

	private Stack<FSR2Context> s_ContextObjectPool = new Stack<FSR2Context>();

	public static GraphicsDevice device => sGraphicsDeviceInstance;

	public static uint version => AMDUP_GetDeviceVersion();

	private GraphicsDevice()
	{
	}

	private bool Initialize()
	{
		return AMDUP_InitApi();
	}

	private void Shutdown()
	{
		AMDUP_ShutdownApi();
	}

	~GraphicsDevice()
	{
		Shutdown();
	}

	private void InsertEventCall(CommandBuffer cmd, PluginEvent pluginEvent, IntPtr ptr)
	{
		cmd.IssuePluginEventAndData(AMDUP_GetRenderEventCallback(), (int)(pluginEvent + AMDUP_GetBaseEventId()), ptr);
	}

	private static GraphicsDevice InternalCreate()
	{
		if (sGraphicsDeviceInstance != null)
		{
			sGraphicsDeviceInstance.Shutdown();
			sGraphicsDeviceInstance.Initialize();
			return sGraphicsDeviceInstance;
		}
		GraphicsDevice graphicsDevice = new GraphicsDevice();
		if (graphicsDevice.Initialize())
		{
			sGraphicsDeviceInstance = graphicsDevice;
			return graphicsDevice;
		}
		Debug.LogWarning("Unity has an invalid api for dvice. Init failed[");
		return null;
	}

	private static int CreateSetTextureUserData(int featureId, int textureSlot, bool clearTextureTable)
	{
		int num = featureId & 0xFFFF;
		int num2 = textureSlot & 0x7FFF;
		int num3 = (clearTextureTable ? 1 : 0);
		return (num << 16) | (num2 << 1) | num3;
	}

	private void SetTexture(CommandBuffer cmd, FSR2Context fsr2Context, FSR2CommandExecutionData.Textures textureSlot, Texture texture, bool clearTextureTable = false)
	{
		if (!(texture == null))
		{
			uint userData = (uint)CreateSetTextureUserData((int)fsr2Context.featureSlot, (int)textureSlot, clearTextureTable);
			cmd.IssuePluginCustomTextureUpdateV2(AMDUP_GetSetTextureEventCallback(), texture, userData);
		}
	}

	public static GraphicsDevice CreateGraphicsDevice()
	{
		return InternalCreate();
	}

	public FSR2Context CreateFeature(CommandBuffer cmd, in FSR2CommandInitializationData initSettings)
	{
		FSR2Context fSR2Context = null;
		fSR2Context = ((s_ContextObjectPool.Count != 0) ? s_ContextObjectPool.Pop() : new FSR2Context());
		fSR2Context.Init(initSettings, AMDUP_CreateFeatureSlot());
		InsertEventCall(cmd, PluginEvent.FSR2Init, fSR2Context.GetInitCmdPtr());
		return fSR2Context;
	}

	public bool GetRenderResolutionFromQualityMode(FSR2Quality qualityMode, uint displayWidth, uint displayHeight, out uint renderWidth, out uint renderHeight)
	{
		return AMDUP_GetRenderResolutionFromQualityMode(qualityMode, displayWidth, displayHeight, out renderWidth, out renderHeight);
	}

	public float GetUpscaleRatioFromQualityMode(FSR2Quality qualityMode)
	{
		return AMDUP_GetUpscaleRatioFromQualityMode(qualityMode);
	}

	public void DestroyFeature(CommandBuffer cmd, FSR2Context fsrContext)
	{
		InsertEventCall(cmd, PluginEvent.DestroyFeature, new IntPtr(fsrContext.featureSlot));
		fsrContext.Reset();
		s_ContextObjectPool.Push(fsrContext);
	}

	public void ExecuteFSR2(CommandBuffer cmd, FSR2Context fsr2Context, in FSR2TextureTable textures)
	{
		SetTexture(cmd, fsr2Context, FSR2CommandExecutionData.Textures.ColorInput, textures.colorInput, clearTextureTable: true);
		SetTexture(cmd, fsr2Context, FSR2CommandExecutionData.Textures.ColorOutput, textures.colorOutput);
		SetTexture(cmd, fsr2Context, FSR2CommandExecutionData.Textures.Depth, textures.depth);
		SetTexture(cmd, fsr2Context, FSR2CommandExecutionData.Textures.MotionVectors, textures.motionVectors);
		SetTexture(cmd, fsr2Context, FSR2CommandExecutionData.Textures.TransparencyMask, textures.transparencyMask);
		SetTexture(cmd, fsr2Context, FSR2CommandExecutionData.Textures.ExposureTexture, textures.exposureTexture);
		SetTexture(cmd, fsr2Context, FSR2CommandExecutionData.Textures.BiasColorMask, textures.biasColorMask);
		InsertEventCall(cmd, PluginEvent.FSR2Execute, fsr2Context.GetExecuteCmdPtr());
		InsertEventCall(cmd, PluginEvent.FSR2PostExecute, fsr2Context.GetExecuteCmdPtr());
	}

	[DllImport("AMDUnityPlugin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private static extern bool AMDUP_InitApi();

	[DllImport("AMDUnityPlugin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private static extern void AMDUP_ShutdownApi();

	[DllImport("AMDUnityPlugin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private static extern uint AMDUP_GetDeviceVersion();

	[DllImport("AMDUnityPlugin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private static extern IntPtr AMDUP_GetRenderEventCallback();

	[DllImport("AMDUnityPlugin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private static extern IntPtr AMDUP_GetSetTextureEventCallback();

	[DllImport("AMDUnityPlugin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private static extern uint AMDUP_CreateFeatureSlot();

	[DllImport("AMDUnityPlugin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private static extern bool AMDUP_GetRenderResolutionFromQualityMode(FSR2Quality qualityMode, uint displayWidth, uint displayHeight, out uint renderWidth, out uint renderHeight);

	[DllImport("AMDUnityPlugin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private static extern float AMDUP_GetUpscaleRatioFromQualityMode(FSR2Quality qualityMode);

	[DllImport("AMDUnityPlugin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private static extern int AMDUP_GetBaseEventId();
}
