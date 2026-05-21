using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct LineItemsObject(long game_id, long buyer_id, string game_name, string buyer_name, string token_name, long token_pack_id, string token_pack_name)
{
	internal readonly long GameId = game_id;

	internal readonly long BuyerId = buyer_id;

	internal readonly string GameName = game_name;

	internal readonly string BuyerName = buyer_name;

	internal readonly string TokenName = token_name;

	internal readonly long TokenPackId = token_pack_id;

	internal readonly string TokenPackName = token_pack_name;
}
