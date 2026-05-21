using System;
using Fusion.Internal;

namespace Fusion.CodeGen;

[Serializable]
[WeaverGenerated]
internal class UnityLinkedListSurrogate@ElementReaderWriterInt32 : UnityLinkedListSurrogate<int, Fusion.ElementReaderWriterInt32>
{
	[WeaverGenerated]
	public int[] Data = Array.Empty<int>();

	[WeaverGenerated]
	public override int[] DataProperty
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
	public UnityLinkedListSurrogate@ElementReaderWriterInt32()
	{
	}
}
