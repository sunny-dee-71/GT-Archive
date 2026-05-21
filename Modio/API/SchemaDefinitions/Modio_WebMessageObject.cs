using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct WebMessageObject(long code, bool success, string message)
{
	internal readonly long Code = code;

	internal readonly bool Success = success;

	internal readonly string Message = message;
}
