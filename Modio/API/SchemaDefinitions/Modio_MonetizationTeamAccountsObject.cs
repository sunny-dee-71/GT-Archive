using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct MonetizationTeamAccountsObject(long id, string name_id, string username, long monetization_status, long monetization_options, long split)
{
	internal readonly long Id = id;

	internal readonly string NameId = name_id;

	internal readonly string Username = username;

	internal readonly long MonetizationStatus = monetization_status;

	internal readonly long MonetizationOptions = monetization_options;

	internal readonly long Split = split;
}
