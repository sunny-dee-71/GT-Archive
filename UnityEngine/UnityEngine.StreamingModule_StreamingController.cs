using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine;

[NativeHeader("Modules/Streaming/StreamingController.h")]
[RequireComponent(typeof(Camera))]
public class StreamingController : Behaviour
{
	public float streamingMipmapBias
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_streamingMipmapBias_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_streamingMipmapBias_Injected(intPtr, value);
		}
	}

	public void SetPreloading(float timeoutSeconds = 0f, bool activateCameraOnTimeout = false, Camera disableCameraCuttingFrom = null)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetPreloading_Injected(intPtr, timeoutSeconds, activateCameraOnTimeout, MarshalledUnityObject.Marshal(disableCameraCuttingFrom));
	}

	public void CancelPreloading()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		CancelPreloading_Injected(intPtr);
	}

	public bool IsPreloading()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return IsPreloading_Injected(intPtr);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_streamingMipmapBias_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_streamingMipmapBias_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetPreloading_Injected(IntPtr _unity_self, float timeoutSeconds, bool activateCameraOnTimeout, IntPtr disableCameraCuttingFrom);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CancelPreloading_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsPreloading_Injected(IntPtr _unity_self);
}
