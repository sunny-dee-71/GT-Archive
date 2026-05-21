using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine.Rendering.VirtualTexturing;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/VirtualTexturing/Public/VirtualTextureResolver.h")]
public class Resolver : IDisposable
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(Resolver resolver)
		{
			return resolver.m_Ptr;
		}
	}

	internal IntPtr m_Ptr;

	public int CurrentWidth { get; private set; } = 0;

	public int CurrentHeight { get; private set; } = 0;

	public Resolver()
	{
		if (!System.enabled)
		{
			throw new InvalidOperationException("Virtual texturing is not enabled in the player settings.");
		}
		m_Ptr = InitNative();
	}

	~Resolver()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (m_Ptr != IntPtr.Zero)
		{
			Flush_Internal();
			ReleaseNative(m_Ptr);
			m_Ptr = IntPtr.Zero;
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr InitNative();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(IsThreadSafe = true)]
	private static extern void ReleaseNative(IntPtr ptr);

	private void Flush_Internal()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Flush_Internal_Injected(intPtr);
	}

	private void Init_Internal(int width, int height)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Init_Internal_Injected(intPtr, width, height);
	}

	public void UpdateSize(int width, int height)
	{
		if (CurrentWidth != width || CurrentHeight != height)
		{
			if (width <= 0 || height <= 0)
			{
				throw new ArgumentException($"Zero sized dimensions are invalid (width: {width}, height: {height}.");
			}
			CurrentWidth = width;
			CurrentHeight = height;
			Flush_Internal();
			Init_Internal(CurrentWidth, CurrentHeight);
		}
	}

	public void Process(CommandBuffer cmd, RenderTargetIdentifier rt)
	{
		Process(cmd, rt, 0, CurrentWidth, 0, CurrentHeight, 0, 0);
	}

	public void Process(CommandBuffer cmd, RenderTargetIdentifier rt, int x, int width, int y, int height, int mip, int slice)
	{
		if (cmd == null)
		{
			throw new ArgumentNullException("cmd");
		}
		cmd.ProcessVTFeedback(rt, m_Ptr, slice, x, width, y, height, mip);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Flush_Internal_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Init_Internal_Injected(IntPtr _unity_self, int width, int height);
}
