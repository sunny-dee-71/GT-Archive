using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Networking;

[NativeHeader("Modules/UnityWebRequestAudio/Public/DownloadHandlerAudioClip.h")]
internal static class WebRequestWWW
{
	[FreeFunction("UnityWebRequestCreateAudioClip")]
	internal unsafe static AudioClip InternalCreateAudioClipUsingDH(DownloadHandler dh, string url, bool stream, bool compressed, AudioType audioType)
	{
		//The blocks IL_0038 are reachable both inside and outside the pinned region starting at IL_0027. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		IntPtr gcHandlePtr = default(IntPtr);
		AudioClip result;
		try
		{
			IntPtr dh2 = ((dh == null) ? ((IntPtr)0) : DownloadHandler.BindingsMarshaller.ConvertToNative(dh));
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(url, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(url);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					gcHandlePtr = InternalCreateAudioClipUsingDH_Injected(dh2, ref managedSpanWrapper, stream, compressed, audioType);
				}
			}
			else
			{
				gcHandlePtr = InternalCreateAudioClipUsingDH_Injected(dh2, ref managedSpanWrapper, stream, compressed, audioType);
			}
		}
		finally
		{
			result = Unmarshal.UnmarshalUnityObject<AudioClip>(gcHandlePtr);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr InternalCreateAudioClipUsingDH_Injected(IntPtr dh, ref ManagedSpanWrapper url, bool stream, bool compressed, AudioType audioType);
}
