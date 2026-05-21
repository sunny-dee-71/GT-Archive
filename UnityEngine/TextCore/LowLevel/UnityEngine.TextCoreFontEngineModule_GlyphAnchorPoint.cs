using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.TextCore.LowLevel;

[Serializable]
[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
[UsedByNativeCode]
internal struct GlyphAnchorPoint
{
	[SerializeField]
	[NativeName("xPositionAdjustment")]
	private float m_XCoordinate;

	[SerializeField]
	[NativeName("yPositionAdjustment")]
	private float m_YCoordinate;

	public float xCoordinate
	{
		get
		{
			return m_XCoordinate;
		}
		set
		{
			m_XCoordinate = value;
		}
	}

	public float yCoordinate
	{
		get
		{
			return m_YCoordinate;
		}
		set
		{
			m_YCoordinate = value;
		}
	}
}
