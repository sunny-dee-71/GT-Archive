using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct OpenIdAuthenticationRequest(string id_token, bool terms_agreed, string email, long date_expires, bool monetization_account) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly string IdToken = id_token;

	internal readonly bool TermsAgreed = terms_agreed;

	internal readonly string Email = email;

	internal readonly long DateExpires = date_expires;

	internal readonly bool MonetizationAccount = monetization_account;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("id_token", IdToken);
		_bodyParameters.Add("terms_agreed", TermsAgreed);
		_bodyParameters.Add("email", Email);
		_bodyParameters.Add("date_expires", DateExpires);
		_bodyParameters.Add("monetization_account", MonetizationAccount);
		return _bodyParameters;
	}
}
