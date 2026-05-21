using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct S2SPayObject(long transaction_id, string gateway_uuid, long gross_amount, long net_amount, long platform_fee, long gateway_fee, string transaction_type, JObject meta, long purchase_date)
{
	internal readonly long TransactionId = transaction_id;

	internal readonly string GatewayUuid = gateway_uuid;

	internal readonly long GrossAmount = gross_amount;

	internal readonly long NetAmount = net_amount;

	internal readonly long PlatformFee = platform_fee;

	internal readonly long GatewayFee = gateway_fee;

	internal readonly string TransactionType = transaction_type;

	internal readonly JObject Meta = meta;

	internal readonly long PurchaseDate = purchase_date;
}
