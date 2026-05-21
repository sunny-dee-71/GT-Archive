using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine;

[UsedByNativeCode]
[NativeType("Runtime/Graphics/DisplayInfo.h")]
public struct DisplayInfo : IEquatable<DisplayInfo>
{
	[RequiredMember]
	internal ulong handle;

	[RequiredMember]
	public int width;

	[RequiredMember]
	public int height;

	[RequiredMember]
	public RefreshRate refreshRate;

	[RequiredMember]
	public RectInt workArea;

	[RequiredMember]
	public string name;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Equals(DisplayInfo other)
	{
		return handle == other.handle && width == other.width && height == other.height && refreshRate.Equals(other.refreshRate) && workArea.Equals(other.workArea) && name == other.name;
	}
}
