using System;

namespace Fusion;

public unsafe struct NetworkObjectHeaderPtr(NetworkObjectHeader* ptr)
{
	public unsafe NetworkObjectHeader* Ptr = ptr;

	public unsafe NetworkObjectTypeId Type => Ptr->Type;

	public unsafe NetworkId Id => Ptr->Id;

	public unsafe Span<int> Data => new Span<int>((byte*)Ptr + (nint)20 * (nint)4, Ptr->WordCount - 20);
}
