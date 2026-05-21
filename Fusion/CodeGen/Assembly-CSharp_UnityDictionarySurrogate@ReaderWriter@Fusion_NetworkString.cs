using System;
using Fusion.Internal;

namespace Fusion.CodeGen;

[Serializable]
[WeaverGenerated]
internal class UnityDictionarySurrogate@ReaderWriter@Fusion_NetworkString`1<Fusion__32>@ReaderWriter@Fusion_NetworkString`1<Fusion__32> : UnityDictionarySurrogate<NetworkString<_32>, ReaderWriter@Fusion_NetworkString`1<Fusion__32>, NetworkString<_32>, ReaderWriter@Fusion_NetworkString`1<Fusion__32>>
{
	[WeaverGenerated]
	public SerializableDictionary<NetworkString<_32>, NetworkString<_32>> Data = SerializableDictionary.Create<NetworkString<_32>, NetworkString<_32>>();

	[WeaverGenerated]
	public override SerializableDictionary<NetworkString<_32>, NetworkString<_32>> DataProperty
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
	public UnityDictionarySurrogate@ReaderWriter@Fusion_NetworkString`1<Fusion__32>@ReaderWriter@Fusion_NetworkString`1<Fusion__32>()
	{
	}
}
