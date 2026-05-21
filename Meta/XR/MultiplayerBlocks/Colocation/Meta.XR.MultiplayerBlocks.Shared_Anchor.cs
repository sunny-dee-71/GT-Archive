using System;

namespace Meta.XR.MultiplayerBlocks.Colocation;

[Serializable]
internal struct Anchor(bool isAutomaticAnchor, bool isAlignmentAnchor, ulong ownerOculusId, uint colocationGroupId, Guid automaticAnchorUuid) : IEquatable<Anchor>
{
	public bool isAutomaticAnchor = isAutomaticAnchor;

	public bool isAlignmentAnchor = isAlignmentAnchor;

	public ulong ownerOculusId = ownerOculusId;

	public uint colocationGroupId = colocationGroupId;

	public Guid automaticAnchorUuid = automaticAnchorUuid;

	public bool Equals(Anchor other)
	{
		if (isAutomaticAnchor == other.isAutomaticAnchor && isAlignmentAnchor == other.isAlignmentAnchor && ownerOculusId == other.ownerOculusId && colocationGroupId == other.colocationGroupId)
		{
			return automaticAnchorUuid == other.automaticAnchorUuid;
		}
		return false;
	}
}
