namespace UnityEngine.UnityConsent;

public struct ConsentState
{
	public ConsentStatus AdsIntent = ConsentStatus.Unspecified;

	public ConsentStatus AnalyticsIntent = ConsentStatus.Unspecified;

	public ConsentState()
	{
	}

	public override string ToString()
	{
		return string.Format("{0}: {1}, {2}: {3}", "AdsIntent", AdsIntent, "AnalyticsIntent", AnalyticsIntent);
	}
}
