using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct AddGuideRequest(string name, string summary, string description, string logo, long date_live, long status, long community_options, string[] tags, string name_id) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly string Name = name;

	internal readonly string Summary = summary;

	internal readonly string Description = description;

	internal readonly string Logo = logo;

	internal readonly long DateLive = date_live;

	internal readonly long Status = status;

	internal readonly long CommunityOptions = community_options;

	internal readonly string[] Tags = tags;

	internal readonly string NameId = name_id;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("name", Name);
		_bodyParameters.Add("summary", Summary);
		_bodyParameters.Add("description", Description);
		_bodyParameters.Add("logo", Logo);
		_bodyParameters.Add("date_live", DateLive);
		_bodyParameters.Add("status", Status);
		_bodyParameters.Add("community_options", CommunityOptions);
		_bodyParameters.Add("tags", Tags);
		_bodyParameters.Add("name_id", NameId);
		return _bodyParameters;
	}
}
