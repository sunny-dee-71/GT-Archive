namespace VYaml.Parser;

internal struct VersionDirective(int major, int minor) : ITokenContent
{
	public readonly int Major = major;

	public readonly int Minor = minor;
}
