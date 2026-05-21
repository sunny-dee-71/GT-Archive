using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.TextCore.LowLevel;

[Serializable]
[UsedByNativeCode]
[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
internal struct MarkToMarkAdjustmentRecord
{
	[NativeName("baseMarkGlyphID")]
	[SerializeField]
	private uint m_BaseMarkGlyphID;

	[NativeName("baseMarkAnchor")]
	[SerializeField]
	private GlyphAnchorPoint m_BaseMarkGlyphAnchorPoint;

	[SerializeField]
	[NativeName("combiningMarkGlyphID")]
	private uint m_CombiningMarkGlyphID;

	[NativeName("combiningMarkPositionAdjustment")]
	[SerializeField]
	private MarkPositionAdjustment m_CombiningMarkPositionAdjustment;

	public uint baseMarkGlyphID
	{
		get
		{
			return m_BaseMarkGlyphID;
		}
		set
		{
			m_BaseMarkGlyphID = value;
		}
	}

	public GlyphAnchorPoint baseMarkGlyphAnchorPoint
	{
		get
		{
			return m_BaseMarkGlyphAnchorPoint;
		}
		set
		{
			m_BaseMarkGlyphAnchorPoint = value;
		}
	}

	public uint combiningMarkGlyphID
	{
		get
		{
			return m_CombiningMarkGlyphID;
		}
		set
		{
			m_CombiningMarkGlyphID = value;
		}
	}

	public MarkPositionAdjustment combiningMarkPositionAdjustment
	{
		get
		{
			return m_CombiningMarkPositionAdjustment;
		}
		set
		{
			m_CombiningMarkPositionAdjustment = value;
		}
	}
}
