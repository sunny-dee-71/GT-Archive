namespace UnityEngine.UIElements;

internal readonly struct BindingTarget(VisualElement element, in BindingId bindingId)
{
	public readonly VisualElement element = element;

	public readonly BindingId bindingId = bindingId;
}
