using System;
using System.Collections.Generic;

namespace TMPro;

public class FastAction<A, B, C>
{
	private LinkedList<Action<A, B, C>> delegates = new LinkedList<Action<A, B, C>>();

	private Dictionary<Action<A, B, C>, LinkedListNode<Action<A, B, C>>> lookup = new Dictionary<Action<A, B, C>, LinkedListNode<Action<A, B, C>>>();

	public void Add(Action<A, B, C> rhs)
	{
		if (!lookup.ContainsKey(rhs))
		{
			lookup[rhs] = delegates.AddLast(rhs);
		}
	}

	public void Remove(Action<A, B, C> rhs)
	{
		if (lookup.TryGetValue(rhs, out var value))
		{
			lookup.Remove(rhs);
			delegates.Remove(value);
		}
	}

	public void Call(A a, B b, C c)
	{
		for (LinkedListNode<Action<A, B, C>> linkedListNode = delegates.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
		{
			linkedListNode.Value(a, b, c);
		}
	}
}
