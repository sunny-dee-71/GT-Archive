using System;
using UnityEngine.Bindings;

namespace UnityEngine.Accessibility;

public static class AssistiveSupport
{
	internal class NotificationDispatcher : IAccessibilityNotificationDispatcher
	{
		private static void Send(in AccessibilityNotificationContext context)
		{
			AccessibilityManager.SendAccessibilityNotification(in context);
		}

		public void SendAnnouncement(string announcement)
		{
			AccessibilityNotificationContext context = new AccessibilityNotificationContext
			{
				notification = AccessibilityNotification.Announcement,
				announcement = announcement
			};
			Send(in context);
		}

		public void SendPageScrolledAnnouncement(string announcement)
		{
			AccessibilityNotificationContext context = new AccessibilityNotificationContext
			{
				notification = AccessibilityNotification.PageScrolled,
				announcement = announcement
			};
			Send(in context);
		}

		public void SendScreenChanged(AccessibilityNode nodeToFocus = null)
		{
			AccessibilityNotificationContext context = new AccessibilityNotificationContext
			{
				notification = AccessibilityNotification.ScreenChanged,
				nextNodeId = (nodeToFocus?.id ?? (-1))
			};
			Send(in context);
		}

		public void SendLayoutChanged(AccessibilityNode nodeToFocus = null)
		{
			AccessibilityNotificationContext context = new AccessibilityNotificationContext
			{
				notification = AccessibilityNotification.LayoutChanged,
				nextNodeId = (nodeToFocus?.id ?? (-1))
			};
			Send(in context);
		}
	}

	private static ServiceManager s_ServiceManager;

	public static bool isScreenReaderEnabled { get; private set; }

	public static IAccessibilityNotificationDispatcher notificationDispatcher { get; } = new NotificationDispatcher();

	public static AccessibilityHierarchy activeHierarchy
	{
		get
		{
			return GetService<AccessibilityHierarchyService>()?.hierarchy;
		}
		set
		{
			CheckPlatformSupported();
			using (AccessibilityManager.GetExclusiveLock())
			{
				AccessibilityHierarchyService service = GetService<AccessibilityHierarchyService>();
				if (service != null)
				{
					service.hierarchy = value;
					AssistiveSupport.s_ActiveHierarchyChanged?.Invoke(value);
				}
			}
		}
	}

	public static event Action<AccessibilityNode> nodeFocusChanged;

	public static event Action<bool> screenReaderStatusChanged;

	private static event Action<AccessibilityHierarchy> s_ActiveHierarchyChanged;

	internal static event Action<AccessibilityHierarchy> activeHierarchyChanged
	{
		[VisibleToOtherModules(new string[] { "UnityEditor.AccessibilityModule" })]
		add
		{
			s_ActiveHierarchyChanged += value;
		}
		[VisibleToOtherModules(new string[] { "UnityEditor.AccessibilityModule" })]
		remove
		{
			s_ActiveHierarchyChanged -= value;
		}
	}

	internal static void Initialize()
	{
		isScreenReaderEnabled = AccessibilityManager.IsScreenReaderEnabled();
		AccessibilityManager.screenReaderStatusChanged += ScreenReaderStatusChanged;
		AccessibilityManager.nodeFocusChanged += NodeFocusChanged;
		s_ServiceManager = new ServiceManager();
	}

	internal static T GetService<T>() where T : IService
	{
		if (s_ServiceManager == null)
		{
			return default(T);
		}
		return s_ServiceManager.GetService<T>();
	}

	internal static bool IsServiceRunning<T>() where T : IService
	{
		IService service = GetService<T>();
		return service != null;
	}

	internal static void SetApplicationAccessibilityLanguage(SystemLanguage language)
	{
		AccessibilityManager.SetApplicationAccessibilityLanguage(language);
	}

	private static void ScreenReaderStatusChanged(bool screenReaderEnabled)
	{
		if (isScreenReaderEnabled != screenReaderEnabled)
		{
			isScreenReaderEnabled = screenReaderEnabled;
			AssistiveSupport.screenReaderStatusChanged?.Invoke(isScreenReaderEnabled);
		}
	}

	private static void NodeFocusChanged(AccessibilityNode currentNode)
	{
		AssistiveSupport.nodeFocusChanged?.Invoke(currentNode);
	}

	internal static void OnHierarchyNodeFramesRefreshed(AccessibilityHierarchy hierarchy)
	{
		if (activeHierarchy == hierarchy)
		{
			notificationDispatcher.SendLayoutChanged();
		}
	}

	private static void CheckPlatformSupported()
	{
		if (!Application.isEditor && !AccessibilityManager.isSupportedPlatform)
		{
			throw new PlatformNotSupportedException($"This API is not supported for platform {Application.platform}");
		}
	}
}
