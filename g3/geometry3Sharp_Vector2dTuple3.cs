namespace g3;

public struct Vector2dTuple3(Vector2d v0, Vector2d v1, Vector2d v2)
{
	public Vector2d V0 = v0;

	public Vector2d V1 = v1;

	public Vector2d V2 = v2;

	public Vector2d this[int key]
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
