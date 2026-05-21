#define DEBUG
#define TRACE
using System;
using UnityEngine;

namespace Fusion;

public abstract class FusionGlobalScriptableObject<T> : FusionGlobalScriptableObject where T : FusionGlobalScriptableObject<T>
{
	private static T s_instance;

	private static FusionGlobalScriptableObjectUnloadDelegate s_unloadHandler;

	public bool IsGlobal { get; private set; }

	private static string LogPrefix => "[Global " + typeof(T).Name + "]: ";

	protected static T GlobalInternal
	{
		get
		{
			T orLoadGlobalInstance = GetOrLoadGlobalInstance();
			if ((object)orLoadGlobalInstance == null)
			{
				throw new InvalidOperationException("Failed to load " + typeof(T).Name + ". If this happens in edit mode, make sure Fusion is properly installed in the Fusion HUB. Otherwise, if the default path does not exist or does not point to a Resource, you need to use FusionGlobalScriptableObjectAttribute attribute to point to a method that will perform the loading.");
			}
			return orLoadGlobalInstance;
		}
		set
		{
			if (!(value == s_instance))
			{
				SetGlobalInternal(value, null);
			}
		}
	}

	protected static bool IsGlobalLoadedInternal => s_instance != null;

	protected virtual void OnLoadedAsGlobal()
	{
	}

	protected virtual void OnUnloadedAsGlobal(bool destroyed)
	{
	}

	private static string AsId(FusionGlobalScriptableObject<T> obj)
	{
		return obj ? $"[IID:{obj.GetInstanceID()}]" : "null";
	}

	protected virtual void OnDisable()
	{
		if (!IsGlobal)
		{
			InternalLogStreams.LogTrace?.Log(LogPrefix + "OnDisable called for " + AsId(this) + ", but is not global");
			return;
		}
		if (s_unloadHandler != null)
		{
			InternalLogStreams.LogTrace?.Log(LogPrefix + "OnDisable called for " + AsId(this) + ", setting global instance to null. The unload handler is still set, not going to be used.");
		}
		else
		{
			InternalLogStreams.LogTrace?.Log(LogPrefix + "OnDisable called for " + AsId(this) + ", setting global instance to null.");
		}
		Assert.Check((object)this == s_instance, "Expected this to be the global instance");
		s_instance = null;
		s_unloadHandler = null;
		IsGlobal = false;
		OnUnloadedAsGlobal(destroyed: true);
	}

	protected static bool TryGetGlobalInternal(out T global)
	{
		T orLoadGlobalInstance = GetOrLoadGlobalInstance();
		if ((object)orLoadGlobalInstance == null)
		{
			global = null;
			return false;
		}
		global = orLoadGlobalInstance;
		return true;
	}

	protected static bool UnloadGlobalInternal()
	{
		T val = s_instance;
		if (!val)
		{
			return false;
		}
		Assert.Check(val.IsGlobal);
		try
		{
			if (s_unloadHandler != null)
			{
				InternalLogStreams.LogTrace?.Log(LogPrefix + " Unloading global instance " + AsId(val) + " with unloader");
				FusionGlobalScriptableObjectUnloadDelegate fusionGlobalScriptableObjectUnloadDelegate = s_unloadHandler;
				s_unloadHandler = null;
				fusionGlobalScriptableObjectUnloadDelegate(val);
			}
			else
			{
				InternalLogStreams.LogTrace?.Log(LogPrefix + " Instance " + AsId(val) + " has no unloader, simply nulling it out");
			}
		}
		finally
		{
			s_instance = null;
			if (val.IsGlobal)
			{
				val.IsGlobal = false;
				val.OnUnloadedAsGlobal(destroyed: false);
			}
		}
		return true;
	}

	private static T GetOrLoadGlobalInstance()
	{
		if ((bool)s_instance)
		{
			return s_instance;
		}
		T val = null;
		FusionGlobalScriptableObjectUnloadDelegate unloadHandler = null;
		val = LoadPlayerInstance(out unloadHandler);
		if ((bool)val)
		{
			SetGlobalInternal(val, unloadHandler);
		}
		return val;
	}

	private static T LoadPlayerInstance(out FusionGlobalScriptableObjectUnloadDelegate unloadHandler)
	{
		FusionGlobalScriptableObjectSourceAttribute[] sourceAttributes = FusionGlobalScriptableObject.SourceAttributes;
		foreach (FusionGlobalScriptableObjectSourceAttribute fusionGlobalScriptableObjectSourceAttribute in sourceAttributes)
		{
			if ((!Application.isEditor || Application.isPlaying || fusionGlobalScriptableObjectSourceAttribute.AllowEditMode) && (!(fusionGlobalScriptableObjectSourceAttribute.ObjectType != typeof(T)) || typeof(T).IsSubclassOf(fusionGlobalScriptableObjectSourceAttribute.ObjectType)))
			{
				FusionGlobalScriptableObjectLoadResult fusionGlobalScriptableObjectLoadResult = fusionGlobalScriptableObjectSourceAttribute.Load(typeof(T));
				if ((bool)fusionGlobalScriptableObjectLoadResult.Object)
				{
					T val = (T)fusionGlobalScriptableObjectLoadResult.Object;
					unloadHandler = fusionGlobalScriptableObjectLoadResult.Unloader;
					InternalLogStreams.LogTrace?.Log($"{LogPrefix} Loader {fusionGlobalScriptableObjectSourceAttribute} was used to load {AsId(val)}, has unloader: {unloadHandler != null}");
					return val;
				}
				if (!fusionGlobalScriptableObjectSourceAttribute.AllowFallback)
				{
					break;
				}
			}
		}
		InternalLogStreams.LogTrace?.Log(LogPrefix + " No source attribute was able to load the global instance");
		unloadHandler = null;
		return null;
	}

	private static void SetGlobalInternal(T value, FusionGlobalScriptableObjectUnloadDelegate unloadHandler)
	{
		if ((bool)s_instance)
		{
			throw new InvalidOperationException("Failed to set " + typeof(T).Name + " as global. A global instance is already loaded - it needs to be unloaded first");
		}
		Assert.Check(value, "Expected value to be non-null");
		if ((object)s_instance == null)
		{
			Assert.Check(s_unloadHandler == null, "Expected unload handler to be null");
		}
		if ((bool)value)
		{
			s_instance = value;
			s_unloadHandler = unloadHandler;
			s_instance.IsGlobal = true;
			s_instance.OnLoadedAsGlobal();
		}
	}
}
