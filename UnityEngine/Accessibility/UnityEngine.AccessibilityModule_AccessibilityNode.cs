using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityEngine.Accessibility;

public class AccessibilityNode
{
	private class ObservableList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>, IList, ICollection
	{
		private readonly List<T> m_Items;

		public int Count => m_Items.Count;

		public bool IsSynchronized => ((ICollection)m_Items)?.IsSynchronized ?? false;

		public object SyncRoot => ((ICollection)m_Items)?.SyncRoot ?? ((object)false);

		public bool IsReadOnly => ((IList)m_Items)?.IsReadOnly ?? false;

		object IList.this[int index]
		{
			get
			{
				return m_Items[index];
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public bool IsFixedSize { get; }

		public T this[int index]
		{
			get
			{
				return m_Items[index];
			}
			set
			{
				m_Items[index] = value;
			}
		}

		public event Action listChanged;

		public ObservableList()
		{
			m_Items = new List<T>();
		}

		public ObservableList(IEnumerable<T> enumerable)
		{
			m_Items = new List<T>(enumerable);
		}

		public void CopyTo(Array array, int index)
		{
			((ICollection)m_Items)?.CopyTo(array, index);
		}

		public void Add(T item)
		{
			m_Items.Add(item);
			this.listChanged?.Invoke();
		}

		public void Insert(int index, T item)
		{
			m_Items.Insert(index, item);
			this.listChanged?.Invoke();
		}

		public void Remove(T item)
		{
			m_Items.Remove(item);
			this.listChanged?.Invoke();
		}

		bool ICollection<T>.Remove(T item)
		{
			bool flag = m_Items.Remove(item);
			if (flag)
			{
				this.listChanged?.Invoke();
			}
			return flag;
		}

		public void Remove(object value)
		{
			throw new NotImplementedException();
		}

		public void RemoveAt(int index)
		{
			m_Items.RemoveAt(index);
			this.listChanged?.Invoke();
		}

		public int Add(object value)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			m_Items.Clear();
			this.listChanged?.Invoke();
		}

		public bool Contains(object value)
		{
			throw new NotImplementedException();
		}

		public int IndexOf(object value)
		{
			throw new NotImplementedException();
		}

		public void Insert(int index, object value)
		{
			throw new NotImplementedException();
		}

		public int IndexOf(T item)
		{
			return m_Items.IndexOf(item);
		}

		public bool Contains(T item)
		{
			return m_Items.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			m_Items.CopyTo(array, arrayIndex);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return m_Items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return m_Items.GetEnumerator();
		}
	}

	private Func<Rect> m_FrameGetter;

	private string m_Label;

	private string m_Value;

	private string m_Hint;

	private bool m_IsActive = true;

	private AccessibilityRole m_Role;

	private bool m_AllowsDirectInteraction;

	private AccessibilityState m_State;

	private AccessibilityNode m_Parent;

	private ObservableList<AccessibilityNode> m_Children;

	private ObservableList<AccessibilityAction> m_Actions;

	private Rect m_Frame;

	private SystemLanguage m_Language = SystemLanguage.Unknown;

	private AccessibilityHierarchy m_Hierarchy;

	public int id { get; private set; }

	public string label
	{
		get
		{
			return m_Label;
		}
		set
		{
			if (!string.Equals(m_Label, value))
			{
				m_Label = value;
				if (IsInActiveHierarchy())
				{
					AccessibilityNodeManager.SetLabel(id, value);
				}
			}
		}
	}

	public string value
	{
		get
		{
			return m_Value;
		}
		set
		{
			if (!string.Equals(m_Value, value))
			{
				m_Value = value;
				if (IsInActiveHierarchy())
				{
					AccessibilityNodeManager.SetValue(id, value);
				}
			}
		}
	}

	public string hint
	{
		get
		{
			return m_Hint;
		}
		set
		{
			if (!string.Equals(m_Hint, value))
			{
				m_Hint = value;
				if (IsInActiveHierarchy())
				{
					AccessibilityNodeManager.SetHint(id, value);
				}
			}
		}
	}

	public bool isActive
	{
		get
		{
			return m_IsActive;
		}
		set
		{
			if (m_IsActive != value)
			{
				m_IsActive = value;
				if (IsInActiveHierarchy())
				{
					AccessibilityNodeManager.SetIsActive(id, value);
				}
			}
		}
	}

	public AccessibilityRole role
	{
		get
		{
			return m_Role;
		}
		set
		{
			if (m_Role != value)
			{
				m_Role = value;
				if (IsInActiveHierarchy())
				{
					AccessibilityNodeManager.SetRole(id, value);
				}
			}
		}
	}

