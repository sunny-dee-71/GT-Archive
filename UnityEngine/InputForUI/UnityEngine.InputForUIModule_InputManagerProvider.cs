using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IntegerTime;

namespace UnityEngine.InputForUI;

internal class InputManagerProvider : IEventProviderImpl
{
	private struct ButtonEventsIterator : IEnumerator
	{
		private uint _mask;

		private int _bit;

		private const uint kWasPressed = 1u;

		private const uint kWasReleased = 2u;

		private const int kMaxBits = 4;

		public bool Current => _bit % 2 == 0;

		object IEnumerator.Current => Current;

		public bool MoveNext()
		{
			do
			{
				_bit++;
				if ((_mask & (uint)(1 << _bit)) != 0)
				{
					return true;
				}
			}
			while (_bit < 4);
			return false;
		}

		public void Reset()
		{
			_bit = -1;
		}

		public static ButtonEventsIterator FromState(bool previous, bool down, bool up, bool current)
		{
			uint mask = ((!previous && current) ? 1u : ((previous && !current) ? 2u : 0u));
			return new ButtonEventsIterator
			{
				_mask = mask,
				_bit = -1
			};
		}
	}

	public struct Configuration
	{
		public string HorizontalAxis;

		public string VerticalAxis;

		public string SubmitButton;

		public string CancelButton;

		public string NavigateNextButton;

		public string NavigatePreviousButton;

		public float InputActionsPerSecond;

		public float RepeatDelay;

		public static Configuration GetDefaultConfiguration()
		{
			return new Configuration
			{
				HorizontalAxis = "Horizontal",
				VerticalAxis = "Vertical",
				SubmitButton = "Submit",
				CancelButton = "Cancel",
				NavigateNextButton = "Next",
				NavigatePreviousButton = "Previous",
				InputActionsPerSecond = 10f,
				RepeatDelay = 0.5f
			};
		}
	}

	internal interface IInput
	{
		string compositionString { get; }

		bool touchSupported { get; }

		int touchCount { get; }

		bool mousePresent { get; }

		Vector3 mousePosition { get; }

		Vector2 mouseScrollDelta { get; }

		bool GetKey(KeyCode keyCode);

		bool GetKeyDown(KeyCode keyCode);

		bool GetButtonDown(string button);

		float GetAxisRaw(string axis);

		PenData GetPenEvent(int index);

		PenData GetLastPenContactEvent();

		Touch GetTouch(int index);

		bool GetMouseButton(int button);

		bool GetMouseButtonDown(int button);

		bool GetMouseButtonUp(int button);
	}

	private class Input : IInput
	{
		public string compositionString => UnityEngine.Input.compositionString;

		public bool touchSupported => UnityEngine.Input.touchSupported;

		public int touchCount => UnityEngine.Input.touchCount;

		public bool mousePresent => UnityEngine.Input.mousePresent;

		public Vector3 mousePosition => UnityEngine.Input.mousePosition;

		public Vector2 mouseScrollDelta => UnityEngine.Input.mouseScrollDelta;

		public bool GetKey(KeyCode key)
		{
			return UnityEngine.Input.GetKey(key);
		}

		public bool GetKeyDown(KeyCode key)
		{
			return UnityEngine.Input.GetKeyDown(key);
		}

		public bool GetButtonDown(string button)
		{
			return UnityEngine.Input.GetButtonDown(button);
		}

		public float GetAxisRaw(string axis)
		{
			return UnityEngine.Input.GetAxisRaw(axis);
		}

		public PenData GetPenEvent(int index)
		{
			return UnityEngine.Input.GetPenEvent(index);
		}

		public PenData GetLastPenContactEvent()
		{
			return UnityEngine.Input.GetLastPenContactEvent();
		}

		public Touch GetTouch(int index)
		{
			return UnityEngine.Input.GetTouch(index);
		}

		public bool GetMouseButton(int button)
		{
			return UnityEngine.Input.GetMouseButton(button);
		}

		public bool GetMouseButtonDown(int button)
		{
			return UnityEngine.Input.GetMouseButtonDown(button);
		}

