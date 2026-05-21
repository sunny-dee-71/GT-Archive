using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine;

[NativeHeader("Modules/JSONSerialize/Public/JsonUtility.bindings.h")]
public static class JsonUtility
{
	[FreeFunction("ToJsonInternal", true)]
	[ThreadSafe]
	private static string ToJsonInternal([NotNull] object obj, bool prettyPrint)
	{
		if (obj == null)
		{
			ThrowHelper.ThrowArgumentNullException(obj, "obj");
		}
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			ToJsonInternal_Injected(obj, prettyPrint, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[FreeFunction("FromJsonInternal", true, ThrowsException = true)]
	[ThreadSafe]
	private unsafe static object FromJsonInternal(string json, object objectToOverwrite, Type type)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(json, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(json);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return FromJsonInternal_Injected(ref managedSpanWrapper, objectToOverwrite, type);
				}
			}
			return FromJsonInternal_Injected(ref managedSpanWrapper, objectToOverwrite, type);
		}
		finally
		{
		}
	}

	public static string ToJson(object obj)
	{
		return ToJson(obj, prettyPrint: false);
	}

	public static string ToJson(object obj, bool prettyPrint)
	{
		if (obj == null)
		{
			return "";
		}
		if (obj is Object && !(obj is MonoBehaviour) && !(obj is ScriptableObject))
		{
			throw new ArgumentException("JsonUtility.ToJson does not support engine types.");
		}
		return ToJsonInternal(obj, prettyPrint);
	}

	public static T FromJson<T>(string json)
	{
		return (T)FromJson(json, typeof(T));
	}

	public static object FromJson(string json, Type type)
	{
		if (string.IsNullOrEmpty(json))
		{
			return null;
		}
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (type.IsAbstract || type.IsSubclassOf(typeof(Object)))
		{
			throw new ArgumentException("Cannot deserialize JSON to new instances of type '" + type.Name + ".'");
		}
		return FromJsonInternal(json, null, type);
	}

	public static void FromJsonOverwrite(string json, object objectToOverwrite)
	{
		if (!string.IsNullOrEmpty(json))
		{
			if (objectToOverwrite == null)
			{
				throw new ArgumentNullException("objectToOverwrite");
			}
			if (objectToOverwrite is Object && !(objectToOverwrite is MonoBehaviour) && !(objectToOverwrite is ScriptableObject))
			{
				throw new ArgumentException("Engine types cannot be overwritten from JSON outside of the Editor.");
			}
			FromJsonInternal(json, objectToOverwrite, objectToOverwrite.GetType());
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ToJsonInternal_Injected(object obj, bool prettyPrint, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern object FromJsonInternal_Injected(ref ManagedSpanWrapper json, object objectToOverwrite, Type type);
}
