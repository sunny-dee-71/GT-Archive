using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Modio.API.SchemaDefinitions;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
internal readonly struct EditModRequest(string? name, string? nameId, string? summary, string? description, ModioAPIFileParameter? logo, long? visible, long? maturity_option, long? community_options, string? metadataBlob, string[]? tags, long? monetizationOptions, long? price, long? stock) : IApiRequest
{
	private static readonly Dictionary<string, object> _bodyParameters = new Dictionary<string, object>();

	internal readonly string? Name = name;

	internal readonly string? NameId = nameId;

	internal readonly string? Summary = summary;

	internal readonly string? Description = description;

	internal readonly ModioAPIFileParameter? Logo = logo;

	internal readonly long? Visible = visible;

	internal readonly long? MaturityOption = maturity_option;

	internal readonly long? CommunityOptions = community_options;

	internal readonly string? MetadataBlob = metadataBlob;

	internal readonly string[]? Tags = tags;

	internal readonly long? MonetizationOptions = monetizationOptions;

	internal readonly long? Price = price;

	internal readonly long? Stock = stock;

	public IReadOnlyDictionary<string, object> GetBodyParameters()
	{
		_bodyParameters.Clear();
		if (!string.IsNullOrEmpty(Name))
		{
			_bodyParameters.Add("name", Name);
		}
		if (!string.IsNullOrEmpty(NameId))
		{
			_bodyParameters.Add("name_id", NameId);
		}
		if (!string.IsNullOrEmpty(Summary))
		{
			_bodyParameters.Add("summary", Summary);
		}
		if (!string.IsNullOrEmpty(Description))
		{
			_bodyParameters.Add("description", Description);
		}
		if (Logo.HasValue)
		{
			_bodyParameters.Add("logo", Logo);
		}
		if (Visible.HasValue)
		{
			_bodyParameters.Add("visible", Visible);
		}
		if (MaturityOption.HasValue)
		{
			_bodyParameters.Add("maturity_option", MaturityOption);
		}
		if (CommunityOptions.HasValue)
		{
			_bodyParameters.Add("community_options", CommunityOptions);
		}
		if (!string.IsNullOrEmpty(MetadataBlob))
		{
			_bodyParameters.Add("metadata_blob", MetadataBlob);
		}
		if (Tags != null)
		{
			_bodyParameters.Add("tags", Tags);
		}
		if (MonetizationOptions.HasValue)
		{
			_bodyParameters.Add("monetization_options", MonetizationOptions);
		}
		if (Price.HasValue)
		{
			_bodyParameters.Add("price", Price);
		}
		if (Stock.HasValue)
		{
			_bodyParameters.Add("stock", Stock);
		}
		return _bodyParameters;
	}
}
