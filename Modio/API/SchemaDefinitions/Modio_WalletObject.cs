using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct WalletObject(string type, string payment_method_id, string game_id, string currency, long balance, long pending_balance, long deficit, long monetization_status)
{
	internal readonly string Type = type;

	internal readonly string PaymentMethodId = payment_method_id;

	internal readonly string GameId = game_id;

	internal readonly string Currency = currency;

	internal readonly long Balance = balance;

	internal readonly long PendingBalance = pending_balance;

	internal readonly long Deficit = deficit;

	internal readonly long MonetizationStatus = monetization_status;
}
