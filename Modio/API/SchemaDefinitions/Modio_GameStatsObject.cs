using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct GameStatsObject(long game_id, long mods_count_total, long mods_downloads_today, long mods_downloads_total, long mods_downloads_daily_average, long mods_subscribers_total, long date_expires)
{
	internal readonly long GameId = game_id;

	internal readonly long ModsCountTotal = mods_count_total;

	internal readonly long ModsDownloadsToday = mods_downloads_today;

	internal readonly long ModsDownloadsTotal = mods_downloads_total;

	internal readonly long ModsDownloadsDailyAverage = mods_downloads_daily_average;

	internal readonly long ModsSubscribersTotal = mods_subscribers_total;

	internal readonly long DateExpires = date_expires;
}
