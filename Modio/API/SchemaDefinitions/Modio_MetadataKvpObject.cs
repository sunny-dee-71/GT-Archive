using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject(MemberSerialization.Fields)]
internal readonly struct MetadataKvpObject(string metakey, string metavalue)
{
	internal readonly string Metakey = metakey;

	internal readonly string Metavalue = metavalue;
}
