namespace Fusion;

internal struct TimeAdjustment(Tick tick, double total)
{
	public Tick Tick = tick;

	public double Total = total;

	public override string ToString()
	{
		return $"({Tick}, {Total})";
	}
}