		public bool GetMouseButtonUp(int button)
		{
			return UnityEngine.Input.GetMouseButtonUp(button);
		}
	}

	internal interface ITime
	{
		RationalTime timeAsRational { get; }
	}

	private class Time : ITime
	{
		public RationalTime timeAsRational => UnityEngine.Time.timeAsRational;
	}

	private InputEventPartialProvider _inputEventPartialProvider;

	private const int kDefaultPlayerId = 0;

	private string _compositionString = string.Empty;

	private Configuration _configuration = Configuration.GetDefaultConfiguration();

	private IInput _input = new Input();

	private ITime _time = new Time();

	private NavigationEventRepeatHelper _navigationEventRepeatHelper = new NavigationEventRepeatHelper();

	private const int kMaxMouseButtons = 5;

	private PointerState _mouseState;

	private bool _isPenPresent;

	private bool _seenAtLeastOnePenPosition;

	private Vector2 _lastSeenPenPositionForDetection;

	private PointerState _penState;

	private PenData _lastPenData;

	private Dictionary<int, int> _touchFingerIdToFingerIndex = new Dictionary<int, int>();

	private int _touchNextFingerIndex;

	private PointerState _touchState;

	private const float kSmallestReportedMovementSqrDist = 0.01f;

	private const float kScrollUGUIScaleFactor = 3f;

	private EventModifiers _eventModifiers => _inputEventPartialProvider._eventModifiers;

	public uint playerCount => 1u;

	public InputManagerProvider()
	{
	}

	internal InputManagerProvider(IInput inputOverride, ITime timeOverride)
	{
		_input = inputOverride;
		_time = timeOverride;
	}

	public void Initialize()
	{
		if (_inputEventPartialProvider == null)
		{
			_inputEventPartialProvider = new InputEventPartialProvider();
		}
		_inputEventPartialProvider.Initialize();
		_inputEventPartialProvider._sendNavigationEventOnTabKey = true;
		_mouseState.Reset();
		_isPenPresent = false;
		_seenAtLeastOnePenPosition = false;
		_lastSeenPenPositionForDetection = default(Vector2);
		_penState.Reset();
		_lastPenData = default(PenData);
		_touchFingerIdToFingerIndex.Clear();
		_touchNextFingerIndex = 0;
		_touchState.Reset();
	}

	public void Shutdown()
	{
	}

	public void Update()
	{
		_inputEventPartialProvider.Update();
		DiscreteTime currentTime = (DiscreteTime)_time.timeAsRational;
		DetectPen();
		bool flag = false;
		if (_input.touchSupported)
		{
			flag = CheckTouchEvents(currentTime);
		}
		bool flag2 = false;
		if (!flag && _isPenPresent)
		{
			flag2 = CheckPenEvent(currentTime, _input.GetLastPenContactEvent());
		}
		else
		{
			_penState.Reset();
		}
		if (!flag2 && !flag && _input.mousePresent)
		{
			CheckMouseEvents(currentTime);
		}
		else
		{
			CheckMouseEvents(currentTime, muted: true);
			_mouseState.LastPositionValid = false;
		}
		if (_input.mousePresent)
		{
			CheckMouseScroll(currentTime);
		}
		CheckIfIMEChanged(currentTime);
		DirectionNavigation(currentTime);
		SubmitCancelNavigation(currentTime);
		NextPreviousNavigation(currentTime);
	}

