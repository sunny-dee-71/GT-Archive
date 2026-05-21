using System;

namespace UnityEngine.XR;

public struct InputFeatureUsage<T> : IEquatable<InputFeatureUsage<T>>
{
	public string name { get; set; }

	private Type usageType => typeof(T);

	public InputFeatureUsage(string usageName)
	{
		name = usageName;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is InputFeatureUsage<T>))
		{
			return false;
		}
		return Equals((InputFeatureUsage<T>)obj);
	}

	public bool Equals(InputFeatureUsage<T> other)
	{
		return name == other.name;
	}

	public override int GetHashCode()
	{
		return name.GetHashCode();
	}

	public static bool operator ==(InputFeatureUsage<T> a, InputFeatureUsage<T> b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(InputFeatureUsage<T> a, InputFeatureUsage<T> b)
	{
		return !(a == b);
	}

	public static explicit operator InputFeatureUsage(InputFeatureUsage<T> self)
	{
		InputFeatureType inputFeatureType = InputFeatureType.kUnityXRInputFeatureTypeInvalid;
		Type type = self.usageType;
		if (type == typeof(bool))
		{
			inputFeatureType = InputFeatureType.Binary;
		}
		else if (type == typeof(uint))
		{
			inputFeatureType = InputFeatureType.DiscreteStates;
		}
		else if (type == typeof(float))
		{
			inputFeatureType = InputFeatureType.Axis1D;
		}
		else if (type == typeof(Vector2))
		{
			inputFeatureType = InputFeatureType.Axis2D;
		}
		else if (type == typeof(Vector3))
		{
			inputFeatureType = InputFeatureType.Axis3D;
		}
		else if (type == typeof(Quaternion))
		{
			inputFeatureType = InputFeatureType.Rotation;
		}
		else if (type == typeof(Hand))
		{
			inputFeatureType = InputFeatureType.Hand;
		}
		else if (type == typeof(Bone))
		{
			inputFeatureType = InputFeatureType.Bone;
		}
		else if (type == typeof(Eyes))
		{
			inputFeatureType = InputFeatureType.Eyes;
		}
		else if (type == typeof(byte[]))
		{
			inputFeatureType = InputFeatureType.Custom;
		}
		else if (type.IsEnum)
		{
			inputFeatureType = InputFeatureType.DiscreteStates;
		}
		if (inputFeatureType != InputFeatureType.kUnityXRInputFeatureTypeInvalid)
		{
			return new InputFeatureUsage(self.name, inputFeatureType);
		}
		throw new InvalidCastException("No valid InputFeatureType for " + self.name + ".");
	}
}
