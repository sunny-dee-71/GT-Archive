using System;
using System.Runtime.InteropServices;
using UnityEngine.Analytics;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEditor.Analytics;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[RequiredByNativeCode(GenerateProxy = true)]
[ExcludeFromDocs]
public class MetalPatchShaderComputeBufferAnalytic : AnalyticsEventBase
{
	public MetalPatchShaderComputeBufferAnalytic()
		: base("MetalPatchShaderComputeBuffersUsage", 1)
	{
	}

	[RequiredByNativeCode]
	internal static MetalPatchShaderComputeBufferAnalytic CreateMetalPatchShaderComputeBufferAnalytic()
	{
		return new MetalPatchShaderComputeBufferAnalytic();
	}
}
