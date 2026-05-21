using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace Unity.Hierarchy;

public readonly struct HierarchyNodeTypeHandlerBaseEnumerable
{
	public struct Enumerator : IDisposable
	{
		private readonly IMemoryOwner<IntPtr> m_Handlers;

		private readonly int m_Count;

		private int m_Index;

		public HierarchyNodeTypeHandlerBase Current
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return HierarchyNodeTypeHandlerBase.FromIntPtr(m_Handlers.Memory.Span[m_Index]);
			}
		}

		internal Enumerator(Hierarchy hierarchy)
		{
			m_Handlers = MemoryPool<IntPtr>.Shared.Rent(hierarchy.GetNodeTypeHandlersBaseCount());
			m_Count = hierarchy.GetNodeTypeHandlersBaseSpan(m_Handlers.Memory.Span);
			m_Index = -1;
		}

		public void Dispose()
		{
			m_Handlers.Dispose();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool MoveNext()
		{
			return ++m_Index < m_Count;
		}
	}

	private readonly Hierarchy m_Hierarchy;

	internal HierarchyNodeTypeHandlerBaseEnumerable(Hierarchy hierarchy)
	{
		m_Hierarchy = hierarchy;
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(m_Hierarchy);
	}
}
