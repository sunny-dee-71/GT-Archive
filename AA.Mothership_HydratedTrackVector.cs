using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class HydratedTrackVector : IDisposable, IEnumerable, IEnumerable<HydratedProgressionTrackResponse>
{
	public sealed class HydratedTrackVectorEnumerator : IEnumerator, IEnumerator<HydratedProgressionTrackResponse>, IDisposable
	{
		private HydratedTrackVector collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public HydratedProgressionTrackResponse Current
		{
			get
			{
				if (currentIndex == -1)
				{
					throw new InvalidOperationException("Enumeration not started.");
				}
				if (currentIndex > currentSize - 1)
				{
					throw new InvalidOperationException("Enumeration finished.");
				}
				if (currentObject == null)
				{
					throw new InvalidOperationException("Collection modified.");
				}
				return (HydratedProgressionTrackResponse)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public HydratedTrackVectorEnumerator(HydratedTrackVector collection)
		{
			collectionRef = collection;
			currentIndex = -1;
			currentObject = null;
			currentSize = collectionRef.Count;
		}

		public bool MoveNext()
		{
			int count = collectionRef.Count;
			int num;
			if (currentIndex + 1 < count)
			{
				num = ((count == currentSize) ? 1 : 0);
				if (num != 0)
				{
					currentIndex++;
					currentObject = collectionRef[currentIndex];
					return (byte)num != 0;
				}
			}
			else
			{
				num = 0;
			}
			currentObject = null;
			return (byte)num != 0;
		}

		public void Reset()
		{
			currentIndex = -1;
			currentObject = null;
			if (collectionRef.Count != currentSize)
			{
				throw new InvalidOperationException("Collection modified.");
			}
		}

		public void Dispose()
		{
			currentIndex = -1;
			currentObject = null;
		}
	}

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public bool IsFixedSize => false;

	public bool IsReadOnly => false;

	public HydratedProgressionTrackResponse this[int index]
	{
		get
		{
			return getitem(index);
		}
		set
		{
			setitem(index, value);
		}
	}

	public int Capacity
	{
		get
		{
			return (int)capacity();
		}
		set
		{
			if (value < 0 || (uint)value < size())
			{
				throw new ArgumentOutOfRangeException("Capacity");
			}
			reserve((uint)value);
		}
	}

	public int Count => (int)size();

	public bool IsSynchronized => false;

	internal HydratedTrackVector(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(HydratedTrackVector obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	internal static HandleRef swigRelease(HydratedTrackVector obj)
	{
		if (obj != null)
		{
			if (!obj.swigCMemOwn)
			{
				throw new ApplicationException("Cannot release ownership as memory is not owned");
			}
			HandleRef result = obj.swigCPtr;
			obj.swigCMemOwn = false;
			obj.Dispose();
			return result;
		}
		return new HandleRef(null, IntPtr.Zero);
	}

	~HydratedTrackVector()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					MothershipApiPINVOKE.delete_HydratedTrackVector(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public HydratedTrackVector(IEnumerable c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (HydratedProgressionTrackResponse item in c)
		{
			Add(item);
		}
	}

	public HydratedTrackVector(IEnumerable<HydratedProgressionTrackResponse> c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (HydratedProgressionTrackResponse item in c)
		{
			Add(item);
		}
	}

	public void CopyTo(HydratedProgressionTrackResponse[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(HydratedProgressionTrackResponse[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, HydratedProgressionTrackResponse[] array, int arrayIndex, int count)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index", "Value is less than zero");
		}
		if (arrayIndex < 0)
		{
			throw new ArgumentOutOfRangeException("arrayIndex", "Value is less than zero");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count", "Value is less than zero");
		}
		if (array.Rank > 1)
		{
			throw new ArgumentException("Multi dimensional array.", "array");
		}
		if (index + count > Count || arrayIndex + count > array.Length)
		{
			throw new ArgumentException("Number of elements to copy is too large.");
		}
		for (int i = 0; i < count; i++)
		{
			array.SetValue(getitemcopy(index + i), arrayIndex + i);
		}
	}

	public HydratedProgressionTrackResponse[] ToArray()
	{
		HydratedProgressionTrackResponse[] array = new HydratedProgressionTrackResponse[Count];
		CopyTo(array);
		return array;
	}

	IEnumerator<HydratedProgressionTrackResponse> IEnumerable<HydratedProgressionTrackResponse>.GetEnumerator()
	{
		return new HydratedTrackVectorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new HydratedTrackVectorEnumerator(this);
	}

	public HydratedTrackVectorEnumerator GetEnumerator()
	{
		return new HydratedTrackVectorEnumerator(this);
	}

	public void Clear()
	{
		MothershipApiPINVOKE.HydratedTrackVector_Clear(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(HydratedProgressionTrackResponse x)
	{
		MothershipApiPINVOKE.HydratedTrackVector_Add(swigCPtr, HydratedProgressionTrackResponse.getCPtr(x));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = MothershipApiPINVOKE.HydratedTrackVector_size(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = MothershipApiPINVOKE.HydratedTrackVector_capacity(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		MothershipApiPINVOKE.HydratedTrackVector_reserve(swigCPtr, n);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public HydratedTrackVector()
		: this(MothershipApiPINVOKE.new_HydratedTrackVector__SWIG_0(), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public HydratedTrackVector(HydratedTrackVector other)
		: this(MothershipApiPINVOKE.new_HydratedTrackVector__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public HydratedTrackVector(int capacity)
		: this(MothershipApiPINVOKE.new_HydratedTrackVector__SWIG_2(capacity), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private HydratedProgressionTrackResponse getitemcopy(int index)
	{
		HydratedProgressionTrackResponse result = new HydratedProgressionTrackResponse(MothershipApiPINVOKE.HydratedTrackVector_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private HydratedProgressionTrackResponse getitem(int index)
	{
		HydratedProgressionTrackResponse result = new HydratedProgressionTrackResponse(MothershipApiPINVOKE.HydratedTrackVector_getitem(swigCPtr, index), cMemoryOwn: false);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, HydratedProgressionTrackResponse val)
	{
		MothershipApiPINVOKE.HydratedTrackVector_setitem(swigCPtr, index, HydratedProgressionTrackResponse.getCPtr(val));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(HydratedTrackVector values)
	{
		MothershipApiPINVOKE.HydratedTrackVector_AddRange(swigCPtr, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public HydratedTrackVector GetRange(int index, int count)
	{
		IntPtr intPtr = MothershipApiPINVOKE.HydratedTrackVector_GetRange(swigCPtr, index, count);
		HydratedTrackVector result = ((intPtr == IntPtr.Zero) ? null : new HydratedTrackVector(intPtr, cMemoryOwn: true));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, HydratedProgressionTrackResponse x)
	{
		MothershipApiPINVOKE.HydratedTrackVector_Insert(swigCPtr, index, HydratedProgressionTrackResponse.getCPtr(x));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, HydratedTrackVector values)
	{
		MothershipApiPINVOKE.HydratedTrackVector_InsertRange(swigCPtr, index, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		MothershipApiPINVOKE.HydratedTrackVector_RemoveAt(swigCPtr, index);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		MothershipApiPINVOKE.HydratedTrackVector_RemoveRange(swigCPtr, index, count);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static HydratedTrackVector Repeat(HydratedProgressionTrackResponse value, int count)
	{
		IntPtr intPtr = MothershipApiPINVOKE.HydratedTrackVector_Repeat(HydratedProgressionTrackResponse.getCPtr(value), count);
		HydratedTrackVector result = ((intPtr == IntPtr.Zero) ? null : new HydratedTrackVector(intPtr, cMemoryOwn: true));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		MothershipApiPINVOKE.HydratedTrackVector_Reverse__SWIG_0(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		MothershipApiPINVOKE.HydratedTrackVector_Reverse__SWIG_1(swigCPtr, index, count);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, HydratedTrackVector values)
	{
		MothershipApiPINVOKE.HydratedTrackVector_SetRange(swigCPtr, index, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
