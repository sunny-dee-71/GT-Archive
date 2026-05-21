using UnityEngine;

namespace Oculus.Interaction.Throw;

public struct ReleaseVelocityInformation(Vector3 linearVelocity, Vector3 angularVelocity, Vector3 origin, bool isSelectedVelocity = false)
{
	public Vector3 LinearVelocity = linearVelocity;

	public Vector3 AngularVelocity = angularVelocity;

	public Vector3 Origin = origin;

	public bool IsSelectedVelocity = isSelectedVelocity;
}
