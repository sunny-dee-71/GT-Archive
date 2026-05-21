using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine.Networking;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/UnityWebRequest/Public/UploadHandler/UploadHandlerFile.h")]
public sealed class UploadHandlerFile : UploadHandler
{
	internal new static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(UploadHandlerFile uploadHandler)
		{
			return uploadHandler.m_Ptr;
		}
	}

	[NativeThrows]
	private unsafe static IntPtr Create([Unmarshalled] UploadHandlerFile self, string filePath)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(filePath, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(filePath);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return Create_Injected(self, ref managedSpanWrapper);
				}
			}
			return Create_Injected(self, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	public UploadHandlerFile(string filePath)
	{
		m_Ptr = Create(this, filePath);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Create_Injected(UploadHandlerFile self, ref ManagedSpanWrapper filePath);
}
