using System.Collections.Generic;
using Unity.IntegerTime;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.InputForUI;

[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal static class EventProvider
{
	private struct Registration
	{
		public EventConsumer handler;

		public int priority;

		public int? playerId;

		public HashSet<Event.Type> _types;
	}

	private static IEventProviderImpl s_impl = new InputManagerProvider();

	private static EventSanitizer s_sanitizer;

	private static IEventProviderImpl s_implMockBackup = null;

	private static bool s_focusStateBeforeMock;

	private static bool s_focusChangedRegistered;

	private static bool m_IsEnabled = true;

	private static bool m_IsInitialized = false;

	private static List<Registration> _registrations = new List<Registration>();

	public static IEventProviderImpl provider => s_impl;

	public static uint playerCount => s_impl?.playerCount ?? 0;

	internal static string _providerClassName => s_impl?.GetType().Name;

	internal static RationalTime doubleClickTime
	{
		get
		{
			int num = UnityEngine.Event.GetDoubleClickTime();
			return new RationalTime(num, new RationalTime.TicksPerSecond(1000u));
		}
	}

	public static void Subscribe(EventConsumer handler, int priority = 0, int? playerId = null, params Event.Type[] type)
	{
		Bootstrap();
		_registrations.Add(new Registration
		{
			handler = handler,
			priority = priority,
			playerId = playerId,
			_types = new HashSet<Event.Type>(type)
		});
		_registrations.Sort((Registration a, Registration b) => a.priority.CompareTo(b.priority));
	}

	public static void Unsubscribe(EventConsumer handler)
	{
		_registrations.RemoveAll((Registration x) => x.handler == handler);
	}

	public static void SetEnabled(bool enable)
	{
		m_IsEnabled = enable;
		if (enable)
		{
			Initialize();
		}
		else
		{
			Shutdown();
		}
	}

	internal static void Dispatch(in Event ev)
	{
		if (_registrations.Count == 0)
		{
			return;
		}
		s_sanitizer.Inspect(in ev);
		foreach (Registration registration in _registrations)
		{
			if ((registration._types.Count <= 0 || registration._types.Contains(ev.type)) && registration.handler(in ev))
			{
				break;
			}
		}
	}

	public static void RequestCurrentState(params Event.Type[] types)
	{
		Event.Type[] array = ((types != null && types.Length > 0) ? types : Event.TypesWithState);
		foreach (Event.Type type in array)
		{
			if (s_impl?.RequestCurrentState(type) != true)
			{
				Debug.LogWarning($"Can't provide state for type {type}");
			}
		}
	}

	private static void Bootstrap()
	{
		if (m_IsEnabled)
		{
			Initialize();
		}
	}

	private static void Initialize()
	{
		if (!m_IsInitialized)
		{
			s_sanitizer.Reset();
			s_impl?.Initialize();
			if (!s_focusChangedRegistered)
			{
				Application.focusChanged += OnFocusChanged;
				s_focusChangedRegistered = true;
			}
			m_IsInitialized = true;
		}
	}

	private static void Shutdown()
	{
		if (m_IsInitialized)
		{
			m_IsInitialized = false;
			if (s_focusChangedRegistered)
			{
				s_focusChangedRegistered = false;
				Application.focusChanged -= OnFocusChanged;
			}
			s_impl?.Shutdown();
		}
	}

	private static void OnFocusChanged(bool focus)
	{
		s_impl?.OnFocusChanged(focus);
	}

	[RequiredByNativeCode]
	internal static void NotifyUpdate()
	{
		if (Application.isPlaying && _registrations.Count != 0 && m_IsInitialized)
		{
			s_sanitizer.BeforeProviderUpdate();
			s_impl?.Update();
			s_sanitizer.AfterProviderUpdate();
		}
	}

	internal static void SetInputSystemProvider(IEventProviderImpl impl)
	{
		bool isInitialized = m_IsInitialized;
		Shutdown();
		s_impl = impl;
		if (isInitialized)
		{
			Initialize();
		}
	}

	internal static void SetMockProvider(IEventProviderImpl impl)
	{
		if (s_implMockBackup == null)
		{
			s_implMockBackup = s_impl;
		}
		s_focusStateBeforeMock = Application.isFocused;
		Shutdown();
		s_impl = impl;
		Initialize();
	}

	internal static void ClearMockProvider()
	{
		Shutdown();
		s_impl = s_implMockBackup;
		s_implMockBackup = null;
		Initialize();
		if (s_focusStateBeforeMock != Application.isFocused)
		{
			s_impl?.OnFocusChanged(Application.isFocused);
		}
	}
}
