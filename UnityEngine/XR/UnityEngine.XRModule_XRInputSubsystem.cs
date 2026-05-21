using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.XR;

[NativeType(Header = "Modules/XR/Subsystems/Input/XRInputSubsystem.h")]
[UsedByNativeCode]
[NativeConditional("ENABLE_XR")]
public class XRInputSubsystem : IntegratedSubsystem<XRInputSubsystemDescriptor>
{
	internal new static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(XRInputSubsystem xrInputSubsystem)
		{
			return xrInputSubsystem.m_Ptr;
		}
	}

	private List<ulong> m_DeviceIdsCache;

	public event Action<XRInputSubsystem> trackingOriginUpdated;

	public event Action<XRInputSubsystem> boundaryChanged;

	internal uint GetIndex()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetIndex_Injected(intPtr);
	}

	public bool TryRecenter()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return TryRecenter_Injected(intPtr);
	}

	public bool TryGetInputDevices(List<InputDevice> devices)
	{
		if (devices == null)
		{
			throw new ArgumentNullException("devices");
		}
		devices.Clear();
		if (m_DeviceIdsCache == null)
		{
			m_DeviceIdsCache = new List<ulong>();
		}
		m_DeviceIdsCache.Clear();
		TryGetDeviceIds_AsList(m_DeviceIdsCache);
		for (int i = 0; i < m_DeviceIdsCache.Count; i++)
		{
			devices.Add(new InputDevice(m_DeviceIdsCache[i]));
		}
		return true;
	}

	public bool TrySetTrackingOriginMode(TrackingOriginModeFlags origin)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return TrySetTrackingOriginMode_Injected(intPtr, origin);
	}

	public TrackingOriginModeFlags GetTrackingOriginMode()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetTrackingOriginMode_Injected(intPtr);
	}

	public TrackingOriginModeFlags GetSupportedTrackingOriginModes()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetSupportedTrackingOriginModes_Injected(intPtr);
	}

	public bool TryGetBoundaryPoints(List<Vector3> boundaryPoints)
	{
		if (boundaryPoints == null)
		{
			throw new ArgumentNullException("boundaryPoints");
		}
		return TryGetBoundaryPoints_AsList(boundaryPoints);
	}

	private unsafe bool TryGetBoundaryPoints_AsList(List<Vector3> boundaryPoints)
	{
		//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<Vector3> list = default(List<Vector3>);
		BlittableListWrapper boundaryPoints2 = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			list = boundaryPoints;
			if (list != null)
			{
				fixed (Vector3[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					boundaryPoints2 = new BlittableListWrapper(arrayWrapper, list.Count);
					return TryGetBoundaryPoints_AsList_Injected(intPtr, ref boundaryPoints2);
				}
			}
			return TryGetBoundaryPoints_AsList_Injected(intPtr, ref boundaryPoints2);
		}
		finally
		{
			boundaryPoints2.Unmarshal(list);
		}
	}

	[RequiredByNativeCode(GenerateProxy = true)]
	private static void InvokeTrackingOriginUpdatedEvent(IntPtr internalPtr)
	{
		IntegratedSubsystem integratedSubsystemByPtr = SubsystemManager.GetIntegratedSubsystemByPtr(internalPtr);
		if (integratedSubsystemByPtr is XRInputSubsystem { trackingOriginUpdated: not null } xRInputSubsystem)
		{
			xRInputSubsystem.trackingOriginUpdated(xRInputSubsystem);
		}
	}

	[RequiredByNativeCode(GenerateProxy = true)]
	private static void InvokeBoundaryChangedEvent(IntPtr internalPtr)
	{
		IntegratedSubsystem integratedSubsystemByPtr = SubsystemManager.GetIntegratedSubsystemByPtr(internalPtr);
		if (integratedSubsystemByPtr is XRInputSubsystem { boundaryChanged: not null } xRInputSubsystem)
		{
			xRInputSubsystem.boundaryChanged(xRInputSubsystem);
		}
	}

	internal unsafe void TryGetDeviceIds_AsList(List<ulong> deviceIds)
	{
		//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<ulong> list = default(List<ulong>);
		BlittableListWrapper deviceIds2 = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			list = deviceIds;
			if (list != null)
			{
				fixed (ulong[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					deviceIds2 = new BlittableListWrapper(arrayWrapper, list.Count);
					TryGetDeviceIds_AsList_Injected(intPtr, ref deviceIds2);
					return;
				}
			}
			TryGetDeviceIds_AsList_Injected(intPtr, ref deviceIds2);
		}
		finally
		{
			deviceIds2.Unmarshal(list);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern uint GetIndex_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryRecenter_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TrySetTrackingOriginMode_Injected(IntPtr _unity_self, TrackingOriginModeFlags origin);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern TrackingOriginModeFlags GetTrackingOriginMode_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern TrackingOriginModeFlags GetSupportedTrackingOriginModes_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetBoundaryPoints_AsList_Injected(IntPtr _unity_self, ref BlittableListWrapper boundaryPoints);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void TryGetDeviceIds_AsList_Injected(IntPtr _unity_self, ref BlittableListWrapper deviceIds);
}
