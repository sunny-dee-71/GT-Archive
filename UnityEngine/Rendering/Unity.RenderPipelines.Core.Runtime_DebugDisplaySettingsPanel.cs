namespace UnityEngine.Rendering;

public abstract class DebugDisplaySettingsPanel<T> : DebugDisplaySettingsPanel where T : IDebugDisplaySettingsData
{
	internal T m_Data;

	public T data
	{
		get
		{
			return m_Data;
		}
		internal set
		{
			m_Data = value;
		}
	}

	protected DebugDisplaySettingsPanel(T data)
	{
		m_Data = data;
	}
}
