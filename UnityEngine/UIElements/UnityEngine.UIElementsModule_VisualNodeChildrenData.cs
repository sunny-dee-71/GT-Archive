using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace UnityEngine.UIElements;

[StructLayout(LayoutKind.Explicit, Size = 32)]
internal readonly struct VisualNodeChildrenData : IEnumerable<VisualNodeHandle>, IEnumerable
{
	public unsafe struct Enumerator(VisualNodeHandle* ptr, int count) : IEnumerator<VisualNodeHandle>, IEnumerator, IDisposable
	{
		private unsafe VisualNodeHandle* m_Ptr = ptr;

		private int m_Count = count;

		private int m_Index = -1;

		public unsafe VisualNodeHandle Current => m_Ptr[m_Index];

		object IEnumerator.Current => Current;

		public bool MoveNext()
		{
			return ++m_Index < m_Count;
		}

		public void Reset()
		{
			m_Index = -1;
		}

		public unsafe void Dispose()
		{
			m_Ptr = null;
		}
	}

	[FieldOffset(0)]
	private readonly VisualNodeChildrenFixed m_Fixed;

	[FieldOffset(0)]
	private readonly VisualNodeChildrenAlloc m_Alloc;

	public int Count => m_Alloc.IsCreated ? m_Alloc.Count : m_Fixed.Count;

	public VisualNodeHandle this[int index] => m_Alloc.IsCreated ? m_Alloc[index] : m_Fixed[index];

	public VisualNodeHandle ElementAt(int index)
	{
		return m_Alloc.IsCreated ? m_Alloc[index] : m_Fixed[index];
	}

	public unsafe VisualNodeHandle* GetUnsafePtr()
	{
		fixed (VisualNodeChildrenData* result = &this)
		{
			return (VisualNodeHandle*)result;
		}
	}

	public unsafe Enumerator GetEnumerator()
	{
		return new Enumerator(GetUnsafePtr(), Count);
	}

	unsafe IEnumerator<VisualNodeHandle> IEnumerable<VisualNodeHandle>.GetEnumerator()
	{
		return new Enumerator(GetUnsafePtr(), Count);
	}

	unsafe IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(GetUnsafePtr(), Count);
	}
}
