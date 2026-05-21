using System;
using System.Runtime.CompilerServices;

namespace Unity.Hierarchy;

public readonly struct HierarchyViewNodesEnumerable
{
	internal delegate bool Predicate(in HierarchyNode node, HierarchyNodeFlags flags);

	public struct Enumerator
	{
		private readonly HierarchyFlattened m_HierarchyFlattened;

		private readonly Predicate m_Predicate;

		private readonly HierarchyNodeFlags m_Flags;

		private unsafe readonly HierarchyFlattenedNode* m_NodesPtr;

		private readonly int m_NodesCount;

		private readonly int m_Version;

		private int m_Index;

		public unsafe ref readonly HierarchyNode Current
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				ThrowIfVersionChanged();
				return ref HierarchyFlattenedNode.GetNodeByRef(in m_NodesPtr[m_Index]);
			}
		}

		internal unsafe Enumerator(HierarchyViewNodesEnumerable enumerable)
		{
			m_HierarchyFlattened = enumerable.m_HierarchyViewModel.HierarchyFlattened;
			m_Predicate = enumerable.m_Predicate;
			m_Flags = enumerable.m_Flags;
			m_NodesPtr = m_HierarchyFlattened.NodesPtr;
			m_NodesCount = m_HierarchyFlattened.Count;
			m_Version = m_HierarchyFlattened.Version;
			m_Index = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe bool MoveNext()
		{
			ThrowIfVersionChanged();
			do
			{
				if (++m_Index >= m_NodesCount)
				{
					return false;
				}
			}
			while (!m_Predicate(in HierarchyFlattenedNode.GetNodeByRef(in m_NodesPtr[m_Index]), m_Flags));
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ThrowIfVersionChanged()
		{
			if (m_Version != m_HierarchyFlattened.Version)
			{
				throw new InvalidOperationException("HierarchyFlattened was modified.");
			}
		}
	}

	private readonly HierarchyViewModel m_HierarchyViewModel;

	private readonly Predicate m_Predicate;

	private readonly HierarchyNodeFlags m_Flags;

	internal HierarchyViewNodesEnumerable(HierarchyViewModel viewModel, HierarchyNodeFlags flags, Predicate predicate)
	{
		m_HierarchyViewModel = viewModel ?? throw new ArgumentNullException("viewModel");
		m_Predicate = predicate ?? throw new ArgumentNullException("predicate");
		m_Flags = flags;
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this);
	}
}
