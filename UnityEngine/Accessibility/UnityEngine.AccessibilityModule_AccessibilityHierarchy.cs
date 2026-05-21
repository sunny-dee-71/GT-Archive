using System;
using System.Collections.Generic;
using UnityEngine.Bindings;

namespace UnityEngine.Accessibility;

public class AccessibilityHierarchy
{
	internal List<AccessibilityNode> m_RootNodes;

	private Stack<AccessibilityNode> m_FirstLowestCommonAncestorChain;

	private Stack<AccessibilityNode> m_SecondLowestCommonAncestorChain;

	private static int m_NextUniqueNodeId;

	private readonly IDictionary<int, AccessibilityNode> m_Nodes;

	public IReadOnlyList<AccessibilityNode> rootNodes => m_RootNodes;

	private event Action<AccessibilityHierarchy> m_Changed;

	internal event Action<AccessibilityHierarchy> changed
	{
		[VisibleToOtherModules(new string[] { "UnityEditor.AccessibilityModule" })]
		add
		{
			m_Changed += value;
		}
		[VisibleToOtherModules(new string[] { "UnityEditor.AccessibilityModule" })]
		remove
		{
			m_Changed -= value;
		}
	}

	public AccessibilityHierarchy()
	{
		m_FirstLowestCommonAncestorChain = new Stack<AccessibilityNode>();
		m_SecondLowestCommonAncestorChain = new Stack<AccessibilityNode>();
		m_Nodes = new Dictionary<int, AccessibilityNode>();
		m_RootNodes = new List<AccessibilityNode>();
	}

	internal void NotifyHierarchyChanged()
	{
		this.m_Changed?.Invoke(this);
	}

	public void Clear()
	{
		for (int num = m_RootNodes.Count - 1; num >= 0; num--)
		{
			RemoveNode(m_RootNodes[num]);
		}
	}

	public bool TryGetNode(int id, out AccessibilityNode node)
	{
		return m_Nodes.TryGetValue(id, out node);
	}

	public AccessibilityNode AddNode(string label = null, AccessibilityNode parent = null)
	{
		return InsertNode(-1, label, parent);
	}

	public AccessibilityNode InsertNode(int childIndex, string label = null, AccessibilityNode parent = null)
	{
		if (parent != null)
		{
			ValidateNodeInHierarchy(parent);
		}
		AccessibilityNode accessibilityNode = GenerateNewNode();
		m_Nodes[accessibilityNode.id] = accessibilityNode;
		if (label != null)
		{
			accessibilityNode.label = label;
		}
		IList<AccessibilityNode> newParentChildren;
		if (parent != null)
		{
			newParentChildren = parent.childList;
		}
		else
		{
			IList<AccessibilityNode> list = m_RootNodes;
			newParentChildren = list;
		}
		SetParent(accessibilityNode, parent, null, newParentChildren, childIndex);
		NotifyHierarchyChanged();
		return accessibilityNode;
	}

	public bool MoveNode(AccessibilityNode node, AccessibilityNode newParent, int newChildIndex = -1)
	{
		ValidateNodeInHierarchy(node);
		if (node == newParent)
		{
			throw new ArgumentException($"Attempting to move the node {node} under itself.");
		}
		if (node.parent == newParent)
		{
			IList<AccessibilityNode> list;
			if (newParent != null)
			{
				list = newParent.childList;
			}
			else
			{
				IList<AccessibilityNode> list2 = m_RootNodes;
				list = list2;
			}
			IList<AccessibilityNode> list3 = list;
			if (newChildIndex == list3.IndexOf(node))
			{
				return false;
			}
			CheckForLoopsAndSetParent(node, newParent, newChildIndex);
			return true;
		}
		if (newParent == null)
		{
			if (node.parent == null)
			{
				return false;
			}
			CheckForLoopsAndSetParent(node, null, newChildIndex);
			return true;
		}
		ValidateNodeInHierarchy(newParent);
		CheckForLoopsAndSetParent(node, newParent, newChildIndex);
		NotifyHierarchyChanged();
		return true;
	}

	public void RemoveNode(AccessibilityNode node, bool removeChildren = true)
	{
		ValidateNodeInHierarchy(node);
		if (removeChildren)
		{
			removeFromNodes(node);
		}
		else
		{
			m_Nodes.Remove(node.id);
		}
		if (m_RootNodes.Contains(node))
		{
			m_RootNodes.Remove(node);
			if (!removeChildren)
			{
				m_RootNodes.AddRange(node.childList);
			}
		}
		node.Destroy(removeChildren);
		NotifyHierarchyChanged();
		void removeFromNodes(AccessibilityNode child)
		{
			m_Nodes.Remove(child.id);
			for (int i = 0; i < child.childList.Count; i++)
			{
				removeFromNodes(child.childList[i]);
			}
		}
	}

	public bool ContainsNode(AccessibilityNode node)
	{
		return node != null && m_Nodes.ContainsKey(node.id) && m_Nodes[node.id] == node;
	}

