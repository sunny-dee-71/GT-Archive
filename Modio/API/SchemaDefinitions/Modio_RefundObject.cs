using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct RefundObject(long transaction_id, long gross_amount, long net_amount, long platform_fee, long gateway_fee, long tax, string tax_type, string transaction_type, JObject meta, long purchase_date)
{
	internal readonly long TransactionId = transaction_id;

	internal readonly long GrossAmount = gross_amount;

	internal readonly long NetAmount = net_amount;

	internal readonly long PlatformFee = platform_fee;

	internal readonly long GatewayFee = gateway_fee;

	internal readonly long Tax = tax;

	internal readonly string TaxType = tax_type;

	internal readonly string TransactionType = transaction_type;

	internal readonly JObject Meta = meta;

	internal readonly long PurchaseDate = purchase_date;
}
