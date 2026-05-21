using System;

namespace Fusion;

public static class FixedArray
{
	public unsafe static FixedArray<T> CreateFromFieldSequence<T>(ref T firstField, ref T lastField) where T : unmanaged
	{
		fixed (T* ptr = &firstField)
		{
			fixed (T* ptr2 = &lastField)
			{
				return new FixedArray<T>(ptr, (int)(ptr2 - ptr) + 1);
			}
		}
	}

	public unsafe static FixedArray<T> Create<T>(ref T firstField, int length) where T : unmanaged
	{
		fixed (T* array = &firstField)
		{
			return new FixedArray<T>(array, length);
		}
	}

	public unsafe static FixedArray<TAdapted> Create<TActual, TAdapted>(ref TActual firstField, int length) where TActual : unmanaged where TAdapted : unmanaged
	{
		fixed (TActual* array = &firstField)
		{
			return new FixedArray<TAdapted>((TAdapted*)array, length);
		}
	}

	public static int IndexOf<T>(this FixedArray<T> array, T elem) where T : unmanaged, IEquatable<T>
	{
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].Equals(elem))
			{
				return i;
			}
		}
		return -1;
	}
}
