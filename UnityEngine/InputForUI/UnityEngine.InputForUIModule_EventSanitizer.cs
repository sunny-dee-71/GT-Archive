using System.Collections.Generic;

namespace UnityEngine.InputForUI;

internal struct EventSanitizer
{
	private interface IEventSanitizer
	{
		void Reset();

		void BeforeProviderUpdate();

		void AfterProviderUpdate();

		void Inspect(in Event ev);
	}

	private struct ClickCountEventSanitizer : IEventSanitizer
	{
		private List<PointerEvent> _activeButtons;

		private int lastPushedIndex;

		public void Reset()
		{
			_activeButtons = new List<PointerEvent>();
			lastPushedIndex = 0;
		}

		public void BeforeProviderUpdate()
		{
		}

		public void AfterProviderUpdate()
		{
		}

		public void Inspect(in Event ev)
		{
			if (ev.type != Event.Type.PointerEvent)
			{
				return;
			}
			PointerEvent asPointerEvent = ev.asPointerEvent;
			switch (asPointerEvent.type)
			{
			case PointerEvent.Type.ButtonPressed:
				lastPushedIndex = _activeButtons.Count;
				_activeButtons.Add(asPointerEvent);
				break;
			case PointerEvent.Type.ButtonReleased:
			{
				PointerEvent pointerEvent = asPointerEvent;
				for (int i = 0; i < _activeButtons.Count; i++)
				{
					PointerEvent pointerEvent2 = _activeButtons[i];
					if (pointerEvent2.eventSource != pointerEvent.eventSource || pointerEvent2.pointerIndex != pointerEvent.pointerIndex)
					{
						continue;
					}
					if (i == lastPushedIndex)
					{
						if (pointerEvent2.clickCount != pointerEvent.clickCount)
						{
							Debug.LogWarning($"ButtonReleased click count doesn't match ButtonPressed click count, where '{pointerEvent2}' and '{pointerEvent}'");
						}
					}
					else if (pointerEvent.clickCount != 1)
					{
						Debug.LogWarning($"ButtonReleased for not the last pressed button should have click count == 1, but got '{pointerEvent}'");
					}
					_activeButtons.RemoveAt(i);
					return;
				}
				Debug.LogWarning($"Can't find corresponding ButtonPressed for '{ev}'");
				break;
			}
			}
		}

		void IEventSanitizer.Inspect(in Event ev)
		{
			Inspect(in ev);
		}
	}

	private class DefaultEventSystemSanitizer : IEventSanitizer
	{
		private int m_MouseEventCount;

		private int m_PenOrTouchEventCount;

		public void Reset()
		{
		}

		public void BeforeProviderUpdate()
		{
			m_MouseEventCount = 0;
			m_PenOrTouchEventCount = 0;
		}

		public void AfterProviderUpdate()
		{
			if (m_MouseEventCount > 0 && m_PenOrTouchEventCount > 0)
			{
				Debug.LogError("PointerEvents of source Mouse and [Pen or Touch] received in the same update. This is likely an error, and Mouse events should be discarded.");
			}
		}

		public void Inspect(in Event ev)
		{
			if (ev.type != Event.Type.PointerEvent)
			{
				return;
			}
			PointerEvent asPointerEvent = ev.asPointerEvent;
			if (asPointerEvent.type == PointerEvent.Type.ButtonPressed && asPointerEvent.button == PointerEvent.Button.None)
			{
				Debug.LogError("PointerEvent of type ButtonPressed must have button property set to a value other than None.");
			}
			if (asPointerEvent.type == PointerEvent.Type.ButtonReleased && asPointerEvent.button == PointerEvent.Button.None)
			{
				Debug.LogError("PointerEvent of type ButtonReleased must have button property set to a value other than None.");
			}
			if (asPointerEvent.eventSource == EventSource.Mouse)
			{
				m_MouseEventCount++;
				if (!asPointerEvent.isPrimaryPointer)
				{
					Debug.LogError("PointerEvent of source Mouse is expected to have isPrimaryPointer set to true.");
				}
				if (asPointerEvent.pointerIndex != 0)
				{
					Debug.LogError("PointerEvent of source Mouse is expected to have pointerIndex set to 0.");
				}
			}
			else if (asPointerEvent.eventSource == EventSource.Touch)
			{
				m_PenOrTouchEventCount++;
				if (asPointerEvent.button != PointerEvent.Button.None && asPointerEvent.button != PointerEvent.Button.Primary)
				{
					Debug.LogError("PointerEvent of source Touch is expected to have button set to None or FingerInTouch.");
				}
			}
			else if (asPointerEvent.eventSource == EventSource.Pen)
			{
				m_PenOrTouchEventCount++;
				if (asPointerEvent.button != PointerEvent.Button.None && asPointerEvent.button != PointerEvent.Button.Primary && asPointerEvent.button != PointerEvent.Button.PenBarrelButton && asPointerEvent.button != PointerEvent.Button.PenEraserInTouch)
				{
					Debug.LogError("PointerEvent of source Pen is expected to have button set to None, PenTipInTouch, PenBarrelButton, or PenEraserInTouch.");
				}
			}
		}

		void IEventSanitizer.Inspect(in Event ev)
		{
			Inspect(in ev);
		}
	}

	private IEventSanitizer[] _sanitizers;

	public void Reset()
	{
		_sanitizers = new IEventSanitizer[0];
		IEventSanitizer[] sanitizers = _sanitizers;
		foreach (IEventSanitizer eventSanitizer in sanitizers)
		{
			eventSanitizer.Reset();
		}
	}

	public void BeforeProviderUpdate()
	{
		if (_sanitizers == null)
		{
			Reset();
		}
		IEventSanitizer[] sanitizers = _sanitizers;
		foreach (IEventSanitizer eventSanitizer in sanitizers)
		{
			eventSanitizer.BeforeProviderUpdate();
		}
	}

	public void AfterProviderUpdate()
	{
		if (_sanitizers == null)
		{
			Reset();
		}
		IEventSanitizer[] sanitizers = _sanitizers;
		foreach (IEventSanitizer eventSanitizer in sanitizers)
		{
			eventSanitizer.AfterProviderUpdate();
		}
	}

	public void Inspect(in Event ev)
	{
		if (_sanitizers == null)
		{
			Reset();
		}
		IEventSanitizer[] sanitizers = _sanitizers;
		foreach (IEventSanitizer eventSanitizer in sanitizers)
		{
			eventSanitizer.Inspect(in ev);
		}
	}
}
