using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Playables;

[NativeHeader("Modules/Director/PlayableDirector.h")]
[NativeHeader("Runtime/Mono/MonoBehaviour.h")]
[RequiredByNativeCode]
[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector.html")]
public class PlayableDirector : Behaviour, IExposedPropertyTable
{
	public PlayState state => GetPlayState();

	public DirectorWrapMode extrapolationMode
	{
		get
		{
			return GetWrapMode();
		}
		set
		{
			SetWrapMode(value);
		}
	}

	public PlayableAsset playableAsset
	{
		get
		{
			return Internal_GetPlayableAsset() as PlayableAsset;
		}
		set
		{
			SetPlayableAsset(value);
		}
	}

	public PlayableGraph playableGraph => GetGraphHandle();

	public bool playOnAwake
	{
		get
		{
			return GetPlayOnAwake();
		}
		set
		{
			SetPlayOnAwake(value);
		}
	}

	public DirectorUpdateMode timeUpdateMode
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

	public double initialTime
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_initialTime_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_initialTime_Injected(intPtr, value);
		}
	}

	public double duration
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_duration_Injected(intPtr);
		}
	}

	public event Action<PlayableDirector> played;

	public event Action<PlayableDirector> paused;

	public event Action<PlayableDirector> stopped;

	public void DeferredEvaluate()
	{
		EvaluateNextFrame();
	}

	internal void Play(FrameRate frameRate)
	{
		PlayOnFrame(frameRate);
	}

	public void Play(PlayableAsset asset)
	{
		if (asset == null)
		{
			throw new ArgumentNullException("asset");
		}
		Play(asset, extrapolationMode);
	}

	public void Play(PlayableAsset asset, DirectorWrapMode mode)
	{
		if (asset == null)
		{
			throw new ArgumentNullException("asset");
		}
		playableAsset = asset;
		extrapolationMode = mode;
		Play();
	}

	public void SetGenericBinding(Object key, Object value)
	{
		Internal_SetGenericBinding(key, value);
	}

	[NativeThrows]
	public void Evaluate()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Evaluate_Injected(intPtr);
	}

	[NativeThrows]
	private void PlayOnFrame(FrameRate frameRate)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		PlayOnFrame_Injected(intPtr, ref frameRate);
	}

	[NativeThrows]
	public void Play()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Play_Injected(intPtr);
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

	public void Pause()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Pause_Injected(intPtr);
	}

	public void Resume()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Resume_Injected(intPtr);
	}

	[NativeThrows]
	public void RebuildGraph()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		RebuildGraph_Injected(intPtr);
	}

	public void ClearReferenceValue(PropertyName id)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ClearReferenceValue_Injected(intPtr, ref id);
	}

	public void SetReferenceValue(PropertyName id, Object value)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetReferenceValue_Injected(intPtr, ref id, MarshalledUnityObject.Marshal(value));
	}

	public Object GetReferenceValue(PropertyName id, out bool idValid)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<Object>(GetReferenceValue_Injected(intPtr, ref id, out idValid));
	}

	[NativeMethod("GetBindingFor")]
	public Object GetGenericBinding(Object key)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<Object>(GetGenericBinding_Injected(intPtr, MarshalledUnityObject.Marshal(key)));
	}

	[NativeMethod("ClearBindingFor")]
	public void ClearGenericBinding(Object key)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ClearGenericBinding_Injected(intPtr, MarshalledUnityObject.Marshal(key));
	}

	[NativeThrows]
	public void RebindPlayableGraphOutputs()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		RebindPlayableGraphOutputs_Injected(intPtr);
	}

	internal void ProcessPendingGraphChanges()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ProcessPendingGraphChanges_Injected(intPtr);
	}

	[NativeMethod("HasBinding")]
	internal bool HasGenericBinding(Object key)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasGenericBinding_Injected(intPtr, MarshalledUnityObject.Marshal(key));
	}

	private PlayState GetPlayState()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetPlayState_Injected(intPtr);
	}

	private void SetWrapMode(DirectorWrapMode mode)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetWrapMode_Injected(intPtr, mode);
	}

	private DirectorWrapMode GetWrapMode()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetWrapMode_Injected(intPtr);
	}

	[NativeThrows]
	private void EvaluateNextFrame()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		EvaluateNextFrame_Injected(intPtr);
	}

	private PlayableGraph GetGraphHandle()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetGraphHandle_Injected(intPtr, out var ret);
		return ret;
	}

	private void SetPlayOnAwake(bool on)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetPlayOnAwake_Injected(intPtr, on);
	}

	private bool GetPlayOnAwake()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetPlayOnAwake_Injected(intPtr);
	}

	[NativeThrows]
	private void Internal_SetGenericBinding(Object key, Object value)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Internal_SetGenericBinding_Injected(intPtr, MarshalledUnityObject.Marshal(key), MarshalledUnityObject.Marshal(value));
	}

	private void SetPlayableAsset(ScriptableObject asset)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetPlayableAsset_Injected(intPtr, MarshalledUnityObject.Marshal(asset));
	}

	private ScriptableObject Internal_GetPlayableAsset()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<ScriptableObject>(Internal_GetPlayableAsset_Injected(intPtr));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeHeader("Runtime/Director/Core/DirectorManager.h")]
	[StaticAccessor("GetDirectorManager()", StaticAccessorType.Dot)]
	internal static extern void ResetFrameTiming();

	[RequiredByNativeCode]
	private void SendOnPlayableDirectorPlay()
	{
		if (this.played != null)
		{
			this.played(this);
		}
	}

	[RequiredByNativeCode]
	private void SendOnPlayableDirectorPause()
	{
		if (this.paused != null)
		{
			this.paused(this);
		}
	}

	[RequiredByNativeCode]
	private void SendOnPlayableDirectorStop()
	{
		if (this.stopped != null)
		{
			this.stopped(this);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_timeUpdateMode_Injected(IntPtr _unity_self, DirectorUpdateMode value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern DirectorUpdateMode get_timeUpdateMode_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_time_Injected(IntPtr _unity_self, double value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern double get_time_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_initialTime_Injected(IntPtr _unity_self, double value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern double get_initialTime_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern double get_duration_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Evaluate_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void PlayOnFrame_Injected(IntPtr _unity_self, [In] ref FrameRate frameRate);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Play_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Stop_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Pause_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Resume_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void RebuildGraph_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ClearReferenceValue_Injected(IntPtr _unity_self, [In] ref PropertyName id);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetReferenceValue_Injected(IntPtr _unity_self, [In] ref PropertyName id, IntPtr value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetReferenceValue_Injected(IntPtr _unity_self, [In] ref PropertyName id, out bool idValid);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetGenericBinding_Injected(IntPtr _unity_self, IntPtr key);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ClearGenericBinding_Injected(IntPtr _unity_self, IntPtr key);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void RebindPlayableGraphOutputs_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ProcessPendingGraphChanges_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasGenericBinding_Injected(IntPtr _unity_self, IntPtr key);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern PlayState GetPlayState_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetWrapMode_Injected(IntPtr _unity_self, DirectorWrapMode mode);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern DirectorWrapMode GetWrapMode_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EvaluateNextFrame_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetGraphHandle_Injected(IntPtr _unity_self, out PlayableGraph ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetPlayOnAwake_Injected(IntPtr _unity_self, bool on);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetPlayOnAwake_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_SetGenericBinding_Injected(IntPtr _unity_self, IntPtr key, IntPtr value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetPlayableAsset_Injected(IntPtr _unity_self, IntPtr asset);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Internal_GetPlayableAsset_Injected(IntPtr _unity_self);
}
