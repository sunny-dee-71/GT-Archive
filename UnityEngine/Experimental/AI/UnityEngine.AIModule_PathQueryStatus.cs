using System;

namespace UnityEngine.Experimental.AI;

[Obsolete("The experimental PathQueryStatus struct has been deprecated without replacement.")]
[Flags]
public enum PathQueryStatus
{
	Failure = int.MinValue,
	Success = 0x40000000,
	InProgress = 0x20000000,
	StatusDetailMask = 0xFFFFFF,
	WrongMagic = 1,
	WrongVersion = 2,
	OutOfMemory = 4,
	InvalidParam = 8,
	BufferTooSmall = 0x10,
	OutOfNodes = 0x20,
	PartialResult = 0x40
}
