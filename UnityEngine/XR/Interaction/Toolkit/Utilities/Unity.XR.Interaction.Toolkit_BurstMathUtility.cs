using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Mathematics;

namespace UnityEngine.XR.Interaction.Toolkit.Utilities;

[BurstCompile]
public static class BurstMathUtility
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void OrthogonalUpVector_0000034D$PostfixBurstDelegate(in Vector3 forward, in Vector3 referenceUp, out Vector3 orthogonalUp);

	internal static class OrthogonalUpVector_0000034D$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<OrthogonalUpVector_0000034D$PostfixBurstDelegate>(OrthogonalUpVector).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in Vector3 forward, in Vector3 referenceUp, out Vector3 orthogonalUp)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref Vector3, ref Vector3, ref Vector3, void>)functionPointer)(ref forward, ref referenceUp, ref orthogonalUp);
					return;
				}
			}
			OrthogonalUpVector$BurstManaged(in forward, in referenceUp, out orthogonalUp);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void OrthogonalUpVector_0000034E$PostfixBurstDelegate(in float3 forward, in float3 referenceUp, out float3 orthogonalUp);

	internal static class OrthogonalUpVector_0000034E$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<OrthogonalUpVector_0000034E$PostfixBurstDelegate>(OrthogonalUpVector).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in float3 forward, in float3 referenceUp, out float3 orthogonalUp)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref float3, ref float3, ref float3, void>)functionPointer)(ref forward, ref referenceUp, ref orthogonalUp);
					return;
				}
			}
			OrthogonalUpVector$BurstManaged(in forward, in referenceUp, out orthogonalUp);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void OrthogonalLookRotation_0000034F$PostfixBurstDelegate(in Vector3 forward, in Vector3 referenceUp, out Quaternion lookRotation);

	internal static class OrthogonalLookRotation_0000034F$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<OrthogonalLookRotation_0000034F$PostfixBurstDelegate>(OrthogonalLookRotation).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in Vector3 forward, in Vector3 referenceUp, out Quaternion lookRotation)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref Vector3, ref Vector3, ref Quaternion, void>)functionPointer)(ref forward, ref referenceUp, ref lookRotation);
					return;
				}
			}
			OrthogonalLookRotation$BurstManaged(in forward, in referenceUp, out lookRotation);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void OrthogonalLookRotation_00000350$PostfixBurstDelegate(in float3 forward, in float3 referenceUp, out quaternion lookRotation);

	internal static class OrthogonalLookRotation_00000350$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<OrthogonalLookRotation_00000350$PostfixBurstDelegate>(OrthogonalLookRotation).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in float3 forward, in float3 referenceUp, out quaternion lookRotation)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref float3, ref float3, ref quaternion, void>)functionPointer)(ref forward, ref referenceUp, ref lookRotation);
					return;
				}
			}
			OrthogonalLookRotation$BurstManaged(in forward, in referenceUp, out lookRotation);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void ProjectOnPlane_00000351$PostfixBurstDelegate(in float3 vector, in float3 planeNormal, out float3 projectedVector);

	internal static class ProjectOnPlane_00000351$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<ProjectOnPlane_00000351$PostfixBurstDelegate>(ProjectOnPlane).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in float3 vector, in float3 planeNormal, out float3 projectedVector)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref float3, ref float3, ref float3, void>)functionPointer)(ref vector, ref planeNormal, ref projectedVector);
					return;
				}
			}
			ProjectOnPlane$BurstManaged(in vector, in planeNormal, out projectedVector);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void ProjectOnPlane_00000352$PostfixBurstDelegate(in Vector3 vector, in Vector3 planeNormal, out Vector3 projectedVector);

	internal static class ProjectOnPlane_00000352$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<ProjectOnPlane_00000352$PostfixBurstDelegate>(ProjectOnPlane).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in Vector3 vector, in Vector3 planeNormal, out Vector3 projectedVector)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref Vector3, ref Vector3, ref Vector3, void>)functionPointer)(ref vector, ref planeNormal, ref projectedVector);
					return;
				}
			}
			ProjectOnPlane$BurstManaged(in vector, in planeNormal, out projectedVector);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void LookRotationWithForwardProjectedOnPlane_00000353$PostfixBurstDelegate(in float3 forward, in float3 planeNormal, out quaternion lookRotation);

	internal static class LookRotationWithForwardProjectedOnPlane_00000353$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<LookRotationWithForwardProjectedOnPlane_00000353$PostfixBurstDelegate>(LookRotationWithForwardProjectedOnPlane).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in float3 forward, in float3 planeNormal, out quaternion lookRotation)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref float3, ref float3, ref quaternion, void>)functionPointer)(ref forward, ref planeNormal, ref lookRotation);
					return;
				}
			}
			LookRotationWithForwardProjectedOnPlane$BurstManaged(in forward, in planeNormal, out lookRotation);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void LookRotationWithForwardProjectedOnPlane_00000354$PostfixBurstDelegate(in Vector3 forward, in Vector3 planeNormal, out Quaternion lookRotation);

	internal static class LookRotationWithForwardProjectedOnPlane_00000354$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<LookRotationWithForwardProjectedOnPlane_00000354$PostfixBurstDelegate>(LookRotationWithForwardProjectedOnPlane).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in Vector3 forward, in Vector3 planeNormal, out Quaternion lookRotation)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref Vector3, ref Vector3, ref Quaternion, void>)functionPointer)(ref forward, ref planeNormal, ref lookRotation);
					return;
				}
			}
			LookRotationWithForwardProjectedOnPlane$BurstManaged(in forward, in planeNormal, out lookRotation);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void Angle_00000355$PostfixBurstDelegate(in quaternion a, in quaternion b, out float angle);

	internal static class Angle_00000355$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<Angle_00000355$PostfixBurstDelegate>(Angle).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in quaternion a, in quaternion b, out float angle)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref quaternion, ref quaternion, ref float, void>)functionPointer)(ref a, ref b, ref angle);
					return;
				}
			}
			Angle$BurstManaged(in a, in b, out angle);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void Angle_00000356$PostfixBurstDelegate(in Vector3 a, in Vector3 b, out float angle);

	internal static class Angle_00000356$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<Angle_00000356$PostfixBurstDelegate>(BurstMathUtility.Angle).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in Vector3 a, in Vector3 b, out float angle)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref Vector3, ref Vector3, ref float, void>)functionPointer)(ref a, ref b, ref angle);
					return;
				}
			}
			Angle$BurstManaged(in a, in b, out angle);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate bool FastVectorEquals_00000357$PostfixBurstDelegate(in float3 a, in float3 b, float tolerance = 0.0001f);

	internal static class FastVectorEquals_00000357$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<FastVectorEquals_00000357$PostfixBurstDelegate>(FastVectorEquals).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static bool Invoke(in float3 a, in float3 b, float tolerance = 0.0001f)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					return ((delegate* unmanaged[Cdecl]<ref float3, ref float3, float, bool>)functionPointer)(ref a, ref b, tolerance);
				}
			}
			return FastVectorEquals$BurstManaged(in a, in b, tolerance);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate bool FastVectorEquals_00000358$PostfixBurstDelegate(in Vector3 a, in Vector3 b, float tolerance = 0.0001f);

	internal static class FastVectorEquals_00000358$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<FastVectorEquals_00000358$PostfixBurstDelegate>(BurstMathUtility.FastVectorEquals).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static bool Invoke(in Vector3 a, in Vector3 b, float tolerance = 0.0001f)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					return ((delegate* unmanaged[Cdecl]<ref Vector3, ref Vector3, float, bool>)functionPointer)(ref a, ref b, tolerance);
				}
			}
			return FastVectorEquals$BurstManaged(in a, in b, tolerance);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void FastSafeDivide_00000359$PostfixBurstDelegate(in Vector3 a, in Vector3 b, out Vector3 result, float tolerance = 1E-06f);

	internal static class FastSafeDivide_00000359$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<FastSafeDivide_00000359$PostfixBurstDelegate>(FastSafeDivide).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in Vector3 a, in Vector3 b, out Vector3 result, float tolerance = 1E-06f)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref Vector3, ref Vector3, ref Vector3, float, void>)functionPointer)(ref a, ref b, ref result, tolerance);
					return;
				}
			}
			FastSafeDivide$BurstManaged(in a, in b, out result, tolerance);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void FastSafeDivide_0000035A$PostfixBurstDelegate(in float3 a, in float3 b, out float3 result, float tolerance = 1E-06f);

	internal static class FastSafeDivide_0000035A$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<FastSafeDivide_0000035A$PostfixBurstDelegate>(FastSafeDivide).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in float3 a, in float3 b, out float3 result, float tolerance = 1E-06f)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref float3, ref float3, ref float3, float, void>)functionPointer)(ref a, ref b, ref result, tolerance);
					return;
				}
			}
			FastSafeDivide$BurstManaged(in a, in b, out result, tolerance);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void Scale_0000035B$PostfixBurstDelegate(in float3 a, in float3 b, out float3 result);

	internal static class Scale_0000035B$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<Scale_0000035B$PostfixBurstDelegate>(Scale).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in float3 a, in float3 b, out float3 result)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref float3, ref float3, ref float3, void>)functionPointer)(ref a, ref b, ref result);
					return;
				}
			}
			Scale$BurstManaged(in a, in b, out result);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void Scale_0000035C$PostfixBurstDelegate(in Vector3 a, in Vector3 b, out Vector3 result);

	internal static class Scale_0000035C$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<Scale_0000035C$PostfixBurstDelegate>(Scale).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in Vector3 a, in Vector3 b, out Vector3 result)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref Vector3, ref Vector3, ref Vector3, void>)functionPointer)(ref a, ref b, ref result);
					return;
				}
			}
			Scale$BurstManaged(in a, in b, out result);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void Orthogonal_0000035E$PostfixBurstDelegate(in float3 input, out float3 result);

	internal static class Orthogonal_0000035E$BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<Orthogonal_0000035E$PostfixBurstDelegate>(Orthogonal).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in float3 input, out float3 result)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref float3, ref float3, void>)functionPointer)(ref input, ref result);
					return;
				}
			}
			Orthogonal$BurstManaged(in input, out result);
		}
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(OrthogonalUpVector_0000034D$PostfixBurstDelegate))]
	public static void OrthogonalUpVector(in Vector3 forward, in Vector3 referenceUp, out Vector3 orthogonalUp)
	{
		OrthogonalUpVector_0000034D$BurstDirectCall.Invoke(in forward, in referenceUp, out orthogonalUp);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(OrthogonalUpVector_0000034E$PostfixBurstDelegate))]
	public static void OrthogonalUpVector(in float3 forward, in float3 referenceUp, out float3 orthogonalUp)
	{
		OrthogonalUpVector_0000034E$BurstDirectCall.Invoke(in forward, in referenceUp, out orthogonalUp);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(OrthogonalLookRotation_0000034F$PostfixBurstDelegate))]
	public static void OrthogonalLookRotation(in Vector3 forward, in Vector3 referenceUp, out Quaternion lookRotation)
	{
		OrthogonalLookRotation_0000034F$BurstDirectCall.Invoke(in forward, in referenceUp, out lookRotation);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(OrthogonalLookRotation_00000350$PostfixBurstDelegate))]
	public static void OrthogonalLookRotation(in float3 forward, in float3 referenceUp, out quaternion lookRotation)
	{
		OrthogonalLookRotation_00000350$BurstDirectCall.Invoke(in forward, in referenceUp, out lookRotation);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(ProjectOnPlane_00000351$PostfixBurstDelegate))]
	public static void ProjectOnPlane(in float3 vector, in float3 planeNormal, out float3 projectedVector)
	{
		ProjectOnPlane_00000351$BurstDirectCall.Invoke(in vector, in planeNormal, out projectedVector);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(ProjectOnPlane_00000352$PostfixBurstDelegate))]
	public static void ProjectOnPlane(in Vector3 vector, in Vector3 planeNormal, out Vector3 projectedVector)
	{
		ProjectOnPlane_00000352$BurstDirectCall.Invoke(in vector, in planeNormal, out projectedVector);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(LookRotationWithForwardProjectedOnPlane_00000353$PostfixBurstDelegate))]
	public static void LookRotationWithForwardProjectedOnPlane(in float3 forward, in float3 planeNormal, out quaternion lookRotation)
	{
		LookRotationWithForwardProjectedOnPlane_00000353$BurstDirectCall.Invoke(in forward, in planeNormal, out lookRotation);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(LookRotationWithForwardProjectedOnPlane_00000354$PostfixBurstDelegate))]
	public static void LookRotationWithForwardProjectedOnPlane(in Vector3 forward, in Vector3 planeNormal, out Quaternion lookRotation)
	{
		LookRotationWithForwardProjectedOnPlane_00000354$BurstDirectCall.Invoke(in forward, in planeNormal, out lookRotation);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(Angle_00000355$PostfixBurstDelegate))]
	public static void Angle(in quaternion a, in quaternion b, out float angle)
	{
		Angle_00000355$BurstDirectCall.Invoke(in a, in b, out angle);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(Angle_00000356$PostfixBurstDelegate))]
	public static void Angle(in Vector3 a, in Vector3 b, out float angle)
	{
		Angle_00000356$BurstDirectCall.Invoke(in a, in b, out angle);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(FastVectorEquals_00000357$PostfixBurstDelegate))]
	public static bool FastVectorEquals(in float3 a, in float3 b, float tolerance = 0.0001f)
	{
		return FastVectorEquals_00000357$BurstDirectCall.Invoke(in a, in b, tolerance);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(FastVectorEquals_00000358$PostfixBurstDelegate))]
	public static bool FastVectorEquals(in Vector3 a, in Vector3 b, float tolerance = 0.0001f)
	{
		return FastVectorEquals_00000358$BurstDirectCall.Invoke(in a, in b, tolerance);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(FastSafeDivide_00000359$PostfixBurstDelegate))]
	public static void FastSafeDivide(in Vector3 a, in Vector3 b, out Vector3 result, float tolerance = 1E-06f)
	{
		FastSafeDivide_00000359$BurstDirectCall.Invoke(in a, in b, out result, tolerance);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(FastSafeDivide_0000035A$PostfixBurstDelegate))]
	public static void FastSafeDivide(in float3 a, in float3 b, out float3 result, float tolerance = 1E-06f)
	{
		FastSafeDivide_0000035A$BurstDirectCall.Invoke(in a, in b, out result, tolerance);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(Scale_0000035B$PostfixBurstDelegate))]
	public static void Scale(in float3 a, in float3 b, out float3 result)
	{
		Scale_0000035B$BurstDirectCall.Invoke(in a, in b, out result);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(Scale_0000035C$PostfixBurstDelegate))]
	public static void Scale(in Vector3 a, in Vector3 b, out Vector3 result)
	{
		Scale_0000035C$BurstDirectCall.Invoke(in a, in b, out result);
	}

	public static Vector3 Orthogonal(Vector3 input)
	{
		Orthogonal((float3)input, out var result);
		return result;
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(Orthogonal_0000035E$PostfixBurstDelegate))]
	public static void Orthogonal(in float3 input, out float3 result)
	{
		Orthogonal_0000035E$BurstDirectCall.Invoke(in input, out result);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void OrthogonalUpVector$BurstManaged(in Vector3 forward, in Vector3 referenceUp, out Vector3 orthogonalUp)
	{
		OrthogonalUpVector((float3)forward, (float3)referenceUp, out var orthogonalUp2);
		orthogonalUp = orthogonalUp2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void OrthogonalUpVector$BurstManaged(in float3 forward, in float3 referenceUp, out float3 orthogonalUp)
	{
		float3 y = -math.cross(forward, referenceUp);
		orthogonalUp = math.cross(forward, y);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void OrthogonalLookRotation$BurstManaged(in Vector3 forward, in Vector3 referenceUp, out Quaternion lookRotation)
	{
		OrthogonalLookRotation((float3)forward, (float3)referenceUp, out var lookRotation2);
		lookRotation = lookRotation2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void OrthogonalLookRotation$BurstManaged(in float3 forward, in float3 referenceUp, out quaternion lookRotation)
	{
		OrthogonalUpVector(in forward, in referenceUp, out var orthogonalUp);
		lookRotation = quaternion.LookRotation(forward, orthogonalUp);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void ProjectOnPlane$BurstManaged(in float3 vector, in float3 planeNormal, out float3 projectedVector)
	{
		float num = math.dot(planeNormal, planeNormal);
		if (num < 1.1920929E-07f)
		{
			projectedVector = vector;
			return;
		}
		float num2 = math.dot(vector, planeNormal);
		projectedVector = new float3(vector.x - planeNormal.x * num2 / num, vector.y - planeNormal.y * num2 / num, vector.z - planeNormal.z * num2 / num);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void ProjectOnPlane$BurstManaged(in Vector3 vector, in Vector3 planeNormal, out Vector3 projectedVector)
	{
		ProjectOnPlane((float3)vector, (float3)planeNormal, out var projectedVector2);
		projectedVector = projectedVector2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void LookRotationWithForwardProjectedOnPlane$BurstManaged(in float3 forward, in float3 planeNormal, out quaternion lookRotation)
	{
		ProjectOnPlane(in forward, in planeNormal, out var projectedVector);
		lookRotation = quaternion.LookRotation(projectedVector, planeNormal);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void LookRotationWithForwardProjectedOnPlane$BurstManaged(in Vector3 forward, in Vector3 planeNormal, out Quaternion lookRotation)
	{
		LookRotationWithForwardProjectedOnPlane((float3)forward, (float3)planeNormal, out var lookRotation2);
		lookRotation = lookRotation2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void Angle$BurstManaged(in quaternion a, in quaternion b, out float angle)
	{
		float num = math.min(math.abs(math.dot(a, b)), 1f);
		angle = ((num > 0.999999f) ? 0f : (math.acos(num) * 2f * 57.29578f));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void Angle$BurstManaged(in Vector3 a, in Vector3 b, out float angle)
	{
		float num = math.sqrt(a.sqrMagnitude * b.sqrMagnitude);
		if (num < 1E-15f)
		{
			angle = 0f;
			return;
		}
		float x = math.clamp(math.dot(a, b) / num, -1f, 1f);
		angle = math.acos(x) * 57.29578f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static bool FastVectorEquals$BurstManaged(in float3 a, in float3 b, float tolerance = 0.0001f)
	{
		if (math.abs(a.x - b.x) < tolerance && math.abs(a.y - b.y) < tolerance)
		{
			return math.abs(a.z - b.z) < tolerance;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static bool FastVectorEquals$BurstManaged(in Vector3 a, in Vector3 b, float tolerance = 0.0001f)
	{
		if (math.abs(a.x - b.x) < tolerance && math.abs(a.y - b.y) < tolerance)
		{
			return math.abs(a.z - b.z) < tolerance;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void FastSafeDivide$BurstManaged(in Vector3 a, in Vector3 b, out Vector3 result, float tolerance = 1E-06f)
	{
		FastSafeDivide((float3)a, (float3)b, out var result2, tolerance);
		result = result2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void FastSafeDivide$BurstManaged(in float3 a, in float3 b, out float3 result, float tolerance = 1E-06f)
	{
		result = default(float3);
		if (math.abs(a.x - b.x) > tolerance)
		{
			result.x = a.x / b.x;
		}
		if (math.abs(a.y - b.y) > tolerance)
		{
			result.y = a.y / b.y;
		}
		if (math.abs(a.z - b.z) > tolerance)
		{
			result.z = a.z / b.z;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void Scale$BurstManaged(in float3 a, in float3 b, out float3 result)
	{
		result = new float3(a.x * b.x, a.y * b.y, a.z * b.z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void Scale$BurstManaged(in Vector3 a, in Vector3 b, out Vector3 result)
	{
		result = new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void Orthogonal$BurstManaged(in float3 input, out float3 result)
	{
		if (math.abs(input.x) < math.abs(input.y) && math.abs(input.x) < math.abs(input.z))
		{
			result = math.cross(input, new float3(1f, 0f, 0f));
		}
		else if (math.abs(input.y) < math.abs(input.z))
		{
			result = math.cross(input, new float3(0f, 1f, 0f));
		}
		else
		{
			result = math.cross(input, new float3(0f, 0f, 1f));
		}
	}
}
