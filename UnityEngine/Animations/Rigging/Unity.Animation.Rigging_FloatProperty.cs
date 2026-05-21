namespace UnityEngine.Animations.Rigging;

public struct FloatProperty : IAnimatableProperty<float>
{
	public PropertyStreamHandle value;

	public static FloatProperty Bind(Animator animator, Component component, string name)
	{
		return new FloatProperty
		{
			value = animator.BindStreamProperty(component.transform, component.GetType(), name)
		};
	}

	public static FloatProperty BindCustom(Animator animator, string property)
	{
		return new FloatProperty
		{
			value = animator.BindCustomStreamProperty(property, CustomStreamPropertyType.Float)
		};
	}

	public float Get(AnimationStream stream)
	{
		return value.GetFloat(stream);
	}

	public void Set(AnimationStream stream, float v)
	{
		value.SetFloat(stream, v);
	}
}
