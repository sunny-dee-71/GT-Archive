using System;
using UnityEngine;
using UnityEngine.Events;

public class OVRMicrogestureEventSource : MonoBehaviour
{
	[SerializeField]
	private OVRHand _hand;

	public UnityEvent<OVRHand.MicrogestureType> GestureRecognizedEvent;

	public Action<OVRHand.MicrogestureType> WhenGestureRecognized = delegate
	{
	};

	public OVRHand Hand
	{
		get
		{
			return _hand;
		}
		set
		{
			_hand = value;
		}
	}

	private void Update()
	{
		OVRHand.MicrogestureType microgestureType = _hand.GetMicrogestureType();
		if (microgestureType != OVRHand.MicrogestureType.Invalid && microgestureType != OVRHand.MicrogestureType.NoGesture)
		{
			RaiseGestureRecognized(microgestureType);
		}
	}

	private void RaiseGestureRecognized(OVRHand.MicrogestureType gesture)
	{
		GestureRecognizedEvent?.Invoke(gesture);
		WhenGestureRecognized?.Invoke(gesture);
	}
}
