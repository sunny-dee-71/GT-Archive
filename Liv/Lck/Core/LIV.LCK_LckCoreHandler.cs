using System.Collections.Generic;
using Liv.Lck.Settings;
using UnityEngine;
using UnityEngine.Rendering;

namespace Liv.Lck.Core;

public static class LckCoreHandler
{
	internal static Result<bool> LckCoreInitializationResult { get; private set; }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	private static void Initialize()
	{
		InitializeInternal();
	}

	private static void InitializeInternal()
	{
		LckSettings instance = LckSettings.Instance;
		LckCore.SetMaxLogLevel(instance.CoreLogLevel);
		if (instance.CoreLogLevel == LevelFilter.Info)
		{
			Debug.Log("LCK Core Handler initializing...");
		}
		IReadOnlyCollection<InteractionSystemDetector.InteractionSystem> availableInteractionSystems = InteractionSystemDetector.GetAvailableInteractionSystems();
		string interactionSystems = ((availableInteractionSystems.Count == 0) ? "Unknown" : string.Join(";", availableInteractionSystems));
		GameInfo gameInfo = new GameInfo
		{
			GameName = instance.GameName,
			GameVersion = Application.version,
			ProjectName = Application.productName,
			CompanyName = Application.companyName,
			EngineVersion = Application.unityVersion,
			RenderPipeline = GetRenderPipelineType(),
			GraphicsAPI = SystemInfo.graphicsDeviceType.ToString(),
			Platform = Application.platform.ToString(),
			PersistentDataPath = Application.persistentDataPath,
			InteractionSystems = interactionSystems
		};
		LckInfo lckInfo = new LckInfo
		{
			Version = "1.4.6",
			BuildNumber = -1
		};
		LckCoreInitializationResult = LckCore.Initialize(instance.TrackingId, gameInfo, lckInfo);
		if (!LckCoreInitializationResult.IsOk)
		{
			if (LckCoreInitializationResult.Err == CoreError.MissingTrackingId || LckCoreInitializationResult.Err == CoreError.InvalidTrackingId)
			{
				Debug.LogError("LCK: Missing or bad Tracking ID supplied. Recording and streaming will not be available.");
			}
			else
			{
				Debug.LogError($"LCK: LCK Core initialization failed: {LckCoreInitializationResult.Err} - {LckCoreInitializationResult.Message}");
			}
		}
		else
		{
			LckLog.OnLckCoreInitialized();
		}
	}

	private static string GetRenderPipelineType()
	{
		if ((bool)GraphicsSettings.defaultRenderPipeline)
		{
			if (GraphicsSettings.defaultRenderPipeline.GetType().ToString().Contains("HDRenderPipelineAsset"))
			{
				return "High Definition render pipeline";
			}
			if (GraphicsSettings.defaultRenderPipeline.GetType().ToString().Contains("UniversalRenderPipelineAsset"))
			{
				return "Universal render pipeline";
			}
			return "Custom render pipeline";
		}
		return "Built-in render pipeline";
	}
}
