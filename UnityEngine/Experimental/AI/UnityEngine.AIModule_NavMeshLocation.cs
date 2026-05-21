using System;

namespace UnityEngine.Experimental.AI;

[Obsolete("The experimental NavMeshLocation struct has been deprecated without replacement.")]
public struct NavMeshLocation
{
	public PolygonId polygon { get; }

	public Vector3 position { get; }

	internal NavMeshLocation(Vector3 position, PolygonId polygon)
	{
		this.position = position;
		this.polygon = polygon;
	}
}
