using System.Diagnostics;

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

[DebuggerDisplay("PassInputData: Res({resource.index})")]
internal readonly struct PassInputData(ResourceHandle resource)
{
	public readonly ResourceHandle resource = resource;
}
