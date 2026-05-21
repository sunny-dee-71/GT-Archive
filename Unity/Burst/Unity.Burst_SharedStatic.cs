using System;
using System.Diagnostics;
using Unity.Burst.LowLevel;
using UnityEngine;

namespace Unity.Burst;

internal static class SharedStatic
{
	internal class PreserveAttribute : Attribute
	{
	}

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckSizeOf(uint sizeOf)
	{
		if (sizeOf == 0)
		{
			throw new ArgumentException("sizeOf must be > 0", "sizeOf");
		}
	}

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private unsafe static void CheckResult(void* result)
	{
		if (result == null)
		{
			throw new InvalidOperationException("Unable to create a SharedStatic for this key. This is most likely due to the size of the struct inside of the SharedStatic having changed or the same key being reused for differently sized values. To fix this the editor needs to be restarted.");
		}
	}

	[Preserve]
	public unsafe static void* GetOrCreateSharedStaticInternal(long getHashCode64, long getSubHashCode64, uint sizeOf, uint alignment)
	{
		Hash128 key = new Hash128((ulong)getHashCode64, (ulong)getSubHashCode64);
		return BurstCompilerService.GetOrCreateSharedMemory(ref key, sizeOf, alignment);
	}
}
