namespace UnityEngine.Rendering;

public struct OcclusionCullingSettings(int viewInstanceID, OcclusionTest occlusionTest)
{
	public int viewInstanceID = viewInstanceID;

	public OcclusionTest occlusionTest = occlusionTest;

	public int instanceMultiplier = 1;
}
