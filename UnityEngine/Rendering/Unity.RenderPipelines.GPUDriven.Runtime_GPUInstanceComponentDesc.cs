namespace UnityEngine.Rendering;

internal struct GPUInstanceComponentDesc(int inPropertyID, int inByteSize, bool inIsOverriden, bool inPerInstance, InstanceType inInstanceType, InstanceComponentGroup inComponentType)
{
	public int propertyID = inPropertyID;

	public int byteSize = inByteSize;

	public bool isOverriden = inIsOverriden;

	public bool isPerInstance = inPerInstance;

	public InstanceType instanceType = inInstanceType;

	public InstanceComponentGroup componentGroup = inComponentType;
}
