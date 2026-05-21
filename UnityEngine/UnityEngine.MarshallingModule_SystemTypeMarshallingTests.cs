using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/SystemTypeMarshallingTests.h")]
internal static class SystemTypeMarshallingTests
{
	public static string CanMarshallSystemTypeArgumentToScriptingClassPtr(Type param)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			CanMarshallSystemTypeArgumentToScriptingClassPtr_Injected(param, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static string CanMarshallSystemTypeStructField(StructSystemType param)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			CanMarshallSystemTypeStructField_Injected(ref param, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static string[] CanMarshallSystemTypeArrayStructField(StructSystemTypeArray param)
	{
		return CanMarshallSystemTypeArrayStructField_Injected(ref param);
	}

	public static StructSystemType CanUnmarshallSystemTypeStructField()
	{
		CanUnmarshallSystemTypeStructField_Injected(out var ret);
		return ret;
	}

	public static StructSystemTypeArray CanUnmarshallSystemTypeArrayStructField()
	{
		CanUnmarshallSystemTypeArrayStructField_Injected(out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] CanUnmarshallArrayOfSystemTypeArgumentToDynamicArrayOfScriptingSystemTypeObjectPtr(Type[] param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] CanUnmarshallArrayOfSystemTypeArgumentToDynamicArrayOfUnityType(Type[] param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] CanUnmarshallArrayOfSystemTypeArgumentToDynamicArrayOfScriptingClassPtr(Type[] param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern Type CanUnmarshallScriptingSystemTypeObjectPtrToSystemType();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern Type CanUnmarshallUnityTypeToSystemType();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern Type CanUnmarshallScriptingClassPtrToSystemType();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern Type[] CanUnmarshallScriptingArrayPtrToSystemTypeArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern Type[] CanUnmarshallArrayOfScriptingSystemTypeObjectPtrToSystemTypeArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern Type[] CanUnmarshallArrayOfUnityTypeToSystemTypeArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern Type[] CanUnmarshallArrayOfScriptingClassPtrToSystemTypeArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanMarshallSystemTypeArgumentToScriptingClassPtr_Injected(Type param, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanMarshallSystemTypeStructField_Injected([In] ref StructSystemType param, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string[] CanMarshallSystemTypeArrayStructField_Injected([In] ref StructSystemTypeArray param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanUnmarshallSystemTypeStructField_Injected(out StructSystemType ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanUnmarshallSystemTypeArrayStructField_Injected(out StructSystemTypeArray ret);
}
