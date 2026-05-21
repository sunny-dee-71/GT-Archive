using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class SubscriptionPricingVector : IDisposable, IEnumerable, IEnumerable<SubscriptionPricingAndTerms>
{
	public sealed class SubscriptionPricingVectorEnumerator : IEnumerator, IEnumerator<SubscriptionPricingAndTerms>, IDisposable
	{
		private SubscriptionPricingVector collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public SubscriptionPricingAndTerms Current
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
				return (SubscriptionPricingAndTerms)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public SubscriptionPricingVectorEnumerator(SubscriptionPricingVector collection)
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

	public SubscriptionPricingAndTerms this[int index]
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

	internal SubscriptionPricingVector(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(SubscriptionPricingVector obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	internal static HandleRef swigRelease(SubscriptionPricingVector obj)
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

	~SubscriptionPricingVector()
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
					MothershipApiPINVOKE.delete_SubscriptionPricingVector(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public SubscriptionPricingVector(IEnumerable c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (SubscriptionPricingAndTerms item in c)
		{
			Add(item);
		}
	}

	public SubscriptionPricingVector(IEnumerable<SubscriptionPricingAndTerms> c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (SubscriptionPricingAndTerms item in c)
		{
			Add(item);
		}
	}

	public void CopyTo(SubscriptionPricingAndTerms[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(SubscriptionPricingAndTerms[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, SubscriptionPricingAndTerms[] array, int arrayIndex, int count)
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

	public SubscriptionPricingAndTerms[] ToArray()
	{
		SubscriptionPricingAndTerms[] array = new SubscriptionPricingAndTerms[Count];
		CopyTo(array);
		return array;
	}

	IEnumerator<SubscriptionPricingAndTerms> IEnumerable<SubscriptionPricingAndTerms>.GetEnumerator()
	{
		return new SubscriptionPricingVectorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new SubscriptionPricingVectorEnumerator(this);
	}

	public SubscriptionPricingVectorEnumerator GetEnumerator()
	{
		return new SubscriptionPricingVectorEnumerator(this);
	}

	public void Clear()
	{
		MothershipApiPINVOKE.SubscriptionPricingVector_Clear(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(SubscriptionPricingAndTerms x)
	{
		MothershipApiPINVOKE.SubscriptionPricingVector_Add(swigCPtr, SubscriptionPricingAndTerms.getCPtr(x));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = MothershipApiPINVOKE.SubscriptionPricingVector_size(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = MothershipApiPINVOKE.SubscriptionPricingVector_capacity(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		MothershipApiPINVOKE.SubscriptionPricingVector_reserve(swigCPtr, n);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public SubscriptionPricingVector()
		: this(MothershipApiPINVOKE.new_SubscriptionPricingVector__SWIG_0(), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public SubscriptionPricingVector(SubscriptionPricingVector other)
		: this(MothershipApiPINVOKE.new_SubscriptionPricingVector__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public SubscriptionPricingVector(int capacity)
		: this(MothershipApiPINVOKE.new_SubscriptionPricingVector__SWIG_2(capacity), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private SubscriptionPricingAndTerms getitemcopy(int index)
	{
		SubscriptionPricingAndTerms result = new SubscriptionPricingAndTerms(MothershipApiPINVOKE.SubscriptionPricingVector_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private SubscriptionPricingAndTerms getitem(int index)
	{
		SubscriptionPricingAndTerms result = new SubscriptionPricingAndTerms(MothershipApiPINVOKE.SubscriptionPricingVector_getitem(swigCPtr, index), cMemoryOwn: false);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, SubscriptionPricingAndTerms val)
	{
		MothershipApiPINVOKE.SubscriptionPricingVector_setitem(swigCPtr, index, SubscriptionPricingAndTerms.getCPtr(val));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(SubscriptionPricingVector values)
	{
		MothershipApiPINVOKE.SubscriptionPricingVector_AddRange(swigCPtr, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public SubscriptionPricingVector GetRange(int index, int count)
	{
		IntPtr intPtr = MothershipApiPINVOKE.SubscriptionPricingVector_GetRange(swigCPtr, index, count);
		SubscriptionPricingVector result = ((intPtr == IntPtr.Zero) ? null : new SubscriptionPricingVector(intPtr, cMemoryOwn: true));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, SubscriptionPricingAndTerms x)
	{
		MothershipApiPINVOKE.SubscriptionPricingVector_Insert(swigCPtr, index, SubscriptionPricingAndTerms.getCPtr(x));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, SubscriptionPricingVector values)
	{
		MothershipApiPINVOKE.SubscriptionPricingVector_InsertRange(swigCPtr, index, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		MothershipApiPINVOKE.SubscriptionPricingVector_RemoveAt(swigCPtr, index);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		MothershipApiPINVOKE.SubscriptionPricingVector_RemoveRange(swigCPtr, index, count);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static SubscriptionPricingVector Repeat(SubscriptionPricingAndTerms value, int count)
	{
		IntPtr intPtr = MothershipApiPINVOKE.SubscriptionPricingVector_Repeat(SubscriptionPricingAndTerms.getCPtr(value), count);
		SubscriptionPricingVector result = ((intPtr == IntPtr.Zero) ? null : new SubscriptionPricingVector(intPtr, cMemoryOwn: true));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		MothershipApiPINVOKE.SubscriptionPricingVector_Reverse__SWIG_0(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		MothershipApiPINVOKE.SubscriptionPricingVector_Reverse__SWIG_1(swigCPtr, index, count);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, SubscriptionPricingVector values)
	{
		MothershipApiPINVOKE.SubscriptionPricingVector_SetRange(swigCPtr, index, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
