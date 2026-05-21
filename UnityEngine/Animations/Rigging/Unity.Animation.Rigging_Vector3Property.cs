using System;

namespace UnityEngine.Animations.Rigging;

public struct Vector3Property : IAnimatableProperty<Vector3>
{
	public PropertyStreamHandle x;

	public PropertyStreamHandle y;

	public PropertyStreamHandle z;

	public static Vector3Property Bind(Animator animator, Component component, string name)
	{
		Type type = component.GetType();
		return new Vector3Property
		{
			x = animator.BindStreamProperty(component.transform, type, name + ".x"),
			y = animator.BindStreamProperty(component.transform, type, name + ".y"),
			z = animator.BindStreamProperty(component.transform, type, name + ".z")
		};
	}

	public static Vector3Property BindCustom(Animator animator, string name)
	{
		return new Vector3Property
		{
			x = animator.BindCustomStreamProperty(name + ".x", CustomStreamPropertyType.Float),
			y = animator.BindCustomStreamProperty(name + ".y", CustomStreamPropertyType.Float),
			z = animator.BindCustomStreamProperty(name + ".z", CustomStreamPropertyType.Float)
		};
	}

	public Vector3 Get(AnimationStream stream)
	{
		return new Vector3(x.GetFloat(stream), y.GetFloat(stream), z.GetFloat(stream));
	}

	public void Set(AnimationStream stream, Vector3 value)
	{
		x.SetFloat(stream, value.x);
		y.SetFloat(stream, value.y);
		z.SetFloat(stream, value.z);
	}
}
