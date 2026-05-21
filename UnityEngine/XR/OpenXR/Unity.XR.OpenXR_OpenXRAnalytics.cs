using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine.Analytics;
using UnityEngine.XR.OpenXR.Features;

namespace UnityEngine.XR.OpenXR;

internal static class OpenXRAnalytics
{
	[Serializable]
	private struct InitializeEvent : IAnalytic.IData
	{
		public bool success;

		public string runtime;

		public string runtime_version;

		public string plugin_version;

		public string api_version;

		public string[] available_extensions;

		public string[] enabled_extensions;

		public string[] enabled_features;

		public string[] failed_features;
	}

	[AnalyticInfo("openxr_initialize", "unity.openxr", 1, 1000, 1000)]
	private class XrInitializeAnalytic : IAnalytic
	{
		private InitializeEvent? data;

		public XrInitializeAnalytic(InitializeEvent data)
		{
			this.data = data;
		}

		public bool TryGatherData(out IAnalytic.IData data, [NotNullWhen(false)] out Exception error)
		{
			error = null;
			data = this.data;
			return data != null;
		}
	}

	private const int kMaxEventsPerHour = 1000;

	private const int kMaxNumberOfElements = 1000;

	private const string kVendorKey = "unity.openxr";

	private const string kEventInitialize = "openxr_initialize";

	private static bool s_Initialized;

	private static bool Initialize()
	{
		if (s_Initialized)
		{
			return true;
		}
		if (UnityEngine.Analytics.Analytics.RegisterEvent("openxr_initialize", 1000, 1000, "unity.openxr") != AnalyticsResult.Ok)
		{
			return false;
		}
		s_Initialized = true;
		return true;
	}

	public static void SendInitializeEvent(bool success)
	{
		if (s_Initialized || Initialize())
		{
			SendPlayerAnalytics(CreateInitializeEvent(success));
		}
	}

	private static InitializeEvent CreateInitializeEvent(bool success)
	{
		return new InitializeEvent
		{
			success = success,
			runtime = OpenXRRuntime.name,
			runtime_version = OpenXRRuntime.version,
			plugin_version = OpenXRRuntime.pluginVersion,
			api_version = OpenXRRuntime.apiVersion,
			enabled_extensions = (from ext in OpenXRRuntime.GetEnabledExtensions()
				select $"{ext}_{OpenXRRuntime.GetExtensionVersion(ext)}").ToArray(),
			available_extensions = (from ext in OpenXRRuntime.GetAvailableExtensions()
				select $"{ext}_{OpenXRRuntime.GetExtensionVersion(ext)}").ToArray(),
			enabled_features = (from f in OpenXRSettings.Instance.features
				where f != null && f.enabled
				select f.GetType().FullName + "_" + f.version).ToArray(),
			failed_features = (from f in OpenXRSettings.Instance.features
				where f != null && f.failedInitialization
				select f.GetType().FullName + "_" + f.version).ToArray()
		};
	}

	private static void SendPlayerAnalytics(InitializeEvent data)
	{
		UnityEngine.Analytics.Analytics.SendEvent("openxr_initialize", data);
	}
}
