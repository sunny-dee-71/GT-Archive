using System;

namespace Fusion.LagCompensation;

[Serializable]
public struct PositionRotationQueryParams(QueryParams queryParams, Hitbox hitbox)
{
	public QueryParams QueryParams = queryParams;

	public Hitbox Hitbox = hitbox;
}
