namespace UnityEngine.Rendering.Universal;

internal struct ShadowEdge(int indexA, int indexB)
{
	public int v0 = indexA;

	public int v1 = indexB;

	public void Reverse()
	{
		int num = v0;
		v0 = v1;
		v1 = num;
	}
}
