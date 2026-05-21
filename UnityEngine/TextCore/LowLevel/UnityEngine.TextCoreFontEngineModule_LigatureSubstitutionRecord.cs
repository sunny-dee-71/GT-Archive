using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.TextCore.LowLevel;

[Serializable]
[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule", "UnityEditor.TextCoreTextEngineModule" })]
[UsedByNativeCode]
internal struct LigatureSubstitutionRecord : IEquatable<LigatureSubstitutionRecord>
{
	[SerializeField]
	[NativeName("componentGlyphs")]
	private uint[] m_ComponentGlyphIDs;

	[SerializeField]
	[NativeName("ligatureGlyph")]
	private uint m_LigatureGlyphID;

	public uint[] componentGlyphIDs
	{
		get
		{
			return m_ComponentGlyphIDs;
		}
		set
		{
			m_ComponentGlyphIDs = value;
		}
	}

	public uint ligatureGlyphID
	{
		get
		{
			return m_LigatureGlyphID;
		}
		set
		{
			m_LigatureGlyphID = value;
		}
	}

	public bool Equals(LigatureSubstitutionRecord other)
	{
		return this == other;
	}

	public override bool Equals(object obj)
	{
		return obj is LigatureSubstitutionRecord other && Equals(other);
	}

	public override int GetHashCode()
	{
		return m_ComponentGlyphIDs.GetHashCode();
	}

	public static bool operator ==(LigatureSubstitutionRecord lhs, LigatureSubstitutionRecord rhs)
	{
		if (lhs.componentGlyphIDs != null && rhs.componentGlyphIDs != null)
		{
			int num = lhs.m_ComponentGlyphIDs.Length;
			if (num != rhs.m_ComponentGlyphIDs.Length)
			{
				return false;
			}
			for (int i = 0; i < num; i++)
			{
				if (lhs.m_ComponentGlyphIDs[i] != rhs.m_ComponentGlyphIDs[i])
				{
					return false;
				}
			}
		}
		else if (lhs.componentGlyphIDs != null || rhs.componentGlyphIDs != null)
		{
			return false;
		}
		return lhs.ligatureGlyphID == rhs.m_LigatureGlyphID;
	}

	public static bool operator !=(LigatureSubstitutionRecord lhs, LigatureSubstitutionRecord rhs)
	{
		return !(lhs == rhs);
	}
}
