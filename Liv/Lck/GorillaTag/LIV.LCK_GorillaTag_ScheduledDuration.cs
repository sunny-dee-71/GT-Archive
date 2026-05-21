using System;
using UnityEngine;

namespace Liv.Lck.GorillaTag;

[Serializable]
public struct ScheduledDuration(long startTimeTicks, long endTimeTicks)
{
	[SerializeField]
	private long _startTimeTicks = startTimeTicks;

	[SerializeField]
	private long _endTimeTicks = endTimeTicks;

	public bool IsActive()
	{
		long ticks = DateTime.Now.Ticks;
		if (ticks >= _startTimeTicks)
		{
			return ticks <= _endTimeTicks;
		}
		return false;
	}
}
