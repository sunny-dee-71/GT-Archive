using UnityEngine;

namespace Oculus.Interaction;

public class MoveRelativeToTarget : IMovement
{
	private Pose _current = Pose.identity;

	private Pose _originalTarget;

	private Pose _originalSource;

	public Pose Pose => _current;

	public bool Stopped => true;

	public void MoveTo(Pose target)
	{
		_originalTarget = target;
	}

	public void UpdateTarget(Pose target)
	{
		PoseUtils.Multiply(new Pose(_originalSource.position, _originalTarget.rotation), PoseUtils.Delta(in _originalTarget, in target), ref _current);
	}

	public void StopAndSetPose(Pose source)
	{
		_current = (_originalSource = source);
	}

	public void Tick()
	{
	}
}
