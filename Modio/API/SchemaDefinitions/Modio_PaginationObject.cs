using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct PaginationObject(long per_page, string current_page, long next_page_url, long prev_page_url)
{
	internal readonly long PerPage = per_page;

	internal readonly string CurrentPage = current_page;

	internal readonly long NextPageUrl = next_page_url;

	internal readonly long PrevPageUrl = prev_page_url;
}
