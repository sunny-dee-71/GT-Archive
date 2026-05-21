#define DEBUG
using System;
using System.Runtime.CompilerServices;

namespace Fusion;

internal class NetworkObjectHeaderSnapshot(Allocator allocator)
{
	internal NetworkObjectHeaderSnapshot Prev;

	internal NetworkObjectHeaderSnapshot Next;

	public Tick Tick;

	public int WordCount;

	private unsafe int* _ptr;

	public unsafe NetworkObjectHeaderPtr HeaderPtr
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return new NetworkObjectHeaderPtr((NetworkObjectHeader*)_ptr);
		}
	}

	public unsafe ref NetworkObjectHeader Header
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return ref *(NetworkObjectHeader*)_ptr;
		}
	}

	public unsafe Span<int> Raw
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return new Span<int>(_ptr, WordCount);
		}
	}

	public void Init(NetworkObjectMeta meta, bool copyData)
	{
		Init(meta.WordCount);
		if (copyData)
		{
			CopyFrom(meta);
		}
	}

	public unsafe void Init(int wordCount)
	{
		Assert.Check(allocator);
		Assert.Check(_ptr == null);
		WordCount = wordCount;
		_ptr = (int*)Allocator.AllocAndClear(allocator, wordCount * 4);
	}

	public unsafe void Release()
	{
		Tick = default(Tick);
		WordCount = 0;
		Allocator.Free(allocator, ref _ptr);
	}

	public NetworkObjectHeaderSnapshot Clone(Simulation simulation)
	{
		NetworkObjectHeaderSnapshot snapshot = simulation.GetSnapshot();
		snapshot.Init(WordCount);
		snapshot.CopyFrom(this);
		return snapshot;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CopyTo(int[] target)
	{
		Native.MemCpy(target, Raw);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CopyFrom(NetworkObjectMeta meta)
	{
		Native.MemCpy(Raw, meta.Raw);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CopyTo(NetworkObjectMeta meta)
	{
		Native.MemCpy(meta.Raw, Raw);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CopyFrom(NetworkObjectHeaderSnapshot target)
	{
		Native.MemCpy(Raw, target.Raw);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CopyTo(NetworkObjectHeaderSnapshot target)
	{
		Native.MemCpy(target.Raw, Raw);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CopyFrom(NetworkObjectHeaderSnapshotRef target)
	{
		Native.MemCpy(Raw, target.Raw);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CopyTo(NetworkObjectHeaderSnapshotRef target)
	{
		Native.MemCpy(target.Raw, Raw);
	}

	internal unsafe int* GetBehaviourPtr(NetworkBehaviour behaviour)
	{
		return _ptr + behaviour.WordOffset;
	}

	internal ulong BuildCRC()
	{
		return CRC64.Compute(Raw);
	}
}
