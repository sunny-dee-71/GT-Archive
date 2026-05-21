using System.Collections.Generic;
using Unity.IntegerTime;

namespace UnityEngine.InputForUI;

internal class InputEventPartialProvider : IEventProviderImpl
{
	private const int kDefaultPlayerId = 0;

	private UnityEngine.Event _ev = new UnityEngine.Event();

	private OperatingSystemFamily _operatingSystemFamily;

	private KeyEvent.ButtonsState _keyboardButtonsState;

	internal EventModifiers _eventModifiers;

	internal bool _sendNavigationEventOnTabKey;

	private IDictionary<string, CommandEvent.Command> _IMGUICommandToInputForUICommandType = new Dictionary<string, CommandEvent.Command>
	{
		{
			"Cut",
			CommandEvent.Command.Cut
		},
		{
			"Copy",
			CommandEvent.Command.Copy
		},
		{
			"Paste",
			CommandEvent.Command.Paste
		},
		{
			"SelectAll",
			CommandEvent.Command.SelectAll
		},
		{
			"DeselectAll",
			CommandEvent.Command.DeselectAll
		},
		{
			"InvertSelection",
			CommandEvent.Command.InvertSelection
		},
		{
			"Duplicate",
			CommandEvent.Command.Duplicate
		},
		{
			"Rename",
			CommandEvent.Command.Rename
		},
		{
			"Delete",
			CommandEvent.Command.Delete
		},
		{
			"SoftDelete",
			CommandEvent.Command.SoftDelete
		},
		{
			"Find",
			CommandEvent.Command.Find
		},
		{
			"SelectChildren",
			CommandEvent.Command.SelectChildren
		},
		{
			"SelectPrefabRoot",
			CommandEvent.Command.SelectPrefabRoot
		},
		{
			"UndoRedoPerformed",
			CommandEvent.Command.UndoRedoPerformed
		},
		{
			"OnLostFocus",
			CommandEvent.Command.OnLostFocus
		},
		{
			"NewKeyboardFocus",
			CommandEvent.Command.NewKeyboardFocus
		},
		{
			"ModifierKeysChanged",
			CommandEvent.Command.ModifierKeysChanged
		},
		{
			"EyeDropperUpdate",
			CommandEvent.Command.EyeDropperUpdate
		},
		{
			"EyeDropperClicked",
			CommandEvent.Command.EyeDropperClicked
		},
		{
			"EyeDropperCancelled",
			CommandEvent.Command.EyeDropperCancelled
		},
		{
			"ColorPickerChanged",
			CommandEvent.Command.ColorPickerChanged
		},
		{
			"FrameSelected",
			CommandEvent.Command.FrameSelected
		},
		{
			"FrameSelectedWithLock",
			CommandEvent.Command.FrameSelectedWithLock
		}
	};

	public uint playerCount => 0u;

	public void Initialize()
	{
		_operatingSystemFamily = SystemInfo.operatingSystemFamily;
		_keyboardButtonsState.Reset();
		_eventModifiers.Reset();
	}

	public void Shutdown()
	{
	}

	public void Update()
	{
		int eventCount = UnityEngine.Event.GetEventCount();
		for (int i = 0; i < eventCount; i++)
		{
			UnityEngine.Event.GetEventAtIndex(i, _ev);
			UpdateEventModifiers(in _ev);
			switch (_ev.type)
			{
			case EventType.KeyDown:
			case EventType.KeyUp:
				if (_ev.keyCode != KeyCode.None)
				{
					EventProvider.Dispatch(Event.From(ToKeyEvent(in _ev)));
					if (_sendNavigationEventOnTabKey)
					{
						SendNextOrPreviousNavigationEventOnTabKeyDownEvent(in _ev);
					}
				}
				if (_ev.character != 0 && _ev.type == EventType.KeyDown)
				{
					EventProvider.Dispatch(Event.From(ToTextInputEvent(in _ev)));
				}
				break;
			case EventType.ValidateCommand:
			case EventType.ExecuteCommand:
				EventProvider.Dispatch(Event.From(ToCommandEvent(in _ev)));
				break;
			}
		}
	}

	public void OnFocusChanged(bool focus)
	{
		if (!focus)
		{
			_eventModifiers.Reset();
			_keyboardButtonsState.Reset();
		}
	}

	public bool RequestCurrentState(Event.Type type)
	{
		if (type == Event.Type.KeyEvent)
		{
			EventProvider.Dispatch(Event.From(new KeyEvent
			{
				type = KeyEvent.Type.State,
				keyCode = KeyCode.None,
				buttonsState = _keyboardButtonsState,
				timestamp = (DiscreteTime)Time.timeAsRational,
				eventSource = EventSource.Keyboard,
				playerId = 0u,
				eventModifiers = _eventModifiers
			}));
			return true;
		}
		return false;
	}

	private DiscreteTime GetTimestamp(in UnityEngine.Event ev)
	{
		return (DiscreteTime)Time.timeAsRational;
	}

