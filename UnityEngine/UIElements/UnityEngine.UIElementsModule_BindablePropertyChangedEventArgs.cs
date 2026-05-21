namespace UnityEngine.UIElements;

public readonly struct BindablePropertyChangedEventArgs(in BindingId propertyName)
{
	private readonly BindingId m_PropertyName = propertyName;

	public BindingId propertyName => m_PropertyName;
}
