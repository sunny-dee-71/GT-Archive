using System;
using System.Collections.Generic;
using System.Threading;

namespace g3;

public class PointHashGrid2d<T>
{
	private Dictionary<Vector2i, List<T>> Hash;

	private ScaleGridIndexer2 Indexer;

	private T invalidValue;

	private SpinLock spinlock;

	public T InvalidValue => invalidValue;

	public PointHashGrid2d(double cellSize, T invalidValue)
	{
		Hash = new Dictionary<Vector2i, List<T>>();
		Indexer = new ScaleGridIndexer2
		{
			CellSize = cellSize
		};
		spinlock = default(SpinLock);
		this.invalidValue = invalidValue;
	}

	public void InsertPoint(T value, Vector2d pos)
	{
		Vector2i idx = Indexer.ToGrid(pos);
		insert_point(value, idx);
	}

	public void InsertPointUnsafe(T value, Vector2d pos)
	{
		Vector2i idx = Indexer.ToGrid(pos);
		insert_point(value, idx, threadsafe: false);
	}

	public bool RemovePoint(T value, Vector2d pos)
	{
		Vector2i idx = Indexer.ToGrid(pos);
		return remove_point(value, idx);
	}

	public bool RemovePointUnsafe(T value, Vector2d pos)
	{
		Vector2i idx = Indexer.ToGrid(pos);
		return remove_point(value, idx, threadsafe: false);
	}

	public void UpdatePoint(T value, Vector2d old_pos, Vector2d new_pos)
	{
		Vector2i vector2i = Indexer.ToGrid(old_pos);
		Vector2i vector2i2 = Indexer.ToGrid(new_pos);
		if (!(vector2i == vector2i2))
		{
			remove_point(value, vector2i);
			insert_point(value, vector2i2);
		}
	}

	public void UpdatePointUnsafe(T value, Vector2d old_pos, Vector2d new_pos)
	{
		Vector2i vector2i = Indexer.ToGrid(old_pos);
		Vector2i vector2i2 = Indexer.ToGrid(new_pos);
		if (!(vector2i == vector2i2))
		{
			remove_point(value, vector2i, threadsafe: false);
			insert_point(value, vector2i2, threadsafe: false);
		}
	}

	public KeyValuePair<T, double> FindNearestInRadius(Vector2d query_pt, double radius, Func<T, double> distF, Func<T, bool> ignoreF = null)
	{
		Vector2i vector2i = Indexer.ToGrid(query_pt - radius * Vector2d.One);
		Vector2i vector2i2 = Indexer.ToGrid(query_pt + radius * Vector2d.One);
		double num = double.MaxValue;
		T key = invalidValue;
		if (ignoreF == null)
		{
			ignoreF = (T pt) => false;
		}
		for (int num2 = vector2i.y; num2 <= vector2i2.y; num2++)
		{
			for (int num3 = vector2i.x; num3 <= vector2i2.x; num3++)
			{
				Vector2i key2 = new Vector2i(num3, num2);
				if (!Hash.TryGetValue(key2, out var value))
				{
					continue;
				}
				foreach (T item in value)
				{
					if (!ignoreF(item))
					{
						double num4 = distF(item);
						if (num4 < radius && num4 < num)
						{
							key = item;
							num = num4;
						}
					}
				}
			}
		}
		return new KeyValuePair<T, double>(key, num);
	}

	private void insert_point(T value, Vector2i idx, bool threadsafe = true)
	{
		bool lockTaken = false;
		while (threadsafe && !lockTaken)
		{
			spinlock.Enter(ref lockTaken);
		}
		if (Hash.TryGetValue(idx, out var value2))
		{
			value2.Add(value);
		}
		else
		{
			Hash[idx] = new List<T> { value };
		}
		if (lockTaken)
		{
			spinlock.Exit();
		}
	}

	private bool remove_point(T value, Vector2i idx, bool threadsafe = true)
	{
		bool lockTaken = false;
		while (threadsafe && !lockTaken)
		{
			spinlock.Enter(ref lockTaken);
		}
		bool result = false;
		if (Hash.TryGetValue(idx, out var value2))
		{
			result = value2.Remove(value);
		}
		if (lockTaken)
		{
			spinlock.Exit();
		}
		return result;
	}
}
