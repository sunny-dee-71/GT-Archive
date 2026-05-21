using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.XR;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/XR/Subsystems/Input/Public/XRInputDevices.h")]
[StaticAccessor("XRInputDevices::Get()", StaticAccessorType.Dot)]
[UsedByNativeCode]
[NativeConditional("ENABLE_VR")]
public class InputDevices
{
	private static List<InputDevice> s_InputDeviceList;

	public static event Action<InputDevice> deviceConnected;

	public static event Action<InputDevice> deviceDisconnected;

	public static event Action<InputDevice> deviceConfigChanged;

	public static InputDevice GetDeviceAtXRNode(XRNode node)
	{
		ulong deviceIdAtXRNode = InputTracking.GetDeviceIdAtXRNode(node);
		return new InputDevice(deviceIdAtXRNode);
	}

	public static void GetDevicesAtXRNode(XRNode node, List<InputDevice> inputDevices)
	{
		if (inputDevices == null)
		{
			throw new ArgumentNullException("inputDevices");
		}
		List<ulong> list = new List<ulong>();
		InputTracking.GetDeviceIdsAtXRNode_Internal(node, list);
		inputDevices.Clear();
		foreach (ulong item2 in list)
		{
			InputDevice item = new InputDevice(item2);
			if (item.isValid)
			{
				inputDevices.Add(item);
			}
		}
	}

	public static void GetDevices(List<InputDevice> inputDevices)
	{
		if (inputDevices == null)
		{
			throw new ArgumentNullException("inputDevices");
		}
		inputDevices.Clear();
		GetDevices_Internal(inputDevices);
	}

	[Obsolete("This API has been marked as deprecated and will be removed in future versions. Please use InputDevices.GetDevicesWithCharacteristics instead.")]
	public static void GetDevicesWithRole(InputDeviceRole role, List<InputDevice> inputDevices)
	{
		if (inputDevices == null)
		{
			throw new ArgumentNullException("inputDevices");
		}
		if (s_InputDeviceList == null)
		{
			s_InputDeviceList = new List<InputDevice>();
		}
		GetDevices_Internal(s_InputDeviceList);
		inputDevices.Clear();
		foreach (InputDevice s_InputDevice in s_InputDeviceList)
		{
			if (s_InputDevice.role == role)
			{
				inputDevices.Add(s_InputDevice);
			}
		}
	}

	public static void GetDevicesWithCharacteristics(InputDeviceCharacteristics desiredCharacteristics, List<InputDevice> inputDevices)
	{
		if (inputDevices == null)
		{
			throw new ArgumentNullException("inputDevices");
		}
		if (s_InputDeviceList == null)
		{
			s_InputDeviceList = new List<InputDevice>();
		}
		GetDevices_Internal(s_InputDeviceList);
		inputDevices.Clear();
		foreach (InputDevice s_InputDevice in s_InputDeviceList)
		{
			if ((s_InputDevice.characteristics & desiredCharacteristics) == desiredCharacteristics)
			{
				inputDevices.Add(s_InputDevice);
			}
		}
	}

	[RequiredByNativeCode]
	private static void InvokeConnectionEvent(ulong deviceId, ConnectionChangeType change)
	{
		switch (change)
		{
		case ConnectionChangeType.Connected:
			if (InputDevices.deviceConnected != null)
			{
				InputDevices.deviceConnected(new InputDevice(deviceId));
			}
			break;
		case ConnectionChangeType.Disconnected:
			if (InputDevices.deviceDisconnected != null)
			{
				InputDevices.deviceDisconnected(new InputDevice(deviceId));
			}
			break;
		case ConnectionChangeType.ConfigChange:
			if (InputDevices.deviceConfigChanged != null)
			{
				InputDevices.deviceConfigChanged(new InputDevice(deviceId));
			}
			break;
		}
	}

