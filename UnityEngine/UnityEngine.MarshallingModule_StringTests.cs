using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal class StringTests
{
	public unsafe static void SetTestOutString(string testString)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(testString, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(testString);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					SetTestOutString_Injected(ref managedSpanWrapper);
					return;
				}
			}
			SetTestOutString_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void ParameterICallString(string param)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ParameterICallString_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ParameterICallString_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void ParameterICallNullString(string param)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ParameterICallNullString_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ParameterICallNullString_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void ParameterCoreString(string param)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ParameterCoreString_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ParameterCoreString_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void ParameterConstCharPtr(string param)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ParameterConstCharPtr_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ParameterConstCharPtr_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void ParameterConstCharPtrNull(string param)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ParameterConstCharPtrNull_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ParameterConstCharPtrNull_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void ParameterConstCharPtrEmptyString(string param)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ParameterConstCharPtrEmptyString_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ParameterConstCharPtrEmptyString_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void ParameterCoreStringVector(string[] param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void ParameterCoreStringDynamicArray(string[] param);

	[NativeThrows]
	public static void ParameterStructCoreString(StructCoreString param)
	{
		ParameterStructCoreString_Injected(ref param);
	}

	[NativeThrows]
	public static void ParameterStructCoreStringVector(StructCoreStringVector param)
	{
		ParameterStructCoreStringVector_Injected(ref param);
	}

	[NativeThrows]
	public static StructCoreString TestCoreStringViaProxy(StructCoreString param)
	{
		TestCoreStringViaProxy_Injected(ref param, out var ret);
		return ret;
	}

	public static string ReturnCoreString()
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			ReturnCoreString_Injected(out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static string ReturnCoreStringRef()
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			ReturnCoreStringRef_Injected(out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static string ReturnConstCharPtr()
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			ReturnConstCharPtr_Injected(out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] ReturnCoreStringVector();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] ReturnCoreStringDynamicArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] ReturnNullStringDynamicArray();

	public static StructCoreString ReturnStructCoreString()
	{
		ReturnStructCoreString_Injected(out var ret);
		return ret;
	}

	[NativeConditional("FOO")]
	public static string FalseConditional()
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			FalseConditional_Injected(out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static StructCoreStringVector ReturnStructCoreStringVector()
	{
		ReturnStructCoreStringVector_Injected(out var ret);
		return ret;
	}

	[NativeThrows]
	public static void ParameterOutString(out string param)
	{
		ManagedSpanWrapper param2 = default(ManagedSpanWrapper);
		try
		{
			ParameterOutString_Injected(out param2);
		}
		finally
		{
			param = OutStringMarshaller.GetStringAndDispose(param2);
		}
	}

	[NativeThrows]
	public static void ParameterOutStringInNull(out string param)
	{
		ManagedSpanWrapper param2 = default(ManagedSpanWrapper);
		try
		{
			ParameterOutStringInNull_Injected(out param2);
		}
		finally
		{
			param = OutStringMarshaller.GetStringAndDispose(param2);
		}
	}

	[NativeThrows]
	public static void ParameterOutStringNotSet(out string param)
	{
		ManagedSpanWrapper param2 = default(ManagedSpanWrapper);
		try
		{
			ParameterOutStringNotSet_Injected(out param2);
		}
		finally
		{
			param = OutStringMarshaller.GetStringAndDispose(param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterRefString(ref string param)
	{
		//The blocks IL_002b are reachable both inside and outside the pinned region starting at IL_001a. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
		try
		{
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ParameterRefString_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ParameterRefString_Injected(ref managedSpanWrapper);
		}
		finally
		{
			param = OutStringMarshaller.GetStringAndDispose(managedSpanWrapper);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterRefStringInNull(ref string param)
	{
		//The blocks IL_002b are reachable both inside and outside the pinned region starting at IL_001a. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
		try
		{
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ParameterRefStringInNull_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ParameterRefStringInNull_Injected(ref managedSpanWrapper);
		}
		finally
		{
			param = OutStringMarshaller.GetStringAndDispose(managedSpanWrapper);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterRefStringNotSet(ref string param)
	{
		//The blocks IL_002b are reachable both inside and outside the pinned region starting at IL_001a. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
		try
		{
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ParameterRefStringNotSet_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ParameterRefStringNotSet_Injected(ref managedSpanWrapper);
		}
		finally
		{
			param = OutStringMarshaller.GetStringAndDispose(managedSpanWrapper);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetTestOutString_Injected(ref ManagedSpanWrapper testString);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterICallString_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterICallNullString_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterCoreString_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterConstCharPtr_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterConstCharPtrNull_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterConstCharPtrEmptyString_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructCoreString_Injected([In] ref StructCoreString param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructCoreStringVector_Injected([In] ref StructCoreStringVector param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void TestCoreStringViaProxy_Injected([In] ref StructCoreString param, out StructCoreString ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnCoreString_Injected(out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnCoreStringRef_Injected(out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnConstCharPtr_Injected(out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnStructCoreString_Injected(out StructCoreString ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void FalseConditional_Injected(out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnStructCoreStringVector_Injected(out StructCoreStringVector ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterOutString_Injected(out ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterOutStringInNull_Injected(out ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterOutStringNotSet_Injected(out ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterRefString_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterRefStringInNull_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterRefStringNotSet_Injected(ref ManagedSpanWrapper param);
}
