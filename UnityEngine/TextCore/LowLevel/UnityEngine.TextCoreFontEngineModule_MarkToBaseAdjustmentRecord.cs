using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.TextCore.LowLevel;

[Serializable]
[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
[UsedByNativeCode]
internal struct MarkToBaseAdjustmentRecord
{
	[SerializeField]
	[NativeName("baseGlyphID")]
	private uint m_BaseGlyphID;

	[SerializeField]
	[NativeName("baseAnchor")]
	private GlyphAnchorPoint m_BaseGlyphAnchorPoint;

	[SerializeField]
	[NativeName("markGlyphID")]
	private uint m_MarkGlyphID;

	[SerializeField]
	[NativeName("markPositionAdjustment")]
	private MarkPositionAdjustment m_MarkPositionAdjustment;

	public uint baseGlyphID
	{
		get
		{
			return m_BaseGlyphID;
		}
		set
		{
			m_BaseGlyphID = value;
		}
	}

	public GlyphAnchorPoint baseGlyphAnchorPoint
	{
		get
		{
			return m_BaseGlyphAnchorPoint;
		}
		set
		{
			m_BaseGlyphAnchorPoint = value;
		}
	}

	public uint markGlyphID
	{
		get
		{
			return m_MarkGlyphID;
		}
		set
		{
			m_MarkGlyphID = value;
		}
	}

	public MarkPositionAdjustment markPositionAdjustment
	{
		get
		{
			return m_MarkPositionAdjustment;
		}
		set
		{
			m_MarkPositionAdjustment = value;
		}
	}
}
