using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject(MemberSerialization.Fields)]
internal readonly struct ModPlatformsObject(string platform, long modfile_live)
{
	internal readonly string Platform = platform;

	internal readonly long ModfileLive = modfile_live;
}
