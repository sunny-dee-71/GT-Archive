using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.InputForUI;

[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal struct EventModifiers
{
	[Flags]
	public enum Modifiers : uint
	{
		LeftShift = 1u,
		RightShift = 2u,
		Shift = 3u,
		LeftCtrl = 4u,
		RightCtrl = 8u,
		Ctrl = 0xCu,
		LeftAlt = 0x10u,
		RightAlt = 0x20u,
		Alt = 0x30u,
		LeftMeta = 0x40u,
		RightMeta = 0x80u,
		Meta = 0xC0u,
		CapsLock = 0x100u,
		Numlock = 0x200u,
		FunctionKey = 0x400u,
		Numeric = 0x800u
	}

	private uint _state;

	public bool isShiftPressed => IsPressed(Modifiers.Shift);

	public bool isCtrlPressed => IsPressed(Modifiers.Ctrl);

	public bool isAltPressed => IsPressed(Modifiers.Alt);

	public bool isMetaPressed => IsPressed(Modifiers.Meta);

	public bool isCapsLockEnabled => IsPressed(Modifiers.CapsLock);

	public bool isNumLockEnabled => IsPressed(Modifiers.Numlock);

	public bool isFunctionKeyPressed => IsPressed(Modifiers.FunctionKey);

	public bool isNumericPressed => IsPressed(Modifiers.Numeric);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool IsPressed(Modifiers mod)
	{
		return (_state & (uint)mod) != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetPressed(Modifiers modifier, bool pressed)
	{
		if (pressed)
		{
			_state |= (uint)modifier;
		}
		else
		{
			_state &= (uint)(~modifier);
		}
	}

	public void Reset()
	{
		_state = 0u;
	}

	private static void Append(ref string str, string value)
	{
		str = (string.IsNullOrEmpty(str) ? value : (str + "," + value));
	}

	public override string ToString()
	{
		string str = string.Empty;
		if (IsPressed(Modifiers.LeftShift))
		{
			Append(ref str, "LeftShift");
		}
		if (IsPressed(Modifiers.RightShift))
		{
			Append(ref str, "RightShift");
		}
		if (IsPressed(Modifiers.LeftCtrl))
		{
			Append(ref str, "LeftCtrl");
		}
		if (IsPressed(Modifiers.RightCtrl))
		{
			Append(ref str, "RightCtrl");
		}
		if (IsPressed(Modifiers.LeftAlt))
		{
			Append(ref str, "LeftAlt");
		}
		if (IsPressed(Modifiers.RightAlt))
		{
			Append(ref str, "RightAlt");
		}
		if (IsPressed(Modifiers.LeftMeta))
		{
			Append(ref str, "LeftMeta");
		}
		if (IsPressed(Modifiers.RightMeta))
		{
			Append(ref str, "RightMeta");
		}
		if (IsPressed(Modifiers.CapsLock))
		{
			Append(ref str, "CapsLock");
		}
		if (IsPressed(Modifiers.Numlock))
		{
			Append(ref str, "Numlock");
		}
		if (IsPressed(Modifiers.FunctionKey))
		{
			Append(ref str, "FunctionKey");
		}
		if (IsPressed(Modifiers.Numeric))
		{
			Append(ref str, "Numeric");
		}
		return str;
	}
}
