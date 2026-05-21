using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class PlatformAndSkuVector : IDisposable, IEnumerable, IEnumerable<SubscriptionPlatformAndSku>
{
	public sealed class PlatformAndSkuVectorEnumerator : IEnumerator, IEnumerator<SubscriptionPlatformAndSku>, IDisposable
	{
		private PlatformAndSkuVector collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public SubscriptionPlatformAndSku Current
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
				return (SubscriptionPlatformAndSku)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public PlatformAndSkuVectorEnumerator(PlatformAndSkuVector collection)
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

	public SubscriptionPlatformAndSku this[int index]
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

	internal PlatformAndSkuVector(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(PlatformAndSkuVector obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	internal static HandleRef swigRelease(PlatformAndSkuVector obj)
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

	~PlatformAndSkuVector()
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
					MothershipApiPINVOKE.delete_PlatformAndSkuVector(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public PlatformAndSkuVector(IEnumerable c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (SubscriptionPlatformAndSku item in c)
		{
			Add(item);
		}
	}

	public PlatformAndSkuVector(IEnumerable<SubscriptionPlatformAndSku> c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (SubscriptionPlatformAndSku item in c)
		{
			Add(item);
		}
	}

	public void CopyTo(SubscriptionPlatformAndSku[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(SubscriptionPlatformAndSku[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, SubscriptionPlatformAndSku[] array, int arrayIndex, int count)
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

	public SubscriptionPlatformAndSku[] ToArray()
	{
		SubscriptionPlatformAndSku[] array = new SubscriptionPlatformAndSku[Count];
		CopyTo(array);
		return array;
	}

	IEnumerator<SubscriptionPlatformAndSku> IEnumerable<SubscriptionPlatformAndSku>.GetEnumerator()
	{
		return new PlatformAndSkuVectorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new PlatformAndSkuVectorEnumerator(this);
	}

	public PlatformAndSkuVectorEnumerator GetEnumerator()
	{
		return new PlatformAndSkuVectorEnumerator(this);
	}

	public void Clear()
	{
		MothershipApiPINVOKE.PlatformAndSkuVector_Clear(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(SubscriptionPlatformAndSku x)
	{
		MothershipApiPINVOKE.PlatformAndSkuVector_Add(swigCPtr, SubscriptionPlatformAndSku.getCPtr(x));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = MothershipApiPINVOKE.PlatformAndSkuVector_size(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = MothershipApiPINVOKE.PlatformAndSkuVector_capacity(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		MothershipApiPINVOKE.PlatformAndSkuVector_reserve(swigCPtr, n);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public PlatformAndSkuVector()
		: this(MothershipApiPINVOKE.new_PlatformAndSkuVector__SWIG_0(), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public PlatformAndSkuVector(PlatformAndSkuVector other)
		: this(MothershipApiPINVOKE.new_PlatformAndSkuVector__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public PlatformAndSkuVector(int capacity)
		: this(MothershipApiPINVOKE.new_PlatformAndSkuVector__SWIG_2(capacity), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private SubscriptionPlatformAndSku getitemcopy(int index)
	{
		SubscriptionPlatformAndSku result = new SubscriptionPlatformAndSku(MothershipApiPINVOKE.PlatformAndSkuVector_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private SubscriptionPlatformAndSku getitem(int index)
	{
		SubscriptionPlatformAndSku result = new SubscriptionPlatformAndSku(MothershipApiPINVOKE.PlatformAndSkuVector_getitem(swigCPtr, index), cMemoryOwn: false);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, SubscriptionPlatformAndSku val)
	{
		MothershipApiPINVOKE.PlatformAndSkuVector_setitem(swigCPtr, index, SubscriptionPlatformAndSku.getCPtr(val));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(PlatformAndSkuVector values)
	{
		MothershipApiPINVOKE.PlatformAndSkuVector_AddRange(swigCPtr, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public PlatformAndSkuVector GetRange(int index, int count)
	{
		IntPtr intPtr = MothershipApiPINVOKE.PlatformAndSkuVector_GetRange(swigCPtr, index, count);
		PlatformAndSkuVector result = ((intPtr == IntPtr.Zero) ? null : new PlatformAndSkuVector(intPtr, cMemoryOwn: true));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, SubscriptionPlatformAndSku x)
	{
		MothershipApiPINVOKE.PlatformAndSkuVector_Insert(swigCPtr, index, SubscriptionPlatformAndSku.getCPtr(x));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, PlatformAndSkuVector values)
	{
		MothershipApiPINVOKE.PlatformAndSkuVector_InsertRange(swigCPtr, index, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		MothershipApiPINVOKE.PlatformAndSkuVector_RemoveAt(swigCPtr, index);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		MothershipApiPINVOKE.PlatformAndSkuVector_RemoveRange(swigCPtr, index, count);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static PlatformAndSkuVector Repeat(SubscriptionPlatformAndSku value, int count)
	{
		IntPtr intPtr = MothershipApiPINVOKE.PlatformAndSkuVector_Repeat(SubscriptionPlatformAndSku.getCPtr(value), count);
		PlatformAndSkuVector result = ((intPtr == IntPtr.Zero) ? null : new PlatformAndSkuVector(intPtr, cMemoryOwn: true));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		MothershipApiPINVOKE.PlatformAndSkuVector_Reverse__SWIG_0(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		MothershipApiPINVOKE.PlatformAndSkuVector_Reverse__SWIG_1(swigCPtr, index, count);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, PlatformAndSkuVector values)
	{
		MothershipApiPINVOKE.PlatformAndSkuVector_SetRange(swigCPtr, index, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
