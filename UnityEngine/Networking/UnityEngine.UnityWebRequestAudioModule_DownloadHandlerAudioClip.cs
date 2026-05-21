using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using UnityEngine.Bindings;

namespace UnityEngine.Networking;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/UnityWebRequestAudio/Public/DownloadHandlerAudioClip.h")]
public sealed class DownloadHandlerAudioClip : DownloadHandler
{
	internal new static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(DownloadHandlerAudioClip handler)
		{
			return handler.m_Ptr;
		}
	}

	private NativeArray<byte> m_NativeData;

	[NativeThrows]
	public AudioClip audioClip
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<AudioClip>(get_audioClip_Injected(intPtr));
		}
	}

	public bool streamAudio
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_streamAudio_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_streamAudio_Injected(intPtr, value);
		}
	}

	public bool compressed
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_compressed_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_compressed_Injected(intPtr, value);
		}
	}

	private unsafe static IntPtr Create([Unmarshalled] DownloadHandlerAudioClip obj, string url, AudioType audioType)
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
					return Create_Injected(obj, ref managedSpanWrapper, audioType);
				}
			}
			return Create_Injected(obj, ref managedSpanWrapper, audioType);
		}
		finally
		{
		}
	}

	private void InternalCreateAudioClip(string url, AudioType audioType)
	{
		m_Ptr = Create(this, url, audioType);
	}

	public DownloadHandlerAudioClip(string url, AudioType audioType)
	{
		InternalCreateAudioClip(url, audioType);
	}

	public DownloadHandlerAudioClip(Uri uri, AudioType audioType)
	{
		InternalCreateAudioClip(uri.AbsoluteUri, audioType);
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

	protected override string GetText()
	{
		throw new NotSupportedException("String access is not supported for audio clips");
	}

	public static AudioClip GetContent(UnityWebRequest www)
	{
		return DownloadHandler.GetCheckedDownloader<DownloadHandlerAudioClip>(www).audioClip;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Create_Injected(DownloadHandlerAudioClip obj, ref ManagedSpanWrapper url, AudioType audioType);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_audioClip_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_streamAudio_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_streamAudio_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_compressed_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_compressed_Injected(IntPtr _unity_self, bool value);
}
