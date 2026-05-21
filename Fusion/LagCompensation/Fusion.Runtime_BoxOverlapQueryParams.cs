using System;
using UnityEngine;

namespace Fusion.LagCompensation;

[Serializable]
public struct BoxOverlapQueryParams(QueryParams queryParams, Vector3 center, Vector3 extents, Quaternion rotation, int staticHitsCapacity)
{
	public QueryParams QueryParams = queryParams;

	public Vector3 Center = center;

	public Vector3 Extents = extents;

	public Quaternion Rotation = rotation;

	public int StaticHitsCapacity = staticHitsCapacity;
}
