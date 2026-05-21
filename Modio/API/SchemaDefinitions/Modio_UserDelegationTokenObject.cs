using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct UserDelegationTokenObject(string entity, string token)
{
	internal readonly string Entity = entity;

	internal readonly string Token = token;
}
