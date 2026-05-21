using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine;

[Obsolete("This type is deprecated and will be removed in Unity 7.", false)]
[NativeConditional("ENABLE_CLUSTERINPUT")]
[NativeHeader("Modules/ClusterInput/ClusterInput.h")]
public class ClusterInput
{
	public unsafe static float GetAxis(string name)
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
					return GetAxis_Injected(ref managedSpanWrapper);
				}
			}
			return GetAxis_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	public unsafe static bool GetButton(string name)
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
					return GetButton_Injected(ref managedSpanWrapper);
				}
			}
			return GetButton_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[NativeConditional("ENABLE_CLUSTERINPUT", "Vector3f(0.0f, 0.0f, 0.0f)")]
	public unsafe static Vector3 GetTrackerPosition(string name)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		Vector3 ret = default(Vector3);
		Vector3 result;
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					GetTrackerPosition_Injected(ref managedSpanWrapper, out ret);
				}
			}
			else
			{
				GetTrackerPosition_Injected(ref managedSpanWrapper, out ret);
			}
		}
		finally
		{
			result = ret;
		}
		return result;
	}

	[NativeConditional("ENABLE_CLUSTERINPUT", "Quartenion::identity")]
	public unsafe static Quaternion GetTrackerRotation(string name)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		Quaternion ret = default(Quaternion);
		Quaternion result;
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					GetTrackerRotation_Injected(ref managedSpanWrapper, out ret);
				}
			}
			else
			{
				GetTrackerRotation_Injected(ref managedSpanWrapper, out ret);
			}
		}
		finally
		{
			result = ret;
		}
		return result;
	}

	public unsafe static void SetAxis(string name, float value)
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
					SetAxis_Injected(ref managedSpanWrapper, value);
					return;
				}
			}
			SetAxis_Injected(ref managedSpanWrapper, value);
		}
		finally
		{
		}
	}

	public unsafe static void SetButton(string name, bool value)
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
					SetButton_Injected(ref managedSpanWrapper, value);
					return;
				}
			}
			SetButton_Injected(ref managedSpanWrapper, value);
		}
		finally
		{
		}
	}

	public unsafe static void SetTrackerPosition(string name, Vector3 value)
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
					SetTrackerPosition_Injected(ref managedSpanWrapper, ref value);
					return;
				}
			}
			SetTrackerPosition_Injected(ref managedSpanWrapper, ref value);
		}
		finally
		{
		}
	}

	public unsafe static void SetTrackerRotation(string name, Quaternion value)
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
					SetTrackerRotation_Injected(ref managedSpanWrapper, ref value);
					return;
				}
			}
			SetTrackerRotation_Injected(ref managedSpanWrapper, ref value);
		}
		finally
		{
		}
	}

	public unsafe static bool AddInput(string name, string deviceName, string serverUrl, int index, ClusterInputType type)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057, IL_0064, IL_0073, IL_0081, IL_0086 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057, IL_0064, IL_0073, IL_0081, IL_0086 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0086 are reachable both inside and outside the pinned region starting at IL_0073. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0086 are reachable both inside and outside the pinned region starting at IL_0073. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057, IL_0064, IL_0073, IL_0081, IL_0086 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0086 are reachable both inside and outside the pinned region starting at IL_0073. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0086 are reachable both inside and outside the pinned region starting at IL_0073. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper name2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			ref ManagedSpanWrapper deviceName2;
			ManagedSpanWrapper managedSpanWrapper3 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan3;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					name2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(deviceName, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(deviceName);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							deviceName2 = ref managedSpanWrapper2;
							if (!StringMarshaller.TryMarshalEmptyOrNullString(serverUrl, ref managedSpanWrapper3))
							{
								readOnlySpan3 = MemoryExtensions.AsSpan(serverUrl);
								fixed (char* begin3 = readOnlySpan3)
								{
									managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
									return AddInput_Injected(ref name2, ref deviceName2, ref managedSpanWrapper3, index, type);
								}
							}
							return AddInput_Injected(ref name2, ref deviceName2, ref managedSpanWrapper3, index, type);
						}
					}
					deviceName2 = ref managedSpanWrapper2;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(serverUrl, ref managedSpanWrapper3))
					{
						readOnlySpan3 = MemoryExtensions.AsSpan(serverUrl);
						fixed (char* begin3 = readOnlySpan3)
						{
							managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
							return AddInput_Injected(ref name2, ref deviceName2, ref managedSpanWrapper3, index, type);
						}
					}
					return AddInput_Injected(ref name2, ref deviceName2, ref managedSpanWrapper3, index, type);
				}
			}
			name2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(deviceName, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(deviceName);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					deviceName2 = ref managedSpanWrapper2;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(serverUrl, ref managedSpanWrapper3))
					{
						readOnlySpan3 = MemoryExtensions.AsSpan(serverUrl);
						fixed (char* begin3 = readOnlySpan3)
						{
							managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
							return AddInput_Injected(ref name2, ref deviceName2, ref managedSpanWrapper3, index, type);
						}
					}
					return AddInput_Injected(ref name2, ref deviceName2, ref managedSpanWrapper3, index, type);
				}
			}
			deviceName2 = ref managedSpanWrapper2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(serverUrl, ref managedSpanWrapper3))
			{
				readOnlySpan3 = MemoryExtensions.AsSpan(serverUrl);
				fixed (char* begin3 = readOnlySpan3)
				{
					managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
					return AddInput_Injected(ref name2, ref deviceName2, ref managedSpanWrapper3, index, type);
				}
			}
			return AddInput_Injected(ref name2, ref deviceName2, ref managedSpanWrapper3, index, type);
		}
		finally
		{
		}
	}

	public unsafe static bool EditInput(string name, string deviceName, string serverUrl, int index, ClusterInputType type)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057, IL_0064, IL_0073, IL_0081, IL_0086 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057, IL_0064, IL_0073, IL_0081, IL_0086 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0086 are reachable both inside and outside the pinned region starting at IL_0073. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0086 are reachable both inside and outside the pinned region starting at IL_0073. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057, IL_0064, IL_0073, IL_0081, IL_0086 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0086 are reachable both inside and outside the pinned region starting at IL_0073. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0086 are reachable both inside and outside the pinned region starting at IL_0073. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper name2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			ref ManagedSpanWrapper deviceName2;
			ManagedSpanWrapper managedSpanWrapper3 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan3;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					name2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(deviceName, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(deviceName);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							deviceName2 = ref managedSpanWrapper2;
							if (!StringMarshaller.TryMarshalEmptyOrNullString(serverUrl, ref managedSpanWrapper3))
							{
								readOnlySpan3 = MemoryExtensions.AsSpan(serverUrl);
								fixed (char* begin3 = readOnlySpan3)
								{
									managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
									return EditInput_Injected(ref name2, ref deviceName2, ref managedSpanWrapper3, index, type);
								}
							}
							return EditInput_Injected(ref name2, ref deviceName2, ref managedSpanWrapper3, index, type);
						}
					}
					deviceName2 = ref managedSpanWrapper2;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(serverUrl, ref managedSpanWrapper3))
					{
						readOnlySpan3 = MemoryExtensions.AsSpan(serverUrl);
						fixed (char* begin3 = readOnlySpan3)
						{
							managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
							return EditInput_Injected(ref name2, ref deviceName2, ref managedSpanWrapper3, index, type);
						}
					}
					return EditInput_Injected(ref name2, ref deviceName2, ref managedSpanWrapper3, index, type);
				}
			}
			name2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(deviceName, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(deviceName);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					deviceName2 = ref managedSpanWrapper2;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(serverUrl, ref managedSpanWrapper3))
					{
						readOnlySpan3 = MemoryExtensions.AsSpan(serverUrl);
						fixed (char* begin3 = readOnlySpan3)
						{
							managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
							return EditInput_Injected(ref name2, ref deviceName2, ref managedSpanWrapper3, index, type);
						}
					}
					return EditInput_Injected(ref name2, ref deviceName2, ref managedSpanWrapper3, index, type);
				}
			}
			deviceName2 = ref managedSpanWrapper2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(serverUrl, ref managedSpanWrapper3))
			{
				readOnlySpan3 = MemoryExtensions.AsSpan(serverUrl);
				fixed (char* begin3 = readOnlySpan3)
				{
					managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
					return EditInput_Injected(ref name2, ref deviceName2, ref managedSpanWrapper3, index, type);
				}
			}
			return EditInput_Injected(ref name2, ref deviceName2, ref managedSpanWrapper3, index, type);
		}
		finally
		{
		}
	}

	public unsafe static bool CheckConnectionToServer(string name)
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
					return CheckConnectionToServer_Injected(ref managedSpanWrapper);
				}
			}
			return CheckConnectionToServer_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetAxis_Injected(ref ManagedSpanWrapper name);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetButton_Injected(ref ManagedSpanWrapper name);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetTrackerPosition_Injected(ref ManagedSpanWrapper name, out Vector3 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetTrackerRotation_Injected(ref ManagedSpanWrapper name, out Quaternion ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetAxis_Injected(ref ManagedSpanWrapper name, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetButton_Injected(ref ManagedSpanWrapper name, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetTrackerPosition_Injected(ref ManagedSpanWrapper name, [In] ref Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetTrackerRotation_Injected(ref ManagedSpanWrapper name, [In] ref Quaternion value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool AddInput_Injected(ref ManagedSpanWrapper name, ref ManagedSpanWrapper deviceName, ref ManagedSpanWrapper serverUrl, int index, ClusterInputType type);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool EditInput_Injected(ref ManagedSpanWrapper name, ref ManagedSpanWrapper deviceName, ref ManagedSpanWrapper serverUrl, int index, ClusterInputType type);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool CheckConnectionToServer_Injected(ref ManagedSpanWrapper name);
}
