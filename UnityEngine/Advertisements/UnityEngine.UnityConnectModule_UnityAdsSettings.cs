using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Advertisements;

[NativeHeader("Modules/UnityConnect/UnityAds/UnityAdsSettings.h")]
internal static class UnityAdsSettings
{
	[StaticAccessor("GetUnityAdsSettings()", StaticAccessorType.Dot)]
	public static extern bool enabled
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		set;
	}

	[StaticAccessor("GetUnityAdsSettings()", StaticAccessorType.Dot)]
	public static extern bool initializeOnStartup
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetUnityAdsSettings()", StaticAccessorType.Dot)]
	public static extern bool testMode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[Obsolete("warning No longer supported and will always return true")]
	public static bool IsPlatformEnabled(RuntimePlatform platform)
	{
		return true;
	}

	[Obsolete("warning No longer supported and will do nothing")]
	public static void SetPlatformEnabled(RuntimePlatform platform, bool value)
	{
	}

	[StaticAccessor("GetUnityAdsSettings()", StaticAccessorType.Dot)]
	public static string GetGameId(RuntimePlatform platform)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			GetGameId_Injected(platform, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[StaticAccessor("GetUnityAdsSettings()", StaticAccessorType.Dot)]
	public unsafe static void SetGameId(RuntimePlatform platform, string gameId)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(gameId, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(gameId);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					SetGameId_Injected(platform, ref managedSpanWrapper);
					return;
				}
			}
			SetGameId_Injected(platform, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetGameId_Injected(RuntimePlatform platform, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetGameId_Injected(RuntimePlatform platform, ref ManagedSpanWrapper gameId);
}
