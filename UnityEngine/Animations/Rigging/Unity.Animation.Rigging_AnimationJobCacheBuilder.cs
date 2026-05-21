using System.Collections.Generic;

namespace UnityEngine.Animations.Rigging;

public class AnimationJobCacheBuilder
{
	private List<float> m_Data;

	public AnimationJobCacheBuilder()
	{
		m_Data = new List<float>();
	}

	public CacheIndex Add(float v)
	{
		m_Data.Add(v);
		return new CacheIndex
		{
			idx = m_Data.Count - 1
		};
	}

	public CacheIndex Add(Vector2 v)
	{
		m_Data.Add(v.x);
		m_Data.Add(v.y);
		return new CacheIndex
		{
			idx = m_Data.Count - 2
		};
	}

	public CacheIndex Add(Vector3 v)
	{
		m_Data.Add(v.x);
		m_Data.Add(v.y);
		m_Data.Add(v.z);
		return new CacheIndex
		{
			idx = m_Data.Count - 3
		};
	}

	public CacheIndex Add(Vector4 v)
	{
		m_Data.Add(v.x);
		m_Data.Add(v.y);
		m_Data.Add(v.z);
		m_Data.Add(v.w);
		return new CacheIndex
		{
			idx = m_Data.Count - 4
		};
	}

	public CacheIndex Add(Quaternion v)
	{
		return Add(new Vector4(v.x, v.y, v.z, v.w));
	}

	public CacheIndex Add(AffineTransform tx)
	{
		Add(tx.translation);
		Add(tx.rotation);
		return new CacheIndex
		{
			idx = m_Data.Count - 7
		};
	}

	public CacheIndex AllocateChunk(int size)
	{
		m_Data.AddRange(new float[size]);
		return new CacheIndex
		{
			idx = m_Data.Count - size
		};
	}

	public void SetValue(CacheIndex index, int offset, float value)
	{
		if (index.idx + offset < m_Data.Count)
		{
			m_Data[index.idx + offset] = value;
		}
	}

	public AnimationJobCache Build()
	{
		return new AnimationJobCache(m_Data.ToArray());
	}
}
