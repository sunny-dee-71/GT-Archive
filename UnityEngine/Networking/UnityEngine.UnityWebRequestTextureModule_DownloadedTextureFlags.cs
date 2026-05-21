using System;

namespace UnityEngine.Networking;

[Flags]
public enum DownloadedTextureFlags : uint
{
	None = 0u,
	Readable = 1u,
	MipmapChain = 2u,
	LinearColorSpace = 4u
}
