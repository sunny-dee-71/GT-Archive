using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
public readonly struct AccessTokenObject(long code, string access_token, long date_expires)
{
	public readonly long Code = code;

	public readonly string AccessToken = access_token;

	public readonly long DateExpires = date_expires;
}
