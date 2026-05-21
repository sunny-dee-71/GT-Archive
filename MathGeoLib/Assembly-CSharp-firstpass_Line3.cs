using JetBrains.Annotations;
using UnityEngine;

namespace MathGeoLib;

[PublicAPI]
public struct Line3(Vector3 point1, Vector3 point2)
{
	public readonly Vector3 Point1 = point1;

	public readonly Vector3 Point2 = point2;

	public override string ToString()
	{
		return string.Format("{0}: {1}, {2}: {3}", "Point1", Point1, "Point2", Point2);
	}
}
