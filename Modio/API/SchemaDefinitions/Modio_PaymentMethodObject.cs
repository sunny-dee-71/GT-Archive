using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct PaymentMethodObject(string name, string id, long amount, string display_amount)
{
	internal readonly string Name = name;

	internal readonly string Id = id;

	internal readonly long Amount = amount;

	internal readonly string DisplayAmount = display_amount;
}
