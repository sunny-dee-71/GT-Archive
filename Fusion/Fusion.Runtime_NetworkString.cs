namespace Fusion;

public static class NetworkString
{
	public unsafe static int GetCapacity<TSize>() where TSize : unmanaged, IFixedStorage
	{
		return sizeof(TSize) / 4;
	}
}
