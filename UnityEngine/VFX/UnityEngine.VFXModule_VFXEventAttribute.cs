using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.VFX;

[StructLayout(LayoutKind.Sequential)]
[RequiredByNativeCode]
[NativeType(Header = "Modules/VFX/Public/VFXEventAttribute.h")]
public sealed class VFXEventAttribute : IDisposable
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(VFXEventAttribute eventAttibute)
		{
			return eventAttibute.m_Ptr;
		}

		public static VFXEventAttribute ConvertToManaged(IntPtr ptr)
		{
			return new VFXEventAttribute(ptr);
		}
	}

	private IntPtr m_Ptr;

	private bool m_Owner;

	private VisualEffectAsset m_VfxAsset;

	internal VisualEffectAsset vfxAsset => m_VfxAsset;

	private VFXEventAttribute(IntPtr ptr, bool owner, VisualEffectAsset vfxAsset)
	{
		m_Ptr = ptr;
		m_Owner = owner;
		m_VfxAsset = vfxAsset;
	}

	private VFXEventAttribute(IntPtr ptr)
	{
		m_Ptr = ptr;
	}

	private VFXEventAttribute()
		: this(IntPtr.Zero, owner: false, null)
	{
	}

	internal static VFXEventAttribute CreateEventAttributeWrapper()
	{
		return new VFXEventAttribute(IntPtr.Zero, owner: false, null);
	}

	internal void SetWrapValue(IntPtr ptrToEventAttribute)
	{
		if (m_Owner)
		{
			throw new Exception("VFXSpawnerState : SetWrapValue is reserved to CreateWrapper object");
		}
		m_Ptr = ptrToEventAttribute;
	}

	public VFXEventAttribute(VFXEventAttribute original)
	{
		if (original == null)
		{
			throw new ArgumentNullException("VFXEventAttribute expect a non null attribute");
		}
		m_Ptr = Internal_Create();
		m_VfxAsset = original.m_VfxAsset;
		Internal_InitFromEventAttribute(original);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern IntPtr Internal_Create();

	internal static VFXEventAttribute Internal_InstanciateVFXEventAttribute(VisualEffectAsset vfxAsset)
	{
		VFXEventAttribute vFXEventAttribute = new VFXEventAttribute(Internal_Create(), owner: true, vfxAsset);
		vFXEventAttribute.Internal_InitFromAsset(vfxAsset);
		return vFXEventAttribute;
	}

	internal void Internal_InitFromAsset(VisualEffectAsset vfxAsset)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Internal_InitFromAsset_Injected(intPtr, Object.MarshalledUnityObject.Marshal(vfxAsset));
	}

	internal void Internal_InitFromEventAttribute(VFXEventAttribute vfxEventAttribute)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Internal_InitFromEventAttribute_Injected(intPtr, (vfxEventAttribute == null) ? ((IntPtr)0) : BindingsMarshaller.ConvertToNative(vfxEventAttribute));
	}

	private void Release()
	{
		if (m_Owner && m_Ptr != IntPtr.Zero)
		{
			Internal_Destroy(m_Ptr);
		}
		m_Ptr = IntPtr.Zero;
		m_VfxAsset = null;
	}

	~VFXEventAttribute()
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
	internal static extern void Internal_Destroy(IntPtr ptr);

	[NativeName("HasValueFromScript<bool>")]
	public bool HasBool(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasBool_Injected(intPtr, nameID);
	}

	[NativeName("HasValueFromScript<int>")]
	public bool HasInt(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasInt_Injected(intPtr, nameID);
	}

	[NativeName("HasValueFromScript<UInt32>")]
	public bool HasUint(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasUint_Injected(intPtr, nameID);
	}

	[NativeName("HasValueFromScript<float>")]
	public bool HasFloat(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasFloat_Injected(intPtr, nameID);
	}

	[NativeName("HasValueFromScript<Vector2f>")]
	public bool HasVector2(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasVector2_Injected(intPtr, nameID);
	}

	[NativeName("HasValueFromScript<Vector3f>")]
	public bool HasVector3(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasVector3_Injected(intPtr, nameID);
	}

	[NativeName("HasValueFromScript<Vector4f>")]
	public bool HasVector4(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasVector4_Injected(intPtr, nameID);
	}

	[NativeName("HasValueFromScript<Matrix4x4f>")]
	public bool HasMatrix4x4(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasMatrix4x4_Injected(intPtr, nameID);
	}

	[NativeName("SetValueFromScript<bool>")]
	public void SetBool(int nameID, bool b)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetBool_Injected(intPtr, nameID, b);
	}

	[NativeName("SetValueFromScript<int>")]
	public void SetInt(int nameID, int i)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetInt_Injected(intPtr, nameID, i);
	}

	[NativeName("SetValueFromScript<UInt32>")]
	public void SetUint(int nameID, uint i)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetUint_Injected(intPtr, nameID, i);
	}

	[NativeName("SetValueFromScript<float>")]
	public void SetFloat(int nameID, float f)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetFloat_Injected(intPtr, nameID, f);
	}

	[NativeName("SetValueFromScript<Vector2f>")]
	public void SetVector2(int nameID, Vector2 v)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetVector2_Injected(intPtr, nameID, ref v);
	}

	[NativeName("SetValueFromScript<Vector3f>")]
	public void SetVector3(int nameID, Vector3 v)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetVector3_Injected(intPtr, nameID, ref v);
	}

	[NativeName("SetValueFromScript<Vector4f>")]
	public void SetVector4(int nameID, Vector4 v)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetVector4_Injected(intPtr, nameID, ref v);
	}

	[NativeName("SetValueFromScript<Matrix4x4f>")]
	public void SetMatrix4x4(int nameID, Matrix4x4 v)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetMatrix4x4_Injected(intPtr, nameID, ref v);
	}

	[NativeName("GetValueFromScript<bool>")]
	public bool GetBool(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetBool_Injected(intPtr, nameID);
	}

	[NativeName("GetValueFromScript<int>")]
	public int GetInt(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetInt_Injected(intPtr, nameID);
	}

	[NativeName("GetValueFromScript<UInt32>")]
	public uint GetUint(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetUint_Injected(intPtr, nameID);
	}

	[NativeName("GetValueFromScript<float>")]
	public float GetFloat(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetFloat_Injected(intPtr, nameID);
	}

	[NativeName("GetValueFromScript<Vector2f>")]
	public Vector2 GetVector2(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetVector2_Injected(intPtr, nameID, out var ret);
		return ret;
	}

	[NativeName("GetValueFromScript<Vector3f>")]
	public Vector3 GetVector3(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetVector3_Injected(intPtr, nameID, out var ret);
		return ret;
	}

	[NativeName("GetValueFromScript<Vector4f>")]
	public Vector4 GetVector4(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetVector4_Injected(intPtr, nameID, out var ret);
		return ret;
	}

	[NativeName("GetValueFromScript<Matrix4x4f>")]
	public Matrix4x4 GetMatrix4x4(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetMatrix4x4_Injected(intPtr, nameID, out var ret);
		return ret;
	}

	public bool HasBool(string name)
	{
		return HasBool(Shader.PropertyToID(name));
	}

	public bool HasInt(string name)
	{
		return HasInt(Shader.PropertyToID(name));
	}

	public bool HasUint(string name)
	{
		return HasUint(Shader.PropertyToID(name));
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

	public void SetBool(string name, bool b)
	{
		SetBool(Shader.PropertyToID(name), b);
	}

	public void SetInt(string name, int i)
	{
		SetInt(Shader.PropertyToID(name), i);
	}

	public void SetUint(string name, uint i)
	{
		SetUint(Shader.PropertyToID(name), i);
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

	public bool GetBool(string name)
	{
		return GetBool(Shader.PropertyToID(name));
	}

	public int GetInt(string name)
	{
		return GetInt(Shader.PropertyToID(name));
	}

	public uint GetUint(string name)
	{
		return GetUint(Shader.PropertyToID(name));
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

	public void CopyValuesFrom([NotNull] VFXEventAttribute eventAttibute)
	{
		if (eventAttibute == null)
		{
			ThrowHelper.ThrowArgumentNullException(eventAttibute, "eventAttibute");
		}
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		IntPtr intPtr2 = BindingsMarshaller.ConvertToNative(eventAttibute);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(eventAttibute, "eventAttibute");
		}
		CopyValuesFrom_Injected(intPtr, intPtr2);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_InitFromAsset_Injected(IntPtr _unity_self, IntPtr vfxAsset);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_InitFromEventAttribute_Injected(IntPtr _unity_self, IntPtr vfxEventAttribute);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasBool_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasInt_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasUint_Injected(IntPtr _unity_self, int nameID);

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
	private static extern void SetBool_Injected(IntPtr _unity_self, int nameID, bool b);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetInt_Injected(IntPtr _unity_self, int nameID, int i);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetUint_Injected(IntPtr _unity_self, int nameID, uint i);

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
	private static extern bool GetBool_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetInt_Injected(IntPtr _unity_self, int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern uint GetUint_Injected(IntPtr _unity_self, int nameID);

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
	private static extern void CopyValuesFrom_Injected(IntPtr _unity_self, IntPtr eventAttibute);
}
