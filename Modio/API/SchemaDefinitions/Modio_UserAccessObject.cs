using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct UserAccessObject(string resource_type, long resource_id, long resource_name, string resource_name_id, string resource_url)
{
	internal readonly string ResourceType = resource_type;

	internal readonly long ResourceId = resource_id;

	internal readonly long ResourceName = resource_name;

	internal readonly string ResourceNameId = resource_name_id;

	internal readonly string ResourceUrl = resource_url;
}
