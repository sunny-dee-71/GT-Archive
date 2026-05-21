using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Playables;

[NativeHeader("Runtime/Director/Core/HPlayableGraph.h")]
[RequiredByNativeCode]
[StaticAccessor("DataPlayableOutputBindings", StaticAccessorType.DoubleColon)]
[NativeHeader("Runtime/Director/Core/HPlayableOutput.h")]
[NativeHeader("Modules/Director/ScriptBindings/DataPlayableOutput.bindings.h")]
[NativeHeader("Modules/Director/ScriptBindings/DataPlayableOutputExtensions.bindings.h")]
[NativeHeader("Modules/Director/DataPlayableOutput.h")]
internal struct DataPlayableOutput : IPlayableOutput
{
	private PlayableOutputHandle m_Handle;

	public static DataPlayableOutput Null => new DataPlayableOutput(PlayableOutputHandle.Null);

	public Type GetStreamType()
	{
		return InternalGetType(ref m_Handle);
	}

	public bool GetConnectionChanged()
	{
		return InternalGetConnectionChanged(ref m_Handle);
	}

	public void ClearConnectionChanged()
	{
		InternalClearConnectionChanged(ref m_Handle);
	}

	public TDataStream GetDataStream<TDataStream>() where TDataStream : new()
	{
		if (!(InternalGetStream(ref m_Handle) is TDataStream result))
		{
			return default(TDataStream);
		}
		return result;
	}

	public void SetDataStream<TDataStream>(TDataStream stream) where TDataStream : new()
	{
		Type streamType = GetStreamType();
		if (!streamType.IsAssignableFrom(typeof(TDataStream)))
		{
			throw new ArgumentException(string.Format("{0} is of the wrong type. This output only accepts streams with type {1} or inheriting from type {2}", "stream", streamType, streamType), "stream");
		}
		InternalSetStream(ref m_Handle, stream);
	}

	public static DataPlayableOutput Create<TDataStream>(PlayableGraph graph, string name) where TDataStream : new()
	{
		if (!DataPlayableOutputExtensions.InternalCreateDataOutput(ref graph, name, typeof(TDataStream), out var handle))
		{
			return Null;
		}
		return new DataPlayableOutput(handle);
	}

	internal DataPlayableOutput(PlayableOutputHandle handle)
	{
		if (handle.IsValid() && !handle.IsPlayableOutputOfType<DataPlayableOutput>())
		{
			throw new InvalidCastException("Can't set handle: the playable is not a DataPlayableOutput.");
		}
		m_Handle = handle;
	}

	public PlayableOutputHandle GetHandle()
	{
		return m_Handle;
	}

	public static implicit operator PlayableOutput(DataPlayableOutput output)
	{
		return new PlayableOutput(output.GetHandle());
	}

	public static explicit operator DataPlayableOutput(PlayableOutput output)
	{
		return new DataPlayableOutput(output.GetHandle());
	}

	public IDataPlayer GetPlayer()
	{
		return InternalGetPlayer(ref m_Handle) as IDataPlayer;
	}

	public void SetPlayer<TPlayer>(TPlayer player) where TPlayer : Object, IDataPlayer
	{
		InternalSetPlayer(ref m_Handle, player);
	}

	[NativeThrows]
	private static Object InternalGetPlayer(ref PlayableOutputHandle handle)
	{
		return Unmarshal.UnmarshalUnityObject<Object>(InternalGetPlayer_Injected(ref handle));
	}

	[NativeThrows]
	private static void InternalSetPlayer(ref PlayableOutputHandle handle, Object player)
	{
		InternalSetPlayer_Injected(ref handle, Object.MarshalledUnityObject.Marshal(player));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	private static extern Type InternalGetType(ref PlayableOutputHandle handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	private static extern void InternalSetStream(ref PlayableOutputHandle handle, object stream);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	private static extern object InternalGetStream(ref PlayableOutputHandle handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	private static extern bool InternalGetConnectionChanged(ref PlayableOutputHandle handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	private static extern void InternalClearConnectionChanged(ref PlayableOutputHandle handle);

	[RequiredByNativeCode]
	private static void Internal_CallOnPlayerChanged(PlayableOutputHandle handle, object previousPlayer, object currentPlayer)
	{
		DataPlayableOutput output = new DataPlayableOutput(handle);
		if (previousPlayer is IDataPlayer dataPlayer)
		{
			dataPlayer.Release(output);
		}
		if (currentPlayer is IDataPlayer dataPlayer2)
		{
			dataPlayer2.Bind(output);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr InternalGetPlayer_Injected(ref PlayableOutputHandle handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void InternalSetPlayer_Injected(ref PlayableOutputHandle handle, IntPtr player);
}
