using System;
using System.Text;

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

internal readonly struct Name(string name, bool computeUTF8ByteCount = false)
{
	public readonly string name = name;

	public readonly int utf8ByteCount = ((name != null && name.Length > 0 && computeUTF8ByteCount) ? Encoding.UTF8.GetByteCount((ReadOnlySpan<char>)name) : 0);
}
