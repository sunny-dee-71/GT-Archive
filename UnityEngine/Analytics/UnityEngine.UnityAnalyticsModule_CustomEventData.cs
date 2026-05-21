using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine.Analytics;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/UnityAnalytics/Public/Events/UserCustomEvent.h")]
internal class CustomEventData : IDisposable
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(CustomEventData customEventData)
		{
			return customEventData.m_Ptr;
		}
	}

	[NonSerialized]
	internal IntPtr m_Ptr;

	private CustomEventData()
	{
	}

	public CustomEventData(string name)
	{
		m_Ptr = Internal_Create(this, name);
	}

	~CustomEventData()
	{
		Destroy();
	}

	private void Destroy()
	{
		if (m_Ptr != IntPtr.Zero)
		{
			Internal_Destroy(m_Ptr);
			m_Ptr = IntPtr.Zero;
		}
	}

	public void Dispose()
	{
		Destroy();
		GC.SuppressFinalize(this);
	}

	internal unsafe static IntPtr Internal_Create([Unmarshalled] CustomEventData ced, string name)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return Internal_Create_Injected(ced, ref managedSpanWrapper);
				}
			}
			return Internal_Create_Injected(ced, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[ThreadSafe]
	internal static extern void Internal_Destroy(IntPtr ptr);

	public unsafe bool AddString(string key, string value)
	{
		//The blocks IL_0039, IL_0046, IL_0054, IL_0062, IL_0067 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0067 are reachable both inside and outside the pinned region starting at IL_0054. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0067 are reachable both inside and outside the pinned region starting at IL_0054. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
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
					if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(value);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							return AddString_Injected(intPtr, ref key2, ref managedSpanWrapper2);
						}
					}
					return AddString_Injected(intPtr, ref key2, ref managedSpanWrapper2);
				}
			}
			key2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(value);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					return AddString_Injected(intPtr, ref key2, ref managedSpanWrapper2);
				}
			}
			return AddString_Injected(intPtr, ref key2, ref managedSpanWrapper2);
		}
		finally
		{
		}
	}

	public unsafe bool AddInt32(string key, int value)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return AddInt32_Injected(intPtr, ref managedSpanWrapper, value);
				}
			}
			return AddInt32_Injected(intPtr, ref managedSpanWrapper, value);
		}
		finally
		{
		}
	}

	public unsafe bool AddUInt32(string key, uint value)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return AddUInt32_Injected(intPtr, ref managedSpanWrapper, value);
				}
			}
			return AddUInt32_Injected(intPtr, ref managedSpanWrapper, value);
		}
		finally
		{
		}
	}

	public unsafe bool AddInt64(string key, long value)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return AddInt64_Injected(intPtr, ref managedSpanWrapper, value);
				}
			}
			return AddInt64_Injected(intPtr, ref managedSpanWrapper, value);
		}
		finally
		{
		}
	}

	public unsafe bool AddUInt64(string key, ulong value)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return AddUInt64_Injected(intPtr, ref managedSpanWrapper, value);
				}
			}
			return AddUInt64_Injected(intPtr, ref managedSpanWrapper, value);
		}
		finally
		{
		}
	}

	public unsafe bool AddBool(string key, bool value)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return AddBool_Injected(intPtr, ref managedSpanWrapper, value);
				}
			}
			return AddBool_Injected(intPtr, ref managedSpanWrapper, value);
		}
		finally
		{
		}
	}

	public unsafe bool AddDouble(string key, double value)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return AddDouble_Injected(intPtr, ref managedSpanWrapper, value);
				}
			}
			return AddDouble_Injected(intPtr, ref managedSpanWrapper, value);
		}
		finally
		{
		}
	}

	public bool AddDictionary(IDictionary<string, object> eventData)
	{
		foreach (KeyValuePair<string, object> eventDatum in eventData)
		{
			string key = eventDatum.Key;
			object value = eventDatum.Value;
			if (value == null)
			{
				AddString(key, "null");
				continue;
			}
			Type type = value.GetType();
			if (type == typeof(string))
			{
				AddString(key, (string)value);
				continue;
			}
			if (type == typeof(char))
			{
				AddString(key, char.ToString((char)value));
				continue;
			}
			if (type == typeof(sbyte))
			{
				AddInt32(key, (sbyte)value);
				continue;
			}
			if (type == typeof(byte))
			{
				AddInt32(key, (byte)value);
				continue;
			}
			if (type == typeof(short))
			{
				AddInt32(key, (short)value);
				continue;
			}
			if (type == typeof(ushort))
			{
				AddUInt32(key, (ushort)value);
				continue;
			}
			if (type == typeof(int))
			{
				AddInt32(key, (int)value);
				continue;
			}
			if (type == typeof(uint))
			{
				AddUInt32(eventDatum.Key, (uint)value);
				continue;
			}
			if (type == typeof(long))
			{
				AddInt64(key, (long)value);
				continue;
			}
			if (type == typeof(ulong))
			{
				AddUInt64(key, (ulong)value);
				continue;
			}
			if (type == typeof(bool))
			{
				AddBool(key, (bool)value);
				continue;
			}
			if (type == typeof(float))
			{
				AddDouble(key, (double)Convert.ToDecimal((float)value));
				continue;
			}
			if (type == typeof(double))
			{
				AddDouble(key, (double)value);
				continue;
			}
			if (type == typeof(decimal))
			{
				AddDouble(key, (double)Convert.ToDecimal((decimal)value));
				continue;
			}
			if (type.IsValueType)
			{
				AddString(key, value.ToString());
				continue;
			}
			throw new ArgumentException($"Invalid type: {type} passed");
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Internal_Create_Injected(CustomEventData ced, ref ManagedSpanWrapper name);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool AddString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool AddInt32_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool AddUInt32_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, uint value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool AddInt64_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, long value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool AddUInt64_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, ulong value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool AddBool_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool AddDouble_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, double value);
}
