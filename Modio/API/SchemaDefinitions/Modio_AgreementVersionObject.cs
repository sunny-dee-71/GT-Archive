using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct AgreementVersionObject(long id, bool is_active, bool is_latest, long type, UserObject user, long date_added, long date_updated, long date_live, string name, string changelog, string description, JObject adjacent_versions)
{
	internal readonly long Id = id;

	internal readonly bool IsActive = is_active;

	internal readonly bool IsLatest = is_latest;

	internal readonly long Type = type;

	internal readonly UserObject User = user;

	internal readonly long DateAdded = date_added;

	internal readonly long DateUpdated = date_updated;

	internal readonly long DateLive = date_live;

	internal readonly string Name = name;

	internal readonly string Changelog = changelog;

	internal readonly string Description = description;

	internal readonly JObject AdjacentVersions = adjacent_versions;
}
