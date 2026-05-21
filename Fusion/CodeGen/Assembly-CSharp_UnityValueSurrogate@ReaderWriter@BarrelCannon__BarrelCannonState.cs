using System;
using Fusion.Internal;

namespace Fusion.CodeGen;

[Serializable]
[WeaverGenerated]
internal class UnityValueSurrogate@ReaderWriter@BarrelCannon__BarrelCannonState : UnityValueSurrogate<BarrelCannon.BarrelCannonState, ReaderWriter@BarrelCannon__BarrelCannonState>
{
	[WeaverGenerated]
	public BarrelCannon.BarrelCannonState Data;

	[WeaverGenerated]
	public override BarrelCannon.BarrelCannonState DataProperty
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
	public UnityValueSurrogate@ReaderWriter@BarrelCannon__BarrelCannonState()
	{
	}
}
