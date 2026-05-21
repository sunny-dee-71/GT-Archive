using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct HeaderImageObject(string filename, string original)
{
	internal readonly string Filename = filename;

	internal readonly string Original = original;
}
