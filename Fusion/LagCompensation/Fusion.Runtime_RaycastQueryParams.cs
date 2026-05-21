using System;
using UnityEngine;

namespace Fusion.LagCompensation;

[Serializable]
public struct RaycastQueryParams(QueryParams queryParams, Vector3 origin, Vector3 direction, float length, int staticHitsCapacity = 64)
{
	public QueryParams QueryParams = queryParams;

	public Vector3 Origin = origin;

	public Vector3 Direction = direction;

	public float Length = length;

	public int StaticHitsCapacity = staticHitsCapacity;
}
