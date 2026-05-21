using System;
using System.Runtime.InteropServices;

namespace Liv.NGFX;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ResourceDestroyInfo(IntPtr ctx, uint id)
{
	public static EventType eventType = EventType.ResourceDestroy;

	private IntPtr m_context = ctx;

	private uint m_id = id;
}
