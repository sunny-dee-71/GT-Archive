namespace UnityEngine.Rendering.UnifiedRayTracing;

internal struct TerrainDesc(Terrain terrain)
{
	public Terrain terrain = terrain;

	public Matrix4x4 localToWorldMatrix = Matrix4x4.identity;

	public uint mask = uint.MaxValue;

	public uint renderingLayerMask = uint.MaxValue;

	public uint materialID = 0u;

	public bool enableTriangleCulling = true;

	public bool frontTriangleCounterClockwise = false;
}
