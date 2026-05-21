using System.Diagnostics;

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

[DebuggerDisplay("PassRandomWriteData: Res({resource.index}):{index}:{preserveCounterValue}")]
internal readonly struct PassRandomWriteData(ResourceHandle resource, int index, bool preserveCounterValue)
{
	public readonly ResourceHandle resource = resource;

	public readonly int index = index;

	public readonly bool preserveCounterValue = preserveCounterValue;

	public override int GetHashCode()
	{
		return resource.GetHashCode() * 23 + index.GetHashCode();
	}
}
