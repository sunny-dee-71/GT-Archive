using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class UserHydratedProgressionTrackVector : IDisposable, IEnumerable, IEnumerable<UserHydratedProgressionTrackResponse>
{
	public sealed class UserHydratedProgressionTrackVectorEnumerator : IEnumerator, IEnumerator<UserHydratedProgressionTrackResponse>, IDisposable
	{
		private UserHydratedProgressionTrackVector collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public UserHydratedProgressionTrackResponse Current
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
				return (UserHydratedProgressionTrackResponse)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public UserHydratedProgressionTrackVectorEnumerator(UserHydratedProgressionTrackVector collection)
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

	public UserHydratedProgressionTrackResponse this[int index]
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

	internal UserHydratedProgressionTrackVector(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(UserHydratedProgressionTrackVector obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	internal static HandleRef swigRelease(UserHydratedProgressionTrackVector obj)
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

	~UserHydratedProgressionTrackVector()
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
					MothershipApiPINVOKE.delete_UserHydratedProgressionTrackVector(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public UserHydratedProgressionTrackVector(IEnumerable c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (UserHydratedProgressionTrackResponse item in c)
		{
			Add(item);
		}
	}

	public UserHydratedProgressionTrackVector(IEnumerable<UserHydratedProgressionTrackResponse> c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (UserHydratedProgressionTrackResponse item in c)
		{
			Add(item);
		}
	}

	public void CopyTo(UserHydratedProgressionTrackResponse[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(UserHydratedProgressionTrackResponse[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, UserHydratedProgressionTrackResponse[] array, int arrayIndex, int count)
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

	public UserHydratedProgressionTrackResponse[] ToArray()
	{
		UserHydratedProgressionTrackResponse[] array = new UserHydratedProgressionTrackResponse[Count];
		CopyTo(array);
		return array;
	}

	IEnumerator<UserHydratedProgressionTrackResponse> IEnumerable<UserHydratedProgressionTrackResponse>.GetEnumerator()
	{
		return new UserHydratedProgressionTrackVectorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new UserHydratedProgressionTrackVectorEnumerator(this);
	}

	public UserHydratedProgressionTrackVectorEnumerator GetEnumerator()
	{
		return new UserHydratedProgressionTrackVectorEnumerator(this);
	}

	public void Clear()
	{
		MothershipApiPINVOKE.UserHydratedProgressionTrackVector_Clear(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(UserHydratedProgressionTrackResponse x)
	{
		MothershipApiPINVOKE.UserHydratedProgressionTrackVector_Add(swigCPtr, UserHydratedProgressionTrackResponse.getCPtr(x));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = MothershipApiPINVOKE.UserHydratedProgressionTrackVector_size(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = MothershipApiPINVOKE.UserHydratedProgressionTrackVector_capacity(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		MothershipApiPINVOKE.UserHydratedProgressionTrackVector_reserve(swigCPtr, n);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public UserHydratedProgressionTrackVector()
		: this(MothershipApiPINVOKE.new_UserHydratedProgressionTrackVector__SWIG_0(), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public UserHydratedProgressionTrackVector(UserHydratedProgressionTrackVector other)
		: this(MothershipApiPINVOKE.new_UserHydratedProgressionTrackVector__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public UserHydratedProgressionTrackVector(int capacity)
		: this(MothershipApiPINVOKE.new_UserHydratedProgressionTrackVector__SWIG_2(capacity), cMemoryOwn: true)
	{
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private UserHydratedProgressionTrackResponse getitemcopy(int index)
	{
		UserHydratedProgressionTrackResponse result = new UserHydratedProgressionTrackResponse(MothershipApiPINVOKE.UserHydratedProgressionTrackVector_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private UserHydratedProgressionTrackResponse getitem(int index)
	{
		UserHydratedProgressionTrackResponse result = new UserHydratedProgressionTrackResponse(MothershipApiPINVOKE.UserHydratedProgressionTrackVector_getitem(swigCPtr, index), cMemoryOwn: false);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, UserHydratedProgressionTrackResponse val)
	{
		MothershipApiPINVOKE.UserHydratedProgressionTrackVector_setitem(swigCPtr, index, UserHydratedProgressionTrackResponse.getCPtr(val));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(UserHydratedProgressionTrackVector values)
	{
		MothershipApiPINVOKE.UserHydratedProgressionTrackVector_AddRange(swigCPtr, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public UserHydratedProgressionTrackVector GetRange(int index, int count)
	{
		IntPtr intPtr = MothershipApiPINVOKE.UserHydratedProgressionTrackVector_GetRange(swigCPtr, index, count);
		UserHydratedProgressionTrackVector result = ((intPtr == IntPtr.Zero) ? null : new UserHydratedProgressionTrackVector(intPtr, cMemoryOwn: true));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, UserHydratedProgressionTrackResponse x)
	{
		MothershipApiPINVOKE.UserHydratedProgressionTrackVector_Insert(swigCPtr, index, UserHydratedProgressionTrackResponse.getCPtr(x));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, UserHydratedProgressionTrackVector values)
	{
		MothershipApiPINVOKE.UserHydratedProgressionTrackVector_InsertRange(swigCPtr, index, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		MothershipApiPINVOKE.UserHydratedProgressionTrackVector_RemoveAt(swigCPtr, index);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		MothershipApiPINVOKE.UserHydratedProgressionTrackVector_RemoveRange(swigCPtr, index, count);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static UserHydratedProgressionTrackVector Repeat(UserHydratedProgressionTrackResponse value, int count)
	{
		IntPtr intPtr = MothershipApiPINVOKE.UserHydratedProgressionTrackVector_Repeat(UserHydratedProgressionTrackResponse.getCPtr(value), count);
		UserHydratedProgressionTrackVector result = ((intPtr == IntPtr.Zero) ? null : new UserHydratedProgressionTrackVector(intPtr, cMemoryOwn: true));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		MothershipApiPINVOKE.UserHydratedProgressionTrackVector_Reverse__SWIG_0(swigCPtr);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		MothershipApiPINVOKE.UserHydratedProgressionTrackVector_Reverse__SWIG_1(swigCPtr, index, count);
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, UserHydratedProgressionTrackVector values)
	{
		MothershipApiPINVOKE.UserHydratedProgressionTrackVector_SetRange(swigCPtr, index, getCPtr(values));
		if (MothershipApiPINVOKE.SWIGPendingException.Pending)
		{
			throw MothershipApiPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
