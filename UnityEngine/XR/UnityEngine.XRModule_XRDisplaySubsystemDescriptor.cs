using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.XR;

[NativeType(Header = "Modules/XR/Subsystems/Display/XRDisplaySubsystemDescriptor.h")]
[UsedByNativeCode]
public class XRDisplaySubsystemDescriptor : IntegratedSubsystemDescriptor<XRDisplaySubsystem>
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(XRDisplaySubsystemDescriptor descriptor)
		{
			return descriptor.m_Ptr;
		}
	}

	[NativeConditional("ENABLE_XR")]
	public bool disablesLegacyVr
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_disablesLegacyVr_Injected(intPtr);
		}
	}

	[NativeConditional("ENABLE_XR")]
	public bool enableBackBufferMSAA
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_enableBackBufferMSAA_Injected(intPtr);
		}
	}

	[NativeMethod("TryGetAvailableMirrorModeCount")]
	[NativeConditional("ENABLE_XR")]
	public int GetAvailableMirrorBlitModeCount()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetAvailableMirrorBlitModeCount_Injected(intPtr);
	}

	[NativeMethod("TryGetMirrorModeByIndex")]
	[NativeConditional("ENABLE_XR")]
	public void GetMirrorBlitModeByIndex(int index, out XRMirrorViewBlitModeDesc mode)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetMirrorBlitModeByIndex_Injected(intPtr, index, out mode);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_disablesLegacyVr_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_enableBackBufferMSAA_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetAvailableMirrorBlitModeCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetMirrorBlitModeByIndex_Injected(IntPtr _unity_self, int index, out XRMirrorViewBlitModeDesc mode);
}
