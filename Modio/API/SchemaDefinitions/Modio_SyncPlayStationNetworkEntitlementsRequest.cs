using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
public readonly struct SyncPlayStationNetworkEntitlementsRequest(string auth_code, long env, long service_label) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	public readonly string AuthCode = auth_code;

	public readonly long Env = env;

	public readonly long ServiceLabel = service_label;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("auth_code", AuthCode);
		_bodyParameters.Add("env", Env);
		_bodyParameters.Add("service_label", ServiceLabel);
		return _bodyParameters;
	}
}
