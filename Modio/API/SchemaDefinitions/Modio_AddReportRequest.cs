using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct AddReportRequest(string resource, long id, long type, long reason, string platforms, string name, string contact, string summary) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly string Resource = resource;

	internal readonly long Id = id;

	internal readonly long Type = type;

	internal readonly long Reason = reason;

	internal readonly string Platforms = platforms;

	internal readonly string Name = name;

	internal readonly string Contact = contact;

	internal readonly string Summary = summary;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("resource", Resource);
		_bodyParameters.Add("id", Id);
		_bodyParameters.Add("type", Type);
		_bodyParameters.Add("reason", Reason);
		_bodyParameters.Add("platforms", Platforms);
		_bodyParameters.Add("name", Name);
		_bodyParameters.Add("contact", Contact);
		_bodyParameters.Add("summary", Summary);
		return _bodyParameters;
	}
}
