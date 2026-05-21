using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Modio.API.SchemaDefinitions;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
internal readonly struct AddModfileRequest(ModioAPIFileParameter filedata, string? version, string? changelog, string? metadataBlob, string[]? platforms, string? uploadId) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly ModioAPIFileParameter Filedata = filedata;

	internal readonly string? Version = version;

	internal readonly string? Changelog = changelog;

	internal readonly string? MetadataBlob = metadataBlob;

	internal readonly string[]? Platforms = platforms;

	internal readonly string? UploadId = uploadId;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		_bodyParameters.Add("filedata", Filedata);
		if (string.IsNullOrEmpty(Version))
		{
			_bodyParameters.Add("version", Version);
		}
		if (string.IsNullOrEmpty(Changelog))
		{
			_bodyParameters.Add("changelog", Changelog);
		}
		if (string.IsNullOrEmpty(MetadataBlob))
		{
			_bodyParameters.Add("metadata_blob", MetadataBlob);
		}
		if (Platforms != null && Platforms.Length != 0)
		{
			for (int i = 0; i < Platforms.Length; i++)
			{
				_bodyParameters.Add($"platforms[{i}]", Platforms[i]);
			}
		}
		if (string.IsNullOrEmpty(UploadId))
		{
			_bodyParameters.Add("upload_id", UploadId);
		}
		return _bodyParameters;
	}
}
