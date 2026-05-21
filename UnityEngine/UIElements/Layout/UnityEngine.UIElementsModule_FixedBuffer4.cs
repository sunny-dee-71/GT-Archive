using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.UIElements.Layout;

[Serializable]
internal struct FixedBuffer4<T>(T x, T y, T z, T w) where T : unmanaged
{
	[SerializeField]
	private T __0 = x;

	[SerializeField]
	private T __1 = y;

	[SerializeField]
	private T __2 = z;

	[SerializeField]
	private T __3 = w;

	public const int Length = 4;

	public unsafe ref T this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0 || index >= 4)
			{
				throw new IndexOutOfRangeException("index");
			}
			fixed (FixedBuffer4<T>* ptr = &this)
			{
				void* ptr2 = ptr;
				T* ptr3 = (T*)ptr2;
				return ref ptr3[index];
			}
		}
	}
}
