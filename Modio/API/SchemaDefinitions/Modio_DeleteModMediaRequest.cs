using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct DeleteModMediaRequest(string[] images, string[] youtube, string[] sketchfab) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly string[] Images = images;

	internal readonly string[] Youtube = youtube;

	internal readonly string[] Sketchfab = sketchfab;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("images", Images);
		_bodyParameters.Add("youtube", Youtube);
		_bodyParameters.Add("sketchfab", Sketchfab);
		return _bodyParameters;
	}
}
