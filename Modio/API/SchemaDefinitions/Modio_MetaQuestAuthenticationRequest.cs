using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
public readonly struct MetaQuestAuthenticationRequest(string device, string nonce, string userId, string accessToken, bool termsAgreed, string? email, long dateExpires) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly string Device = device;

	internal readonly string Nonce = nonce;

	internal readonly string UserId = userId;

	internal readonly string AccessToken = accessToken;

	internal readonly bool TermsAgreed = termsAgreed;

	internal readonly string? Email = email;

	internal readonly long DateExpires = dateExpires;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("device", Device);
		_bodyParameters.Add("nonce", Nonce);
		_bodyParameters.Add("user_id", UserId);
		_bodyParameters.Add("access_token", AccessToken);
		_bodyParameters.Add("terms_agreed", TermsAgreed);
		if (!string.IsNullOrEmpty(Email))
		{
			_bodyParameters.Add("email", Email);
		}
		_bodyParameters.Add("date_expires", DateExpires);
		return _bodyParameters;
	}
}
