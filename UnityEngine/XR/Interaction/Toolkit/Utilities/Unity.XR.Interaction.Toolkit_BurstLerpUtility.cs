using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Mathematics;

namespace UnityEngine.XR.Interaction.Toolkit.Utilities;

[BurstCompile]
public static class BurstLerpUtility
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void BezierLerp_00000343$PostfixBurstDelegate(in float3 start, in float3 end, float t, out float3 result, float controlHeightFactor = 0.5f);

	internal static class BezierLerp_00000343$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<BezierLerp_00000343$PostfixBurstDelegate>(BezierLerp).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in float3 start, in float3 end, float t, out float3 result, float controlHeightFactor = 0.5f)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref float3, ref float3, float, ref float3, float, void>)functionPointer)(ref start, ref end, t, ref result, controlHeightFactor);
					return;
				}
			}
			BezierLerp$BurstManaged(in start, in end, t, out result, controlHeightFactor);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate float BezierLerp_00000344$PostfixBurstDelegate(float start, float end, float t, float controlHeightFactor = 0.5f);

	internal static class BezierLerp_00000344$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<BezierLerp_00000344$PostfixBurstDelegate>(BezierLerp).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static float Invoke(float start, float end, float t, float controlHeightFactor = 0.5f)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					return ((delegate* unmanaged[Cdecl]<float, float, float, float, float>)functionPointer)(start, end, t, controlHeightFactor);
				}
			}
			return BezierLerp$BurstManaged(start, end, t, controlHeightFactor);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void BounceOutLerp_00000346$PostfixBurstDelegate(in float3 start, in float3 end, float t, out float3 result, float speed = 1f);

	internal static class BounceOutLerp_00000346$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<BounceOutLerp_00000346$PostfixBurstDelegate>(BounceOutLerp).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in float3 start, in float3 end, float t, out float3 result, float speed = 1f)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref float3, ref float3, float, ref float3, float, void>)functionPointer)(ref start, ref end, t, ref result, speed);
					return;
				}
			}
			BounceOutLerp$BurstManaged(in start, in end, t, out result, speed);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate float BounceOutLerp_00000347$PostfixBurstDelegate(float start, float end, float t, float speed = 1f);

	internal static class BounceOutLerp_00000347$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<BounceOutLerp_00000347$PostfixBurstDelegate>(BounceOutLerp).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static float Invoke(float start, float end, float t, float speed = 1f)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					return ((delegate* unmanaged[Cdecl]<float, float, float, float, float>)functionPointer)(start, end, t, speed);
				}
			}
			return BounceOutLerp$BurstManaged(start, end, t, speed);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void SingleBounceOutLerp_0000034A$PostfixBurstDelegate(in float3 start, in float3 end, float t, out float3 result, float speed = 1f);

	internal static class SingleBounceOutLerp_0000034A$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<SingleBounceOutLerp_0000034A$PostfixBurstDelegate>(SingleBounceOutLerp).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in float3 start, in float3 end, float t, out float3 result, float speed = 1f)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref float3, ref float3, float, ref float3, float, void>)functionPointer)(ref start, ref end, t, ref result, speed);
					return;
				}
			}
			SingleBounceOutLerp$BurstManaged(in start, in end, t, out result, speed);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate float SingleBounceOutLerp_0000034B$PostfixBurstDelegate(float start, float end, float t, float speed = 1f);

	internal static class SingleBounceOutLerp_0000034B$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<SingleBounceOutLerp_0000034B$PostfixBurstDelegate>(SingleBounceOutLerp).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static float Invoke(float start, float end, float t, float speed = 1f)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					return ((delegate* unmanaged[Cdecl]<float, float, float, float, float>)functionPointer)(start, end, t, speed);
				}
			}
			return SingleBounceOutLerp$BurstManaged(start, end, t, speed);
		}
	}

	public static Vector3 BezierLerp(in Vector3 start, in Vector3 end, float t, float controlHeightFactor = 0.5f)
	{
		BezierLerp((float3)start, (float3)end, t, out var result, controlHeightFactor);
		return result;
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(BezierLerp_00000343$PostfixBurstDelegate))]
	public static void BezierLerp(in float3 start, in float3 end, float t, out float3 result, float controlHeightFactor = 0.5f)
	{
		BezierLerp_00000343$BurstDirectCall.Invoke(in start, in end, t, out result, controlHeightFactor);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(BezierLerp_00000344$PostfixBurstDelegate))]
	public static float BezierLerp(float start, float end, float t, float controlHeightFactor = 0.5f)
	{
		return BezierLerp_00000344$BurstDirectCall.Invoke(start, end, t, controlHeightFactor);
	}

	public static Vector3 BounceOutLerp(Vector3 start, Vector3 end, float t, float speed = 1f)
	{
		BounceOutLerp((float3)start, (float3)end, t, out var result, speed);
		return result;
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(BounceOutLerp_00000346$PostfixBurstDelegate))]
	public static void BounceOutLerp(in float3 start, in float3 end, float t, out float3 result, float speed = 1f)
	{
		BounceOutLerp_00000346$BurstDirectCall.Invoke(in start, in end, t, out result, speed);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(BounceOutLerp_00000347$PostfixBurstDelegate))]
	public static float BounceOutLerp(float start, float end, float t, float speed = 1f)
	{
		return BounceOutLerp_00000347$BurstDirectCall.Invoke(start, end, t, speed);
	}

	private static float EaseOutBounce(float t, float speed = 1f)
	{
		t = Mathf.Clamp01(t * speed);
		if (t < 0.36363637f)
		{
			return 7.5625f * t * t;
		}
		if (t < 0.72727275f)
		{
			t -= 0.54545456f;
			return 7.5625f * t * t + 0.75f;
		}
		if ((double)t < 0.9090909090909091)
		{
			t -= 0.8181818f;
			return 7.5625f * t * t + 0.9375f;
		}
		t -= 21f / 22f;
		return 7.5625f * t * t + 63f / 64f;
	}

	public static Vector3 SingleBounceOutLerp(Vector3 start, Vector3 end, float t, float speed = 1f)
	{
		BounceOutLerp((float3)start, (float3)end, t, out var result, speed);
		return result;
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(SingleBounceOutLerp_0000034A$PostfixBurstDelegate))]
	public static void SingleBounceOutLerp(in float3 start, in float3 end, float t, out float3 result, float speed = 1f)
	{
		SingleBounceOutLerp_0000034A$BurstDirectCall.Invoke(in start, in end, t, out result, speed);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(SingleBounceOutLerp_0000034B$PostfixBurstDelegate))]
	public static float SingleBounceOutLerp(float start, float end, float t, float speed = 1f)
	{
		return SingleBounceOutLerp_0000034B$BurstDirectCall.Invoke(start, end, t, speed);
	}

	private static float EaseOutBounceSingle(float t, float speed = 1f)
	{
		t = Mathf.Clamp01(t * speed);
		if (t < 0.36363637f)
		{
			return 7.5625f * t * t;
		}
		if (t < 0.72727275f)
		{
			t -= 0.54545456f;
			return 7.5625f * t * t + 0.75f;
		}
		t -= 0.8181818f;
		return 7.5625f * t * t + 0.9375f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void BezierLerp$BurstManaged(in float3 start, in float3 end, float t, out float3 result, float controlHeightFactor = 0.5f)
	{
		result = math.lerp(start, end, BezierLerp(0f, 1f, t, controlHeightFactor));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static float BezierLerp$BurstManaged(float start, float end, float t, float controlHeightFactor = 0.5f)
	{
		float num = (start + end) / 2f + controlHeightFactor * (end - start);
		float num2 = 1f - t;
		return num2 * (num2 * start + t * num) + t * (num2 * num + t * end);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void BounceOutLerp$BurstManaged(in float3 start, in float3 end, float t, out float3 result, float speed = 1f)
	{
		result = math.lerp(start, end, EaseOutBounce(t, speed));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static float BounceOutLerp$BurstManaged(float start, float end, float t, float speed = 1f)
	{
		return math.lerp(start, end, EaseOutBounce(t, speed));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void SingleBounceOutLerp$BurstManaged(in float3 start, in float3 end, float t, out float3 result, float speed = 1f)
	{
		result = math.lerp(start, end, EaseOutBounceSingle(t, speed));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static float SingleBounceOutLerp$BurstManaged(float start, float end, float t, float speed = 1f)
	{
		return math.lerp(start, end, EaseOutBounceSingle(t, speed));
	}
}
