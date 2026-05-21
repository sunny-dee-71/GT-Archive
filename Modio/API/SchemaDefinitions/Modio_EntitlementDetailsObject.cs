using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
public readonly struct EntitlementDetailsObject(long tokens_allocated)
{
	internal readonly long TokensAllocated = tokens_allocated;
}
