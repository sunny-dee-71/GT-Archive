using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine;

[NativeHeader("Modules/AssetBundle/Public/AssetBundleManifest.h")]
public class AssetBundleManifest : Object
{
	private AssetBundleManifest()
	{
	}

	[NativeMethod("GetAllAssetBundles")]
	public string[] GetAllAssetBundles()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetAllAssetBundles_Injected(intPtr);
	}

	[NativeMethod("GetAllAssetBundlesWithVariant")]
	public string[] GetAllAssetBundlesWithVariant()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetAllAssetBundlesWithVariant_Injected(intPtr);
	}

	[NativeMethod("GetAssetBundleHash")]
	public unsafe Hash128 GetAssetBundleHash(string assetBundleName)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		Hash128 ret = default(Hash128);
		Hash128 result;
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(assetBundleName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(assetBundleName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					GetAssetBundleHash_Injected(intPtr, ref managedSpanWrapper, out ret);
				}
			}
			else
			{
				GetAssetBundleHash_Injected(intPtr, ref managedSpanWrapper, out ret);
			}
		}
		finally
		{
			result = ret;
		}
		return result;
	}

	[NativeMethod("GetDirectDependencies")]
	public unsafe string[] GetDirectDependencies(string assetBundleName)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(assetBundleName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(assetBundleName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetDirectDependencies_Injected(intPtr, ref managedSpanWrapper);
				}
			}
			return GetDirectDependencies_Injected(intPtr, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[NativeMethod("GetAllDependencies")]
	public unsafe string[] GetAllDependencies(string assetBundleName)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(assetBundleName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(assetBundleName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetAllDependencies_Injected(intPtr, ref managedSpanWrapper);
				}
			}
			return GetAllDependencies_Injected(intPtr, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string[] GetAllAssetBundles_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string[] GetAllAssetBundlesWithVariant_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetAssetBundleHash_Injected(IntPtr _unity_self, ref ManagedSpanWrapper assetBundleName, out Hash128 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string[] GetDirectDependencies_Injected(IntPtr _unity_self, ref ManagedSpanWrapper assetBundleName);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string[] GetAllDependencies_Injected(IntPtr _unity_self, ref ManagedSpanWrapper assetBundleName);
}
