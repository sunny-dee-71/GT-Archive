using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Playables;

[NativeHeader("Runtime/Export/Director/PlayableHandle.bindings.h")]
[NativeHeader("Runtime/Director/Core/HPlayable.h")]
[NativeHeader("Runtime/Director/Core/HPlayableGraph.h")]
[UsedByNativeCode]
public struct PlayableHandle : IEquatable<PlayableHandle>
{
	internal IntPtr m_Handle;

	internal uint m_Version;

	private static readonly PlayableHandle m_Null = default(PlayableHandle);

	public static PlayableHandle Null => m_Null;

	internal T GetObject<T>() where T : class, IPlayableBehaviour
	{
		if (!IsValid())
		{
			return null;
		}
		object scriptInstance = GetScriptInstance();
		if (scriptInstance == null)
		{
			return null;
		}
		return (T)scriptInstance;
	}

	[VisibleToOtherModules(new string[] { "UnityEngine.DirectorModule" })]
	internal T GetPayload<T>() where T : struct
	{
		if (!IsValid())
		{
			return default(T);
		}
		object scriptInstance = GetScriptInstance();
		if (scriptInstance == null)
		{
			return default(T);
		}
		return (T)scriptInstance;
	}

	[VisibleToOtherModules(new string[] { "UnityEngine.DirectorModule" })]
	internal void SetPayload<T>(T payload) where T : struct
	{
		if (IsValid())
		{
			SetScriptInstance(payload);
		}
	}

	[VisibleToOtherModules]
	internal bool IsPlayableOfType<T>()
	{
		return GetPlayableType() == typeof(T);
	}

	internal Playable GetInput(int inputPort)
	{
		return new Playable(GetInputHandle(inputPort));
	}

	internal Playable GetOutput(int outputPort)
	{
		return new Playable(GetOutputHandle(outputPort));
	}

	internal int GetOutputPortFromInputConnection(int inputPort)
	{
		return GetOutputPortFromInputIndex(inputPort);
	}

	internal int GetInputPortFromOutputConnection(int inputPort)
	{
		return GetInputPortFromOutputIndex(inputPort);
	}

	internal bool SetInputWeight(int inputIndex, float weight)
	{
		if (CheckInputBounds(inputIndex))
		{
			SetInputWeightFromIndex(inputIndex, weight);
			return true;
		}
		return false;
	}

	internal float GetInputWeight(int inputIndex)
	{
		if (CheckInputBounds(inputIndex))
		{
			return GetInputWeightFromIndex(inputIndex);
		}
		return 0f;
	}

	internal void Destroy()
	{
		GetGraph().DestroyPlayable(new Playable(this));
	}

	public static bool operator ==(PlayableHandle x, PlayableHandle y)
	{
		return CompareVersion(x, y);
	}

	public static bool operator !=(PlayableHandle x, PlayableHandle y)
	{
		return !CompareVersion(x, y);
	}

	public override bool Equals(object p)
	{
		return p is PlayableHandle && Equals((PlayableHandle)p);
	}

	public bool Equals(PlayableHandle other)
	{
		return CompareVersion(this, other);
	}

	public override int GetHashCode()
	{
		return m_Handle.GetHashCode() ^ m_Version.GetHashCode();
	}

	internal static bool CompareVersion(PlayableHandle lhs, PlayableHandle rhs)
	{
		return lhs.m_Handle == rhs.m_Handle && lhs.m_Version == rhs.m_Version;
	}

	internal bool CheckInputBounds(int inputIndex)
	{
		return CheckInputBounds(inputIndex, acceptAny: false);
	}

