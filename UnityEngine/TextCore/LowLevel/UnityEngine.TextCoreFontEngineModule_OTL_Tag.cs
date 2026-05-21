using UnityEngine.Scripting;

namespace UnityEngine.TextCore.LowLevel;

[UsedByNativeCode]
internal struct OTL_Tag
{
	public byte c0;

	public byte c1;

	public byte c2;

	public byte c3;

	public byte c4;

	public unsafe override string ToString()
	{
		char* ptr = stackalloc char[4];
		*ptr = (char)c0;
		ptr[1] = (char)c1;
		ptr[2] = (char)c2;
		ptr[3] = (char)c3;
		return new string(ptr);
	}
}
