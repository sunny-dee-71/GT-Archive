using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Modio.API.SchemaDefinitions;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
internal readonly struct AddBatchRequest(string batch0RelativeUrl, string batch0Method, string batch1RelativeUrl, string batch1Method, string batch2RelativeUrl, string batch2Method) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly string Batch0RelativeUrl = batch0RelativeUrl;

	internal readonly string Batch0Method = batch0Method;

	internal readonly string Batch1RelativeUrl = batch1RelativeUrl;

	internal readonly string Batch1Method = batch1Method;

	internal readonly string Batch2RelativeUrl = batch2RelativeUrl;

	internal readonly string Batch2Method = batch2Method;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("batch[0][relative_url]", Batch0RelativeUrl);
		_bodyParameters.Add("batch[0][method]", Batch0Method);
		_bodyParameters.Add("batch[1][relative_url]", Batch1RelativeUrl);
		_bodyParameters.Add("batch[1][method]", Batch1Method);
		_bodyParameters.Add("batch[2][relative_url]", Batch2RelativeUrl);
		_bodyParameters.Add("batch[2][method]", Batch2Method);
		return _bodyParameters;
	}
}
