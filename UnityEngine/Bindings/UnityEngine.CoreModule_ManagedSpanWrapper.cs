using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.Bindings;

[VisibleToOtherModules]
internal unsafe readonly ref struct ManagedSpanWrapper(void* begin, int length)
{
	public unsafe readonly void* begin = begin;

	public readonly int length = length;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe static Span<T> ToSpan<T>(ManagedSpanWrapper spanWrapper)
	{
		return new Span<T>(spanWrapper.begin, spanWrapper.length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe static ReadOnlySpan<T> ToReadOnlySpan<T>(ManagedSpanWrapper spanWrapper)
	{
		return new ReadOnlySpan<T>(spanWrapper.begin, spanWrapper.length);
	}
}
