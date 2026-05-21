using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;

namespace Unity.Hierarchy;

[NativeHeader("Modules/HierarchyCore/HierarchyTestsHelper.h")]
internal static class HierarchyTestsHelper
{
	[NativeHeader("Modules/HierarchyCore/HierarchyTestsHelper.h")]
	internal enum SortOrder
	{
		Ascending,
		Descending
	}

	internal delegate void ForEachDelegate(in HierarchyNode node, int index);

	[NativeMethod(IsThreadSafe = true)]
	internal static int GenerateNodesTree(Hierarchy hierarchy, in HierarchyNode root, int width, int depth, int maxCount = 0)
	{
		return GenerateNodesTree_Injected((hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy), in root, width, depth, maxCount);
	}

	[NativeMethod(IsThreadSafe = true)]
	internal static void GenerateNodesCount(Hierarchy hierarchy, in HierarchyNode root, int count, int width, int depth)
	{
		GenerateNodesCount_Injected((hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy), in root, count, width, depth);
	}

	[NativeMethod(IsThreadSafe = true)]
	internal static void GenerateSortIndex(Hierarchy hierarchy, in HierarchyNode root, SortOrder order)
	{
		GenerateSortIndex_Injected((hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy), in root, order);
	}

	internal unsafe static void ForEach(Hierarchy hierarchy, in HierarchyNode root, ForEachDelegate func)
	{
		Stack<HierarchyNode> stack = new Stack<HierarchyNode>();
		stack.Push(root);
		using NativeArray<HierarchyNode> nativeArray = new NativeArray<HierarchyNode>(hierarchy.Count, Allocator.Temp);
		while (stack.Count > 0)
		{
			HierarchyNode node = stack.Pop();
			int childrenCount = hierarchy.GetChildrenCount(in node);
			Span<HierarchyNode> outChildren = new Span<HierarchyNode>(nativeArray.GetUnsafePtr(), childrenCount);
			int children = hierarchy.GetChildren(in node, outChildren);
			if (children != childrenCount)
			{
				throw new InvalidOperationException($"Expected GetChildren to return {childrenCount}, but was {children}.");
			}
			int i = 0;
			for (int length = outChildren.Length; i < length; i++)
			{
				HierarchyNode node2 = outChildren[i];
				func(in node2, i);
				stack.Push(node2);
			}
		}
	}

	[NativeMethod(IsThreadSafe = true)]
	internal static void SetNextHierarchyNodeId(Hierarchy hierarchy, int id)
	{
		SetNextHierarchyNodeId_Injected((hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy), id);
	}

	internal static int GetNodeType<T>() where T : HierarchyNodeTypeHandlerBase
	{
		return GetNodeType(typeof(T));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
	private static extern int GetNodeType(Type type);

	[NativeMethod(IsThreadSafe = true)]
	internal static int[] GetRegisteredNodeTypes(Hierarchy hierarchy)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		int[] result;
		try
		{
			GetRegisteredNodeTypes_Injected((hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy), out ret);
		}
		finally
		{
			int[] array = default(int[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[NativeMethod(IsThreadSafe = true)]
	internal static int GetCapacity(Hierarchy hierarchy)
	{
		return GetCapacity_Injected((hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy));
	}

	[NativeMethod(IsThreadSafe = true)]
	internal static int GetVersion(Hierarchy hierarchy)
	{
		return GetVersion_Injected((hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy));
	}

	[NativeMethod(IsThreadSafe = true)]
	internal static int GetChildrenCapacity(Hierarchy hierarchy, in HierarchyNode node)
	{
		return GetChildrenCapacity_Injected((hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy), in node);
	}

	internal static bool SearchMatch(HierarchyViewModel model, in HierarchyNode node)
	{
		return model.Hierarchy.GetNodeTypeHandlerBase(in node)?.Internal_SearchMatch(in node) ?? false;
	}

	[NativeMethod(IsThreadSafe = true)]
	internal static object GetHierarchyScriptingObject(Hierarchy hierarchy)
	{
		return GetHierarchyScriptingObject_Injected((hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy));
	}

	[NativeMethod(IsThreadSafe = true)]
	internal static object GetHierarchyFlattenedScriptingObject(HierarchyFlattened hierarchyFlattened)
	{
		return GetHierarchyFlattenedScriptingObject_Injected((hierarchyFlattened == null) ? ((IntPtr)0) : HierarchyFlattened.BindingsMarshaller.ConvertToNative(hierarchyFlattened));
	}

	[NativeMethod(IsThreadSafe = true)]
	internal static object GetHierarchyViewModelScriptingObject(HierarchyViewModel viewModel)
	{
		return GetHierarchyViewModelScriptingObject_Injected((viewModel == null) ? ((IntPtr)0) : HierarchyViewModel.BindingsMarshaller.ConvertToNative(viewModel));
	}

	[NativeMethod(IsThreadSafe = true)]
	internal static object GetHierarchyCommandListScriptingObject(HierarchyCommandList cmdList)
	{
		return GetHierarchyCommandListScriptingObject_Injected((cmdList == null) ? ((IntPtr)0) : HierarchyCommandList.BindingsMarshaller.ConvertToNative(cmdList));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GenerateNodesTree_Injected(IntPtr hierarchy, in HierarchyNode root, int width, int depth, int maxCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GenerateNodesCount_Injected(IntPtr hierarchy, in HierarchyNode root, int count, int width, int depth);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GenerateSortIndex_Injected(IntPtr hierarchy, in HierarchyNode root, SortOrder order);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetNextHierarchyNodeId_Injected(IntPtr hierarchy, int id);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetRegisteredNodeTypes_Injected(IntPtr hierarchy, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetCapacity_Injected(IntPtr hierarchy);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetVersion_Injected(IntPtr hierarchy);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetChildrenCapacity_Injected(IntPtr hierarchy, in HierarchyNode node);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern object GetHierarchyScriptingObject_Injected(IntPtr hierarchy);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern object GetHierarchyFlattenedScriptingObject_Injected(IntPtr hierarchyFlattened);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern object GetHierarchyViewModelScriptingObject_Injected(IntPtr viewModel);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern object GetHierarchyCommandListScriptingObject_Injected(IntPtr cmdList);
}
