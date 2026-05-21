using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine;

[ExcludeFromPreset]
[NativeClass("LocalizationAsset")]
[NativeHeader("Modules/Localization/Public/LocalizationAsset.bindings.h")]
[NativeHeader("Modules/Localization/Public/LocalizationAsset.h")]
[MovedFrom("UnityEditor")]
public sealed class LocalizationAsset : Object
{
	public unsafe string localeIsoCode
	{
		get
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_localeIsoCode_Injected(intPtr, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}
		set
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(value);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						set_localeIsoCode_Injected(intPtr, ref managedSpanWrapper);
						return;
					}
				}
				set_localeIsoCode_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}
	}

	public bool isEditorAsset
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_isEditorAsset_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_isEditorAsset_Injected(intPtr, value);
		}
	}

	public LocalizationAsset()
	{
		Internal_CreateInstance(this);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("Internal_CreateInstance")]
	private static extern void Internal_CreateInstance([Writable] LocalizationAsset locAsset);

	[NativeMethod("StoreLocalizedString")]
	public unsafe void SetLocalizedString(string original, string localized)
	{
		//The blocks IL_0039, IL_0046, IL_0054, IL_0062, IL_0067 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0067 are reachable both inside and outside the pinned region starting at IL_0054. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0067 are reachable both inside and outside the pinned region starting at IL_0054. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper original2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(original, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(original);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					original2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(localized, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(localized);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							SetLocalizedString_Injected(intPtr, ref original2, ref managedSpanWrapper2);
							return;
						}
					}
					SetLocalizedString_Injected(intPtr, ref original2, ref managedSpanWrapper2);
					return;
				}
			}
			original2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(localized, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(localized);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					SetLocalizedString_Injected(intPtr, ref original2, ref managedSpanWrapper2);
					return;
				}
			}
			SetLocalizedString_Injected(intPtr, ref original2, ref managedSpanWrapper2);
		}
		finally
		{
		}
	}

	[NativeMethod("GetLocalized")]
	public unsafe string GetLocalizedString(string original)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(original, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(original);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					GetLocalizedString_Injected(intPtr, ref managedSpanWrapper, out ret);
				}
			}
			else
			{
				GetLocalizedString_Injected(intPtr, ref managedSpanWrapper, out ret);
			}
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetLocalizedString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper original, ref ManagedSpanWrapper localized);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetLocalizedString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper original, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_localeIsoCode_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_localeIsoCode_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_isEditorAsset_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_isEditorAsset_Injected(IntPtr _unity_self, bool value);
}
