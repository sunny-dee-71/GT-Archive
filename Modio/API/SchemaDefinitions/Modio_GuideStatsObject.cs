using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct GuideStatsObject(long guide_id, long visits_today, long visits_total, long comments_total)
{
	internal readonly long GuideId = guide_id;

	internal readonly long VisitsToday = visits_today;

	internal readonly long VisitsTotal = visits_total;

	internal readonly long CommentsTotal = comments_total;
}
