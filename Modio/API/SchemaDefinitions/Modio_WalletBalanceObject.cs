using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct WalletBalanceObject(long balance)
{
	internal readonly long Balance = balance;
}
