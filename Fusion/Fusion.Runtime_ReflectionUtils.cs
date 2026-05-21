using System;
using System.Collections.Generic;
using System.Reflection;

namespace Fusion;

public static class ReflectionUtils
{
	public static T GetCustomAttributeOrThrow<T>(this MemberInfo member, bool inherit) where T : Attribute
	{
		object[] customAttributes = member.GetCustomAttributes(typeof(T), inherit);
		if (customAttributes.Length == 0)
		{
			throw new ArgumentOutOfRangeException("T", $"{member} has no attribute {typeof(T)}");
		}
		if (customAttributes.Length > 1)
		{
			throw new InvalidOperationException($"{member} has more than one attribute {typeof(T)}");
		}
		return (T)customAttributes[0];
	}

	public static NetworkBehaviourWeavedAttribute GetWeavedAttributeOrThrow(Type type)
	{
		try
		{
			return type.GetCustomAttributeOrThrow<NetworkBehaviourWeavedAttribute>(inherit: false);
		}
		catch (ArgumentOutOfRangeException)
		{
			throw new InvalidOperationException(string.Format("Type {0} has not been weaved. Has the assembly {1} been added to {2}?", type, type.Assembly.GetName().Name, "NetworkProjectConfig"));
		}
	}

	public static IEnumerable<Assembly> GetAllWeavedAssemblies()
	{
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly asm in assemblies)
		{
			NetworkAssemblyWeavedAttribute attr = asm.GetCustomAttribute<NetworkAssemblyWeavedAttribute>();
			if (attr != null)
			{
				yield return asm;
			}
		}
	}

	public static IEnumerable<Type> GetAllSimulationBehaviourTypes()
	{
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly asm in assemblies)
		{
			Type[] types = asm.GetTypes();
			foreach (Type type in types)
			{
				if (typeof(SimulationBehaviour).IsAssignableFrom(type))
				{
					yield return type;
				}
			}
		}
	}

	public static IEnumerable<Type> GetAllWeavedSimulationBehaviourTypes()
	{
		foreach (Assembly asm in GetAllWeavedAssemblies())
		{
			Type[] types = asm.GetTypes();
			foreach (Type type in types)
			{
				if (typeof(SimulationBehaviour).IsAssignableFrom(type))
				{
					yield return type;
				}
			}
		}
	}

	public static IEnumerable<Type> GetAllNetworkBehaviourTypes()
	{
		foreach (Type type in GetAllSimulationBehaviourTypes())
		{
			if (typeof(NetworkBehaviour).IsAssignableFrom(type))
			{
				yield return type;
			}
		}
	}

	public static IEnumerable<Type> GetAllWeavedNetworkBehaviourTypes()
	{
		foreach (Type type in GetAllWeavedSimulationBehaviourTypes())
		{
			if (typeof(NetworkBehaviour).IsAssignableFrom(type))
			{
				yield return type;
			}
		}
	}

	public static IEnumerable<Type> GetAllWeaverGeneratedTypes()
	{
		foreach (Assembly asm in GetAllWeavedAssemblies())
		{
			Type[] types = asm.GetTypes();
			foreach (Type type in types)
			{
				WeaverGeneratedAttribute weaverGen = type.GetCustomAttribute<WeaverGeneratedAttribute>();
				if (weaverGen != null)
				{
					yield return type;
				}
			}
		}
	}
}
