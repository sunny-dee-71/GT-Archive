using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct TermsObject(string plaintext, string html, TermsObject.EmbeddedButtons buttons, TermsObject.EmbeddedLinks links)
{
	[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
	internal readonly struct EmbeddedButtons(EmbeddedButtons.EmbeddedAgree agree, EmbeddedButtons.EmbeddedDisagree disagree)
	{
		[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
		internal readonly struct EmbeddedAgree(string text)
		{
			internal readonly string Text = text;
		}

		[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
		internal readonly struct EmbeddedDisagree(string text)
		{
			internal readonly string Text = text;
		}

		internal readonly EmbeddedAgree Agree = agree;

		internal readonly EmbeddedDisagree Disagree = disagree;
	}

	[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
	internal readonly struct EmbeddedLinks(EmbeddedLinks.EmbeddedWebsite website, EmbeddedLinks.EmbeddedTerms terms, EmbeddedLinks.EmbeddedPrivacy privacy, EmbeddedLinks.EmbeddedRefund refund, EmbeddedLinks.EmbeddedManage manage)
	{
		[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
		internal readonly struct EmbeddedWebsite(string text, string url, bool required)
		{
			internal readonly string Text = text;

			internal readonly string Url = url;

			internal readonly bool Required = required;
		}

		[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
		internal readonly struct EmbeddedTerms(string text, string url, bool required)
		{
			internal readonly string Text = text;

			internal readonly string Url = url;

			internal readonly bool Required = required;
		}

		[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
		internal readonly struct EmbeddedPrivacy(string text, string url, bool required)
		{
			internal readonly string Text = text;

			internal readonly string Url = url;

			internal readonly bool Required = required;
		}

		[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
		internal readonly struct EmbeddedRefund(string text, string url, bool required)
		{
			internal readonly string Text = text;

			internal readonly string Url = url;

			internal readonly bool Required = required;
		}

		[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
		internal readonly struct EmbeddedManage(string text, string url, bool required)
		{
			internal readonly string Text = text;

			internal readonly string Url = url;

			internal readonly bool Required = required;
		}

		internal readonly EmbeddedWebsite Website = website;

		internal readonly EmbeddedTerms Terms = terms;

		internal readonly EmbeddedPrivacy Privacy = privacy;

		internal readonly EmbeddedRefund Refund = refund;

		internal readonly EmbeddedManage Manage = manage;
	}

	internal readonly string Plaintext = plaintext;

	internal readonly string Html = html;

	internal readonly EmbeddedButtons Buttons = buttons;

	internal readonly EmbeddedLinks Links = links;
}
