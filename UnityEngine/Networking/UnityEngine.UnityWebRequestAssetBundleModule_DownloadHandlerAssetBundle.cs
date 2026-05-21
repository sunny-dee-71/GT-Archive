using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine.Networking;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/UnityWebRequestAssetBundle/Public/DownloadHandlerAssetBundle.h")]
public sealed class DownloadHandlerAssetBundle : DownloadHandler
{
	internal new static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(DownloadHandlerAssetBundle handler)
		{
			return handler.m_Ptr;
		}
	}

	public AssetBundle assetBundle
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<AssetBundle>(get_assetBundle_Injected(intPtr));
		}
	}

	public bool autoLoadAssetBundle
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_autoLoadAssetBundle_Injected(intPtr);
		}
		[NativeThrows]
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_autoLoadAssetBundle_Injected(intPtr, value);
		}
	}

	public bool isDownloadComplete
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_isDownloadComplete_Injected(intPtr);
		}
	}

	private unsafe static IntPtr Create([Unmarshalled] DownloadHandlerAssetBundle obj, string url, uint crc)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(url, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(url);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return Create_Injected(obj, ref managedSpanWrapper, crc);
				}
			}
			return Create_Injected(obj, ref managedSpanWrapper, crc);
		}
		finally
		{
		}
	}

	private unsafe static IntPtr CreateCached([Unmarshalled] DownloadHandlerAssetBundle obj, string url, string name, Hash128 hash, uint crc)
	{
		//The blocks IL_002a, IL_0037, IL_0045, IL_0053, IL_0058 are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0058 are reachable both inside and outside the pinned region starting at IL_0045. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0058 are reachable both inside and outside the pinned region starting at IL_0045. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper url2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(url, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(url);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					url2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(name);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							return CreateCached_Injected(obj, ref url2, ref managedSpanWrapper2, ref hash, crc);
						}
					}
					return CreateCached_Injected(obj, ref url2, ref managedSpanWrapper2, ref hash, crc);
				}
			}
			url2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(name);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					return CreateCached_Injected(obj, ref url2, ref managedSpanWrapper2, ref hash, crc);
				}
			}
			return CreateCached_Injected(obj, ref url2, ref managedSpanWrapper2, ref hash, crc);
		}
		finally
		{
		}
	}

	private void InternalCreateAssetBundle(string url, uint crc)
	{
		m_Ptr = Create(this, url, crc);
	}

	private void InternalCreateAssetBundleCached(string url, string name, Hash128 hash, uint crc)
	{
		m_Ptr = CreateCached(this, url, name, hash, crc);
	}

	public DownloadHandlerAssetBundle(string url, uint crc)
	{
		InternalCreateAssetBundle(url, crc);
	}

	public DownloadHandlerAssetBundle(string url, uint version, uint crc)
	{
		InternalCreateAssetBundleCached(url, "", new Hash128(0u, 0u, 0u, version), crc);
	}

	public DownloadHandlerAssetBundle(string url, Hash128 hash, uint crc)
	{
		InternalCreateAssetBundleCached(url, "", hash, crc);
	}

	public DownloadHandlerAssetBundle(string url, string name, Hash128 hash, uint crc)
	{
		InternalCreateAssetBundleCached(url, name, hash, crc);
	}

	public DownloadHandlerAssetBundle(string url, CachedAssetBundle cachedBundle, uint crc)
	{
		InternalCreateAssetBundleCached(url, cachedBundle.name, cachedBundle.hash, crc);
	}

	protected override byte[] GetData()
	{
		throw new NotSupportedException("Raw data access is not supported for asset bundles");
	}

	protected override string GetText()
	{
		throw new NotSupportedException("String access is not supported for asset bundles");
	}

	public static AssetBundle GetContent(UnityWebRequest www)
	{
		return DownloadHandler.GetCheckedDownloader<DownloadHandlerAssetBundle>(www).assetBundle;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Create_Injected(DownloadHandlerAssetBundle obj, ref ManagedSpanWrapper url, uint crc);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr CreateCached_Injected(DownloadHandlerAssetBundle obj, ref ManagedSpanWrapper url, ref ManagedSpanWrapper name, [In] ref Hash128 hash, uint crc);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_assetBundle_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_autoLoadAssetBundle_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_autoLoadAssetBundle_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_isDownloadComplete_Injected(IntPtr _unity_self);
}
