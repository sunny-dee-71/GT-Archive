namespace UnityEngine.XR.OpenXR.NativeTypes;

public struct XrPosef(Vector3 vec3, Quaternion quaternion)
{
	public XrQuaternionf Orientation = new XrQuaternionf(quaternion);

	public XrVector3f Position = new XrVector3f(vec3);
}
