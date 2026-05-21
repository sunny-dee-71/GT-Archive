using System;

namespace UnityEngine.AMD;

[Flags]
public enum FfxFsr2InitializationFlags
{
	EnableHighDynamicRange = 1,
	EnableDisplayResolutionMotionVectors = 2,
	EnableMotionVectorsJitterCancellation = 4,
	DepthInverted = 8,
	EnableDepthInfinite = 0x10,
	EnableAutoExposure = 0x20,
	EnableDynamicResolution = 0x40,
	EnableTexture1DUsage = 0x80
}