	private unsafe static void GetDevices_Internal([NotNull] List<InputDevice> inputDevices)
	{
		if (inputDevices == null)
		{
			ThrowHelper.ThrowArgumentNullException(inputDevices, "inputDevices");
		}
		List<InputDevice> list = default(List<InputDevice>);
		BlittableListWrapper inputDevices2 = default(BlittableListWrapper);
		try
		{
			list = inputDevices;
			fixed (InputDevice[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				inputDevices2 = new BlittableListWrapper(arrayWrapper, list.Count);
				GetDevices_Internal_Injected(ref inputDevices2);
			}
		}
		finally
		{
			inputDevices2.Unmarshal(list);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool SendHapticImpulse(ulong deviceId, uint channel, float amplitude, float duration);

	internal unsafe static bool SendHapticBuffer(ulong deviceId, uint channel, [NotNull] byte[] buffer)
	{
		if (buffer == null)
		{
			ThrowHelper.ThrowArgumentNullException(buffer, "buffer");
		}
		Span<byte> span = new Span<byte>(buffer);
		bool result;
		fixed (byte* begin = span)
		{
			ManagedSpanWrapper buffer2 = new ManagedSpanWrapper(begin, span.Length);
			result = SendHapticBuffer_Injected(deviceId, channel, ref buffer2);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool TryGetHapticCapabilities(ulong deviceId, out HapticCapabilities capabilities);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void StopHaptics(ulong deviceId);

	internal static bool TryGetFeatureUsages(ulong deviceId, [NotNull] List<InputFeatureUsage> featureUsages)
	{
		if (featureUsages == null)
		{
			ThrowHelper.ThrowArgumentNullException(featureUsages, "featureUsages");
		}
		return TryGetFeatureUsages_Injected(deviceId, featureUsages);
	}

	internal unsafe static bool TryGetFeatureValue_bool(ulong deviceId, string usage, out bool value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return TryGetFeatureValue_bool_Injected(deviceId, ref managedSpanWrapper, out value);
				}
			}
			return TryGetFeatureValue_bool_Injected(deviceId, ref managedSpanWrapper, out value);
		}
		finally
		{
		}
	}

	internal unsafe static bool TryGetFeatureValue_UInt32(ulong deviceId, string usage, out uint value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return TryGetFeatureValue_UInt32_Injected(deviceId, ref managedSpanWrapper, out value);
				}
			}
			return TryGetFeatureValue_UInt32_Injected(deviceId, ref managedSpanWrapper, out value);
		}
		finally
		{
		}
	}

	internal unsafe static bool TryGetFeatureValue_float(ulong deviceId, string usage, out float value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return TryGetFeatureValue_float_Injected(deviceId, ref managedSpanWrapper, out value);
				}
			}
			return TryGetFeatureValue_float_Injected(deviceId, ref managedSpanWrapper, out value);
		}
		finally
		{
		}
	}

	internal unsafe static bool TryGetFeatureValue_Vector2f(ulong deviceId, string usage, out Vector2 value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return TryGetFeatureValue_Vector2f_Injected(deviceId, ref managedSpanWrapper, out value);
				}
			}
			return TryGetFeatureValue_Vector2f_Injected(deviceId, ref managedSpanWrapper, out value);
		}
		finally
		{
		}
	}

	internal unsafe static bool TryGetFeatureValue_Vector3f(ulong deviceId, string usage, out Vector3 value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return TryGetFeatureValue_Vector3f_Injected(deviceId, ref managedSpanWrapper, out value);
				}
			}
			return TryGetFeatureValue_Vector3f_Injected(deviceId, ref managedSpanWrapper, out value);
		}
		finally
		{
		}
	}

	internal unsafe static bool TryGetFeatureValue_Quaternionf(ulong deviceId, string usage, out Quaternion value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return TryGetFeatureValue_Quaternionf_Injected(deviceId, ref managedSpanWrapper, out value);
				}
			}
			return TryGetFeatureValue_Quaternionf_Injected(deviceId, ref managedSpanWrapper, out value);
		}
		finally
		{
		}
	}

	internal unsafe static bool TryGetFeatureValue_Custom(ulong deviceId, string usage, [Out] byte[] value)
	{
		//The blocks IL_002a, IL_0030, IL_0036, IL_0038, IL_004c are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_004c are reachable both inside and outside the pinned region starting at IL_0031. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper value2 = default(BlittableArrayWrapper);
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper usage2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					usage2 = ref managedSpanWrapper;
					if (value != null)
					{
						fixed (byte[] array = value)
						{
							if (array.Length != 0)
							{
								value2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
							}
							return TryGetFeatureValue_Custom_Injected(deviceId, ref usage2, out value2);
						}
					}
					return TryGetFeatureValue_Custom_Injected(deviceId, ref usage2, out value2);
				}
			}
			usage2 = ref managedSpanWrapper;
			if (value != null)
			{
				array = value;
				if (array.Length != 0)
				{
					value2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
			}
			return TryGetFeatureValue_Custom_Injected(deviceId, ref usage2, out value2);
		}
		finally
		{
			value2.Unmarshal(ref array);
		}
	}

	internal unsafe static bool TryGetFeatureValueAtTime_bool(ulong deviceId, string usage, long time, out bool value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return TryGetFeatureValueAtTime_bool_Injected(deviceId, ref managedSpanWrapper, time, out value);
				}
			}
			return TryGetFeatureValueAtTime_bool_Injected(deviceId, ref managedSpanWrapper, time, out value);
		}
		finally
		{
		}
	}

	internal unsafe static bool TryGetFeatureValueAtTime_UInt32(ulong deviceId, string usage, long time, out uint value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return TryGetFeatureValueAtTime_UInt32_Injected(deviceId, ref managedSpanWrapper, time, out value);
				}
			}
			return TryGetFeatureValueAtTime_UInt32_Injected(deviceId, ref managedSpanWrapper, time, out value);
		}
		finally
		{
		}
	}

	internal unsafe static bool TryGetFeatureValueAtTime_float(ulong deviceId, string usage, long time, out float value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return TryGetFeatureValueAtTime_float_Injected(deviceId, ref managedSpanWrapper, time, out value);
				}
			}
			return TryGetFeatureValueAtTime_float_Injected(deviceId, ref managedSpanWrapper, time, out value);
		}
		finally
		{
		}
	}

	internal unsafe static bool TryGetFeatureValueAtTime_Vector2f(ulong deviceId, string usage, long time, out Vector2 value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return TryGetFeatureValueAtTime_Vector2f_Injected(deviceId, ref managedSpanWrapper, time, out value);
				}
			}
			return TryGetFeatureValueAtTime_Vector2f_Injected(deviceId, ref managedSpanWrapper, time, out value);
		}
		finally
		{
		}
	}

	internal unsafe static bool TryGetFeatureValueAtTime_Vector3f(ulong deviceId, string usage, long time, out Vector3 value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return TryGetFeatureValueAtTime_Vector3f_Injected(deviceId, ref managedSpanWrapper, time, out value);
				}
			}
			return TryGetFeatureValueAtTime_Vector3f_Injected(deviceId, ref managedSpanWrapper, time, out value);
		}
		finally
		{
		}
	}

	internal unsafe static bool TryGetFeatureValueAtTime_Quaternionf(ulong deviceId, string usage, long time, out Quaternion value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return TryGetFeatureValueAtTime_Quaternionf_Injected(deviceId, ref managedSpanWrapper, time, out value);
				}
			}
			return TryGetFeatureValueAtTime_Quaternionf_Injected(deviceId, ref managedSpanWrapper, time, out value);
		}
		finally
		{
		}
	}

	internal unsafe static bool TryGetFeatureValue_XRHand(ulong deviceId, string usage, out Hand value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return TryGetFeatureValue_XRHand_Injected(deviceId, ref managedSpanWrapper, out value);
				}
			}
			return TryGetFeatureValue_XRHand_Injected(deviceId, ref managedSpanWrapper, out value);
		}
		finally
		{
		}
	}

	internal unsafe static bool TryGetFeatureValue_XRBone(ulong deviceId, string usage, out Bone value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return TryGetFeatureValue_XRBone_Injected(deviceId, ref managedSpanWrapper, out value);
				}
			}
			return TryGetFeatureValue_XRBone_Injected(deviceId, ref managedSpanWrapper, out value);
		}
		finally
		{
		}
	}

	internal unsafe static bool TryGetFeatureValue_XREyes(ulong deviceId, string usage, out Eyes value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return TryGetFeatureValue_XREyes_Injected(deviceId, ref managedSpanWrapper, out value);
				}
			}
			return TryGetFeatureValue_XREyes_Injected(deviceId, ref managedSpanWrapper, out value);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool IsDeviceValid(ulong deviceId);

	internal static string GetDeviceName(ulong deviceId)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			GetDeviceName_Injected(deviceId, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	internal static string GetDeviceManufacturer(ulong deviceId)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			GetDeviceManufacturer_Injected(deviceId, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	internal static string GetDeviceSerialNumber(ulong deviceId)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			GetDeviceSerialNumber_Injected(deviceId, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern InputDeviceCharacteristics GetDeviceCharacteristics(ulong deviceId);

	internal static InputDeviceRole GetDeviceRole(ulong deviceId)
	{
		InputDeviceCharacteristics deviceCharacteristics = GetDeviceCharacteristics(deviceId);
		if ((deviceCharacteristics & (InputDeviceCharacteristics.HeadMounted | InputDeviceCharacteristics.TrackedDevice)) == (InputDeviceCharacteristics.HeadMounted | InputDeviceCharacteristics.TrackedDevice))
		{
			return InputDeviceRole.Generic;
		}
		if ((deviceCharacteristics & (InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Left)) == (InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Left))
		{
			return InputDeviceRole.LeftHanded;
		}
		if ((deviceCharacteristics & (InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Right)) == (InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Right))
		{
			return InputDeviceRole.RightHanded;
		}
		if ((deviceCharacteristics & InputDeviceCharacteristics.Controller) == InputDeviceCharacteristics.Controller)
		{
			return InputDeviceRole.GameController;
		}
		if ((deviceCharacteristics & (InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.TrackingReference)) == (InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.TrackingReference))
		{
			return InputDeviceRole.TrackingReference;
		}
		if ((deviceCharacteristics & InputDeviceCharacteristics.TrackedDevice) == InputDeviceCharacteristics.TrackedDevice)
		{
			return InputDeviceRole.HardwareTracker;
		}
		return InputDeviceRole.Unknown;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetDevices_Internal_Injected(ref BlittableListWrapper inputDevices);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool SendHapticBuffer_Injected(ulong deviceId, uint channel, ref ManagedSpanWrapper buffer);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetFeatureUsages_Injected(ulong deviceId, List<InputFeatureUsage> featureUsages);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetFeatureValue_bool_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetFeatureValue_UInt32_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out uint value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetFeatureValue_float_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetFeatureValue_Vector2f_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetFeatureValue_Vector3f_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetFeatureValue_Quaternionf_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out Quaternion value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetFeatureValue_Custom_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out BlittableArrayWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetFeatureValueAtTime_bool_Injected(ulong deviceId, ref ManagedSpanWrapper usage, long time, out bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetFeatureValueAtTime_UInt32_Injected(ulong deviceId, ref ManagedSpanWrapper usage, long time, out uint value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetFeatureValueAtTime_float_Injected(ulong deviceId, ref ManagedSpanWrapper usage, long time, out float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetFeatureValueAtTime_Vector2f_Injected(ulong deviceId, ref ManagedSpanWrapper usage, long time, out Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetFeatureValueAtTime_Vector3f_Injected(ulong deviceId, ref ManagedSpanWrapper usage, long time, out Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetFeatureValueAtTime_Quaternionf_Injected(ulong deviceId, ref ManagedSpanWrapper usage, long time, out Quaternion value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetFeatureValue_XRHand_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out Hand value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetFeatureValue_XRBone_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out Bone value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetFeatureValue_XREyes_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out Eyes value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetDeviceName_Injected(ulong deviceId, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetDeviceManufacturer_Injected(ulong deviceId, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetDeviceSerialNumber_Injected(ulong deviceId, out ManagedSpanWrapper ret);
}
