using System;
using UnityEngine.Scripting;

namespace UnityEngine;

[UsedByNativeCode("Subsystem_TSubsystemDescriptor")]
public class IntegratedSubsystem<TSubsystemDescriptor> : IntegratedSubsystem where TSubsystemDescriptor : ISubsystemDescriptor
{
	public TSubsystemDescriptor subsystemDescriptor => (TSubsystemDescriptor)m_SubsystemDescriptor;

	[Obsolete("The property 'SubsystemDescriptor' is deprecated. Use `subsystemDescriptor` instead. UnityUpgradeable -> subsystemDescriptor", false)]
	public TSubsystemDescriptor SubsystemDescriptor => subsystemDescriptor;
}
