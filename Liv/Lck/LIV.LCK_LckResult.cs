namespace Liv.Lck;

public class LckResult : ILckResult
{
	private readonly bool _success;

	private readonly string _message;

	private readonly LckError? _error;

	public bool Success => _success;

	public string Message => _message;

	public LckError? Error => _error;

	private LckResult(bool success, string message, LckError? error)
	{
		_success = success;
		_message = message;
		_error = error;
	}

	internal static LckResult NewSuccess()
	{
		return new LckResult(success: true, null, null);
	}

	internal static LckResult NewError(LckError error, string message)
	{
		return new LckResult(success: false, message, error);
	}
}