	private bool CheckTouchEvents(DiscreteTime currentTime)
	{
		bool flag = true;
		bool result = false;
		for (int i = 0; i < _input.touchCount; i++)
		{
			Touch touch = _input.GetTouch(i);
			if (touch.type != TouchType.Indirect && touch.phase != TouchPhase.Stationary)
			{
				if (!_touchFingerIdToFingerIndex.TryGetValue(touch.fingerId, out var value))
				{
					value = _touchNextFingerIndex++;
					_touchFingerIdToFingerIndex.Add(touch.fingerId, value);
				}
				int targetDisplay;
				Vector2 position = MultiDisplayBottomLeftToPanelPosition(touch.position, out targetDisplay);
				Vector2 deltaPosition = ScreenBottomLeftToPanelDelta(touch.deltaPosition);
				PointerEvent.Type type = PointerEvent.Type.PointerMoved;
				PointerEvent.Button button = PointerEvent.Button.None;
				switch (touch.phase)
				{
				case TouchPhase.Began:
					type = PointerEvent.Type.ButtonPressed;
					button = PointerEvent.Button.Primary;
					flag = false;
					_touchState.OnButtonDown(currentTime, button);
					break;
				case TouchPhase.Ended:
					type = PointerEvent.Type.ButtonReleased;
					button = PointerEvent.Button.Primary;
					_touchState.OnButtonUp(currentTime, button);
					break;
				case TouchPhase.Canceled:
					type = PointerEvent.Type.TouchCanceled;
					button = PointerEvent.Button.Primary;
					_touchState.OnButtonUp(currentTime, button);
					break;
				case TouchPhase.Moved:
					flag = false;
					break;
				}
				EventProvider.Dispatch(Event.From(new PointerEvent
				{
					type = type,
					pointerIndex = value,
					position = position,
					deltaPosition = deltaPosition,
					scroll = Vector2.zero,
					displayIndex = targetDisplay,
					tilt = AzimuthAndAlitutudeToTilt(touch.altitudeAngle, touch.azimuthAngle),
					twist = 0f,
					pressure = ((Mathf.Abs(touch.maximumPossiblePressure) > Mathf.Epsilon) ? (touch.pressure / touch.maximumPossiblePressure) : 1f),
					isInverted = false,
					button = button,
					buttonsState = _touchState.ButtonsState,
					clickCount = _touchState.ClickCount,
					timestamp = currentTime,
					eventSource = EventSource.Touch,
					playerId = 0u,
					eventModifiers = _eventModifiers
				}));
				result = true;
			}
		}
		if (flag)
		{
			_touchNextFingerIndex = 0;
			_touchFingerIdToFingerIndex.Clear();
		}
		return result;
	}

	private void DetectPen()
	{
		if (!_isPenPresent)
		{
			Vector2 position = _input.GetLastPenContactEvent().position;
			if (_seenAtLeastOnePenPosition)
			{
				float sqrMagnitude = (position - _lastSeenPenPositionForDetection).sqrMagnitude;
				_isPenPresent = sqrMagnitude >= 0.01f;
			}
			else
			{
				_lastSeenPenPositionForDetection = position;
				_seenAtLeastOnePenPosition = true;
			}
		}
	}

	private static PointerEvent.Button PenStatusToButton(PenStatus status)
	{
		if ((status & PenStatus.Eraser) != PenStatus.None)
		{
			return PointerEvent.Button.PenEraserInTouch;
		}
		if ((status & PenStatus.Barrel) != PenStatus.None)
		{
			return PointerEvent.Button.PenBarrelButton;
		}
		return PointerEvent.Button.Primary;
	}

