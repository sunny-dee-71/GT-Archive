using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct ClawbackRequest(long transaction_id, long gateway_uuid, string portal, string refund_reason, string clawback_uuid) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly long TransactionId = transaction_id;

	internal readonly long GatewayUuid = gateway_uuid;

	internal readonly string Portal = portal;

	internal readonly string RefundReason = refund_reason;

	internal readonly string ClawbackUuid = clawback_uuid;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("transaction_id", TransactionId);
		_bodyParameters.Add("gateway_uuid", GatewayUuid);
		_bodyParameters.Add("portal", Portal);
		_bodyParameters.Add("refund_reason", RefundReason);
		_bodyParameters.Add("clawback_uuid", ClawbackUuid);
		return _bodyParameters;
	}
}
