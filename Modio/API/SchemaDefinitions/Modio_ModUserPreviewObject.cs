using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct ModUserPreviewObject(UserObject user, UserObject user_from, string resource_url, bool subscribed, long date_added)
{
	internal readonly UserObject User = user;

	internal readonly UserObject UserFrom = user_from;

	internal readonly string ResourceUrl = resource_url;

	internal readonly bool Subscribed = subscribed;

	internal readonly long DateAdded = date_added;
}
