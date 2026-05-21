using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.XR.Provider;

public static class XRStats
{
	public static bool TryGetStat(IntegratedSubsystem xrSubsystem, string tag, out float value)
	{
		return TryGetStat_Internal(xrSubsystem.m_Ptr, tag, out value);
	}

	[StaticAccessor("XRStats::Get()", StaticAccessorType.Dot)]
	[NativeMethod("TryGetStatByName_Internal")]
	[NativeHeader("Modules/XR/Stats/XRStats.h")]
	[NativeConditional("ENABLE_XR")]
	private unsafe static bool TryGetStat_Internal(IntPtr ptr, string tag, out float value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(tag, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(tag);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return TryGetStat_Internal_Injected(ptr, ref managedSpanWrapper, out value);
				}
			}
			return TryGetStat_Internal_Injected(ptr, ref managedSpanWrapper, out value);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetStat_Internal_Injected(IntPtr ptr, ref ManagedSpanWrapper tag, out float value);
}
