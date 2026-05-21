using System;

namespace UnityEngine.Animations.Rigging;

public struct Vector3IntProperty : IAnimatableProperty<Vector3Int>
{
	public PropertyStreamHandle x;

	public PropertyStreamHandle y;

	public PropertyStreamHandle z;

	public static Vector3IntProperty Bind(Animator animator, Component component, string name)
	{
		Type type = component.GetType();
		return new Vector3IntProperty
		{
			x = animator.BindStreamProperty(component.transform, type, name + ".x"),
			y = animator.BindStreamProperty(component.transform, type, name + ".y"),
			z = animator.BindStreamProperty(component.transform, type, name + ".z")
		};
	}

	public static Vector3IntProperty BindCustom(Animator animator, string name)
	{
		return new Vector3IntProperty
		{
			x = animator.BindCustomStreamProperty(name + ".x", CustomStreamPropertyType.Int),
			y = animator.BindCustomStreamProperty(name + ".y", CustomStreamPropertyType.Int),
			z = animator.BindCustomStreamProperty(name + ".z", CustomStreamPropertyType.Int)
		};
	}

	public Vector3Int Get(AnimationStream stream)
	{
		return new Vector3Int(x.GetInt(stream), y.GetInt(stream), z.GetInt(stream));
	}

	public void Set(AnimationStream stream, Vector3Int value)
	{
		x.SetInt(stream, value.x);
		y.SetInt(stream, value.y);
		z.SetInt(stream, value.z);
	}
}
