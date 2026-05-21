using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.InputSystem.Utilities;

namespace UnityEngine.InputSystem.LowLevel;

public class InputStateHistory<TValue> : InputStateHistory, IReadOnlyList<InputStateHistory<TValue>.Record>, IEnumerable<InputStateHistory<TValue>.Record>, IEnumerable, IReadOnlyCollection<InputStateHistory<TValue>.Record> where TValue : struct
{
	private struct Enumerator(InputStateHistory<TValue> history) : IEnumerator<Record>, IEnumerator, IDisposable
	{
		private readonly InputStateHistory<TValue> m_History = history;

		private int m_Index = -1;

		public Record Current => m_History[m_Index];

		object IEnumerator.Current => Current;

		public bool MoveNext()
		{
			if (m_Index + 1 >= m_History.Count)
			{
				return false;
			}
			m_Index++;
			return true;
		}

		public void Reset()
		{
			m_Index = -1;
		}

		public void Dispose()
		{
		}
	}

	public new struct Record : IEquatable<Record>
	{
		private readonly InputStateHistory<TValue> m_Owner;

		private readonly int m_IndexPlusOne;

		private uint m_Version;

		internal unsafe RecordHeader* header => m_Owner.GetRecord(recordIndex);

		internal int recordIndex => m_IndexPlusOne - 1;

		public unsafe bool valid
		{
			get
			{
				if (m_Owner != null && m_IndexPlusOne != 0)
				{
					return header->version == m_Version;
				}
				return false;
			}
		}

		public InputStateHistory<TValue> owner => m_Owner;

		public int index
		{
			get
			{
				CheckValid();
				return m_Owner.RecordIndexToUserIndex(recordIndex);
			}
		}

		public unsafe double time
		{
			get
			{
				CheckValid();
				return header->time;
			}
		}

		public unsafe InputControl<TValue> control
		{
			get
			{
				CheckValid();
				ReadOnlyArray<InputControl> controls = m_Owner.controls;
				if (controls.Count == 1 && !m_Owner.m_AddNewControls)
				{
					return (InputControl<TValue>)controls[0];
				}
				return (InputControl<TValue>)controls[header->controlIndex];
			}
		}

		public unsafe Record next
		{
			get
			{
				CheckValid();
				int num = m_Owner.RecordIndexToUserIndex(recordIndex);
				if (num + 1 >= m_Owner.Count)
				{
					return default(Record);
				}
				int num2 = m_Owner.UserIndexToRecordIndex(num + 1);
				return new Record(m_Owner, num2, m_Owner.GetRecord(num2));
			}
		}

		public unsafe Record previous
		{
			get
			{
				CheckValid();
				int num = m_Owner.RecordIndexToUserIndex(recordIndex);
				if (num - 1 < 0)
				{
					return default(Record);
				}
				int num2 = m_Owner.UserIndexToRecordIndex(num - 1);
				return new Record(m_Owner, num2, m_Owner.GetRecord(num2));
			}
		}

		internal unsafe Record(InputStateHistory<TValue> owner, int index, RecordHeader* header)
		{
			m_Owner = owner;
			m_IndexPlusOne = index + 1;
			m_Version = header->version;
		}

		internal Record(InputStateHistory<TValue> owner, int index)
		{
			m_Owner = owner;
			m_IndexPlusOne = index + 1;
			m_Version = 0u;
		}

		public unsafe TValue ReadValue()
		{
			CheckValid();
			return m_Owner.ReadValue<TValue>(header);
		}

		public unsafe void* GetUnsafeMemoryPtr()
		{
			CheckValid();
			return GetUnsafeMemoryPtrUnchecked();
		}

		internal unsafe void* GetUnsafeMemoryPtrUnchecked()
		{
			if (m_Owner.controls.Count == 1 && !m_Owner.m_AddNewControls)
			{
				return header->statePtrWithoutControlIndex;
			}
			return header->statePtrWithControlIndex;
		}

		public unsafe void* GetUnsafeExtraMemoryPtr()
		{
			CheckValid();
			return GetUnsafeExtraMemoryPtrUnchecked();
		}

		internal unsafe void* GetUnsafeExtraMemoryPtrUnchecked()
		{
			if (m_Owner.extraMemoryPerRecord == 0)
			{
				throw new InvalidOperationException("No extra memory has been set up for history records; set extraMemoryPerRecord");
			}
			return (byte*)header + m_Owner.bytesPerRecord - m_Owner.extraMemoryPerRecord;
		}

		public unsafe void CopyFrom(Record record)
		{
			CheckValid();
			if (!record.valid)
			{
				throw new ArgumentException("Given history record is not valid", "record");
			}
			InputStateHistory.Record record2 = new InputStateHistory.Record(m_Owner, recordIndex, header);
			record2.CopyFrom(new InputStateHistory.Record(record.m_Owner, record.recordIndex, record.header));
			m_Version = record2.version;
		}

		private unsafe void CheckValid()
		{
			if (m_Owner == null || m_IndexPlusOne == 0)
			{
				throw new InvalidOperationException("Value not initialized");
			}
			if (header->version != m_Version)
			{
				throw new InvalidOperationException("Record is no longer valid");
			}
		}

		public bool Equals(Record other)
		{
			if (m_Owner == other.m_Owner && m_IndexPlusOne == other.m_IndexPlusOne)
			{
				return m_Version == other.m_Version;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is Record other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (((((m_Owner != null) ? m_Owner.GetHashCode() : 0) * 397) ^ m_IndexPlusOne) * 397) ^ (int)m_Version;
		}

		public override string ToString()
		{
			if (!valid)
			{
				return "<Invalid>";
			}
			return $"{{ control={control} value={ReadValue()} time={time} }}";
		}
	}

	public new unsafe Record this[int index]
	{
		get
		{
			if (index < 0 || index >= base.Count)
			{
				throw new ArgumentOutOfRangeException($"Index {index} is out of range for history with {base.Count} entries", "index");
			}
			int index2 = UserIndexToRecordIndex(index);
			return new Record(this, index2, GetRecord(index2));
		}
		set
		{
			if (index < 0 || index >= base.Count)
			{
				throw new ArgumentOutOfRangeException($"Index {index} is out of range for history with {base.Count} entries", "index");
			}
			int index2 = UserIndexToRecordIndex(index);
			new Record(this, index2, GetRecord(index2)).CopyFrom(value);
		}
	}

	public InputStateHistory(int? maxStateSizeInBytes = null)
		: base(maxStateSizeInBytes ?? UnsafeUtility.SizeOf<TValue>())
	{
		if (maxStateSizeInBytes < UnsafeUtility.SizeOf<TValue>())
		{
			throw new ArgumentException("Max state size cannot be smaller than sizeof(TValue)", "maxStateSizeInBytes");
		}
	}

	public InputStateHistory(InputControl<TValue> control)
		: base(control)
	{
	}

	public InputStateHistory(string path)
		: base(path)
	{
		foreach (InputControl control in base.controls)
		{
			if (!typeof(TValue).IsAssignableFrom(control.valueType))
			{
				throw new ArgumentException($"Control '{control}' matched by '{path}' has value type '{control.valueType.GetNiceTypeName()}' which is incompatible with '{typeof(TValue).GetNiceTypeName()}'");
			}
		}
	}

	~InputStateHistory()
	{
		Destroy();
	}

	public unsafe Record AddRecord(Record record)
	{
		int index;
		RecordHeader* header = AllocateRecord(out index);
		Record result = new Record(this, index, header);
		result.CopyFrom(record);
		return result;
	}

	public unsafe Record RecordStateChange(InputControl<TValue> control, TValue value, double time = -1.0)
	{
		InputEventPtr eventPtr;
		using (StateEvent.From(control.device, out eventPtr))
		{
			byte* statePtr = (byte*)StateEvent.From(eventPtr)->state - control.device.stateBlock.byteOffset;
			control.WriteValueIntoState(value, statePtr);
			if (time >= 0.0)
			{
				eventPtr.time = time;
			}
			InputStateHistory.Record record = RecordStateChange(control, eventPtr);
			return new Record(this, record.recordIndex, record.header);
		}
	}

	public new IEnumerator<Record> GetEnumerator()
	{
		return new Enumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
