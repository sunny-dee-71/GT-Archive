using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine;

[StructLayout(LayoutKind.Sequential)]
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal class MarshallingTestObject : Object
{
	[RequiredMember]
	[RequiredByNativeCode(Optional = true)]
	private int TestField;

	public int MemberProperty
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_MemberProperty_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_MemberProperty_Injected(intPtr, value);
		}
	}

	[NativeProperty("m_fieldBoundProp", false, TargetType.Field)]
	public int FieldBoundMemberProperty
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_FieldBoundMemberProperty_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_FieldBoundMemberProperty_Injected(intPtr, value);
		}
	}

	public MarshallingTestObject()
	{
		Internal_CreateMarshallingTestObject(this);
	}

	public int MemberFunction(int a)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return MemberFunction_Injected(intPtr, a);
	}

	public static MarshallingTestObject Create()
	{
		return Unmarshal.UnmarshalUnityObject<MarshallingTestObject>(Create_Injected());
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_CreateMarshallingTestObject([Writable] MarshallingTestObject notSelf);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int MemberFunction_Injected(IntPtr _unity_self, int a);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_MemberProperty_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_MemberProperty_Injected(IntPtr _unity_self, int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_FieldBoundMemberProperty_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_FieldBoundMemberProperty_Injected(IntPtr _unity_self, int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Create_Injected();
}
