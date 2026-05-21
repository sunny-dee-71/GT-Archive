using System;
using Photon.Pun;
using Photon.Realtime;

[Serializable]
public class PhotonSignal<T1, T2, T3, T4, T5> : PhotonSignal
{
	private OnSignalReceived<T1, T2, T3, T4, T5> _callbacks;

	private static readonly int kSignature = typeof(PhotonSignal<T1, T2, T3, T4, T5>).FullName.GetStaticHash();

	public override int argCount => 5;

	public new event OnSignalReceived<T1, T2, T3, T4, T5> OnSignal
	{
		add
		{
			if (value != null)
			{
				_callbacks = (OnSignalReceived<T1, T2, T3, T4, T5>)Delegate.Remove(_callbacks, value);
				_callbacks = (OnSignalReceived<T1, T2, T3, T4, T5>)Delegate.Combine(_callbacks, value);
			}
		}
		remove
		{
			if (value != null)
			{
				_callbacks = (OnSignalReceived<T1, T2, T3, T4, T5>)Delegate.Remove(_callbacks, value);
			}
		}
	}

	public PhotonSignal(string signalID)
		: base(signalID)
	{
	}

	public PhotonSignal(int signalID)
		: base(signalID)
	{
	}

	public override void ClearListeners()
	{
		_callbacks = null;
		base.ClearListeners();
	}

	public void Raise(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
	{
		Raise(_receivers, arg1, arg2, arg3, arg4, arg5);
	}

	public void Raise(ReceiverGroup receivers, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
	{
		if (_enabled && !_mute)
		{
			RaiseEventOptions raiseEventOptions = PhotonSignal.gGroupToOptions[receivers];
			object[] array = PhotonUtils.FetchScratchArray(2 + argCount);
			int serverTimestamp = PhotonNetwork.ServerTimestamp;
			array[0] = _signalID;
			array[1] = serverTimestamp;
			array[2] = arg1;
			array[3] = arg2;
			array[4] = arg3;
			array[5] = arg4;
			array[6] = arg5;
			if (_localOnly || !PhotonNetwork.IsConnected || !PhotonNetwork.InRoom)
			{
				PhotonSignalInfo info = new PhotonSignalInfo(PhotonUtils.LocalNetPlayer, serverTimestamp);
				_Relay(array, info);
			}
			else
			{
				PhotonNetwork.RaiseEvent(177, array, raiseEventOptions, PhotonSignal.gSendReliable);
			}
		}
	}

	protected override void _Relay(object[] args, PhotonSignalInfo info)
	{
		if (args.TryParseArgs<T1, T2, T3, T4, T5>(2, out var arg, out var arg2, out var arg3, out var arg4, out var arg5))
		{
			if (!_safeInvoke)
			{
				PhotonSignal._Invoke(_callbacks, arg, arg2, arg3, arg4, arg5, info);
			}
			else
			{
				PhotonSignal._SafeInvoke(_callbacks, arg, arg2, arg3, arg4, arg5, info);
			}
		}
	}

	public static implicit operator PhotonSignal<T1, T2, T3, T4, T5>(string s)
	{
		return new PhotonSignal<T1, T2, T3, T4, T5>(s);
	}

	public static explicit operator PhotonSignal<T1, T2, T3, T4, T5>(int i)
	{
		return new PhotonSignal<T1, T2, T3, T4, T5>(i);
	}
}
