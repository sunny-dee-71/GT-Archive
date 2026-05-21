using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/AssetBundle/Public/AssetBundleRecompressOperation.h")]
[RequiredByNativeCode]
public class AssetBundleRecompressOperation : AsyncOperation
{
	internal new static class BindingsMarshaller
	{
		public static AssetBundleRecompressOperation ConvertToManaged(IntPtr ptr)
		{
			return new AssetBundleRecompressOperation(ptr);
		}

		public static IntPtr ConvertToNative(AssetBundleRecompressOperation op)
		{
			return op.m_Ptr;
		}
	}

	public string humanReadableResult
	{
		[NativeMethod("GetResultStr")]
		get
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_humanReadableResult_Injected(intPtr, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}
	}

	public string inputPath
	{
		[NativeMethod("GetInputPath")]
		get
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_inputPath_Injected(intPtr, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}
	}

	public string outputPath
	{
		[NativeMethod("GetOutputPath")]
		get
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_outputPath_Injected(intPtr, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}
	}

	public AssetBundleLoadResult result
	{
		[NativeMethod("GetResult")]
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_result_Injected(intPtr);
		}
	}

	public bool success
	{
		[NativeMethod("GetSuccess")]
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_success_Injected(intPtr);
		}
	}

	public AssetBundleRecompressOperation()
	{
	}

	private AssetBundleRecompressOperation(IntPtr ptr)
		: base(ptr)
	{
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_humanReadableResult_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_inputPath_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_outputPath_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern AssetBundleLoadResult get_result_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_success_Injected(IntPtr _unity_self);
}
