using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Modio.API.SchemaDefinitions;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
internal readonly struct MetricsSessionRequest(string sessionId, long sessionTs, string sessionHash, string sessionNonce, long sessionOrderId, long[] ids) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly string SessionId = sessionId;

	internal readonly long SessionTs = sessionTs;

	internal readonly string SessionHash = sessionHash;

	internal readonly string SessionNonce = sessionNonce;

	internal readonly long SessionOrderId = sessionOrderId;

	internal readonly long[] Ids = ids;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("session_id", SessionId);
		_bodyParameters.Add("session_ts", SessionTs);
		_bodyParameters.Add("session_hash", SessionHash);
		_bodyParameters.Add("session_nonce", SessionNonce);
		_bodyParameters.Add("session_order_id", SessionOrderId);
		if (Ids != null)
		{
			_bodyParameters.Add("ids", Ids);
		}
		return _bodyParameters;
	}
}
