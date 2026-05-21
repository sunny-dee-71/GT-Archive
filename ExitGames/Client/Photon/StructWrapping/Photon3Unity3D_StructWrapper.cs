using System;

namespace ExitGames.Client.Photon.StructWrapping;

public class StructWrapper<T> : StructWrapper
{
	internal Pooling pooling;

	internal T value;

	internal static StructWrapperPool<T> staticPool = new StructWrapperPool<T>(isStaticPool: true);

	public StructWrapperPool<T> ReturnPool { get; internal set; }

	public StructWrapper(Pooling releasing)
		: base(typeof(T), StructWrapperPool.GetWrappedType(typeof(T)))
	{
		pooling = releasing;
	}

	public StructWrapper(Pooling releasing, Type tType, WrappedType wType)
		: base(tType, wType)
	{
		pooling = releasing;
	}

	public StructWrapper<T> Poke(byte value)
	{
		if (pooling == Pooling.Readonly)
		{
			throw new InvalidOperationException("Trying to Poke the value of a readonly StructWrapper<byte>. Value cannot be modified.");
		}
		return this;
	}

	public StructWrapper<T> Poke(bool value)
	{
		if (pooling == Pooling.Readonly)
		{
			throw new InvalidOperationException("Trying to Poke the value of a readonly StructWrapper<bool>. Value cannot be modified.");
		}
		return this;
	}

	public StructWrapper<T> Poke(T value)
	{
		this.value = value;
		return this;
	}

	public T Unwrap()
	{
		T result = value;
		if (pooling != Pooling.Readonly)
		{
			ReturnPool.Release(this);
		}
		return result;
	}

	public T Peek()
	{
		return value;
	}

	public override object Box()
	{
		T val = value;
		if (ReturnPool != null)
		{
			ReturnPool.Release(this);
		}
		return val;
	}

	public override void Dispose()
	{
		if ((pooling & Pooling.CheckedOut) == Pooling.CheckedOut && ReturnPool != null)
		{
			ReturnPool.Release(this);
		}
	}

	public override void DisconnectFromPool()
	{
		if (pooling != Pooling.Readonly)
		{
			pooling = Pooling.Disconnected;
			ReturnPool = null;
		}
	}

	public override string ToString()
	{
		return Unwrap().ToString();
	}

	public override string ToString(bool writeTypeInfo)
	{
		if (writeTypeInfo)
		{
			return $"(StructWrapper<{wrappedType}>){Unwrap().ToString()}";
		}
		return Unwrap().ToString();
	}

	public static implicit operator StructWrapper<T>(T value)
	{
		return staticPool.Acquire(value);
	}
}
