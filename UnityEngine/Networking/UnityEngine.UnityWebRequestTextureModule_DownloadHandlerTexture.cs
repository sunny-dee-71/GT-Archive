using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using UnityEngine.Bindings;

namespace UnityEngine.Networking;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/UnityWebRequestTexture/Public/DownloadHandlerTexture.h")]
public sealed class DownloadHandlerTexture : DownloadHandler
{
	internal new static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(DownloadHandlerTexture handler)
		{
			return handler.m_Ptr;
		}
	}

	private NativeArray<byte> m_NativeData;

	public Texture2D texture => InternalGetTextureNative();

	private static IntPtr Create([Unmarshalled] DownloadHandlerTexture obj, DownloadedTextureParams parameters)
	{
		return Create_Injected(obj, ref parameters);
	}

	private void InternalCreateTexture(DownloadedTextureParams parameters)
	{
		m_Ptr = Create(this, parameters);
	}

	public DownloadHandlerTexture()
		: this(readable: true)
	{
	}

	public DownloadHandlerTexture(bool readable)
	{
		DownloadedTextureParams parameters = DownloadedTextureParams.Default;
		parameters.readable = readable;
		InternalCreateTexture(parameters);
	}

	public DownloadHandlerTexture(DownloadedTextureParams parameters)
	{
		InternalCreateTexture(parameters);
	}

	protected override NativeArray<byte> GetNativeData()
	{
		return DownloadHandler.InternalGetNativeArray(this, ref m_NativeData);
	}

	public override void Dispose()
	{
		DownloadHandler.DisposeNativeArray(ref m_NativeData);
		base.Dispose();
	}

	[NativeThrows]
	private Texture2D InternalGetTextureNative()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<Texture2D>(InternalGetTextureNative_Injected(intPtr));
	}

	public static Texture2D GetContent(UnityWebRequest www)
	{
		return DownloadHandler.GetCheckedDownloader<DownloadHandlerTexture>(www).texture;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Create_Injected(DownloadHandlerTexture obj, [In] ref DownloadedTextureParams parameters);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr InternalGetTextureNative_Injected(IntPtr _unity_self);
}
