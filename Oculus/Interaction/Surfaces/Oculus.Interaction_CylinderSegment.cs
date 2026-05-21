using System;
using UnityEngine;

namespace Oculus.Interaction.Surfaces;

[Serializable]
public struct CylinderSegment
{
	[SerializeField]
	[Range(-180f, 180f)]
	private float _rotation;

	[SerializeField]
	[Range(0f, 360f)]
	private float _arcDegrees;

	[SerializeField]
	private float _bottom;

	[SerializeField]
	private float _top;

	public float ArcDegrees => _arcDegrees;

	public float Rotation => _rotation;

	public float Bottom => _bottom;

	public float Top => _top;

	public bool IsInfiniteHeight => Bottom > Top;

	public bool IsInfiniteArc => ArcDegrees >= 360f;

	public CylinderSegment(float rotation, float arcDegrees, float bottom, float top)
	{
		_rotation = rotation;
		_arcDegrees = arcDegrees;
		_bottom = bottom;
		_top = top;
	}

	public static CylinderSegment Default()
	{
		return new CylinderSegment
		{
			_rotation = 0f,
			_arcDegrees = 360f,
			_bottom = -1f,
			_top = 1f
		};
	}

	public static CylinderSegment Infinite()
	{
		return new CylinderSegment
		{
			_rotation = 0f,
			_arcDegrees = 360f,
			_bottom = 1f,
			_top = -1f
		};
	}
}
