using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Playables;

[NativeHeader("Modules/Director/ScriptBindings/DataPlayableOutputExtensions.bindings.h")]
[NativeHeader("Runtime/Director/Core/HPlayableOutput.h")]
[StaticAccessor("DataPlayableOutputExtensionsBindings", StaticAccessorType.DoubleColon)]
internal static class DataPlayableOutputExtensions
{
	[NativeThrows]
	internal unsafe static bool InternalCreateDataOutput(ref PlayableGraph graph, string name, Type type, out PlayableOutputHandle handle)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return InternalCreateDataOutput_Injected(ref graph, ref managedSpanWrapper, type, out handle);
				}
			}
			return InternalCreateDataOutput_Injected(ref graph, ref managedSpanWrapper, type, out handle);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool InternalCreateDataOutput_Injected(ref PlayableGraph graph, ref ManagedSpanWrapper name, Type type, out PlayableOutputHandle handle);
}
