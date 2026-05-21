using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.VFX;

[StructLayout(LayoutKind.Sequential)]
[NativeType(Header = "Modules/VFX/Public/VFXSpawnerState.h")]
[RequiredByNativeCode]
public sealed class VFXSpawnerState : IDisposable
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(VFXSpawnerState vfxSpawnerState)
		{
			return vfxSpawnerState.m_Ptr;
		}
	}

	private IntPtr m_Ptr;

	private bool m_Owner;

	private VFXEventAttribute m_WrapEventAttribute;

	public bool playing
	{
		get
		{
			return loopState == VFXSpawnerLoopState.Looping;
		}
		set
		{
			loopState = (value ? VFXSpawnerLoopState.Looping : VFXSpawnerLoopState.Finished);
		}
	}

	public bool newLoop
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_newLoop_Injected(intPtr);
		}
	}

	public VFXSpawnerLoopState loopState
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_loopState_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_loopState_Injected(intPtr, value);
		}
	}

	public float spawnCount
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_spawnCount_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_spawnCount_Injected(intPtr, value);
		}
	}

	public float deltaTime
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_deltaTime_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_deltaTime_Injected(intPtr, value);
		}
	}

	public float totalTime
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_totalTime_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_totalTime_Injected(intPtr, value);
		}
	}

	public float delayBeforeLoop
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_delayBeforeLoop_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_delayBeforeLoop_Injected(intPtr, value);
		}
	}

	public float loopDuration
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_loopDuration_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_loopDuration_Injected(intPtr, value);
		}
	}

	public float delayAfterLoop
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_delayAfterLoop_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_delayAfterLoop_Injected(intPtr, value);
		}
	}

	public int loopIndex
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_loopIndex_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_loopIndex_Injected(intPtr, value);
		}
	}

	public int loopCount
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_loopCount_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_loopCount_Injected(intPtr, value);
		}
	}

	public VFXEventAttribute vfxEventAttribute
	{
		get
		{
			if (!m_Owner && m_WrapEventAttribute != null)
			{
				return m_WrapEventAttribute;
			}
			return Internal_GetVFXEventAttribute();
		}
	}

	public VFXSpawnerState()
		: this(Internal_Create(), owner: true)
	{
	}

	internal VFXSpawnerState(IntPtr ptr, bool owner)
	{
		m_Ptr = ptr;
		m_Owner = owner;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern IntPtr Internal_Create();

	[RequiredByNativeCode]
	internal static VFXSpawnerState CreateSpawnerStateWrapper()
	{
		VFXSpawnerState vFXSpawnerState = new VFXSpawnerState(IntPtr.Zero, owner: false);
		vFXSpawnerState.PrepareWrapper();
		return vFXSpawnerState;
	}

	private void PrepareWrapper()
	{
		if (m_Owner)
		{
			throw new Exception("VFXSpawnerState : SetWrapValue is reserved to CreateWrapper object");
		}
		if (m_WrapEventAttribute != null)
		{
			throw new Exception("VFXSpawnerState : Unexpected calling twice prepare wrapper");
		}
		m_WrapEventAttribute = VFXEventAttribute.CreateEventAttributeWrapper();
	}

	[RequiredByNativeCode]
	internal void SetWrapValue(IntPtr ptrToSpawnerState, IntPtr ptrToEventAttribute)
	{
		if (m_Owner)
		{
			throw new Exception("VFXSpawnerState : SetWrapValue is reserved to CreateWrapper object");
		}
		if (m_WrapEventAttribute == null)
		{
			throw new Exception("VFXSpawnerState : Missing PrepareWrapper");
		}
		m_Ptr = ptrToSpawnerState;
		m_WrapEventAttribute.SetWrapValue(ptrToEventAttribute);
	}

	internal IntPtr GetPtr()
	{
		return m_Ptr;
	}

	private void Release()
	{
		if (m_Ptr != IntPtr.Zero && m_Owner)
		{
			Internal_Destroy(m_Ptr);
		}
		m_Ptr = IntPtr.Zero;
		m_WrapEventAttribute = null;
	}

	~VFXSpawnerState()
	{
		Release();
	}

	public void Dispose()
	{
		Release();
		GC.SuppressFinalize(this);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(IsThreadSafe = true)]
	private static extern void Internal_Destroy(IntPtr ptr);

	internal VFXEventAttribute Internal_GetVFXEventAttribute()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		IntPtr intPtr2 = Internal_GetVFXEventAttribute_Injected(intPtr);
		return (intPtr2 == (IntPtr)0) ? null : VFXEventAttribute.BindingsMarshaller.ConvertToManaged(intPtr2);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_newLoop_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern VFXSpawnerLoopState get_loopState_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_loopState_Injected(IntPtr _unity_self, VFXSpawnerLoopState value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_spawnCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_spawnCount_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_deltaTime_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_deltaTime_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_totalTime_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_totalTime_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_delayBeforeLoop_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_delayBeforeLoop_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_loopDuration_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_loopDuration_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_delayAfterLoop_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_delayAfterLoop_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_loopIndex_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_loopIndex_Injected(IntPtr _unity_self, int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_loopCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_loopCount_Injected(IntPtr _unity_self, int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Internal_GetVFXEventAttribute_Injected(IntPtr _unity_self);
}
