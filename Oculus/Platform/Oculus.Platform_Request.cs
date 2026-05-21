using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

namespace Oculus.Platform;

public class Request
{
	private TaskCompletionSource<Message> tcs_;

	private Message.Callback callback_;

	public ulong RequestID { get; set; }

	public Request(ulong requestID)
	{
		RequestID = requestID;
	}

	public Request OnComplete(Message.Callback callback)
	{
		callback_ = callback;
		Callback.AddRequest(this);
		return this;
	}

	public async Task<Message> Gen()
	{
		tcs_ = new TaskCompletionSource<Message>();
		Callback.AddRequest(this);
		return await tcs_.Task;
	}

	public TaskAwaiter<Message> GetAwaiter()
	{
		return Gen().GetAwaiter();
	}

	public virtual void HandleMessage(Message msg)
	{
		if (tcs_ != null)
		{
			tcs_.SetResult(msg);
			return;
		}
		if (callback_ != null)
		{
			callback_(msg);
			return;
		}
		throw new UnityException("Request with no handler.  This should never happen.");
	}

	public static void RunCallbacks(uint limit = 0u)
	{
		if (limit == 0)
		{
			Callback.RunCallbacks();
		}
		else
		{
			Callback.RunLimitedCallbacks(limit);
		}
	}
}