	private void CheckForLoopsAndSetParent(AccessibilityNode node, AccessibilityNode parent, int newChildIndex = -1)
	{
		if (parent == null)
		{
			SetParent(node, null, node.parent?.childList ?? m_RootNodes, m_RootNodes, newChildIndex);
			return;
		}
		if (node.parent == parent)
		{
			SetParent(node, parent, parent.childList, parent.childList, newChildIndex);
			return;
		}
		if (node.parent == null && parent.parent == null)
		{
			SetParent(node, parent, m_RootNodes, parent.childList, newChildIndex);
			return;
		}
		for (AccessibilityNode parent2 = parent.parent; parent2 != null; parent2 = parent2.parent)
		{
			if (parent2 == node)
			{
				throw new ArgumentException($"Trying to set the node {node} to have parent {parent}, but this would create a loop.");
			}
		}
		SetParent(node, parent, node.parent?.childList ?? m_RootNodes, parent.childList, newChildIndex);
	}

	private void SetParent(AccessibilityNode node, AccessibilityNode parent, IList<AccessibilityNode> previousParentChildren, IList<AccessibilityNode> newParentChildren, int newChildIndex = -1)
	{
		previousParentChildren?.Remove(node);
		node.SetParent(parent, newChildIndex);
		if (newChildIndex < 0 || newChildIndex > newParentChildren.Count)
		{
			newParentChildren.Add(node);
		}
		else
		{
			newParentChildren.Insert(newChildIndex, node);
		}
	}

	internal void AllocateNative()
	{
		foreach (AccessibilityNode rootNode in m_RootNodes)
		{
			rootNode.AllocateNative();
		}
	}

	internal void FreeNative()
	{
		foreach (AccessibilityNode rootNode in m_RootNodes)
		{
			rootNode.FreeNative(freeChildren: true);
		}
	}

	public void RefreshNodeFrames()
	{
		foreach (AccessibilityNode value in m_Nodes.Values)
		{
			value.CalculateFrame();
		}
		AssistiveSupport.OnHierarchyNodeFramesRefreshed(this);
	}

	public bool TryGetNodeAt(float horizontalPosition, float verticalPosition, out AccessibilityNode node)
	{
		node = FindNodeContainingPoint(pos: new Vector2(horizontalPosition, verticalPosition), nodes: m_RootNodes);
		return node != null;
		static AccessibilityNode FindNodeContainingPoint(IList<AccessibilityNode> nodes, Vector2 pos)
		{
			for (int num = nodes.Count - 1; num >= 0; num--)
			{
				AccessibilityNode accessibilityNode = nodes[num];
				AccessibilityNode accessibilityNode2 = FindNodeContainingPoint(accessibilityNode.childList, pos);
				if (accessibilityNode2 != null)
				{
					return accessibilityNode2;
				}
				if (accessibilityNode.isActive && accessibilityNode.frame.Contains(pos))
				{
					return accessibilityNode;
				}
			}
			return null;
		}
	}

	public AccessibilityNode GetLowestCommonAncestor(AccessibilityNode firstNode, AccessibilityNode secondNode)
	{
		if (firstNode == null || secondNode == null)
		{
			return null;
		}
		if (firstNode.parent == null && secondNode.parent == null)
		{
			return null;
		}
		if (!ContainsNode(firstNode) || !ContainsNode(secondNode))
		{
			return null;
		}
		m_FirstLowestCommonAncestorChain.Clear();
		m_SecondLowestCommonAncestorChain.Clear();
		buildNodeIdStack(firstNode, ref m_FirstLowestCommonAncestorChain);
		buildNodeIdStack(secondNode, ref m_SecondLowestCommonAncestorChain);
		AccessibilityNode result = null;
		for (int num = Mathf.Min(m_FirstLowestCommonAncestorChain.Count, m_SecondLowestCommonAncestorChain.Count); num > 0; num--)
		{
			AccessibilityNode accessibilityNode = m_FirstLowestCommonAncestorChain.Pop();
			AccessibilityNode accessibilityNode2 = m_SecondLowestCommonAncestorChain.Pop();
			if (accessibilityNode != accessibilityNode2)
			{
				break;
			}
			result = accessibilityNode;
		}
		return result;
		void buildNodeIdStack(AccessibilityNode node, ref Stack<AccessibilityNode> nodeStack)
		{
			while (node != null)
			{
				nodeStack.Push(node);
				node = m_Nodes[node.id].parent;
			}
		}
	}

	internal AccessibilityNode GenerateNewNode()
	{
		if (m_NextUniqueNodeId >= int.MaxValue)
		{
			throw new Exception($"Could not generate unique node for hierarchy. A hierarchy may only have up to {int.MaxValue} nodes.");
		}
		AccessibilityNode accessibilityNode = new AccessibilityNode(m_NextUniqueNodeId, this);
		m_NextUniqueNodeId = accessibilityNode.id + 1;
		return accessibilityNode;
	}

	private void ValidateNodeInHierarchy(AccessibilityNode node)
	{
		if (node != null)
		{
			if (ContainsNode(node))
			{
				return;
			}
			throw new ArgumentException($"Trying to use an AccessibilityNode with ID {node.id} that is not part of this hierarchy.");
		}
		throw new ArgumentNullException("node");
	}
}