	private bool CheckPenEvent(DiscreteTime currentTime, in PenData currentPenData)
	{
		Vector2 position = currentPenData.position;
		int displayIndex = 0;
		Vector2 deltaPosition = (_penState.LastPositionValid ? (position - _penState.LastPosition) : Vector2.zero);
		PointerEvent.Button button = PointerEvent.Button.None;
		PointerEvent.Type type;
		if (currentPenData.contactType != _lastPenData.contactType)
		{
			switch (currentPenData.contactType)
			{
			case PenEventType.PenDown:
				type = PointerEvent.Type.ButtonPressed;
				button = PenStatusToButton(currentPenData.penStatus);
				_penState.OnButtonDown(currentTime, button);
				break;
			case PenEventType.PenUp:
				type = PointerEvent.Type.ButtonReleased;
				button = PenStatusToButton(_lastPenData.penStatus);
				_penState.OnButtonUp(currentTime, button);
				break;
			default:
				type = PointerEvent.Type.PointerMoved;
				break;
			}
		}
		else
		{
			type = PointerEvent.Type.PointerMoved;
		}
		_lastPenData = currentPenData;
		bool result = false;
		if (type != PointerEvent.Type.PointerMoved || !_penState.LastPositionValid || deltaPosition.sqrMagnitude >= 0.01f)
		{
			EventProvider.Dispatch(Event.From(new PointerEvent
			{
				type = type,
				pointerIndex = 0,
				position = position,
				deltaPosition = deltaPosition,
				scroll = Vector2.zero,
				displayIndex = displayIndex,
				tilt = currentPenData.tilt,
				twist = currentPenData.twist,
				pressure = currentPenData.pressure,
				isInverted = ((currentPenData.penStatus & PenStatus.Inverted) != 0),
				button = button,
				buttonsState = _penState.ButtonsState,
				clickCount = _penState.ClickCount,
				timestamp = currentTime,
				eventSource = EventSource.Pen,
				playerId = 0u,
				eventModifiers = _eventModifiers
			}));
			result = true;
		}
		_penState.OnMove(currentTime, position, displayIndex);
		return result;
	}

	private void CheckMouseEvents(DiscreteTime currentTime, bool muted = false)
	{
		int targetDisplay;
		Vector2 vector = MultiDisplayBottomLeftToPanelPosition(_input.mousePosition, out targetDisplay);
		if (_mouseState.LastPositionValid)
		{
			Vector2 deltaPosition = vector - _mouseState.LastPosition;
			if (deltaPosition.sqrMagnitude >= 0.01f)
			{
				if (!muted)
				{
					EventProvider.Dispatch(Event.From(new PointerEvent
					{
						type = PointerEvent.Type.PointerMoved,
						pointerIndex = 0,
						position = vector,
						deltaPosition = deltaPosition,
						scroll = Vector2.zero,
						displayIndex = targetDisplay,
						tilt = Vector2.zero,
						twist = 0f,
						pressure = 0f,
						isInverted = false,
						button = PointerEvent.Button.None,
						buttonsState = _mouseState.ButtonsState,
						clickCount = 0,
						timestamp = currentTime,
						eventSource = EventSource.Mouse,
						playerId = 0u,
						eventModifiers = _eventModifiers
					}));
				}
				_mouseState.OnMove(currentTime, vector, targetDisplay);
			}
		}
		else
		{
			_mouseState.OnMove(currentTime, vector, targetDisplay);
		}
		for (int i = 0; i < 5; i++)
		{
			PointerEvent.Button button = PointerEvent.ButtonFromButtonIndex(i);
			bool flag = _mouseState.ButtonsState.Get(button);
			bool mouseButtonDown = _input.GetMouseButtonDown(i);
			bool mouseButtonUp = _input.GetMouseButtonUp(i);
			bool mouseButton = _input.GetMouseButton(i);
			ButtonEventsIterator buttonEventsIterator = ButtonEventsIterator.FromState(flag, mouseButtonDown, mouseButtonUp, mouseButton);
			bool previousState = flag;
			while (buttonEventsIterator.MoveNext())
			{
				_mouseState.OnButtonChange(currentTime, button, previousState, buttonEventsIterator.Current);
				previousState = buttonEventsIterator.Current;
				if (!muted)
				{
					EventProvider.Dispatch(Event.From(new PointerEvent
					{
						type = (buttonEventsIterator.Current ? PointerEvent.Type.ButtonPressed : PointerEvent.Type.ButtonReleased),
						pointerIndex = 0,
						position = _mouseState.LastPosition,
						deltaPosition = Vector2.zero,
						scroll = Vector2.zero,
						displayIndex = _mouseState.LastDisplayIndex,
						tilt = Vector2.zero,
						twist = 0f,
						pressure = 0f,
						isInverted = false,
						button = button,
						buttonsState = _mouseState.ButtonsState,
						clickCount = _mouseState.ClickCount,
						timestamp = currentTime,
						eventSource = EventSource.Mouse,
						playerId = 0u,
						eventModifiers = _eventModifiers
					}));
				}
			}
		}
	}

