using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
public readonly struct SteamAuthenticationRequest(string appdata, bool termsAgreed, string? email, long dateExpires) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly string Appdata = appdata;

	internal readonly bool TermsAgreed = termsAgreed;

	internal readonly string? Email = email;

	internal readonly long DateExpires = dateExpires;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("appdata", Appdata);
		_bodyParameters.Add("terms_agreed", TermsAgreed);
		if (!string.IsNullOrEmpty(Email))
		{
			_bodyParameters.Add("email", Email);
		}
		_bodyParameters.Add("date_expires", DateExpires);
		return _bodyParameters;
	}
}
