using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Pool;
using UnityEngine.Scripting;

namespace UnityEngine.Accessibility;

[VisibleToOtherModules(new string[] { "UnityEditor.AccessibilityModule" })]
[NativeHeader("Modules/Accessibility/Native/AccessibilityManager.h")]
internal static class AccessibilityManager
{
	public struct NotificationContext
	{
		public AccessibilityNotification notification { get; set; }

		public bool isScreenReaderEnabled { get; set; }

		public string announcement { get; set; }

		public bool wasAnnouncementSuccessful { get; set; }

		public AccessibilityNode currentNode { get; set; }

		public AccessibilityNode nextNode { get; set; }

		public float fontScale { get; set; }

		public bool isBoldTextEnabled { get; set; }

		public bool isClosedCaptioningEnabled { get; set; }

		public AccessibilityNotificationContext nativeContext { get; set; }

		public NotificationContext(ref AccessibilityNotificationContext nativeNotification)
		{
			nativeContext = nativeNotification;
			notification = nativeNotification.notification;
			isScreenReaderEnabled = nativeNotification.isScreenReaderEnabled;
			announcement = nativeNotification.announcement;
			wasAnnouncementSuccessful = nativeNotification.wasAnnouncementSuccessful;
			AccessibilityNode node = null;
			AssistiveSupport.activeHierarchy?.TryGetNode(nativeNotification.currentNodeId, out node);
			currentNode = node;
			AssistiveSupport.activeHierarchy?.TryGetNode(nativeNotification.nextNodeId, out node);
			nextNode = node;
			fontScale = 1f;
			isBoldTextEnabled = false;
			isClosedCaptioningEnabled = false;
		}
	}

	private sealed class ExclusiveLock : IDisposable
	{
		private bool m_Disposed;

		public ExclusiveLock()
		{
			Lock();
		}

		~ExclusiveLock()
		{
			InternalDispose();
		}

		private void InternalDispose()
		{
			if (!m_Disposed)
			{
				Unlock();
				m_Disposed = true;
			}
		}

		public void Dispose()
		{
			InternalDispose();
			GC.SuppressFinalize(this);
		}
	}

	internal static Queue<NotificationContext> asyncNotificationContexts = new Queue<NotificationContext>();

	public static bool isSupportedPlatform
	{
		get
		{
			RuntimePlatform platform = Application.platform;
			return platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer;
		}
	}

	public static event Action<bool> screenReaderStatusChanged;

	public static event Action<AccessibilityNode> nodeFocusChanged;

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool IsScreenReaderEnabled();

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void SendAccessibilityNotification(in AccessibilityNotificationContext context);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern SystemLanguage GetApplicationAccessibilityLanguage();

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void SetApplicationAccessibilityLanguage(SystemLanguage languageCode);

	[RequiredByNativeCode]
	[VisibleToOtherModules(new string[] { "UnityEditor.AccessibilityModule" })]
	internal static void Internal_Initialize()
	{
		AssistiveSupport.Initialize();
	}

	[RequiredByNativeCode]
	private static void Internal_Update()
	{
		if (asyncNotificationContexts.Count == 0)
		{
			return;
		}
		NotificationContext[] array;
		lock (asyncNotificationContexts)
		{
			if (asyncNotificationContexts.Count == 0)
			{
				return;
			}
			array = asyncNotificationContexts.ToArray();
			asyncNotificationContexts.Clear();
		}
		using (GetExclusiveLock())
		{
			NotificationContext[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				NotificationContext notificationContext = array2[i];
				switch (notificationContext.notification)
				{
				case AccessibilityNotification.ScreenReaderStatusChanged:
					AccessibilityManager.screenReaderStatusChanged?.Invoke(notificationContext.isScreenReaderEnabled);
					break;
				case AccessibilityNotification.ElementFocused:
					notificationContext.currentNode.InvokeFocusChanged(isNodeFocused: true);
					AccessibilityManager.nodeFocusChanged?.Invoke(notificationContext.currentNode);
					break;
				case AccessibilityNotification.ElementUnfocused:
					notificationContext.currentNode.InvokeFocusChanged(isNodeFocused: false);
					break;
				case AccessibilityNotification.FontScaleChanged:
					AccessibilitySettings.InvokeFontScaleChanged(notificationContext.fontScale);
					break;
				case AccessibilityNotification.BoldTextStatusChanged:
					AccessibilitySettings.InvokeBoldTextStatusChanged(notificationContext.isBoldTextEnabled);
					break;
				case AccessibilityNotification.ClosedCaptioningStatusChanged:
					AccessibilitySettings.InvokeClosedCaptionStatusChanged(notificationContext.isClosedCaptioningEnabled);
					break;
				}
			}
		}
	}

	[RequiredByNativeCode]
	internal static int[] Internal_GetRootNodeIds()
	{
		List<AccessibilityNode> list = AssistiveSupport.GetService<AccessibilityHierarchyService>()?.GetRootNodes();
		if (list == null || list.Count == 0)
		{
			return null;
		}
		List<int> value;
		using (CollectionPool<List<int>, int>.Get(out value))
		{
			for (int i = 0; i < list.Count; i++)
			{
				value.Add(list[i].id);
			}
			return (value.Count == 0) ? null : value.ToArray();
		}
	}

	[RequiredByNativeCode]
	internal static bool Internal_GetNode(int id, ref AccessibilityNodeData nodeData)
	{
		AccessibilityHierarchyService service = AssistiveSupport.GetService<AccessibilityHierarchyService>();
		if (service == null)
		{
			return false;
		}
		if (service.TryGetNode(id, out var node))
		{
			node.GetNodeData(ref nodeData);
			return true;
		}
		return false;
	}

	[RequiredByNativeCode]
	internal static int Internal_GetNodeIdAt(float x, float y)
	{
		AccessibilityHierarchyService service = AssistiveSupport.GetService<AccessibilityHierarchyService>();
		AccessibilityNode node;
		return (service != null && service.TryGetNodeAt(x, y, out node)) ? node.id : (-1);
	}

	[RequiredByNativeCode]
	internal static void Internal_OnAccessibilityNotificationReceived(ref AccessibilityNotificationContext context)
	{
		if (context.notification != AccessibilityNotification.ElementFocused)
		{
			QueueNotification(new NotificationContext(ref context));
		}
	}

	internal static void QueueNotification(NotificationContext notification)
	{
		lock (asyncNotificationContexts)
		{
			asyncNotificationContexts.Enqueue(notification);
		}
	}

	internal static IDisposable GetExclusiveLock()
	{
		return new ExclusiveLock();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[ThreadSafe]
	private static extern void Lock();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[ThreadSafe]
	private static extern void Unlock();
}
