using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct AddRatingResponse(long code, string message)
{
	internal readonly long Code = code;

	internal readonly string Message = message;
}
