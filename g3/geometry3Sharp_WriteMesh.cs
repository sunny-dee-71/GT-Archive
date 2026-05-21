using System.Collections.Generic;

namespace g3;

public struct WriteMesh(IMesh mesh, string name = "")
{
	public IMesh Mesh = mesh;

	public string Name = name;

	public List<GenericMaterial> Materials = null;

	public IIndexMap TriToMaterialMap = null;

	public DenseUVMesh UVs = null;
}
