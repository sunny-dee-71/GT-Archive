using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct ErrorObject(ErrorObject.EmbeddedError error)
{
	[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
	internal readonly struct EmbeddedError(long code, long errorRef, string message, JObject errors)
	{
		internal readonly long Code = code;

		internal readonly long ErrorRef = errorRef;

		internal readonly string Message = message;

		internal readonly JObject Errors = errors;
	}

	internal readonly EmbeddedError Error = error;
}
