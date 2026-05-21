using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine.Analytics;

[Preserve]
[RequiredByNativeCode]
[NativeHeader("Modules/UnityAnalytics/Public/UnityAnalytics.h")]
[NativeHeader("Modules/UnityAnalyticsCommon/Public/UnityAnalyticsCommon.h")]
[NativeHeader("Modules/UnityAnalytics/ContinuousEvent/Manager.h")]
[ExcludeFromDocs]
public class ContinuousEvent
{
	public static AnalyticsResult RegisterCollector<T>(string metricName, Func<T> del) where T : struct, IComparable<T>, IEquatable<T>
	{
		if (string.IsNullOrEmpty(metricName))
		{
			throw new ArgumentException("Cannot set metric name to an empty or null string");
		}
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		return InternalRegisterCollector(typeof(T).ToString(), metricName, del);
	}

	public static AnalyticsResult SetEventHistogramThresholds<T>(string eventName, int count, T[] data, int ver = 1, string prefix = "") where T : struct, IComparable<T>, IEquatable<T>
	{
		if (string.IsNullOrEmpty(eventName))
		{
			throw new ArgumentException("Cannot set event name to an empty or null string");
		}
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		return InternalSetEventHistogramThresholds(typeof(T).ToString(), eventName, count, data, ver, prefix);
	}

	public static AnalyticsResult SetCustomEventHistogramThresholds<T>(string eventName, int count, T[] data) where T : struct, IComparable<T>, IEquatable<T>
	{
		if (string.IsNullOrEmpty(eventName))
		{
			throw new ArgumentException("Cannot set event name to an empty or null string");
		}
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		return InternalSetCustomEventHistogramThresholds(typeof(T).ToString(), eventName, count, data);
	}

	public static AnalyticsResult ConfigureCustomEvent(string customEventName, string metricName, float interval, float period, bool enabled = true)
	{
		if (string.IsNullOrEmpty(customEventName))
		{
			throw new ArgumentException("Cannot set event name to an empty or null string");
		}
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		return InternalConfigureCustomEvent(customEventName, metricName, interval, period, enabled);
	}

	public static AnalyticsResult ConfigureEvent(string eventName, string metricName, float interval, float period, bool enabled = true, int ver = 1, string prefix = "")
	{
		if (string.IsNullOrEmpty(eventName))
		{
			throw new ArgumentException("Cannot set event name to an empty or null string");
		}
		if (!IsInitialized())
		{
			return AnalyticsResult.NotInitialized;
		}
		return InternalConfigureEvent(eventName, metricName, interval, period, enabled, ver, prefix);
	}

