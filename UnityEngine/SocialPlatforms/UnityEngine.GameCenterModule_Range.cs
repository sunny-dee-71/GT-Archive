using System;

namespace UnityEngine.SocialPlatforms;

[Obsolete("Range is deprecated and will be removed in a future release.", false)]
public struct Range(int fromValue, int valueCount)
{
	public int from = fromValue;

	public int count = valueCount;
}