	public bool allowsDirectInteraction
	{
		get
		{
			return m_AllowsDirectInteraction;
		}
		set
		{
			if (value && !Application.isEditor && Application.platform != RuntimePlatform.IPhonePlayer)
			{
				throw new PlatformNotSupportedException("allowsDirectInteraction is only supported on iOS.");
			}
			if (m_AllowsDirectInteraction != value)
			{
				m_AllowsDirectInteraction = value;
				if (IsInActiveHierarchy())
				{
					AccessibilityNodeManager.SetAllowsDirectInteraction(id, value);
				}
			}
		}
	}

	public AccessibilityState state
	{
		get
		{
			return m_State;
		}
		set
		{
			if (m_State != value)
			{
				m_State = value;
				if (IsInActiveHierarchy())
				{
					AccessibilityNodeManager.SetState(id, value);
				}
			}
		}
	}

	public AccessibilityNode parent => m_Parent;

	internal IList<AccessibilityNode> childList
	{
		get
		{
			return m_Children;
		}
		set
		{
			if (m_Children != null)
			{
				m_Children.listChanged -= ChildrenChanged;
			}
			m_Children = new ObservableList<AccessibilityNode>(value);
			ChildrenChanged();
			m_Children.listChanged += ChildrenChanged;
		}
	}

	public IReadOnlyList<AccessibilityNode> children => m_Children;

	internal IList<AccessibilityAction> actions
	{
		get
		{
			return m_Actions;
		}
		set
		{
			if (m_Actions != null)
			{
				m_Actions.listChanged -= ActionsChanged;
			}
			m_Actions = new ObservableList<AccessibilityAction>(value);
			ActionsChanged();
			m_Actions.listChanged += ActionsChanged;
		}
	}

	public Rect frame
	{
		get
		{
			if (m_Frame == default(Rect))
			{
				CalculateFrame();
			}
			return m_Frame;
		}
		set
		{
			SetFrame(value);
		}
	}

	public Func<Rect> frameGetter
	{
		get
		{
			return m_FrameGetter;
		}
		set
		{
			if (m_FrameGetter != value)
			{
				m_FrameGetter = value;
				if (IsInActiveHierarchy())
				{
					AccessibilityNodeManager.SetFrame(id, frame);
				}
			}
		}
	}

	internal SystemLanguage language
	{
		get
		{
			return m_Language;
		}
		set
		{
			if (m_Language != value)
			{
				m_Language = value;
				if (IsInActiveHierarchy())
				{
					AccessibilityNodeManager.SetLanguage(id, value);
				}
			}
		}
	}

	public bool isFocused => IsInActiveHierarchy() && AccessibilityNodeManager.GetIsFocused(id);

	public event Action<AccessibilityNode, bool> focusChanged;

	public event Func<bool> selected;

	public event Action incremented;

	public event Action decremented;

	public event Func<bool> dismissed;

	internal AccessibilityNode(int id, AccessibilityHierarchy hierarchy)
	{
		this.id = id;
		m_Hierarchy = hierarchy;
		m_Children = new ObservableList<AccessibilityNode>();
		m_Actions = new ObservableList<AccessibilityAction>();
		if (IsInActiveHierarchy())
		{
			AccessibilityNodeData nodeData = new AccessibilityNodeData
			{
				id = id,
				isActive = isActive,
				parentId = -1
			};
			CreateNativeNodeWithData(ref nodeData);
			m_Actions.listChanged += ActionsChanged;
			m_Children.listChanged += ChildrenChanged;
		}
	}

	private void CreateNativeNodeWithData(ref AccessibilityNodeData nodeData)
	{
		if (AccessibilityManager.isSupportedPlatform)
		{
			while (!AccessibilityNodeManager.CreateNativeNodeWithData(nodeData))
			{
				Debug.LogWarning($"AccessibilityNode.CreateNativeNodeWithData: id '{nodeData.id}' is already used");
				nodeData.id++;
			}
		}
		id = nodeData.id;
	}

	internal void AllocateNative()
	{
		if (!IsInActiveHierarchy())
		{
			return;
		}
		AccessibilityNodeData nodeData = new AccessibilityNodeData
		{
			id = id,
			label = label,
			value = value,
			hint = hint,
			isActive = isActive,
			role = role,
			allowsDirectInteraction = allowsDirectInteraction,
			state = state,
			parentId = (parent?.id ?? (-1)),
			frame = frame,
			language = language,
			implementsSelected = (this.selected != null),
			implementsDismissed = (this.dismissed != null)
		};
		CreateNativeNodeWithData(ref nodeData);
		ActionsChanged();
		m_Actions.listChanged += ActionsChanged;
		foreach (AccessibilityNode child in m_Children)
		{
			child.AllocateNative();
		}
		ChildrenChanged();
		m_Children.listChanged += ChildrenChanged;
	}