	private void CheckMouseScroll(DiscreteTime currentTime)
	{
		Vector2 mouseScrollDelta = _input.mouseScrollDelta;
		if (!(mouseScrollDelta.sqrMagnitude < 0.01f))
		{
			int targetDisplay = 0;
			Vector2 position;
			if (_mouseState.LastPositionValid)
			{
				position = _mouseState.LastPosition;
				targetDisplay = _mouseState.LastDisplayIndex;
			}
			else
			{
				position = MultiDisplayBottomLeftToPanelPosition(_input.mousePosition, out targetDisplay);
			}
			mouseScrollDelta.x *= 3f;
			mouseScrollDelta.y *= -3f;
			EventProvider.Dispatch(Event.From(new PointerEvent
			{
				type = PointerEvent.Type.Scroll,
				pointerIndex = 0,
				position = position,
				deltaPosition = Vector2.zero,
				scroll = mouseScrollDelta,
				displayIndex = targetDisplay,
				tilt = Vector2.zero,
				twist = 0f,
				pressure = 0f,
				isInverted = false,
				button = PointerEvent.Button.None,
				buttonsState = _mouseState.ButtonsState,
				clickCount = 0,
				timestamp = currentTime,
				eventSource = EventSource.Mouse,
				playerId = 0u,
				eventModifiers = _eventModifiers
			}));
		}
	}

	private PointerEvent ToPointerStateEvent(DiscreteTime currentTime, in PointerState state, EventSource eventSource)
	{
		return new PointerEvent
		{
			type = PointerEvent.Type.State,
			pointerIndex = 0,
			position = state.LastPosition,
			deltaPosition = Vector2.zero,
			scroll = Vector2.zero,
			displayIndex = state.LastDisplayIndex,
			tilt = ((eventSource == EventSource.Pen) ? _lastPenData.tilt : Vector2.zero),
			twist = ((eventSource == EventSource.Pen) ? _lastPenData.twist : 0f),
			pressure = ((eventSource == EventSource.Pen) ? _lastPenData.pressure : 0f),
			isInverted = (eventSource == EventSource.Pen && (_lastPenData.penStatus & PenStatus.Inverted) != 0),
			button = PointerEvent.Button.None,
			buttonsState = state.ButtonsState,
			clickCount = 0,
			timestamp = currentTime,
			eventSource = eventSource,
			playerId = 0u,
			eventModifiers = _eventModifiers
		};
	}

	private void NextPreviousNavigation(DiscreteTime currentTime)
	{
		int num = (InputManagerGetButtonDownOrDefault(_configuration.NavigateNextButton) ? 1 : 0) + (InputManagerGetButtonDownOrDefault(_configuration.NavigatePreviousButton) ? (-1) : 0);
		if (num != 0)
		{
			if (_eventModifiers.isShiftPressed)
			{
				num = -num;
			}
			EventProvider.Dispatch(Event.From(new NavigationEvent
			{
				type = NavigationEvent.Type.Move,
				direction = ((num >= 0) ? NavigationEvent.Direction.Next : NavigationEvent.Direction.Previous),
				timestamp = currentTime,
				eventSource = GetEventSourceFromPressedKey(),
				playerId = 0u,
				eventModifiers = _eventModifiers
			}));
		}
	}

	private void SubmitCancelNavigation(DiscreteTime currentTime)
	{
		if (InputManagerGetButtonDownOrDefault(_configuration.SubmitButton))
		{
			EventProvider.Dispatch(Event.From(new NavigationEvent
			{
				type = NavigationEvent.Type.Submit,
				direction = NavigationEvent.Direction.None,
				timestamp = currentTime,
				eventSource = GetEventSourceFromPressedKey(),
				playerId = 0u,
				eventModifiers = _eventModifiers
			}));
		}
		if (InputManagerGetButtonDownOrDefault(_configuration.CancelButton))
		{
			EventProvider.Dispatch(Event.From(new NavigationEvent
			{
				type = NavigationEvent.Type.Cancel,
				direction = NavigationEvent.Direction.None,
				timestamp = currentTime,
				eventSource = GetEventSourceFromPressedKey(),
				playerId = 0u,
				eventModifiers = _eventModifiers
			}));
		}
	}

