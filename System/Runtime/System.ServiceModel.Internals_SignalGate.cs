namespace System.Runtime;

internal class SignalGate<T> : SignalGate
{
	private T result;

	public bool Signal(T result)
	{
		this.result = result;
		return Signal();
	}

	public bool Unlock(out T result)
	{
		if (Unlock())
		{
			result = this.result;
			return true;
		}
		result = default(T);
		return false;
	}
}
