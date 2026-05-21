namespace UnityEngine.SubsystemsImplementation;

public abstract class SubsystemWithProvider<TSubsystem, TSubsystemDescriptor, TProvider> : SubsystemWithProvider where TSubsystem : SubsystemWithProvider, new() where TSubsystemDescriptor : SubsystemDescriptorWithProvider where TProvider : SubsystemProvider<TSubsystem>
{
	public TSubsystemDescriptor subsystemDescriptor { get; private set; }

	protected internal TProvider provider { get; private set; }

	internal sealed override SubsystemDescriptorWithProvider descriptor => subsystemDescriptor;

	protected virtual void OnCreate()
	{
	}

	protected override void OnStart()
	{
		provider.Start();
	}

	protected override void OnStop()
	{
		provider.Stop();
	}

	protected override void OnDestroy()
	{
		provider.Destroy();
	}

	internal sealed override void Initialize(SubsystemDescriptorWithProvider descriptor, SubsystemProvider provider)
	{
		base.providerBase = provider;
		this.provider = (TProvider)provider;
		subsystemDescriptor = (TSubsystemDescriptor)descriptor;
		OnCreate();
	}
}
