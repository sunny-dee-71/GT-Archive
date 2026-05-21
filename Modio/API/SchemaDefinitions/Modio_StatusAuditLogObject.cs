using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct StatusAuditLogObject(long status_new, long status_old, UserObject user, long date_added, string reason)
{
	internal readonly long StatusNew = status_new;

	internal readonly long StatusOld = status_old;

	internal readonly UserObject User = user;

	internal readonly long DateAdded = date_added;

	internal readonly string Reason = reason;
}
