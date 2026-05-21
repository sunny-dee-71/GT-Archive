using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class AnalyticsRequestVector : IDisposable, IEnumerable, IEnumerable<MothershipAnalyticsEvent>
{
	public sealed class AnalyticsRequestVectorEnumerator : IEnumerator, IEnumerator<MothershipAnalyticsEvent>, IDisposable
	{
		private AnalyticsRequestVector collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public MothershipAnalyticsEvent Current
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
				return (MothershipAnalyticsEvent)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public AnalyticsRequestVectorEnumerator(AnalyticsRequestVector collection)
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

	public MothershipAnalyticsEvent this[int index]
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

	internal AnalyticsRequestVector(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(AnalyticsRequestVector obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	internal static HandleRef swigRelease(AnalyticsRequestVector obj)
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

	~AnalyticsRequestVector()
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
					MothershipApiPINVOKE.delete_AnalyticsRequestVector(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public AnalyticsRequestVector(IEnumerable c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (MothershipAnalyticsEvent item in c)
		{
			Add(item);
		}
	}

	public AnalyticsRequestVector(IEnumerable<MothershipAnalyticsEvent> c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (MothershipAnalyticsEvent item in c)
		{
			Add(item);
		}
	}

	public void CopyTo(MothershipAnalyticsEvent[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(MothershipAnalyticsEvent[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, MothershipAnalyticsEvent[] array, int arrayIndex, int count)
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

	public MothershipAnalyticsEvent[] ToArray()
	{
		MothershipAnalyticsEvent[] array = new MothershipAnalyticsEvent[Count];
		CopyTo(array);
		return array;
	}

	IEnumerator<MothershipAnalyticsEvent> IEnumerable<MothershipAnalyticsEvent>.GetEnumerator()
	{
		return new AnalyticsRequestVectorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new AnalyticsRequestVectorEnumerator(this);
	}

	public AnalyticsRequestVectorEnumerator GetEnumerator()
	{
		return new AnalyticsRequestVectorEnumerator(this);
	}

	public void Clear()
	{
		MothershipApiPINVOKE.AnalyticsRequestVector_Clear(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(MothershipAnalyticsEvent x)
	{
		MothershipApiPINVOKE.AnalyticsRequestVector_Add(swigCPtr, MothershipAnalyticsEvent.getCPtr(x));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = MothershipApiPINVOKE.AnalyticsRequestVector_size(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = MothershipApiPINVOKE.AnalyticsRequestVector_capacity(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		MothershipApiPINVOKE.AnalyticsRequestVector_reserve(swigCPtr, n);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public AnalyticsRequestVector()
		: this(MothershipApiPINVOKE.new_AnalyticsRequestVector__SWIG_0(), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public AnalyticsRequestVector(AnalyticsRequestVector other)
		: this(MothershipApiPINVOKE.new_AnalyticsRequestVector__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public AnalyticsRequestVector(int capacity)
		: this(MothershipApiPINVOKE.new_AnalyticsRequestVector__SWIG_2(capacity), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private MothershipAnalyticsEvent getitemcopy(int index)
	{
		MothershipAnalyticsEvent result = new MothershipAnalyticsEvent(MothershipApiPINVOKE.AnalyticsRequestVector_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private MothershipAnalyticsEvent getitem(int index)
	{
		MothershipAnalyticsEvent result = new MothershipAnalyticsEvent(MothershipApiPINVOKE.AnalyticsRequestVector_getitem(swigCPtr, index), cMemoryOwn: false);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, MothershipAnalyticsEvent val)
	{
		MothershipApiPINVOKE.AnalyticsRequestVector_setitem(swigCPtr, index, MothershipAnalyticsEvent.getCPtr(val));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(AnalyticsRequestVector values)
	{
		MothershipApiPINVOKE.AnalyticsRequestVector_AddRange(swigCPtr, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public AnalyticsRequestVector GetRange(int index, int count)
	{
		IntPtr intPtr = MothershipApiPINVOKE.AnalyticsRequestVector_GetRange(swigCPtr, index, count);
		AnalyticsRequestVector result = ((intPtr == IntPtr.Zero) ? null : new AnalyticsRequestVector(intPtr, cMemoryOwn: true));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, MothershipAnalyticsEvent x)
	{
		MothershipApiPINVOKE.AnalyticsRequestVector_Insert(swigCPtr, index, MothershipAnalyticsEvent.getCPtr(x));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, AnalyticsRequestVector values)
	{
		MothershipApiPINVOKE.AnalyticsRequestVector_InsertRange(swigCPtr, index, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		MothershipApiPINVOKE.AnalyticsRequestVector_RemoveAt(swigCPtr, index);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		MothershipApiPINVOKE.AnalyticsRequestVector_RemoveRange(swigCPtr, index, count);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static AnalyticsRequestVector Repeat(MothershipAnalyticsEvent value, int count)
	{
		IntPtr intPtr = MothershipApiPINVOKE.AnalyticsRequestVector_Repeat(MothershipAnalyticsEvent.getCPtr(value), count);
		AnalyticsRequestVector result = ((intPtr == IntPtr.Zero) ? null : new AnalyticsRequestVector(intPtr, cMemoryOwn: true));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		MothershipApiPINVOKE.AnalyticsRequestVector_Reverse__SWIG_0(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		MothershipApiPINVOKE.AnalyticsRequestVector_Reverse__SWIG_1(swigCPtr, index, count);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, AnalyticsRequestVector values)
	{
		MothershipApiPINVOKE.AnalyticsRequestVector_SetRange(swigCPtr, index, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
