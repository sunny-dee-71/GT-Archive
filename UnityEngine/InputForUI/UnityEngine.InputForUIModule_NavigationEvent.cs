using Unity.IntegerTime;
using UnityEngine.Bindings;

namespace UnityEngine.InputForUI;

[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal struct NavigationEvent : IEventProperties
{
	public enum Type
	{
		Move = 1,
		Submit,
		Cancel
	}

	public enum Direction
	{
		None,
		Left,
		Up,
		Right,
		Down,
		Next,
		Previous
	}

	public Type type;

	public Direction direction;

	public bool shouldBeUsed;

	public DiscreteTime timestamp { get; set; }

	public EventSource eventSource { get; set; }

	public uint playerId { get; set; }

	public EventModifiers eventModifiers { get; set; }

	public override string ToString()
	{
		return $"Navigation {type}" + ((type == Type.Move) ? $" {direction}" : "") + ((eventSource != EventSource.Keyboard) ? $" {eventSource}" : "");
	}

	internal static Direction DetermineMoveDirection(Vector2 vec, float deadZone = 0.6f)
	{
		if (vec.sqrMagnitude < deadZone * deadZone)
		{
			return Direction.None;
		}
		if (Mathf.Abs(vec.x) > Mathf.Abs(vec.y))
		{
			return (!(vec.x > 0f)) ? Direction.Left : Direction.Right;
		}
		return (vec.y > 0f) ? Direction.Up : Direction.Down;
	}
}
