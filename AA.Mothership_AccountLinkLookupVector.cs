using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class AccountLinkLookupVector : IDisposable, IEnumerable, IEnumerable<AccountLinkLookupEntry>
{
	public sealed class AccountLinkLookupVectorEnumerator : IEnumerator, IEnumerator<AccountLinkLookupEntry>, IDisposable
	{
		private AccountLinkLookupVector collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public AccountLinkLookupEntry Current
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
				return (AccountLinkLookupEntry)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public AccountLinkLookupVectorEnumerator(AccountLinkLookupVector collection)
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

	public AccountLinkLookupEntry this[int index]
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

	internal AccountLinkLookupVector(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(AccountLinkLookupVector obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	internal static HandleRef swigRelease(AccountLinkLookupVector obj)
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

	~AccountLinkLookupVector()
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
					MothershipApiPINVOKE.delete_AccountLinkLookupVector(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public AccountLinkLookupVector(IEnumerable c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (AccountLinkLookupEntry item in c)
		{
			Add(item);
		}
	}

	public AccountLinkLookupVector(IEnumerable<AccountLinkLookupEntry> c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (AccountLinkLookupEntry item in c)
		{
			Add(item);
		}
	}

	public void CopyTo(AccountLinkLookupEntry[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(AccountLinkLookupEntry[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, AccountLinkLookupEntry[] array, int arrayIndex, int count)
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

	public AccountLinkLookupEntry[] ToArray()
	{
		AccountLinkLookupEntry[] array = new AccountLinkLookupEntry[Count];
		CopyTo(array);
		return array;
	}

	IEnumerator<AccountLinkLookupEntry> IEnumerable<AccountLinkLookupEntry>.GetEnumerator()
	{
		return new AccountLinkLookupVectorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new AccountLinkLookupVectorEnumerator(this);
	}

	public AccountLinkLookupVectorEnumerator GetEnumerator()
	{
		return new AccountLinkLookupVectorEnumerator(this);
	}

	public void Clear()
	{
		MothershipApiPINVOKE.AccountLinkLookupVector_Clear(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(AccountLinkLookupEntry x)
	{
		MothershipApiPINVOKE.AccountLinkLookupVector_Add(swigCPtr, AccountLinkLookupEntry.getCPtr(x));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = MothershipApiPINVOKE.AccountLinkLookupVector_size(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = MothershipApiPINVOKE.AccountLinkLookupVector_capacity(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		MothershipApiPINVOKE.AccountLinkLookupVector_reserve(swigCPtr, n);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public AccountLinkLookupVector()
		: this(MothershipApiPINVOKE.new_AccountLinkLookupVector__SWIG_0(), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public AccountLinkLookupVector(AccountLinkLookupVector other)
		: this(MothershipApiPINVOKE.new_AccountLinkLookupVector__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public AccountLinkLookupVector(int capacity)
		: this(MothershipApiPINVOKE.new_AccountLinkLookupVector__SWIG_2(capacity), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private AccountLinkLookupEntry getitemcopy(int index)
	{
		AccountLinkLookupEntry result = new AccountLinkLookupEntry(MothershipApiPINVOKE.AccountLinkLookupVector_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private AccountLinkLookupEntry getitem(int index)
	{
		AccountLinkLookupEntry result = new AccountLinkLookupEntry(MothershipApiPINVOKE.AccountLinkLookupVector_getitem(swigCPtr, index), cMemoryOwn: false);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, AccountLinkLookupEntry val)
	{
		MothershipApiPINVOKE.AccountLinkLookupVector_setitem(swigCPtr, index, AccountLinkLookupEntry.getCPtr(val));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(AccountLinkLookupVector values)
	{
		MothershipApiPINVOKE.AccountLinkLookupVector_AddRange(swigCPtr, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public AccountLinkLookupVector GetRange(int index, int count)
	{
		IntPtr intPtr = MothershipApiPINVOKE.AccountLinkLookupVector_GetRange(swigCPtr, index, count);
		AccountLinkLookupVector result = ((intPtr == IntPtr.Zero) ? null : new AccountLinkLookupVector(intPtr, cMemoryOwn: true));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, AccountLinkLookupEntry x)
	{
		MothershipApiPINVOKE.AccountLinkLookupVector_Insert(swigCPtr, index, AccountLinkLookupEntry.getCPtr(x));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, AccountLinkLookupVector values)
	{
		MothershipApiPINVOKE.AccountLinkLookupVector_InsertRange(swigCPtr, index, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		MothershipApiPINVOKE.AccountLinkLookupVector_RemoveAt(swigCPtr, index);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		MothershipApiPINVOKE.AccountLinkLookupVector_RemoveRange(swigCPtr, index, count);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static AccountLinkLookupVector Repeat(AccountLinkLookupEntry value, int count)
	{
		IntPtr intPtr = MothershipApiPINVOKE.AccountLinkLookupVector_Repeat(AccountLinkLookupEntry.getCPtr(value), count);
		AccountLinkLookupVector result = ((intPtr == IntPtr.Zero) ? null : new AccountLinkLookupVector(intPtr, cMemoryOwn: true));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		MothershipApiPINVOKE.AccountLinkLookupVector_Reverse__SWIG_0(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		MothershipApiPINVOKE.AccountLinkLookupVector_Reverse__SWIG_1(swigCPtr, index, count);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, AccountLinkLookupVector values)
	{
		MothershipApiPINVOKE.AccountLinkLookupVector_SetRange(swigCPtr, index, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
