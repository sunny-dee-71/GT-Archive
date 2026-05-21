using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Accessibility;

[NativeHeader("Modules/Accessibility/Native/AccessibilitySettings.h")]
public static class AccessibilitySettings
{
	public static float fontScale => GetFontScale();

	public static bool isBoldTextEnabled => IsBoldTextEnabled();

	public static bool isClosedCaptioningEnabled => IsClosedCaptioningEnabled();

	public static event Action<float> fontScaleChanged;

	public static event Action<bool> boldTextStatusChanged;

	public static event Action<bool> closedCaptioningStatusChanged;

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetFontScale();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsBoldTextEnabled();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsClosedCaptioningEnabled();

	[RequiredByNativeCode]
	private static void Internal_OnFontScaleChanged(float newFontScale)
	{
		AccessibilityManager.QueueNotification(new AccessibilityManager.NotificationContext
		{
			notification = AccessibilityNotification.FontScaleChanged,
			fontScale = newFontScale
		});
	}

	[RequiredByNativeCode]
	private static void Internal_OnBoldTextStatusChanged(bool enabled)
	{
		AccessibilityManager.QueueNotification(new AccessibilityManager.NotificationContext
		{
			notification = AccessibilityNotification.BoldTextStatusChanged,
			isBoldTextEnabled = enabled
		});
	}

	[RequiredByNativeCode]
	private static void Internal_OnClosedCaptioningStatusChanged(bool enabled)
	{
		AccessibilityManager.QueueNotification(new AccessibilityManager.NotificationContext
		{
			notification = AccessibilityNotification.ClosedCaptioningStatusChanged,
			isClosedCaptioningEnabled = enabled
		});
	}

	internal static void InvokeFontScaleChanged(float newFontScale)
	{
		AccessibilitySettings.fontScaleChanged?.Invoke(newFontScale);
	}

	internal static void InvokeBoldTextStatusChanged(bool enabled)
	{
		AccessibilitySettings.boldTextStatusChanged?.Invoke(enabled);
	}

	internal static void InvokeClosedCaptionStatusChanged(bool enabled)
	{
		AccessibilitySettings.closedCaptioningStatusChanged?.Invoke(enabled);
	}
}
