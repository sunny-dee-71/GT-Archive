using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[ExcludeFromDocs]
internal class MyIntPtrObject : IDisposable
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(MyIntPtrObject obj)
		{
			return obj.m_Ptr;
		}

		public static MyIntPtrObject ConvertToManaged(IntPtr ptr)
		{
			return new MyIntPtrObject(ptr);
		}
	}

	public IntPtr m_Ptr;

	public int MemberProperty
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_MemberProperty_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_MemberProperty_Injected(intPtr, value);
		}
	}

	internal MyIntPtrObject(IntPtr ptr)
	{
		m_Ptr = ptr;
	}

	public MyIntPtrObject()
	{
		m_Ptr = Internal_Create();
	}

	public void Dispose()
	{
		if (m_Ptr != IntPtr.Zero)
		{
			Internal_Destroy(m_Ptr);
			m_Ptr = IntPtr.Zero;
		}
	}

	public static MyIntPtrObject Create()
	{
		IntPtr intPtr = Create_Injected();
		return (intPtr == (IntPtr)0) ? null : BindingsMarshaller.ConvertToManaged(intPtr);
	}

	public int MemberFunction(int a)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return MemberFunction_Injected(intPtr, a);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Internal_Create();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_Destroy(IntPtr ptr);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Create_Injected();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int MemberFunction_Injected(IntPtr _unity_self, int a);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_MemberProperty_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_MemberProperty_Injected(IntPtr _unity_self, int value);
}
