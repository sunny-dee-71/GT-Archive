using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct AddCommentRequest(long replyid, string content) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly long Replyid = replyid;

	internal readonly string Content = content;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("replyid", Replyid);
		_bodyParameters.Add("content", Content);
		return _bodyParameters;
	}
}
