using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Accessibility;

[RequiredByNativeCode]
[NativeType(CodegenOptions.Custom, "MonoAccessibilityNotificationContext")]
[NativeHeader("Modules/Accessibility/Native/AccessibilityNotificationContext.h")]
[NativeHeader("Modules/Accessibility/Bindings/AccessibilityNotificationContext.bindings.h")]
internal struct AccessibilityNotificationContext
{
	public AccessibilityNotification notification { get; set; }

	public bool isScreenReaderEnabled { get; }

	public string announcement { get; set; }

	public bool wasAnnouncementSuccessful { get; }

	public int currentNodeId { get; }

	public int nextNodeId { get; set; }
}
