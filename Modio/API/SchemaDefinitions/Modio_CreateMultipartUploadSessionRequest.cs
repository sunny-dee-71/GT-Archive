using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct CreateMultipartUploadSessionRequest(string filename, string nonce) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly string Filename = filename;

	internal readonly string Nonce = nonce;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("filename", Filename);
		_bodyParameters.Add("nonce", Nonce);
		return _bodyParameters;
	}
}
