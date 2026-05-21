using System.Diagnostics;

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

[DebuggerDisplay("Res({handle.index}) : {loadAction} : {storeAction} : {memoryless}")]
internal readonly struct NativePassAttachment(ResourceHandle handle, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, bool memoryless, int mipLevel, int depthSlice)
{
	public readonly ResourceHandle handle = handle;

	public readonly RenderBufferLoadAction loadAction = loadAction;

	public readonly RenderBufferStoreAction storeAction = storeAction;

	public readonly bool memoryless = memoryless;

	public readonly int mipLevel = mipLevel;

	public readonly int depthSlice = depthSlice;
}
