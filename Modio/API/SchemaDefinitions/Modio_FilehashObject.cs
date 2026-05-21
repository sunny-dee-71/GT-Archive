using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct FilehashObject(string md5)
{
	internal readonly string Md5 = md5;
}
