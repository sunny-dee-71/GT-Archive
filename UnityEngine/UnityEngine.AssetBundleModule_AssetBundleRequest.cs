using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine;

[StructLayout(LayoutKind.Sequential)]
[RequiredByNativeCode]
[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadAssetOperation.h")]
public class AssetBundleRequest : ResourceRequest
{
	internal new static class BindingsMarshaller
	{
		public static AssetBundleRequest ConvertToManaged(IntPtr ptr)
		{
			return new AssetBundleRequest(ptr);
		}

		public static IntPtr ConvertToNative(AssetBundleRequest request)
		{
			return request.m_Ptr;
		}
	}

	public new Object asset => GetResult();

	public Object[] allAssets
	{
		[NativeMethod("GetAllLoadedAssets")]
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_allAssets_Injected(intPtr);
		}
	}

	[NativeMethod("GetLoadedAsset")]
	protected override Object GetResult()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<Object>(GetResult_Injected(intPtr));
	}

	public AssetBundleRequest()
	{
	}

	private AssetBundleRequest(IntPtr ptr)
		: base(ptr)
	{
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetResult_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Object[] get_allAssets_Injected(IntPtr _unity_self);
}
