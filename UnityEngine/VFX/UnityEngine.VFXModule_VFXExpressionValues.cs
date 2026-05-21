using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.VFX;

[StructLayout(LayoutKind.Sequential)]
[RequiredByNativeCode]
[NativeType(Header = "Modules/VFX/Public/VFXExpressionValues.h")]
public class VFXExpressionValues
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(VFXExpressionValues vFXExpressionValues)
		{
			return vFXExpressionValues.m_Ptr;
		}
	}

	internal IntPtr m_Ptr;

	private VFXExpressionValues()
	{
	}

	[RequiredByNativeCode]
	internal static VFXExpressionValues CreateExpressionValuesWrapper(IntPtr ptr)
	{
		VFXExpressionValues vFXExpressionValues = new VFXExpressionValues();
		vFXExpressionValues.m_Ptr = ptr;
		return vFXExpressionValues;
	}

	[NativeName("GetValueFromScript<bool>")]
	[NativeThrows]
	public bool GetBool(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetBool_Injected(intPtr, nameID);
	}

	[NativeThrows]
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

	[NativeThrows]
	[NativeName("GetValueFromScript<UInt32>")]
	public uint GetUInt(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetUInt_Injected(intPtr, nameID);
	}

	[NativeThrows]
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

	[NativeThrows]
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
	[NativeThrows]
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

	[NativeThrows]
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

	[NativeThrows]
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

	[NativeName("GetValueFromScript<Texture*>")]
	[NativeThrows]
	public Texture GetTexture(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<Texture>(GetTexture_Injected(intPtr, nameID));
	}

	[NativeName("GetValueFromScript<Mesh*>")]
	[NativeThrows]
	public Mesh GetMesh(int nameID)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<Mesh>(GetMesh_Injected(intPtr, nameID));
	}

	public AnimationCurve GetAnimationCurve(int nameID)
	{
		AnimationCurve animationCurve = new AnimationCurve();
		Internal_GetAnimationCurveFromScript(nameID, animationCurve);
		return animationCurve;
	}

	[NativeThrows]
	internal void Internal_GetAnimationCurveFromScript(int nameID, AnimationCurve curve)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Internal_GetAnimationCurveFromScript_Injected(intPtr, nameID, (curve == null) ? ((IntPtr)0) : AnimationCurve.BindingsMarshaller.ConvertToNative(curve));
	}

	public Gradient GetGradient(int nameID)
	{
		Gradient gradient = new Gradient();
		Internal_GetGradientFromScript(nameID, gradient);
		return gradient;
	}

	[NativeThrows]
	internal void Internal_GetGradientFromScript(int nameID, Gradient gradient)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Internal_GetGradientFromScript_Injected(intPtr, nameID, (gradient == null) ? ((IntPtr)0) : Gradient.BindingsMarshaller.ConvertToNative(gradient));
	}

	public bool GetBool(string name)
	{
		return GetBool(Shader.PropertyToID(name));
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

	public AnimationCurve GetAnimationCurve(string name)
	{
		return GetAnimationCurve(Shader.PropertyToID(name));
	}

	public Gradient GetGradient(string name)
	{
		return GetGradient(Shader.PropertyToID(name));
	}

	public Mesh GetMesh(string name)
	{
		return GetMesh(Shader.PropertyToID(name));
	}

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
	private static extern void Internal_GetAnimationCurveFromScript_Injected(IntPtr _unity_self, int nameID, IntPtr curve);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_GetGradientFromScript_Injected(IntPtr _unity_self, int nameID, IntPtr gradient);
}
