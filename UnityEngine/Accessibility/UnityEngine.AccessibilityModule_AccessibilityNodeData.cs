using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Accessibility;

[RequiredByNativeCode]
[NativeType(CodegenOptions.Custom, "MonoAccessibilityNodeData")]
[NativeHeader("Modules/Accessibility/Bindings/AccessibilityNodeData.bindings.h")]
[NativeHeader("Modules/Accessibility/Native/AccessibilityNodeData.h")]
internal struct AccessibilityNodeData
{
	public int id { get; set; }

	public bool isActive { get; set; }

	public string label { get; set; }

	public string value { get; set; }

	public string hint { get; set; }

	public AccessibilityRole role { get; set; }

	public bool allowsDirectInteraction { get; set; }

	public AccessibilityState state { get; set; }

	public Rect frame { get; set; }

	public int parentId { get; set; }

	public int[] childIds { get; set; }

	public bool isFocused { get; }

	internal SystemLanguage language { get; set; }

	public bool implementsSelected { get; set; }

	public bool implementsDismissed { get; set; }
}
