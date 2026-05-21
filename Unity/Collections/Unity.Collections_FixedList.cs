using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Unity.Collections;

[StructLayout(LayoutKind.Sequential, Size = 1)]
[GenerateTestsForBurstCompatibility]
internal struct FixedList
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[] { typeof(int) })]
	internal static int PaddingBytes<T>() where T : unmanaged
	{
		return math.max(0, math.min(6, (1 << math.tzcnt(UnsafeUtility.SizeOf<T>())) - 2));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[]
	{
		typeof(int),
		typeof(int)
	})]
	internal static int StorageBytes<BUFFER, T>() where BUFFER : unmanaged where T : unmanaged
	{
		return UnsafeUtility.SizeOf<BUFFER>() - UnsafeUtility.SizeOf<ushort>() - PaddingBytes<T>();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[]
	{
		typeof(int),
		typeof(int)
	})]
	internal static int Capacity<BUFFER, T>() where BUFFER : unmanaged where T : unmanaged
	{
		return StorageBytes<BUFFER, T>() / UnsafeUtility.SizeOf<T>();
	}

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[]
	{
		typeof(int),
		typeof(int)
	})]
	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	internal static void CheckResize<BUFFER, T>(int newLength) where BUFFER : unmanaged where T : unmanaged
	{
		int num = Capacity<BUFFER, T>();
		if (newLength < 0 || newLength > num)
		{
			throw new IndexOutOfRangeException($"NewLength {newLength} is out of range of '{num}' Capacity.");
		}
	}
}
