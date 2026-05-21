using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject(MemberSerialization.Fields)]
internal readonly struct ModStatsObject(long mod_id, long popularity_rank_position, long popularity_rank_total_mods, long downloads_today, long downloads_total, long subscribers_total, long ratings_total, long ratings_positive, long ratings_negative, long ratings_percentage_positive, float ratings_weighted_aggregate, string ratings_display_text, long date_expires)
{
	internal readonly long ModId = mod_id;

	internal readonly long PopularityRankPosition = popularity_rank_position;

	internal readonly long PopularityRankTotalMods = popularity_rank_total_mods;

	internal readonly long DownloadsToday = downloads_today;

	internal readonly long DownloadsTotal = downloads_total;

	internal readonly long SubscribersTotal = subscribers_total;

	internal readonly long RatingsTotal = ratings_total;

	internal readonly long RatingsPositive = ratings_positive;

	internal readonly long RatingsNegative = ratings_negative;

	internal readonly long RatingsPercentagePositive = ratings_percentage_positive;

	internal readonly float RatingsWeightedAggregate = ratings_weighted_aggregate;

	internal readonly string RatingsDisplayText = ratings_display_text;

	internal readonly long DateExpires = date_expires;
}
