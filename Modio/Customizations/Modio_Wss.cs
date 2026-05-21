using System;
using System.Threading.Tasks;
using Modio.Errors;

namespace Modio.Customizations;

internal static class Wss
{
	public static async Task<(Error, ExternalAuthenticationToken)> BeginAuthenticationProcess(bool restartProcess = false)
	{
		(Error, WssDeviceLoginResponse) tuple = await WssHandler.DoMessageHandshake<WssDeviceLoginResponse>(WssRequest.DeviceLogin());
		if ((bool)tuple.Item1)
		{
			return (tuple.Item1, default(ExternalAuthenticationToken));
		}
		Task<(Error, WssLoginSuccess)> task = WaitForAccessToken();
		ExternalAuthenticationToken item = new ExternalAuthenticationToken
		{
			code = tuple.Item2.code,
			url = tuple.Item2.login_url,
			autoUrl = tuple.Item2.login_url + "?code=" + tuple.Item2.code,
			expiryTime = DateTimeOffset.FromUnixTimeSeconds(tuple.Item2.date_expires).DateTime,
			task = task,
			cancel = delegate
			{
				WssHandler.CancelWaitingFor("login_success");
			}
		};
		return (Error.None, item);
	}

	private static async Task<(Error, WssLoginSuccess)> WaitForAccessToken()
	{
		(Error, WssMessage) tuple = await WssHandler.WaitForMessage("login_success");
		WssLoginSuccess output = new WssLoginSuccess
		{
			access_token = "",
			code = -1L,
			date_expires = -1L
		};
		var (error, _) = tuple;
		if (!error)
		{
			error = ((!tuple.Item2.TryGetValue<WssLoginSuccess>(out output)) ? new Error(ErrorCode.WSS_UNEXPECTED_MESSAGE) : Error.None);
		}
		WssHandler.Shutdown();
		return (error, output);
	}
}
