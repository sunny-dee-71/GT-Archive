using UnityEngine;

namespace Unity.XR.CoreUtils;

public abstract class ScriptableSettingsBase<T> : ScriptableSettingsBase where T : ScriptableObject
{
	protected static readonly bool HasCustomPath = typeof(T).IsDefined(typeof(ScriptableSettingsPathAttribute), inherit: true);

	protected static T BaseInstance;

	protected ScriptableSettingsBase()
	{
		if (BaseInstance != null)
		{
			XRLoggingUtils.LogWarning($"ScriptableSingleton {typeof(T)} already exists. This can happen if " + "there are two copies of the asset or if you query the singleton in a constructor.", BaseInstance);
		}
	}

	protected static void Save(string savePathFormat)
	{
	}

	protected static string GetFilePath()
	{
		return typeof(T).Name;
	}
}
