using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct ContactRequest(string email, string subject, string message) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly string Email = email;

	internal readonly string Subject = subject;

	internal readonly string Message = message;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("email", Email);
		_bodyParameters.Add("subject", Subject);
		_bodyParameters.Add("message", Message);
		return _bodyParameters;
	}
}
