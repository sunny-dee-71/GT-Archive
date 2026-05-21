using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine.Analytics;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/UnityAnalytics/Public/UnityAnalytics.h")]
[NativeHeader("Modules/UnityAnalytics/Public/Events/UserCustomEvent.h")]
[NativeHeader("Modules/UnityAnalyticsCommon/Public/UnityAnalyticsCommon.h")]
[NativeHeader("Modules/UnityConnect/UnityConnectSettings.h")]
public static class Analytics
{
	public static bool initializeOnStartup
	{
		get
		{
			if (!IsInitialized())
			{
				return false;
			}
			return initializeOnStartupInternal;
		}
		set
		{
			if (IsInitialized())
			{
				initializeOnStartupInternal = value;
			}
		}
	}

	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	private static extern bool initializeOnStartupInternal
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("GetInitializeOnStartup")]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("SetInitializeOnStartup")]
		set;
	}

	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	private static extern bool enabledInternal
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("GetEnabled")]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("SetEnabled")]
		set;
	}

	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	private static extern bool playerOptedOutInternal
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("GetPlayerOptedOut")]
		get;
	}

	[StaticAccessor("GetUnityConnectSettings()", StaticAccessorType.Dot)]
	private static string eventUrlInternal
	{
		[NativeMethod("GetEventUrl")]
		get
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				get_eventUrlInternal_Injected(out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}
	}

	[StaticAccessor("GetUnityConnectSettings()", StaticAccessorType.Dot)]
	private static string configUrlInternal
	{
		[NativeMethod("GetConfigUrl")]
		get
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				get_configUrlInternal_Injected(out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}
	}

	[StaticAccessor("GetUnityConnectSettings()", StaticAccessorType.Dot)]
	private static string dashboardUrlInternal
	{
		[NativeMethod("GetDashboardUrl")]
		get
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				get_dashboardUrlInternal_Injected(out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}
	}

	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	private static extern bool limitUserTrackingInternal
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("GetLimitUserTracking")]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("SetLimitUserTracking")]
		set;
	}

	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	private static extern bool deviceStatsEnabledInternal
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("GetDeviceStatsEnabled")]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("SetDeviceStatsEnabled")]
		set;
	}

	public static bool playerOptedOut
	{
		get
		{
			if (!IsInitialized())
			{
				return false;
			}
			return playerOptedOutInternal;
		}
	}

	public static string eventUrl
	{
		get
		{
			if (!IsInitialized())
			{
				return string.Empty;
			}
			return eventUrlInternal;
		}
	}

	public static string dashboardUrl
	{
		get
		{
			if (!IsInitialized())
			{
				return string.Empty;
			}
			return dashboardUrlInternal;
		}
	}

	public static string configUrl
	{
		get
		{
			if (!IsInitialized())
			{
				return string.Empty;
			}
			return configUrlInternal;
		}
	}

	public static bool limitUserTracking
	{
		get
		{
			if (!IsInitialized())
			{
				return false;
			}
			return limitUserTrackingInternal;
		}
		set
		{
			if (IsInitialized())
			{
				limitUserTrackingInternal = value;
			}
		}
	}

	public static bool deviceStatsEnabled
	{
		get
		{
			if (!IsInitialized())
			{
				return false;
			}
			return deviceStatsEnabledInternal;
		}
		set
		{
			if (IsInitialized())
			{
				deviceStatsEnabledInternal = value;
			}
		}
	}

	public static bool enabled
	{
		get
		{
			if (!IsInitialized())
			{
				return false;
			}
			return enabledInternal;
		}
		set
		{
			if (IsInitialized())
			{
				enabledInternal = value;
			}
		}
	}

	public static AnalyticsResult ResumeInitialization()
	{
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		return ResumeInitializationInternal();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod("ResumeInitialization")]
	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	private static extern AnalyticsResult ResumeInitializationInternal();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[ThreadSafe]
	internal static extern bool IsInitialized();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod("FlushEvents")]
	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	private static extern bool FlushArchivedEvents();

	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	private unsafe static AnalyticsResult Transaction(string productId, double amount, string currency, string receiptPurchaseData, string signature, bool usingIAPService)
	{
		//The blocks IL_0029, IL_0037, IL_0045, IL_0053, IL_0058, IL_0065, IL_0074, IL_0082, IL_0087, IL_0095, IL_00a5, IL_00b3, IL_00b8 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0058, IL_0065, IL_0074, IL_0082, IL_0087, IL_0095, IL_00a5, IL_00b3, IL_00b8 are reachable both inside and outside the pinned region starting at IL_0045. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0087, IL_0095, IL_00a5, IL_00b3, IL_00b8 are reachable both inside and outside the pinned region starting at IL_0074. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_00b8 are reachable both inside and outside the pinned region starting at IL_00a5. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_00b8 are reachable both inside and outside the pinned region starting at IL_00a5. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0087, IL_0095, IL_00a5, IL_00b3, IL_00b8 are reachable both inside and outside the pinned region starting at IL_0074. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_00b8 are reachable both inside and outside the pinned region starting at IL_00a5. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_00b8 are reachable both inside and outside the pinned region starting at IL_00a5. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0058, IL_0065, IL_0074, IL_0082, IL_0087, IL_0095, IL_00a5, IL_00b3, IL_00b8 are reachable both inside and outside the pinned region starting at IL_0045. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0087, IL_0095, IL_00a5, IL_00b3, IL_00b8 are reachable both inside and outside the pinned region starting at IL_0074. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_00b8 are reachable both inside and outside the pinned region starting at IL_00a5. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_00b8 are reachable both inside and outside the pinned region starting at IL_00a5. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0087, IL_0095, IL_00a5, IL_00b3, IL_00b8 are reachable both inside and outside the pinned region starting at IL_0074. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_00b8 are reachable both inside and outside the pinned region starting at IL_00a5. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_00b8 are reachable both inside and outside the pinned region starting at IL_00a5. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper productId2;
			double amount2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			ref ManagedSpanWrapper currency2;
			ManagedSpanWrapper managedSpanWrapper3 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan3;
			ref ManagedSpanWrapper receiptPurchaseData2;
			ManagedSpanWrapper managedSpanWrapper4 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan4;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(productId, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(productId);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					productId2 = ref managedSpanWrapper;
					amount2 = amount;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(currency, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(currency);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							currency2 = ref managedSpanWrapper2;
							if (!StringMarshaller.TryMarshalEmptyOrNullString(receiptPurchaseData, ref managedSpanWrapper3))
							{
								readOnlySpan3 = MemoryExtensions.AsSpan(receiptPurchaseData);
								fixed (char* begin3 = readOnlySpan3)
								{
									managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
									receiptPurchaseData2 = ref managedSpanWrapper3;
									if (!StringMarshaller.TryMarshalEmptyOrNullString(signature, ref managedSpanWrapper4))
									{
										readOnlySpan4 = MemoryExtensions.AsSpan(signature);
										fixed (char* begin4 = readOnlySpan4)
										{
											managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
											return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
										}
									}
									return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
								}
							}
							receiptPurchaseData2 = ref managedSpanWrapper3;
							if (!StringMarshaller.TryMarshalEmptyOrNullString(signature, ref managedSpanWrapper4))
							{
								readOnlySpan4 = MemoryExtensions.AsSpan(signature);
								fixed (char* begin4 = readOnlySpan4)
								{
									managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
									return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
								}
							}
							return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
						}
					}
					currency2 = ref managedSpanWrapper2;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(receiptPurchaseData, ref managedSpanWrapper3))
					{
						readOnlySpan3 = MemoryExtensions.AsSpan(receiptPurchaseData);
						fixed (char* begin3 = readOnlySpan3)
						{
							managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
							receiptPurchaseData2 = ref managedSpanWrapper3;
							if (!StringMarshaller.TryMarshalEmptyOrNullString(signature, ref managedSpanWrapper4))
							{
								readOnlySpan4 = MemoryExtensions.AsSpan(signature);
								fixed (char* begin4 = readOnlySpan4)
								{
									managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
									return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
								}
							}
							return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
						}
					}
					receiptPurchaseData2 = ref managedSpanWrapper3;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(signature, ref managedSpanWrapper4))
					{
						readOnlySpan4 = MemoryExtensions.AsSpan(signature);
						fixed (char* begin4 = readOnlySpan4)
						{
							managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
							return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
						}
					}
					return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
				}
			}
			productId2 = ref managedSpanWrapper;
			amount2 = amount;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(currency, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(currency);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					currency2 = ref managedSpanWrapper2;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(receiptPurchaseData, ref managedSpanWrapper3))
					{
						readOnlySpan3 = MemoryExtensions.AsSpan(receiptPurchaseData);
						fixed (char* begin3 = readOnlySpan3)
						{
							managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
							receiptPurchaseData2 = ref managedSpanWrapper3;
							if (!StringMarshaller.TryMarshalEmptyOrNullString(signature, ref managedSpanWrapper4))
							{
								readOnlySpan4 = MemoryExtensions.AsSpan(signature);
								fixed (char* begin4 = readOnlySpan4)
								{
									managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
									return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
								}
							}
							return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
						}
					}
					receiptPurchaseData2 = ref managedSpanWrapper3;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(signature, ref managedSpanWrapper4))
					{
						readOnlySpan4 = MemoryExtensions.AsSpan(signature);
						fixed (char* begin4 = readOnlySpan4)
						{
							managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
							return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
						}
					}
					return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
				}
			}
			currency2 = ref managedSpanWrapper2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(receiptPurchaseData, ref managedSpanWrapper3))
			{
				readOnlySpan3 = MemoryExtensions.AsSpan(receiptPurchaseData);
				fixed (char* begin3 = readOnlySpan3)
				{
					managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
					receiptPurchaseData2 = ref managedSpanWrapper3;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(signature, ref managedSpanWrapper4))
					{
						readOnlySpan4 = MemoryExtensions.AsSpan(signature);
						fixed (char* begin4 = readOnlySpan4)
						{
							managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
							return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
						}
					}
					return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
				}
			}
			receiptPurchaseData2 = ref managedSpanWrapper3;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(signature, ref managedSpanWrapper4))
			{
				readOnlySpan4 = MemoryExtensions.AsSpan(signature);
				fixed (char* begin4 = readOnlySpan4)
				{
					managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
					return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
				}
			}
			return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
		}
		finally
		{
		}
	}

	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	private unsafe static AnalyticsResult SendCustomEventName(string customEventName)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(customEventName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(customEventName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return SendCustomEventName_Injected(ref managedSpanWrapper);
				}
			}
			return SendCustomEventName_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	private static AnalyticsResult SendCustomEvent(CustomEventData eventData)
	{
		return SendCustomEvent_Injected((eventData == null) ? ((IntPtr)0) : CustomEventData.BindingsMarshaller.ConvertToNative(eventData));
	}

	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	internal unsafe static AnalyticsResult IsCustomEventWithLimitEnabled(string customEventName)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(customEventName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(customEventName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return IsCustomEventWithLimitEnabled_Injected(ref managedSpanWrapper);
				}
			}
			return IsCustomEventWithLimitEnabled_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	internal unsafe static AnalyticsResult EnableCustomEventWithLimit(string customEventName, bool enable)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(customEventName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(customEventName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return EnableCustomEventWithLimit_Injected(ref managedSpanWrapper, enable);
				}
			}
			return EnableCustomEventWithLimit_Injected(ref managedSpanWrapper, enable);
		}
		finally
		{
		}
	}

	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	internal unsafe static AnalyticsResult IsEventWithLimitEnabled(string eventName, int ver, string prefix)
	{
		//The blocks IL_0029, IL_0037, IL_0045, IL_0053, IL_0058 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0058 are reachable both inside and outside the pinned region starting at IL_0045. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0058 are reachable both inside and outside the pinned region starting at IL_0045. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper eventName2;
			int ver2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(eventName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					eventName2 = ref managedSpanWrapper;
					ver2 = ver;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							return IsEventWithLimitEnabled_Injected(ref eventName2, ver2, ref managedSpanWrapper2);
						}
					}
					return IsEventWithLimitEnabled_Injected(ref eventName2, ver2, ref managedSpanWrapper2);
				}
			}
			eventName2 = ref managedSpanWrapper;
			ver2 = ver;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					return IsEventWithLimitEnabled_Injected(ref eventName2, ver2, ref managedSpanWrapper2);
				}
			}
			return IsEventWithLimitEnabled_Injected(ref eventName2, ver2, ref managedSpanWrapper2);
		}
		finally
		{
		}
	}

	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	internal unsafe static AnalyticsResult EnableEventWithLimit(string eventName, bool enable, int ver, string prefix)
	{
		//The blocks IL_0029, IL_0038, IL_0046, IL_0054, IL_0059 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper eventName2;
			bool enable2;
			int ver2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(eventName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					eventName2 = ref managedSpanWrapper;
					enable2 = enable;
					ver2 = ver;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							return EnableEventWithLimit_Injected(ref eventName2, enable2, ver2, ref managedSpanWrapper2);
						}
					}
					return EnableEventWithLimit_Injected(ref eventName2, enable2, ver2, ref managedSpanWrapper2);
				}
			}
			eventName2 = ref managedSpanWrapper;
			enable2 = enable;
			ver2 = ver;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					return EnableEventWithLimit_Injected(ref eventName2, enable2, ver2, ref managedSpanWrapper2);
				}
			}
			return EnableEventWithLimit_Injected(ref eventName2, enable2, ver2, ref managedSpanWrapper2);
		}
		finally
		{
		}
	}

	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	internal unsafe static AnalyticsResult RegisterEventWithLimit(string eventName, int maxEventPerHour, int maxItems, string vendorKey, int ver, string prefix, string assemblyInfo, bool notifyServer)
	{
		//The blocks IL_0029, IL_0038, IL_0046, IL_0054, IL_0059, IL_0069, IL_0079, IL_0087, IL_008c, IL_009a, IL_00aa, IL_00b8, IL_00bd are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0059, IL_0069, IL_0079, IL_0087, IL_008c, IL_009a, IL_00aa, IL_00b8, IL_00bd are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_008c, IL_009a, IL_00aa, IL_00b8, IL_00bd are reachable both inside and outside the pinned region starting at IL_0079. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_00bd are reachable both inside and outside the pinned region starting at IL_00aa. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_00bd are reachable both inside and outside the pinned region starting at IL_00aa. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_008c, IL_009a, IL_00aa, IL_00b8, IL_00bd are reachable both inside and outside the pinned region starting at IL_0079. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_00bd are reachable both inside and outside the pinned region starting at IL_00aa. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_00bd are reachable both inside and outside the pinned region starting at IL_00aa. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0059, IL_0069, IL_0079, IL_0087, IL_008c, IL_009a, IL_00aa, IL_00b8, IL_00bd are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_008c, IL_009a, IL_00aa, IL_00b8, IL_00bd are reachable both inside and outside the pinned region starting at IL_0079. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_00bd are reachable both inside and outside the pinned region starting at IL_00aa. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_00bd are reachable both inside and outside the pinned region starting at IL_00aa. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_008c, IL_009a, IL_00aa, IL_00b8, IL_00bd are reachable both inside and outside the pinned region starting at IL_0079. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_00bd are reachable both inside and outside the pinned region starting at IL_00aa. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_00bd are reachable both inside and outside the pinned region starting at IL_00aa. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper eventName2;
			int maxEventPerHour2;
			int maxItems2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			ref ManagedSpanWrapper vendorKey2;
			int ver2;
			ManagedSpanWrapper managedSpanWrapper3 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan3;
			ref ManagedSpanWrapper prefix2;
			ManagedSpanWrapper managedSpanWrapper4 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan4;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(eventName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					eventName2 = ref managedSpanWrapper;
					maxEventPerHour2 = maxEventPerHour;
					maxItems2 = maxItems;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(vendorKey, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(vendorKey);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							vendorKey2 = ref managedSpanWrapper2;
							ver2 = ver;
							if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
							{
								readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
								fixed (char* begin3 = readOnlySpan3)
								{
									managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
									prefix2 = ref managedSpanWrapper3;
									if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper4))
									{
										readOnlySpan4 = MemoryExtensions.AsSpan(assemblyInfo);
										fixed (char* begin4 = readOnlySpan4)
										{
											managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
											return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
										}
									}
									return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
								}
							}
							prefix2 = ref managedSpanWrapper3;
							if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper4))
							{
								readOnlySpan4 = MemoryExtensions.AsSpan(assemblyInfo);
								fixed (char* begin4 = readOnlySpan4)
								{
									managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
									return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
								}
							}
							return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
						}
					}
					vendorKey2 = ref managedSpanWrapper2;
					ver2 = ver;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
					{
						readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
						fixed (char* begin3 = readOnlySpan3)
						{
							managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
							prefix2 = ref managedSpanWrapper3;
							if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper4))
							{
								readOnlySpan4 = MemoryExtensions.AsSpan(assemblyInfo);
								fixed (char* begin4 = readOnlySpan4)
								{
									managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
									return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
								}
							}
							return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
						}
					}
					prefix2 = ref managedSpanWrapper3;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper4))
					{
						readOnlySpan4 = MemoryExtensions.AsSpan(assemblyInfo);
						fixed (char* begin4 = readOnlySpan4)
						{
							managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
							return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
						}
					}
					return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
				}
			}
			eventName2 = ref managedSpanWrapper;
			maxEventPerHour2 = maxEventPerHour;
			maxItems2 = maxItems;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(vendorKey, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(vendorKey);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					vendorKey2 = ref managedSpanWrapper2;
					ver2 = ver;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
					{
						readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
						fixed (char* begin3 = readOnlySpan3)
						{
							managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
							prefix2 = ref managedSpanWrapper3;
							if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper4))
							{
								readOnlySpan4 = MemoryExtensions.AsSpan(assemblyInfo);
								fixed (char* begin4 = readOnlySpan4)
								{
									managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
									return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
								}
							}
							return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
						}
					}
					prefix2 = ref managedSpanWrapper3;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper4))
					{
						readOnlySpan4 = MemoryExtensions.AsSpan(assemblyInfo);
						fixed (char* begin4 = readOnlySpan4)
						{
							managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
							return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
						}
					}
					return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
				}
			}
			vendorKey2 = ref managedSpanWrapper2;
			ver2 = ver;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
			{
				readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
				fixed (char* begin3 = readOnlySpan3)
				{
					managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
					prefix2 = ref managedSpanWrapper3;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper4))
					{
						readOnlySpan4 = MemoryExtensions.AsSpan(assemblyInfo);
						fixed (char* begin4 = readOnlySpan4)
						{
							managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
							return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
						}
					}
					return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
				}
			}
			prefix2 = ref managedSpanWrapper3;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper4))
			{
				readOnlySpan4 = MemoryExtensions.AsSpan(assemblyInfo);
				fixed (char* begin4 = readOnlySpan4)
				{
					managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
					return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
				}
			}
			return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
		}
		finally
		{
		}
	}

	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	internal unsafe static AnalyticsResult RegisterEventsWithLimit(string[] eventName, int maxEventPerHour, int maxItems, string vendorKey, int ver, string prefix, string assemblyInfo, bool notifyServer)
	{
		//The blocks IL_002c, IL_003c, IL_004b, IL_0059, IL_005e, IL_006c, IL_007c, IL_008a, IL_008f are reachable both inside and outside the pinned region starting at IL_001b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_005e, IL_006c, IL_007c, IL_008a, IL_008f are reachable both inside and outside the pinned region starting at IL_004b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_008f are reachable both inside and outside the pinned region starting at IL_007c. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_008f are reachable both inside and outside the pinned region starting at IL_007c. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_005e, IL_006c, IL_007c, IL_008a, IL_008f are reachable both inside and outside the pinned region starting at IL_004b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_008f are reachable both inside and outside the pinned region starting at IL_007c. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_008f are reachable both inside and outside the pinned region starting at IL_007c. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper vendorKey2;
			int ver2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			ref ManagedSpanWrapper prefix2;
			ManagedSpanWrapper managedSpanWrapper3 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan3;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(vendorKey, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(vendorKey);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					vendorKey2 = ref managedSpanWrapper;
					ver2 = ver;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							prefix2 = ref managedSpanWrapper2;
							if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper3))
							{
								readOnlySpan3 = MemoryExtensions.AsSpan(assemblyInfo);
								fixed (char* begin3 = readOnlySpan3)
								{
									managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
									return RegisterEventsWithLimit_Injected(eventName, maxEventPerHour, maxItems, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper3, notifyServer);
								}
							}
							return RegisterEventsWithLimit_Injected(eventName, maxEventPerHour, maxItems, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper3, notifyServer);
						}
					}
					prefix2 = ref managedSpanWrapper2;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper3))
					{
						readOnlySpan3 = MemoryExtensions.AsSpan(assemblyInfo);
						fixed (char* begin3 = readOnlySpan3)
						{
							managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
							return RegisterEventsWithLimit_Injected(eventName, maxEventPerHour, maxItems, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper3, notifyServer);
						}
					}
					return RegisterEventsWithLimit_Injected(eventName, maxEventPerHour, maxItems, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper3, notifyServer);
				}
			}
			vendorKey2 = ref managedSpanWrapper;
			ver2 = ver;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					prefix2 = ref managedSpanWrapper2;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper3))
					{
						readOnlySpan3 = MemoryExtensions.AsSpan(assemblyInfo);
						fixed (char* begin3 = readOnlySpan3)
						{
							managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
							return RegisterEventsWithLimit_Injected(eventName, maxEventPerHour, maxItems, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper3, notifyServer);
						}
					}
					return RegisterEventsWithLimit_Injected(eventName, maxEventPerHour, maxItems, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper3, notifyServer);
				}
			}
			prefix2 = ref managedSpanWrapper2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper3))
			{
				readOnlySpan3 = MemoryExtensions.AsSpan(assemblyInfo);
				fixed (char* begin3 = readOnlySpan3)
				{
					managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
					return RegisterEventsWithLimit_Injected(eventName, maxEventPerHour, maxItems, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper3, notifyServer);
				}
			}
			return RegisterEventsWithLimit_Injected(eventName, maxEventPerHour, maxItems, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper3, notifyServer);
		}
		finally
		{
		}
	}

	[ThreadSafe]
	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	internal unsafe static AnalyticsResult SendEventWithLimit(string eventName, object parameters, int ver, string prefix)
	{
		//The blocks IL_0029, IL_0038, IL_0046, IL_0054, IL_0059 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper eventName2;
			object parameters2;
			int ver2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(eventName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					eventName2 = ref managedSpanWrapper;
					parameters2 = parameters;
					ver2 = ver;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							return SendEventWithLimit_Injected(ref eventName2, parameters2, ver2, ref managedSpanWrapper2);
						}
					}
					return SendEventWithLimit_Injected(ref eventName2, parameters2, ver2, ref managedSpanWrapper2);
				}
			}
			eventName2 = ref managedSpanWrapper;
			parameters2 = parameters;
			ver2 = ver;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					return SendEventWithLimit_Injected(ref eventName2, parameters2, ver2, ref managedSpanWrapper2);
				}
			}
			return SendEventWithLimit_Injected(ref eventName2, parameters2, ver2, ref managedSpanWrapper2);
		}
		finally
		{
		}
	}

	[ThreadSafe]
	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	internal unsafe static AnalyticsResult SetEventWithLimitEndPoint(string eventName, string endPoint, int ver, string prefix)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057, IL_0065, IL_0074, IL_0082, IL_0087 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057, IL_0065, IL_0074, IL_0082, IL_0087 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0087 are reachable both inside and outside the pinned region starting at IL_0074. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0087 are reachable both inside and outside the pinned region starting at IL_0074. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057, IL_0065, IL_0074, IL_0082, IL_0087 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0087 are reachable both inside and outside the pinned region starting at IL_0074. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0087 are reachable both inside and outside the pinned region starting at IL_0074. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper eventName2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			ref ManagedSpanWrapper endPoint2;
			int ver2;
			ManagedSpanWrapper managedSpanWrapper3 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan3;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(eventName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					eventName2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(endPoint, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(endPoint);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							endPoint2 = ref managedSpanWrapper2;
							ver2 = ver;
							if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
							{
								readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
								fixed (char* begin3 = readOnlySpan3)
								{
									managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
									return SetEventWithLimitEndPoint_Injected(ref eventName2, ref endPoint2, ver2, ref managedSpanWrapper3);
								}
							}
							return SetEventWithLimitEndPoint_Injected(ref eventName2, ref endPoint2, ver2, ref managedSpanWrapper3);
						}
					}
					endPoint2 = ref managedSpanWrapper2;
					ver2 = ver;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
					{
						readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
						fixed (char* begin3 = readOnlySpan3)
						{
							managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
							return SetEventWithLimitEndPoint_Injected(ref eventName2, ref endPoint2, ver2, ref managedSpanWrapper3);
						}
					}
					return SetEventWithLimitEndPoint_Injected(ref eventName2, ref endPoint2, ver2, ref managedSpanWrapper3);
				}
			}
			eventName2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(endPoint, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(endPoint);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					endPoint2 = ref managedSpanWrapper2;
					ver2 = ver;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
					{
						readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
						fixed (char* begin3 = readOnlySpan3)
						{
							managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
							return SetEventWithLimitEndPoint_Injected(ref eventName2, ref endPoint2, ver2, ref managedSpanWrapper3);
						}
					}
					return SetEventWithLimitEndPoint_Injected(ref eventName2, ref endPoint2, ver2, ref managedSpanWrapper3);
				}
			}
			endPoint2 = ref managedSpanWrapper2;
			ver2 = ver;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
			{
				readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
				fixed (char* begin3 = readOnlySpan3)
				{
					managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
					return SetEventWithLimitEndPoint_Injected(ref eventName2, ref endPoint2, ver2, ref managedSpanWrapper3);
				}
			}
			return SetEventWithLimitEndPoint_Injected(ref eventName2, ref endPoint2, ver2, ref managedSpanWrapper3);
		}
		finally
		{
		}
	}

	[ThreadSafe]
	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	internal unsafe static AnalyticsResult SetEventWithLimitPriority(string eventName, AnalyticsEventPriority eventPriority, int ver, string prefix)
	{
		//The blocks IL_0029, IL_0038, IL_0046, IL_0054, IL_0059 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper eventName2;
			AnalyticsEventPriority eventPriority2;
			int ver2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(eventName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					eventName2 = ref managedSpanWrapper;
					eventPriority2 = eventPriority;
					ver2 = ver;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							return SetEventWithLimitPriority_Injected(ref eventName2, eventPriority2, ver2, ref managedSpanWrapper2);
						}
					}
					return SetEventWithLimitPriority_Injected(ref eventName2, eventPriority2, ver2, ref managedSpanWrapper2);
				}
			}
			eventName2 = ref managedSpanWrapper;
			eventPriority2 = eventPriority;
			ver2 = ver;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					return SetEventWithLimitPriority_Injected(ref eventName2, eventPriority2, ver2, ref managedSpanWrapper2);
				}
			}
			return SetEventWithLimitPriority_Injected(ref eventName2, eventPriority2, ver2, ref managedSpanWrapper2);
		}
		finally
		{
		}
	}

	[ThreadSafe]
	[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
	internal unsafe static AnalyticsResult QueueEvent(string eventName, object parameters, int ver, string prefix)
	{
		//The blocks IL_0029, IL_0038, IL_0046, IL_0054, IL_0059 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper eventName2;
			object parameters2;
			int ver2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(eventName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					eventName2 = ref managedSpanWrapper;
					parameters2 = parameters;
					ver2 = ver;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							return QueueEvent_Injected(ref eventName2, parameters2, ver2, ref managedSpanWrapper2);
						}
					}
					return QueueEvent_Injected(ref eventName2, parameters2, ver2, ref managedSpanWrapper2);
				}
			}
			eventName2 = ref managedSpanWrapper;
			parameters2 = parameters;
			ver2 = ver;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					return QueueEvent_Injected(ref eventName2, parameters2, ver2, ref managedSpanWrapper2);
				}
			}
			return QueueEvent_Injected(ref eventName2, parameters2, ver2, ref managedSpanWrapper2);
		}
		finally
		{
		}
	}

	public static AnalyticsResult FlushEvents()
	{
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		return (!FlushArchivedEvents()) ? AnalyticsResult.NotInitialized : AnalyticsResult.Ok;
	}

	[Obsolete("SetUserId is no longer supported", true)]
	public static AnalyticsResult SetUserId(string userId)
	{
		if (string.IsNullOrEmpty(userId))
		{
			throw new ArgumentException("Cannot set userId to an empty or null string");
		}
		return AnalyticsResult.InvalidData;
	}

	[Obsolete("SetUserGender is no longer supported", true)]
	public static AnalyticsResult SetUserGender(Gender gender)
	{
		return AnalyticsResult.InvalidData;
	}

	[Obsolete("SetUserBirthYear is no longer supported", true)]
	public static AnalyticsResult SetUserBirthYear(int birthYear)
	{
		return AnalyticsResult.InvalidData;
	}

	[Obsolete("SendUserInfoEvent is no longer supported", true)]
	private static AnalyticsResult SendUserInfoEvent(object param)
	{
		return AnalyticsResult.InvalidData;
	}

	public static AnalyticsResult Transaction(string productId, decimal amount, string currency)
	{
		return Transaction(productId, amount, currency, null, null, usingIAPService: false);
	}

	public static AnalyticsResult Transaction(string productId, decimal amount, string currency, string receiptPurchaseData, string signature)
	{
		return Transaction(productId, amount, currency, receiptPurchaseData, signature, usingIAPService: false);
	}

	public static AnalyticsResult Transaction(string productId, decimal amount, string currency, string receiptPurchaseData, string signature, bool usingIAPService)
	{
		if (string.IsNullOrEmpty(productId))
		{
			throw new ArgumentException("Cannot set productId to an empty or null string");
		}
		if (string.IsNullOrEmpty(currency))
		{
			throw new ArgumentException("Cannot set currency to an empty or null string");
		}
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		if (receiptPurchaseData == null)
		{
			receiptPurchaseData = string.Empty;
		}
		if (signature == null)
		{
			signature = string.Empty;
		}
		return Transaction(productId, Convert.ToDouble(amount), currency, receiptPurchaseData, signature, usingIAPService);
	}

	public static AnalyticsResult CustomEvent(string customEventName)
	{
		if (string.IsNullOrEmpty(customEventName))
		{
			throw new ArgumentException("Cannot set custom event name to an empty or null string");
		}
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		return SendCustomEventName(customEventName);
	}

	public static AnalyticsResult CustomEvent(string customEventName, Vector3 position)
	{
		if (string.IsNullOrEmpty(customEventName))
		{
			throw new ArgumentException("Cannot set custom event name to an empty or null string");
		}
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		CustomEventData customEventData = new CustomEventData(customEventName);
		customEventData.AddDouble("x", (double)Convert.ToDecimal(position.x));
		customEventData.AddDouble("y", (double)Convert.ToDecimal(position.y));
		customEventData.AddDouble("z", (double)Convert.ToDecimal(position.z));
		AnalyticsResult result = SendCustomEvent(customEventData);
		customEventData.Dispose();
		return result;
	}

	public static AnalyticsResult CustomEvent(string customEventName, IDictionary<string, object> eventData)
	{
		if (string.IsNullOrEmpty(customEventName))
		{
			throw new ArgumentException("Cannot set custom event name to an empty or null string");
		}
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		if (eventData == null)
		{
			return SendCustomEventName(customEventName);
		}
		CustomEventData customEventData = new CustomEventData(customEventName);
		AnalyticsResult result = AnalyticsResult.InvalidData;
		try
		{
			customEventData.AddDictionary(eventData);
			result = SendCustomEvent(customEventData);
		}
		finally
		{
			customEventData.Dispose();
		}
		return result;
	}

	public static AnalyticsResult EnableCustomEvent(string customEventName, bool enabled)
	{
		if (string.IsNullOrEmpty(customEventName))
		{
			throw new ArgumentException("Cannot set event name to an empty or null string");
		}
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		return EnableCustomEventWithLimit(customEventName, enabled);
	}

	public static AnalyticsResult IsCustomEventEnabled(string customEventName)
	{
		if (string.IsNullOrEmpty(customEventName))
		{
			throw new ArgumentException("Cannot set event name to an empty or null string");
		}
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		return IsCustomEventWithLimitEnabled(customEventName);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AnalyticsResult RegisterEvent(string eventName, int maxEventPerHour, int maxItems, string vendorKey = "", string prefix = "")
	{
		string empty = string.Empty;
		empty = Assembly.GetCallingAssembly().FullName;
		return RegisterEvent(eventName, maxEventPerHour, maxItems, vendorKey, 1, prefix, empty);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AnalyticsResult RegisterEvent(string eventName, int maxEventPerHour, int maxItems, string vendorKey, int ver, string prefix = "")
	{
		string empty = string.Empty;
		empty = Assembly.GetCallingAssembly().FullName;
		return RegisterEvent(eventName, maxEventPerHour, maxItems, vendorKey, ver, prefix, empty);
	}

	private static AnalyticsResult RegisterEvent(string eventName, int maxEventPerHour, int maxItems, string vendorKey, int ver, string prefix, string assemblyInfo)
	{
		if (string.IsNullOrEmpty(eventName))
		{
			throw new ArgumentException("Cannot set event name to an empty or null string");
		}
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		return RegisterEventWithLimit(eventName, maxEventPerHour, maxItems, vendorKey, ver, prefix, assemblyInfo, notifyServer: true);
	}

	public static AnalyticsResult SendEvent(string eventName, object parameters, int ver = 1, string prefix = "")
	{
		if (string.IsNullOrEmpty(eventName))
		{
			throw new ArgumentException("Cannot set event name to an empty or null string");
		}
		if (parameters == null)
		{
			throw new ArgumentException("Cannot set parameters to null");
		}
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		return SendEventWithLimit(eventName, parameters, ver, prefix);
	}

	public static AnalyticsResult SetEventEndPoint(string eventName, string endPoint, int ver = 1, string prefix = "")
	{
		if (string.IsNullOrEmpty(eventName))
		{
			throw new ArgumentException("Cannot set event name to an empty or null string");
		}
		if (endPoint == null)
		{
			throw new ArgumentException("Cannot set parameters to null");
		}
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		return SetEventWithLimitEndPoint(eventName, endPoint, ver, prefix);
	}

	public static AnalyticsResult SetEventPriority(string eventName, AnalyticsEventPriority eventPriority, int ver = 1, string prefix = "")
	{
		if (string.IsNullOrEmpty(eventName))
		{
			throw new ArgumentException("Cannot set event name to an empty or null string");
		}
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		return SetEventWithLimitPriority(eventName, eventPriority, ver, prefix);
	}

	public static AnalyticsResult EnableEvent(string eventName, bool enabled, int ver = 1, string prefix = "")
	{
		if (string.IsNullOrEmpty(eventName))
		{
			throw new ArgumentException("Cannot set event name to an empty or null string");
		}
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		return EnableEventWithLimit(eventName, enabled, ver, prefix);
	}

	public static AnalyticsResult IsEventEnabled(string eventName, int ver = 1, string prefix = "")
	{
		if (string.IsNullOrEmpty(eventName))
		{
			throw new ArgumentException("Cannot set event name to an empty or null string");
		}
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		return IsEventWithLimitEnabled(eventName, ver, prefix);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_eventUrlInternal_Injected(out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_configUrlInternal_Injected(out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_dashboardUrlInternal_Injected(out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult Transaction_Injected(ref ManagedSpanWrapper productId, double amount, ref ManagedSpanWrapper currency, ref ManagedSpanWrapper receiptPurchaseData, ref ManagedSpanWrapper signature, bool usingIAPService);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult SendCustomEventName_Injected(ref ManagedSpanWrapper customEventName);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult SendCustomEvent_Injected(IntPtr eventData);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult IsCustomEventWithLimitEnabled_Injected(ref ManagedSpanWrapper customEventName);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult EnableCustomEventWithLimit_Injected(ref ManagedSpanWrapper customEventName, bool enable);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult IsEventWithLimitEnabled_Injected(ref ManagedSpanWrapper eventName, int ver, ref ManagedSpanWrapper prefix);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult EnableEventWithLimit_Injected(ref ManagedSpanWrapper eventName, bool enable, int ver, ref ManagedSpanWrapper prefix);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult RegisterEventWithLimit_Injected(ref ManagedSpanWrapper eventName, int maxEventPerHour, int maxItems, ref ManagedSpanWrapper vendorKey, int ver, ref ManagedSpanWrapper prefix, ref ManagedSpanWrapper assemblyInfo, bool notifyServer);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult RegisterEventsWithLimit_Injected(string[] eventName, int maxEventPerHour, int maxItems, ref ManagedSpanWrapper vendorKey, int ver, ref ManagedSpanWrapper prefix, ref ManagedSpanWrapper assemblyInfo, bool notifyServer);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult SendEventWithLimit_Injected(ref ManagedSpanWrapper eventName, object parameters, int ver, ref ManagedSpanWrapper prefix);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult SetEventWithLimitEndPoint_Injected(ref ManagedSpanWrapper eventName, ref ManagedSpanWrapper endPoint, int ver, ref ManagedSpanWrapper prefix);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult SetEventWithLimitPriority_Injected(ref ManagedSpanWrapper eventName, AnalyticsEventPriority eventPriority, int ver, ref ManagedSpanWrapper prefix);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult QueueEvent_Injected(ref ManagedSpanWrapper eventName, object parameters, int ver, ref ManagedSpanWrapper prefix);
}
