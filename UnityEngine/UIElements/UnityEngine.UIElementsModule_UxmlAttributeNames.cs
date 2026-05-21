using System;

namespace UnityEngine.UIElements;

public readonly struct UxmlAttributeNames(string fieldName, string uxmlName, Type typeReference = null, params string[] obsoleteNames)
{
	public readonly string fieldName = fieldName;

	public readonly string uxmlName = uxmlName;

	public readonly Type typeReference = typeReference;

	public readonly string[] obsoleteNames = obsoleteNames ?? Array.Empty<string>();
}
