using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine;

internal static class SubsystemDescriptorBindings
{
	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern IntPtr Create(IntPtr descriptorPtr);

	public static string GetId(IntPtr descriptorPtr)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			GetId_Injected(descriptorPtr, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetId_Injected(IntPtr descriptorPtr, out ManagedSpanWrapper ret);
}
