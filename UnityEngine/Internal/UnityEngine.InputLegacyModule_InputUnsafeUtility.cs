using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Internal;

[NativeHeader("Runtime/Input/InputBindings.h")]
internal static class InputUnsafeUtility
{
	[NativeThrows]
	internal unsafe static bool GetKeyString(string name)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetKeyString_Injected(ref managedSpanWrapper);
				}
			}
			return GetKeyString_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	[RequiredMember]
	internal unsafe static extern bool GetKeyString__Unmanaged(byte* name, int nameLen);

	[NativeThrows]
	internal unsafe static bool GetKeyUpString(string name)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetKeyUpString_Injected(ref managedSpanWrapper);
				}
			}
			return GetKeyUpString_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	[RequiredMember]
	internal unsafe static extern bool GetKeyUpString__Unmanaged(byte* name, int nameLen);

	[NativeThrows]
	internal unsafe static bool GetKeyDownString(string name)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetKeyDownString_Injected(ref managedSpanWrapper);
				}
			}
			return GetKeyDownString_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	[RequiredMember]
	internal unsafe static extern bool GetKeyDownString__Unmanaged(byte* name, int nameLen);

	[NativeThrows]
	internal unsafe static float GetAxis(string axisName)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(axisName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(axisName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetAxis_Injected(ref managedSpanWrapper);
				}
			}
			return GetAxis_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[RequiredMember]
	[NativeThrows]
	internal unsafe static extern float GetAxis__Unmanaged(byte* axisName, int axisNameLen);

	[NativeThrows]
	internal unsafe static float GetAxisRaw(string axisName)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(axisName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(axisName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetAxisRaw_Injected(ref managedSpanWrapper);
				}
			}
			return GetAxisRaw_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	[RequiredMember]
	internal unsafe static extern float GetAxisRaw__Unmanaged(byte* axisName, int axisNameLen);

	[NativeThrows]
	internal unsafe static bool GetButton(string buttonName)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(buttonName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(buttonName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetButton_Injected(ref managedSpanWrapper);
				}
			}
			return GetButton_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	[RequiredMember]
	internal unsafe static extern bool GetButton__Unmanaged(byte* buttonName, int buttonNameLen);

	[NativeThrows]
	internal unsafe static bool GetButtonDown(string buttonName)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(buttonName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(buttonName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetButtonDown_Injected(ref managedSpanWrapper);
				}
			}
			return GetButtonDown_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	[RequiredMember]
	internal unsafe static extern byte GetButtonDown__Unmanaged(byte* buttonName, int buttonNameLen);

	[NativeThrows]
	internal unsafe static bool GetButtonUp(string buttonName)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(buttonName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(buttonName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetButtonUp_Injected(ref managedSpanWrapper);
				}
			}
			return GetButtonUp_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[RequiredMember]
	[NativeThrows]
	internal unsafe static extern bool GetButtonUp__Unmanaged(byte* buttonName, int buttonNameLen);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetKeyString_Injected(ref ManagedSpanWrapper name);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetKeyUpString_Injected(ref ManagedSpanWrapper name);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetKeyDownString_Injected(ref ManagedSpanWrapper name);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetAxis_Injected(ref ManagedSpanWrapper axisName);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetAxisRaw_Injected(ref ManagedSpanWrapper axisName);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetButton_Injected(ref ManagedSpanWrapper buttonName);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetButtonDown_Injected(ref ManagedSpanWrapper buttonName);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetButtonUp_Injected(ref ManagedSpanWrapper buttonName);
}
