namespace Fusion;

internal struct TimelinePoint(Tick snapshot, Tick tick, double tickDeltaDouble)
{
	public Tick Snapshot = snapshot;

	public Tick Tick = tick;

	public double Time = (double)(int)tick * tickDeltaDouble;
}
