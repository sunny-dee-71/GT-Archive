using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Modio.API.SchemaDefinitions;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
internal readonly struct ThemeObject(string primary, string dark, string light, string success, string warning, string danger)
{
	internal readonly string Primary = primary;

	internal readonly string Dark = dark;

	internal readonly string Light = light;

	internal readonly string Success = success;

	internal readonly string Warning = warning;

	internal readonly string Danger = danger;
}
