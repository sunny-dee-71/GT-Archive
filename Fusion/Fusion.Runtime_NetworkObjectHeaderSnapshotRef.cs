using System;
using System.Runtime.CompilerServices;

namespace Fusion;

internal readonly ref struct NetworkObjectHeaderSnapshotRef(NetworkObjectHeaderSnapshot snapshot)
{
	public Tick Tick
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return snapshot.Tick;
		}
	}

	public ref NetworkObjectHeader Header
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return ref snapshot.Header;
		}
	}

	public ulong SnapshotCRC
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return snapshot.BuildCRC();
		}
	}

	internal Span<int> Raw
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return snapshot.Raw;
		}
	}

	public static implicit operator NetworkObjectHeaderSnapshotRef(NetworkObjectHeaderSnapshot snapshot)
	{
		return new NetworkObjectHeaderSnapshotRef(snapshot);
	}

	public void CopyFrom(NetworkObjectMeta target)
	{
		snapshot.CopyFrom(target);
	}

	public void CopyFrom(NetworkObjectHeaderSnapshotRef target)
	{
		snapshot.CopyFrom(target);
	}

	public void CopyTo(NetworkObjectMeta target)
	{
		snapshot.CopyTo(target);
	}

	public void CopyTo(int[] target)
	{
		snapshot.CopyTo(target);
	}

	public void CopyTo(NetworkObjectHeaderSnapshotRef target)
	{
		snapshot.CopyTo(target);
	}

	internal unsafe int* GetBehaviourPtr(NetworkBehaviour behaviour)
	{
		return snapshot.GetBehaviourPtr(behaviour);
	}
}
