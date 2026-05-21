using System;

namespace UnityEngine.SocialPlatforms;

[Obsolete("ActivePlatform is deprecated and will be removed in a future release.", false)]
internal static class ActivePlatform
{
	private static ISocialPlatform _active;

	internal static ISocialPlatform Instance
	{
		get
		{
			if (_active == null)
			{
				_active = SelectSocialPlatform();
			}
			return _active;
		}
		set
		{
			_active = value;
		}
	}

	private static ISocialPlatform SelectSocialPlatform()
	{
		return new Local();
	}
}
