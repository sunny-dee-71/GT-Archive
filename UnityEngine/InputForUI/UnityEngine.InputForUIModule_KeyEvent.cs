using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.IntegerTime;
using UnityEngine.Bindings;

namespace UnityEngine.InputForUI;

[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal struct KeyEvent : IEventProperties
{
	public enum Type
	{
		KeyPressed = 1,
		KeyRepeated,
		KeyReleased,
		State
	}

	public struct ButtonsState
	{
		private const uint kMaxIndex = 319u;

		private const uint kSizeInBytes = 40u;

		private unsafe fixed byte buttons[40];

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool ShouldBeProcessed(KeyCode keyCode)
		{
			return (uint)keyCode <= 319u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe bool GetUnchecked(uint index)
		{
			return (buttons[index >> 3] & (byte)(1 << (int)(index & 7))) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void SetUnchecked(uint index)
		{
			ref byte reference = ref buttons[index >> 3];
			reference |= (byte)(1 << (int)(index & 7));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void ClearUnchecked(uint index)
		{
			ref byte reference = ref buttons[index >> 3];
			reference &= (byte)(~(1 << (int)(index & 7)));
		}

		public bool IsPressed(KeyCode keyCode)
		{
			return ShouldBeProcessed(keyCode) && GetUnchecked((uint)keyCode);
		}

		public IEnumerable<KeyCode> GetAllPressed()
		{
			uint index = 0u;
			while (index <= 319)
			{
				if (GetUnchecked(index))
				{
					yield return (KeyCode)index;
				}
				uint num = index + 1;
				index = num;
			}
		}

		public void SetPressed(KeyCode keyCode, bool pressed)
		{
			if (ShouldBeProcessed(keyCode))
			{
				if (pressed)
				{
					SetUnchecked((uint)keyCode);
				}
				else
				{
					ClearUnchecked((uint)keyCode);
				}
			}
		}

		public unsafe void Reset()
		{
			for (int i = 0; (long)i < 40L; i++)
			{
				buttons[i] = 0;
			}
		}

		public override string ToString()
		{
			return string.Join(",", GetAllPressed());
		}
	}

	public Type type;

	public KeyCode keyCode;

	public ButtonsState buttonsState;

	public DiscreteTime timestamp { get; set; }

	public EventSource eventSource { get; set; }

	public uint playerId { get; set; }

	public EventModifiers eventModifiers { get; set; }

	public override string ToString()
	{
		switch (type)
		{
		case Type.KeyPressed:
		case Type.KeyRepeated:
		case Type.KeyReleased:
			return $"{type} {keyCode}";
		case Type.State:
			return $"{type} Pressed:{buttonsState}";
		default:
			throw new ArgumentOutOfRangeException();
		}
	}
}
