using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct EditGuideRequest(string name, string summary, string description, ModioAPIFileParameter logo, long date_live) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly string Name = name;

	internal readonly string Summary = summary;

	internal readonly string Description = description;

	internal readonly ModioAPIFileParameter Logo = logo;

	internal readonly long DateLive = date_live;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("name", Name);
		_bodyParameters.Add("summary", Summary);
		_bodyParameters.Add("description", Description);
		_bodyParameters.Add("logo", Logo);
		_bodyParameters.Add("date_live", DateLive);
		return _bodyParameters;
	}
}
