using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct ProxyTransformerObject(bool success)
{
	internal readonly bool Success = success;
}
