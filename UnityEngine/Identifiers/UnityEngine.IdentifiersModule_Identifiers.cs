using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Identifiers;

[NativeHeader("Modules/Identifiers/Identifiers.h")]
public static class Identifiers
{
	public static string installationId => GetInstallationId();

	[FreeFunction("UnityEngine_Identifiers_GetInstallationId")]
	private static string GetInstallationId()
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			GetInstallationId_Injected(out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetInstallationId_Injected(out ManagedSpanWrapper ret);
}