	private void UpdateEventModifiers(in UnityEngine.Event ev)
	{
		_eventModifiers.SetPressed(EventModifiers.Modifiers.CapsLock, ev.capsLock);
		_eventModifiers.SetPressed(EventModifiers.Modifiers.FunctionKey, ev.functionKey);
		_eventModifiers.SetPressed(EventModifiers.Modifiers.Numeric, ev.numeric);
		if (ev.isKey && ev.keyCode != KeyCode.None)
		{
			bool pressed = ev.type == EventType.KeyDown;
			switch (ev.keyCode)
			{
			case KeyCode.LeftShift:
				_eventModifiers.SetPressed(EventModifiers.Modifiers.LeftShift, pressed);
				break;
			case KeyCode.RightShift:
				_eventModifiers.SetPressed(EventModifiers.Modifiers.RightShift, pressed);
				break;
			case KeyCode.LeftControl:
				_eventModifiers.SetPressed(EventModifiers.Modifiers.LeftCtrl, pressed);
				break;
			case KeyCode.RightControl:
				_eventModifiers.SetPressed(EventModifiers.Modifiers.RightCtrl, pressed);
				break;
			case KeyCode.LeftAlt:
				_eventModifiers.SetPressed(EventModifiers.Modifiers.LeftAlt, pressed);
				break;
			case KeyCode.RightAlt:
				_eventModifiers.SetPressed(EventModifiers.Modifiers.RightAlt, pressed);
				break;
			case KeyCode.LeftMeta:
				_eventModifiers.SetPressed(EventModifiers.Modifiers.LeftMeta, pressed);
				break;
			case KeyCode.RightMeta:
				_eventModifiers.SetPressed(EventModifiers.Modifiers.RightMeta, pressed);
				break;
			case KeyCode.Numlock:
				_eventModifiers.SetPressed(EventModifiers.Modifiers.Numlock, pressed);
				break;
			}
		}
		if (ev.shift != _eventModifiers.IsPressed(EventModifiers.Modifiers.Shift))
		{
			_eventModifiers.SetPressed(EventModifiers.Modifiers.Shift, ev.shift);
		}
		if (ev.control != _eventModifiers.IsPressed(EventModifiers.Modifiers.Ctrl))
		{
			_eventModifiers.SetPressed(EventModifiers.Modifiers.Ctrl, ev.control);
		}
		if (ev.alt != _eventModifiers.IsPressed(EventModifiers.Modifiers.Alt))
		{
			_eventModifiers.SetPressed(EventModifiers.Modifiers.Alt, ev.alt);
		}
		if (ev.command != _eventModifiers.IsPressed(EventModifiers.Modifiers.Meta))
		{
			_eventModifiers.SetPressed(EventModifiers.Modifiers.Meta, ev.command);
		}
	}

	private KeyEvent ToKeyEvent(in UnityEngine.Event ev)
	{
		bool flag = _keyboardButtonsState.IsPressed(ev.keyCode);
		bool flag2 = ev.type == EventType.KeyDown;
		_keyboardButtonsState.SetPressed(ev.keyCode, flag2);
		return new KeyEvent
		{
			type = ((!flag2) ? KeyEvent.Type.KeyReleased : ((!flag) ? KeyEvent.Type.KeyPressed : KeyEvent.Type.KeyRepeated)),
			keyCode = ev.keyCode,
			buttonsState = _keyboardButtonsState,
			timestamp = GetTimestamp(in ev),
			eventSource = EventSource.Keyboard,
			playerId = 0u,
			eventModifiers = _eventModifiers
		};
	}

	private TextInputEvent ToTextInputEvent(in UnityEngine.Event ev)
	{
		return new TextInputEvent
		{
			character = ev.character,
			timestamp = GetTimestamp(in ev),
			eventSource = EventSource.Keyboard,
			playerId = 0u,
			eventModifiers = _eventModifiers
		};
	}

	private void SendNextOrPreviousNavigationEventOnTabKeyDownEvent(in UnityEngine.Event ev)
	{
		if (_ev.type == EventType.KeyDown && _ev.keyCode == KeyCode.Tab)
		{
			EventProvider.Dispatch(Event.From(new NavigationEvent
			{
				type = NavigationEvent.Type.Move,
				direction = (_ev.shift ? NavigationEvent.Direction.Previous : NavigationEvent.Direction.Next),
				timestamp = GetTimestamp(in _ev),
				eventSource = EventSource.Keyboard,
				playerId = 0u,
				eventModifiers = _eventModifiers
			}));
		}
	}

	private CommandEvent ToCommandEvent(in UnityEngine.Event ev)
	{
		if (!_IMGUICommandToInputForUICommandType.TryGetValue(ev.commandName, out var value))
		{
			Debug.LogWarning("Unsupported command name '" + ev.commandName + "'");
		}
		return new CommandEvent
		{
			type = ((ev.type == EventType.ValidateCommand) ? CommandEvent.Type.Validate : CommandEvent.Type.Execute),
			command = value,
			timestamp = GetTimestamp(in ev),
			eventSource = EventSource.Unspecified,
			playerId = 0u,
			eventModifiers = _eventModifiers
		};
	}
}
