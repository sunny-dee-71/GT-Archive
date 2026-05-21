using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine.Networking;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/UnityWebRequest/Public/UploadHandler/UploadHandler.h")]
public class UploadHandler : IDisposable
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(UploadHandler uploadHandler)
		{
			return uploadHandler.m_Ptr;
		}
	}

	[NonSerialized]
	internal IntPtr m_Ptr;

	public byte[] data => GetData();

	public string contentType
	{
		get
		{
			return GetContentType();
		}
		set
		{
			SetContentType(value);
		}
	}

	public float progress => GetProgress();

	[NativeMethod(IsThreadSafe = true)]
	private void ReleaseFromScripting()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ReleaseFromScripting_Injected(intPtr);
	}

	internal UploadHandler()
	{
	}

	~UploadHandler()
	{
		Dispose();
	}

	public virtual void Dispose()
	{
		if (m_Ptr != IntPtr.Zero)
		{
			ReleaseFromScripting();
			m_Ptr = IntPtr.Zero;
		}
	}

	internal virtual byte[] GetData()
	{
		return null;
	}

	internal virtual string GetContentType()
	{
		return InternalGetContentType();
	}

	internal virtual void SetContentType(string newContentType)
	{
		InternalSetContentType(newContentType);
	}

	internal virtual float GetProgress()
	{
		return InternalGetProgress();
	}

	[NativeMethod("GetContentType")]
	private string InternalGetContentType()
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			InternalGetContentType_Injected(intPtr, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[NativeMethod("SetContentType")]
	private unsafe void InternalSetContentType(string newContentType)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(newContentType, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(newContentType);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					InternalSetContentType_Injected(intPtr, ref managedSpanWrapper);
					return;
				}
			}
			InternalSetContentType_Injected(intPtr, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[NativeMethod("GetProgress")]
	private float InternalGetProgress()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return InternalGetProgress_Injected(intPtr);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReleaseFromScripting_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void InternalGetContentType_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void InternalSetContentType_Injected(IntPtr _unity_self, ref ManagedSpanWrapper newContentType);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float InternalGetProgress_Injected(IntPtr _unity_self);
}
