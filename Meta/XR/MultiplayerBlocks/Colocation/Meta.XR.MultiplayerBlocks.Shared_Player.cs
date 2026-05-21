using System;

namespace Meta.XR.MultiplayerBlocks.Colocation;

[Serializable]
internal struct Player(ulong playerId, ulong oculusId, uint colocationGroupId) : IEquatable<Player>
{
	public ulong playerId = playerId;

	public ulong oculusId = oculusId;

	public uint colocationGroupId = colocationGroupId;

	public bool Equals(Player other)
	{
		if (playerId == other.playerId && oculusId == other.oculusId)
		{
			return colocationGroupId == other.colocationGroupId;
		}
		return false;
	}
}
