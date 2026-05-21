using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject(MemberSerialization.Fields)]
internal readonly struct ModDependantsObject(long mod_id, string name, string name_id, long status, long visible, long date_added, long date_updated, LogoObject logo)
{
	internal readonly long ModId = mod_id;

	internal readonly string Name = name;

	internal readonly string NameId = name_id;

	internal readonly long Status = status;

	internal readonly long Visible = visible;

	internal readonly long DateAdded = date_added;

	internal readonly long DateUpdated = date_updated;

	internal readonly LogoObject Logo = logo;
}
