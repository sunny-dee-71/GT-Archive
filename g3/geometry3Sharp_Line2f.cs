namespace g3;

public struct Line2f(Vector2f origin, Vector2f direction)
{
	public Vector2f Origin = origin;

	public Vector2f Direction = direction;

	public Vector2f PointAt(float d)
	{
		return Origin + d * Direction;
	}

	public float Project(Vector2f p)
	{
		return (p - Origin).Dot(Direction);
	}

	public float DistanceSquared(Vector2f p)
	{
		float num = (p - Origin).Dot(Direction);
		return (Origin + num * Direction - p).LengthSquared;
	}
}
