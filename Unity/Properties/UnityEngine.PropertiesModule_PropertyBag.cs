using System;
using Unity.Properties.Internal;

namespace Unity.Properties;

public abstract class PropertyBag<TContainer> : IPropertyBag<TContainer>, IPropertyBag, IPropertyBagRegister, IConstructor<TContainer>, IConstructor
{
	InstantiationKind IConstructor.InstantiationKind => InstantiationKind;

	protected virtual InstantiationKind InstantiationKind { get; } = InstantiationKind.Activator;

	static PropertyBag()
	{
		if (!TypeTraits.IsContainer(typeof(TContainer)))
		{
			throw new InvalidOperationException($"Failed to create a property bag for Type=[{typeof(TContainer)}]. The type is not a valid container type.");
		}
	}

	void IPropertyBagRegister.Register()
	{
		PropertyBagStore.AddPropertyBag(this);
	}

	public void Accept(ITypeVisitor visitor)
	{
		if (visitor == null)
		{
			throw new ArgumentNullException("visitor");
		}
		visitor.Visit<TContainer>();
	}

	void IPropertyBag.Accept(IPropertyBagVisitor visitor, ref object container)
	{
		if (container == null)
		{
			throw new ArgumentNullException("container");
		}
		if (!(container is TContainer container2) || 1 == 0)
		{
			throw new ArgumentException($"The given ContainerType=[{container.GetType()}] does not match the PropertyBagType=[{typeof(TContainer)}]");
		}
		PropertyBag.AcceptWithSpecializedVisitor(this, visitor, ref container2);
		container = container2;
	}

	void IPropertyBag<TContainer>.Accept(IPropertyBagVisitor visitor, ref TContainer container)
	{
		visitor.Visit(this, ref container);
	}

	PropertyCollection<TContainer> IPropertyBag<TContainer>.GetProperties()
	{
		return GetProperties();
	}

	PropertyCollection<TContainer> IPropertyBag<TContainer>.GetProperties(ref TContainer container)
	{
		return GetProperties(ref container);
	}

	TContainer IConstructor<TContainer>.Instantiate()
	{
		return Instantiate();
	}

	public abstract PropertyCollection<TContainer> GetProperties();

	public abstract PropertyCollection<TContainer> GetProperties(ref TContainer container);

	protected virtual TContainer Instantiate()
	{
		return default(TContainer);
	}

	public TContainer CreateInstance()
	{
		return TypeUtility.Instantiate<TContainer>();
	}

	public bool TryCreateInstance(out TContainer instance)
	{
		return TypeUtility.TryInstantiate<TContainer>(out instance);
	}
}
