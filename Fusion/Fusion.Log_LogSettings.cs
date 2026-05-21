using System;

namespace Fusion;

[Serializable]
public struct LogSettings(LogLevel level, TraceChannels traceChannels)
{
	public LogLevel Level = level;

	public TraceChannels TraceChannels = traceChannels;
}