	[StaticAccessor("::GetUnityAnalytics().GetContinuousEventManager()", StaticAccessorType.Dot)]
	private unsafe static AnalyticsResult InternalRegisterCollector(string type, string metricName, object collector)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper type2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(type, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(type);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					type2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(metricName, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(metricName);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							return InternalRegisterCollector_Injected(ref type2, ref managedSpanWrapper2, collector);
						}
					}
					return InternalRegisterCollector_Injected(ref type2, ref managedSpanWrapper2, collector);
				}
			}
			type2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(metricName, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(metricName);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					return InternalRegisterCollector_Injected(ref type2, ref managedSpanWrapper2, collector);
				}
			}
			return InternalRegisterCollector_Injected(ref type2, ref managedSpanWrapper2, collector);
		}
		finally
		{
		}
	}

	[StaticAccessor("::GetUnityAnalytics().GetContinuousEventManager()", StaticAccessorType.Dot)]
	private unsafe static AnalyticsResult InternalSetEventHistogramThresholds(string type, string eventName, int count, object data, int ver, string prefix)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057, IL_0069, IL_0079, IL_0087, IL_008c are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057, IL_0069, IL_0079, IL_0087, IL_008c are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_008c are reachable both inside and outside the pinned region starting at IL_0079. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_008c are reachable both inside and outside the pinned region starting at IL_0079. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057, IL_0069, IL_0079, IL_0087, IL_008c are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_008c are reachable both inside and outside the pinned region starting at IL_0079. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_008c are reachable both inside and outside the pinned region starting at IL_0079. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper type2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			ref ManagedSpanWrapper eventName2;
			int count2;
			object data2;
			int ver2;
			ManagedSpanWrapper managedSpanWrapper3 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan3;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(type, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(type);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					type2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(eventName);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							eventName2 = ref managedSpanWrapper2;
							count2 = count;
							data2 = data;
							ver2 = ver;
							if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
							{
								readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
								fixed (char* begin3 = readOnlySpan3)
								{
									managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
									return InternalSetEventHistogramThresholds_Injected(ref type2, ref eventName2, count2, data2, ver2, ref managedSpanWrapper3);
								}
							}
							return InternalSetEventHistogramThresholds_Injected(ref type2, ref eventName2, count2, data2, ver2, ref managedSpanWrapper3);
						}
					}
					eventName2 = ref managedSpanWrapper2;
					count2 = count;
					data2 = data;
					ver2 = ver;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
					{
						readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
						fixed (char* begin3 = readOnlySpan3)
						{
							managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
							return InternalSetEventHistogramThresholds_Injected(ref type2, ref eventName2, count2, data2, ver2, ref managedSpanWrapper3);
						}
					}
					return InternalSetEventHistogramThresholds_Injected(ref type2, ref eventName2, count2, data2, ver2, ref managedSpanWrapper3);
				}
			}
			type2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(eventName);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					eventName2 = ref managedSpanWrapper2;
					count2 = count;
					data2 = data;
					ver2 = ver;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
					{
						readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
						fixed (char* begin3 = readOnlySpan3)
						{
							managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
							return InternalSetEventHistogramThresholds_Injected(ref type2, ref eventName2, count2, data2, ver2, ref managedSpanWrapper3);
						}
					}
					return InternalSetEventHistogramThresholds_Injected(ref type2, ref eventName2, count2, data2, ver2, ref managedSpanWrapper3);
				}
			}
			eventName2 = ref managedSpanWrapper2;
			count2 = count;
			data2 = data;
			ver2 = ver;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
			{
				readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
				fixed (char* begin3 = readOnlySpan3)
				{
					managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
					return InternalSetEventHistogramThresholds_Injected(ref type2, ref eventName2, count2, data2, ver2, ref managedSpanWrapper3);
				}
			}
			return InternalSetEventHistogramThresholds_Injected(ref type2, ref eventName2, count2, data2, ver2, ref managedSpanWrapper3);
		}
		finally
		{
		}
	}

	[StaticAccessor("::GetUnityAnalytics().GetContinuousEventManager()", StaticAccessorType.Dot)]
	private unsafe static AnalyticsResult InternalSetCustomEventHistogramThresholds(string type, string eventName, int count, object data)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper type2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(type, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(type);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					type2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(eventName);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							return InternalSetCustomEventHistogramThresholds_Injected(ref type2, ref managedSpanWrapper2, count, data);
						}
					}
					return InternalSetCustomEventHistogramThresholds_Injected(ref type2, ref managedSpanWrapper2, count, data);
				}
			}
			type2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(eventName);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					return InternalSetCustomEventHistogramThresholds_Injected(ref type2, ref managedSpanWrapper2, count, data);
				}
			}
			return InternalSetCustomEventHistogramThresholds_Injected(ref type2, ref managedSpanWrapper2, count, data);
		}
		finally
		{
		}
	}

	[StaticAccessor("::GetUnityAnalytics().GetContinuousEventManager()", StaticAccessorType.Dot)]
	private unsafe static AnalyticsResult InternalConfigureCustomEvent(string customEventName, string metricName, float interval, float period, bool enabled)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper customEventName2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(customEventName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(customEventName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					customEventName2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(metricName, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(metricName);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							return InternalConfigureCustomEvent_Injected(ref customEventName2, ref managedSpanWrapper2, interval, period, enabled);
						}
					}
					return InternalConfigureCustomEvent_Injected(ref customEventName2, ref managedSpanWrapper2, interval, period, enabled);
				}
			}
			customEventName2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(metricName, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(metricName);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					return InternalConfigureCustomEvent_Injected(ref customEventName2, ref managedSpanWrapper2, interval, period, enabled);
				}
			}
			return InternalConfigureCustomEvent_Injected(ref customEventName2, ref managedSpanWrapper2, interval, period, enabled);
		}
		finally
		{
		}
	}

	[StaticAccessor("::GetUnityAnalytics().GetContinuousEventManager()", StaticAccessorType.Dot)]
	private unsafe static AnalyticsResult InternalConfigureEvent(string eventName, string metricName, float interval, float period, bool enabled, int ver, string prefix)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057, IL_006b, IL_007b, IL_0089, IL_008e are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057, IL_006b, IL_007b, IL_0089, IL_008e are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_008e are reachable both inside and outside the pinned region starting at IL_007b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_008e are reachable both inside and outside the pinned region starting at IL_007b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057, IL_006b, IL_007b, IL_0089, IL_008e are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_008e are reachable both inside and outside the pinned region starting at IL_007b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_008e are reachable both inside and outside the pinned region starting at IL_007b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper eventName2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			ref ManagedSpanWrapper metricName2;
			float interval2;
			float period2;
			bool enabled2;
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
					if (!StringMarshaller.TryMarshalEmptyOrNullString(metricName, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(metricName);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							metricName2 = ref managedSpanWrapper2;
							interval2 = interval;
							period2 = period;
							enabled2 = enabled;
							ver2 = ver;
							if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
							{
								readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
								fixed (char* begin3 = readOnlySpan3)
								{
									managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
									return InternalConfigureEvent_Injected(ref eventName2, ref metricName2, interval2, period2, enabled2, ver2, ref managedSpanWrapper3);
								}
							}
							return InternalConfigureEvent_Injected(ref eventName2, ref metricName2, interval2, period2, enabled2, ver2, ref managedSpanWrapper3);
						}
					}
					metricName2 = ref managedSpanWrapper2;
					interval2 = interval;
					period2 = period;
					enabled2 = enabled;
					ver2 = ver;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
					{
						readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
						fixed (char* begin3 = readOnlySpan3)
						{
							managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
							return InternalConfigureEvent_Injected(ref eventName2, ref metricName2, interval2, period2, enabled2, ver2, ref managedSpanWrapper3);
						}
					}
					return InternalConfigureEvent_Injected(ref eventName2, ref metricName2, interval2, period2, enabled2, ver2, ref managedSpanWrapper3);
				}
			}
			eventName2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(metricName, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(metricName);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					metricName2 = ref managedSpanWrapper2;
					interval2 = interval;
					period2 = period;
					enabled2 = enabled;
					ver2 = ver;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
					{
						readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
						fixed (char* begin3 = readOnlySpan3)
						{
							managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
							return InternalConfigureEvent_Injected(ref eventName2, ref metricName2, interval2, period2, enabled2, ver2, ref managedSpanWrapper3);
						}
					}
					return InternalConfigureEvent_Injected(ref eventName2, ref metricName2, interval2, period2, enabled2, ver2, ref managedSpanWrapper3);
				}
			}
			metricName2 = ref managedSpanWrapper2;
			interval2 = interval;
			period2 = period;
			enabled2 = enabled;
			ver2 = ver;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
			{
				readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
				fixed (char* begin3 = readOnlySpan3)
				{
					managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
					return InternalConfigureEvent_Injected(ref eventName2, ref metricName2, interval2, period2, enabled2, ver2, ref managedSpanWrapper3);
				}
			}
			return InternalConfigureEvent_Injected(ref eventName2, ref metricName2, interval2, period2, enabled2, ver2, ref managedSpanWrapper3);
		}
		finally
		{
		}
	}

	internal static bool IsInitialized()
	{
		return Analytics.IsInitialized();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult InternalRegisterCollector_Injected(ref ManagedSpanWrapper type, ref ManagedSpanWrapper metricName, object collector);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult InternalSetEventHistogramThresholds_Injected(ref ManagedSpanWrapper type, ref ManagedSpanWrapper eventName, int count, object data, int ver, ref ManagedSpanWrapper prefix);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult InternalSetCustomEventHistogramThresholds_Injected(ref ManagedSpanWrapper type, ref ManagedSpanWrapper eventName, int count, object data);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult InternalConfigureCustomEvent_Injected(ref ManagedSpanWrapper customEventName, ref ManagedSpanWrapper metricName, float interval, float period, bool enabled);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AnalyticsResult InternalConfigureEvent_Injected(ref ManagedSpanWrapper eventName, ref ManagedSpanWrapper metricName, float interval, float period, bool enabled, int ver, ref ManagedSpanWrapper prefix);
}