	private void DirectionNavigation(DiscreteTime currentTime)
	{
		(Vector2, bool) tuple = ReadCurrentNavigationMoveVector();
		Vector2 item = tuple.Item1;
		bool item2 = tuple.Item2;
		NavigationEvent.Direction direction = NavigationEvent.DetermineMoveDirection(item);
		if (direction == NavigationEvent.Direction.None)
		{
			_navigationEventRepeatHelper.Reset();
		}
		else if (_navigationEventRepeatHelper.ShouldSendMoveEvent(currentTime, direction, item2))
		{
			EventSource eventSource = GetEventSourceFromPressedKey();
			if (eventSource == EventSource.Unspecified && !item2)
			{
				eventSource = EventSource.Gamepad;
			}
			EventProvider.Dispatch(Event.From(new NavigationEvent
			{
				type = NavigationEvent.Type.Move,
				direction = direction,
				timestamp = currentTime,
				eventSource = eventSource,
				playerId = 0u,
				eventModifiers = _eventModifiers
			}));
		}
	}

	private void CheckIfIMEChanged(DiscreteTime currentTime)
	{
		string compositionString = _input.compositionString;
		if (_compositionString != compositionString)
		{
			_compositionString = compositionString;
			EventProvider.Dispatch(Event.From(ToIMECompositionEvent(currentTime, _compositionString)));
		}
	}

	public void OnFocusChanged(bool focus)
	{
		_inputEventPartialProvider.OnFocusChanged(focus);
	}

	public bool RequestCurrentState(Event.Type type)
	{
		if (_inputEventPartialProvider.RequestCurrentState(type))
		{
			return true;
		}
		DiscreteTime currentTime = (DiscreteTime)_time.timeAsRational;
		switch (type)
		{
		case Event.Type.PointerEvent:
			if (_touchState.LastPositionValid)
			{
				EventProvider.Dispatch(Event.From(ToPointerStateEvent(currentTime, in _touchState, EventSource.Touch)));
			}
			if (_penState.LastPositionValid)
			{
				EventProvider.Dispatch(Event.From(ToPointerStateEvent(currentTime, in _penState, EventSource.Pen)));
			}
			if (_mouseState.LastPositionValid)
			{
				EventProvider.Dispatch(Event.From(ToPointerStateEvent(currentTime, in _mouseState, EventSource.Mouse)));
			}
			return _touchState.LastPositionValid || _penState.LastPositionValid || _mouseState.LastPositionValid;
		case Event.Type.IMECompositionEvent:
			EventProvider.Dispatch(Event.From(ToIMECompositionEvent(currentTime, _compositionString)));
			return true;
		default:
			return false;
		}
	}

	private EventSource GetEventSourceFromPressedKey()
	{
		if (InputManagerKeyboardWasPressed())
		{
			return EventSource.Keyboard;
		}
		if (InputManagerJoystickWasPressed())
		{
			return EventSource.Gamepad;
		}
		return EventSource.Unspecified;
	}

	private bool InputManagerJoystickWasPressed()
	{
		for (KeyCode keyCode = KeyCode.Joystick1Button0; keyCode <= KeyCode.Joystick8Button19; keyCode++)
		{
			if (_input.GetKey(keyCode))
			{
				return true;
			}
		}
		return false;
	}

	private bool InputManagerKeyboardWasPressed()
	{
		for (KeyCode keyCode = KeyCode.None; keyCode <= KeyCode.Menu; keyCode++)
		{
			if (_input.GetKey(keyCode))
			{
				return true;
			}
		}
		return false;
	}

	private float InputManagerGetAxisRawOrDefault(string axisName)
	{
		try
		{
			return (!string.IsNullOrEmpty(axisName)) ? _input.GetAxisRaw(axisName) : 0f;
		}
		catch
		{
			return 0f;
		}
	}

