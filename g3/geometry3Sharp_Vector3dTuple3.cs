namespace g3;

public struct Vector3dTuple3(Vector3d v0, Vector3d v1, Vector3d v2)
{
	public Vector3d V0 = v0;

	public Vector3d V1 = v1;

	public Vector3d V2 = v2;

	public Vector3d this[int key]
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
