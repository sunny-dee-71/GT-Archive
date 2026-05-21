using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using UnityEngine.Bindings;

namespace UnityEngine.Networking;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/UnityWebRequest/Public/DownloadHandler/DownloadHandlerBuffer.h")]
public sealed class DownloadHandlerBuffer : DownloadHandler
{
	internal new static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(DownloadHandlerBuffer handler)
		{
			return handler.m_Ptr;
		}
	}

	private NativeArray<byte> m_NativeData;

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Create([Unmarshalled] DownloadHandlerBuffer obj);

	private void InternalCreateBuffer()
	{
		m_Ptr = Create(this);
	}

	public DownloadHandlerBuffer()
	{
		InternalCreateBuffer();
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

	public static string GetContent(UnityWebRequest www)
	{
		return DownloadHandler.GetCheckedDownloader<DownloadHandlerBuffer>(www).text;
	}
}
