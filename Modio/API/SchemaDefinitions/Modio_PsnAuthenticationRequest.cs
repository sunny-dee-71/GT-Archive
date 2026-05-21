using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
public readonly struct PsnAuthenticationRequest(string auth_code, bool terms_agreed, string? email, int environment, long date_expires) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	public readonly string AuthCode = auth_code;

	public readonly bool TermsAgreed = terms_agreed;

	public readonly string? Email = email;

	public readonly int Environment = environment;

	internal readonly long DateExpires = date_expires;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("auth_code", AuthCode);
		_bodyParameters.Add("terms_agreed", TermsAgreed);
		if (!string.IsNullOrEmpty(Email))
		{
			_bodyParameters.Add("email", Email);
		}
		_bodyParameters.Add("env", Environment);
		_bodyParameters.Add("date_expires", DateExpires);
		return _bodyParameters;
	}
}
