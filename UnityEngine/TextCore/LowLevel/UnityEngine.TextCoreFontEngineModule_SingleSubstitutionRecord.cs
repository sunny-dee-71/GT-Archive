using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.TextCore.LowLevel;

[Serializable]
[UsedByNativeCode]
internal struct SingleSubstitutionRecord
{
	[NativeName("targetGlyphID")]
	[SerializeField]
	private uint m_TargetGlyphID;

	[NativeName("substituteGlyphID")]
	[SerializeField]
	private uint m_SubstituteGlyphID;

	public uint targetGlyphID
	{
		get
		{
			return m_TargetGlyphID;
		}
		set
		{
			m_TargetGlyphID = value;
		}
	}

	public uint substituteGlyphID
	{
		get
		{
			return m_SubstituteGlyphID;
		}
		set
		{
			m_SubstituteGlyphID = value;
		}
	}
}
