using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject(MemberSerialization.Fields)]
internal readonly struct ModTagObject(string name, string name_localized, long date_added)
{
	internal readonly string Name = name;

	internal readonly string NameLocalized = name_localized;

	internal readonly long DateAdded = date_added;
}
