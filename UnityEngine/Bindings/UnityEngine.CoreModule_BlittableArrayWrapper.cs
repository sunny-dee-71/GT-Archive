using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.Bindings;

[VisibleToOtherModules]
internal unsafe ref struct BlittableArrayWrapper(void* data, int size)
{
	internal enum UpdateFlags
	{
		NoUpdateNeeded,
		SizeChanged,
		DataIsNativePointer,
		DataIsNativeOwnedMemory,
		DataIsEmpty,
		DataIsNull
	}

	internal unsafe void* data = data;

	internal int size = size;

	internal UpdateFlags updateFlags = UpdateFlags.NoUpdateNeeded;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe void Unmarshal<T>(ref T[] array) where T : unmanaged
	{
		switch (updateFlags)
		{
		case UpdateFlags.NoUpdateNeeded:
			break;
		case UpdateFlags.SizeChanged:
		case UpdateFlags.DataIsNativePointer:
			array = new Span<T>(data, size).ToArray();
			break;
		case UpdateFlags.DataIsNativeOwnedMemory:
			array = new Span<T>(BindingsAllocator.GetNativeOwnedDataPointer(data), size).ToArray();
			BindingsAllocator.FreeNativeOwnedMemory(data);
			break;
		case UpdateFlags.DataIsEmpty:
			array = Array.Empty<T>();
			break;
		case UpdateFlags.DataIsNull:
			array = null;
			break;
		}
	}
}
