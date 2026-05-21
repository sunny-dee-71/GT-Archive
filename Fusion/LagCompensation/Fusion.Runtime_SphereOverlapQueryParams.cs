using System;
using UnityEngine;

namespace Fusion.LagCompensation;

[Serializable]
public struct SphereOverlapQueryParams(QueryParams queryParams, Vector3 center, float radius, int staticHitsCapacity)
{
	public QueryParams QueryParams = queryParams;

	public Vector3 Center = center;

	public float Radius = radius;

	public int StaticHitsCapacity = staticHitsCapacity;
}
