using System;
using System.Runtime.InteropServices;
using Fusion;

namespace Meta.XR.MultiplayerBlocks.Colocation.Fusion;

[Serializable]
[StructLayout(LayoutKind.Explicit, Size = 20)]
[NetworkStructWeaved(5)]
internal struct FusionPlayer(Player player) : INetworkStruct, IEquatable<FusionPlayer>
{
	[FieldOffset(0)]
	public ulong playerId = player.playerId;

	[FieldOffset(8)]
	public ulong oculusId = player.oculusId;

	[FieldOffset(16)]
	public uint colocationGroupId = player.colocationGroupId;

	public Player GetPlayer()
	{
		return new Player(playerId, oculusId, colocationGroupId);
	}

	public bool Equals(FusionPlayer other)
	{
		return GetPlayer().Equals(other.GetPlayer());
	}
}
