using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine;

[NativeHeader("UnityAnalyticsScriptingClasses.h")]
[NativeHeader("Modules/UnityAnalytics/RemoteSettings/RemoteSettings.h")]
public static class RemoteSettings
{
	public delegate void UpdatedEventHandler();

	public static event UpdatedEventHandler Updated;

	public static event Action BeforeFetchFromServer;

	public static event Action<bool, bool, int> Completed;

	[Preserve]
	[RequiredByNativeCode]
	internal static void RemoteSettingsUpdated(bool wasLastUpdatedFromServer)
	{
		RemoteSettings.Updated?.Invoke();
	}

	[Preserve]
	[RequiredByNativeCode]
	internal static void RemoteSettingsBeforeFetchFromServer()
	{
		RemoteSettings.BeforeFetchFromServer?.Invoke();
	}

	[Preserve]
	[RequiredByNativeCode]
	internal static void RemoteSettingsUpdateCompleted(bool wasLastUpdatedFromServer, bool settingsChanged, int response)
	{
		RemoteSettings.Completed?.Invoke(wasLastUpdatedFromServer, settingsChanged, response);
	}

	[Obsolete("Calling CallOnUpdate() is not necessary any more and should be removed. Use RemoteSettingsUpdated instead", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void CallOnUpdate()
	{
		throw new NotSupportedException("Calling CallOnUpdate() is not necessary any more and should be removed.");
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void ForceUpdate();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern bool WasLastUpdatedFromServer();

	[ExcludeFromDocs]
	public static int GetInt(string key)
	{
		return GetInt(key, 0);
	}

	public unsafe static int GetInt(string key, [UnityEngine.Internal.DefaultValue("0")] int defaultValue)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetInt_Injected(ref managedSpanWrapper, defaultValue);
				}
			}
			return GetInt_Injected(ref managedSpanWrapper, defaultValue);
		}
		finally
		{
		}
	}

	[ExcludeFromDocs]
	public static long GetLong(string key)
	{
		return GetLong(key, 0L);
	}

	public unsafe static long GetLong(string key, [UnityEngine.Internal.DefaultValue("0")] long defaultValue)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetLong_Injected(ref managedSpanWrapper, defaultValue);
				}
			}
			return GetLong_Injected(ref managedSpanWrapper, defaultValue);
		}
		finally
		{
		}
	}

	[ExcludeFromDocs]
	public static float GetFloat(string key)
	{
		return GetFloat(key, 0f);
	}

	public unsafe static float GetFloat(string key, [UnityEngine.Internal.DefaultValue("0.0F")] float defaultValue)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetFloat_Injected(ref managedSpanWrapper, defaultValue);
				}
			}
			return GetFloat_Injected(ref managedSpanWrapper, defaultValue);
		}
		finally
		{
		}
	}

	[ExcludeFromDocs]
	public static string GetString(string key)
	{
		return GetString(key, "");
	}

	public unsafe static string GetString(string key, [UnityEngine.Internal.DefaultValue("\"\"")] string defaultValue)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper key2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					key2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(defaultValue, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(defaultValue);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							GetString_Injected(ref key2, ref managedSpanWrapper2, out ret);
						}
					}
					else
					{
						GetString_Injected(ref key2, ref managedSpanWrapper2, out ret);
					}
				}
			}
			else
			{
				key2 = ref managedSpanWrapper;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(defaultValue, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(defaultValue);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						GetString_Injected(ref key2, ref managedSpanWrapper2, out ret);
					}
				}
				else
				{
					GetString_Injected(ref key2, ref managedSpanWrapper2, out ret);
				}
			}
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[ExcludeFromDocs]
	public static bool GetBool(string key)
	{
		return GetBool(key, defaultValue: false);
	}

	public unsafe static bool GetBool(string key, [UnityEngine.Internal.DefaultValue("false")] bool defaultValue)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetBool_Injected(ref managedSpanWrapper, defaultValue);
				}
			}
			return GetBool_Injected(ref managedSpanWrapper, defaultValue);
		}
		finally
		{
		}
	}

	public unsafe static bool HasKey(string key)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return HasKey_Injected(ref managedSpanWrapper);
				}
			}
			return HasKey_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern int GetCount();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] GetKeys();

	public static T GetObject<T>(string key = "")
	{
		return (T)GetObject(typeof(T), key);
	}

	public static object GetObject(Type type, string key = "")
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (type.IsAbstract || type.IsSubclassOf(typeof(Object)))
		{
			throw new ArgumentException("Cannot deserialize to new instances of type '" + type.Name + ".'");
		}
		return GetAsScriptingObject(type, null, key);
	}

	public static object GetObject(string key, object defaultValue)
	{
		if (defaultValue == null)
		{
			throw new ArgumentNullException("defaultValue");
		}
		Type type = defaultValue.GetType();
		if (type.IsAbstract || type.IsSubclassOf(typeof(Object)))
		{
			throw new ArgumentException("Cannot deserialize to new instances of type '" + type.Name + ".'");
		}
		return GetAsScriptingObject(type, defaultValue, key);
	}

	internal unsafe static object GetAsScriptingObject(Type t, object defaultValue, string key)
	{
		//The blocks IL_002b are reachable both inside and outside the pinned region starting at IL_001a. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetAsScriptingObject_Injected(t, defaultValue, ref managedSpanWrapper);
				}
			}
			return GetAsScriptingObject_Injected(t, defaultValue, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	public static IDictionary<string, object> GetDictionary(string key = "")
	{
		UseSafeLock();
		IDictionary<string, object> dictionary = RemoteConfigSettingsHelper.GetDictionary(GetSafeTopMap(), key);
		ReleaseSafeLock();
		return dictionary;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void UseSafeLock();

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void ReleaseSafeLock();

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern IntPtr GetSafeTopMap();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetInt_Injected(ref ManagedSpanWrapper key, [UnityEngine.Internal.DefaultValue("0")] int defaultValue);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern long GetLong_Injected(ref ManagedSpanWrapper key, [UnityEngine.Internal.DefaultValue("0")] long defaultValue);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetFloat_Injected(ref ManagedSpanWrapper key, [UnityEngine.Internal.DefaultValue("0.0F")] float defaultValue);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetString_Injected(ref ManagedSpanWrapper key, [UnityEngine.Internal.DefaultValue("\"\"")] ref ManagedSpanWrapper defaultValue, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetBool_Injected(ref ManagedSpanWrapper key, [UnityEngine.Internal.DefaultValue("false")] bool defaultValue);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasKey_Injected(ref ManagedSpanWrapper key);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern object GetAsScriptingObject_Injected(Type t, object defaultValue, ref ManagedSpanWrapper key);
}
