using System;

namespace UnityEngine.AMD;

public class FSR2Context
{
	private NativeData<FSR2CommandInitializationData> m_InitData = new NativeData<FSR2CommandInitializationData>();

	private NativeData<FSR2CommandExecutionData> m_ExecData = new NativeData<FSR2CommandExecutionData>();

	public ref readonly FSR2CommandInitializationData initData => ref m_InitData.Value;

	public ref FSR2CommandExecutionData executeData => ref m_ExecData.Value;

	internal uint featureSlot => initData.featureSlot;

	internal FSR2Context()
	{
	}

	internal void Init(FSR2CommandInitializationData initSettings, uint featureSlot)
	{
		m_InitData.Value = initSettings;
		m_InitData.Value.featureSlot = featureSlot;
	}

	internal void Reset()
	{
		m_InitData.Value = default(FSR2CommandInitializationData);
		m_ExecData.Value = default(FSR2CommandExecutionData);
	}

	internal IntPtr GetInitCmdPtr()
	{
		return m_InitData.Ptr;
	}

	internal IntPtr GetExecuteCmdPtr()
	{
		m_ExecData.Value.featureSlot = featureSlot;
		return m_ExecData.Ptr;
	}
}
