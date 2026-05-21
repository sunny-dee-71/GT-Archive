using System;
using Fusion.Internal;

namespace Fusion.CodeGen;

[Serializable]
[WeaverGenerated]
internal class UnityValueSurrogate@ElementReaderWriterNetworkBool : UnityValueSurrogate<NetworkBool, Fusion.ElementReaderWriterNetworkBool>
{
	[WeaverGenerated]
	public NetworkBool Data;

	[WeaverGenerated]
	public override NetworkBool DataProperty
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
	public UnityValueSurrogate@ElementReaderWriterNetworkBool()
	{
	}
}
