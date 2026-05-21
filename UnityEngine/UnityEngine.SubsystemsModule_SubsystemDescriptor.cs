using System;

namespace UnityEngine;

[Obsolete("Use SubsystemDescriptorWithProvider<> instead.", false)]
public class SubsystemDescriptor<TSubsystem> : SubsystemDescriptor where TSubsystem : Subsystem
{
	internal override ISubsystem CreateImpl()
	{
		return Create();
	}

	public TSubsystem Create()
	{
		if (SubsystemManager.FindDeprecatedSubsystemByDescriptor(this) is TSubsystem result)
		{
			return result;
		}
		TSubsystem val = Activator.CreateInstance(base.subsystemImplementationType) as TSubsystem;
		val.m_SubsystemDescriptor = this;
		SubsystemManager.AddDeprecatedSubsystem(val);
		return val;
	}
}
