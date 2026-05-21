using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class ListEntitlementResultsVector : IDisposable, IEnumerable, IEnumerable<MothershipEntitlementCatalogItem>
{
	public sealed class ListEntitlementResultsVectorEnumerator : IEnumerator, IEnumerator<MothershipEntitlementCatalogItem>, IDisposable
	{
		private ListEntitlementResultsVector collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public MothershipEntitlementCatalogItem Current
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
				return (MothershipEntitlementCatalogItem)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public ListEntitlementResultsVectorEnumerator(ListEntitlementResultsVector collection)
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

	public MothershipEntitlementCatalogItem this[int index]
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

	internal ListEntitlementResultsVector(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(ListEntitlementResultsVector obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	internal static HandleRef swigRelease(ListEntitlementResultsVector obj)
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

	~ListEntitlementResultsVector()
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
					MothershipApiPINVOKE.delete_ListEntitlementResultsVector(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public ListEntitlementResultsVector(IEnumerable c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (MothershipEntitlementCatalogItem item in c)
		{
			Add(item);
		}
	}

	public ListEntitlementResultsVector(IEnumerable<MothershipEntitlementCatalogItem> c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (MothershipEntitlementCatalogItem item in c)
		{
			Add(item);
		}
	}

	public void CopyTo(MothershipEntitlementCatalogItem[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(MothershipEntitlementCatalogItem[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, MothershipEntitlementCatalogItem[] array, int arrayIndex, int count)
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

	public MothershipEntitlementCatalogItem[] ToArray()
	{
		MothershipEntitlementCatalogItem[] array = new MothershipEntitlementCatalogItem[Count];
		CopyTo(array);
		return array;
	}

	IEnumerator<MothershipEntitlementCatalogItem> IEnumerable<MothershipEntitlementCatalogItem>.GetEnumerator()
	{
		return new ListEntitlementResultsVectorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new ListEntitlementResultsVectorEnumerator(this);
	}

	public ListEntitlementResultsVectorEnumerator GetEnumerator()
	{
		return new ListEntitlementResultsVectorEnumerator(this);
	}

	public void Clear()
	{
		MothershipApiPINVOKE.ListEntitlementResultsVector_Clear(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(MothershipEntitlementCatalogItem x)
	{
		MothershipApiPINVOKE.ListEntitlementResultsVector_Add(swigCPtr, MothershipEntitlementCatalogItem.getCPtr(x));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = MothershipApiPINVOKE.ListEntitlementResultsVector_size(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = MothershipApiPINVOKE.ListEntitlementResultsVector_capacity(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		MothershipApiPINVOKE.ListEntitlementResultsVector_reserve(swigCPtr, n);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ListEntitlementResultsVector()
		: this(MothershipApiPINVOKE.new_ListEntitlementResultsVector__SWIG_0(), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ListEntitlementResultsVector(ListEntitlementResultsVector other)
		: this(MothershipApiPINVOKE.new_ListEntitlementResultsVector__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ListEntitlementResultsVector(int capacity)
		: this(MothershipApiPINVOKE.new_ListEntitlementResultsVector__SWIG_2(capacity), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private MothershipEntitlementCatalogItem getitemcopy(int index)
	{
		MothershipEntitlementCatalogItem result = new MothershipEntitlementCatalogItem(MothershipApiPINVOKE.ListEntitlementResultsVector_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private MothershipEntitlementCatalogItem getitem(int index)
	{
		MothershipEntitlementCatalogItem result = new MothershipEntitlementCatalogItem(MothershipApiPINVOKE.ListEntitlementResultsVector_getitem(swigCPtr, index), cMemoryOwn: false);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, MothershipEntitlementCatalogItem val)
	{
		MothershipApiPINVOKE.ListEntitlementResultsVector_setitem(swigCPtr, index, MothershipEntitlementCatalogItem.getCPtr(val));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(ListEntitlementResultsVector values)
	{
		MothershipApiPINVOKE.ListEntitlementResultsVector_AddRange(swigCPtr, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ListEntitlementResultsVector GetRange(int index, int count)
	{
		IntPtr intPtr = MothershipApiPINVOKE.ListEntitlementResultsVector_GetRange(swigCPtr, index, count);
		ListEntitlementResultsVector result = ((intPtr == IntPtr.Zero) ? null : new ListEntitlementResultsVector(intPtr, cMemoryOwn: true));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, MothershipEntitlementCatalogItem x)
	{
		MothershipApiPINVOKE.ListEntitlementResultsVector_Insert(swigCPtr, index, MothershipEntitlementCatalogItem.getCPtr(x));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, ListEntitlementResultsVector values)
	{
		MothershipApiPINVOKE.ListEntitlementResultsVector_InsertRange(swigCPtr, index, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		MothershipApiPINVOKE.ListEntitlementResultsVector_RemoveAt(swigCPtr, index);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		MothershipApiPINVOKE.ListEntitlementResultsVector_RemoveRange(swigCPtr, index, count);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static ListEntitlementResultsVector Repeat(MothershipEntitlementCatalogItem value, int count)
	{
		IntPtr intPtr = MothershipApiPINVOKE.ListEntitlementResultsVector_Repeat(MothershipEntitlementCatalogItem.getCPtr(value), count);
		ListEntitlementResultsVector result = ((intPtr == IntPtr.Zero) ? null : new ListEntitlementResultsVector(intPtr, cMemoryOwn: true));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		MothershipApiPINVOKE.ListEntitlementResultsVector_Reverse__SWIG_0(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		MothershipApiPINVOKE.ListEntitlementResultsVector_Reverse__SWIG_1(swigCPtr, index, count);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, ListEntitlementResultsVector values)
	{
		MothershipApiPINVOKE.ListEntitlementResultsVector_SetRange(swigCPtr, index, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
