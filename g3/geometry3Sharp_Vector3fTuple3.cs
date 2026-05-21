namespace g3;

public struct Vector3fTuple3(Vector3f v0, Vector3f v1, Vector3f v2)
{
	public Vector3f V0 = v0;

	public Vector3f V1 = v1;

	public Vector3f V2 = v2;

	public Vector3f this[int key]
	{
		get
		{
			return key switch
			{
				1 => V1, 
				0 => V0, 
				_ => V2, 
			};
		}
		set
		{
			switch (key)
			{
			case 0:
				V0 = value;
				break;
			case 1:
				V1 = value;
				break;
			default:
				V2 = value;
				break;
			}
		}
	}
}
