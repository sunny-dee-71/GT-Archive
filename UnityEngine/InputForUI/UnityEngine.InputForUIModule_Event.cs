#define UNITY_ASSERTIONS
using System;
using System.Runtime.InteropServices;
using Unity.IntegerTime;
using UnityEngine.Bindings;

namespace UnityEngine.InputForUI;

[StructLayout(LayoutKind.Explicit)]
[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal struct Event : IEventProperties
{
	public enum Type
	{
		Invalid,
		KeyEvent,
		PointerEvent,
		TextInputEvent,
		IMECompositionEvent,
		CommandEvent,
		NavigationEvent
	}

	private interface IMapFn<TOutputType>
	{
		TOutputType Map<TEventType>(ref TEventType ev) where TEventType : IEventProperties;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct MapAsObject : IMapFn<IEventProperties>
	{
		public IEventProperties Map<TEventType>(ref TEventType ev) where TEventType : IEventProperties
		{
			return ev;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct MapAsTimestamp : IMapFn<DiscreteTime>
	{
		public DiscreteTime Map<TEventType>(ref TEventType ev) where TEventType : IEventProperties
		{
			return ev.timestamp;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct MapAsEventSource : IMapFn<EventSource>
	{
		public EventSource Map<TEventType>(ref TEventType ev) where TEventType : IEventProperties
		{
			return ev.eventSource;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct MapAsPlayerId : IMapFn<uint>
	{
		public uint Map<TEventType>(ref TEventType ev) where TEventType : IEventProperties
		{
			return ev.playerId;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct MapAsEventModifiers : IMapFn<EventModifiers>
	{
		public EventModifiers Map<TEventType>(ref TEventType ev) where TEventType : IEventProperties
		{
			return ev.eventModifiers;
		}
	}

	public static Type[] TypesWithState = new Type[3]
	{
		Type.KeyEvent,
		Type.PointerEvent,
		Type.IMECompositionEvent
	};

	private const int kManagedOffset = 8;

	private const int kUnmanagedOffset = 16;

	[FieldOffset(0)]
	private Type _type;

	[FieldOffset(8)]
	private object _managedEvent;

	[FieldOffset(16)]
	private KeyEvent _keyEvent;

	[FieldOffset(16)]
	private PointerEvent _pointerEvent;

	[FieldOffset(16)]
	private TextInputEvent _textInputEvent;

	[FieldOffset(16)]
	private CommandEvent _commandEvent;

	[FieldOffset(16)]
	private NavigationEvent _navigationEvent;

	public Type type => _type;

	private IEventProperties asObject => Map<IEventProperties, MapAsObject>();

	public DiscreteTime timestamp => Map<DiscreteTime, MapAsTimestamp>();

	public EventSource eventSource => Map<EventSource, MapAsEventSource>();

	public uint playerId => Map<uint, MapAsPlayerId>();

	public EventModifiers eventModifiers => Map<EventModifiers, MapAsEventModifiers>();

	public KeyEvent asKeyEvent
	{
		get
		{
			Ensure(Type.KeyEvent);
			return _keyEvent;
		}
	}

	public PointerEvent asPointerEvent
	{
		get
		{
			Ensure(Type.PointerEvent);
			return _pointerEvent;
		}
	}

	public TextInputEvent asTextInputEvent
	{
		get
		{
			Ensure(Type.TextInputEvent);
			return _textInputEvent;
		}
	}

	public IMECompositionEvent asIMECompositionEvent
	{
		get
		{
			Ensure(Type.IMECompositionEvent);
			return (IMECompositionEvent)_managedEvent;
		}
	}

	public CommandEvent asCommandEvent
	{
		get
		{
			Ensure(Type.CommandEvent);
			return _commandEvent;
		}
	}

	public NavigationEvent asNavigationEvent
	{
		get
		{
			Ensure(Type.NavigationEvent);
			return _navigationEvent;
		}
	}

	internal static int CompareType(Event a, Event b)
	{
		if (a.type == Type.PointerEvent && b.type == Type.PointerEvent)
		{
			int value = (int)a.eventSource;
			return ((int)b.eventSource).CompareTo(value);
		}
		int num = (int)a.type;
		int value2 = (int)b.type;
		return num.CompareTo(value2);
	}

	private void Ensure(Type t)
	{
		Debug.Assert(type == t);
	}

	public override string ToString()
	{
		string text = eventModifiers.ToString();
		if (!string.IsNullOrEmpty(text))
		{
			text = " ev:" + text;
		}
		return (type == Type.Invalid) ? "Invalid" : $"{asObject}{text} src:{eventSource.ToString()}";
	}

	public static Event From(KeyEvent keyEvent)
	{
		return new Event
		{
			_type = Type.KeyEvent,
			_keyEvent = keyEvent
		};
	}

	public static Event From(PointerEvent pointerEvent)
	{
		return new Event
		{
			_type = Type.PointerEvent,
			_pointerEvent = pointerEvent
		};
	}

	public static Event From(TextInputEvent textInputEvent)
	{
		return new Event
		{
			_type = Type.TextInputEvent,
			_textInputEvent = textInputEvent
		};
	}

	public static Event From(IMECompositionEvent imeCompositionEvent)
	{
		return new Event
		{
			_type = Type.IMECompositionEvent,
			_managedEvent = imeCompositionEvent
		};
	}

	public static Event From(CommandEvent commandEvent)
	{
		return new Event
		{
			_type = Type.CommandEvent,
			_commandEvent = commandEvent
		};
	}

	public static Event From(NavigationEvent navigationEvent)
	{
		return new Event
		{
			_type = Type.NavigationEvent,
			_navigationEvent = navigationEvent
		};
	}

	private TOutputType Map<TOutputType, TMapType>(TMapType fn) where TMapType : IMapFn<TOutputType>
	{
		switch (type)
		{
		case Type.Invalid:
			return default(TOutputType);
		case Type.KeyEvent:
		{
			ref KeyEvent keyEvent = ref _keyEvent;
			return fn.Map(ref keyEvent);
		}
		case Type.PointerEvent:
		{
			ref PointerEvent pointerEvent = ref _pointerEvent;
			return fn.Map(ref pointerEvent);
		}
		case Type.TextInputEvent:
		{
			ref TextInputEvent textInputEvent = ref _textInputEvent;
			return fn.Map(ref textInputEvent);
		}
		case Type.IMECompositionEvent:
		{
			IMECompositionEvent ev = (IMECompositionEvent)_managedEvent;
			return fn.Map(ref ev);
		}
		case Type.CommandEvent:
		{
			ref CommandEvent commandEvent = ref _commandEvent;
			return fn.Map(ref commandEvent);
		}
		case Type.NavigationEvent:
		{
			ref NavigationEvent navigationEvent = ref _navigationEvent;
			return fn.Map(ref navigationEvent);
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private TOutputType Map<TOutputType, TMapType>() where TMapType : IMapFn<TOutputType>, new()
	{
		return Map<TOutputType, TMapType>(new TMapType());
	}
}
