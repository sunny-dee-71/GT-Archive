using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct GetTransactions(TransactionObject[] data, PaginationObject download)
{
	internal readonly TransactionObject[] Data = data;

	internal readonly PaginationObject Download = download;
}
