using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject(MemberSerialization.Fields)]
internal readonly struct ModObject(long id, long game_id, long status, long visible, UserObject submitted_by, long date_added, long date_updated, long date_live, long maturity_option, long community_options, long monetization_options, long credit_options, long stock, long price, long tax, LogoObject logo, string homepage_url, string name, string name_id, string summary, string description, string description_plaintext, string metadata_blob, string profile_url, ModMediaObject media, ModfileObject modfile, bool dependencies, ModPlatformsObject[] platforms, MetadataKvpObject[] metadata_kvp, ModTagObject[] tags, ModStatsObject stats)
{
	internal readonly long Id = id;

	internal readonly long GameId = game_id;

	internal readonly long Status = status;

	internal readonly long Visible = visible;

	internal readonly UserObject SubmittedBy = submitted_by;

	internal readonly long DateAdded = date_added;

	internal readonly long DateUpdated = date_updated;

	internal readonly long DateLive = date_live;

	internal readonly long MaturityOption = maturity_option;

	internal readonly long CommunityOptions = community_options;

	internal readonly long MonetizationOptions = monetization_options;

	internal readonly long CreditOptions = credit_options;

	internal readonly long Stock = stock;

	internal readonly long Price = price;

	internal readonly long Tax = tax;

	internal readonly LogoObject Logo = logo;

	internal readonly string HomepageUrl = homepage_url;

	internal readonly string Name = name;

	internal readonly string NameId = name_id;

	internal readonly string Summary = summary;

	internal readonly string Description = description;

	internal readonly string DescriptionPlaintext = description_plaintext;

	internal readonly string MetadataBlob = metadata_blob;

	internal readonly string ProfileUrl = profile_url;

	internal readonly ModMediaObject Media = media;

	internal readonly ModfileObject Modfile = modfile;

	internal readonly bool Dependencies = dependencies;

	internal readonly ModPlatformsObject[] Platforms = platforms;

	internal readonly MetadataKvpObject[] MetadataKvp = metadata_kvp;

	internal readonly ModTagObject[] Tags = tags;

	internal readonly ModStatsObject Stats = stats;

	public static ModObject GetHiddenModObject(long modId, long modFileId)
	{
		return new ModObject(modId, ModioServices.Resolve<ModioSettings>().GameId, 1L, 0L, new UserObject(-1L, "", "", "", -1L, -1L, new AvatarObject("", "", "", ""), "", "", ""), -1L, -1L, -1L, 0L, 0L, 0L, 0L, 0L, 0L, 0L, new LogoObject("", "", "", "", ""), "", "HIDDEN", "", "You don't currently have access to this hidden mod.\nCheck that you're logged in to the correct mod.io account.", "<p>You don't currently have access to this hidden mod.\nCheck that you're logged in to the correct mod.io account.</p>", "You don't currently have access to this hidden mod.\nCheck that you're logged in to the correct mod.io account.\n", "", "", new ModMediaObject(new string[0], new string[0], new ImageObject[0]), new ModfileObject(modFileId, modId, -1L, -1L, -1L, 1L, 0L, null, 0L, 0L, new FilehashObject(""), "", null, null, null, new DownloadObject("", -1L), new ModfilePlatformObject[0]), dependencies: false, new ModPlatformsObject[0], new MetadataKvpObject[0], new ModTagObject[0], new ModStatsObject(-1L, -1L, -1L, 0L, 0L, 0L, 0L, 0L, 0L, 0L, 0f, "", -1L));
	}
}
