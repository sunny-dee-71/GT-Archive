using System;
using Meta.XR.Util;
using Oculus.Interaction.Body.Input;
using UnityEngine;

namespace Oculus.Interaction.Body.PoseDetection;

[Feature(Feature.Interaction)]
public class OVRBodyPoseSkeletonProvider : MonoBehaviour, OVRSkeleton.IOVRSkeletonDataProvider
{
	private const int OVR_NUM_JOINTS = 84;

	[SerializeField]
	[Interface(typeof(IBodyPose), new Type[] { })]
	private UnityEngine.Object _bodyPose;

	private IBodyPose BodyPose;

	[SerializeField]
	private OVRPlugin.BodyJointSet _bodyJointSet;

	private OVRPlugin.Quatf[] _boneRotations = new OVRPlugin.Quatf[84];

	private OVRPlugin.Vector3f[] _boneTranslations = new OVRPlugin.Vector3f[84];

	private OVRSkeletonMapping _mapping;

	protected virtual void Awake()
	{
		BodyPose = _bodyPose as IBodyPose;
	}

	protected virtual void Start()
	{
		_mapping = new OVRSkeletonMapping(_bodyJointSet);
	}

	OVRSkeleton.SkeletonPoseData OVRSkeleton.IOVRSkeletonDataProvider.GetSkeletonPoseData()
	{
		_boneRotations = EnsureLength<OVRPlugin.Quatf>(_boneRotations, 84);
		_boneTranslations = EnsureLength<OVRPlugin.Vector3f>(_boneTranslations, 84);
		for (int i = 0; i < 84; i++)
		{
			OVRPlugin.BoneId jointId = (OVRPlugin.BoneId)i;
			if (_mapping.TryGetBodyJointId(jointId, out var bodyJointId) && BodyPose.GetJointPoseFromRoot(bodyJointId, out var pose))
			{
				_boneRotations[i] = pose.rotation.ToFlippedZQuatf();
				_boneTranslations[i] = pose.position.ToFlippedZVector3f();
			}
		}
		Pose pose2;
		OVRPlugin.Posef rootPose = ((!BodyPose.GetJointPoseFromRoot(BodyJointId.Body_Start, out pose2)) ? default(OVRPlugin.Posef) : new OVRPlugin.Posef
		{
			Orientation = pose2.rotation.ToFlippedXQuatf(),
			Position = pose2.position.ToFlippedZVector3f()
		});
		return new OVRSkeleton.SkeletonPoseData
		{
			IsDataValid = true,
			IsDataHighConfidence = true,
			RootPose = rootPose,
			RootScale = 1f,
			BoneRotations = _boneRotations,
			BoneTranslations = _boneTranslations
		};
		static T[] EnsureLength<T>(T[] array, int length)
		{
			if (array == null || array.Length != length)
			{
				return new T[length];
			}
			return array;
		}
	}

	public OVRSkeleton.SkeletonType GetSkeletonType()
	{
		return _bodyJointSet switch
		{
			OVRPlugin.BodyJointSet.UpperBody => OVRSkeleton.SkeletonType.Body, 
			OVRPlugin.BodyJointSet.FullBody => OVRSkeleton.SkeletonType.FullBody, 
			_ => OVRSkeleton.SkeletonType.None, 
		};
	}
}
