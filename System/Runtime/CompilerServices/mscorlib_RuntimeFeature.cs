namespace System.Runtime.CompilerServices;

/// <summary>A class whose static <see cref="M:System.Runtime.CompilerServices.RuntimeFeature.IsSupported(System.String)" /> method checks whether a specified feature is supported by the common language runtime.</summary>
public static class RuntimeFeature
{
	/// <summary>Gets the name of the portable PDB feature.</summary>
	public const string PortablePdb = "PortablePdb";

	public const string DefaultImplementationsOfInterfaces = "DefaultImplementationsOfInterfaces";

	public static bool IsDynamicCodeSupported => true;

	public static bool IsDynamicCodeCompiled => true;

	/// <summary>Determines whether a specified feature is supported by the common language runtime.</summary>
	/// <param name="feature">The name of the feature.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="feature" /> is supported; otherwise, <see langword="false" />.</returns>
	public static bool IsSupported(string feature)
	{
		switch (feature)
		{
		case "PortablePdb":
		case "DefaultImplementationsOfInterfaces":
			return true;
		case "IsDynamicCodeSupported":
			return IsDynamicCodeSupported;
		case "IsDynamicCodeCompiled":
			return IsDynamicCodeCompiled;
		default:
			return false;
		}
	}
}
