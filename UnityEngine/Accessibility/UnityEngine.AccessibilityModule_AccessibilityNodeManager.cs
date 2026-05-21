using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Accessibility;

[NativeHeader("Modules/Accessibility/Native/AccessibilityNodeManager.h")]
internal static class AccessibilityNodeManager
{
	internal const int k_InvalidNodeId = -1;

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool CreateNativeNode(int id);

	internal static bool CreateNativeNodeWithData(AccessibilityNodeData nodeData)
	{
		return CreateNativeNodeWithData_Injected(ref nodeData);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void DestroyNativeNode(int id, int parentId);

	internal static void SetNodeData(int id, AccessibilityNodeData nodeData)
	{
		SetNodeData_Injected(id, ref nodeData);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void SetIsActive(int id, bool isActive);

	internal unsafe static void SetLabel(int id, string label)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(label, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(label);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					SetLabel_Injected(id, ref managedSpanWrapper);
					return;
				}
			}
			SetLabel_Injected(id, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	internal unsafe static void SetValue(int id, string value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(value);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					SetValue_Injected(id, ref managedSpanWrapper);
					return;
				}
			}
			SetValue_Injected(id, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	internal unsafe static void SetHint(int id, string hint)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(hint, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(hint);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					SetHint_Injected(id, ref managedSpanWrapper);
					return;
				}
			}
			SetHint_Injected(id, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void SetRole(int id, AccessibilityRole role);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void SetAllowsDirectInteraction(int id, bool allows);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void SetState(int id, AccessibilityState state);

	internal static void SetFrame(int id, Rect frame)
	{
		SetFrame_Injected(id, ref frame);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void SetParent(int id, int parentId, int index = -1);

	internal unsafe static void SetChildren(int id, int[] childIds)
	{
		Span<int> span = new Span<int>(childIds);
		fixed (int* begin = span)
		{
			ManagedSpanWrapper childIds2 = new ManagedSpanWrapper(begin, span.Length);
			SetChildren_Injected(id, ref childIds2);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool GetIsFocused(int id);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void SetActions(int id, AccessibilityAction[] actions);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void SetLanguage(int id, SystemLanguage language);

	[RequiredByNativeCode]
	internal static void Internal_InvokeFocusChanged(int id, bool isNodeFocused)
	{
		AccessibilityHierarchyService service = AssistiveSupport.GetService<AccessibilityHierarchyService>();
		if (service != null && service.TryGetNode(id, out var node))
		{
			node.NotifyFocusChanged(isNodeFocused);
		}
	}

	[RequiredByNativeCode]
	internal static bool Internal_InvokeSelected(int id)
	{
		AccessibilityHierarchyService service = AssistiveSupport.GetService<AccessibilityHierarchyService>();
		if (service == null)
		{
			return false;
		}
		if (service.TryGetNode(id, out var node))
		{
			return node.InvokeSelected();
		}
		return false;
	}

	[RequiredByNativeCode]
	internal static void Internal_InvokeIncremented(int id)
	{
		AccessibilityHierarchyService service = AssistiveSupport.GetService<AccessibilityHierarchyService>();
		if (service != null && service.TryGetNode(id, out var node))
		{
			node.InvokeIncremented();
		}
	}

	[RequiredByNativeCode]
	internal static void Internal_InvokeDecremented(int id)
	{
		AccessibilityHierarchyService service = AssistiveSupport.GetService<AccessibilityHierarchyService>();
		if (service != null && service.TryGetNode(id, out var node))
		{
			node.InvokeDecremented();
		}
	}

	[RequiredByNativeCode]
	internal static bool Internal_InvokeDismissed(int id)
	{
		AccessibilityHierarchyService service = AssistiveSupport.GetService<AccessibilityHierarchyService>();
		if (service == null)
		{
			return false;
		}
		if (service.TryGetNode(id, out var node))
		{
			return node.Dismissed();
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool CreateNativeNodeWithData_Injected([In] ref AccessibilityNodeData nodeData);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetNodeData_Injected(int id, [In] ref AccessibilityNodeData nodeData);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetLabel_Injected(int id, ref ManagedSpanWrapper label);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetValue_Injected(int id, ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetHint_Injected(int id, ref ManagedSpanWrapper hint);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetFrame_Injected(int id, [In] ref Rect frame);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetChildren_Injected(int id, ref ManagedSpanWrapper childIds);
}
