using System;
using System.Runtime.InteropServices;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine.Analytics;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[RequiredByNativeCode(GenerateProxy = true)]
[ExcludeFromDocs]
public class VRDeviceMirrorAnalytic : VRDeviceAnalyticBase
{
	public bool vr_device_mirror_mode;

	[RequiredByNativeCode]
	internal static VRDeviceMirrorAnalytic CreateVRDeviceMirrorAnalytic()
	{
		return new VRDeviceMirrorAnalytic();
	}
}
