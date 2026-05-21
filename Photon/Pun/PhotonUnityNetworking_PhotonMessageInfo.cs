using System;
using Photon.Realtime;

namespace Photon.Pun;

public struct PhotonMessageInfo(Player player, int timestamp, PhotonView view)
{
	private readonly int timeInt = timestamp;

	public readonly Player Sender = player;

	public readonly PhotonView photonView = view;

	[Obsolete("Use SentServerTime instead.")]
	public double timestamp => (double)(uint)timeInt / 1000.0;

	public double SentServerTime => (double)(uint)timeInt / 1000.0;

	public int SentServerTimestamp => timeInt;

	public override string ToString()
	{
		return string.Format("[PhotonMessageInfo: Sender='{1}' Senttime={0}]", SentServerTime, Sender);
	}
}
