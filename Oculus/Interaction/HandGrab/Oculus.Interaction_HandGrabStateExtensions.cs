using UnityEngine;

namespace Oculus.Interaction.HandGrab;

public static class HandGrabStateExtensions
{
	public static Pose GetVisualWristPose(this IHandGrabState grabState)
	{
		if (grabState.HandGrabTarget.HandPose != null)
		{
			return grabState.HandGrabTarget.GetWorldPoseDisplaced(Pose.identity);
		}
		Pose result = Pose.identity;
		PoseUtils.Inverse(grabState.WristToGrabPoseOffset, ref result);
		return grabState.HandGrabTarget.GetWorldPoseDisplaced(in result);
	}

	public static Pose GetTargetGrabPose(this IHandGrabState grabState)
	{
		if (grabState.HandGrabTarget.HandPose != null)
		{
			return grabState.HandGrabTarget.GetWorldPoseDisplaced(grabState.WristToGrabPoseOffset);
		}
		return grabState.HandGrabTarget.GetWorldPoseDisplaced(Pose.identity);
	}
}
