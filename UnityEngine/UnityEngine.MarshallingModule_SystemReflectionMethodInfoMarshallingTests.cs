using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/SystemReflectionMethodInfoMarshallingTests.h")]
internal static class SystemReflectionMethodInfoMarshallingTests
{
	public static string CanMarshallMethodInfoArgumentToScriptingMethodPtr(MethodInfo param)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			CanMarshallMethodInfoArgumentToScriptingMethodPtr_Injected(param, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static string CanMarshallSystemReflectionMethodInfoStructField(StructSystemReflectionMethodInfo param)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			CanMarshallSystemReflectionMethodInfoStructField_Injected(ref param, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static string[] CanMarshallSystemReflectionMethodInfoArrayStructField(StructSystemReflectionMethodInfoArray param)
	{
		return CanMarshallSystemReflectionMethodInfoArrayStructField_Injected(ref param);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] CanMarshallArrayOfMethodInfoArgumentToDynamicArrayOfScriptingMethodInfoObjectPtr(MethodInfo[] param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] CanMarshallArrayOfMethodInfoArgumentToDynamicArrayOfScriptingMethodPtr(MethodInfo[] param);

	public static StructSystemReflectionMethodInfo CanUnmarshallSystemReflectionMethodInfoStructField()
	{
		CanUnmarshallSystemReflectionMethodInfoStructField_Injected(out var ret);
		return ret;
	}

	public static StructSystemReflectionMethodInfoArray CanUnmarshallSystemReflectionMethodInfoArrayStructField()
	{
		CanUnmarshallSystemReflectionMethodInfoArrayStructField_Injected(out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern MethodInfo CanUnmarshallScriptingMethodInfoObjectPtrToMethodInfo();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern MethodInfo CanUnmarshallScriptingMethodPtrToMethodInfo();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern MethodInfo[] CanUnmarshallScriptingArrayPtrToMethodInfoArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern MethodInfo[] CanUnmarshallArrayOfScriptingMethodInfoObjectPtrToMethodInfoArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern MethodInfo[] CanUnmarshallArrayOfScriptingMethodPtrToMethodInfoArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanMarshallMethodInfoArgumentToScriptingMethodPtr_Injected(MethodInfo param, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanMarshallSystemReflectionMethodInfoStructField_Injected([In] ref StructSystemReflectionMethodInfo param, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string[] CanMarshallSystemReflectionMethodInfoArrayStructField_Injected([In] ref StructSystemReflectionMethodInfoArray param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanUnmarshallSystemReflectionMethodInfoStructField_Injected(out StructSystemReflectionMethodInfo ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanUnmarshallSystemReflectionMethodInfoArrayStructField_Injected(out StructSystemReflectionMethodInfoArray ret);
}
