using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Analytics;

[Preserve]
[NativeHeader("Modules/UnityAnalytics/Public/UnityAnalytics.h")]
[NativeHeader("UnityAnalyticsScriptingClasses.h")]
[RequiredByNativeCode]
public static class AnalyticsSessionInfo
{
	public delegate void SessionStateChanged(AnalyticsSessionState sessionState, long sessionId, long sessionElapsedTime, bool sessionChanged);

	public delegate void IdentityTokenChanged(string token);

	public static extern AnalyticsSessionState sessionState
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("GetPlayerSessionState")]
		get;
	}

	public static extern long sessionId
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("GetPlayerSessionId")]
		get;
	}

	public static extern long sessionCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("GetPlayerSessionCount")]
		get;
	}

	public static extern long sessionElapsedTime
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("GetPlayerSessionElapsedTime")]
		get;
	}

	public static extern bool sessionFirstRun
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("GetPlayerSessionFirstRun", false, true)]
		get;
	}

	public static string userId
	{
		[NativeMethod("GetUserId")]
		get
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				get_userId_Injected(out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}
	}

	public static string customUserId
	{
		get
		{
			if (!Analytics.IsInitialized())
			{
				return null;
			}
			return customUserIdInternal;
		}
		set
		{
			if (Analytics.IsInitialized())
			{
				customUserIdInternal = value;
			}
		}
	}

	public static string customDeviceId
	{
		get
		{
			if (!Analytics.IsInitialized())
			{
				return null;
			}
			return customDeviceIdInternal;
		}
		set
		{
			if (Analytics.IsInitialized())
			{
				customDeviceIdInternal = value;
			}
		}
	}

	public static string identityToken
	{
		get
		{
			if (!Analytics.IsInitialized())
			{
				return null;
			}
			return identityTokenInternal;
		}
	}

	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	private static string identityTokenInternal
	{
		[NativeMethod("GetIdentityToken")]
		get
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				get_identityTokenInternal_Injected(out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}
	}

	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	private unsafe static string customUserIdInternal
	{
		[NativeMethod("GetCustomUserId")]
		get
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				get_customUserIdInternal_Injected(out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}
		[NativeMethod("SetCustomUserId")]
		set
		{
			//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(value);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						set_customUserIdInternal_Injected(ref managedSpanWrapper);
						return;
					}
				}
				set_customUserIdInternal_Injected(ref managedSpanWrapper);
			}
			finally
			{
			}
		}
	}

	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	private unsafe static string customDeviceIdInternal
	{
		[NativeMethod("GetCustomDeviceId")]
		get
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				get_customDeviceIdInternal_Injected(out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}
		[NativeMethod("SetCustomDeviceId")]
		set
		{
			//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(value);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						set_customDeviceIdInternal_Injected(ref managedSpanWrapper);
						return;
					}
				}
				set_customDeviceIdInternal_Injected(ref managedSpanWrapper);
			}
			finally
			{
			}
		}
	}

	public static event SessionStateChanged sessionStateChanged;

	public static event IdentityTokenChanged identityTokenChanged;

	[RequiredByNativeCode]
	[Preserve]
	internal static void CallSessionStateChanged(AnalyticsSessionState sessionState, long sessionId, long sessionElapsedTime, bool sessionChanged)
	{
		AnalyticsSessionInfo.sessionStateChanged?.Invoke(sessionState, sessionId, sessionElapsedTime, sessionChanged);
	}

	[RequiredByNativeCode]
	[Preserve]
	internal static void CallIdentityTokenChanged(string token)
	{
		AnalyticsSessionInfo.identityTokenChanged?.Invoke(token);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_userId_Injected(out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_identityTokenInternal_Injected(out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_customUserIdInternal_Injected(out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_customUserIdInternal_Injected(ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_customDeviceIdInternal_Injected(out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_customDeviceIdInternal_Injected(ref ManagedSpanWrapper value);
}
