using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngineInternal.Video;

[UsedByNativeCode]
[NativeHeader("Modules/Video/Public/Base/VideoMediaPlayback.h")]
internal class VideoPlaybackMgr : IDisposable
{
	public delegate void Callback();

	public delegate void MessageCallback(string message);

	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(VideoPlaybackMgr videoPlaybackMgr)
		{
			return videoPlaybackMgr.m_Ptr;
		}
	}

	internal IntPtr m_Ptr;

	public ulong videoPlaybackCount
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_videoPlaybackCount_Injected(intPtr);
		}
	}

	public VideoPlaybackMgr()
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
		GC.SuppressFinalize(this);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Internal_Create();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_Destroy(IntPtr ptr);

	public unsafe VideoPlayback CreateVideoPlayback(string fileName, MessageCallback errorCallback, Callback readyCallback, Callback reachedEndCallback, bool splitAlpha = false)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		IntPtr intPtr2 = default(IntPtr);
		VideoPlayback result;
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(fileName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(fileName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					intPtr2 = CreateVideoPlayback_Injected(intPtr, ref managedSpanWrapper, errorCallback, readyCallback, reachedEndCallback, splitAlpha);
				}
			}
			else
			{
				intPtr2 = CreateVideoPlayback_Injected(intPtr, ref managedSpanWrapper, errorCallback, readyCallback, reachedEndCallback, splitAlpha);
			}
		}
		finally
		{
			IntPtr intPtr3 = intPtr2;
			result = ((intPtr3 == (IntPtr)0) ? null : VideoPlayback.BindingsMarshaller.ConvertToManaged(intPtr3));
		}
		return result;
	}

	public void ReleaseVideoPlayback(VideoPlayback playback)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ReleaseVideoPlayback_Injected(intPtr, (playback == null) ? ((IntPtr)0) : VideoPlayback.BindingsMarshaller.ConvertToNative(playback));
	}

	public void Update()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Update_Injected(intPtr);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void ProcessOSMainLoopMessagesForTesting();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr CreateVideoPlayback_Injected(IntPtr _unity_self, ref ManagedSpanWrapper fileName, MessageCallback errorCallback, Callback readyCallback, Callback reachedEndCallback, bool splitAlpha);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReleaseVideoPlayback_Injected(IntPtr _unity_self, IntPtr playback);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern ulong get_videoPlaybackCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Update_Injected(IntPtr _unity_self);
}
