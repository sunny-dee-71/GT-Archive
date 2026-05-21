using Unity.IntegerTime;

namespace UnityEngine.InputForUI;

internal struct PointerState
{
	private PointerEvent.ButtonsState _buttonsState;

	private static readonly DiscreteTime kClickDelay = new DiscreteTime((double)UnityEngine.Event.GetDoubleClickTime() / 1000.0);

	public PointerEvent.Button LastPressedButton { get; private set; }

	public PointerEvent.ButtonsState ButtonsState => _buttonsState;

	public DiscreteTime NextPressTime { get; private set; }

	public int ClickCount { get; private set; }

	public Vector2 LastPosition { get; private set; }

	public int LastDisplayIndex { get; private set; }

	public bool LastPositionValid { get; set; }

	public void OnButtonDown(DiscreteTime currentTime, PointerEvent.Button button)
	{
		if (LastPressedButton != button || currentTime >= NextPressTime)
		{
			ClickCount = 0;
		}
		LastPressedButton = button;
		_buttonsState.Set(button, pressed: true);
		ClickCount++;
		NextPressTime = currentTime + kClickDelay;
	}

	public void OnButtonUp(DiscreteTime currentTime, PointerEvent.Button button)
	{
		if (LastPressedButton != button)
		{
			ClickCount = 1;
		}
		_buttonsState.Set(button, pressed: false);
	}

	public void OnButtonChange(DiscreteTime currentTime, PointerEvent.Button button, bool previousState, bool newState)
	{
		if (newState && !previousState)
		{
			OnButtonDown(currentTime, button);
		}
		else if (!newState && previousState)
		{
			OnButtonUp(currentTime, button);
		}
	}

	public void OnMove(DiscreteTime currentTime, Vector2 position, int displayIndex)
	{
		LastPosition = position;
		LastDisplayIndex = displayIndex;
		LastPositionValid = true;
	}

	public void Reset()
	{
		LastPressedButton = PointerEvent.Button.None;
		ButtonsState.Reset();
		NextPressTime = DiscreteTime.Zero;
		ClickCount = 0;
		LastPosition = Vector2.zero;
		LastDisplayIndex = 0;
		LastPositionValid = false;
	}
}
