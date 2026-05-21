namespace UnityEngine.Rendering.UnifiedRayTracing;

internal struct MeshInstanceDesc(Mesh mesh, int subMeshIndex = 0)
{
	public Mesh mesh = mesh;

	public int subMeshIndex = subMeshIndex;

	public Matrix4x4 localToWorldMatrix = Matrix4x4.identity;

	public uint mask = uint.MaxValue;

	public uint instanceID = uint.MaxValue;

	public bool enableTriangleCulling = true;

	public bool frontTriangleCounterClockwise = false;
}
