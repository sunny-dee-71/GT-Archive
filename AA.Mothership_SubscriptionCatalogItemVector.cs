using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class SubscriptionCatalogItemVector : IDisposable, IEnumerable, IEnumerable<SubscriptionCatalogItem>
{
	public sealed class SubscriptionCatalogItemVectorEnumerator : IEnumerator, IEnumerator<SubscriptionCatalogItem>, IDisposable
	{
		private SubscriptionCatalogItemVector collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public SubscriptionCatalogItem Current
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
				return (SubscriptionCatalogItem)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public SubscriptionCatalogItemVectorEnumerator(SubscriptionCatalogItemVector collection)
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

	public SubscriptionCatalogItem this[int index]
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

	internal SubscriptionCatalogItemVector(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(SubscriptionCatalogItemVector obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	internal static HandleRef swigRelease(SubscriptionCatalogItemVector obj)
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

	~SubscriptionCatalogItemVector()
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
					MothershipApiPINVOKE.delete_SubscriptionCatalogItemVector(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public SubscriptionCatalogItemVector(IEnumerable c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (SubscriptionCatalogItem item in c)
		{
			Add(item);
		}
	}

	public SubscriptionCatalogItemVector(IEnumerable<SubscriptionCatalogItem> c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (SubscriptionCatalogItem item in c)
		{
			Add(item);
		}
	}

	public void CopyTo(SubscriptionCatalogItem[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(SubscriptionCatalogItem[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, SubscriptionCatalogItem[] array, int arrayIndex, int count)
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

	public SubscriptionCatalogItem[] ToArray()
	{
		SubscriptionCatalogItem[] array = new SubscriptionCatalogItem[Count];
		CopyTo(array);
		return array;
	}

	IEnumerator<SubscriptionCatalogItem> IEnumerable<SubscriptionCatalogItem>.GetEnumerator()
	{
		return new SubscriptionCatalogItemVectorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new SubscriptionCatalogItemVectorEnumerator(this);
	}

	public SubscriptionCatalogItemVectorEnumerator GetEnumerator()
	{
		return new SubscriptionCatalogItemVectorEnumerator(this);
	}

	public void Clear()
	{
		MothershipApiPINVOKE.SubscriptionCatalogItemVector_Clear(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(SubscriptionCatalogItem x)
	{
		MothershipApiPINVOKE.SubscriptionCatalogItemVector_Add(swigCPtr, SubscriptionCatalogItem.getCPtr(x));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = MothershipApiPINVOKE.SubscriptionCatalogItemVector_size(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = MothershipApiPINVOKE.SubscriptionCatalogItemVector_capacity(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		MothershipApiPINVOKE.SubscriptionCatalogItemVector_reserve(swigCPtr, n);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public SubscriptionCatalogItemVector()
		: this(MothershipApiPINVOKE.new_SubscriptionCatalogItemVector__SWIG_0(), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public SubscriptionCatalogItemVector(SubscriptionCatalogItemVector other)
		: this(MothershipApiPINVOKE.new_SubscriptionCatalogItemVector__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public SubscriptionCatalogItemVector(int capacity)
		: this(MothershipApiPINVOKE.new_SubscriptionCatalogItemVector__SWIG_2(capacity), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private SubscriptionCatalogItem getitemcopy(int index)
	{
		SubscriptionCatalogItem result = new SubscriptionCatalogItem(MothershipApiPINVOKE.SubscriptionCatalogItemVector_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private SubscriptionCatalogItem getitem(int index)
	{
		SubscriptionCatalogItem result = new SubscriptionCatalogItem(MothershipApiPINVOKE.SubscriptionCatalogItemVector_getitem(swigCPtr, index), cMemoryOwn: false);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, SubscriptionCatalogItem val)
	{
		MothershipApiPINVOKE.SubscriptionCatalogItemVector_setitem(swigCPtr, index, SubscriptionCatalogItem.getCPtr(val));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(SubscriptionCatalogItemVector values)
	{
		MothershipApiPINVOKE.SubscriptionCatalogItemVector_AddRange(swigCPtr, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public SubscriptionCatalogItemVector GetRange(int index, int count)
	{
		IntPtr intPtr = MothershipApiPINVOKE.SubscriptionCatalogItemVector_GetRange(swigCPtr, index, count);
		SubscriptionCatalogItemVector result = ((intPtr == IntPtr.Zero) ? null : new SubscriptionCatalogItemVector(intPtr, cMemoryOwn: true));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, SubscriptionCatalogItem x)
	{
		MothershipApiPINVOKE.SubscriptionCatalogItemVector_Insert(swigCPtr, index, SubscriptionCatalogItem.getCPtr(x));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, SubscriptionCatalogItemVector values)
	{
		MothershipApiPINVOKE.SubscriptionCatalogItemVector_InsertRange(swigCPtr, index, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		MothershipApiPINVOKE.SubscriptionCatalogItemVector_RemoveAt(swigCPtr, index);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		MothershipApiPINVOKE.SubscriptionCatalogItemVector_RemoveRange(swigCPtr, index, count);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static SubscriptionCatalogItemVector Repeat(SubscriptionCatalogItem value, int count)
	{
		IntPtr intPtr = MothershipApiPINVOKE.SubscriptionCatalogItemVector_Repeat(SubscriptionCatalogItem.getCPtr(value), count);
		SubscriptionCatalogItemVector result = ((intPtr == IntPtr.Zero) ? null : new SubscriptionCatalogItemVector(intPtr, cMemoryOwn: true));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		MothershipApiPINVOKE.SubscriptionCatalogItemVector_Reverse__SWIG_0(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		MothershipApiPINVOKE.SubscriptionCatalogItemVector_Reverse__SWIG_1(swigCPtr, index, count);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, SubscriptionCatalogItemVector values)
	{
		MothershipApiPINVOKE.SubscriptionCatalogItemVector_SetRange(swigCPtr, index, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
