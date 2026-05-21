using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct ItchioAuthenticationRequest(string itchio_token, bool terms_agreed, string email, long date_expires) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly string ItchioToken = itchio_token;

	internal readonly bool TermsAgreed = terms_agreed;

	internal readonly string Email = email;

	internal readonly long DateExpires = date_expires;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("itchio_token", ItchioToken);
		_bodyParameters.Add("terms_agreed", TermsAgreed);
		_bodyParameters.Add("email", Email);
		_bodyParameters.Add("date_expires", DateExpires);
		return _bodyParameters;
	}
}
