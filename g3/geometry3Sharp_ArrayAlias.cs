namespace g3;

public struct ArrayAlias<T>(T[] source, int i)
{
	public T[] Source = source;

	public int Index = i;

	public T this[int i]
	{
		get
		{
			return Source[Index + i];
		}
		set
		{
			Source[Index + i] = value;
		}
	}
}
