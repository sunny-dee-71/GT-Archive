using System;

namespace Fusion;

public readonly struct NetworkPrefabAcquireContext(NetworkPrefabId prefabId, NetworkObjectMeta meta = null, bool isSynchronous = true, bool dontDestroyOnLoad = false)
{
	public readonly NetworkPrefabId PrefabId = prefabId;

	public readonly NetworkObjectMeta Meta = meta;

	public readonly bool IsSynchronous = isSynchronous;

	public readonly bool DontDestroyOnLoad = dontDestroyOnLoad;

	public bool HasHeader => Meta != null;

	public Span<int> Data => (Meta != null) ? Meta.Data : default(Span<int>);
}
