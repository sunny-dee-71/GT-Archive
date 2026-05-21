using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine.Analytics;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/UnityAnalyticsCommon/Public/UnityAnalyticsCommon.h")]
[ExcludeFromDocs]
public static class AnalyticsCommon
{
	[StaticAccessor("GetUnityAnalyticsCommon()", StaticAccessorType.Dot)]
	private static extern bool ugsAnalyticsEnabledInternal
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("UGSAnalyticsUserOptStatus")]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("SetUGSAnalyticsUserOptStatus")]
		set;
	}

	public static bool ugsAnalyticsEnabled
	{
		get
		{
			return ugsAnalyticsEnabledInternal;
		}
		set
		{
			ugsAnalyticsEnabledInternal = value;
		}
	}
}
