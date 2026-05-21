using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject(MemberSerialization.Fields)]
internal readonly struct ModfilePlatformObject(string platform, long status)
{
	internal readonly string Platform = platform;

	internal readonly long Status = status;
}
