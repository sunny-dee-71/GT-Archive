using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Collections;

internal static class OVRNativeList
{
	public readonly struct CapacityHelper(int? count)
	{
		private readonly int? _count = count;

		public OVRNativeList<T> AllocateEmpty<T>(Allocator allocator) where T : unmanaged
		{
			return new OVRNativeList<T>(_count, allocator);
		}
	}

	public static CapacityHelper WithSuggestedCapacityFrom<T>([NoEnumeration] IEnumerable<T> collection)
	{
		return new CapacityHelper(collection.ToNonAlloc().Count);
	}

	public static CapacityHelper WithSuggestedCapacityFrom<T>([NoEnumeration] IEnumerable<T> collection, out OVREnumerable<T> nonAllocatingEnumerable)
	{
		nonAllocatingEnumerable = collection.ToNonAlloc();
		return new CapacityHelper(nonAllocatingEnumerable.Count);
	}

	public static OVRNativeList<T> ToNativeList<T>(this IEnumerable<T> collection, Allocator allocator) where T : unmanaged
	{
		OVRNativeList<T> result = new OVRNativeList<T>(allocator);
		result.AddRange(collection);
		return result;
	}
}
