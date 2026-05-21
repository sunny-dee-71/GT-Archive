using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
public readonly struct GameTokenPackObject(long id, long token_pack_id, long price, long amount, string portal, string sku, string name, string description, long date_added, long date_updated)
{
	public readonly long Id = id;

	public readonly long TokenPackId = token_pack_id;

	public readonly long Price = price;

	public readonly long Amount = amount;

	public readonly string Portal = portal;

	public readonly string Sku = sku;

	public readonly string Name = name;

	public readonly string Description = description;

	public readonly long DateAdded = date_added;

	public readonly long DateUpdated = date_updated;
}
