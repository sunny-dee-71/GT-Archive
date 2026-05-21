using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.XR;

[StaticAccessor("XRInputDevices::Get()", StaticAccessorType.Dot)]
[RequiredByNativeCode]
[NativeHeader("Modules/XR/Subsystems/Input/Public/XRInputDevices.h")]
[NativeHeader("XRScriptingClasses.h")]
[NativeConditional("ENABLE_VR")]
[NativeHeader("Modules/XR/XRPrefix.h")]
public struct Hand : IEquatable<Hand>
{
	private ulong m_DeviceId;

	private uint m_FeatureIndex;

	internal ulong deviceId => m_DeviceId;

	internal uint featureIndex => m_FeatureIndex;

	public bool TryGetRootBone(out Bone boneOut)
	{
		return Hand_TryGetRootBone(this, out boneOut);
	}

	private static bool Hand_TryGetRootBone(Hand hand, out Bone boneOut)
	{
		return Hand_TryGetRootBone_Injected(ref hand, out boneOut);
	}

	public bool TryGetFingerBones(HandFinger finger, List<Bone> bonesOut)
	{
		if (bonesOut == null)
		{
			throw new ArgumentNullException("bonesOut");
		}
		return Hand_TryGetFingerBonesAsList(this, finger, bonesOut);
	}

	private unsafe static bool Hand_TryGetFingerBonesAsList(Hand hand, HandFinger finger, [NotNull] List<Bone> bonesOut)
	{
		if (bonesOut == null)
		{
			ThrowHelper.ThrowArgumentNullException(bonesOut, "bonesOut");
		}
		List<Bone> list = default(List<Bone>);
		BlittableListWrapper bonesOut2 = default(BlittableListWrapper);
		try
		{
			list = bonesOut;
			fixed (Bone[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				bonesOut2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return Hand_TryGetFingerBonesAsList_Injected(ref hand, finger, ref bonesOut2);
			}
		}
		finally
		{
			bonesOut2.Unmarshal(list);
		}
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Hand))
		{
			return false;
		}
		return Equals((Hand)obj);
	}

	public bool Equals(Hand other)
	{
		return deviceId == other.deviceId && featureIndex == other.featureIndex;
	}

	public override int GetHashCode()
	{
		return deviceId.GetHashCode() ^ (featureIndex.GetHashCode() << 1);
	}

	public static bool operator ==(Hand a, Hand b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(Hand a, Hand b)
	{
		return !(a == b);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool Hand_TryGetRootBone_Injected([In] ref Hand hand, out Bone boneOut);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool Hand_TryGetFingerBonesAsList_Injected([In] ref Hand hand, HandFinger finger, ref BlittableListWrapper bonesOut);
}
