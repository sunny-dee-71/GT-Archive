using System;
using Fusion.Internal;
using UnityEngine;

namespace Fusion.CodeGen;

[Serializable]
[WeaverGenerated]
internal class UnityLinkedListSurrogate@ReaderWriter@UnityEngine_Quaternion : UnityLinkedListSurrogate<Quaternion, ReaderWriter@UnityEngine_Quaternion>
{
	[WeaverGenerated]
	public Quaternion[] Data = Array.Empty<Quaternion>();

	[WeaverGenerated]
	public override Quaternion[] DataProperty
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
	public UnityLinkedListSurrogate@ReaderWriter@UnityEngine_Quaternion()
	{
	}
}
