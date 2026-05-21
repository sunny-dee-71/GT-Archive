using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct S2SCommitRequest(long transaction_id, string clawback_uuid) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly long TransactionId = transaction_id;

	internal readonly string ClawbackUuid = clawback_uuid;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("transaction_id", TransactionId);
		_bodyParameters.Add("clawback_uuid", ClawbackUuid);
		return _bodyParameters;
	}
}
