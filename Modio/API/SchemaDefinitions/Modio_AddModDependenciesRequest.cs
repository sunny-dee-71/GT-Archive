using System.Collections.Generic;
using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct AddModDependenciesRequest(long[] dependencies, bool sync) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly long[] Dependencies = dependencies;

	internal readonly bool Sync = sync;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("dependencies", Dependencies);
		_bodyParameters.Add("sync", Sync);
		return _bodyParameters;
	}
}
