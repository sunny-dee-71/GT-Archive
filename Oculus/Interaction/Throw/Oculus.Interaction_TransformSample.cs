using System;
using UnityEngine;

namespace Oculus.Interaction.Throw;

[Obsolete]
public struct TransformSample(Vector3 position, Quaternion rotation, float time, int frameIndex)
{
	public readonly Vector3 Position = position;

	public readonly Quaternion Rotation = rotation;

	public readonly float SampleTime = time;

	public readonly int FrameIndex = frameIndex;

	public static TransformSample Interpolate(TransformSample start, TransformSample fin, float time)
	{
		float t = Mathf.Clamp01(Mathf.InverseLerp(start.SampleTime, fin.SampleTime, time));
		return new TransformSample(Vector3.Lerp(start.Position, fin.Position, t), Quaternion.Slerp(start.Rotation, fin.Rotation, t), time, (int)Mathf.Lerp(start.FrameIndex, fin.FrameIndex, t));
	}
}
