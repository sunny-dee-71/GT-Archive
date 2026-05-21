using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal class BoolStructTests
{
	[NativeThrows]
	public static void ParameterStructWith8ByteAndBoolFields(StructWith8ByteAndBoolFields param)
	{
		ParameterStructWith8ByteAndBoolFields_Injected(ref param);
	}

	[NativeThrows]
	public unsafe static void ParameterStructWith8ByteAndBoolFieldsArray(StructWith8ByteAndBoolFields[] param)
	{
		Span<StructWith8ByteAndBoolFields> span = new Span<StructWith8ByteAndBoolFields>(param);
		fixed (StructWith8ByteAndBoolFields* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterStructWith8ByteAndBoolFieldsArray_Injected(ref param2);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructWith8ByteAndBoolFields_Injected([In] ref StructWith8ByteAndBoolFields param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructWith8ByteAndBoolFieldsArray_Injected(ref ManagedSpanWrapper param);
}
