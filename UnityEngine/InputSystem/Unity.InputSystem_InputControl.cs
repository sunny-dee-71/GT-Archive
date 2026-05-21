using System;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.InputSystem.Utilities;

namespace UnityEngine.InputSystem;

public abstract class InputControl<TValue> : InputControl where TValue : struct
{
	internal InlinedArray<InputProcessor<TValue>> m_ProcessorStack;

	private TValue m_CachedValue;

	private TValue m_UnprocessedCachedValue;

	internal bool evaluateProcessorsEveryRead;

	public override Type valueType => typeof(TValue);

	public override int valueSizeInBytes => UnsafeUtility.SizeOf<TValue>();

	public ref readonly TValue value
	{
		get
		{
			if (!InputSystem.s_Manager.readValueCachingFeatureEnabled || m_CachedValueIsStale || evaluateProcessorsEveryRead)
			{
				m_CachedValue = ProcessValue(unprocessedValue);
				m_CachedValueIsStale = false;
			}
			return ref m_CachedValue;
		}
	}

	internal unsafe ref readonly TValue unprocessedValue
	{
		get
		{
			if (base.currentStatePtr == null)
			{
				return ref m_UnprocessedCachedValue;
			}
			if (!InputSystem.s_Manager.readValueCachingFeatureEnabled || m_UnprocessedCachedValueIsStale)
			{
				m_UnprocessedCachedValue = ReadUnprocessedValueFromState(base.currentStatePtr);
				m_UnprocessedCachedValueIsStale = false;
			}
			return ref m_UnprocessedCachedValue;
		}
	}

	internal InputProcessor<TValue>[] processors => m_ProcessorStack.ToArray();

	public TValue ReadValue()
	{
		return value;
	}

	public unsafe TValue ReadValueFromPreviousFrame()
	{
		return ReadValueFromState(base.previousFrameStatePtr);
	}

	public unsafe TValue ReadDefaultValue()
	{
		return ReadValueFromState(base.defaultStatePtr);
	}

	public unsafe TValue ReadValueFromState(void* statePtr)
	{
		if (statePtr == null)
		{
			throw new ArgumentNullException("statePtr");
		}
		return ProcessValue(ReadUnprocessedValueFromState(statePtr));
	}

	public unsafe TValue ReadValueFromStateWithCaching(void* statePtr)
	{
		if (statePtr != base.currentStatePtr)
		{
			return ReadValueFromState(statePtr);
		}
		return value;
	}

	public unsafe TValue ReadUnprocessedValueFromStateWithCaching(void* statePtr)
	{
		if (statePtr != base.currentStatePtr)
		{
			return ReadUnprocessedValueFromState(statePtr);
		}
		return unprocessedValue;
	}

	public TValue ReadUnprocessedValue()
	{
		return unprocessedValue;
	}

	public unsafe abstract TValue ReadUnprocessedValueFromState(void* statePtr);

	public unsafe override object ReadValueFromStateAsObject(void* statePtr)
	{
		return ReadValueFromState(statePtr);
	}

	public unsafe override void ReadValueFromStateIntoBuffer(void* statePtr, void* bufferPtr, int bufferSize)
	{
		if (statePtr == null)
		{
			throw new ArgumentNullException("statePtr");
		}
		if (bufferPtr == null)
		{
			throw new ArgumentNullException("bufferPtr");
		}
		int num = UnsafeUtility.SizeOf<TValue>();
		if (bufferSize < num)
		{
			throw new ArgumentException($"bufferSize={bufferSize} < sizeof(TValue)={num}", "bufferSize");
		}
		TValue output = ReadValueFromState(statePtr);
		void* source = UnsafeUtility.AddressOf(ref output);
		UnsafeUtility.MemCpy(bufferPtr, source, num);
	}

