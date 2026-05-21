using VYaml.Emitter;

namespace VYaml.Internal;

internal readonly struct EmitStringInfo(int lines, bool needsQuotes, bool isReservedWord)
{
	public readonly int Lines = lines;

	public readonly bool NeedsQuotes = needsQuotes;

	public readonly bool IsReservedWord = isReservedWord;

	public ScalarStyle SuggestScalarStyle()
	{
		if (Lines <= 1)
		{
			if (!NeedsQuotes)
			{
				return ScalarStyle.Plain;
			}
			return ScalarStyle.DoubleQuoted;
		}
		return ScalarStyle.Literal;
	}
}
