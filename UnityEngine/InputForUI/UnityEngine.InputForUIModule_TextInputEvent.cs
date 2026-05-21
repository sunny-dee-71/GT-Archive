using Unity.IntegerTime;
using UnityEngine.Bindings;

namespace UnityEngine.InputForUI;

[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal struct TextInputEvent : IEventProperties
{
	public char character;

	public DiscreteTime timestamp { get; set; }

	public EventSource eventSource { get; set; }

	public uint playerId { get; set; }

	public EventModifiers eventModifiers { get; set; }

	public override string ToString()
	{
		string arg = ((character == '\0') ? string.Empty : character.ToString());
		return $"text input 0x{(int)character:x8} '{arg}'";
	}

	public static bool ShouldBeProcessed(char character)
	{
		return character > '\u001f' && character != '\u007f';
	}
}
