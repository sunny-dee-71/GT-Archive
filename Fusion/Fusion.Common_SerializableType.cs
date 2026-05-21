#define DEBUG
using System;

namespace Fusion;

[Serializable]
public struct SerializableType<BaseType> : IEquatable<SerializableType<BaseType>>
{
	public string AssemblyQualifiedName;

	public bool IsValid => !string.IsNullOrEmpty(AssemblyQualifiedName);

	public Type Value
	{
		get
		{
			SerializableType serializableType = new SerializableType
			{
				AssemblyQualifiedName = AssemblyQualifiedName
			};
			Type value = serializableType.Value;
			Assert.Check(value != null);
			if (!value.IsSubclassOf(typeof(BaseType)))
			{
				throw new Exception($"Type mismatch: {value} must inherit from {typeof(BaseType)}");
			}
			return value;
		}
	}

	public SerializableType(Type type)
	{
		AssemblyQualifiedName = type.AssemblyQualifiedName;
	}

	public SerializableType<BaseType> AsShort()
	{
		return new SerializableType<BaseType>
		{
			AssemblyQualifiedName = SerializableType.GetShortAssemblyQualifiedName(AssemblyQualifiedName)
		};
	}

	public static implicit operator SerializableType<BaseType>(Type type)
	{
		return new SerializableType<BaseType>(type);
	}

	public static implicit operator Type(SerializableType<BaseType> serializableType)
	{
		return serializableType.Value;
	}

	public bool Equals(SerializableType<BaseType> other)
	{
		return AssemblyQualifiedName == other.AssemblyQualifiedName;
	}

	public override bool Equals(object obj)
	{
		return obj is SerializableType<BaseType> other && Equals(other);
	}

	public override int GetHashCode()
	{
		return (AssemblyQualifiedName != null) ? AssemblyQualifiedName.GetHashCode() : 0;
	}
}
