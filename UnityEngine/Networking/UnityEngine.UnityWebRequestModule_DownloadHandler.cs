using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Networking;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/UnityWebRequest/Public/DownloadHandler/DownloadHandler.h")]
public class DownloadHandler : IDisposable
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(DownloadHandler handler)
		{
			return handler.m_Ptr;
		}
	}

	[NonSerialized]
	[VisibleToOtherModules]
	internal IntPtr m_Ptr;

	public bool isDone => IsDone();

	public string error => GetErrorMsg();

	public NativeArray<byte>.ReadOnly nativeData => GetNativeData().AsReadOnly();

	public byte[] data => GetData();

	public string text => GetText();

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

	[VisibleToOtherModules]
	internal DownloadHandler()
	{
	}

	~DownloadHandler()
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

	private bool IsDone()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return IsDone_Injected(intPtr);
	}

	private string GetErrorMsg()
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
			GetErrorMsg_Injected(intPtr, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	protected virtual NativeArray<byte> GetNativeData()
	{
		return default(NativeArray<byte>);
	}

	protected virtual byte[] GetData()
	{
		return InternalGetByteArray(this);
	}

	protected unsafe virtual string GetText()
	{
		NativeArray<byte> nativeArray = GetNativeData();
		if (nativeArray.IsCreated && nativeArray.Length > 0)
		{
			return new string((sbyte*)nativeArray.GetUnsafeReadOnlyPtr(), 0, nativeArray.Length, GetTextEncoder());
		}
		return "";
	}

	private Encoding GetTextEncoder()
	{
		string contentType = GetContentType();
		if (!string.IsNullOrEmpty(contentType))
		{
			int num = contentType.IndexOf("charset", StringComparison.OrdinalIgnoreCase);
			if (num > -1)
			{
				int num2 = contentType.IndexOf('=', num);
				if (num2 > -1)
				{
					string text = contentType.Substring(num2 + 1).Trim().Trim('\'', '"')
						.Trim();
					int num3 = text.IndexOf(';');
					if (num3 > -1)
					{
						text = text.Substring(0, num3);
					}
					try
					{
						return Encoding.GetEncoding(text);
					}
					catch (ArgumentException ex)
					{
						Debug.LogWarning($"Unsupported encoding '{text}': {ex.Message}");
					}
					catch (NotSupportedException ex2)
					{
						Debug.LogWarning($"Unsupported encoding '{text}': {ex2.Message}");
					}
				}
			}
		}
		return Encoding.UTF8;
	}

	private string GetContentType()
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
			GetContentType_Injected(intPtr, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[RequiredByNativeCode]
	protected virtual bool ReceiveData(byte[] data, int dataLength)
	{
		return true;
	}

	[RequiredByNativeCode]
	protected virtual void ReceiveContentLengthHeader(ulong contentLength)
	{
		ReceiveContentLength((int)contentLength);
	}

	[Obsolete("Use ReceiveContentLengthHeader")]
	protected virtual void ReceiveContentLength(int contentLength)
	{
	}

	[RequiredByNativeCode]
	protected virtual void CompleteContent()
	{
	}

	[RequiredByNativeCode]
	protected virtual float GetProgress()
	{
		return 0f;
	}

	protected static T GetCheckedDownloader<T>(UnityWebRequest www) where T : DownloadHandler
	{
		if (www == null)
		{
			throw new NullReferenceException("Cannot get content from a null UnityWebRequest object");
		}
		if (!www.isDone)
		{
			throw new InvalidOperationException("Cannot get content from an unfinished UnityWebRequest object");
		}
		if (www.result == UnityWebRequest.Result.ProtocolError)
		{
			throw new InvalidOperationException(www.error);
		}
		return (T)www.downloadHandler;
	}

	[VisibleToOtherModules]
	[NativeThrows]
	internal unsafe static byte* InternalGetByteArray(DownloadHandler dh, out int length)
	{
		return InternalGetByteArray_Injected((dh == null) ? ((IntPtr)0) : BindingsMarshaller.ConvertToNative(dh), out length);
	}

	internal static byte[] InternalGetByteArray(DownloadHandler dh)
	{
		NativeArray<byte> nativeArray = dh.GetNativeData();
		if (nativeArray.IsCreated)
		{
			return nativeArray.ToArray();
		}
		return null;
	}

	[VisibleToOtherModules(new string[] { "UnityEngine.UnityWebRequestAudioModule", "UnityEngine.UnityWebRequestTextureModule" })]
	internal unsafe static NativeArray<byte> InternalGetNativeArray(DownloadHandler dh, ref NativeArray<byte> nativeArray)
	{
		int length;
		byte* bytes = InternalGetByteArray(dh, out length);
		if (nativeArray.IsCreated)
		{
			if (nativeArray.Length == length)
			{
				return nativeArray;
			}
			DisposeNativeArray(ref nativeArray);
		}
		CreateNativeArrayForNativeData(ref nativeArray, bytes, length);
		return nativeArray;
	}

	[VisibleToOtherModules(new string[] { "UnityEngine.UnityWebRequestAudioModule", "UnityEngine.UnityWebRequestTextureModule" })]
	internal static void DisposeNativeArray(ref NativeArray<byte> data)
	{
		if (data.IsCreated)
		{
			data = default(NativeArray<byte>);
		}
	}

	internal unsafe static void CreateNativeArrayForNativeData(ref NativeArray<byte> data, byte* bytes, int length)
	{
		data = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(bytes, length, Allocator.Persistent);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReleaseFromScripting_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsDone_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetErrorMsg_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetContentType_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern byte* InternalGetByteArray_Injected(IntPtr dh, out int length);
}
