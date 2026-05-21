using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct GameTagOptionLocalizedObject(string name, string name_localized, string type, string[] tags, JObject tags_localized, JObject tag_count_map, bool hidden, bool locked)
{
	internal readonly string Name = name;

	internal readonly string NameLocalized = name_localized;

	internal readonly string Type = type;

	internal readonly string[] Tags = tags;

	internal readonly JObject TagsLocalized = tags_localized;

	internal readonly JObject TagCountMap = tag_count_map;

	internal readonly bool Hidden = hidden;

	internal readonly bool Locked = locked;
}
