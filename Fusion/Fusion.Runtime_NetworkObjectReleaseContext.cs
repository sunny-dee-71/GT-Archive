namespace Fusion;

public readonly struct NetworkObjectReleaseContext(NetworkObject obj, NetworkObjectTypeId typeId, bool isBeingDestroyed, bool isNested)
{
	public readonly NetworkObject Object = obj;

	public readonly NetworkObjectTypeId TypeId = typeId;

	public readonly bool IsBeingDestroyed = isBeingDestroyed;

	public readonly bool IsNestedObject = isNested;

	public override string ToString()
	{
		return $"[{Object}, TypeId={TypeId}, IsBeingDestroyed={IsBeingDestroyed}, IsNestedObject={IsNestedObject}]";
	}
}
