using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct GuideTagObject(string name, long date_added, long count)
{
	internal readonly string Name = name;

	internal readonly long DateAdded = date_added;

	internal readonly long Count = count;
}
