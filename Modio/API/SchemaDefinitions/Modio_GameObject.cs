using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Modio.API.SchemaDefinitions;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
internal readonly struct GameObject(long id, long status, JObject submittedBy, long dateAdded, long dateUpdated, long dateLive, long presentationOption, long submissionOption, long dependencyOption, long curationOption, long communityOptions, long monetizationOptions, GameMonetizationTeamObject monetizationTeam, long revenueOptions, long maxStock, long apiAccessOptions, long maturityOptions, string ugcName, string tokenName, IconObject icon, LogoObject logo, HeaderImageObject header, string name, string nameId, string summary, string instructions, string instructionsUrl, string profileUrl, GameOtherUrlsObject[] otherUrls, GameTagOptionLocalizedObject[] tagOptions, GameStatsObject stats, ThemeObject theme, GamePlatformsObject[] platforms)
{
	internal readonly long Id = id;

	internal readonly long Status = status;

	internal readonly JObject SubmittedBy = submittedBy;

	internal readonly long DateAdded = dateAdded;

	internal readonly long DateUpdated = dateUpdated;

	internal readonly long DateLive = dateLive;

	internal readonly long PresentationOption = presentationOption;

	internal readonly long SubmissionOption = submissionOption;

	internal readonly long DependencyOption = dependencyOption;

	internal readonly long CurationOption = curationOption;

	internal readonly long CommunityOptions = communityOptions;

	internal readonly long MonetizationOptions = monetizationOptions;

	internal readonly GameMonetizationTeamObject MonetizationTeam = monetizationTeam;

	internal readonly long RevenueOptions = revenueOptions;

	internal readonly long MaxStock = maxStock;

	internal readonly long ApiAccessOptions = apiAccessOptions;

	internal readonly long MaturityOptions = maturityOptions;

	internal readonly string UgcName = ugcName;

	internal readonly string TokenName = tokenName;

	internal readonly IconObject Icon = icon;

	internal readonly LogoObject Logo = logo;

	internal readonly HeaderImageObject Header = header;

	internal readonly string Name = name;

	internal readonly string NameId = nameId;

	internal readonly string Summary = summary;

	internal readonly string Instructions = instructions;

	internal readonly string InstructionsUrl = instructionsUrl;

	internal readonly string ProfileUrl = profileUrl;

	internal readonly GameOtherUrlsObject[] OtherUrls = otherUrls;

	internal readonly GameTagOptionLocalizedObject[] TagOptions = tagOptions;

	internal readonly GameStatsObject Stats = stats;

	internal readonly ThemeObject Theme = theme;

	internal readonly GamePlatformsObject[] Platforms = platforms;
}
