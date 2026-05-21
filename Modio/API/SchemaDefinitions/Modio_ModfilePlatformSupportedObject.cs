using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct ModfilePlatformSupportedObject(string[] targetted, string[] approved, string[] denied, string[] live, string[] pending)
{
	internal readonly string[] Targetted = targetted;

	internal readonly string[] Approved = approved;

	internal readonly string[] Denied = denied;

	internal readonly string[] Live = live;

	internal readonly string[] Pending = pending;
}
