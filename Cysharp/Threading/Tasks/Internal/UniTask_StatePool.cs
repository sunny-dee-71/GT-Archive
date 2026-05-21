using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace Cysharp.Threading.Tasks.Internal;

internal static class StatePool<T1, T2, T3>
{
	private static readonly ConcurrentQueue<StateTuple<T1, T2, T3>> queue = new ConcurrentQueue<StateTuple<T1, T2, T3>>();

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static StateTuple<T1, T2, T3> Create(T1 item1, T2 item2, T3 item3)
	{
		if (queue.TryDequeue(out var result))
		{
			result.Item1 = item1;
			result.Item2 = item2;
			result.Item3 = item3;
			return result;
		}
		return new StateTuple<T1, T2, T3>
		{
			Item1 = item1,
			Item2 = item2,
			Item3 = item3
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Return(StateTuple<T1, T2, T3> tuple)
	{
		tuple.Item1 = default(T1);
		tuple.Item2 = default(T2);
		tuple.Item3 = default(T3);
		queue.Enqueue(tuple);
	}
}
