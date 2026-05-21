using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct PayRequest(long display_amount, bool subscribe, string idempotent_key) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly long DisplayAmount = display_amount;

	internal readonly bool Subscribe = subscribe;

	internal readonly string IdempotentKey = idempotent_key;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("display_amount", DisplayAmount);
		_bodyParameters.Add("subscribe", Subscribe);
		_bodyParameters.Add("idempotent_key", IdempotentKey);
		return _bodyParameters;
	}
}
