using System;
using System.Runtime.CompilerServices;
using Unity.IntegerTime;
using UnityEngine.Bindings;

namespace UnityEngine.InputForUI;

[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal struct PointerEvent : IEventProperties
{
	public enum Type
	{
		PointerMoved = 1,
		Scroll = 2,
		ButtonPressed = 3,
		ButtonReleased = 4,
		State = 5,
		TouchCanceled = 6,
		TrackedCanceled = 6
	}

	[Flags]
	public enum Button : uint
	{
		None = 0u,
		Primary = 1u,
		FingerInTouch = 1u,
		PenTipInTouch = 1u,
		PenEraserInTouch = 2u,
		PenBarrelButton = 4u,
		MouseLeft = 1u,
		MouseRight = 2u,
		MouseMiddle = 4u,
		MouseForward = 8u,
		MouseBack = 0x10u
	}

	public struct ButtonsState
	{
		private uint _state;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(Button button, bool pressed)
		{
			if (pressed)
			{
				_state |= (uint)button;
			}
			else
			{
				_state &= (uint)(~button);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(Button button)
		{
			return (_state & (uint)button) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Reset()
		{
			_state = 0u;
		}

		public override string ToString()
		{
			return $"{_state:x2}";
		}
	}

	public Type type;

	public int pointerIndex;

	public Vector2 position;

	public Vector2 deltaPosition;

	public Vector3 worldPosition;

	public Quaternion worldOrientation;

	public float maxDistance;

	public Vector2 scroll;

	public int displayIndex;

	public Vector2 tilt;

	public float twist;

	public float pressure;

	public bool isInverted;

	public Button button;

	public ButtonsState buttonsState;

	public int clickCount;

	public bool isPrimaryPointer => pointerIndex == 0;

	public Ray worldRay => new Ray(worldPosition, worldOrientation * Vector3.forward);

	public float azimuth => InputManagerProvider.TiltToAzimuth(tilt);

	public float altitude => InputManagerProvider.TiltToAltitude(tilt);

	public bool isPressed => buttonsState.Get((!isInverted) ? Button.Primary : Button.PenEraserInTouch);

	public DiscreteTime timestamp { get; set; }

	public EventSource eventSource { get; set; }

	public uint playerId { get; set; }

	public EventModifiers eventModifiers { get; set; }

	public override string ToString()
	{
		string text = ((eventSource == EventSource.Pen) ? $" tilt:({tilt.x:f1},{tilt.y:f1}) az:{azimuth:f2} al:{altitude:f2} twist:{twist} pressure:{pressure} isInverted:{(isInverted ? 1 : 0)}" : "");
		string text2 = ((eventSource == EventSource.Touch) ? $" finger:{pointerIndex} tilt:({tilt.x:f1},{tilt.y:f1}) twist:{twist} pressure:{pressure}" : "");
		string text3 = $" dsp:{displayIndex}";
		string text4 = text + text2 + text3;
		switch (type)
		{
		case Type.PointerMoved:
			return $"{type} pos:{position} dlt:{deltaPosition} btns:{buttonsState}{text4}";
		case Type.Scroll:
			return $"{type} pos:{position} scr:{scroll}{text4}";
		case Type.ButtonPressed:
		case Type.ButtonReleased:
			return $"{type} pos:{position} btn:{button} btns:{buttonsState} clk:{clickCount}{text4}";
		case Type.State:
			return $"{type} pos:{position} btns:{buttonsState}{text4}";
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	internal static Button ButtonFromButtonIndex(int index)
	{
		return (index <= 31) ? ((Button)(1 << index)) : Button.None;
	}
}