	public unsafe override void WriteValueFromBufferIntoState(void* bufferPtr, int bufferSize, void* statePtr)
	{
		if (bufferPtr == null)
		{
			throw new ArgumentNullException("bufferPtr");
		}
		if (statePtr == null)
		{
			throw new ArgumentNullException("statePtr");
		}
		int num = UnsafeUtility.SizeOf<TValue>();
		if (bufferSize < num)
		{
			throw new ArgumentException($"bufferSize={bufferSize} < sizeof(TValue)={num}", "bufferSize");
		}
		TValue output = default(TValue);
		UnsafeUtility.MemCpy(UnsafeUtility.AddressOf(ref output), bufferPtr, num);
		WriteValueIntoState(output, statePtr);
	}

	public unsafe override void WriteValueFromObjectIntoState(object value, void* statePtr)
	{
		if (statePtr == null)
		{
			throw new ArgumentNullException("statePtr");
		}
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		if (!(value is TValue))
		{
			value = Convert.ChangeType(value, typeof(TValue));
		}
		TValue val = (TValue)value;
		WriteValueIntoState(val, statePtr);
	}

	public unsafe virtual void WriteValueIntoState(TValue value, void* statePtr)
	{
		throw new NotSupportedException($"Control '{this}' does not support writing");
	}

	public unsafe override object ReadValueFromBufferAsObject(void* buffer, int bufferSize)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		int num = UnsafeUtility.SizeOf<TValue>();
		if (bufferSize < num)
		{
			throw new ArgumentException($"Expecting buffer of at least {num} bytes for value of type {typeof(TValue).Name} but got buffer of only {bufferSize} bytes instead", "bufferSize");
		}
		TValue output = default(TValue);
		UnsafeUtility.MemCpy(UnsafeUtility.AddressOf(ref output), buffer, num);
		return output;
	}

	private unsafe static bool CompareValue(ref TValue firstValue, ref TValue secondValue)
	{
		void* ptr = UnsafeUtility.AddressOf(ref firstValue);
		void* ptr2 = UnsafeUtility.AddressOf(ref secondValue);
		return UnsafeUtility.MemCmp(ptr, ptr2, UnsafeUtility.SizeOf<TValue>()) != 0;
	}

	public unsafe override bool CompareValue(void* firstStatePtr, void* secondStatePtr)
	{
		TValue firstValue = ReadValueFromState(firstStatePtr);
		TValue secondValue = ReadValueFromState(secondStatePtr);
		return CompareValue(ref firstValue, ref secondValue);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public TValue ProcessValue(TValue value)
	{
		ProcessValue(ref value);
		return value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ProcessValue(ref TValue value)
	{
		if (m_ProcessorStack.length <= 0)
		{
			return;
		}
		value = m_ProcessorStack.firstValue.Process(value, this);
		if (m_ProcessorStack.additionalValues != null)
		{
			for (int i = 0; i < m_ProcessorStack.length - 1; i++)
			{
				value = m_ProcessorStack.additionalValues[i].Process(value, this);
			}
		}
	}

	internal TProcessor TryGetProcessor<TProcessor>() where TProcessor : InputProcessor<TValue>
	{
		if (m_ProcessorStack.length > 0)
		{
			if (m_ProcessorStack.firstValue is TProcessor result)
			{
				return result;
			}
			if (m_ProcessorStack.additionalValues != null)
			{
				for (int i = 0; i < m_ProcessorStack.length - 1; i++)
				{
					if (m_ProcessorStack.additionalValues[i] is TProcessor result2)
					{
						return result2;
					}
				}
			}
		}
		return null;
	}

	internal override void AddProcessor(object processor)
	{
		if (!(processor is InputProcessor<TValue> inputProcessor))
		{
			throw new ArgumentException("Cannot add processor of type '" + processor.GetType().Name + "' to control of type '" + GetType().Name + "'", "processor");
		}
		m_ProcessorStack.Append(inputProcessor);
	}

	protected override void FinishSetup()
	{
		foreach (InputProcessor<TValue> item in m_ProcessorStack)
		{
			if (item.cachingPolicy == InputProcessor.CachingPolicy.EvaluateOnEveryRead)
			{
				evaluateProcessorsEveryRead = true;
			}
		}
		base.FinishSetup();
	}
}
