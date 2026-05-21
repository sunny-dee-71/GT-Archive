using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Subsystems;

[UsedByNativeCode]
[NativeType(Header = "Modules/Subsystems/Example/ExampleSubsystem.h")]
public class ExampleSubsystem : IntegratedSubsystem<ExampleSubsystemDescriptor>
{
	internal new static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(ExampleSubsystem exampleSubsystem)
		{
			return exampleSubsystem.m_Ptr;
		}
	}

	public void PrintExample()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		PrintExample_Injected(intPtr);
	}

	public bool GetBool()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetBool_Injected(intPtr);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void PrintExample_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetBool_Injected(IntPtr _unity_self);
}
