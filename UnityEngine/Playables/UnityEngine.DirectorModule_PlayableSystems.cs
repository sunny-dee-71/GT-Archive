using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Playables;

[StaticAccessor("PlayableSystemsBindings", StaticAccessorType.DoubleColon)]
[NativeHeader("Modules/Director/ScriptBindings/PlayableSystems.bindings.h")]
internal static class PlayableSystems
{
	public delegate void PlayableSystemDelegate(IReadOnlyList<DataPlayableOutput> outputs);

	public enum PlayableSystemStage : ushort
	{
		FixedUpdate,
		FixedUpdatePostPhysics,
		Update,
		AnimationBegin,
		AnimationEnd,
		LateUpdate,
		Render
	}

	private class DataPlayableOutputList : IReadOnlyList<DataPlayableOutput>, IEnumerable<DataPlayableOutput>, IEnumerable, IReadOnlyCollection<DataPlayableOutput>
	{
		private class DataPlayableOutputEnumerator : IEnumerator<DataPlayableOutput>, IEnumerator, IDisposable
		{
			private DataPlayableOutputList m_List;

			private int m_Index;

			public DataPlayableOutput Current
			{
				get
				{
					try
					{
						return m_List[m_Index];
					}
					catch (IndexOutOfRangeException)
					{
						throw new InvalidOperationException("Enumeration has either not started or has already finished.");
					}
				}
			}

			object IEnumerator.Current => Current;

			public DataPlayableOutputEnumerator(DataPlayableOutputList list)
			{
				m_List = list;
				m_Index = -1;
			}

			public void Dispose()
			{
				m_List = null;
			}

			public bool MoveNext()
			{
				m_Index++;
				return m_Index < m_List.Count;
			}

			public void Reset()
			{
				m_Index = -1;
			}
		}

		private unsafe PlayableOutputHandle* m_Outputs;

		private int m_Count;

		public unsafe DataPlayableOutput this[int index]
		{
			get
			{
				if (index >= m_Count)
				{
					throw new IndexOutOfRangeException($"index {index} is greater than the number of items: {m_Count}");
				}
				if (index < 0)
				{
					throw new IndexOutOfRangeException("index cannot be negative");
				}
				return new DataPlayableOutput(m_Outputs[index]);
			}
		}

		public int Count => m_Count;

		public unsafe DataPlayableOutputList(PlayableOutputHandle* outputs, int count)
		{
			m_Outputs = outputs;
			m_Count = count;
		}

		public IEnumerator<DataPlayableOutput> GetEnumerator()
		{
			return new DataPlayableOutputEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	private static Dictionary<int, Type> s_SystemTypes;

	private static Dictionary<int, PlayableSystemDelegate> s_Delegates;

	private static ReaderWriterLockSlim s_RWLock;

	public static void RegisterSystemPhaseDelegate<TDataStream>(PlayableSystemStage stage, PlayableSystemDelegate systemDelegate) where TDataStream : new()
	{
		RegisterSystemPhaseDelegate(typeof(TDataStream), stage, systemDelegate);
	}

	private static void RegisterSystemPhaseDelegate(Type streamType, PlayableSystemStage stage, PlayableSystemDelegate systemDelegate)
	{
		int num = RegisterStreamStage(streamType, (int)stage);
		try
		{
			s_RWLock.EnterWriteLock();
			s_SystemTypes.TryAdd(num, streamType);
			int key = CombineTypeAndIndex(num, stage);
			if (!s_Delegates.TryAdd(key, systemDelegate))
			{
				s_Delegates[key] = systemDelegate;
			}
		}
		finally
		{
			s_RWLock.ExitWriteLock();
		}
	}

	private static int CombineTypeAndIndex(int typeIndex, PlayableSystemStage stage)
	{
		return (typeIndex << 16) | (int)stage;
	}

	[RequiredByNativeCode]
	private unsafe static bool Internal_CallSystemDelegate(int systemIndex, PlayableSystemStage stage, IntPtr outputsPtr, int numOutputs)
	{
		PlayableOutputHandle* outputs = (PlayableOutputHandle*)(void*)outputsPtr;
		int key = CombineTypeAndIndex(systemIndex, stage);
		bool flag = false;
		bool flag2 = false;
		PlayableSystemDelegate value = null;
		s_RWLock.EnterReadLock();
		flag = s_SystemTypes.TryGetValue(systemIndex, out var _);
		if (flag)
		{
			flag2 = s_Delegates.TryGetValue(key, out value) && value != null;
		}
		s_RWLock.ExitReadLock();
		if (!flag || !flag2)
		{
			return false;
		}
		DataPlayableOutputList outputs2 = new DataPlayableOutputList(outputs, numOutputs);
		value(outputs2);
		return true;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[ThreadAndSerializationSafe]
	private static extern int RegisterStreamStage(Type streamType, int stage);

	static PlayableSystems()
	{
		s_Delegates = new Dictionary<int, PlayableSystemDelegate>();
		s_SystemTypes = new Dictionary<int, Type>();
		s_RWLock = new ReaderWriterLockSlim();
	}
}
