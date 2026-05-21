using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[NativeHeader("Modules/Marshalling/SystemReflectionFieldInfoMarshallingTests.h")]
[ExcludeFromDocs]
internal static class SystemReflectionFieldInfoMarshallingTests
{
	public static string CanMarshallFieldInfoArgumentToScriptingFieldPtr(FieldInfo param)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			CanMarshallFieldInfoArgumentToScriptingFieldPtr_Injected(param, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static string CanMarshallSystemReflectionFieldInfoStructField(StructSystemReflectionFieldInfo param)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			CanMarshallSystemReflectionFieldInfoStructField_Injected(ref param, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static string[] CanMarshallSystemReflectionFieldInfoArrayStructField(StructSystemReflectionFieldInfoArray param)
	{
		return CanMarshallSystemReflectionFieldInfoArrayStructField_Injected(ref param);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] CanMarshallArrayOfFieldInfoArgumentToDynamicArrayOfScriptingFieldInfoObjectPtr(FieldInfo[] param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] CanMarshallArrayOfFieldInfoArgumentToDynamicArrayOfScriptingFieldPtr(FieldInfo[] param);

	public static StructSystemReflectionFieldInfo CanUnmarshallSystemReflectionFieldInfoStructField()
	{
		CanUnmarshallSystemReflectionFieldInfoStructField_Injected(out var ret);
		return ret;
	}

	public static StructSystemReflectionFieldInfoArray CanUnmarshallSystemReflectionFieldInfoArrayStructField()
	{
		CanUnmarshallSystemReflectionFieldInfoArrayStructField_Injected(out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern FieldInfo CanUnmarshallScriptingFieldInfoObjectPtrToFieldInfo();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern FieldInfo CanUnmarshallScriptingFieldPtrToFieldInfo();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern FieldInfo[] CanUnmarshallScriptingArrayPtrToFieldInfoArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern FieldInfo[] CanUnmarshallArrayOfScriptingFieldInfoObjectPtrToFieldInfoArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern FieldInfo[] CanUnmarshallArrayOfScriptingFieldPtrToFieldInfoArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanMarshallFieldInfoArgumentToScriptingFieldPtr_Injected(FieldInfo param, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanMarshallSystemReflectionFieldInfoStructField_Injected([In] ref StructSystemReflectionFieldInfo param, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string[] CanMarshallSystemReflectionFieldInfoArrayStructField_Injected([In] ref StructSystemReflectionFieldInfoArray param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanUnmarshallSystemReflectionFieldInfoStructField_Injected(out StructSystemReflectionFieldInfo ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanUnmarshallSystemReflectionFieldInfoArrayStructField_Injected(out StructSystemReflectionFieldInfoArray ret);
}
