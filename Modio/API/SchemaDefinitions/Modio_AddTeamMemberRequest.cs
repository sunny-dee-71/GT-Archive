using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct AddTeamMemberRequest(string email, long to_user_id, string position, long level) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly string Email = email;

	internal readonly long ToUserId = to_user_id;

	internal readonly string Position = position;

	internal readonly long Level = level;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("email", Email);
		_bodyParameters.Add("to_user_id", ToUserId);
		_bodyParameters.Add("position", Position);
		_bodyParameters.Add("level", Level);
		return _bodyParameters;
	}
}
