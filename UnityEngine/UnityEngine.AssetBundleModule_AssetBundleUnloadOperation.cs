using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/AssetBundle/Public/AssetBundleUnloadOperation.h")]
[RequiredByNativeCode]
public class AssetBundleUnloadOperation : AsyncOperation
{
	internal new static class BindingsMarshaller
	{
		public static AssetBundleUnloadOperation ConvertToManaged(IntPtr ptr)
		{
			return new AssetBundleUnloadOperation(ptr);
		}

		public static IntPtr ConvertToNative(AssetBundleUnloadOperation assetBundleUnloadOperation)
		{
			return assetBundleUnloadOperation.m_Ptr;
		}
	}

	[NativeMethod("WaitForCompletion")]
	public void WaitForCompletion()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		WaitForCompletion_Injected(intPtr);
	}

	public AssetBundleUnloadOperation()
	{
	}

	private AssetBundleUnloadOperation(IntPtr ptr)
		: base(ptr)
	{
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void WaitForCompletion_Injected(IntPtr _unity_self);
}
