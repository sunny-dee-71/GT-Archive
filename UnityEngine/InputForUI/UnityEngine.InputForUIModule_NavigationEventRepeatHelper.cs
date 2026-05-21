using Unity.IntegerTime;

namespace UnityEngine.InputForUI;

internal class NavigationEventRepeatHelper
{
	private int m_ConsecutiveMoveCount;

	private NavigationEvent.Direction m_LastDirection;

	private DiscreteTime m_PrevActionTime;

	private readonly DiscreteTime m_InitialRepeatDelay = new DiscreteTime(0.5f);

	private readonly DiscreteTime m_ConsecutiveRepeatDelay = new DiscreteTime(0.1f);

	public void Reset()
	{
		m_ConsecutiveMoveCount = 0;
		m_LastDirection = NavigationEvent.Direction.None;
		m_PrevActionTime = DiscreteTime.Zero;
	}

	public bool ShouldSendMoveEvent(DiscreteTime timestamp, NavigationEvent.Direction direction, bool axisButtonsWherePressedThisFrame)
	{
		if (axisButtonsWherePressedThisFrame || direction != m_LastDirection || timestamp > m_PrevActionTime + ((m_ConsecutiveMoveCount == 1) ? m_InitialRepeatDelay : m_ConsecutiveRepeatDelay))
		{
			m_ConsecutiveMoveCount = ((direction != m_LastDirection) ? 1 : (m_ConsecutiveMoveCount + 1));
			m_LastDirection = direction;
			m_PrevActionTime = timestamp;
			return true;
		}
		return false;
	}
}
