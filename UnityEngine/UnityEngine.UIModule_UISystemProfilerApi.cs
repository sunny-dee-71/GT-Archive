using System;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine.Bindings;

namespace UnityEngine;

[StaticAccessor("UI::SystemProfilerApi", StaticAccessorType.DoubleColon)]
[IgnoredByDeepProfiler]
[NativeHeader("Modules/UI/Canvas.h")]
public static class UISystemProfilerApi
{
	public enum SampleType
	{
		Layout,
		Render
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void BeginSample(SampleType type);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void EndSample(SampleType type);

	public unsafe static void AddMarker(string name, Object obj)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					AddMarker_Injected(ref managedSpanWrapper, Object.MarshalledUnityObject.Marshal(obj));
					return;
				}
			}
			AddMarker_Injected(ref managedSpanWrapper, Object.MarshalledUnityObject.Marshal(obj));
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void AddMarker_Injected(ref ManagedSpanWrapper name, IntPtr obj);
}