	internal bool CheckInputBounds(int inputIndex, bool acceptAny)
	{
		if (inputIndex == -1 && acceptAny)
		{
			return true;
		}
		if (inputIndex < 0)
		{
			throw new IndexOutOfRangeException("Index must be greater than 0");
		}
		if (GetInputCount() <= inputIndex)
		{
			throw new IndexOutOfRangeException("inputIndex " + inputIndex + " is greater than the number of available inputs (" + GetInputCount() + ").");
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	internal extern bool IsNull();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	internal extern bool IsValid();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::GetPlayableType", HasExplicitThis = true, ThrowsException = true)]
	[VisibleToOtherModules]
	internal extern Type GetPlayableType();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::GetJobType", HasExplicitThis = true, ThrowsException = true)]
	internal extern Type GetJobType();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::SetScriptInstance", HasExplicitThis = true, ThrowsException = true)]
	[VisibleToOtherModules]
	internal extern void SetScriptInstance(object scriptInstance);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::CanChangeInputs", HasExplicitThis = true, ThrowsException = true)]
	internal extern bool CanChangeInputs();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::CanSetWeights", HasExplicitThis = true, ThrowsException = true)]
	[VisibleToOtherModules]
	internal extern bool CanSetWeights();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::CanDestroy", HasExplicitThis = true, ThrowsException = true)]
	[VisibleToOtherModules]
	internal extern bool CanDestroy();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::GetPlayState", HasExplicitThis = true, ThrowsException = true)]
	[VisibleToOtherModules]
	internal extern PlayState GetPlayState();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::Play", HasExplicitThis = true, ThrowsException = true)]
	[VisibleToOtherModules]
	internal extern void Play();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::Pause", HasExplicitThis = true, ThrowsException = true)]
	internal extern void Pause();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::GetSpeed", HasExplicitThis = true, ThrowsException = true)]
	internal extern double GetSpeed();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::SetSpeed", HasExplicitThis = true, ThrowsException = true)]
	internal extern void SetSpeed(double value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::GetTime", HasExplicitThis = true, ThrowsException = true)]
	[VisibleToOtherModules]
	internal extern double GetTime();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::SetTime", HasExplicitThis = true, ThrowsException = true)]
	internal extern void SetTime(double value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::IsDone", HasExplicitThis = true, ThrowsException = true)]
	internal extern bool IsDone();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::SetDone", HasExplicitThis = true, ThrowsException = true)]
	internal extern void SetDone(bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::GetDuration", HasExplicitThis = true, ThrowsException = true)]
	internal extern double GetDuration();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::SetDuration", HasExplicitThis = true, ThrowsException = true)]
	internal extern void SetDuration(double value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::GetPropagateSetTime", HasExplicitThis = true, ThrowsException = true)]
	[VisibleToOtherModules]
	internal extern bool GetPropagateSetTime();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::SetPropagateSetTime", HasExplicitThis = true, ThrowsException = true)]
	[VisibleToOtherModules]
	internal extern void SetPropagateSetTime(bool value);

	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::GetGraph", HasExplicitThis = true, ThrowsException = true)]
	internal PlayableGraph GetGraph()
	{
		GetGraph_Injected(ref this, out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::GetInputCount", HasExplicitThis = true, ThrowsException = true)]
	internal extern int GetInputCount();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::GetOutputPortFromInputIndex", HasExplicitThis = true, ThrowsException = true)]
	internal extern int GetOutputPortFromInputIndex(int index);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::GetInputPortFromOutputIndex", HasExplicitThis = true, ThrowsException = true)]
	[VisibleToOtherModules]
	internal extern int GetInputPortFromOutputIndex(int index);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::SetInputCount", HasExplicitThis = true, ThrowsException = true)]
	[VisibleToOtherModules]
	internal extern void SetInputCount(int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::GetOutputCount", HasExplicitThis = true, ThrowsException = true)]
	[VisibleToOtherModules]
	internal extern int GetOutputCount();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::SetOutputCount", HasExplicitThis = true, ThrowsException = true)]
	[VisibleToOtherModules]
	internal extern void SetOutputCount(int value);

	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::SetInputWeight", HasExplicitThis = true, ThrowsException = true)]
	internal void SetInputWeight(PlayableHandle input, float weight)
	{
		SetInputWeight_Injected(ref this, ref input, weight);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::SetDelay", HasExplicitThis = true, ThrowsException = true)]
	[VisibleToOtherModules]
	internal extern void SetDelay(double delay);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::GetDelay", HasExplicitThis = true, ThrowsException = true)]
	internal extern double GetDelay();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::IsDelayed", HasExplicitThis = true, ThrowsException = true)]
	internal extern bool IsDelayed();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::GetPreviousTime", HasExplicitThis = true, ThrowsException = true)]
	internal extern double GetPreviousTime();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::SetLeadTime", HasExplicitThis = true, ThrowsException = true)]
	internal extern void SetLeadTime(float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::GetLeadTime", HasExplicitThis = true, ThrowsException = true)]
	internal extern float GetLeadTime();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::GetTraversalMode", HasExplicitThis = true, ThrowsException = true)]
	[VisibleToOtherModules]
	internal extern PlayableTraversalMode GetTraversalMode();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::SetTraversalMode", HasExplicitThis = true, ThrowsException = true)]
	[VisibleToOtherModules]
	internal extern void SetTraversalMode(PlayableTraversalMode mode);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::GetJobData", HasExplicitThis = true, ThrowsException = true)]
	[VisibleToOtherModules]
	internal extern IntPtr GetJobData();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::GetTimeWrapMode", HasExplicitThis = true, ThrowsException = true)]
	[VisibleToOtherModules]
	internal extern DirectorWrapMode GetTimeWrapMode();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules]
	[FreeFunction("PlayableHandleBindings::SetTimeWrapMode", HasExplicitThis = true, ThrowsException = true)]
	internal extern void SetTimeWrapMode(DirectorWrapMode mode);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::GetScriptInstance", HasExplicitThis = true, ThrowsException = true)]
	private extern object GetScriptInstance();

	[FreeFunction("PlayableHandleBindings::GetInputHandle", HasExplicitThis = true, ThrowsException = true)]
	private PlayableHandle GetInputHandle(int index)
	{
		GetInputHandle_Injected(ref this, index, out var ret);
		return ret;
	}

	[FreeFunction("PlayableHandleBindings::GetOutputHandle", HasExplicitThis = true, ThrowsException = true)]
	private PlayableHandle GetOutputHandle(int index)
	{
		GetOutputHandle_Injected(ref this, index, out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::SetInputWeightFromIndex", HasExplicitThis = true, ThrowsException = true)]
	private extern void SetInputWeightFromIndex(int index, float weight);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("PlayableHandleBindings::GetInputWeightFromIndex", HasExplicitThis = true, ThrowsException = true)]
	private extern float GetInputWeightFromIndex(int index);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetGraph_Injected(ref PlayableHandle _unity_self, out PlayableGraph ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetInputWeight_Injected(ref PlayableHandle _unity_self, [In] ref PlayableHandle input, float weight);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetInputHandle_Injected(ref PlayableHandle _unity_self, int index, out PlayableHandle ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetOutputHandle_Injected(ref PlayableHandle _unity_self, int index, out PlayableHandle ret);
}
