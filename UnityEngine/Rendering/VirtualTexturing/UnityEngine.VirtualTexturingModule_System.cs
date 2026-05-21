using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Rendering.VirtualTexturing;

[NativeHeader("Modules/VirtualTexturing/ScriptBindings/VirtualTexturing.bindings.h")]
[StaticAccessor("VirtualTexturing::System", StaticAccessorType.DoubleColon)]
public static class System
{
	public const int AllMips = int.MaxValue;

	internal static extern bool enabled
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void Update();

	[NativeThrows]
	internal static void SetDebugFlag(Guid guid, bool enabled)
	{
		SetDebugFlagInteger(guid.ToByteArray(), enabled ? 1 : 0);
	}

	[NativeThrows]
	internal static void SetDebugFlagInteger(Guid guid, long value)
	{
		SetDebugFlagInteger(guid.ToByteArray(), value);
	}

	[NativeThrows]
	internal static void SetDebugFlagDouble(Guid guid, double value)
	{
		SetDebugFlagDouble(guid.ToByteArray(), value);
	}

	[NativeThrows]
	private unsafe static void SetDebugFlagInteger(byte[] guid, long value)
	{
		Span<byte> span = new Span<byte>(guid);
		fixed (byte* begin = span)
		{
			ManagedSpanWrapper guid2 = new ManagedSpanWrapper(begin, span.Length);
			SetDebugFlagInteger_Injected(ref guid2, value);
		}
	}

	[NativeThrows]
	private unsafe static void SetDebugFlagDouble(byte[] guid, double value)
	{
		Span<byte> span = new Span<byte>(guid);
		fixed (byte* begin = span)
		{
			ManagedSpanWrapper guid2 = new ManagedSpanWrapper(begin, span.Length);
			SetDebugFlagDouble_Injected(ref guid2, value);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetDebugFlagInteger_Injected(ref ManagedSpanWrapper guid, long value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetDebugFlagDouble_Injected(ref ManagedSpanWrapper guid, double value);
}
