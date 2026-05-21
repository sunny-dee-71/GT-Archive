using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct RatingObject(long game_id, long mod_id, long rating, long date_added)
{
	internal readonly long GameId = game_id;

	internal readonly long ModId = mod_id;

	internal readonly long Rating = rating;

	internal readonly long DateAdded = date_added;
}
