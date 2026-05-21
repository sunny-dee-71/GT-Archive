namespace UnityEngine.AMD;

public struct FSR2CommandInitializationData
{
	public uint maxRenderSizeWidth;

	public uint maxRenderSizeHeight;

	public uint displaySizeWidth;

	public uint displaySizeHeight;

	public FfxFsr2InitializationFlags ffxFsrFlags;

	internal uint featureSlot;

	public void SetFlag(FfxFsr2InitializationFlags flag, bool value)
	{
		if (value)
		{
			ffxFsrFlags |= flag;
		}
		else
		{
			ffxFsrFlags &= ~flag;
		}
	}

	public bool GetFlag(FfxFsr2InitializationFlags flag)
	{
		return (ffxFsrFlags & flag) != 0;
	}
}
