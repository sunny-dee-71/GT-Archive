using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Analytics;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/UnityAnalyticsCommon/Public/UnityAnalyticsCommon.h")]
[ExcludeFromDocs]
[NativeHeader("Modules/UnityAnalytics/RemoteSettings/RemoteSettings.h")]
[NativeHeader("UnityAnalyticsScriptingClasses.h")]
public class RemoteConfigSettings : IDisposable
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(RemoteConfigSettings remoteConfigSettings)
		{
			return remoteConfigSettings.m_Ptr;
		}
	}

	[NonSerialized]
	internal IntPtr m_Ptr;

	public event Action<bool> Updated;

	private RemoteConfigSettings()
	{
	}

	public RemoteConfigSettings(string configKey)
	{
		m_Ptr = Internal_Create(this, configKey);
		this.Updated = null;
	}

	~RemoteConfigSettings()
	{
		Destroy();
	}

	private void Destroy()
	{
		if (m_Ptr != IntPtr.Zero)
		{
			Internal_Destroy(m_Ptr);
			m_Ptr = IntPtr.Zero;
		}
	}

	public void Dispose()
	{
		Destroy();
		GC.SuppressFinalize(this);
	}

	internal unsafe static IntPtr Internal_Create([Unmarshalled] RemoteConfigSettings rcs, string configKey)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(configKey, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(configKey);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return Internal_Create_Injected(rcs, ref managedSpanWrapper);
				}
			}
			return Internal_Create_Injected(rcs, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[ThreadSafe]
	internal static extern void Internal_Destroy(IntPtr ptr);

	[RequiredByNativeCode]
	[Preserve]
	internal static void RemoteConfigSettingsUpdated(RemoteConfigSettings rcs, bool wasLastUpdatedFromServer)
	{
		rcs.Updated?.Invoke(wasLastUpdatedFromServer);
	}

	public unsafe static AnalyticsResult QueueConfig(string name, object param, int ver = 1, string prefix = "")
	{
		//The blocks IL_0029, IL_0038, IL_0046, IL_0054, IL_0059 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper name2;
			object param2;
			int ver2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					name2 = ref managedSpanWrapper;
					param2 = param;
					ver2 = ver;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							return QueueConfig_Injected(ref name2, param2, ver2, ref managedSpanWrapper2);
						}
					}
					return QueueConfig_Injected(ref name2, param2, ver2, ref managedSpanWrapper2);
				}
			}
			name2 = ref managedSpanWrapper;
			param2 = param;
			ver2 = ver;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					return QueueConfig_Injected(ref name2, param2, ver2, ref managedSpanWrapper2);
				}
			}
			return QueueConfig_Injected(ref name2, param2, ver2, ref managedSpanWrapper2);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern bool SendDeviceInfoInConfigRequest();

	public unsafe static void AddSessionTag(string tag)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(tag, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(tag);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					AddSessionTag_Injected(ref managedSpanWrapper);
					return;
				}
			}
			AddSessionTag_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	public void ForceUpdate()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ForceUpdate_Injected(intPtr);
	}

	public bool WasLastUpdatedFromServer()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return WasLastUpdatedFromServer_Injected(intPtr);
	}

	[ExcludeFromDocs]
	public int GetInt(string key)
	{
		return GetInt(key, 0);
	}

	public unsafe int GetInt(string key, [DefaultValue("0")] int defaultValue)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetInt_Injected(intPtr, ref managedSpanWrapper, defaultValue);
				}
			}
			return GetInt_Injected(intPtr, ref managedSpanWrapper, defaultValue);
		}
		finally
		{
		}
	}

	[ExcludeFromDocs]
	public long GetLong(string key)
	{
		return GetLong(key, 0L);
	}

	public unsafe long GetLong(string key, [DefaultValue("0")] long defaultValue)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetLong_Injected(intPtr, ref managedSpanWrapper, defaultValue);
				}
			}
			return GetLong_Injected(intPtr, ref managedSpanWrapper, defaultValue);
		}
		finally
		{
		}
	}

	[ExcludeFromDocs]
	public float GetFloat(string key)
	{
		return GetFloat(key, 0f);
	}

	public unsafe float GetFloat(string key, [DefaultValue("0.0F")] float defaultValue)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetFloat_Injected(intPtr, ref managedSpanWrapper, defaultValue);
				}
			}
			return GetFloat_Injected(intPtr, ref managedSpanWrapper, defaultValue);
		}
		finally
		{
		}
	}

	[ExcludeFromDocs]
	public string GetString(string key)
	{
		return GetString(key, "");
	}

	public unsafe string GetString(string key, [DefaultValue("\"\"")] string defaultValue)
	{
		//The blocks IL_0039, IL_0046, IL_0054, IL_0062, IL_0067 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0067 are reachable both inside and outside the pinned region starting at IL_0054. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0067 are reachable both inside and outside the pinned region starting at IL_0054. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
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
							GetString_Injected(intPtr, ref key2, ref managedSpanWrapper2, out ret);
						}
					}
					else
					{
						GetString_Injected(intPtr, ref key2, ref managedSpanWrapper2, out ret);
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
						GetString_Injected(intPtr, ref key2, ref managedSpanWrapper2, out ret);
					}
				}
				else
				{
					GetString_Injected(intPtr, ref key2, ref managedSpanWrapper2, out ret);
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
	public bool GetBool(string key)
	{
		return GetBool(key, defaultValue: false);
	}

	public unsafe bool GetBool(string key, [DefaultValue("false")] bool defaultValue)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetBool_Injected(intPtr, ref managedSpanWrapper, defaultValue);
				}
			}
			return GetBool_Injected(intPtr, ref managedSpanWrapper, defaultValue);
		}
		finally
		{
		}
	}

	public unsafe bool HasKey(string key)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return HasKey_Injected(intPtr, ref managedSpanWrapper);
				}
			}
			return HasKey_Injected(intPtr, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	public int GetCount()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetCount_Injected(intPtr);
	}

	public string[] GetKeys()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetKeys_Injected(intPtr);
	}

	public T GetObject<T>(string key = "")
	{
		return (T)GetObject(typeof(T), key);
	}

	public object GetObject(Type type, string key = "")
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

	public object GetObject(string key, object defaultValue)
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

	internal unsafe object GetAsScriptingObject(Type t, object defaultValue, string key)
	{
		//The blocks IL_003b are reachable both inside and outside the pinned region starting at IL_002a. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetAsScriptingObject_Injected(intPtr, t, defaultValue, ref managedSpanWrapper);
				}
			}
			return GetAsScriptingObject_Injected(intPtr, t, defaultValue, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	public IDictionary<string, object> GetDictionary(string key = "")
	{
		UseSafeLock();
		IDictionary<string, object> dictionary = RemoteConfigSettingsHelper.GetDictionary(GetSafeTopMap(), key);
		ReleaseSafeLock();
		return dictionary;
	}

	internal void UseSafeLock()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		UseSafeLock_Injected(intPtr);
	}

	internal void ReleaseSafeLock()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ReleaseSafeLock_Injected(intPtr);
	}

	internal IntPtr GetSafeTopMap()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetSafeTopMap_Injected(intPtr);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Internal_Create_Injected(RemoteConfigSettings rcs, ref ManagedSpanWrapper configKey);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult QueueConfig_Injected(ref ManagedSpanWrapper name, object param, int ver, ref ManagedSpanWrapper prefix);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void AddSessionTag_Injected(ref ManagedSpanWrapper tag);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ForceUpdate_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool WasLastUpdatedFromServer_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetInt_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, [DefaultValue("0")] int defaultValue);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern long GetLong_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, [DefaultValue("0")] long defaultValue);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetFloat_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, [DefaultValue("0.0F")] float defaultValue);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, [DefaultValue("\"\"")] ref ManagedSpanWrapper defaultValue, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetBool_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, [DefaultValue("false")] bool defaultValue);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasKey_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string[] GetKeys_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern object GetAsScriptingObject_Injected(IntPtr _unity_self, Type t, object defaultValue, ref ManagedSpanWrapper key);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void UseSafeLock_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReleaseSafeLock_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetSafeTopMap_Injected(IntPtr _unity_self);
}
