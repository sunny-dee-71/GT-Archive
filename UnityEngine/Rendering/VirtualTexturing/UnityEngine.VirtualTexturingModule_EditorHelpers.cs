using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.VirtualTexturing;

[StaticAccessor("VirtualTexturing::Editor", StaticAccessorType.DoubleColon)]
[NativeHeader("Modules/VirtualTexturing/ScriptBindings/VirtualTexturing.bindings.h")]
[NativeConditional("UNITY_EDITOR")]
public static class EditorHelpers
{
	[NativeHeader("Runtime/Shaders/SharedMaterialData.h")]
	internal struct StackValidationResult
	{
		public string stackName;

		public string errorMessage;
	}

	[NativeThrows]
	internal static extern int tileSize
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
	}

	[NativeThrows]
	public static bool ValidateTextureStack([Unmarshalled][NotNull] Texture[] textures, out string errorMessage)
	{
		if (textures == null)
		{
			ThrowHelper.ThrowArgumentNullException(textures, "textures");
		}
		ManagedSpanWrapper errorMessage2 = default(ManagedSpanWrapper);
		try
		{
			return ValidateTextureStack_Injected(textures, out errorMessage2);
		}
		finally
		{
			errorMessage = OutStringMarshaller.GetStringAndDispose(errorMessage2);
		}
	}

	[NativeThrows]
	internal static StackValidationResult[] ValidateMaterialTextureStacks([NotNull] Material mat)
	{
		if ((object)mat == null)
		{
			ThrowHelper.ThrowArgumentNullException(mat, "mat");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(mat);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(mat, "mat");
		}
		return ValidateMaterialTextureStacks_Injected(intPtr);
	}

	[NativeConditional("UNITY_EDITOR")]
	[NativeThrows]
	public static GraphicsFormat[] QuerySupportedFormats()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		GraphicsFormat[] result;
		try
		{
			QuerySupportedFormats_Injected(out ret);
		}
		finally
		{
			GraphicsFormat[] array = default(GraphicsFormat[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool ValidateTextureStack_Injected(Texture[] textures, out ManagedSpanWrapper errorMessage);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern StackValidationResult[] ValidateMaterialTextureStacks_Injected(IntPtr mat);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void QuerySupportedFormats_Injected(out BlittableArrayWrapper ret);
}
