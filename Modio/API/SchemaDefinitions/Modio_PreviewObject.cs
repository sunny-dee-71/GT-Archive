using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct PreviewObject(string resource_url, long date_added, long date_updated)
{
	internal readonly string ResourceUrl = resource_url;

	internal readonly long DateAdded = date_added;

	internal readonly long DateUpdated = date_updated;
}
