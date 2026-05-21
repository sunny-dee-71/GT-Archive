internal static class OVREnumerable
{
	public unsafe static int CopyTo<T>(this OVREnumerable<T> enumerable, T* memory) where T : unmanaged
	{
		int result = 0;
		foreach (T item in enumerable)
		{
			memory[result++] = item;
		}
		return result;
	}
}
