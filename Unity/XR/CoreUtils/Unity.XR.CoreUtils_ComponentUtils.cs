using UnityEngine;

namespace Unity.XR.CoreUtils;

public static class ComponentUtils
{
	public static T GetOrAddIf<T>(GameObject gameObject, bool add) where T : Component
	{
		T val = gameObject.GetComponent<T>();
		if (add && val == null)
		{
			val = gameObject.AddComponent<T>();
		}
		return val;
	}
}
