namespace UnityEngine.Animations.Rigging;

public struct BoolProperty : IAnimatableProperty<bool>
{
	public PropertyStreamHandle value;

	public static BoolProperty Bind(Animator animator, Component component, string name)
	{
		return new BoolProperty
		{
			value = animator.BindStreamProperty(component.transform, component.GetType(), name)
		};
	}

	public static BoolProperty BindCustom(Animator animator, string property)
	{
		return new BoolProperty
		{
			value = animator.BindCustomStreamProperty(property, CustomStreamPropertyType.Bool)
		};
	}

	public bool Get(AnimationStream stream)
	{
		return value.GetBool(stream);
	}

	public void Set(AnimationStream stream, bool v)
	{
		value.SetBool(stream, v);
	}
}
