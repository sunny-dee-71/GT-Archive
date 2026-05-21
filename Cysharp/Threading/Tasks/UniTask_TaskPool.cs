using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Cysharp.Threading.Tasks;

[StructLayout(LayoutKind.Auto)]
public struct TaskPool<T> where T : class, ITaskPoolNode<T>
{
	private int gate;

	private int size;

	private T root;

	public int Size => size;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryPop(out T result)
	{
		if (Interlocked.CompareExchange(ref gate, 1, 0) == 0)
		{
			T val = root;
			if (val != null)
			{
				ref T nextNode = ref val.NextNode;
				root = nextNode;
				nextNode = null;
				size--;
				result = val;
				Volatile.Write(ref gate, 0);
				return true;
			}
			Volatile.Write(ref gate, 0);
		}
		result = null;
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryPush(T item)
	{
		if (Interlocked.CompareExchange(ref gate, 1, 0) == 0)
		{
			if (size < TaskPool.MaxPoolSize)
			{
				item.NextNode = root;
				root = item;
				size++;
				Volatile.Write(ref gate, 0);
				return true;
			}
			Volatile.Write(ref gate, 0);
		}
		return false;
	}
}
