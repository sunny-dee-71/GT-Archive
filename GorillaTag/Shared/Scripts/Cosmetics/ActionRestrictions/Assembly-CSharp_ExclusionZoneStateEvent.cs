using System;
using UnityEngine.Events;

namespace GorillaTag.Shared.Scripts.Cosmetics.ActionRestrictions;

[Serializable]
public class ExclusionZoneStateEvent<T0, T1> : ZoneStateEventBase
{
	[Serializable]
	public class TypedEvent : UnityEvent<T0, T1>
	{
	}

	public TypedEvent onNormal;

	public TypedEvent onRestricted;

	public void Invoke(VRRig vrRig, T0 arg0, T1 arg1)
	{
		if (IsRestricted(vrRig))
		{
			onRestricted?.Invoke(arg0, arg1);
		}
		else
		{
			onNormal?.Invoke(arg0, arg1);
		}
	}
}
