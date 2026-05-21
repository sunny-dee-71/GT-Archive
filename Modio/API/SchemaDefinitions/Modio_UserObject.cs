using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct UserObject(long id, string name_id, string username, string display_name_portal, long date_online, long date_joined, AvatarObject avatar, string timezone, string language, string profile_url)
{
	internal readonly long Id = id;

	internal readonly string NameId = name_id;

	internal readonly string Username = username;

	internal readonly string DisplayNamePortal = display_name_portal;

	internal readonly long DateOnline = date_online;

	internal readonly long DateJoined = date_joined;

	internal readonly AvatarObject Avatar = avatar;

	internal readonly string Timezone = timezone;

	internal readonly string Language = language;

	internal readonly string ProfileUrl = profile_url;
}
