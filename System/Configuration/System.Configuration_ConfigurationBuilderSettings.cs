using Unity;

namespace System.Configuration;

/// <summary>Represents a group of configuration elements that configure the providers for the <see langword="&lt;configBuilders&gt;" /> configuration section.</summary>
public class ConfigurationBuilderSettings : ConfigurationElement
{
	/// <summary>Gets a collection of <see cref="T:System.Configuration.ConfigurationBuilderSettings" /> objects that represent the properties of configuration builders.</summary>
	/// <returns>The <see cref="T:System.Configuration.ConfigurationBuilder" /> objects.</returns>
	public ProviderSettingsCollection Builders
	{
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return null;
		}
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Configuration.ConfigurationBuilderSettings" /> class.</summary>
	public ConfigurationBuilderSettings()
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}
}
