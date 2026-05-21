using System;
using System.Linq;
using System.Reflection;

namespace BuildSafe;

public static class Reflection
{
	private static Assembly[] gAssemblyCache;

	private static Type[] gTypeCache;

	public static Assembly[] AllAssemblies => PreFetchAllAssemblies();

	public static Type[] AllTypes => PreFetchAllTypes();

	static Reflection()
	{
		PreFetchAllAssemblies();
		PreFetchAllTypes();
	}

	private static Assembly[] PreFetchAllAssemblies()
	{
		if (gAssemblyCache != null)
		{
			return gAssemblyCache;
		}
		return gAssemblyCache = (from a in AppDomain.CurrentDomain.GetAssemblies()
			where a != null
			select a).ToArray();
	}

	private static Type[] PreFetchAllTypes()
	{
		if (gTypeCache != null)
		{
			return gTypeCache;
		}
		return gTypeCache = (from t in PreFetchAllAssemblies().SelectMany((Assembly a) => a.GetTypes())
			where t != null
			select t).ToArray();
	}

	public static MethodInfo[] GetMethodsWithAttribute<T>() where T : Attribute
	{
		return (from m in AllTypes.SelectMany((Type t) => t.GetRuntimeMethods())
			where m.GetCustomAttributes(typeof(T), inherit: false).Length != 0
			select m).ToArray();
	}
}
