using System;
using Fusion.Internal;

namespace Fusion.CodeGen;

[Serializable]
[WeaverGenerated]
internal class UnityValueSurrogate@ReaderWriter@Fusion_NetworkString`1<Fusion__128> : UnityValueSurrogate<NetworkString<_128>, ReaderWriter@Fusion_NetworkString`1<Fusion__128>>
{
	[WeaverGenerated]
	public NetworkString<_128> Data;

	[WeaverGenerated]
	public override NetworkString<_128> DataProperty
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
	public UnityValueSurrogate@ReaderWriter@Fusion_NetworkString`1<Fusion__128>()
	{
	}
}
