using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.UnityConsent;

[NativeHeader("Modules/UnityConsent/EndUserConsent.h")]
public static class EndUserConsent
{
	public static event Action<ConsentState> consentStateChanged;

	[NativeMethod("GetConsentStateStatic")]
	public static ConsentState GetConsentState()
	{
		GetConsentState_Injected(out var ret);
		return ret;
	}

	[NativeMethod("SetConsentStateStatic")]
	public static void SetConsentState(ConsentState consentState)
	{
		SetConsentState_Injected(ref consentState);
	}

	[RequiredByNativeCode]
	private static void OnConsentStateChanged()
	{
		if (EndUserConsent.consentStateChanged != null)
		{
			EndUserConsent.consentStateChanged(GetConsentState());
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetConsentState_Injected(out ConsentState ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetConsentState_Injected([In] ref ConsentState consentState);
}
