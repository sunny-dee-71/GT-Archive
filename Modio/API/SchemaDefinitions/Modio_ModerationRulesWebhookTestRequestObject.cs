using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct ModerationRulesWebhookTestRequestObject(string url)
{
	internal readonly string Url = url;
}