	internal void FreeNative(bool freeChildren)
	{
		if (freeChildren)
		{
			foreach (AccessibilityNode child in m_Children)
			{
				child.FreeNative(freeChildren: true);
			}
		}
		m_Children.listChanged -= ChildrenChanged;
		m_Actions.listChanged -= ActionsChanged;
		if (IsInActiveHierarchy())
		{
			int parentId = parent?.id ?? (-1);
			AccessibilityNodeManager.DestroyNativeNode(id, parentId);
		}
	}

	internal void SetParent(AccessibilityNode parent, int index = -1)
	{
		m_Parent = parent;
		if (IsInActiveHierarchy())
		{
			int parentId = parent?.id ?? (-1);
			AccessibilityNodeManager.SetParent(id, parentId, index);
		}
	}

	private void SetFrame(Rect frame)
	{
		if (!(m_Frame == frame))
		{
			m_Frame = frame;
			if (IsInActiveHierarchy())
			{
				AccessibilityNodeManager.SetFrame(id, frame);
			}
		}
	}

	internal void CalculateFrame()
	{
		SetFrame(frameGetter?.Invoke() ?? Rect.zero);
	}

	internal void GetNodeData(ref AccessibilityNodeData nodeData)
	{
		nodeData.id = id;
		nodeData.isActive = isActive;
		nodeData.label = label;
		nodeData.value = value;
		nodeData.hint = hint;
		nodeData.role = role;
		nodeData.allowsDirectInteraction = allowsDirectInteraction;
		nodeData.state = state;
		nodeData.frame = frame;
		nodeData.parentId = parent?.id ?? (-1);
		int[] array = new int[m_Children.Count];
		for (int i = 0; i < m_Children.Count; i++)
		{
			array[i] = m_Children[i].id;
		}
		nodeData.childIds = array;
		nodeData.language = language;
		nodeData.implementsSelected = this.selected != null;
		nodeData.implementsDismissed = this.dismissed != null;
	}

	internal void Destroy(bool destroyChildren)
	{
		FreeNative(destroyChildren);
		parent?.childList.Remove(this);
		if (destroyChildren)
		{
			for (int num = childList.Count - 1; num >= 0; num--)
			{
				childList[num].Destroy(destroyChildren: true);
			}
		}
		else
		{
			foreach (AccessibilityNode child in childList)
			{
				child.SetParent(parent);
				parent?.childList.Add(child);
			}
		}
		childList.Clear();
		m_Hierarchy = null;
	}

	public override int GetHashCode()
	{
		return id;
	}

	public override string ToString()
	{
		return $"AccessibilityNode(ID: {id}, Label: {label})";
	}

	private void ChildrenChanged()
	{
		if (IsInActiveHierarchy())
		{
			int[] array = new int[m_Children.Count];
			for (int i = 0; i < m_Children.Count; i++)
			{
				array[i] = m_Children[i].id;
			}
			AccessibilityNodeManager.SetChildren(id, array);
		}
	}

	private void ActionsChanged()
	{
		if (IsInActiveHierarchy())
		{
			AccessibilityAction[] array = new AccessibilityAction[m_Actions.Count];
			for (int i = 0; i < m_Actions.Count; i++)
			{
				array[i] = m_Actions[i];
			}
			AccessibilityNodeManager.SetActions(id, array);
		}
	}

	private bool IsInActiveHierarchy()
	{
		return m_Hierarchy != null && AssistiveSupport.activeHierarchy == m_Hierarchy;
	}

	internal void NotifyFocusChanged(bool isNodeFocused)
	{
		AccessibilityManager.QueueNotification(new AccessibilityManager.NotificationContext
		{
			notification = (isNodeFocused ? AccessibilityNotification.ElementFocused : AccessibilityNotification.ElementUnfocused),
			currentNode = this
		});
	}

	internal void InvokeFocusChanged(bool isNodeFocused)
	{
		this.focusChanged?.Invoke(this, isNodeFocused);
	}

	internal bool InvokeSelected()
	{
		return this.selected?.Invoke() ?? false;
	}

	internal void InvokeIncremented()
	{
		this.incremented?.Invoke();
	}

	internal void InvokeDecremented()
	{
		this.decremented?.Invoke();
	}

	internal bool Dismissed()
	{
		return this.dismissed?.Invoke() ?? false;
	}
}
