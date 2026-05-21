using System;
using UnityEngine.Serialization;

namespace Liv.Lck;

[Serializable]
public struct QualityOption(string name, bool isDefault, CameraTrackDescriptor recordingCameraTrackDescriptor, CameraTrackDescriptor streamingCameraTrackDescriptor)
{
	public string Name = name;

	public bool IsDefault = isDefault;

	[FormerlySerializedAs("CameraTrackDescriptor")]
	public CameraTrackDescriptor RecordingCameraTrackDescriptor = recordingCameraTrackDescriptor;

	public CameraTrackDescriptor StreamingCameraTrackDescriptor = streamingCameraTrackDescriptor;

	[Obsolete("Provides the RecordingCameraTrackDescriptor and only exists for backwards compability - Use RecordingCameraTrackDescriptor or StreamingCameraTrackDescriptor instead")]
	public CameraTrackDescriptor CameraTrackDescriptor => RecordingCameraTrackDescriptor;
}
