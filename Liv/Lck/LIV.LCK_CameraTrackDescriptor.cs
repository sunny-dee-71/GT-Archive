using System;

namespace Liv.Lck;

[Serializable]
public struct CameraTrackDescriptor(CameraResolutionDescriptor cameraResolutionDescriptor, uint bitrate = 5242880u, uint framerate = 30u, uint audioBitrate = 192000u)
{
	public CameraResolutionDescriptor CameraResolutionDescriptor = cameraResolutionDescriptor;

	public uint Bitrate = bitrate;

	public uint Framerate = framerate;

	public uint AudioBitrate = audioBitrate;
}
