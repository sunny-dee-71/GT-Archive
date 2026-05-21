using System;

namespace UnityEngine.Animations.Rigging;

[Serializable]
public struct WeightedTransform(Transform transform, float weight) : ITransformProvider, IWeightProvider, IEquatable<WeightedTransform>
{
	public Transform transform = transform;

	public float weight = Mathf.Clamp01(weight);

	Transform ITransformProvider.transform
	{
		get
		{
			return transform;
		}
		set
		{
			transform = value;
		}
	}

	float IWeightProvider.weight
	{
		get
		{
			return weight;
		}
		set
		{
			weight = Mathf.Clamp01(value);
		}
	}

	public static WeightedTransform Default(float weight)
	{
		return new WeightedTransform(null, weight);
	}

	public bool Equals(WeightedTransform other)
	{
		if (transform == other.transform && weight == other.weight)
		{
			return true;
		}
		return false;
	}
}
