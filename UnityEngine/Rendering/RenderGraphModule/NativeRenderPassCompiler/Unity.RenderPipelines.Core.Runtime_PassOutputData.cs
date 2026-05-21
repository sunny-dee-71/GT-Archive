using System.Diagnostics;

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

[DebuggerDisplay("PassOutputData: Res({resource.index})")]
internal readonly struct PassOutputData(ResourceHandle resource)
{
	public readonly ResourceHandle resource = resource;
}
