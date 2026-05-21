using System;

namespace UnityEngine.UIElements;

[EventCategory(EventCategory.Default)]
public abstract class EventBase<T> : EventBase where T : EventBase<T>, new()
{
	private static readonly long s_TypeId = EventBase.RegisterEventType();

	private static readonly ObjectPool<T> s_Pool = new ObjectPool<T>(() => new T());

	private int m_RefCount;

	internal static readonly EventCategory EventCategory = EventInterestReflectionUtils.GetEventCategory(typeof(T));

	public override long eventTypeId => s_TypeId;

	internal static void SetCreateFunction(Func<T> createMethod)
	{
		s_Pool.CreateFunc = createMethod;
	}

	protected EventBase()
		: base(EventCategory)
	{
		m_RefCount = 0;
	}

	public static long TypeId()
	{
		return s_TypeId;
	}

	protected override void Init()
	{
		base.Init();
		if (m_RefCount != 0)
		{
			Debug.Log("Event improperly released.");
			m_RefCount = 0;
		}
	}

	public static T GetPooled()
	{
		T val = s_Pool.Get();
		val.Init();
		val.pooled = true;
		val.Acquire();
		return val;
	}

	internal static T GetPooled(EventBase e)
	{
		T val = GetPooled();
		if (e != null)
		{
			val.SetTriggerEventId(e.eventId);
		}
		return val;
	}

	private static void ReleasePooled(T evt)
	{
		if (evt.pooled)
		{
			evt.Init();
			s_Pool.Release(evt);
			evt.pooled = false;
		}
	}

	internal override void Acquire()
	{
		m_RefCount++;
	}

	public sealed override void Dispose()
	{
		if (--m_RefCount == 0)
		{
			ReleasePooled((T)this);
		}
	}
}
