using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.XR;

[NativeConditional("ENABLE_XR")]
[UsedByNativeCode]
[NativeType(Header = "Modules/XR/Subsystems/Input/XRInputSubsystemDescriptor.h")]
[NativeHeader("Modules/XR/XRPrefix.h")]
public class XRInputSubsystemDescriptor : IntegratedSubsystemDescriptor<XRInputSubsystem>
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(XRInputSubsystemDescriptor descriptor)
		{
			return descriptor.m_Ptr;
		}
	}

	[NativeConditional("ENABLE_XR")]
	public bool disablesLegacyInput
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_disablesLegacyInput_Injected(intPtr);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_disablesLegacyInput_Injected(IntPtr _unity_self);
}
