using System;
using Fusion.Internal;

namespace Fusion.CodeGen;

[Serializable]
[WeaverGenerated]
internal class UnityArraySurrogate@ElementReaderWriterInt32 : UnityArraySurrogate<int, Fusion.ElementReaderWriterInt32>
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
	public UnityArraySurrogate@ElementReaderWriterInt32()
	{
	}
}
