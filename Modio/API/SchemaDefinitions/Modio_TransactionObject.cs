using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct TransactionObject(long id, string gateway_uuid, string gateway_name, long account_id, long gross_amount, long net_amount, long platform_fee, long gateway_fee, long tax, string tax_type, string currency, long tokens, string transaction_type, string monetization_type, string purchase_date, string created_at, PaymentMethodObject[] payment_method, LineItemsObject[] line_items)
{
	internal readonly long Id = id;

	internal readonly string GatewayUuid = gateway_uuid;

	internal readonly string GatewayName = gateway_name;

	internal readonly long AccountId = account_id;

	internal readonly long GrossAmount = gross_amount;

	internal readonly long NetAmount = net_amount;

	internal readonly long PlatformFee = platform_fee;

	internal readonly long GatewayFee = gateway_fee;

	internal readonly long Tax = tax;

	internal readonly string TaxType = tax_type;

	internal readonly string Currency = currency;

	internal readonly long Tokens = tokens;

	internal readonly string TransactionType = transaction_type;

	internal readonly string MonetizationType = monetization_type;

	internal readonly string PurchaseDate = purchase_date;

	internal readonly string CreatedAt = created_at;

	internal readonly PaymentMethodObject[] PaymentMethod = payment_method;

	internal readonly LineItemsObject[] LineItems = line_items;
}
