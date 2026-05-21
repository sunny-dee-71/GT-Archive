using System;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Internal;

namespace UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;

[Serializable]
public class XRInputValueReader<TValue> : XRInputValueReader, IXRInputValueReader<TValue>, IXRInputValueReader where TValue : struct
{
	private readonly struct BypassScope : IDisposable
	{
		private readonly XRInputValueReader<TValue> m_Reader;

		public BypassScope(XRInputValueReader<TValue> reader)
		{
			m_Reader = reader;
			m_Reader.m_CallingBypass = true;
		}

		public void Dispose()
		{
			m_Reader.m_CallingBypass = false;
		}
	}

	[SerializeField]
	[RequireInterface(typeof(IXRInputValueReader))]
	private Object m_ObjectReferenceObject;

	[SerializeField]
	private TValue m_ManualValue;

	private bool m_CallingBypass;

	private readonly UnityObjectReferenceCache<IXRInputValueReader<TValue>, Object> m_ObjectReference = new UnityObjectReferenceCache<IXRInputValueReader<TValue>, Object>();

	public TValue manualValue
	{
		get
		{
			return m_ManualValue;
		}
		set
		{
			m_ManualValue = value;
		}
	}

	public IXRInputValueReader<TValue> bypass { get; set; }

	public XRInputValueReader()
	{
	}

	public XRInputValueReader(string name = null, InputSourceMode inputSourceMode = InputSourceMode.InputActionReference)
		: base(InputActionUtility.CreateValueAction(typeof(TValue), name), inputSourceMode)
	{
	}

	public IXRInputValueReader<TValue> GetObjectReference()
	{
		return m_ObjectReference.Get(m_ObjectReferenceObject);
	}

	public void SetObjectReference(IXRInputValueReader<TValue> value)
	{
		m_ObjectReference.Set(ref m_ObjectReferenceObject, value);
	}

	public TValue ReadValue()
	{
		if (bypass != null && !m_CallingBypass)
		{
			using (new BypassScope(this))
			{
				return bypass.ReadValue();
			}
		}
		switch (m_InputSourceMode)
		{
		default:
			return default(TValue);
		case InputSourceMode.InputAction:
			return ReadValue(m_InputAction);
		case InputSourceMode.InputActionReference:
		{
			if (!TryGetInputActionReference(out var reference))
			{
				return default(TValue);
			}
			return ReadValue(reference.action);
		}
		case InputSourceMode.ObjectReference:
			return GetObjectReference()?.ReadValue() ?? default(TValue);
		case InputSourceMode.ManualValue:
			return m_ManualValue;
		}
	}

	public bool TryReadValue(out TValue value)
	{
		if (bypass != null && !m_CallingBypass)
		{
			using (new BypassScope(this))
			{
				return bypass.TryReadValue(out value);
			}
		}
		switch (base.inputSourceMode)
		{
		default:
			value = default(TValue);
			return false;
		case InputSourceMode.InputAction:
			return TryReadValue(m_InputAction, out value);
		case InputSourceMode.InputActionReference:
		{
			if (TryGetInputActionReference(out var reference))
			{
				return TryReadValue(reference.action, out value);
			}
			value = default(TValue);
			return false;
		}
		case InputSourceMode.ObjectReference:
		{
			IXRInputValueReader<TValue> objectReference = GetObjectReference();
			if (objectReference != null)
			{
				return objectReference.TryReadValue(out value);
			}
			value = default(TValue);
			return false;
		}
		case InputSourceMode.ManualValue:
			value = m_ManualValue;
			return true;
		}
	}

	private static TValue ReadValue(InputAction action)
	{
		return action?.ReadValue<TValue>() ?? default(TValue);
	}

	private static bool TryReadValue(InputAction action, out TValue value)
	{
		if (action == null)
		{
			value = default(TValue);
			return false;
		}
		value = action.ReadValue<TValue>();
		return action.IsInProgress();
	}
}
