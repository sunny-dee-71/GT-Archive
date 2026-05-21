using System;

namespace WebSocketSharp.Server;

internal class WebSocketServiceHost<TBehavior> : WebSocketServiceHost where TBehavior : WebSocketBehavior, new()
{
	private Func<TBehavior> _creator;

	public override Type BehaviorType => typeof(TBehavior);

	internal WebSocketServiceHost(string path, Action<TBehavior> initializer, Logger log)
		: base(path, log)
	{
		_creator = createSessionCreator(initializer);
	}

	private static Func<TBehavior> createSessionCreator(Action<TBehavior> initializer)
	{
		if (initializer == null)
		{
			return () => new TBehavior();
		}
		return delegate
		{
			TBehavior val = new TBehavior();
			initializer(val);
			return val;
		};
	}

	protected override WebSocketBehavior CreateSession()
	{
		return _creator();
	}
}
