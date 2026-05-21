using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct EmbeddableModHubConfigurationObject(long id, string name, string[] urls, string style, string css, bool allow_subscribing, bool allow_rating, bool allow_reporting, bool allow_downloading, bool allow_commenting, bool allow_filtering, bool allow_searching, bool allow_infinite_scroll, bool allow_email_auth, bool allow_sso_auth, bool allow_steam_auth, bool allow_PSN_auth, bool allow_xbox_auth, bool allow_egs_auth, bool allow_discord_auth, bool allow_google_auth, bool show_collection, bool show_comments, bool show_guides, bool show_user_avatars, bool show_sort_tabs, bool allow_links, bool filter_right_side, bool name_right_side, long results_per_page, long min_age, long date_added, long date_updated, string company_name, object[] agreement_urls)
{
	internal readonly long Id = id;

	internal readonly string Name = name;

	internal readonly string[] Urls = urls;

	internal readonly string Style = style;

	internal readonly string Css = css;

	internal readonly bool AllowSubscribing = allow_subscribing;

	internal readonly bool AllowRating = allow_rating;

	internal readonly bool AllowReporting = allow_reporting;

	internal readonly bool AllowDownloading = allow_downloading;

	internal readonly bool AllowCommenting = allow_commenting;

	internal readonly bool AllowFiltering = allow_filtering;

	internal readonly bool AllowSearching = allow_searching;

	internal readonly bool AllowInfiniteScroll = allow_infinite_scroll;

	internal readonly bool AllowEmailAuth = allow_email_auth;

	internal readonly bool AllowSsoAuth = allow_sso_auth;

	internal readonly bool AllowSteamAuth = allow_steam_auth;

	internal readonly bool AllowPsnAuth = allow_PSN_auth;

	internal readonly bool AllowXboxAuth = allow_xbox_auth;

	internal readonly bool AllowEgsAuth = allow_egs_auth;

	internal readonly bool AllowDiscordAuth = allow_discord_auth;

	internal readonly bool AllowGoogleAuth = allow_google_auth;

	internal readonly bool ShowCollection = show_collection;

	internal readonly bool ShowComments = show_comments;

	internal readonly bool ShowGuides = show_guides;

	internal readonly bool ShowUserAvatars = show_user_avatars;

	internal readonly bool ShowSortTabs = show_sort_tabs;

	internal readonly bool AllowLinks = allow_links;

	internal readonly bool FilterRightSide = filter_right_side;

	internal readonly bool NameRightSide = name_right_side;

	internal readonly long ResultsPerPage = results_per_page;

	internal readonly long MinAge = min_age;

	internal readonly long DateAdded = date_added;

	internal readonly long DateUpdated = date_updated;

	internal readonly string CompanyName = company_name;

	internal readonly object[] AgreementUrls = agreement_urls;
}
