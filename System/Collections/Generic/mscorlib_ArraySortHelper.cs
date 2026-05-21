using System.Threading;

namespace System.Collections.Generic;

internal class ArraySortHelper<TKey, TValue>
{
	private static readonly ArraySortHelper<TKey, TValue> s_defaultArraySortHelper = new ArraySortHelper<TKey, TValue>();

	public static ArraySortHelper<TKey, TValue> Default => s_defaultArraySortHelper;

	public void Sort(TKey[] keys, TValue[] values, int index, int length, IComparer<TKey> comparer)
	{
		try
		{
			if (comparer == null || comparer == Comparer<TKey>.Default)
			{
				comparer = Comparer<TKey>.Default;
			}
			IntrospectiveSort(keys, values, index, length, comparer);
		}
		catch (IndexOutOfRangeException)
		{
			IntrospectiveSortUtilities.ThrowOrIgnoreBadComparer(comparer);
		}
		catch (ThreadAbortException)
		{
			throw;
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException("Failed to compare two elements in the array.", innerException);
		}
	}

	private static void SwapIfGreaterWithItems(TKey[] keys, TValue[] values, IComparer<TKey> comparer, int a, int b)
	{
		if (a != b && comparer.Compare(keys[a], keys[b]) > 0)
		{
			TKey val = keys[a];
			keys[a] = keys[b];
			keys[b] = val;
			TValue val2 = values[a];
			values[a] = values[b];
			values[b] = val2;
		}
	}

	private static void Swap(TKey[] keys, TValue[] values, int i, int j)
	{
		if (i != j)
		{
			TKey val = keys[i];
			keys[i] = keys[j];
			keys[j] = val;
			TValue val2 = values[i];
			values[i] = values[j];
			values[j] = val2;
		}
	}

	internal static void IntrospectiveSort(TKey[] keys, TValue[] values, int left, int length, IComparer<TKey> comparer)
	{
		if (length >= 2)
		{
			IntroSort(keys, values, left, length + left - 1, 2 * IntrospectiveSortUtilities.FloorLog2PlusOne(length), comparer);
		}
	}

	private static void IntroSort(TKey[] keys, TValue[] values, int lo, int hi, int depthLimit, IComparer<TKey> comparer)
	{
		while (hi > lo)
		{
			int num = hi - lo + 1;
			if (num <= 16)
			{
				switch (num)
				{
				case 1:
					break;
				case 2:
					SwapIfGreaterWithItems(keys, values, comparer, lo, hi);
					break;
				case 3:
					SwapIfGreaterWithItems(keys, values, comparer, lo, hi - 1);
					SwapIfGreaterWithItems(keys, values, comparer, lo, hi);
					SwapIfGreaterWithItems(keys, values, comparer, hi - 1, hi);
					break;
				default:
					InsertionSort(keys, values, lo, hi, comparer);
					break;
				}
				break;
			}
			if (depthLimit == 0)
			{
				Heapsort(keys, values, lo, hi, comparer);
				break;
			}
			depthLimit--;
			int num2 = PickPivotAndPartition(keys, values, lo, hi, comparer);
			IntroSort(keys, values, num2 + 1, hi, depthLimit, comparer);
			hi = num2 - 1;
		}
	}

	private static int PickPivotAndPartition(TKey[] keys, TValue[] values, int lo, int hi, IComparer<TKey> comparer)
	{
		int num = lo + (hi - lo) / 2;
		SwapIfGreaterWithItems(keys, values, comparer, lo, num);
		SwapIfGreaterWithItems(keys, values, comparer, lo, hi);
		SwapIfGreaterWithItems(keys, values, comparer, num, hi);
		TKey val = keys[num];
		Swap(keys, values, num, hi - 1);
		int num2 = lo;
		int num3 = hi - 1;
		while (num2 < num3)
		{
			while (comparer.Compare(keys[++num2], val) < 0)
			{
			}
			while (comparer.Compare(val, keys[--num3]) < 0)
			{
			}
			if (num2 >= num3)
			{
				break;
			}
			Swap(keys, values, num2, num3);
		}
		Swap(keys, values, num2, hi - 1);
		return num2;
	}

	private static void Heapsort(TKey[] keys, TValue[] values, int lo, int hi, IComparer<TKey> comparer)
	{
		int num = hi - lo + 1;
		for (int num2 = num / 2; num2 >= 1; num2--)
		{
			DownHeap(keys, values, num2, num, lo, comparer);
		}
		for (int num3 = num; num3 > 1; num3--)
		{
			Swap(keys, values, lo, lo + num3 - 1);
			DownHeap(keys, values, 1, num3 - 1, lo, comparer);
		}
	}

	private static void DownHeap(TKey[] keys, TValue[] values, int i, int n, int lo, IComparer<TKey> comparer)
	{
		TKey val = keys[lo + i - 1];
		TValue val2 = values[lo + i - 1];
		while (i <= n / 2)
		{
			int num = 2 * i;
			if (num < n && comparer.Compare(keys[lo + num - 1], keys[lo + num]) < 0)
			{
				num++;
			}
			if (comparer.Compare(val, keys[lo + num - 1]) >= 0)
			{
				break;
			}
			keys[lo + i - 1] = keys[lo + num - 1];
			values[lo + i - 1] = values[lo + num - 1];
			i = num;
		}
		keys[lo + i - 1] = val;
		values[lo + i - 1] = val2;
	}

	private static void InsertionSort(TKey[] keys, TValue[] values, int lo, int hi, IComparer<TKey> comparer)
	{
		for (int i = lo; i < hi; i++)
		{
			int num = i;
			TKey val = keys[i + 1];
			TValue val2 = values[i + 1];
			while (num >= lo && comparer.Compare(val, keys[num]) < 0)
			{
				keys[num + 1] = keys[num];
				values[num + 1] = values[num];
				num--;
			}
			keys[num + 1] = val;
			values[num + 1] = val2;
		}
	}
}
