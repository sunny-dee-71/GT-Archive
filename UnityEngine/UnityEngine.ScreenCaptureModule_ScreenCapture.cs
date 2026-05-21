using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[NativeHeader("Modules/ScreenCapture/Public/CaptureScreenshot.h")]
public static class ScreenCapture
{
	public enum StereoScreenCaptureMode
	{
		LeftEye = 1,
		RightEye,
		BothEyes,
		MotionVectors
	}

	public static void CaptureScreenshot(string filename)
	{
		CaptureScreenshot(filename, 1, StereoScreenCaptureMode.LeftEye);
	}

	public static void CaptureScreenshot(string filename, int superSize)
	{
		CaptureScreenshot(filename, superSize, StereoScreenCaptureMode.LeftEye);
	}

	public static void CaptureScreenshot(string filename, StereoScreenCaptureMode stereoCaptureMode)
	{
		CaptureScreenshot(filename, 1, stereoCaptureMode);
	}

	public static Texture2D CaptureScreenshotAsTexture()
	{
		return CaptureScreenshotAsTexture(1, StereoScreenCaptureMode.LeftEye);
	}

	public static Texture2D CaptureScreenshotAsTexture(int superSize)
	{
		return CaptureScreenshotAsTexture(superSize, StereoScreenCaptureMode.LeftEye);
	}

	public static Texture2D CaptureScreenshotAsTexture(StereoScreenCaptureMode stereoCaptureMode)
	{
		return CaptureScreenshotAsTexture(1, stereoCaptureMode);
	}

	public static void CaptureScreenshotIntoRenderTexture(RenderTexture renderTexture)
	{
		CaptureScreenshotIntoRenderTexture_Injected(Object.MarshalledUnityObject.Marshal(renderTexture));
	}

	private unsafe static void CaptureScreenshot(string filename, [DefaultValue("1")] int superSize, [DefaultValue("1")] StereoScreenCaptureMode CaptureMode)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(filename, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(filename);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					CaptureScreenshot_Injected(ref managedSpanWrapper, superSize, CaptureMode);
					return;
				}
			}
			CaptureScreenshot_Injected(ref managedSpanWrapper, superSize, CaptureMode);
		}
		finally
		{
		}
	}

	private static Texture2D CaptureScreenshotAsTexture(int superSize, StereoScreenCaptureMode stereoScreenCaptureMode)
	{
		return Unmarshal.UnmarshalUnityObject<Texture2D>(CaptureScreenshotAsTexture_Injected(superSize, stereoScreenCaptureMode));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CaptureScreenshotIntoRenderTexture_Injected(IntPtr renderTexture);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CaptureScreenshot_Injected(ref ManagedSpanWrapper filename, [DefaultValue("1")] int superSize, [DefaultValue("1")] StereoScreenCaptureMode CaptureMode);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr CaptureScreenshotAsTexture_Injected(int superSize, StereoScreenCaptureMode stereoScreenCaptureMode);
}
