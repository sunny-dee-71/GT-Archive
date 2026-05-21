using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct EditOpenIdConfigRequest(string jwk_url, string aud, string display_name_claim, string avatar_url_claim) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly string JwkUrl = jwk_url;

	internal readonly string Aud = aud;

	internal readonly string DisplayNameClaim = display_name_claim;

	internal readonly string AvatarUrlClaim = avatar_url_claim;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("jwk_url", JwkUrl);
		_bodyParameters.Add("aud", Aud);
		_bodyParameters.Add("display_name_claim", DisplayNameClaim);
		_bodyParameters.Add("avatar_url_claim", AvatarUrlClaim);
		return _bodyParameters;
	}
}
