namespace UnityEngine.XR.Interaction.Toolkit.Utilities;

internal class UnityObjectReferenceCache<TInterface, TObject> where TInterface : class where TObject : Object
{
	private TObject m_CapturedObject;

	private TInterface m_Interface;

	public TInterface Get(TObject field)
	{
		if ((object)m_CapturedObject == field)
		{
			return m_Interface;
		}
		m_CapturedObject = field;
		m_Interface = field as TInterface;
		return m_Interface;
	}

	public void Set(ref TObject field, TInterface value)
	{
		field = value as TObject;
		m_CapturedObject = field;
		m_Interface = value;
	}
}
