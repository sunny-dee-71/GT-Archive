using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine;

[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[NativeClass("StructCoreString", "struct StructCoreString;")]
[RequiredByNativeCode(GenerateProxy = true, Name = "StructCoreStringManaged", Optional = true)]
[ExcludeFromDocs]
internal struct StructCoreString
{
	public string field;

	public string GetField()
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			GetField_Injected(ref this, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public unsafe void SetField(string value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(value);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					SetField_Injected(ref this, ref managedSpanWrapper);
					return;
				}
			}
			SetField_Injected(ref this, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetField_Injected(ref StructCoreString _unity_self, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetField_Injected(ref StructCoreString _unity_self, ref ManagedSpanWrapper value);
}
