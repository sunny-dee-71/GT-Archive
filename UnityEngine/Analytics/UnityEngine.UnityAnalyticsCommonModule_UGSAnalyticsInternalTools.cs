using UnityEngine.Internal;

namespace UnityEngine.Analytics;

[ExcludeFromDocs]
public interface UGSAnalyticsInternalTools
{
	static void SetPrivacyStatus(bool status)
	{
		AnalyticsCommon.ugsAnalyticsEnabled = status;
	}
}
