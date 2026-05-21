using Unity.IntegerTime;
using UnityEngine.Bindings;

namespace UnityEngine.InputForUI;

[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal struct IMECompositionEvent : IEventProperties
{
	public string compositionString;

	public DiscreteTime timestamp { get; set; }

	public EventSource eventSource { get; set; }

	public uint playerId { get; set; }

	public EventModifiers eventModifiers { get; set; }

	public override string ToString()
	{
		return "IME '" + compositionString + "'";
	}
}
