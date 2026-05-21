namespace UnityEngine.Rendering;

public struct OccluderSubviewUpdate(int subviewIndex)
{
	public int subviewIndex = subviewIndex;

	public int depthSliceIndex = 0;

	public Vector2Int depthOffset = Vector2Int.zero;

	public Matrix4x4 viewMatrix = Matrix4x4.identity;

	public Matrix4x4 invViewMatrix = Matrix4x4.identity;

	public Matrix4x4 gpuProjMatrix = Matrix4x4.identity;

	public Vector3 viewOffsetWorldSpace = Vector3.zero;
}
