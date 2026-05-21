using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace Unity.Hierarchy;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/HierarchyCore/Public/HierarchyViewModel.h")]
[NativeHeader("Modules/HierarchyCore/HierarchyViewModelBindings.h")]
[RequiredByNativeCode(GenerateProxy = true)]
public sealed class HierarchyViewModel : IDisposable
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(HierarchyViewModel viewModel)
		{
			return viewModel.m_Ptr;
		}
	}

	public struct Enumerator
	{
		private readonly HierarchyViewModel m_ViewModel;

		private readonly HierarchyFlattened m_HierarchyFlattened;

		private unsafe readonly int* m_NodesPtr;

		private readonly int m_NodesCount;

		private readonly int m_Version;

		private int m_Index;

		public unsafe ref readonly HierarchyNode Current
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (m_Version != m_ViewModel.m_Version)
				{
					throw new InvalidOperationException("HierarchyViewModel was modified.");
				}
				return ref HierarchyFlattenedNode.GetNodeByRef(in m_HierarchyFlattened[m_NodesPtr[m_Index]]);
			}
		}

		internal unsafe Enumerator(HierarchyViewModel hierarchyViewModel)
		{
			m_ViewModel = hierarchyViewModel;
			m_HierarchyFlattened = hierarchyViewModel.HierarchyFlattened;
			m_NodesPtr = (int*)(void*)hierarchyViewModel.m_NodesPtr;
			m_NodesCount = hierarchyViewModel.Count;
			m_Version = hierarchyViewModel.Version;
			m_Index = -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool MoveNext()
		{
			return ++m_Index < m_NodesCount;
		}
	}

	private IntPtr m_Ptr;

	private readonly Hierarchy m_Hierarchy;

	private readonly HierarchyFlattened m_HierarchyFlattened;

	private IntPtr m_NodesPtr;

	private int m_NodesCount;

	private int m_Version;

	private readonly bool m_IsOwner;

	public bool IsCreated => m_Ptr != IntPtr.Zero;

	public int Count => m_NodesCount;

	public bool Updating
	{
		[NativeMethod("Updating", IsThreadSafe = true)]
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_Updating_Injected(intPtr);
		}
	}

	public bool UpdateNeeded
	{
		[NativeMethod("UpdateNeeded", IsThreadSafe = true)]
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_UpdateNeeded_Injected(intPtr);
		}
	}

	public HierarchyFlattened HierarchyFlattened => m_HierarchyFlattened;

	public Hierarchy Hierarchy => m_Hierarchy;

	internal unsafe int* NodesPtr => (int*)(void*)m_NodesPtr;

	internal int Version
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[VisibleToOtherModules(new string[] { "UnityEngine.HierarchyModule" })]
		get
		{
			return m_Version;
		}
	}

	internal float UpdateProgress
	{
		[VisibleToOtherModules(new string[] { "UnityEngine.HierarchyModule" })]
		[NativeMethod("UpdateProgress", IsThreadSafe = true)]
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_UpdateProgress_Injected(intPtr);
		}
	}

	internal IHierarchySearchQueryParser QueryParser
	{
		[VisibleToOtherModules(new string[] { "UnityEditor.HierarchyModule" })]
		get;
		[VisibleToOtherModules(new string[] { "UnityEditor.HierarchyModule" })]
		set;
	}

	internal HierarchySearchQueryDescriptor Query
	{
		[NativeMethod(IsThreadSafe = true)]
		[VisibleToOtherModules(new string[] { "UnityEngine.HierarchyModule" })]
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_Query_Injected(intPtr);
		}
		[VisibleToOtherModules(new string[] { "UnityEngine.HierarchyModule" })]
		[NativeMethod(IsThreadSafe = true)]
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_Query_Injected(intPtr, value);
		}
	}

	public unsafe ref readonly HierarchyNode this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0 || index >= m_NodesCount)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ref HierarchyFlattenedNode.GetNodeByRef(in m_HierarchyFlattened[((int*)(void*)m_NodesPtr)[index]]);
		}
	}

	public HierarchyViewModel(HierarchyFlattened hierarchyFlattened, HierarchyNodeFlags defaultFlags = HierarchyNodeFlags.None)
	{
		m_Ptr = Create(GCHandle.ToIntPtr(GCHandle.Alloc(this)), hierarchyFlattened, defaultFlags, out var nodesPtr, out var nodesCount, out var version);
		m_Hierarchy = hierarchyFlattened.Hierarchy;
		m_HierarchyFlattened = hierarchyFlattened;
		m_NodesPtr = nodesPtr;
		m_NodesCount = nodesCount;
		m_Version = version;
		m_IsOwner = true;
		QueryParser = new DefaultHierarchySearchQueryParser();
	}

	private HierarchyViewModel(IntPtr nativePtr, HierarchyFlattened hierarchyFlattened, IntPtr nodesPtr, int nodesCount, int version)
	{
		m_Ptr = nativePtr;
		m_Hierarchy = hierarchyFlattened.Hierarchy;
		m_HierarchyFlattened = hierarchyFlattened;
		m_NodesPtr = nodesPtr;
		m_NodesCount = nodesCount;
		m_Version = version;
		m_IsOwner = false;
		QueryParser = new DefaultHierarchySearchQueryParser();
	}

	~HierarchyViewModel()
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

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public int IndexOf(in HierarchyNode node)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return IndexOf_Injected(intPtr, in node);
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public bool Contains(in HierarchyNode node)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Contains_Injected(intPtr, in node);
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public HierarchyNode GetParent(in HierarchyNode node)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetParent_Injected(intPtr, in node, out var ret);
		return ret;
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public HierarchyNode GetNextSibling(in HierarchyNode node)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetNextSibling_Injected(intPtr, in node, out var ret);
		return ret;
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public int GetChildrenCount(in HierarchyNode node)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetChildrenCount_Injected(intPtr, in node);
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public int GetChildrenCountRecursive(in HierarchyNode node)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetChildrenCountRecursive_Injected(intPtr, in node);
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public int GetDepth(in HierarchyNode node)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetDepth_Injected(intPtr, in node);
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public HierarchyNodeFlags GetFlags(in HierarchyNode node)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetFlags_Injected(intPtr, in node);
	}

	public void SetFlags(HierarchyNodeFlags flags)
	{
		SetFlagsAll(flags);
	}

	public void SetFlags(in HierarchyNode node, HierarchyNodeFlags flags, bool recurse = false)
	{
		SetFlagsNode(in node, flags, recurse);
	}

	public int SetFlags(ReadOnlySpan<HierarchyNode> nodes, HierarchyNodeFlags flags)
	{
		return SetFlagsNodes(nodes, flags);
	}

	public int SetFlags(ReadOnlySpan<int> indices, HierarchyNodeFlags flags)
	{
		return SetFlagsIndices(indices, flags);
	}

	public bool HasAllFlags(HierarchyNodeFlags flags)
	{
		return HasAllFlagsAny(flags);
	}

	public bool HasAnyFlags(HierarchyNodeFlags flags)
	{
		return HasAnyFlagsAny(flags);
	}

	public bool HasAllFlags(in HierarchyNode node, HierarchyNodeFlags flags)
	{
		return HasAllFlagsNode(in node, flags);
	}

	public bool HasAnyFlags(in HierarchyNode node, HierarchyNodeFlags flags)
	{
		return HasAnyFlagsNode(in node, flags);
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public int HasAllFlagsCount(HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasAllFlagsCount_Injected(intPtr, flags);
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public int HasAnyFlagsCount(HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasAnyFlagsCount_Injected(intPtr, flags);
	}

	public bool DoesNotHaveAllFlags(HierarchyNodeFlags flags)
	{
		return DoesNotHaveAllFlagsAny(flags);
	}

	public bool DoesNotHaveAnyFlags(HierarchyNodeFlags flags)
	{
		return DoesNotHaveAnyFlagsAny(flags);
	}

	public bool DoesNotHaveAllFlags(in HierarchyNode node, HierarchyNodeFlags flags)
	{
		return DoesNotHaveAllFlagsNode(in node, flags);
	}

	public bool DoesNotHaveAnyFlags(in HierarchyNode node, HierarchyNodeFlags flags)
	{
		return DoesNotHaveAnyFlagsNode(in node, flags);
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public int DoesNotHaveAllFlagsCount(HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return DoesNotHaveAllFlagsCount_Injected(intPtr, flags);
	}

	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	public int DoesNotHaveAnyFlagsCount(HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return DoesNotHaveAnyFlagsCount_Injected(intPtr, flags);
	}

	public void ClearFlags(HierarchyNodeFlags flags)
	{
		ClearFlagsAll(flags);
	}

	public void ClearFlags(in HierarchyNode node, HierarchyNodeFlags flags, bool recurse = false)
	{
		ClearFlagsNode(in node, flags, recurse);
	}

	public int ClearFlags(ReadOnlySpan<HierarchyNode> nodes, HierarchyNodeFlags flags)
	{
		return ClearFlagsNodes(nodes, flags);
	}

	public int ClearFlags(ReadOnlySpan<int> indices, HierarchyNodeFlags flags)
	{
		return ClearFlagsIndices(indices, flags);
	}

	public void ToggleFlags(HierarchyNodeFlags flags)
	{
		ToggleFlagsAll(flags);
	}

	public void ToggleFlags(in HierarchyNode node, HierarchyNodeFlags flags, bool recurse = false)
	{
		ToggleFlagsNode(in node, flags, recurse);
	}

	public int ToggleFlags(ReadOnlySpan<HierarchyNode> nodes, HierarchyNodeFlags flags)
	{
		return ToggleFlagsNodes(nodes, flags);
	}

	public int ToggleFlags(ReadOnlySpan<int> indices, HierarchyNodeFlags flags)
	{
		return ToggleFlagsIndices(indices, flags);
	}

	public int GetNodesWithAllFlags(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
	{
		return GetNodesWithAllFlagsSpan(flags, outNodes);
	}

	public int GetNodesWithAnyFlags(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
	{
		return GetNodesWithAnyFlagsSpan(flags, outNodes);
	}

	public HierarchyNode[] GetNodesWithAllFlags(HierarchyNodeFlags flags)
	{
		int num = HasAllFlagsCount(flags);
		if (num == 0)
		{
			return Array.Empty<HierarchyNode>();
		}
		HierarchyNode[] array = new HierarchyNode[num];
		GetNodesWithAllFlagsSpan(flags, array);
		return array;
	}

	public HierarchyNode[] GetNodesWithAnyFlags(HierarchyNodeFlags flags)
	{
		int num = HasAnyFlagsCount(flags);
		if (num == 0)
		{
			return Array.Empty<HierarchyNode>();
		}
		HierarchyNode[] array = new HierarchyNode[num];
		GetNodesWithAnyFlagsSpan(flags, array);
		return array;
	}

	public HierarchyViewNodesEnumerable EnumerateNodesWithAllFlags(HierarchyNodeFlags flags)
	{
		return new HierarchyViewNodesEnumerable(this, flags, HasAllFlags);
	}

	public HierarchyViewNodesEnumerable EnumerateNodesWithAnyFlags(HierarchyNodeFlags flags)
	{
		return new HierarchyViewNodesEnumerable(this, flags, HasAnyFlags);
	}

	public int GetIndicesWithAllFlags(HierarchyNodeFlags flags, Span<int> outIndices)
	{
		return GetIndicesWithAllFlagsSpan(flags, outIndices);
	}

	public int GetIndicesWithAnyFlags(HierarchyNodeFlags flags, Span<int> outIndices)
	{
		return GetIndicesWithAnyFlagsSpan(flags, outIndices);
	}

	public int[] GetIndicesWithAllFlags(HierarchyNodeFlags flags)
	{
		int num = HasAllFlagsCount(flags);
		if (num == 0)
		{
			return Array.Empty<int>();
		}
		int[] array = new int[num];
		GetIndicesWithAllFlagsSpan(flags, array);
		return array;
	}

	public int[] GetIndicesWithAnyFlags(HierarchyNodeFlags flags)
	{
		int num = HasAnyFlagsCount(flags);
		if (num == 0)
		{
			return Array.Empty<int>();
		}
		int[] array = new int[num];
		GetIndicesWithAnyFlagsSpan(flags, array);
		return array;
	}

	public int GetNodesWithoutAllFlags(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
	{
		return GetNodesWithoutAllFlagsSpan(flags, outNodes);
	}

	public int GetNodesWithoutAnyFlags(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
	{
		return GetNodesWithoutAnyFlagsSpan(flags, outNodes);
	}

	public HierarchyNode[] GetNodesWithoutAllFlags(HierarchyNodeFlags flags)
	{
		int num = DoesNotHaveAllFlagsCount(flags);
		if (num == 0)
		{
			return Array.Empty<HierarchyNode>();
		}
		HierarchyNode[] array = new HierarchyNode[num];
		GetNodesWithoutAllFlagsSpan(flags, array);
		return array;
	}

	public HierarchyNode[] GetNodesWithoutAnyFlags(HierarchyNodeFlags flags)
	{
		int num = DoesNotHaveAnyFlagsCount(flags);
		if (num == 0)
		{
			return Array.Empty<HierarchyNode>();
		}
		HierarchyNode[] array = new HierarchyNode[num];
		GetNodesWithoutAnyFlagsSpan(flags, array);
		return array;
	}

	public HierarchyViewNodesEnumerable EnumerateNodesWithoutAllFlags(HierarchyNodeFlags flags)
	{
		return new HierarchyViewNodesEnumerable(this, flags, DoesNotHaveAllFlags);
	}

	public HierarchyViewNodesEnumerable EnumerateNodesWithoutAnyFlags(HierarchyNodeFlags flags)
	{
		return new HierarchyViewNodesEnumerable(this, flags, DoesNotHaveAnyFlags);
	}

	public int GetIndicesWithoutAllFlags(HierarchyNodeFlags flags, Span<int> outIndices)
	{
		return GetIndicesWithoutAllFlagsSpan(flags, outIndices);
	}

	public int GetIndicesWithoutAnyFlags(HierarchyNodeFlags flags, Span<int> outIndices)
	{
		return GetIndicesWithoutAnyFlagsSpan(flags, outIndices);
	}

	public int[] GetIndicesWithoutAllFlags(HierarchyNodeFlags flags)
	{
		int num = DoesNotHaveAllFlagsCount(flags);
		if (num == 0)
		{
			return Array.Empty<int>();
		}
		int[] array = new int[num];
		GetIndicesWithoutAllFlagsSpan(flags, array);
		return array;
	}

	public int[] GetIndicesWithoutAnyFlags(HierarchyNodeFlags flags)
	{
		int num = DoesNotHaveAnyFlagsCount(flags);
		if (num == 0)
		{
			return Array.Empty<int>();
		}
		int[] array = new int[num];
		GetIndicesWithoutAnyFlagsSpan(flags, array);
		return array;
	}

	public void SetQuery(string query)
	{
		HierarchySearchQueryDescriptor hierarchySearchQueryDescriptor = QueryParser.ParseQuery(query);
		if (hierarchySearchQueryDescriptor != Query)
		{
			Query = hierarchySearchQueryDescriptor;
		}
	}

	[NativeMethod(IsThreadSafe = true)]
	public void Update()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Update_Injected(intPtr);
	}

	[NativeMethod(IsThreadSafe = true)]
	public bool UpdateIncremental()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return UpdateIncremental_Injected(intPtr);
	}

	[NativeMethod(IsThreadSafe = true)]
	public bool UpdateIncrementalTimed(double milliseconds)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return UpdateIncrementalTimed_Injected(intPtr, milliseconds);
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static HierarchyViewModel FromIntPtr(IntPtr handlePtr)
	{
		return (handlePtr != IntPtr.Zero) ? ((HierarchyViewModel)GCHandle.FromIntPtr(handlePtr).Target) : null;
	}

	[FreeFunction("HierarchyViewModelBindings::Create", IsThreadSafe = true)]
	private static IntPtr Create(IntPtr handlePtr, HierarchyFlattened hierarchyFlattened, HierarchyNodeFlags defaultFlags, out IntPtr nodesPtr, out int nodesCount, out int version)
	{
		return Create_Injected(handlePtr, (hierarchyFlattened == null) ? ((IntPtr)0) : HierarchyFlattened.BindingsMarshaller.ConvertToNative(hierarchyFlattened), defaultFlags, out nodesPtr, out nodesCount, out version);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("HierarchyViewModelBindings::Destroy", IsThreadSafe = true)]
	private static extern void Destroy(IntPtr nativePtr);

	[FreeFunction("HierarchyViewModelBindings::SetFlagsAll", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private void SetFlagsAll(HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetFlagsAll_Injected(intPtr, flags);
	}

	[FreeFunction("HierarchyViewModelBindings::SetFlagsNode", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private void SetFlagsNode(in HierarchyNode node, HierarchyNodeFlags flags, bool recurse = false)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetFlagsNode_Injected(intPtr, in node, flags, recurse);
	}

	[FreeFunction("HierarchyViewModelBindings::SetFlagsNodes", HasExplicitThis = true, IsThreadSafe = true)]
	private unsafe int SetFlagsNodes(ReadOnlySpan<HierarchyNode> nodes, HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ReadOnlySpan<HierarchyNode> readOnlySpan = nodes;
		int result;
		fixed (HierarchyNode* begin = readOnlySpan)
		{
			ManagedSpanWrapper nodes2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
			result = SetFlagsNodes_Injected(intPtr, ref nodes2, flags);
		}
		return result;
	}

	[FreeFunction("HierarchyViewModelBindings::SetFlagsIndices", HasExplicitThis = true, IsThreadSafe = true)]
	private unsafe int SetFlagsIndices(ReadOnlySpan<int> indices, HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ReadOnlySpan<int> readOnlySpan = indices;
		int result;
		fixed (int* begin = readOnlySpan)
		{
			ManagedSpanWrapper indices2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
			result = SetFlagsIndices_Injected(intPtr, ref indices2, flags);
		}
		return result;
	}

	[FreeFunction("HierarchyViewModelBindings::HasAllFlagsAny", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private bool HasAllFlagsAny(HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasAllFlagsAny_Injected(intPtr, flags);
	}

	[FreeFunction("HierarchyViewModelBindings::HasAnyFlagsAny", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private bool HasAnyFlagsAny(HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasAnyFlagsAny_Injected(intPtr, flags);
	}

	[FreeFunction("HierarchyViewModelBindings::HasAllFlagsNode", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private bool HasAllFlagsNode(in HierarchyNode node, HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasAllFlagsNode_Injected(intPtr, in node, flags);
	}

	[FreeFunction("HierarchyViewModelBindings::HasAnyFlagsNode", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private bool HasAnyFlagsNode(in HierarchyNode node, HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasAnyFlagsNode_Injected(intPtr, in node, flags);
	}

	[FreeFunction("HierarchyViewModelBindings::DoesNotHaveAllFlagsAny", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private bool DoesNotHaveAllFlagsAny(HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return DoesNotHaveAllFlagsAny_Injected(intPtr, flags);
	}

	[FreeFunction("HierarchyViewModelBindings::DoesNotHaveAnyFlagsAny", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private bool DoesNotHaveAnyFlagsAny(HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return DoesNotHaveAnyFlagsAny_Injected(intPtr, flags);
	}

	[FreeFunction("HierarchyViewModelBindings::DoesNotHaveAllFlagsNode", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private bool DoesNotHaveAllFlagsNode(in HierarchyNode node, HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return DoesNotHaveAllFlagsNode_Injected(intPtr, in node, flags);
	}

	[FreeFunction("HierarchyViewModelBindings::DoesNotHaveAnyFlagsNode", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private bool DoesNotHaveAnyFlagsNode(in HierarchyNode node, HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return DoesNotHaveAnyFlagsNode_Injected(intPtr, in node, flags);
	}

	[FreeFunction("HierarchyViewModelBindings::ClearFlagsAll", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private void ClearFlagsAll(HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ClearFlagsAll_Injected(intPtr, flags);
	}

	[FreeFunction("HierarchyViewModelBindings::ClearFlagsNode", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private void ClearFlagsNode(in HierarchyNode node, HierarchyNodeFlags flags, bool recurse = false)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ClearFlagsNode_Injected(intPtr, in node, flags, recurse);
	}

	[FreeFunction("HierarchyViewModelBindings::ClearFlagsNodes", HasExplicitThis = true, IsThreadSafe = true)]
	private unsafe int ClearFlagsNodes(ReadOnlySpan<HierarchyNode> nodes, HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ReadOnlySpan<HierarchyNode> readOnlySpan = nodes;
		int result;
		fixed (HierarchyNode* begin = readOnlySpan)
		{
			ManagedSpanWrapper nodes2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
			result = ClearFlagsNodes_Injected(intPtr, ref nodes2, flags);
		}
		return result;
	}

	[FreeFunction("HierarchyViewModelBindings::ClearFlagsIndices", HasExplicitThis = true, IsThreadSafe = true)]
	private unsafe int ClearFlagsIndices(ReadOnlySpan<int> indices, HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ReadOnlySpan<int> readOnlySpan = indices;
		int result;
		fixed (int* begin = readOnlySpan)
		{
			ManagedSpanWrapper indices2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
			result = ClearFlagsIndices_Injected(intPtr, ref indices2, flags);
		}
		return result;
	}

	[FreeFunction("HierarchyViewModelBindings::ToggleFlagsAll", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private void ToggleFlagsAll(HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ToggleFlagsAll_Injected(intPtr, flags);
	}

	[FreeFunction("HierarchyViewModelBindings::ToggleFlagsNode", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private void ToggleFlagsNode(in HierarchyNode node, HierarchyNodeFlags flags, bool recurse = false)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ToggleFlagsNode_Injected(intPtr, in node, flags, recurse);
	}

	[FreeFunction("HierarchyViewModelBindings::ToggleFlagsNodes", HasExplicitThis = true, IsThreadSafe = true)]
	private unsafe int ToggleFlagsNodes(ReadOnlySpan<HierarchyNode> nodes, HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ReadOnlySpan<HierarchyNode> readOnlySpan = nodes;
		int result;
		fixed (HierarchyNode* begin = readOnlySpan)
		{
			ManagedSpanWrapper nodes2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
			result = ToggleFlagsNodes_Injected(intPtr, ref nodes2, flags);
		}
		return result;
	}

	[FreeFunction("HierarchyViewModelBindings::ToggleFlagsIndices", HasExplicitThis = true, IsThreadSafe = true)]
	private unsafe int ToggleFlagsIndices(ReadOnlySpan<int> indices, HierarchyNodeFlags flags)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ReadOnlySpan<int> readOnlySpan = indices;
		int result;
		fixed (int* begin = readOnlySpan)
		{
			ManagedSpanWrapper indices2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
			result = ToggleFlagsIndices_Injected(intPtr, ref indices2, flags);
		}
		return result;
	}

	[FreeFunction("HierarchyViewModelBindings::GetNodesWithAllFlagsSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private unsafe int GetNodesWithAllFlagsSpan(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Span<HierarchyNode> span = outNodes;
		int nodesWithAllFlagsSpan_Injected;
		fixed (HierarchyNode* begin = span)
		{
			ManagedSpanWrapper outNodes2 = new ManagedSpanWrapper(begin, span.Length);
			nodesWithAllFlagsSpan_Injected = GetNodesWithAllFlagsSpan_Injected(intPtr, flags, ref outNodes2);
		}
		return nodesWithAllFlagsSpan_Injected;
	}

	[FreeFunction("HierarchyViewModelBindings::GetNodesWithAnyFlagsSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private unsafe int GetNodesWithAnyFlagsSpan(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Span<HierarchyNode> span = outNodes;
		int nodesWithAnyFlagsSpan_Injected;
		fixed (HierarchyNode* begin = span)
		{
			ManagedSpanWrapper outNodes2 = new ManagedSpanWrapper(begin, span.Length);
			nodesWithAnyFlagsSpan_Injected = GetNodesWithAnyFlagsSpan_Injected(intPtr, flags, ref outNodes2);
		}
		return nodesWithAnyFlagsSpan_Injected;
	}

	[FreeFunction("HierarchyViewModelBindings::GetIndicesWithAllFlagsSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private unsafe int GetIndicesWithAllFlagsSpan(HierarchyNodeFlags flags, Span<int> outIndices)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Span<int> span = outIndices;
		int indicesWithAllFlagsSpan_Injected;
		fixed (int* begin = span)
		{
			ManagedSpanWrapper outIndices2 = new ManagedSpanWrapper(begin, span.Length);
			indicesWithAllFlagsSpan_Injected = GetIndicesWithAllFlagsSpan_Injected(intPtr, flags, ref outIndices2);
		}
		return indicesWithAllFlagsSpan_Injected;
	}

	[FreeFunction("HierarchyViewModelBindings::GetIndicesWithAnyFlagsSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private unsafe int GetIndicesWithAnyFlagsSpan(HierarchyNodeFlags flags, Span<int> outIndices)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Span<int> span = outIndices;
		int indicesWithAnyFlagsSpan_Injected;
		fixed (int* begin = span)
		{
			ManagedSpanWrapper outIndices2 = new ManagedSpanWrapper(begin, span.Length);
			indicesWithAnyFlagsSpan_Injected = GetIndicesWithAnyFlagsSpan_Injected(intPtr, flags, ref outIndices2);
		}
		return indicesWithAnyFlagsSpan_Injected;
	}

	[FreeFunction("HierarchyViewModelBindings::GetNodesWithoutAllFlagsSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private unsafe int GetNodesWithoutAllFlagsSpan(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Span<HierarchyNode> span = outNodes;
		int nodesWithoutAllFlagsSpan_Injected;
		fixed (HierarchyNode* begin = span)
		{
			ManagedSpanWrapper outNodes2 = new ManagedSpanWrapper(begin, span.Length);
			nodesWithoutAllFlagsSpan_Injected = GetNodesWithoutAllFlagsSpan_Injected(intPtr, flags, ref outNodes2);
		}
		return nodesWithoutAllFlagsSpan_Injected;
	}

	[FreeFunction("HierarchyViewModelBindings::GetNodesWithoutAnyFlagsSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private unsafe int GetNodesWithoutAnyFlagsSpan(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Span<HierarchyNode> span = outNodes;
		int nodesWithoutAnyFlagsSpan_Injected;
		fixed (HierarchyNode* begin = span)
		{
			ManagedSpanWrapper outNodes2 = new ManagedSpanWrapper(begin, span.Length);
			nodesWithoutAnyFlagsSpan_Injected = GetNodesWithoutAnyFlagsSpan_Injected(intPtr, flags, ref outNodes2);
		}
		return nodesWithoutAnyFlagsSpan_Injected;
	}

	[FreeFunction("HierarchyViewModelBindings::GetIndicesWithoutAllFlagsSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private unsafe int GetIndicesWithoutAllFlagsSpan(HierarchyNodeFlags flags, Span<int> outIndices)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Span<int> span = outIndices;
		int indicesWithoutAllFlagsSpan_Injected;
		fixed (int* begin = span)
		{
			ManagedSpanWrapper outIndices2 = new ManagedSpanWrapper(begin, span.Length);
			indicesWithoutAllFlagsSpan_Injected = GetIndicesWithoutAllFlagsSpan_Injected(intPtr, flags, ref outIndices2);
		}
		return indicesWithoutAllFlagsSpan_Injected;
	}

	[FreeFunction("HierarchyViewModelBindings::GetIndicesWithoutAnyFlagsSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
	private unsafe int GetIndicesWithoutAnyFlagsSpan(HierarchyNodeFlags flags, Span<int> outIndices)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Span<int> span = outIndices;
		int indicesWithoutAnyFlagsSpan_Injected;
		fixed (int* begin = span)
		{
			ManagedSpanWrapper outIndices2 = new ManagedSpanWrapper(begin, span.Length);
			indicesWithoutAnyFlagsSpan_Injected = GetIndicesWithoutAnyFlagsSpan_Injected(intPtr, flags, ref outIndices2);
		}
		return indicesWithoutAnyFlagsSpan_Injected;
	}

	[RequiredByNativeCode]
	private static IntPtr CreateHierarchyViewModel(IntPtr nativePtr, IntPtr flattenedPtr, IntPtr nodesPtr, int nodesCount, int version)
	{
		return GCHandle.ToIntPtr(GCHandle.Alloc(new HierarchyViewModel(nativePtr, HierarchyFlattened.FromIntPtr(flattenedPtr), nodesPtr, nodesCount, version)));
	}

	[RequiredByNativeCode]
	private static void UpdateHierarchyViewModel(IntPtr handlePtr, IntPtr nodesPtr, int nodesCount, int version)
	{
		HierarchyViewModel hierarchyViewModel = FromIntPtr(handlePtr);
		hierarchyViewModel.m_NodesPtr = nodesPtr;
		hierarchyViewModel.m_NodesCount = nodesCount;
		hierarchyViewModel.m_Version = version;
	}

	[RequiredByNativeCode]
	private static void SearchBegin(IntPtr handlePtr)
	{
		HierarchyViewModel hierarchyViewModel = FromIntPtr(handlePtr);
		foreach (HierarchyNodeTypeHandlerBase item in hierarchyViewModel.m_Hierarchy.EnumerateNodeTypeHandlersBase())
		{
			item.Internal_SearchBegin(hierarchyViewModel.Query);
		}
	}

	[Obsolete("HasFlags is obsolete, please use HasAllFlags or HasAnyFlags instead", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool HasFlags(HierarchyNodeFlags flags)
	{
		return HasAllFlagsAny(flags);
	}

	[Obsolete("HasFlags is obsolete, please use HasAllFlags or HasAnyFlags instead", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool HasFlags(in HierarchyNode node, HierarchyNodeFlags flags)
	{
		return HasAllFlagsNode(in node, flags);
	}

	[Obsolete("HasFlagsCount is obsolete, please use HasAllFlagsCount or HasAnyFlagsCount instead", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int HasFlagsCount(HierarchyNodeFlags flags)
	{
		return HasAllFlagsCount(flags);
	}

	[Obsolete("DoesNotHaveFlags is obsolete, please use DoesNotHaveAllFlags or DoesNotHaveAnyFlags instead", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool DoesNotHaveFlags(HierarchyNodeFlags flags)
	{
		return DoesNotHaveAllFlagsAny(flags);
	}

	[Obsolete("DoesNotHaveFlags is obsolete, please use DoesNotHaveAllFlags or DoesNotHaveAnyFlags instead", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool DoesNotHaveFlags(in HierarchyNode node, HierarchyNodeFlags flags)
	{
		return DoesNotHaveAllFlagsNode(in node, flags);
	}

	[Obsolete("DoesNotHaveFlagsCount is obsolete, please use DoesNotHaveAllFlagsCount or DoesNotHaveAnyFlagsCount instead", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int DoesNotHaveFlagsCount(HierarchyNodeFlags flags)
	{
		return DoesNotHaveAllFlagsCount(flags);
	}

	[Obsolete("GetNodesWithFlags is obsolete, please use GetNodesWithAllFlags or GetNodesWithAnyFlags instead", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int GetNodesWithFlags(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
	{
		return GetNodesWithAllFlagsSpan(flags, outNodes);
	}

	[Obsolete("GetNodesWithFlags is obsolete, please use GetNodesWithAllFlags or GetNodesWithAnyFlags instead", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public HierarchyNode[] GetNodesWithFlags(HierarchyNodeFlags flags)
	{
		return GetNodesWithAllFlags(flags);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("EnumerateNodesWithFlags is obsolete, please use EnumerateNodesWithAllFlags or EnumerateNodesWithAnyFlags instead", false)]
	public HierarchyViewNodesEnumerable EnumerateNodesWithFlags(HierarchyNodeFlags flags)
	{
		return EnumerateNodesWithAllFlags(flags);
	}

	[Obsolete("GetIndicesWithFlags is obsolete, please use GetIndicesWithAllFlags or GetIndicesWithAnyFlags instead", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int GetIndicesWithFlags(HierarchyNodeFlags flags, Span<int> outIndices)
	{
		return GetIndicesWithAllFlagsSpan(flags, outIndices);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("GetIndicesWithFlags is obsolete, please use GetIndicesWithAllFlags or GetIndicesWithAnyFlags instead", false)]
	public int[] GetIndicesWithFlags(HierarchyNodeFlags flags)
	{
		return GetIndicesWithAllFlags(flags);
	}

	[Obsolete("GetNodesWithoutFlags is obsolete, please use GetNodesWithoutAllFlags or GetNodesWithoutAnyFlags instead", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int GetNodesWithoutFlags(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
	{
		return GetNodesWithoutAllFlagsSpan(flags, outNodes);
	}

	[Obsolete("GetNodesWithoutFlags is obsolete, please use GetNodesWithoutAllFlags or GetNodesWithoutAnyFlags instead", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public HierarchyNode[] GetNodesWithoutFlags(HierarchyNodeFlags flags)
	{
		return GetNodesWithoutAllFlags(flags);
	}

	[Obsolete("EnumerateNodesWithoutFlags is obsolete, please use EnumerateNodesWithoutAllFlags or EnumerateNodesWithoutAnyFlags instead", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public HierarchyViewNodesEnumerable EnumerateNodesWithoutFlags(HierarchyNodeFlags flags)
	{
		return EnumerateNodesWithoutAllFlags(flags);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("GetIndicesWithoutFlags is obsolete, please use GetIndicesWithoutAllFlags or GetIndicesWithoutAnyFlags instead", false)]
	public int GetIndicesWithoutFlags(HierarchyNodeFlags flags, Span<int> outIndices)
	{
		return GetIndicesWithoutAllFlagsSpan(flags, outIndices);
	}

	[Obsolete("GetIndicesWithoutFlags is obsolete, please use GetIndicesWithoutAllFlags or GetIndicesWithoutAnyFlags instead", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int[] GetIndicesWithoutFlags(HierarchyNodeFlags flags)
	{
		return GetIndicesWithoutAllFlags(flags);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_Updating_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_UpdateNeeded_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_UpdateProgress_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern HierarchySearchQueryDescriptor get_Query_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_Query_Injected(IntPtr _unity_self, HierarchySearchQueryDescriptor value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int IndexOf_Injected(IntPtr _unity_self, in HierarchyNode node);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool Contains_Injected(IntPtr _unity_self, in HierarchyNode node);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetParent_Injected(IntPtr _unity_self, in HierarchyNode node, out HierarchyNode ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetNextSibling_Injected(IntPtr _unity_self, in HierarchyNode node, out HierarchyNode ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetChildrenCount_Injected(IntPtr _unity_self, in HierarchyNode node);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetChildrenCountRecursive_Injected(IntPtr _unity_self, in HierarchyNode node);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetDepth_Injected(IntPtr _unity_self, in HierarchyNode node);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern HierarchyNodeFlags GetFlags_Injected(IntPtr _unity_self, in HierarchyNode node);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int HasAllFlagsCount_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int HasAnyFlagsCount_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int DoesNotHaveAllFlagsCount_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int DoesNotHaveAnyFlagsCount_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Update_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool UpdateIncremental_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool UpdateIncrementalTimed_Injected(IntPtr _unity_self, double milliseconds);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Create_Injected(IntPtr handlePtr, IntPtr hierarchyFlattened, HierarchyNodeFlags defaultFlags, out IntPtr nodesPtr, out int nodesCount, out int version);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetFlagsAll_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetFlagsNode_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags flags, bool recurse);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int SetFlagsNodes_Injected(IntPtr _unity_self, ref ManagedSpanWrapper nodes, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int SetFlagsIndices_Injected(IntPtr _unity_self, ref ManagedSpanWrapper indices, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasAllFlagsAny_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasAnyFlagsAny_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasAllFlagsNode_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasAnyFlagsNode_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool DoesNotHaveAllFlagsAny_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool DoesNotHaveAnyFlagsAny_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool DoesNotHaveAllFlagsNode_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool DoesNotHaveAnyFlagsNode_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ClearFlagsAll_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ClearFlagsNode_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags flags, bool recurse);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int ClearFlagsNodes_Injected(IntPtr _unity_self, ref ManagedSpanWrapper nodes, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int ClearFlagsIndices_Injected(IntPtr _unity_self, ref ManagedSpanWrapper indices, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ToggleFlagsAll_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ToggleFlagsNode_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags flags, bool recurse);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int ToggleFlagsNodes_Injected(IntPtr _unity_self, ref ManagedSpanWrapper nodes, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int ToggleFlagsIndices_Injected(IntPtr _unity_self, ref ManagedSpanWrapper indices, HierarchyNodeFlags flags);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetNodesWithAllFlagsSpan_Injected(IntPtr _unity_self, HierarchyNodeFlags flags, ref ManagedSpanWrapper outNodes);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetNodesWithAnyFlagsSpan_Injected(IntPtr _unity_self, HierarchyNodeFlags flags, ref ManagedSpanWrapper outNodes);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetIndicesWithAllFlagsSpan_Injected(IntPtr _unity_self, HierarchyNodeFlags flags, ref ManagedSpanWrapper outIndices);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetIndicesWithAnyFlagsSpan_Injected(IntPtr _unity_self, HierarchyNodeFlags flags, ref ManagedSpanWrapper outIndices);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetNodesWithoutAllFlagsSpan_Injected(IntPtr _unity_self, HierarchyNodeFlags flags, ref ManagedSpanWrapper outNodes);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetNodesWithoutAnyFlagsSpan_Injected(IntPtr _unity_self, HierarchyNodeFlags flags, ref ManagedSpanWrapper outNodes);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetIndicesWithoutAllFlagsSpan_Injected(IntPtr _unity_self, HierarchyNodeFlags flags, ref ManagedSpanWrapper outIndices);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetIndicesWithoutAnyFlagsSpan_Injected(IntPtr _unity_self, HierarchyNodeFlags flags, ref ManagedSpanWrapper outIndices);
}
