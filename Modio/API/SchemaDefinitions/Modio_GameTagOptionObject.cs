using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct GameTagOptionObject(string name, Dictionary<string, string> name_localization, string type, string[] tags, GameTagOptionObject.EmbeddedTagsLocalization[] tags_localization, Dictionary<string, int> tag_count_map, bool hidden, bool locked)
{
	[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
	internal readonly struct EmbeddedTagsLocalization(string tag, Dictionary<string, string> translations)
	{
		internal readonly string Tag = tag;

		internal readonly Dictionary<string, string> Translations = translations;
	}

	internal readonly string Name = name;

	internal readonly Dictionary<string, string> NameLocalization = name_localization;

	internal readonly string Type = type;

	internal readonly string[] Tags = tags;

	internal readonly EmbeddedTagsLocalization[] TagsLocalization = tags_localization;

	internal readonly Dictionary<string, int> TagCountMap = tag_count_map;

	internal readonly bool Hidden = hidden;

	internal readonly bool Locked = locked;
}
