using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class ProgressionTreeBindingVector : IDisposable, IEnumerable, IEnumerable<ProgressionTreeBindingResponse>
{
	public sealed class ProgressionTreeBindingVectorEnumerator : IEnumerator, IEnumerator<ProgressionTreeBindingResponse>, IDisposable
	{
		private ProgressionTreeBindingVector collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public ProgressionTreeBindingResponse Current
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
				return (ProgressionTreeBindingResponse)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public ProgressionTreeBindingVectorEnumerator(ProgressionTreeBindingVector collection)
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

	public ProgressionTreeBindingResponse this[int index]
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

	internal ProgressionTreeBindingVector(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(ProgressionTreeBindingVector obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	internal static HandleRef swigRelease(ProgressionTreeBindingVector obj)
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

	~ProgressionTreeBindingVector()
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
					MothershipApiPINVOKE.delete_ProgressionTreeBindingVector(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public ProgressionTreeBindingVector(IEnumerable c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (ProgressionTreeBindingResponse item in c)
		{
			Add(item);
		}
	}

	public ProgressionTreeBindingVector(IEnumerable<ProgressionTreeBindingResponse> c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (ProgressionTreeBindingResponse item in c)
		{
			Add(item);
		}
	}

	public void CopyTo(ProgressionTreeBindingResponse[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(ProgressionTreeBindingResponse[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, ProgressionTreeBindingResponse[] array, int arrayIndex, int count)
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

	public ProgressionTreeBindingResponse[] ToArray()
	{
		ProgressionTreeBindingResponse[] array = new ProgressionTreeBindingResponse[Count];
		CopyTo(array);
		return array;
	}

	IEnumerator<ProgressionTreeBindingResponse> IEnumerable<ProgressionTreeBindingResponse>.GetEnumerator()
	{
		return new ProgressionTreeBindingVectorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new ProgressionTreeBindingVectorEnumerator(this);
	}

	public ProgressionTreeBindingVectorEnumerator GetEnumerator()
	{
		return new ProgressionTreeBindingVectorEnumerator(this);
	}

	public void Clear()
	{
		MothershipApiPINVOKE.ProgressionTreeBindingVector_Clear(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(ProgressionTreeBindingResponse x)
	{
		MothershipApiPINVOKE.ProgressionTreeBindingVector_Add(swigCPtr, ProgressionTreeBindingResponse.getCPtr(x));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = MothershipApiPINVOKE.ProgressionTreeBindingVector_size(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = MothershipApiPINVOKE.ProgressionTreeBindingVector_capacity(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		MothershipApiPINVOKE.ProgressionTreeBindingVector_reserve(swigCPtr, n);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ProgressionTreeBindingVector()
		: this(MothershipApiPINVOKE.new_ProgressionTreeBindingVector__SWIG_0(), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ProgressionTreeBindingVector(ProgressionTreeBindingVector other)
		: this(MothershipApiPINVOKE.new_ProgressionTreeBindingVector__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ProgressionTreeBindingVector(int capacity)
		: this(MothershipApiPINVOKE.new_ProgressionTreeBindingVector__SWIG_2(capacity), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private ProgressionTreeBindingResponse getitemcopy(int index)
	{
		ProgressionTreeBindingResponse result = new ProgressionTreeBindingResponse(MothershipApiPINVOKE.ProgressionTreeBindingVector_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private ProgressionTreeBindingResponse getitem(int index)
	{
		ProgressionTreeBindingResponse result = new ProgressionTreeBindingResponse(MothershipApiPINVOKE.ProgressionTreeBindingVector_getitem(swigCPtr, index), cMemoryOwn: false);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, ProgressionTreeBindingResponse val)
	{
		MothershipApiPINVOKE.ProgressionTreeBindingVector_setitem(swigCPtr, index, ProgressionTreeBindingResponse.getCPtr(val));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(ProgressionTreeBindingVector values)
	{
		MothershipApiPINVOKE.ProgressionTreeBindingVector_AddRange(swigCPtr, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ProgressionTreeBindingVector GetRange(int index, int count)
	{
		IntPtr intPtr = MothershipApiPINVOKE.ProgressionTreeBindingVector_GetRange(swigCPtr, index, count);
		ProgressionTreeBindingVector result = ((intPtr == IntPtr.Zero) ? null : new ProgressionTreeBindingVector(intPtr, cMemoryOwn: true));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, ProgressionTreeBindingResponse x)
	{
		MothershipApiPINVOKE.ProgressionTreeBindingVector_Insert(swigCPtr, index, ProgressionTreeBindingResponse.getCPtr(x));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, ProgressionTreeBindingVector values)
	{
		MothershipApiPINVOKE.ProgressionTreeBindingVector_InsertRange(swigCPtr, index, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		MothershipApiPINVOKE.ProgressionTreeBindingVector_RemoveAt(swigCPtr, index);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		MothershipApiPINVOKE.ProgressionTreeBindingVector_RemoveRange(swigCPtr, index, count);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static ProgressionTreeBindingVector Repeat(ProgressionTreeBindingResponse value, int count)
	{
		IntPtr intPtr = MothershipApiPINVOKE.ProgressionTreeBindingVector_Repeat(ProgressionTreeBindingResponse.getCPtr(value), count);
		ProgressionTreeBindingVector result = ((intPtr == IntPtr.Zero) ? null : new ProgressionTreeBindingVector(intPtr, cMemoryOwn: true));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		MothershipApiPINVOKE.ProgressionTreeBindingVector_Reverse__SWIG_0(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		MothershipApiPINVOKE.ProgressionTreeBindingVector_Reverse__SWIG_1(swigCPtr, index, count);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, ProgressionTreeBindingVector values)
	{
		MothershipApiPINVOKE.ProgressionTreeBindingVector_SetRange(swigCPtr, index, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
