namespace g3;

public struct MultigridIndexer3(Vector3i blockSize) : IMultigridIndexer3
{
	public Vector3i OuterShift = (BlockShift = Vector3i.Zero);

	public Vector3i BlockSize = blockSize;

	public Vector3i BlockShift;

	public Vector3i ToBlockIndex(Vector3i outer_index)
	{
		Vector3i vector3i = outer_index - OuterShift;
		vector3i.x = ((vector3i.x >= 0) ? (vector3i.x / BlockSize.x) : (vector3i.x / BlockSize.x - 1));
		vector3i.y = ((vector3i.y >= 0) ? (vector3i.y / BlockSize.y) : (vector3i.y / BlockSize.y - 1));
		vector3i.z = ((vector3i.z >= 0) ? (vector3i.z / BlockSize.z) : (vector3i.z / BlockSize.z - 1));
		return vector3i - BlockShift;
	}

	public Vector3i ToBlockLocal(Vector3i outer_index)
	{
		Vector3i vector3i = ToBlockIndex(outer_index);
		return outer_index - vector3i * BlockSize;
	}

	public GridLevelIndex ToBlock(Vector3i outer_index)
	{
		Vector3i vector3i = outer_index - OuterShift;
		vector3i.x = ((vector3i.x >= 0) ? (vector3i.x / BlockSize.x) : (vector3i.x / BlockSize.x - 1));
		vector3i.y = ((vector3i.y >= 0) ? (vector3i.y / BlockSize.y) : (vector3i.y / BlockSize.y - 1));
		vector3i.z = ((vector3i.z >= 0) ? (vector3i.z / BlockSize.z) : (vector3i.z / BlockSize.z - 1));
		vector3i -= BlockShift;
		return new GridLevelIndex
		{
			block_index = vector3i,
			local_index = outer_index - vector3i * BlockSize
		};
	}

	public Vector3i FromBlock(Vector3i block_idx)
	{
		return (block_idx + BlockShift) * BlockSize + OuterShift;
	}
}
