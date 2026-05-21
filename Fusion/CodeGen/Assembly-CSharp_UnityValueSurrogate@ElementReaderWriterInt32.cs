using System;
using Fusion.Internal;

namespace Fusion.CodeGen;

[Serializable]
[WeaverGenerated]
internal class UnityValueSurrogate@ElementReaderWriterInt32 : UnityValueSurrogate<int, Fusion.ElementReaderWriterInt32>
{
	[WeaverGenerated]
	public int Data;

	[WeaverGenerated]
	public override int DataProperty
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
	public UnityValueSurrogate@ElementReaderWriterInt32()
	{
	}
}
