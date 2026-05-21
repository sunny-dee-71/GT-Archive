using JetBrains.Annotations;
using UnityEngine;

namespace MathGeoLib;

[PublicAPI]
public struct Plane(Vector3 normal, float distance)
{
	public readonly Vector3 Normal = normal;

	public readonly float Distance = distance;

	public override string ToString()
	{
		return string.Format("{0}: {1}, {2}: {3}", "Normal", Normal, "Distance", Distance);
	}
}
