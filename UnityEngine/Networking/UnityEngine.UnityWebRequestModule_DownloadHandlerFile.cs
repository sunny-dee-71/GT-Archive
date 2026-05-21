using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using UnityEngine.Bindings;

namespace UnityEngine.Networking;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/UnityWebRequest/Public/DownloadHandler/DownloadHandlerVFS.h")]
public sealed class DownloadHandlerFile : DownloadHandler
{
	internal new static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(DownloadHandlerFile handler)
		{
			return handler.m_Ptr;
		}
	}

	public bool removeFileOnAbort
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_removeFileOnAbort_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_removeFileOnAbort_Injected(intPtr, value);
		}
	}

	[NativeThrows]
	private unsafe static IntPtr Create([Unmarshalled] DownloadHandlerFile obj, string path, bool append)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(path, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(path);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return Create_Injected(obj, ref managedSpanWrapper, append);
				}
			}
			return Create_Injected(obj, ref managedSpanWrapper, append);
		}
		finally
		{
		}
	}

	private void InternalCreateVFS(string path, bool append)
	{
		string directoryName = Path.GetDirectoryName(path);
		if (!Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		m_Ptr = Create(this, path, append);
	}

	public DownloadHandlerFile(string path)
	{
		InternalCreateVFS(path, append: false);
	}

	public DownloadHandlerFile(string path, bool append)
	{
		InternalCreateVFS(path, append);
	}

	protected override NativeArray<byte> GetNativeData()
	{
		throw new NotSupportedException("Raw data access is not supported");
	}

	protected override byte[] GetData()
	{
		throw new NotSupportedException("Raw data access is not supported");
	}

	protected override string GetText()
	{
		throw new NotSupportedException("String access is not supported");
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Create_Injected(DownloadHandlerFile obj, ref ManagedSpanWrapper path, bool append);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_removeFileOnAbort_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_removeFileOnAbort_Injected(IntPtr _unity_self, bool value);
}
