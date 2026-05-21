using System;

namespace Mono.Globalization.Unicode;

internal class CodePointIndexer
{
	[Serializable]
	internal struct TableRange(int start, int end, int indexStart)
	{
		public readonly int Start = start;

		public readonly int End = end;

		public readonly int Count = End - Start;

		public readonly int IndexStart = indexStart;

		public readonly int IndexEnd = IndexStart + Count;
	}

	private readonly TableRange[] ranges;

	public readonly int TotalCount;

	private int defaultIndex;

	private int defaultCP;

	public static Array CompressArray(Array source, Type type, CodePointIndexer indexer)
	{
		int num = 0;
		for (int i = 0; i < indexer.ranges.Length; i++)
		{
			num += indexer.ranges[i].Count;
		}
		Array array = Array.CreateInstance(type, num);
		for (int j = 0; j < indexer.ranges.Length; j++)
		{
			Array.Copy(source, indexer.ranges[j].Start, array, indexer.ranges[j].IndexStart, indexer.ranges[j].Count);
		}
		return array;
	}

	public CodePointIndexer(int[] starts, int[] ends, int defaultIndex, int defaultCP)
	{
		this.defaultIndex = defaultIndex;
		this.defaultCP = defaultCP;
		ranges = new TableRange[starts.Length];
		for (int i = 0; i < ranges.Length; i++)
		{
			ranges[i] = new TableRange(starts[i], ends[i], (i != 0) ? (ranges[i - 1].IndexStart + ranges[i - 1].Count) : 0);
		}
		for (int j = 0; j < ranges.Length; j++)
		{
			TotalCount += ranges[j].Count;
		}
	}

	public int ToIndex(int cp)
	{
		for (int i = 0; i < ranges.Length; i++)
		{
			if (cp < ranges[i].Start)
			{
				return defaultIndex;
			}
			if (cp < ranges[i].End)
			{
				return cp - ranges[i].Start + ranges[i].IndexStart;
			}
		}
		return defaultIndex;
	}

	public int ToCodePoint(int i)
	{
		for (int j = 0; j < ranges.Length; j++)
		{
			if (i < ranges[j].IndexStart)
			{
				return defaultCP;
			}
			if (i < ranges[j].IndexEnd)
			{
				return i - ranges[j].IndexStart + ranges[j].Start;
			}
		}
		return defaultCP;
	}
}
