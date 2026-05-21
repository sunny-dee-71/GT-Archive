using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Video;

[RequiredByNativeCode]
[NativeHeader("Modules/Video/Public/VideoPlayer.h")]
[RequireComponent(typeof(Transform))]
public sealed class VideoPlayer : Behaviour
{
	public delegate void EventHandler(VideoPlayer source);

	public delegate void ErrorEventHandler(VideoPlayer source, string message);

	public delegate void FrameReadyEventHandler(VideoPlayer source, long frameIdx);

	public delegate void TimeEventHandler(VideoPlayer source, double seconds);

	public VideoSource source
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_source_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_source_Injected(intPtr, value);
		}
	}

	public VideoTimeUpdateMode timeUpdateMode
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_timeUpdateMode_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_timeUpdateMode_Injected(intPtr, value);
		}
	}

	[NativeName("VideoUrl")]
	public unsafe string url
	{
		get
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_url_Injected(intPtr, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}
		set
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
				if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(value);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						set_url_Injected(intPtr, ref managedSpanWrapper);
						return;
					}
				}
				set_url_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}
	}

	[NativeName("VideoClip")]
	public VideoClip clip
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<VideoClip>(get_clip_Injected(intPtr));
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_clip_Injected(intPtr, MarshalledUnityObject.Marshal(value));
		}
	}

	public VideoRenderMode renderMode
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_renderMode_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_renderMode_Injected(intPtr, value);
		}
	}

	public bool canSetTimeUpdateMode
	{
		[NativeName("CanSetTimeUpdateMode")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_canSetTimeUpdateMode_Injected(intPtr);
		}
	}

	[NativeHeader("Runtime/Camera/Camera.h")]
	public Camera targetCamera
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Camera>(get_targetCamera_Injected(intPtr));
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_targetCamera_Injected(intPtr, MarshalledUnityObject.Marshal(value));
		}
	}

	[NativeHeader("Runtime/Graphics/RenderTexture.h")]
	public RenderTexture targetTexture
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<RenderTexture>(get_targetTexture_Injected(intPtr));
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_targetTexture_Injected(intPtr, MarshalledUnityObject.Marshal(value));
		}
	}

	[NativeHeader("Runtime/Graphics/Renderer.h")]
	public Renderer targetMaterialRenderer
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Renderer>(get_targetMaterialRenderer_Injected(intPtr));
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_targetMaterialRenderer_Injected(intPtr, MarshalledUnityObject.Marshal(value));
		}
	}

	public unsafe string targetMaterialProperty
	{
		get
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_targetMaterialProperty_Injected(intPtr, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}
		set
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
				if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(value);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						set_targetMaterialProperty_Injected(intPtr, ref managedSpanWrapper);
						return;
					}
				}
				set_targetMaterialProperty_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}
	}

	public VideoAspectRatio aspectRatio
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_aspectRatio_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_aspectRatio_Injected(intPtr, value);
		}
	}

	public float targetCameraAlpha
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_targetCameraAlpha_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_targetCameraAlpha_Injected(intPtr, value);
		}
	}

	public Video3DLayout targetCamera3DLayout
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_targetCamera3DLayout_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_targetCamera3DLayout_Injected(intPtr, value);
		}
	}

	[NativeHeader("Runtime/Graphics/Texture.h")]
	public Texture texture
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Texture>(get_texture_Injected(intPtr));
		}
	}

	public bool isPrepared
	{
		[NativeName("IsPrepared")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_isPrepared_Injected(intPtr);
		}
	}

	public bool waitForFirstFrame
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_waitForFirstFrame_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_waitForFirstFrame_Injected(intPtr, value);
		}
	}

	public bool playOnAwake
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_playOnAwake_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_playOnAwake_Injected(intPtr, value);
		}
	}

	public bool isPlaying
	{
		[NativeName("IsPlaying")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_isPlaying_Injected(intPtr);
		}
	}

	public bool isPaused
	{
		[NativeName("IsPaused")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_isPaused_Injected(intPtr);
		}
	}

	public bool canSetTime
	{
		[NativeName("CanSetTime")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_canSetTime_Injected(intPtr);
		}
	}

	[NativeName("SecPosition")]
	public double time
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_time_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_time_Injected(intPtr, value);
		}
	}

	[NativeName("FramePosition")]
	public long frame
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_frame_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_frame_Injected(intPtr, value);
		}
	}

	public double clockTime
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_clockTime_Injected(intPtr);
		}
	}

	public bool canStep
	{
		[NativeName("CanStep")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_canStep_Injected(intPtr);
		}
	}

	public bool canSetPlaybackSpeed
	{
		[NativeName("CanSetPlaybackSpeed")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_canSetPlaybackSpeed_Injected(intPtr);
		}
	}

	public float playbackSpeed
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_playbackSpeed_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_playbackSpeed_Injected(intPtr, value);
		}
	}

	[NativeName("Loop")]
	public bool isLooping
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_isLooping_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_isLooping_Injected(intPtr, value);
		}
	}

	[Obsolete("VideoPlayer.canSetTimeSource is deprecated. Use canSetTimeUpdateMode instead. (UnityUpgradable) -> canSetTimeUpdateMode")]
	public bool canSetTimeSource
	{
		[NativeName("CanSetTimeSource")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_canSetTimeSource_Injected(intPtr);
		}
	}

	[Obsolete("VideoPlayer.timeSource is deprecated. Use timeUpdateMode instead. (UnityUpgradable) -> timeUpdateMode")]
	public VideoTimeSource timeSource
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_timeSource_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_timeSource_Injected(intPtr, value);
		}
	}

	public VideoTimeReference timeReference
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_timeReference_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_timeReference_Injected(intPtr, value);
		}
	}

	public double externalReferenceTime
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_externalReferenceTime_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_externalReferenceTime_Injected(intPtr, value);
		}
	}

	public bool canSetSkipOnDrop
	{
		[NativeName("CanSetSkipOnDrop")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_canSetSkipOnDrop_Injected(intPtr);
		}
	}

	public bool skipOnDrop
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_skipOnDrop_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_skipOnDrop_Injected(intPtr, value);
		}
	}

	public ulong frameCount
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_frameCount_Injected(intPtr);
		}
	}

	public float frameRate
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_frameRate_Injected(intPtr);
		}
	}

	[NativeName("Duration")]
	public double length
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_length_Injected(intPtr);
		}
	}

	public uint width
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_width_Injected(intPtr);
		}
	}

	public uint height
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_height_Injected(intPtr);
		}
	}

	public uint pixelAspectRatioNumerator
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_pixelAspectRatioNumerator_Injected(intPtr);
		}
	}

	public uint pixelAspectRatioDenominator
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_pixelAspectRatioDenominator_Injected(intPtr);
		}
	}

	public ushort audioTrackCount
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_audioTrackCount_Injected(intPtr);
		}
	}

	public static extern ushort controlledAudioTrackMaxCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
	}

	public ushort controlledAudioTrackCount
	{
		get
		{
			return GetControlledAudioTrackCount();
		}
		set
		{
			int num = controlledAudioTrackMaxCount;
			if (value > num)
			{
				throw new ArgumentException($"Cannot control more than {num} tracks.", "value");
			}
			SetControlledAudioTrackCount(value);
		}
	}

	public VideoAudioOutputMode audioOutputMode
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_audioOutputMode_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_audioOutputMode_Injected(intPtr, value);
		}
	}

	public bool canSetDirectAudioVolume
	{
		[NativeName("CanSetDirectAudioVolume")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_canSetDirectAudioVolume_Injected(intPtr);
		}
	}

	public bool sendFrameReadyEvents
	{
		[NativeName("AreFrameReadyEventsEnabled")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_sendFrameReadyEvents_Injected(intPtr);
		}
		[NativeName("EnableFrameReadyEvents")]
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_sendFrameReadyEvents_Injected(intPtr, value);
		}
	}

	public event EventHandler prepareCompleted;

	public event EventHandler loopPointReached;

	public event EventHandler started;

	public event EventHandler frameDropped;

	public event ErrorEventHandler errorReceived;

	public event EventHandler seekCompleted;

	public event TimeEventHandler clockResyncOccurred;

	public event FrameReadyEventHandler frameReady;

	public void Prepare()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Prepare_Injected(intPtr);
	}

	public void Play()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Play_Injected(intPtr);
	}

	public void Pause()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Pause_Injected(intPtr);
	}

	public void Stop()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Stop_Injected(intPtr);
	}

	public void StepForward()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		StepForward_Injected(intPtr);
	}

	public string GetAudioLanguageCode(ushort trackIndex)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetAudioLanguageCode_Injected(intPtr, trackIndex, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public ushort GetAudioChannelCount(ushort trackIndex)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetAudioChannelCount_Injected(intPtr, trackIndex);
	}

	public uint GetAudioSampleRate(ushort trackIndex)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetAudioSampleRate_Injected(intPtr, trackIndex);
	}

	private ushort GetControlledAudioTrackCount()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetControlledAudioTrackCount_Injected(intPtr);
	}

	private void SetControlledAudioTrackCount(ushort value)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetControlledAudioTrackCount_Injected(intPtr, value);
	}

	public void EnableAudioTrack(ushort trackIndex, bool enabled)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		EnableAudioTrack_Injected(intPtr, trackIndex, enabled);
	}

	public bool IsAudioTrackEnabled(ushort trackIndex)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return IsAudioTrackEnabled_Injected(intPtr, trackIndex);
	}

	public float GetDirectAudioVolume(ushort trackIndex)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetDirectAudioVolume_Injected(intPtr, trackIndex);
	}

	public void SetDirectAudioVolume(ushort trackIndex, float volume)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetDirectAudioVolume_Injected(intPtr, trackIndex, volume);
	}

	public bool GetDirectAudioMute(ushort trackIndex)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetDirectAudioMute_Injected(intPtr, trackIndex);
	}

	public void SetDirectAudioMute(ushort trackIndex, bool mute)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetDirectAudioMute_Injected(intPtr, trackIndex, mute);
	}

	[NativeHeader("Modules/Audio/Public/AudioSource.h")]
	public AudioSource GetTargetAudioSource(ushort trackIndex)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<AudioSource>(GetTargetAudioSource_Injected(intPtr, trackIndex));
	}

	public void SetTargetAudioSource(ushort trackIndex, AudioSource source)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetTargetAudioSource_Injected(intPtr, trackIndex, MarshalledUnityObject.Marshal(source));
	}

	[RequiredByNativeCode]
	private static void InvokePrepareCompletedCallback_Internal(VideoPlayer source)
	{
		if (source.prepareCompleted != null)
		{
			source.prepareCompleted(source);
		}
	}

	[RequiredByNativeCode]
	private static void InvokeFrameReadyCallback_Internal(VideoPlayer source, long frameIdx)
	{
		if (source.frameReady != null)
		{
			source.frameReady(source, frameIdx);
		}
	}

	[RequiredByNativeCode]
	private static void InvokeLoopPointReachedCallback_Internal(VideoPlayer source)
	{
		if (source.loopPointReached != null)
		{
			source.loopPointReached(source);
		}
	}

	[RequiredByNativeCode]
	private static void InvokeStartedCallback_Internal(VideoPlayer source)
	{
		if (source.started != null)
		{
			source.started(source);
		}
	}

	[RequiredByNativeCode]
	private static void InvokeFrameDroppedCallback_Internal(VideoPlayer source)
	{
		if (source.frameDropped != null)
		{
			source.frameDropped(source);
		}
	}

	[RequiredByNativeCode]
	private static void InvokeErrorReceivedCallback_Internal(VideoPlayer source, string errorStr)
	{
		if (source.errorReceived != null)
		{
			source.errorReceived(source, errorStr);
		}
	}

	[RequiredByNativeCode]
	private static void InvokeSeekCompletedCallback_Internal(VideoPlayer source)
	{
		if (source.seekCompleted != null)
		{
			source.seekCompleted(source);
		}
	}

	[RequiredByNativeCode]
	private static void InvokeClockResyncOccurredCallback_Internal(VideoPlayer source, double seconds)
	{
		if (source.clockResyncOccurred != null)
		{
			source.clockResyncOccurred(source, seconds);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern VideoSource get_source_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_source_Injected(IntPtr _unity_self, VideoSource value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern VideoTimeUpdateMode get_timeUpdateMode_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_timeUpdateMode_Injected(IntPtr _unity_self, VideoTimeUpdateMode value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_url_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_url_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_clip_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_clip_Injected(IntPtr _unity_self, IntPtr value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern VideoRenderMode get_renderMode_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_renderMode_Injected(IntPtr _unity_self, VideoRenderMode value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_canSetTimeUpdateMode_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_targetCamera_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_targetCamera_Injected(IntPtr _unity_self, IntPtr value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_targetTexture_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_targetTexture_Injected(IntPtr _unity_self, IntPtr value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_targetMaterialRenderer_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_targetMaterialRenderer_Injected(IntPtr _unity_self, IntPtr value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_targetMaterialProperty_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_targetMaterialProperty_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern VideoAspectRatio get_aspectRatio_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_aspectRatio_Injected(IntPtr _unity_self, VideoAspectRatio value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_targetCameraAlpha_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_targetCameraAlpha_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Video3DLayout get_targetCamera3DLayout_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_targetCamera3DLayout_Injected(IntPtr _unity_self, Video3DLayout value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_texture_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Prepare_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_isPrepared_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_waitForFirstFrame_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_waitForFirstFrame_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_playOnAwake_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_playOnAwake_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Play_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Pause_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Stop_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_isPlaying_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_isPaused_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_canSetTime_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern double get_time_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_time_Injected(IntPtr _unity_self, double value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern long get_frame_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_frame_Injected(IntPtr _unity_self, long value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern double get_clockTime_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_canStep_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void StepForward_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_canSetPlaybackSpeed_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_playbackSpeed_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_playbackSpeed_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_isLooping_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_isLooping_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_canSetTimeSource_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern VideoTimeSource get_timeSource_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_timeSource_Injected(IntPtr _unity_self, VideoTimeSource value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern VideoTimeReference get_timeReference_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_timeReference_Injected(IntPtr _unity_self, VideoTimeReference value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern double get_externalReferenceTime_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_externalReferenceTime_Injected(IntPtr _unity_self, double value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_canSetSkipOnDrop_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_skipOnDrop_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_skipOnDrop_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern ulong get_frameCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_frameRate_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern double get_length_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern uint get_width_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern uint get_height_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern uint get_pixelAspectRatioNumerator_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern uint get_pixelAspectRatioDenominator_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern ushort get_audioTrackCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetAudioLanguageCode_Injected(IntPtr _unity_self, ushort trackIndex, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern ushort GetAudioChannelCount_Injected(IntPtr _unity_self, ushort trackIndex);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern uint GetAudioSampleRate_Injected(IntPtr _unity_self, ushort trackIndex);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern ushort GetControlledAudioTrackCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetControlledAudioTrackCount_Injected(IntPtr _unity_self, ushort value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EnableAudioTrack_Injected(IntPtr _unity_self, ushort trackIndex, bool enabled);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsAudioTrackEnabled_Injected(IntPtr _unity_self, ushort trackIndex);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern VideoAudioOutputMode get_audioOutputMode_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_audioOutputMode_Injected(IntPtr _unity_self, VideoAudioOutputMode value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_canSetDirectAudioVolume_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetDirectAudioVolume_Injected(IntPtr _unity_self, ushort trackIndex);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetDirectAudioVolume_Injected(IntPtr _unity_self, ushort trackIndex, float volume);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetDirectAudioMute_Injected(IntPtr _unity_self, ushort trackIndex);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetDirectAudioMute_Injected(IntPtr _unity_self, ushort trackIndex, bool mute);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetTargetAudioSource_Injected(IntPtr _unity_self, ushort trackIndex);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetTargetAudioSource_Injected(IntPtr _unity_self, ushort trackIndex, IntPtr source);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_sendFrameReadyEvents_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_sendFrameReadyEvents_Injected(IntPtr _unity_self, bool value);
}
