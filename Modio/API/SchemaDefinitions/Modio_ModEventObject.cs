using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct ModEventObject(long id, long mod_id, long user_id, long date_added, string event_type)
{
	internal readonly long Id = id;

	internal readonly long ModId = mod_id;

	internal readonly long UserId = user_id;

	internal readonly long DateAdded = date_added;

	internal readonly string EventType = event_type;
}
