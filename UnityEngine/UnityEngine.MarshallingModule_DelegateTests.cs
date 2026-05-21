using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal class DelegateTests
{
	public delegate int SomeDelegate();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate int SomeDelegateFunctionPtr();

	public static int A()
	{
		return 882;
	}

	[MonoPInvokeCallback(typeof(SomeDelegateFunctionPtr))]
	public static int B()
	{
		return 883;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern int ReturnDelegate(SomeDelegate someDelegate);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern int ReturnDelegateFunctionPtr(SomeDelegateFunctionPtr SomeDelegateFunctionPtr);
}
