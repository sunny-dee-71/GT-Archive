using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine;

internal static class RemoteConfigSettingsHelper
{
	[Preserve]
	[RequiredByNativeCode]
	internal enum Tag
	{
		kUnknown,
		kIntVal,
		kInt64Val,
		kUInt64Val,
		kDoubleVal,
		kBoolVal,
		kStringVal,
		kArrayVal,
		kMixedArrayVal,
		kMapVal,
		kMaxTags
	}

	internal unsafe static IntPtr GetSafeMap(IntPtr m, string key)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetSafeMap_Injected(m, ref managedSpanWrapper);
				}
			}
			return GetSafeMap_Injected(m, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern string[] GetSafeMapKeys(IntPtr m);

	internal static Tag[] GetSafeMapTypes(IntPtr m)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		Tag[] result;
		try
		{
			GetSafeMapTypes_Injected(m, out ret);
		}
		finally
		{
			Tag[] array = default(Tag[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	internal unsafe static long GetSafeNumber(IntPtr m, string key, long defaultValue)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetSafeNumber_Injected(m, ref managedSpanWrapper, defaultValue);
				}
			}
			return GetSafeNumber_Injected(m, ref managedSpanWrapper, defaultValue);
		}
		finally
		{
		}
	}

	internal unsafe static float GetSafeFloat(IntPtr m, string key, float defaultValue)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetSafeFloat_Injected(m, ref managedSpanWrapper, defaultValue);
				}
			}
			return GetSafeFloat_Injected(m, ref managedSpanWrapper, defaultValue);
		}
		finally
		{
		}
	}

	internal unsafe static bool GetSafeBool(IntPtr m, string key, bool defaultValue)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetSafeBool_Injected(m, ref managedSpanWrapper, defaultValue);
				}
			}
			return GetSafeBool_Injected(m, ref managedSpanWrapper, defaultValue);
		}
		finally
		{
		}
	}

	internal unsafe static string GetSafeStringValue(IntPtr m, string key, string defaultValue)
	{
		//The blocks IL_002a, IL_0037, IL_0045, IL_0053, IL_0058 are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0058 are reachable both inside and outside the pinned region starting at IL_0045. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0058 are reachable both inside and outside the pinned region starting at IL_0045. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper key2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					key2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(defaultValue, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(defaultValue);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							GetSafeStringValue_Injected(m, ref key2, ref managedSpanWrapper2, out ret);
						}
					}
					else
					{
						GetSafeStringValue_Injected(m, ref key2, ref managedSpanWrapper2, out ret);
					}
				}
			}
			else
			{
				key2 = ref managedSpanWrapper;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(defaultValue, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(defaultValue);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						GetSafeStringValue_Injected(m, ref key2, ref managedSpanWrapper2, out ret);
					}
				}
				else
				{
					GetSafeStringValue_Injected(m, ref key2, ref managedSpanWrapper2, out ret);
				}
			}
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	internal unsafe static IntPtr GetSafeArray(IntPtr m, string key)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetSafeArray_Injected(m, ref managedSpanWrapper);
				}
			}
			return GetSafeArray_Injected(m, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern long GetSafeArraySize(IntPtr a);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern IntPtr GetSafeArrayArray(IntPtr a, long i);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern IntPtr GetSafeArrayMap(IntPtr a, long i);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern Tag GetSafeArrayType(IntPtr a, long i);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern long GetSafeNumberArray(IntPtr a, long i);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern float GetSafeArrayFloat(IntPtr a, long i);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool GetSafeArrayBool(IntPtr a, long i);

	internal static string GetSafeArrayStringValue(IntPtr a, long i)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			GetSafeArrayStringValue_Injected(a, i, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static IDictionary<string, object> GetDictionary(IntPtr m, string key)
	{
		if (m == IntPtr.Zero)
		{
			return null;
		}
		if (!string.IsNullOrEmpty(key))
		{
			m = GetSafeMap(m, key);
			if (m == IntPtr.Zero)
			{
				return null;
			}
		}
		return GetDictionary(m);
	}

	internal static IDictionary<string, object> GetDictionary(IntPtr m)
	{
		if (m == IntPtr.Zero)
		{
			return null;
		}
		IDictionary<string, object> dictionary = new Dictionary<string, object>();
		Tag[] safeMapTypes = GetSafeMapTypes(m);
		string[] safeMapKeys = GetSafeMapKeys(m);
		for (int i = 0; i < safeMapKeys.Length; i++)
		{
			SetDictKeyType(m, dictionary, safeMapKeys[i], safeMapTypes[i]);
		}
		return dictionary;
	}

	internal static object GetArrayArrayEntries(IntPtr a, long i)
	{
		return GetArrayEntries(GetSafeArrayArray(a, i));
	}

	internal static IDictionary<string, object> GetArrayMapEntries(IntPtr a, long i)
	{
		return GetDictionary(GetSafeArrayMap(a, i));
	}

	internal static T[] GetArrayEntriesType<T>(IntPtr a, long size, Func<IntPtr, long, T> f)
	{
		T[] array = new T[size];
		for (long num = 0L; num < size; num++)
		{
			array[num] = f(a, num);
		}
		return array;
	}

	internal static object GetArrayEntries(IntPtr a)
	{
		long safeArraySize = GetSafeArraySize(a);
		if (safeArraySize == 0)
		{
			return null;
		}
		switch (GetSafeArrayType(a, 0L))
		{
		case Tag.kIntVal:
		case Tag.kInt64Val:
			return GetArrayEntriesType(a, safeArraySize, GetSafeNumberArray);
		case Tag.kDoubleVal:
			return GetArrayEntriesType(a, safeArraySize, GetSafeArrayFloat);
		case Tag.kBoolVal:
			return GetArrayEntriesType(a, safeArraySize, GetSafeArrayBool);
		case Tag.kStringVal:
			return GetArrayEntriesType(a, safeArraySize, GetSafeArrayStringValue);
		case Tag.kArrayVal:
			return GetArrayEntriesType(a, safeArraySize, GetArrayArrayEntries);
		case Tag.kMapVal:
			return GetArrayEntriesType(a, safeArraySize, GetArrayMapEntries);
		default:
			return null;
		}
	}

	internal static object GetMixedArrayEntries(IntPtr a)
	{
		long safeArraySize = GetSafeArraySize(a);
		if (safeArraySize == 0)
		{
			return null;
		}
		object[] array = new object[safeArraySize];
		for (long num = 0L; num < safeArraySize; num++)
		{
			switch (GetSafeArrayType(a, num))
			{
			case Tag.kIntVal:
			case Tag.kInt64Val:
				array[num] = GetSafeNumberArray(a, num);
				break;
			case Tag.kDoubleVal:
				array[num] = GetSafeArrayFloat(a, num);
				break;
			case Tag.kBoolVal:
				array[num] = GetSafeArrayBool(a, num);
				break;
			case Tag.kStringVal:
				array[num] = GetSafeArrayStringValue(a, num);
				break;
			case Tag.kArrayVal:
				array[num] = GetArrayArrayEntries(a, num);
				break;
			case Tag.kMapVal:
				array[num] = GetArrayMapEntries(a, num);
				break;
			}
		}
		return array;
	}

	internal static void SetDictKeyType(IntPtr m, IDictionary<string, object> dict, string key, Tag tag)
	{
		switch (tag)
		{
		case Tag.kIntVal:
		case Tag.kInt64Val:
			dict[key] = GetSafeNumber(m, key, 0L);
			break;
		case Tag.kDoubleVal:
			dict[key] = GetSafeFloat(m, key, 0f);
			break;
		case Tag.kBoolVal:
			dict[key] = GetSafeBool(m, key, defaultValue: false);
			break;
		case Tag.kStringVal:
			dict[key] = GetSafeStringValue(m, key, "");
			break;
		case Tag.kArrayVal:
			dict[key] = GetArrayEntries(GetSafeArray(m, key));
			break;
		case Tag.kMixedArrayVal:
			dict[key] = GetMixedArrayEntries(GetSafeArray(m, key));
			break;
		case Tag.kMapVal:
			dict[key] = GetDictionary(GetSafeMap(m, key));
			break;
		case Tag.kUInt64Val:
			break;
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetSafeMap_Injected(IntPtr m, ref ManagedSpanWrapper key);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetSafeMapTypes_Injected(IntPtr m, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern long GetSafeNumber_Injected(IntPtr m, ref ManagedSpanWrapper key, long defaultValue);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetSafeFloat_Injected(IntPtr m, ref ManagedSpanWrapper key, float defaultValue);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetSafeBool_Injected(IntPtr m, ref ManagedSpanWrapper key, bool defaultValue);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetSafeStringValue_Injected(IntPtr m, ref ManagedSpanWrapper key, ref ManagedSpanWrapper defaultValue, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetSafeArray_Injected(IntPtr m, ref ManagedSpanWrapper key);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetSafeArrayStringValue_Injected(IntPtr a, long i, out ManagedSpanWrapper ret);
}
