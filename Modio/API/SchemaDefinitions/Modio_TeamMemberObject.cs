using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct TeamMemberObject(long id, UserObject user, long level, long date_added, string position, long invite_pending)
{
	internal readonly long Id = id;

	internal readonly UserObject User = user;

	internal readonly long Level = level;

	internal readonly long DateAdded = date_added;

	internal readonly string Position = position;

	internal readonly long InvitePending = invite_pending;
}
