using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct GamePlatformsObject(string platform, string label, bool moderated, bool locked)
{
	internal readonly string Platform = platform;

	internal readonly string Label = label;

	internal readonly bool Moderated = moderated;

	internal readonly bool Locked = locked;
}
