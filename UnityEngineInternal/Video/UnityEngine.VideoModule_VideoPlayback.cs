using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Experimental.Audio;
using UnityEngine.Scripting;

namespace UnityEngineInternal.Video;

[NativeHeader("Modules/Video/Public/Base/MediaComponent.h")]
[UsedByNativeCode]
internal class VideoPlayback
{
	public delegate void Callback();

	internal static class BindingsMarshaller
	{
		public static VideoPlayback ConvertToManaged(IntPtr ptr)
		{
			return new VideoPlayback(ptr);
		}

		public static IntPtr ConvertToNative(VideoPlayback videoPlayback)
		{
			return videoPlayback.m_Ptr;
		}
	}

	internal IntPtr m_Ptr;

	private VideoPlayback(IntPtr ptr)
	{
		m_Ptr = ptr;
	}

	public void StartPlayback()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		StartPlayback_Injected(intPtr);
	}

	public void PausePlayback()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		PausePlayback_Injected(intPtr);
	}

	public void StopPlayback()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		StopPlayback_Injected(intPtr);
	}

	public VideoError GetStatus()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetStatus_Injected(intPtr);
	}

	public bool IsReady()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return IsReady_Injected(intPtr);
	}

	public bool IsPlaying()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return IsPlaying_Injected(intPtr);
	}

	public void Step()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Step_Injected(intPtr);
	}

	public bool CanStep()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return CanStep_Injected(intPtr);
	}

	public uint GetWidth()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetWidth_Injected(intPtr);
	}

	public uint GetHeight()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetHeight_Injected(intPtr);
	}

	public float GetFrameRate()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetFrameRate_Injected(intPtr);
	}

	public float GetDuration()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetDuration_Injected(intPtr);
	}

	public ulong GetFrameCount()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetFrameCount_Injected(intPtr);
	}

	public uint GetPixelAspectRatioNumerator()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetPixelAspectRatioNumerator_Injected(intPtr);
	}

	public uint GetPixelAspectRatioDenominator()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetPixelAspectRatioDenominator_Injected(intPtr);
	}

	public VideoPixelFormat GetPixelFormat()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetPixelFormat_Injected(intPtr);
	}

	public bool CanNotSkipOnDrop()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return CanNotSkipOnDrop_Injected(intPtr);
	}

	public void SetSkipOnDrop(bool skipOnDrop)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetSkipOnDrop_Injected(intPtr, skipOnDrop);
	}

	public bool GetTexture(Texture texture, out long outputFrameNum)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetTexture_Injected(intPtr, UnityEngine.Object.MarshalledUnityObject.Marshal(texture), out outputFrameNum);
	}

	public void SeekToFrame(long frameIndex, Callback seekCompletedCallback)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SeekToFrame_Injected(intPtr, frameIndex, seekCompletedCallback);
	}

	public void SeekToTime(double secs, Callback seekCompletedCallback)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SeekToTime_Injected(intPtr, secs, seekCompletedCallback);
	}

	public float GetPlaybackSpeed()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetPlaybackSpeed_Injected(intPtr);
	}

	public void SetPlaybackSpeed(float value)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetPlaybackSpeed_Injected(intPtr, value);
	}

	public bool GetLoop()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetLoop_Injected(intPtr);
	}

	public void SetLoop(bool value)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetLoop_Injected(intPtr, value);
	}

	public void SetAdjustToLinearSpace(bool enable)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetAdjustToLinearSpace_Injected(intPtr, enable);
	}

	[NativeHeader("Modules/Audio/Public/AudioSource.h")]
	public ushort GetAudioTrackCount()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetAudioTrackCount_Injected(intPtr);
	}

	public ushort GetAudioChannelCount(ushort trackIdx)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetAudioChannelCount_Injected(intPtr, trackIdx);
	}

	public uint GetAudioSampleRate(ushort trackIdx)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetAudioSampleRate_Injected(intPtr, trackIdx);
	}

	public string GetAudioLanguageCode(ushort trackIdx)
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
			GetAudioLanguageCode_Injected(intPtr, trackIdx, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public void SetAudioTarget(ushort trackIdx, bool enabled, bool softwareOutput, AudioSource audioSource)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetAudioTarget_Injected(intPtr, trackIdx, enabled, softwareOutput, UnityEngine.Object.MarshalledUnityObject.Marshal(audioSource));
	}

	private uint GetAudioSampleProviderId(ushort trackIndex)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetAudioSampleProviderId_Injected(intPtr, trackIndex);
	}

	public AudioSampleProvider GetAudioSampleProvider(ushort trackIndex)
	{
		if (trackIndex >= GetAudioTrackCount())
		{
			throw new ArgumentOutOfRangeException("trackIndex", trackIndex, "VideoPlayback has " + GetAudioTrackCount() + " tracks.");
		}
		AudioSampleProvider audioSampleProvider = AudioSampleProvider.Lookup(GetAudioSampleProviderId(trackIndex), null, trackIndex);
		if (audioSampleProvider == null)
		{
			throw new InvalidOperationException("VideoPlayback.GetAudioSampleProvider got null provider.");
		}
		if (audioSampleProvider.owner != null)
		{
			throw new InvalidOperationException("Internal error: VideoPlayback.GetAudioSampleProvider got unexpected non-null provider owner.");
		}
		if (audioSampleProvider.trackIndex != trackIndex)
		{
			throw new InvalidOperationException("Internal error: VideoPlayback.GetAudioSampleProvider got provider for track " + audioSampleProvider.trackIndex + " instead of " + trackIndex);
		}
		return audioSampleProvider;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool PlatformSupportsH265();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void StartPlayback_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void PausePlayback_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void StopPlayback_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern VideoError GetStatus_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsReady_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsPlaying_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Step_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool CanStep_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern uint GetWidth_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern uint GetHeight_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetFrameRate_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetDuration_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern ulong GetFrameCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern uint GetPixelAspectRatioNumerator_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern uint GetPixelAspectRatioDenominator_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern VideoPixelFormat GetPixelFormat_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool CanNotSkipOnDrop_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetSkipOnDrop_Injected(IntPtr _unity_self, bool skipOnDrop);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetTexture_Injected(IntPtr _unity_self, IntPtr texture, out long outputFrameNum);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SeekToFrame_Injected(IntPtr _unity_self, long frameIndex, Callback seekCompletedCallback);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SeekToTime_Injected(IntPtr _unity_self, double secs, Callback seekCompletedCallback);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetPlaybackSpeed_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetPlaybackSpeed_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetLoop_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetLoop_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetAdjustToLinearSpace_Injected(IntPtr _unity_self, bool enable);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern ushort GetAudioTrackCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern ushort GetAudioChannelCount_Injected(IntPtr _unity_self, ushort trackIdx);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern uint GetAudioSampleRate_Injected(IntPtr _unity_self, ushort trackIdx);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetAudioLanguageCode_Injected(IntPtr _unity_self, ushort trackIdx, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetAudioTarget_Injected(IntPtr _unity_self, ushort trackIdx, bool enabled, bool softwareOutput, IntPtr audioSource);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern uint GetAudioSampleProviderId_Injected(IntPtr _unity_self, ushort trackIndex);
}
