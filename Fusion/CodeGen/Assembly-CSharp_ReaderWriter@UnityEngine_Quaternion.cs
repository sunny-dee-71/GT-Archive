using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fusion.CodeGen;

[StructLayout(LayoutKind.Sequential, Size = 1)]
[WeaverGenerated]
internal struct ReaderWriter@UnityEngine_Quaternion : IElementReaderWriter<Quaternion>
{
	[WeaverGenerated]
	public static IElementReaderWriter<Quaternion> Instance;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[WeaverGenerated]
	public unsafe Quaternion Read(byte* data, int index)
	{
		return *(Quaternion*)(data + index * 16);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[WeaverGenerated]
	public unsafe ref Quaternion ReadRef(byte* data, int index)
	{
		return ref *(Quaternion*)(data + index * 16);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[WeaverGenerated]
	public unsafe void Write(byte* data, int index, Quaternion val)
	{
		*(Quaternion*)(data + index * 16) = val;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[WeaverGenerated]
	public int GetElementWordCount()
	{
		return 4;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[WeaverGenerated]
	public int GetElementHashCode(Quaternion val)
	{
		return val.GetHashCode();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[WeaverGenerated]
	public static IElementReaderWriter<Quaternion> GetInstance()
	{
		if (Instance == null)
		{
			Instance = default(ReaderWriter@UnityEngine_Quaternion);
		}
		return Instance;
	}
}
