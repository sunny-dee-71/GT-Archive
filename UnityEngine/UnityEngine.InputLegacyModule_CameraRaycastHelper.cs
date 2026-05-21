using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine;

[NativeHeader("Runtime/Camera/Camera.h")]
internal class CameraRaycastHelper
{
	[FreeFunction("CameraScripting::RaycastTry")]
	internal static GameObject RaycastTry(Camera cam, Ray ray, float distance, int layerMask)
	{
		return Unmarshal.UnmarshalUnityObject<GameObject>(RaycastTry_Injected(Object.MarshalledUnityObject.Marshal(cam), ref ray, distance, layerMask));
	}

	[FreeFunction("CameraScripting::RaycastTry2D")]
	internal static GameObject RaycastTry2D(Camera cam, Ray ray, float distance, int layerMask)
	{
		return Unmarshal.UnmarshalUnityObject<GameObject>(RaycastTry2D_Injected(Object.MarshalledUnityObject.Marshal(cam), ref ray, distance, layerMask));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr RaycastTry_Injected(IntPtr cam, [In] ref Ray ray, float distance, int layerMask);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr RaycastTry2D_Injected(IntPtr cam, [In] ref Ray ray, float distance, int layerMask);
}
