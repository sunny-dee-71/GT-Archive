using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct AdminEditModStatusRequest(long status, string reason) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly long Status = status;

	internal readonly string Reason = reason;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("status", Status);
		_bodyParameters.Add("reason", Reason);
		return _bodyParameters;
	}
}
