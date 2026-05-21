using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace Unity.Hierarchy;

[StructLayout(LayoutKind.Sequential)]
[RequiredByNativeCode(GenerateProxy = true)]
[NativeHeader("Modules/HierarchyCore/HierarchyCommandListBindings.h")]
[NativeHeader("Modules/HierarchyCore/Public/HierarchyCommandList.h")]
public sealed class HierarchyCommandList : IDisposable
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(HierarchyCommandList cmdList)
		{
			return cmdList.m_Ptr;
		}
	}

	private IntPtr m_Ptr;

	private readonly bool m_IsOwner;

	public bool IsCreated => m_Ptr != IntPtr.Zero;

	public int Size
	{
		[NativeMethod("Size", IsThreadSafe = true)]
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_Size_Injected(intPtr);
		}
	}

	public int Capacity
	{
		[NativeMethod("Capacity", IsThreadSafe = true)]
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_Capacity_Injected(intPtr);
		}
	}

	public bool IsEmpty
	{
		[NativeMethod("IsEmpty", IsThreadSafe = true)]
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_IsEmpty_Injected(intPtr);
		}
	}

	public bool IsExecuting
	{
		[NativeMethod("IsExecuting", IsThreadSafe = true)]
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_IsExecuting_Injected(intPtr);
		}
	}

	public HierarchyCommandList(Hierarchy hierarchy, int initialCapacity = 65536)
		: this(hierarchy, HierarchyNodeType.Null, initialCapacity)
	{
	}

	internal HierarchyCommandList(Hierarchy hierarchy, HierarchyNodeType nodeType, int initialCapacity = 65536)
	{
		m_Ptr = Create(GCHandle.ToIntPtr(GCHandle.Alloc(this)), hierarchy, nodeType, initialCapacity);
		m_IsOwner = true;
	}

	private HierarchyCommandList(IntPtr nativePtr)
	{
		m_Ptr = nativePtr;
		m_IsOwner = false;
	}

	~HierarchyCommandList()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	private void Dispose(bool disposing)
	{
		if (m_Ptr != IntPtr.Zero)
		{
			if (m_IsOwner)
			{
				Destroy(m_Ptr);
			}
			m_Ptr = IntPtr.Zero;
		}
	}

	[NativeMethod(IsThreadSafe = true)]
	public void Clear()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Clear_Injected(intPtr);
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public bool Reserve(int count)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Reserve_Injected(intPtr, count);
	}

	public bool Add(in HierarchyNode parent, out HierarchyNode node)
	{
		return AddNode(in parent, out node);
	}

	public bool Add(in HierarchyNode parent, int count, out HierarchyNode[] nodes)
	{
		nodes = new HierarchyNode[count];
		return AddNodeSpan(in parent, nodes);
	}

	public bool Add(in HierarchyNode parent, Span<HierarchyNode> outNodes)
	{
		return AddNodeSpan(in parent, outNodes);
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public bool Remove(in HierarchyNode node)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Remove_Injected(intPtr, in node);
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public bool RemoveChildren(in HierarchyNode node)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return RemoveChildren_Injected(intPtr, in node);
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public bool SetParent(in HierarchyNode node, in HierarchyNode parent)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return SetParent_Injected(intPtr, in node, in parent);
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public bool SetSortIndex(in HierarchyNode node, int sortIndex)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return SetSortIndex_Injected(intPtr, in node, sortIndex);
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public bool SortChildren(in HierarchyNode node, bool recurse = false)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return SortChildren_Injected(intPtr, in node, recurse);
	}

	public unsafe bool SetProperty<T>(in HierarchyPropertyUnmanaged<T> property, in HierarchyNode node, T value) where T : unmanaged
	{
		return SetNodePropertyRaw(in property.m_Property, in node, &value, sizeof(T));
	}

	public bool SetProperty(in HierarchyPropertyString property, in HierarchyNode node, string value)
	{
		return SetNodePropertyString(in property.m_Property, in node, value);
	}

	public bool ClearProperty<T>(in HierarchyPropertyUnmanaged<T> property, in HierarchyNode node) where T : unmanaged
	{
		return ClearNodeProperty(in property.m_Property, in node);
	}

	public bool ClearProperty(in HierarchyPropertyString property, in HierarchyNode node)
	{
		return ClearNodeProperty(in property.m_Property, in node);
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public unsafe bool SetName(in HierarchyNode node, string name)
	{
		//The blocks IL_003a are reachable both inside and outside the pinned region starting at IL_0029. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return SetName_Injected(intPtr, in node, ref managedSpanWrapper);
				}
			}
			return SetName_Injected(intPtr, in node, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public void Execute()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Execute_Injected(intPtr);
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public bool ExecuteIncremental()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return ExecuteIncremental_Injected(intPtr);
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public bool ExecuteIncrementalTimed(double milliseconds)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return ExecuteIncrementalTimed_Injected(intPtr, milliseconds);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static HierarchyCommandList FromIntPtr(IntPtr handlePtr)
	{
		return (handlePtr != IntPtr.Zero) ? ((HierarchyCommandList)GCHandle.FromIntPtr(handlePtr).Target) : null;
	}

	[FreeFunction("HierarchyCommandListBindings::Create", IsThreadSafe = true)]
	private static IntPtr Create(IntPtr handlePtr, Hierarchy hierarchy, HierarchyNodeType nodeType, int initialCapacity)
	{
		return Create_Injected(handlePtr, (hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy), ref nodeType, initialCapacity);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("HierarchyCommandListBindings::Destroy", IsThreadSafe = true)]
	private static extern void Destroy(IntPtr nativePtr);

	[FreeFunction("HierarchyCommandListBindings::AddNode", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private bool AddNode(in HierarchyNode parent, out HierarchyNode node)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return AddNode_Injected(intPtr, in parent, out node);
	}

	[FreeFunction("HierarchyCommandListBindings::AddNodeSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private unsafe bool AddNodeSpan(in HierarchyNode parent, Span<HierarchyNode> outNodes)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Span<HierarchyNode> span = outNodes;
		bool result;
		fixed (HierarchyNode* begin = span)
		{
			ManagedSpanWrapper outNodes2 = new ManagedSpanWrapper(begin, span.Length);
			result = AddNodeSpan_Injected(intPtr, in parent, ref outNodes2);
		}
		return result;
	}

	[FreeFunction("HierarchyCommandListBindings::SetNodePropertyRaw", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private unsafe bool SetNodePropertyRaw(in HierarchyPropertyId property, in HierarchyNode node, void* ptr, int size)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return SetNodePropertyRaw_Injected(intPtr, in property, in node, ptr, size);
	}

	[FreeFunction("HierarchyCommandListBindings::SetNodePropertyString", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private unsafe bool SetNodePropertyString(in HierarchyPropertyId property, in HierarchyNode node, string value)
	{
		//The blocks IL_003b are reachable both inside and outside the pinned region starting at IL_002a. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(value);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return SetNodePropertyString_Injected(intPtr, in property, in node, ref managedSpanWrapper);
				}
			}
			return SetNodePropertyString_Injected(intPtr, in property, in node, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[FreeFunction("HierarchyCommandListBindings::ClearNodeProperty", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private bool ClearNodeProperty(in HierarchyPropertyId property, in HierarchyNode node)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return ClearNodeProperty_Injected(intPtr, in property, in node);
	}

	[RequiredByNativeCode]
	private static IntPtr CreateCommandList(IntPtr nativePtr)
	{
		return GCHandle.ToIntPtr(GCHandle.Alloc(new HierarchyCommandList(nativePtr)));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_Size_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_Capacity_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_IsEmpty_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_IsExecuting_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Clear_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool Reserve_Injected(IntPtr _unity_self, int count);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool Remove_Injected(IntPtr _unity_self, in HierarchyNode node);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool RemoveChildren_Injected(IntPtr _unity_self, in HierarchyNode node);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool SetParent_Injected(IntPtr _unity_self, in HierarchyNode node, in HierarchyNode parent);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool SetSortIndex_Injected(IntPtr _unity_self, in HierarchyNode node, int sortIndex);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool SortChildren_Injected(IntPtr _unity_self, in HierarchyNode node, bool recurse);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool SetName_Injected(IntPtr _unity_self, in HierarchyNode node, ref ManagedSpanWrapper name);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Execute_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool ExecuteIncremental_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool ExecuteIncrementalTimed_Injected(IntPtr _unity_self, double milliseconds);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Create_Injected(IntPtr handlePtr, IntPtr hierarchy, [In] ref HierarchyNodeType nodeType, int initialCapacity);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool AddNode_Injected(IntPtr _unity_self, in HierarchyNode parent, out HierarchyNode node);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool AddNodeSpan_Injected(IntPtr _unity_self, in HierarchyNode parent, ref ManagedSpanWrapper outNodes);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern bool SetNodePropertyRaw_Injected(IntPtr _unity_self, in HierarchyPropertyId property, in HierarchyNode node, void* ptr, int size);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool SetNodePropertyString_Injected(IntPtr _unity_self, in HierarchyPropertyId property, in HierarchyNode node, ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool ClearNodeProperty_Injected(IntPtr _unity_self, in HierarchyPropertyId property, in HierarchyNode node);
}
