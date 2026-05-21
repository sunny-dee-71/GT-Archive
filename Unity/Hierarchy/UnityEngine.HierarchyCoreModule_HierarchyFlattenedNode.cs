using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace Unity.Hierarchy;

[NativeHeader("Modules/HierarchyCore/Public/HierarchyFlattenedNode.h")]
public readonly struct HierarchyFlattenedNode : IEquatable<HierarchyFlattenedNode>
{
	private static readonly HierarchyFlattenedNode s_Null;

	private readonly HierarchyNode m_Node = HierarchyNode.Null;

	private readonly HierarchyNodeType m_Type = HierarchyNodeType.Null;

	private readonly int m_ParentOffset = 0;

	private readonly int m_NextSiblingOffset = 0;

	private readonly int m_ChildrenCount = 0;

	private readonly int m_Depth = 0;

	public static ref readonly HierarchyFlattenedNode Null => ref s_Null;

	public HierarchyNode Node => m_Node;

	public HierarchyNodeType Type => m_Type;

	public int ParentOffset => m_ParentOffset;

	public int NextSiblingOffset => m_NextSiblingOffset;

	public int ChildrenCount => m_ChildrenCount;

	public int Depth => m_Depth;

	public HierarchyFlattenedNode()
	{
	}

	[ExcludeFromDocs]
	public static bool operator ==(in HierarchyFlattenedNode lhs, in HierarchyFlattenedNode rhs)
	{
		return lhs.Node == rhs.Node;
	}

	[ExcludeFromDocs]
	public static bool operator !=(in HierarchyFlattenedNode lhs, in HierarchyFlattenedNode rhs)
	{
		return !(lhs == rhs);
	}

	[ExcludeFromDocs]
	public bool Equals(HierarchyFlattenedNode other)
	{
		return other.Node == Node;
	}

	[ExcludeFromDocs]
	public override string ToString()
	{
		return "HierarchyFlattenedNode(" + ((this == Null) ? "Null" : $"{Node.Id}:{Node.Version}") + ")";
	}

	[ExcludeFromDocs]
	public override bool Equals(object obj)
	{
		return obj is HierarchyFlattenedNode other && Equals(other);
	}

	[ExcludeFromDocs]
	public override int GetHashCode()
	{
		return Node.GetHashCode();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static ref readonly HierarchyNode GetNodeByRef(in HierarchyFlattenedNode hierarchyFlattenedNode)
	{
		return ref hierarchyFlattenedNode.m_Node;
	}
}
