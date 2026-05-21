namespace System.ComponentModel;

/// <summary>Provides a base class for the container filter service.</summary>
public abstract class ContainerFilterService
{
	/// <summary>Initializes a new instance of the <see cref="T:System.ComponentModel.ContainerFilterService" /> class.</summary>
	protected ContainerFilterService()
	{
	}

	/// <summary>Filters the component collection.</summary>
	/// <param name="components">The component collection to filter.</param>
	/// <returns>A <see cref="T:System.ComponentModel.ComponentCollection" /> that represents a modified collection.</returns>
	public virtual ComponentCollection FilterComponents(ComponentCollection components)
	{
		return components;
	}
}
