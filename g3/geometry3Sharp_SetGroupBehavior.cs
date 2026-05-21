namespace g3;

public struct SetGroupBehavior(SetGroupBehavior.Modes mode, int id = 0)
{
	public enum Modes
	{
		Ignore,
		AutoGenerate,
		UseConstant
	}

	private Modes Mode = mode;

	private int SetGroupID = id;

	public static SetGroupBehavior Ignore => new SetGroupBehavior(Modes.Ignore);

	public static SetGroupBehavior AutoGenerate => new SetGroupBehavior(Modes.AutoGenerate);

	public int GetGroupID(DMesh3 mesh)
	{
		if (Mode == Modes.Ignore)
		{
			return -1;
		}
		if (Mode == Modes.AutoGenerate)
		{
			return mesh.AllocateTriangleGroup();
		}
		return SetGroupID;
	}

	public static SetGroupBehavior SetTo(int groupID)
	{
		return new SetGroupBehavior(Modes.UseConstant, groupID);
	}
}
