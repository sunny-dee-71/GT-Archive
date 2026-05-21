using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Networking;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/UnityWebRequest/Public/CertificateHandler/CertificateHandlerScript.h")]
public class CertificateHandler : IDisposable
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(CertificateHandler handler)
		{
			return handler.m_Ptr;
		}
	}

	[NonSerialized]
	internal IntPtr m_Ptr;

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Create([Unmarshalled] CertificateHandler obj);

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

	protected CertificateHandler()
	{
		m_Ptr = Create(this);
	}

	~CertificateHandler()
	{
		Dispose();
	}

	protected virtual bool ValidateCertificate(byte[] certificateData)
	{
		return false;
	}

	[RequiredByNativeCode]
	internal bool ValidateCertificateNative(byte[] certificateData)
	{
		return ValidateCertificate(certificateData);
	}

	public void Dispose()
	{
		if (m_Ptr != IntPtr.Zero)
		{
			ReleaseFromScripting();
			m_Ptr = IntPtr.Zero;
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReleaseFromScripting_Injected(IntPtr _unity_self);
}
