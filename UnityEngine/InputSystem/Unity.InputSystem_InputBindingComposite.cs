using System;
using Unity.Collections.LowLevel.Unsafe;

namespace UnityEngine.InputSystem;

public abstract class InputBindingComposite<TValue> : InputBindingComposite where TValue : struct
{
	public override Type valueType => typeof(TValue);

	public override int valueSizeInBytes => UnsafeUtility.SizeOf<TValue>();

	public abstract TValue ReadValue(ref InputBindingCompositeContext context);

	public unsafe override void ReadValue(ref InputBindingCompositeContext context, void* buffer, int bufferSize)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		int num = UnsafeUtility.SizeOf<TValue>();
		if (bufferSize < num)
		{
			throw new ArgumentException($"Expected buffer of at least {UnsafeUtility.SizeOf<TValue>()} bytes but got buffer of only {bufferSize} bytes instead", "bufferSize");
		}
		TValue output = ReadValue(ref context);
		void* source = UnsafeUtility.AddressOf(ref output);
		UnsafeUtility.MemCpy(buffer, source, num);
	}

	public unsafe override object ReadValueAsObject(ref InputBindingCompositeContext context)
	{
		TValue output = default(TValue);
		void* buffer = UnsafeUtility.AddressOf(ref output);
		ReadValue(ref context, buffer, UnsafeUtility.SizeOf<TValue>());
		return output;
	}
}
