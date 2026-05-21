using Unity.IntegerTime;
using UnityEngine.Bindings;

namespace UnityEngine.InputForUI;

[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal struct CommandEvent : IEventProperties
{
	public enum Type
	{
		Validate = 1,
		Execute
	}

	public enum Command
	{
		Invalid,
		Cut,
		Copy,
		Paste,
		SelectAll,
		DeselectAll,
		InvertSelection,
		Duplicate,
		Rename,
		Delete,
		SoftDelete,
		Find,
		SelectChildren,
		SelectPrefabRoot,
		UndoRedoPerformed,
		OnLostFocus,
		NewKeyboardFocus,
		ModifierKeysChanged,
		EyeDropperUpdate,
		EyeDropperClicked,
		EyeDropperCancelled,
		ColorPickerChanged,
		FrameSelected,
		FrameSelectedWithLock
	}

	public Type type;

	public Command command;

	public DiscreteTime timestamp { get; set; }

	public EventSource eventSource { get; set; }

	public uint playerId { get; set; }

	public EventModifiers eventModifiers { get; set; }

	public override string ToString()
	{
		return $"{type} {command}";
	}
}
