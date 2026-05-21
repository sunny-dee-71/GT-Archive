using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
public readonly struct EntitlementFulfillmentObject(string transaction_id, long transaction_state, string sku_id, bool entitlement_consumed, long entitlement_type, EntitlementDetailsObject details)
{
	internal readonly string TransactionId = transaction_id;

	internal readonly long TransactionState = transaction_state;

	internal readonly string SkuId = sku_id;

	internal readonly bool EntitlementConsumed = entitlement_consumed;

	internal readonly long EntitlementType = entitlement_type;

	internal readonly EntitlementDetailsObject Details = details;
}