	private bool InputManagerGetButtonDownOrDefault(string axisName)
	{
		try
		{
			return !string.IsNullOrEmpty(axisName) && _input.GetButtonDown(axisName);
		}
		catch
		{
			return false;
		}
	}

	private (Vector2, bool) ReadCurrentNavigationMoveVector()
	{
		Vector2 item = new Vector2(InputManagerGetAxisRawOrDefault(_configuration.HorizontalAxis), InputManagerGetAxisRawOrDefault(_configuration.VerticalAxis));
		bool item2 = false;
		if (InputManagerGetButtonDownOrDefault(_configuration.HorizontalAxis))
		{
			if (item.x < 0f)
			{
				item.x = -1f;
			}
			else if (item.x > 0f)
			{
				item.x = 1f;
			}
			item2 = true;
		}
		if (InputManagerGetButtonDownOrDefault(_configuration.VerticalAxis))
		{
			if (item.y < 0f)
			{
				item.y = -1f;
			}
			else if (item.y > 0f)
			{
				item.y = 1f;
			}
			item2 = true;
		}
		return (item, item2);
	}

	private IMECompositionEvent ToIMECompositionEvent(DiscreteTime currentTime, string compositionString)
	{
		return new IMECompositionEvent
		{
			compositionString = compositionString,
			timestamp = currentTime,
			eventSource = EventSource.Unspecified,
			playerId = 0u,
			eventModifiers = _eventModifiers
		};
	}

	internal static float TiltToAzimuth(Vector2 tilt)
	{
		float result = 0f;
		if (tilt.x != 0f)
		{
			result = MathF.PI / 2f - Mathf.Atan2((0f - Mathf.Cos(tilt.x)) * Mathf.Sin(tilt.y), Mathf.Cos(tilt.y) * Mathf.Sin(tilt.x));
			if (result < 0f)
			{
				result += MathF.PI * 2f;
			}
			result = ((!(result >= MathF.PI / 2f)) ? (result + 4.712389f) : (result - MathF.PI / 2f));
		}
		return result;
	}

	internal static Vector2 AzimuthAndAlitutudeToTilt(float altitude, float azimuth)
	{
		Vector2 result = new Vector2(0f, 0f);
		result.x = Mathf.Atan(Mathf.Cos(azimuth) * Mathf.Cos(altitude) / Mathf.Sin(azimuth));
		result.y = Mathf.Atan(Mathf.Cos(azimuth) * Mathf.Sin(altitude) / Mathf.Sin(azimuth));
		return result;
	}

	internal static float TiltToAltitude(Vector2 tilt)
	{
		return MathF.PI / 2f - Mathf.Acos(Mathf.Cos(tilt.x) * Mathf.Cos(tilt.y));
	}

	private static Vector2 MultiDisplayBottomLeftToPanelPosition(Vector2 position, out int targetDisplay)
	{
		int? targetDisplay2;
		Vector2 position2 = MultiDisplayToLocalScreenPosition(position, out targetDisplay2);
		targetDisplay = targetDisplay2.GetValueOrDefault();
		return ScreenBottomLeftToPanelPosition(position2, targetDisplay);
	}

	private static Vector2 MultiDisplayToLocalScreenPosition(Vector2 position, out int? targetDisplay)
	{
		Vector3 vector = Display.RelativeMouseAt(position);
		if (vector != Vector3.zero)
		{
			targetDisplay = (int)vector.z;
			return vector;
		}
		targetDisplay = null;
		return position;
	}

	private static Vector2 ScreenBottomLeftToPanelPosition(Vector2 position, int targetDisplay)
	{
		int num = Screen.height;
		if (targetDisplay > 0 && targetDisplay < Display.displays.Length)
		{
			num = Display.displays[targetDisplay].systemHeight;
		}
		position.y = (float)num - position.y;
		return position;
	}

	private static Vector2 ScreenBottomLeftToPanelDelta(Vector2 delta)
	{
		delta.y = 0f - delta.y;
		return delta;
	}
}
