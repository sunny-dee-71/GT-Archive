using System;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine;

[StructLayout(LayoutKind.Sequential)]
[UsedByNativeCode("SubsystemDescriptor")]
[NativeHeader("Modules/Subsystems/SubsystemDescriptor.h")]
public class IntegratedSubsystemDescriptor<TSubsystem> : IntegratedSubsystemDescriptor where TSubsystem : IntegratedSubsystem
{
	internal override ISubsystem CreateImpl()
	{
		return Create();
	}

	public TSubsystem Create()
	{
		IntPtr ptr = SubsystemDescriptorBindings.Create(m_Ptr);
		TSubsystem val = (TSubsystem)SubsystemManager.GetIntegratedSubsystemByPtr(ptr);
		if (val != null)
		{
			val.m_SubsystemDescriptor = this;
		}
		return val;
	}
}
