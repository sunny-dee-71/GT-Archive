using UnityEngine.Internal;

namespace UnityEngine.Analytics;

[ExcludeFromDocs]
public class Analytic : AnalyticsEventBase
{
	public readonly IAnalytic instance;

	public readonly AnalyticInfoAttribute info;

	public Analytic(IAnalytic instance, AnalyticInfoAttribute info)
		: base(info.eventName, info.version)
	{
		this.instance = instance;
		this.info = info;
	}
}
