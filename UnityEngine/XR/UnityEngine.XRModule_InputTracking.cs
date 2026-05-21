using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.XR;

[NativeHeader("Modules/XR/Subsystems/Input/Public/XRInputTrackingFacade.h")]
[RequiredByNativeCode]
[StaticAccessor("XRInputTrackingFacade::Get()", StaticAccessorType.Dot)]
[NativeConditional("ENABLE_VR")]
public static class InputTracking
{
	private enum TrackingStateEventType
	{
		NodeAdded,
		NodeRemoved,
		TrackingAcquired,
		TrackingLost
	}

	[NativeConditional("ENABLE_VR")]
	[Obsolete("This API is obsolete, and should no longer be used. Please use the TrackedPoseDriver in the Legacy Input Helpers package for controlling a camera in XR.")]
	public static extern bool disablePositionalTracking
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeName("GetPositionalTrackingDisabled")]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeName("SetPositionalTrackingDisabled")]
		set;
	}

	public static event Action<XRNodeState> trackingAcquired;

	public static event Action<XRNodeState> trackingLost;

	public static event Action<XRNodeState> nodeAdded;

	public static event Action<XRNodeState> nodeRemoved;

	[RequiredByNativeCode]
	private static void InvokeTrackingEvent(TrackingStateEventType eventType, XRNode nodeType, long uniqueID, bool tracked)
	{
		Action<XRNodeState> action = null;
		XRNodeState obj = new XRNodeState
		{
			uniqueID = (ulong)uniqueID,
			nodeType = nodeType,
			tracked = tracked
		};
		((Action<XRNodeState>)(eventType switch
		{
			TrackingStateEventType.TrackingAcquired => InputTracking.trackingAcquired, 
			TrackingStateEventType.TrackingLost => InputTracking.trackingLost, 
			TrackingStateEventType.NodeAdded => InputTracking.nodeAdded, 
			TrackingStateEventType.NodeRemoved => InputTracking.nodeRemoved, 
			_ => throw new ArgumentException("TrackingEventHandler - Invalid EventType: " + eventType), 
		}))?.Invoke(obj);
	}

	[NativeConditional("ENABLE_VR", "Vector3f::zero")]
	[Obsolete("This API is obsolete, and should no longer be used. Please use InputDevice.TryGetFeatureValue with the CommonUsages.devicePosition usage instead.")]
	public static Vector3 GetLocalPosition(XRNode node)
	{
		GetLocalPosition_Injected(node, out var ret);
		return ret;
	}

	[NativeConditional("ENABLE_VR", "Quaternionf::identity()")]
	[Obsolete("This API is obsolete, and should no longer be used. Please use InputDevice.TryGetFeatureValue with the CommonUsages.deviceRotation usage instead.")]
	public static Quaternion GetLocalRotation(XRNode node)
	{
		GetLocalRotation_Injected(node, out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[Obsolete("This API is obsolete, and should no longer be used. Please use XRInputSubsystem.TryRecenter() instead.")]
	[NativeConditional("ENABLE_VR")]
	public static extern void Recenter();

	[NativeConditional("ENABLE_VR")]
	[Obsolete("This API is obsolete, and should no longer be used. Please use InputDevice.name with the device associated with that tracking data instead.")]
	public static string GetNodeName(ulong uniqueId)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			GetNodeName_Injected(uniqueId, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static void GetNodeStates(List<XRNodeState> nodeStates)
	{
		if (nodeStates == null)
		{
			throw new ArgumentNullException("nodeStates");
		}
		nodeStates.Clear();
		GetNodeStates_Internal(nodeStates);
	}

	[NativeConditional("ENABLE_VR")]
	private unsafe static void GetNodeStates_Internal([NotNull] List<XRNodeState> nodeStates)
	{
		if (nodeStates == null)
		{
			ThrowHelper.ThrowArgumentNullException(nodeStates, "nodeStates");
		}
		List<XRNodeState> list = default(List<XRNodeState>);
		BlittableListWrapper nodeStates2 = default(BlittableListWrapper);
		try
		{
			list = nodeStates;
			fixed (XRNodeState[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				nodeStates2 = new BlittableListWrapper(arrayWrapper, list.Count);
				GetNodeStates_Internal_Injected(ref nodeStates2);
			}
		}
		finally
		{
			nodeStates2.Unmarshal(list);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeHeader("Modules/XR/Subsystems/Input/Public/XRInputTracking.h")]
	[StaticAccessor("XRInputTracking::Get()", StaticAccessorType.Dot)]
	internal static extern ulong GetDeviceIdAtXRNode(XRNode node);

	[NativeHeader("Modules/XR/Subsystems/Input/Public/XRInputTracking.h")]
	[StaticAccessor("XRInputTracking::Get()", StaticAccessorType.Dot)]
	internal unsafe static void GetDeviceIdsAtXRNode_Internal(XRNode node, [NotNull] List<ulong> deviceIds)
	{
		if (deviceIds == null)
		{
			ThrowHelper.ThrowArgumentNullException(deviceIds, "deviceIds");
		}
		List<ulong> list = default(List<ulong>);
		BlittableListWrapper deviceIds2 = default(BlittableListWrapper);
		try
		{
			list = deviceIds;
			fixed (ulong[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				deviceIds2 = new BlittableListWrapper(arrayWrapper, list.Count);
				GetDeviceIdsAtXRNode_Internal_Injected(node, ref deviceIds2);
			}
		}
		finally
		{
			deviceIds2.Unmarshal(list);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetLocalPosition_Injected(XRNode node, out Vector3 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetLocalRotation_Injected(XRNode node, out Quaternion ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetNodeName_Injected(ulong uniqueId, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetNodeStates_Internal_Injected(ref BlittableListWrapper nodeStates);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetDeviceIdsAtXRNode_Internal_Injected(XRNode node, ref BlittableListWrapper deviceIds);
}
