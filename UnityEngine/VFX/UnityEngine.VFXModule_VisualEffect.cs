using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

namespace UnityEngine.VFX;

[NativeHeader("Modules/VFX/Public/ScriptBindings/VisualEffectBindings.h")]
[NativeHeader("Modules/VFX/Public/VisualEffect.h")]
[RequireComponent(typeof(Transform))]
public class VisualEffect : Behaviour
{
	internal enum VFXCPUEffectMarkers
	{
		FullUpdate,
		ProcessUpdate,
		EvaluateExpressions
	}

	private VFXEventAttribute m_cachedEventAttribute;

	public Action<VFXOutputEventArgs> outputEventReceived;

	public bool pause
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_pause_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_pause_Injected(intPtr, value);
		}
	}

	public float playRate
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_playRate_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_playRate_Injected(intPtr, value);
		}
	}

	public uint startSeed
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_startSeed_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_startSeed_Injected(intPtr, value);
		}
	}

	public bool resetSeedOnPlay
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_resetSeedOnPlay_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_resetSeedOnPlay_Injected(intPtr, value);
		}
	}

	public int initialEventID
	{
		[FreeFunction(Name = "VisualEffectBindings::GetInitialEventID", HasExplicitThis = true)]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_initialEventID_Injected(intPtr);
		}
		[FreeFunction(Name = "VisualEffectBindings::SetInitialEventID", HasExplicitThis = true)]
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_initialEventID_Injected(intPtr, value);
		}
	}

	public unsafe string initialEventName
	{
		[FreeFunction(Name = "VisualEffectBindings::GetInitialEventName", HasExplicitThis = true)]
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
				get_initialEventName_Injected(intPtr, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}
		[FreeFunction(Name = "VisualEffectBindings::SetInitialEventName", HasExplicitThis = true)]
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
						set_initialEventName_Injected(intPtr, ref managedSpanWrapper);
						return;
					}
				}
				set_initialEventName_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}
	}

	public bool culled
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_culled_Injected(intPtr);
		}
	}

	public VisualEffectAsset visualEffectAsset
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<VisualEffectAsset>(get_visualEffectAsset_Injected(intPtr));
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_visualEffectAsset_Injected(intPtr, MarshalledUnityObject.Marshal(value));
		}
	}

	public int aliveParticleCount
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_aliveParticleCount_Injected(intPtr);
		}
	}

	internal float time
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
	}

	public VFXEventAttribute CreateVFXEventAttribute()
	{
		if (visualEffectAsset == null)
		{
			return null;
		}
		return VFXEventAttribute.Internal_InstanciateVFXEventAttribute(visualEffectAsset);
	}

	private void CheckValidVFXEventAttribute(VFXEventAttribute eventAttribute)
	{
		if (eventAttribute != null && eventAttribute.vfxAsset != visualEffectAsset)
		{
			throw new InvalidOperationException("Invalid VFXEventAttribute provided to VisualEffect. It has been created with another VisualEffectAsset. Use CreateVFXEventAttribute.");
		}
	}

	[FreeFunction(Name = "VisualEffectBindings::SendEventFromScript", HasExplicitThis = true)]
	private void SendEventFromScript(int eventNameID, VFXEventAttribute eventAttribute)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SendEventFromScript_Injected(intPtr, eventNameID, (eventAttribute == null) ? ((IntPtr)0) : VFXEventAttribute.BindingsMarshaller.ConvertToNative(eventAttribute));
	}

	public void SendEvent(int eventNameID, VFXEventAttribute eventAttribute)
	{
		CheckValidVFXEventAttribute(eventAttribute);
		SendEventFromScript(eventNameID, eventAttribute);
	}

	public void SendEvent(string eventName, VFXEventAttribute eventAttribute)
	{
		SendEvent(Shader.PropertyToID(eventName), eventAttribute);
	}

	public void SendEvent(int eventNameID)
	{
		SendEventFromScript(eventNameID, null);
	}

	public void SendEvent(string eventName)
	{
		SendEvent(Shader.PropertyToID(eventName), null);
	}

	public void Play(VFXEventAttribute eventAttribute)
	{
		SendEvent(VisualEffectAsset.PlayEventID, eventAttribute);
	}

	public void Play()
	{
		SendEvent(VisualEffectAsset.PlayEventID);
	}

	public void Stop(VFXEventAttribute eventAttribute)
	{
		SendEvent(VisualEffectAsset.StopEventID, eventAttribute);
	}

	public void Stop()
	{
		SendEvent(VisualEffectAsset.StopEventID);
	}

	public void Reinit()
	{
		Reinit(true);
	}

	internal void Reinit(bool sendInitialEventAndPrewarm = true)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Reinit_Injected(intPtr, sendInitialEventAndPrewarm);
	}

	public void AdvanceOneFrame()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		AdvanceOneFrame_Injected(intPtr);
	}

	internal void RecreateData()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		RecreateData_Injected(intPtr);
	}

	[NativeConditional("ENABLE_PROFILER")]
	[FreeFunction(Name = "VisualEffectBindings::GetGPUTaskMarkerName", HasExplicitThis = true, ThrowsException = true)]
	private string GetGPUTaskMarkerName(int nameID, int taskIndex)
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
			GetGPUTaskMarkerName_Injected(intPtr, nameID, taskIndex, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[NativeConditional("ENABLE_PROFILER")]
	[FreeFunction(Name = "VisualEffectBindings::GetCPUEffectMarkerName", HasExplicitThis = true, ThrowsException = true)]
	internal string GetCPUEffectMarkerName(int markerIndex)
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
			GetCPUEffectMarkerName_Injected(intPtr, markerIndex, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[FreeFunction(Name = "VisualEffectBindings::GetCPUSystemMarkerName", HasExplicitThis = true, ThrowsException = true)]
	[NativeConditional("ENABLE_PROFILER")]
	private string GetCPUSystemMarkerName(int nameID)
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
			GetCPUSystemMarkerName_Injected(intPtr, nameID, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[FreeFunction(Name = "VisualEffectBindings::RegisterForProfiling", HasExplicitThis = true, ThrowsException = false)]
	[NativeConditional("ENABLE_PROFILER")]
	internal void RegisterForProfiling()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		RegisterForProfiling_Injected(intPtr);
	}

	[NativeConditional("ENABLE_PROFILER")]
	[FreeFunction(Name = "VisualEffectBindings::UnregisterForProfiling", HasExplicitThis = true, ThrowsException = false)]
	internal void UnregisterForProfiling()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		UnregisterForProfiling_Injected(intPtr);
	}

	[NativeConditional("ENABLE_PROFILER")]
	[FreeFunction(Name = "VisualEffectBindings::IsRegisteredForProfiling", HasExplicitThis = true, ThrowsException = false)]
	internal bool IsRegisteredForProfiling()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return IsRegisteredForProfiling_Injected(intPtr);
	}

	[FreeFunction(Name = "VisualEffectBindings::ResetOverrideFromScript", HasExplicitThis = true)]
	public void ResetOverride(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ResetOverride_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::GetTextureDimensionFromScript", HasExplicitThis = true)]
	public TextureDimension GetTextureDimension(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetTextureDimension_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<bool>", HasExplicitThis = true)]
	public bool HasBool(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasBool_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<int>", HasExplicitThis = true)]
	public bool HasInt(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasInt_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<UInt32>", HasExplicitThis = true)]
	public bool HasUInt(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasUInt_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<float>", HasExplicitThis = true)]
	public bool HasFloat(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasFloat_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<Vector2f>", HasExplicitThis = true)]
	public bool HasVector2(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasVector2_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<Vector3f>", HasExplicitThis = true)]
	public bool HasVector3(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasVector3_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<Vector4f>", HasExplicitThis = true)]
	public bool HasVector4(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasVector4_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<Matrix4x4f>", HasExplicitThis = true)]
	public bool HasMatrix4x4(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasMatrix4x4_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<Texture*>", HasExplicitThis = true)]
	public bool HasTexture(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasTexture_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<AnimationCurve*>", HasExplicitThis = true)]
	public bool HasAnimationCurve(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasAnimationCurve_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<Gradient*>", HasExplicitThis = true)]
	public bool HasGradient(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasGradient_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<Mesh*>", HasExplicitThis = true)]
	public bool HasMesh(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasMesh_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<SkinnedMeshRenderer*>", HasExplicitThis = true)]
	public bool HasSkinnedMeshRenderer(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasSkinnedMeshRenderer_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<GraphicsBuffer*>", HasExplicitThis = true)]
	public bool HasGraphicsBuffer(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasGraphicsBuffer_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<bool>", HasExplicitThis = true)]
	public void SetBool(int nameID, bool b)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetBool_Injected(intPtr, nameID, b);
	}

	[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<int>", HasExplicitThis = true)]
	public void SetInt(int nameID, int i)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetInt_Injected(intPtr, nameID, i);
	}

	[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<UInt32>", HasExplicitThis = true)]
	public void SetUInt(int nameID, uint i)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetUInt_Injected(intPtr, nameID, i);
	}

	[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<float>", HasExplicitThis = true)]
	public void SetFloat(int nameID, float f)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetFloat_Injected(intPtr, nameID, f);
	}

	[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<Vector2f>", HasExplicitThis = true)]
	public void SetVector2(int nameID, Vector2 v)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetVector2_Injected(intPtr, nameID, ref v);
	}

	[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<Vector3f>", HasExplicitThis = true)]
	public void SetVector3(int nameID, Vector3 v)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetVector3_Injected(intPtr, nameID, ref v);
	}

	[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<Vector4f>", HasExplicitThis = true)]
	public void SetVector4(int nameID, Vector4 v)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetVector4_Injected(intPtr, nameID, ref v);
	}

	[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<Matrix4x4f>", HasExplicitThis = true)]
	public void SetMatrix4x4(int nameID, Matrix4x4 v)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetMatrix4x4_Injected(intPtr, nameID, ref v);
	}

	[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<Texture*>", HasExplicitThis = true)]
	public void SetTexture(int nameID, [NotNull] Texture t)
	{
		if ((object)t == null)
		{
			ThrowHelper.ThrowArgumentNullException(t, "t");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		IntPtr intPtr2 = MarshalledUnityObject.MarshalNotNull(t);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(t, "t");
		}
		SetTexture_Injected(intPtr, nameID, intPtr2);
	}

	[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<AnimationCurve*>", HasExplicitThis = true)]
	public void SetAnimationCurve(int nameID, [NotNull] AnimationCurve c)
	{
		if (c == null)
		{
			ThrowHelper.ThrowArgumentNullException(c, "c");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		IntPtr intPtr2 = AnimationCurve.BindingsMarshaller.ConvertToNative(c);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(c, "c");
		}
		SetAnimationCurve_Injected(intPtr, nameID, intPtr2);
	}

	[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<Gradient*>", HasExplicitThis = true)]
	public void SetGradient(int nameID, [NotNull] Gradient g)
	{
		if (g == null)
		{
			ThrowHelper.ThrowArgumentNullException(g, "g");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		IntPtr intPtr2 = Gradient.BindingsMarshaller.ConvertToNative(g);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(g, "g");
		}
		SetGradient_Injected(intPtr, nameID, intPtr2);
	}

	[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<Mesh*>", HasExplicitThis = true)]
	public void SetMesh(int nameID, [NotNull] Mesh m)
	{
		if ((object)m == null)
		{
			ThrowHelper.ThrowArgumentNullException(m, "m");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		IntPtr intPtr2 = MarshalledUnityObject.MarshalNotNull(m);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(m, "m");
		}
		SetMesh_Injected(intPtr, nameID, intPtr2);
	}

	[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<SkinnedMeshRenderer*>", HasExplicitThis = true)]
	public void SetSkinnedMeshRenderer(int nameID, SkinnedMeshRenderer m)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetSkinnedMeshRenderer_Injected(intPtr, nameID, MarshalledUnityObject.Marshal(m));
	}

	[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<GraphicsBuffer*>", HasExplicitThis = true)]
	public void SetGraphicsBuffer(int nameID, GraphicsBuffer g)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetGraphicsBuffer_Injected(intPtr, nameID, (g == null) ? ((IntPtr)0) : GraphicsBuffer.BindingsMarshaller.ConvertToNative(g));
	}

	[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<bool>", HasExplicitThis = true)]
	public bool GetBool(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetBool_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<int>", HasExplicitThis = true)]
	public int GetInt(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetInt_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<UInt32>", HasExplicitThis = true)]
	public uint GetUInt(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetUInt_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<float>", HasExplicitThis = true)]
	public float GetFloat(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetFloat_Injected(intPtr, nameID);
	}

	[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<Vector2f>", HasExplicitThis = true)]
	public Vector2 GetVector2(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetVector2_Injected(intPtr, nameID, out var ret);
		return ret;
	}

	[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<Vector3f>", HasExplicitThis = true)]
	public Vector3 GetVector3(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetVector3_Injected(intPtr, nameID, out var ret);
		return ret;
	}

	[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<Vector4f>", HasExplicitThis = true)]
	public Vector4 GetVector4(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetVector4_Injected(intPtr, nameID, out var ret);
		return ret;
	}

	[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<Matrix4x4f>", HasExplicitThis = true)]
	public Matrix4x4 GetMatrix4x4(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetMatrix4x4_Injected(intPtr, nameID, out var ret);
		return ret;
	}

	[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<Texture*>", HasExplicitThis = true)]
	public Texture GetTexture(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<Texture>(GetTexture_Injected(intPtr, nameID));
	}

	[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<Mesh*>", HasExplicitThis = true)]
	public Mesh GetMesh(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<Mesh>(GetMesh_Injected(intPtr, nameID));
	}

	[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<SkinnedMeshRenderer*>", HasExplicitThis = true)]
	public SkinnedMeshRenderer GetSkinnedMeshRenderer(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<SkinnedMeshRenderer>(GetSkinnedMeshRenderer_Injected(intPtr, nameID));
	}

	[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<GraphicsBuffer*>", HasExplicitThis = true)]
	internal GraphicsBuffer GetGraphicsBuffer(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		IntPtr graphicsBuffer_Injected = GetGraphicsBuffer_Injected(intPtr, nameID);
		return (graphicsBuffer_Injected == (IntPtr)0) ? null : GraphicsBuffer.BindingsMarshaller.ConvertToManaged(graphicsBuffer_Injected);
	}

	public Gradient GetGradient(int nameID)
	{
		Gradient gradient = new Gradient();
		Internal_GetGradient(nameID, gradient);
		return gradient;
	}

	[FreeFunction(Name = "VisualEffectBindings::Internal_GetGradientFromScript", HasExplicitThis = true)]
	private void Internal_GetGradient(int nameID, Gradient gradient)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Internal_GetGradient_Injected(intPtr, nameID, (gradient == null) ? ((IntPtr)0) : Gradient.BindingsMarshaller.ConvertToNative(gradient));
	}

	public AnimationCurve GetAnimationCurve(int nameID)
	{
		AnimationCurve animationCurve = new AnimationCurve();
		Internal_GetAnimationCurve(nameID, animationCurve);
		return animationCurve;
	}

	[FreeFunction(Name = "VisualEffectBindings::Internal_GetAnimationCurveFromScript", HasExplicitThis = true)]
	private void Internal_GetAnimationCurve(int nameID, AnimationCurve curve)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Internal_GetAnimationCurve_Injected(intPtr, nameID, (curve == null) ? ((IntPtr)0) : AnimationCurve.BindingsMarshaller.ConvertToNative(curve));
	}

	[FreeFunction(Name = "VisualEffectBindings::GetParticleSystemInfo", HasExplicitThis = true, ThrowsException = true)]
	public VFXParticleSystemInfo GetParticleSystemInfo(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetParticleSystemInfo_Injected(intPtr, nameID, out var ret);
		return ret;
	}

	[FreeFunction(Name = "VisualEffectBindings::GetSpawnSystemInfo", HasExplicitThis = true, ThrowsException = true)]
	private void GetSpawnSystemInfo(int nameID, IntPtr spawnerState)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetSpawnSystemInfo_Injected(intPtr, nameID, spawnerState);
	}

	public bool HasAnySystemAwake()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasAnySystemAwake_Injected(intPtr);
	}

	[FreeFunction(Name = "VisualEffectBindings::GetComputedBounds", HasExplicitThis = true)]
	internal Bounds GetComputedBounds(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetComputedBounds_Injected(intPtr, nameID, out var ret);
		return ret;
	}

	[FreeFunction(Name = "VisualEffectBindings::GetCurrentBoundsPadding", HasExplicitThis = true)]
	internal Vector3 GetCurrentBoundsPadding(int nameID)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetCurrentBoundsPadding_Injected(intPtr, nameID, out var ret);
		return ret;
	}

	public void GetSpawnSystemInfo(int nameID, VFXSpawnerState spawnState)
	{
		if (spawnState == null)
		{
			throw new NullReferenceException("GetSpawnSystemInfo expects a non null VFXSpawnerState.");
		}
		IntPtr ptr = spawnState.GetPtr();
		if (ptr == IntPtr.Zero)
		{
			throw new NullReferenceException("GetSpawnSystemInfo use an unexpected not owned VFXSpawnerState.");
		}
		GetSpawnSystemInfo(nameID, ptr);
	}

	public VFXSpawnerState GetSpawnSystemInfo(int nameID)
	{
		VFXSpawnerState vFXSpawnerState = new VFXSpawnerState();
		GetSpawnSystemInfo(nameID, vFXSpawnerState);
		return vFXSpawnerState;
	}

	public bool HasSystem(int nameID)
	{
		VisualEffectAsset visualEffectAsset = this.visualEffectAsset;
		return visualEffectAsset != null && visualEffectAsset.HasSystem(nameID);
	}

	public void GetSystemNames(List<string> names)
	{
		if (names == null)
		{
			throw new ArgumentNullException("names");
		}
		VisualEffectAsset visualEffectAsset = this.visualEffectAsset;
		if ((bool)visualEffectAsset)
		{
			visualEffectAsset.GetSystemNames(names);
		}
		else
		{
			names.Clear();
		}
	}

	public void GetParticleSystemNames(List<string> names)
	{
		if (names == null)
		{
			throw new ArgumentNullException("names");
		}
		VisualEffectAsset visualEffectAsset = this.visualEffectAsset;
		if ((bool)visualEffectAsset)
		{
			visualEffectAsset.GetParticleSystemNames(names);
		}
		else
		{
			names.Clear();
		}
	}

	public void GetOutputEventNames(List<string> names)
	{
		if (names == null)
		{
			throw new ArgumentNullException("names");
		}
		VisualEffectAsset visualEffectAsset = this.visualEffectAsset;
		if ((bool)visualEffectAsset)
		{
			visualEffectAsset.GetOutputEventNames(names);
		}
		else
		{
			names.Clear();
		}
	}

	public void GetSpawnSystemNames(List<string> names)
	{
		if (names == null)
		{
			throw new ArgumentNullException("names");
		}
		VisualEffectAsset visualEffectAsset = this.visualEffectAsset;
		if ((bool)visualEffectAsset)
		{
			visualEffectAsset.GetSpawnSystemNames(names);
		}
		else
		{
			names.Clear();
		}
	}

	public void ResetOverride(string name)
	{
		ResetOverride(Shader.PropertyToID(name));
	}

	public bool HasInt(string name)
	{
		return HasInt(Shader.PropertyToID(name));
	}

	public bool HasUInt(string name)
	{
		return HasUInt(Shader.PropertyToID(name));
	}

	public bool HasFloat(string name)
	{
		return HasFloat(Shader.PropertyToID(name));
	}

	public bool HasVector2(string name)
	{
		return HasVector2(Shader.PropertyToID(name));
	}

	public bool HasVector3(string name)
	{
		return HasVector3(Shader.PropertyToID(name));
	}

	public bool HasVector4(string name)
	{
		return HasVector4(Shader.PropertyToID(name));
	}

	public bool HasMatrix4x4(string name)
	{
		return HasMatrix4x4(Shader.PropertyToID(name));
	}

	public bool HasTexture(string name)
	{
		return HasTexture(Shader.PropertyToID(name));
	}

	public TextureDimension GetTextureDimension(string name)
	{
		return GetTextureDimension(Shader.PropertyToID(name));
	}

	public bool HasAnimationCurve(string name)
	{
		return HasAnimationCurve(Shader.PropertyToID(name));
	}

	public bool HasGradient(string name)
	{
		return HasGradient(Shader.PropertyToID(name));
	}

	public bool HasMesh(string name)
	{
		return HasMesh(Shader.PropertyToID(name));
	}

	public bool HasSkinnedMeshRenderer(string name)
	{
		return HasSkinnedMeshRenderer(Shader.PropertyToID(name));
	}

	public bool HasGraphicsBuffer(string name)
	{
		return HasGraphicsBuffer(Shader.PropertyToID(name));
	}

	public bool HasBool(string name)
	{
		return HasBool(Shader.PropertyToID(name));
	}

	public void SetInt(string name, int i)
	{
		SetInt(Shader.PropertyToID(name), i);
	}

	public void SetUInt(string name, uint i)
	{
		SetUInt(Shader.PropertyToID(name), i);
	}

	public void SetFloat(string name, float f)
	{
		SetFloat(Shader.PropertyToID(name), f);
	}

	public void SetVector2(string name, Vector2 v)
	{
		SetVector2(Shader.PropertyToID(name), v);
	}

	public void SetVector3(string name, Vector3 v)
	{
		SetVector3(Shader.PropertyToID(name), v);
	}

	public void SetVector4(string name, Vector4 v)
	{
		SetVector4(Shader.PropertyToID(name), v);
	}

	public void SetMatrix4x4(string name, Matrix4x4 v)
	{
		SetMatrix4x4(Shader.PropertyToID(name), v);
	}

	public void SetTexture(string name, Texture t)
	{
		SetTexture(Shader.PropertyToID(name), t);
	}

	public void SetAnimationCurve(string name, AnimationCurve c)
	{
		SetAnimationCurve(Shader.PropertyToID(name), c);
	}

	public void SetGradient(string name, Gradient g)
	{
		SetGradient(Shader.PropertyToID(name), g);
	}

	public void SetMesh(string name, Mesh m)
	{
		SetMesh(Shader.PropertyToID(name), m);
	}

	public void SetSkinnedMeshRenderer(string name, SkinnedMeshRenderer m)
	{
		SetSkinnedMeshRenderer(Shader.PropertyToID(name), m);
	}

	public void SetGraphicsBuffer(string name, GraphicsBuffer g)
	{
		SetGraphicsBuffer(Shader.PropertyToID(name), g);
	}

	public void SetBool(string name, bool b)
	{
		SetBool(Shader.PropertyToID(name), b);
	}

	public int GetInt(string name)
	{
		return GetInt(Shader.PropertyToID(name));
	}

	public uint GetUInt(string name)
	{
		return GetUInt(Shader.PropertyToID(name));
	}

	public float GetFloat(string name)
	{
		return GetFloat(Shader.PropertyToID(name));
	}

	public Vector2 GetVector2(string name)
	{
		return GetVector2(Shader.PropertyToID(name));
	}

	public Vector3 GetVector3(string name)
	{
		return GetVector3(Shader.PropertyToID(name));
	}

	public Vector4 GetVector4(string name)
	{
		return GetVector4(Shader.PropertyToID(name));
	}

	public Matrix4x4 GetMatrix4x4(string name)
	{
		return GetMatrix4x4(Shader.PropertyToID(name));
	}

	public Texture GetTexture(string name)
	{
		return GetTexture(Shader.PropertyToID(name));
	}

	public Mesh GetMesh(string name)
	{
		return GetMesh(Shader.PropertyToID(name));
	}

	public SkinnedMeshRenderer GetSkinnedMeshRenderer(string name)
	{
		return GetSkinnedMeshRenderer(Shader.PropertyToID(name));
	}

	internal GraphicsBuffer GetGraphicsBuffer(string name)
	{
		return GetGraphicsBuffer(Shader.PropertyToID(name));
	}

	public bool GetBool(string name)
	{
		return GetBool(Shader.PropertyToID(name));
	}

	public AnimationCurve GetAnimationCurve(string name)
	{
		return GetAnimationCurve(Shader.PropertyToID(name));
	}

	public Gradient GetGradient(string name)
	{
		return GetGradient(Shader.PropertyToID(name));
	}

	public bool HasSystem(string name)
	{
		return HasSystem(Shader.PropertyToID(name));
	}

	public VFXParticleSystemInfo GetParticleSystemInfo(string name)
	{
		return GetParticleSystemInfo(Shader.PropertyToID(name));
	}

	internal string GetGPUTaskMarkerName(string systemName, int taskIndex)
	{
		return GetGPUTaskMarkerName(Shader.PropertyToID(systemName), taskIndex);
	}

	internal string GetCPUSystemMarkerName(string systemName)
	{
		return GetCPUSystemMarkerName(Shader.PropertyToID(systemName));
	}

	internal string GetCPUEffectMarkerName(VFXCPUEffectMarkers markerId)
	{
		return GetCPUEffectMarkerName((int)markerId);
	}

	public VFXSpawnerState GetSpawnSystemInfo(string name)
	{
		return GetSpawnSystemInfo(Shader.PropertyToID(name));
	}

	internal Bounds GetComputedBounds(string name)
	{
		return GetComputedBounds(Shader.PropertyToID(name));
	}

	internal Vector3 GetCurrentBoundsPadding(string name)
	{
		return GetCurrentBoundsPadding(Shader.PropertyToID(name));
	}

	public void Simulate(float stepDeltaTime, uint stepCount = 1u)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Simulate_Injected(intPtr, stepDeltaTime, stepCount);
	}

	[RequiredByNativeCode]
	private static VFXEventAttribute InvokeGetCachedEventAttributeForOutputEvent_Internal(VisualEffect source)
	{
		if (source.outputEventReceived == null)
		{
			return null;
		}
		if (source.m_cachedEventAttribute == null)
		{
			source.m_cachedEventAttribute = source.CreateVFXEventAttribute();
		}
		return source.m_cachedEventAttribute;
	}

	[RequiredByNativeCode]
	private static void InvokeOutputEventReceived_Internal(VisualEffect source, int eventNameId)
	{
		VFXOutputEventArgs obj = new VFXOutputEventArgs(eventNameId, source.m_cachedEventAttribute);
		source.outputEventReceived(obj);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_pause_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_pause_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_playRate_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_playRate_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern uint get_startSeed_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_startSeed_Injected(IntPtr _unity_self, uint value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_resetSeedOnPlay_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_resetSeedOnPlay_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_initialEventID_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_initialEventID_Injected(IntPtr _unity_self, int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_initialEventName_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_initialEventName_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_culled_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_visualEffectAsset_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_visualEffectAsset_Injected(IntPtr _unity_self, IntPtr value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SendEventFromScript_Injected(IntPtr _unity_self, int eventNameID, IntPtr eventAttribute);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Reinit_Injected(IntPtr _unity_self, bool sendInitialEventAndPrewarm);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void AdvanceOneFrame_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void RecreateData_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetGPUTaskMarkerName_Injected(IntPtr _unity_self, int nameID, int taskIndex, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetCPUEffectMarkerName_Injected(IntPtr _unity_self, int markerIndex, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetCPUSystemMarkerName_Injected(IntPtr _unity_self, int nameID, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void RegisterForProfiling_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void UnregisterForProfiling_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsRegisteredForProfiling_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ResetOverride_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern TextureDimension GetTextureDimension_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasBool_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasInt_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasUInt_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasFloat_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasVector2_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasVector3_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasVector4_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasMatrix4x4_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasTexture_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasAnimationCurve_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasGradient_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasMesh_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasSkinnedMeshRenderer_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasGraphicsBuffer_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetBool_Injected(IntPtr _unity_self, int nameID, bool b);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetInt_Injected(IntPtr _unity_self, int nameID, int i);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetUInt_Injected(IntPtr _unity_self, int nameID, uint i);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetFloat_Injected(IntPtr _unity_self, int nameID, float f);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetVector2_Injected(IntPtr _unity_self, int nameID, [In] ref Vector2 v);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetVector3_Injected(IntPtr _unity_self, int nameID, [In] ref Vector3 v);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetVector4_Injected(IntPtr _unity_self, int nameID, [In] ref Vector4 v);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetMatrix4x4_Injected(IntPtr _unity_self, int nameID, [In] ref Matrix4x4 v);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetTexture_Injected(IntPtr _unity_self, int nameID, IntPtr t);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetAnimationCurve_Injected(IntPtr _unity_self, int nameID, IntPtr c);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetGradient_Injected(IntPtr _unity_self, int nameID, IntPtr g);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetMesh_Injected(IntPtr _unity_self, int nameID, IntPtr m);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetSkinnedMeshRenderer_Injected(IntPtr _unity_self, int nameID, IntPtr m);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetGraphicsBuffer_Injected(IntPtr _unity_self, int nameID, IntPtr g);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetBool_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetInt_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern uint GetUInt_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetFloat_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetVector2_Injected(IntPtr _unity_self, int nameID, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetVector3_Injected(IntPtr _unity_self, int nameID, out Vector3 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetVector4_Injected(IntPtr _unity_self, int nameID, out Vector4 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetMatrix4x4_Injected(IntPtr _unity_self, int nameID, out Matrix4x4 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetTexture_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetMesh_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetSkinnedMeshRenderer_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetGraphicsBuffer_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_GetGradient_Injected(IntPtr _unity_self, int nameID, IntPtr gradient);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_GetAnimationCurve_Injected(IntPtr _unity_self, int nameID, IntPtr curve);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetParticleSystemInfo_Injected(IntPtr _unity_self, int nameID, out VFXParticleSystemInfo ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetSpawnSystemInfo_Injected(IntPtr _unity_self, int nameID, IntPtr spawnerState);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasAnySystemAwake_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetComputedBounds_Injected(IntPtr _unity_self, int nameID, out Bounds ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetCurrentBoundsPadding_Injected(IntPtr _unity_self, int nameID, out Vector3 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_aliveParticleCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_time_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Simulate_Injected(IntPtr _unity_self, float stepDeltaTime, uint stepCount);
}
