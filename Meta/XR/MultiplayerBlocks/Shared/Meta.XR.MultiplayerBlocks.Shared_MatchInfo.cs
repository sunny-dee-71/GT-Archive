using System;

namespace Meta.XR.MultiplayerBlocks.Shared;

[Serializable]
internal struct MatchInfo(string roomId, string roomPassword, string extra = "")
{
	internal string RoomId = roomId;

	internal string RoomPassword = roomPassword;

	internal string Extra = extra;
}
