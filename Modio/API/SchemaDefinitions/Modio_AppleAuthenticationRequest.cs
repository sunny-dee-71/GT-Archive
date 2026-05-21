using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct AppleAuthenticationRequest(string id_token, bool terms_agreed, long date_expires) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly string IdToken = id_token;

	internal readonly bool TermsAgreed = terms_agreed;

	internal readonly long DateExpires = date_expires;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("id_token", IdToken);
		_bodyParameters.Add("terms_agreed", TermsAgreed);
		_bodyParameters.Add("date_expires", DateExpires);
		return _bodyParameters;
	}
}
