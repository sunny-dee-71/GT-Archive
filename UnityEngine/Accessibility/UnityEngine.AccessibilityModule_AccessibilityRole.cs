using System;
using UnityEngine.Bindings;

namespace UnityEngine.Accessibility;

[NativeHeader("Modules/Accessibility/Native/AccessibilityNodeData.h")]
[Flags]
public enum AccessibilityRole : ushort
{
	None = 0,
	Button = 1,
	Image = 2,
	StaticText = 4,
	SearchField = 8,
	KeyboardKey = 0x10,
	Header = 0x20,
	TabBar = 0x40,
	Slider = 0x80,
	Toggle = 0x100
}
