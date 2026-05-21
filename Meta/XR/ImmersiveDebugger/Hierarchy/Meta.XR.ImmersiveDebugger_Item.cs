using Meta.XR.ImmersiveDebugger.Utils;

namespace Meta.XR.ImmersiveDebugger.Hierarchy;

internal abstract class Item<T> : Item
{
	protected T _owner;

	public override object Owner => _owner;

	public T TypedOwner => _owner;

	public void SetOwner(T owner)
	{
		_owner = owner;
		_handle = BuildHandle();
	}

	protected abstract InstanceHandle BuildHandle();
}
