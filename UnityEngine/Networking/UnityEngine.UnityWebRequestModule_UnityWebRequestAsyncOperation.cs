using System;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Networking;

[StructLayout(LayoutKind.Sequential)]
[UsedByNativeCode]
[NativeHeader("Modules/UnityWebRequest/Public/UnityWebRequestAsyncOperation.h")]
[NativeHeader("UnityWebRequestScriptingClasses.h")]
public class UnityWebRequestAsyncOperation : AsyncOperation
{
	internal new static class BindingsMarshaller
	{
		public static UnityWebRequestAsyncOperation ConvertToManaged(IntPtr ptr)
		{
			return new UnityWebRequestAsyncOperation(ptr);
		}
	}

	public UnityWebRequest webRequest { get; internal set; }

	public UnityWebRequestAsyncOperation()
	{
	}

	private UnityWebRequestAsyncOperation(IntPtr ptr)
		: base(ptr)
	{
	}
}
