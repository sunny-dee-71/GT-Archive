using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Modio.API.SchemaDefinitions;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
internal readonly struct GameEmhObject(long id, long status, long communityOptions, string ugcName, string name, string nameId, GameTagOptionLocalizedObject[] tagOptions, ThemeObject theme, GamePlatformsObject[] platforms)
{
	internal readonly long Id = id;

	internal readonly long Status = status;

	internal readonly long CommunityOptions = communityOptions;

	internal readonly string UgcName = ugcName;

	internal readonly string Name = name;

	internal readonly string NameId = nameId;

	internal readonly GameTagOptionLocalizedObject[] TagOptions = tagOptions;

	internal readonly ThemeObject Theme = theme;

	internal readonly GamePlatformsObject[] Platforms = platforms;
}
