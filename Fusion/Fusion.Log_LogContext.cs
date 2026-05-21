using System;

namespace Fusion;

[Obsolete]
public readonly struct LogContext(string prefix, object source)
{
	public readonly string Prefix = prefix;

	public readonly object Source = source;
}
