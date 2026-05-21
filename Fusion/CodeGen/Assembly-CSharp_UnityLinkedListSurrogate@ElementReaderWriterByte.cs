using System;
using Fusion.Internal;

namespace Fusion.CodeGen;

[Serializable]
[WeaverGenerated]
internal class UnityLinkedListSurrogate@ElementReaderWriterByte : UnityLinkedListSurrogate<byte, Fusion.ElementReaderWriterByte>
{
	[WeaverGenerated]
	public byte[] Data = Array.Empty<byte>();

	[WeaverGenerated]
	public override byte[] DataProperty
	{
		[WeaverGenerated]
		get
		{
			return Data;
		}
		[WeaverGenerated]
		set
		{
			Data = value;
		}
	}

	[WeaverGenerated]
	public UnityLinkedListSurrogate@ElementReaderWriterByte()
	{
	}
}
