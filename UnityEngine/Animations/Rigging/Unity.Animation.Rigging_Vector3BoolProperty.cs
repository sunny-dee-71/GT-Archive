using System;

namespace UnityEngine.Animations.Rigging;

public struct Vector3BoolProperty : IAnimatableProperty<Vector3Bool>
{
	public PropertyStreamHandle x;

	public PropertyStreamHandle y;

	public PropertyStreamHandle z;

	public static Vector3BoolProperty Bind(Animator animator, Component component, string name)
	{
		Type type = component.GetType();
		return new Vector3BoolProperty
		{
			x = animator.BindStreamProperty(component.transform, type, name + ".x"),
			y = animator.BindStreamProperty(component.transform, type, name + ".y"),
			z = animator.BindStreamProperty(component.transform, type, name + ".z")
		};
	}

	public static Vector3BoolProperty BindCustom(Animator animator, string name)
	{
		return new Vector3BoolProperty
		{
			x = animator.BindCustomStreamProperty(name + ".x", CustomStreamPropertyType.Bool),
			y = animator.BindCustomStreamProperty(name + ".y", CustomStreamPropertyType.Bool),
			z = animator.BindCustomStreamProperty(name + ".z", CustomStreamPropertyType.Bool)
		};
	}

	public Vector3Bool Get(AnimationStream stream)
	{
		return new Vector3Bool(x.GetBool(stream), y.GetBool(stream), z.GetBool(stream));
	}

	public void Set(AnimationStream stream, Vector3Bool value)
	{
		x.SetBool(stream, value.x);
		y.SetBool(stream, value.y);
		z.SetBool(stream, value.z);
	}
}
