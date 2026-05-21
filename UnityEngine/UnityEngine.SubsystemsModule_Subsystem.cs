using System;

namespace UnityEngine;

[Obsolete("Use SubsystemWithProvider<> instead.", false)]
public abstract class Subsystem<TSubsystemDescriptor> : Subsystem where TSubsystemDescriptor : ISubsystemDescriptor
{
	public TSubsystemDescriptor SubsystemDescriptor => (TSubsystemDescriptor)m_SubsystemDescriptor;
}
