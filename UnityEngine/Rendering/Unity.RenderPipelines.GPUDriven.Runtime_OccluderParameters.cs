using UnityEngine.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering;

public struct OccluderParameters(int viewInstanceID)
{
	public int viewInstanceID = viewInstanceID;

	public int subviewCount = 1;

	public TextureHandle depthTexture = TextureHandle.nullHandle;

	public Vector2Int depthSize = Vector2Int.zero;

	public bool depthIsArray = false;
}
