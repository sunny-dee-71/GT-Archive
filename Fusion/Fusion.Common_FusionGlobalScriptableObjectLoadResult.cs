namespace Fusion;

public readonly struct FusionGlobalScriptableObjectLoadResult(FusionGlobalScriptableObject obj, FusionGlobalScriptableObjectUnloadDelegate unloader = null)
{
	public readonly FusionGlobalScriptableObject Object = obj;

	public readonly FusionGlobalScriptableObjectUnloadDelegate Unloader = unloader;

	public static implicit operator FusionGlobalScriptableObjectLoadResult(FusionGlobalScriptableObject result)
	{
		return new FusionGlobalScriptableObjectLoadResult(result);
	}
}
