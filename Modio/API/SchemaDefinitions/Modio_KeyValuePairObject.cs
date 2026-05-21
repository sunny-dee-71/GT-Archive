using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct KeyValuePairObject(string key, string value)
{
	internal readonly string Key = key;

	internal readonly string Value = value;
}
