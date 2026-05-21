using Modio.API;

namespace Modio.Monetization;

public struct PortalSku(ModioAPI.Portal portal, string sku, string name, string formattedPrice, int value)
{
	public readonly ModioAPI.Portal Portal = portal;

	public readonly string Sku = sku;

	public readonly string Name = name;

	public readonly string FormattedPrice = formattedPrice;

	public readonly int Value = value;
}
