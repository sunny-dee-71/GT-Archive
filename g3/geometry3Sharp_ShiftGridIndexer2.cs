namespace g3;

public struct ShiftGridIndexer2(Vector2d origin, double cellSize) : IGridWorldIndexer2
{
	public Vector2d Origin = origin;

	public double CellSize = cellSize;

	public Vector2i ToGrid(Vector2d point)
	{
		return new Vector2i((int)((point.x - Origin.x) / CellSize), (int)((point.y - Origin.y) / CellSize));
	}

	public Vector2d FromGrid(Vector2i gridpoint)
	{
		return new Vector2d((double)gridpoint.x * CellSize + Origin.x, (double)gridpoint.y * CellSize + Origin.y);
	}

	public Vector2d FromGrid(Vector2d gridpointf)
	{
		return new Vector2d(gridpointf.x * CellSize + Origin.x, gridpointf.y * CellSize + Origin.y);
	}
}
