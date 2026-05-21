using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Content;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.SceneManagement;

namespace Unity.Loading;

[StaticAccessor("GetContentLoadFrontend()", StaticAccessorType.Dot)]
[NativeHeader("Modules/ContentLoad/Public/ContentLoadFrontend.h")]
public static class ContentLoadInterface
{
	internal static extern float IntegrationTimeMS
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[NativeThrows]
	internal unsafe static ContentFile LoadContentFileAsync(ContentNamespace nameSpace, string filename, void* dependencies, int dependencyCount, JobHandle dependentFence, bool useUnsafe = false)
	{
		//The blocks IL_002b are reachable both inside and outside the pinned region starting at IL_001a. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		ContentFile ret = default(ContentFile);
		ContentFile result;
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(filename, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(filename);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					LoadContentFileAsync_Injected(ref nameSpace, ref managedSpanWrapper, dependencies, dependencyCount, ref dependentFence, useUnsafe, out ret);
				}
			}
			else
			{
				LoadContentFileAsync_Injected(ref nameSpace, ref managedSpanWrapper, dependencies, dependencyCount, ref dependentFence, useUnsafe, out ret);
			}
		}
		finally
		{
			result = ret;
		}
		return result;
	}

	[NativeThrows]
	internal static void ContentFile_UnloadAsync(ContentFile handle)
	{
		ContentFile_UnloadAsync_Injected(ref handle);
	}

	internal static UnityEngine.Object ContentFile_GetObject(ContentFile handle, ulong localIdentifierInFile)
	{
		return Unmarshal.UnmarshalUnityObject<UnityEngine.Object>(ContentFile_GetObject_Injected(ref handle, localIdentifierInFile));
	}

	internal static UnityEngine.Object[] ContentFile_GetObjects(ContentFile handle)
	{
		return ContentFile_GetObjects_Injected(ref handle);
	}

	internal static LoadingStatus ContentFile_GetLoadingStatus(ContentFile handle)
	{
		return ContentFile_GetLoadingStatus_Injected(ref handle);
	}

	internal static bool ContentFile_IsHandleValid(ContentFile handle)
	{
		return ContentFile_IsHandleValid_Injected(ref handle);
	}

	internal static bool WaitForLoadCompletion(ContentFile handle, int timeoutMs)
	{
		return WaitForLoadCompletion_Injected(ref handle, timeoutMs);
	}

	internal static bool WaitForUnloadCompletion(ContentFile handle, int timeoutMs)
	{
		return WaitForUnloadCompletion_Injected(ref handle, timeoutMs);
	}

	internal static bool ContentFile_IsUnloadComplete(ContentFile handle)
	{
		return ContentFile_IsUnloadComplete_Injected(ref handle);
	}

	[NativeThrows]
	internal unsafe static ContentSceneFile LoadSceneAsync(ContentNamespace nameSpace, string filename, string sceneName, ContentSceneParameters sceneParams, ContentFile* dependencies, int dependencyCount, JobHandle dependentFence)
	{
		//The blocks IL_002b, IL_0038, IL_0046, IL_0054, IL_0059 are reachable both inside and outside the pinned region starting at IL_001a. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		ContentSceneFile ret = default(ContentSceneFile);
		ContentSceneFile result;
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper filename2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(filename, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(filename);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					filename2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(sceneName, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(sceneName);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							LoadSceneAsync_Injected(ref nameSpace, ref filename2, ref managedSpanWrapper2, ref sceneParams, dependencies, dependencyCount, ref dependentFence, out ret);
						}
					}
					else
					{
						LoadSceneAsync_Injected(ref nameSpace, ref filename2, ref managedSpanWrapper2, ref sceneParams, dependencies, dependencyCount, ref dependentFence, out ret);
					}
				}
			}
			else
			{
				filename2 = ref managedSpanWrapper;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(sceneName, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(sceneName);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						LoadSceneAsync_Injected(ref nameSpace, ref filename2, ref managedSpanWrapper2, ref sceneParams, dependencies, dependencyCount, ref dependentFence, out ret);
					}
				}
				else
				{
					LoadSceneAsync_Injected(ref nameSpace, ref filename2, ref managedSpanWrapper2, ref sceneParams, dependencies, dependencyCount, ref dependentFence, out ret);
				}
			}
		}
		finally
		{
			result = ret;
		}
		return result;
	}

	internal static Scene ContentSceneFile_GetScene(ContentSceneFile handle)
	{
		ContentSceneFile_GetScene_Injected(ref handle, out var ret);
		return ret;
	}

	internal static SceneLoadingStatus ContentSceneFile_GetStatus(ContentSceneFile handle)
	{
		return ContentSceneFile_GetStatus_Injected(ref handle);
	}

	[NativeThrows]
	internal static void ContentSceneFile_IntegrateAtEndOfFrame(ContentSceneFile handle)
	{
		ContentSceneFile_IntegrateAtEndOfFrame_Injected(ref handle);
	}

	internal static bool ContentSceneFile_UnloadAtEndOfFrame(ContentSceneFile handle)
	{
		return ContentSceneFile_UnloadAtEndOfFrame_Injected(ref handle);
	}

	internal static bool ContentSceneFile_IsHandleValid(ContentSceneFile handle)
	{
		return ContentSceneFile_IsHandleValid_Injected(ref handle);
	}

	internal static bool ContentSceneFile_WaitForCompletion(ContentSceneFile handle, int timeoutMs)
	{
		return ContentSceneFile_WaitForCompletion_Injected(ref handle, timeoutMs);
	}

	public unsafe static ContentSceneFile LoadSceneAsync(ContentNamespace nameSpace, string filename, string sceneName, ContentSceneParameters sceneParams, NativeArray<ContentFile> dependencies, JobHandle dependentFence = default(JobHandle))
	{
		return LoadSceneAsync(nameSpace, filename, sceneName, sceneParams, (ContentFile*)dependencies.m_Buffer, dependencies.Length, dependentFence);
	}

	public unsafe static ContentFile LoadContentFileAsync(ContentNamespace nameSpace, string filename, NativeArray<ContentFile> dependencies, JobHandle dependentFence = default(JobHandle))
	{
		return LoadContentFileAsync(nameSpace, filename, dependencies.m_Buffer, dependencies.Length, dependentFence);
	}

	public static ContentFile[] GetContentFiles(ContentNamespace nameSpace)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		ContentFile[] result;
		try
		{
			GetContentFiles_Injected(ref nameSpace, out ret);
		}
		finally
		{
			ContentFile[] array = default(ContentFile[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static ContentSceneFile[] GetSceneFiles(ContentNamespace nameSpace)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		ContentSceneFile[] result;
		try
		{
			GetSceneFiles_Injected(ref nameSpace, out ret);
		}
		finally
		{
			ContentSceneFile[] array = default(ContentSceneFile[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static float GetIntegrationTimeMS()
	{
		return IntegrationTimeMS;
	}

	public static void SetIntegrationTimeMS(float integrationTimeMS)
	{
		if (integrationTimeMS <= 0f)
		{
			throw new ArgumentOutOfRangeException("integrationTimeMS", "integrationTimeMS was out of range. Must be greater than zero.");
		}
		IntegrationTimeMS = integrationTimeMS;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern void LoadContentFileAsync_Injected([In] ref ContentNamespace nameSpace, ref ManagedSpanWrapper filename, void* dependencies, int dependencyCount, [In] ref JobHandle dependentFence, bool useUnsafe, out ContentFile ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ContentFile_UnloadAsync_Injected([In] ref ContentFile handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr ContentFile_GetObject_Injected([In] ref ContentFile handle, ulong localIdentifierInFile);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern UnityEngine.Object[] ContentFile_GetObjects_Injected([In] ref ContentFile handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern LoadingStatus ContentFile_GetLoadingStatus_Injected([In] ref ContentFile handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool ContentFile_IsHandleValid_Injected([In] ref ContentFile handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool WaitForLoadCompletion_Injected([In] ref ContentFile handle, int timeoutMs);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool WaitForUnloadCompletion_Injected([In] ref ContentFile handle, int timeoutMs);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool ContentFile_IsUnloadComplete_Injected([In] ref ContentFile handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern void LoadSceneAsync_Injected([In] ref ContentNamespace nameSpace, ref ManagedSpanWrapper filename, ref ManagedSpanWrapper sceneName, [In] ref ContentSceneParameters sceneParams, ContentFile* dependencies, int dependencyCount, [In] ref JobHandle dependentFence, out ContentSceneFile ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ContentSceneFile_GetScene_Injected([In] ref ContentSceneFile handle, out Scene ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern SceneLoadingStatus ContentSceneFile_GetStatus_Injected([In] ref ContentSceneFile handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ContentSceneFile_IntegrateAtEndOfFrame_Injected([In] ref ContentSceneFile handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool ContentSceneFile_UnloadAtEndOfFrame_Injected([In] ref ContentSceneFile handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool ContentSceneFile_IsHandleValid_Injected([In] ref ContentSceneFile handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool ContentSceneFile_WaitForCompletion_Injected([In] ref ContentSceneFile handle, int timeoutMs);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetContentFiles_Injected([In] ref ContentNamespace nameSpace, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetSceneFiles_Injected([In] ref ContentNamespace nameSpace, out BlittableArrayWrapper ret);
}
