using System;

namespace Meta.XR.ImmersiveDebugger.Gizmo;

internal struct GizmoTypeInfo(Action<object> renderDelegate)
{
	public readonly Action<object> RenderDelegate = renderDelegate;
}
