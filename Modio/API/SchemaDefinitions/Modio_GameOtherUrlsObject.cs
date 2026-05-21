using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct GameOtherUrlsObject(string label, string url)
{
	internal readonly string Label = label;

	internal readonly string Url = url;
}
