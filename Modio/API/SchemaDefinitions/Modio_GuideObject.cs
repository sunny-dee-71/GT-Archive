using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct GuideObject(long id, long game_id, string game_name, LogoObject logo, UserObject user, long date_added, long date_updated, long date_live, long status, string url, string name, string name_id, string summary, string description, long community_options, GuideTagObject[] tags, GuideStatsObject[] stats)
{
	internal readonly long Id = id;

	internal readonly long GameId = game_id;

	internal readonly string GameName = game_name;

	internal readonly LogoObject Logo = logo;

	internal readonly UserObject User = user;

	internal readonly long DateAdded = date_added;

	internal readonly long DateUpdated = date_updated;

	internal readonly long DateLive = date_live;

	internal readonly long Status = status;

	internal readonly string Url = url;

	internal readonly string Name = name;

	internal readonly string NameId = name_id;

	internal readonly string Summary = summary;

	internal readonly string Description = description;

	internal readonly long CommunityOptions = community_options;

	internal readonly GuideTagObject[] Tags = tags;

	internal readonly GuideStatsObject[] Stats = stats;
}
