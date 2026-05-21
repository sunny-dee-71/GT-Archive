using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngineInternal;

namespace UnityEngine;

[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadAssetUtility.h")]
[NativeHeader("Modules/AssetBundle/Public/AssetBundleUtility.h")]
[NativeHeader("Modules/AssetBundle/Public/AssetBundleSaveAndLoadHelper.h")]
[NativeHeader("AssetBundleScriptingClasses.h")]
[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadFromManagedStreamAsyncOperation.h")]
[NativeHeader("Runtime/Scripting/ScriptingExportUtility.h")]
[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadAssetOperation.h")]
[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadFromMemoryAsyncOperation.h")]
[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadFromFileAsyncOperation.h")]
[NativeHeader("Runtime/Scripting/ScriptingUtility.h")]
[ExcludeFromPreset]
public class AssetBundle : Object
{
	[Obsolete("mainAsset has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
	public Object mainAsset => returnMainAsset(this);

	public bool isStreamedSceneAssetBundle
	{
		[NativeMethod("GetIsStreamedSceneAssetBundle")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_isStreamedSceneAssetBundle_Injected(intPtr);
		}
	}

	public static uint memoryBudgetKB
	{
		get
		{
			return AssetBundleLoadingCache.memoryBudgetKB;
		}
		set
		{
			AssetBundleLoadingCache.memoryBudgetKB = value;
		}
	}

	private AssetBundle()
	{
	}

	[FreeFunction("LoadMainObjectFromAssetBundle", true)]
	internal static Object returnMainAsset([NotNull] AssetBundle bundle)
	{
		if ((object)bundle == null)
		{
			ThrowHelper.ThrowArgumentNullException(bundle, "bundle");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(bundle);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(bundle, "bundle");
		}
		return Unmarshal.UnmarshalUnityObject<Object>(returnMainAsset_Injected(intPtr));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("UnloadAllAssetBundles")]
	public static extern void UnloadAllAssetBundles(bool unloadAllObjects);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("GetAllAssetBundles")]
	internal static extern AssetBundle[] GetAllLoadedAssetBundles_Native();

	public static IEnumerable<AssetBundle> GetAllLoadedAssetBundles()
	{
		return GetAllLoadedAssetBundles_Native();
	}

	[FreeFunction("LoadFromFileAsync")]
	internal unsafe static AssetBundleCreateRequest LoadFromFileAsync_Internal(string path, uint crc, ulong offset)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		IntPtr intPtr = default(IntPtr);
		AssetBundleCreateRequest result;
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(path, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(path);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					intPtr = LoadFromFileAsync_Internal_Injected(ref managedSpanWrapper, crc, offset);
				}
			}
			else
			{
				intPtr = LoadFromFileAsync_Internal_Injected(ref managedSpanWrapper, crc, offset);
			}
		}
		finally
		{
			IntPtr intPtr2 = intPtr;
			result = ((intPtr2 == (IntPtr)0) ? null : AssetBundleCreateRequest.BindingsMarshaller.ConvertToManaged(intPtr2));
		}
		return result;
	}

	public static AssetBundleCreateRequest LoadFromFileAsync(string path)
	{
		return LoadFromFileAsync_Internal(path, 0u, 0uL);
	}

	public static AssetBundleCreateRequest LoadFromFileAsync(string path, uint crc)
	{
		return LoadFromFileAsync_Internal(path, crc, 0uL);
	}

	public static AssetBundleCreateRequest LoadFromFileAsync(string path, uint crc, ulong offset)
	{
		return LoadFromFileAsync_Internal(path, crc, offset);
	}

	[FreeFunction("LoadFromFile")]
	internal unsafe static AssetBundle LoadFromFile_Internal(string path, uint crc, ulong offset)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		IntPtr gcHandlePtr = default(IntPtr);
		AssetBundle result;
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(path, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(path);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					gcHandlePtr = LoadFromFile_Internal_Injected(ref managedSpanWrapper, crc, offset);
				}
			}
			else
			{
				gcHandlePtr = LoadFromFile_Internal_Injected(ref managedSpanWrapper, crc, offset);
			}
		}
		finally
		{
			result = Unmarshal.UnmarshalUnityObject<AssetBundle>(gcHandlePtr);
		}
		return result;
	}

	public static AssetBundle LoadFromFile(string path)
	{
		return LoadFromFile_Internal(path, 0u, 0uL);
	}

	public static AssetBundle LoadFromFile(string path, uint crc)
	{
		return LoadFromFile_Internal(path, crc, 0uL);
	}

	public static AssetBundle LoadFromFile(string path, uint crc, ulong offset)
	{
		return LoadFromFile_Internal(path, crc, offset);
	}

	[FreeFunction("LoadFromMemoryAsync")]
	internal unsafe static AssetBundleCreateRequest LoadFromMemoryAsync_Internal(byte[] binary, uint crc)
	{
		Span<byte> span = new Span<byte>(binary);
		AssetBundleCreateRequest result;
		fixed (byte* begin = span)
		{
			ManagedSpanWrapper binary2 = new ManagedSpanWrapper(begin, span.Length);
			IntPtr intPtr = LoadFromMemoryAsync_Internal_Injected(ref binary2, crc);
			result = ((intPtr == (IntPtr)0) ? null : AssetBundleCreateRequest.BindingsMarshaller.ConvertToManaged(intPtr));
		}
		return result;
	}

	public static AssetBundleCreateRequest LoadFromMemoryAsync(byte[] binary)
	{
		return LoadFromMemoryAsync_Internal(binary, 0u);
	}

	public static AssetBundleCreateRequest LoadFromMemoryAsync(byte[] binary, uint crc)
	{
		return LoadFromMemoryAsync_Internal(binary, crc);
	}

	[FreeFunction("LoadFromMemory")]
	internal unsafe static AssetBundle LoadFromMemory_Internal(byte[] binary, uint crc)
	{
		Span<byte> span = new Span<byte>(binary);
		AssetBundle result;
		fixed (byte* begin = span)
		{
			ManagedSpanWrapper binary2 = new ManagedSpanWrapper(begin, span.Length);
			result = Unmarshal.UnmarshalUnityObject<AssetBundle>(LoadFromMemory_Internal_Injected(ref binary2, crc));
		}
		return result;
	}

	public static AssetBundle LoadFromMemory(byte[] binary)
	{
		return LoadFromMemory_Internal(binary, 0u);
	}

	public static AssetBundle LoadFromMemory(byte[] binary, uint crc)
	{
		return LoadFromMemory_Internal(binary, crc);
	}

	internal static void ValidateLoadFromStream(Stream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("ManagedStream object must be non-null", "stream");
		}
		if (!stream.CanRead)
		{
			throw new ArgumentException("ManagedStream object must be readable (stream.CanRead must return true)", "stream");
		}
		if (!stream.CanSeek)
		{
			throw new ArgumentException("ManagedStream object must be seekable (stream.CanSeek must return true)", "stream");
		}
	}

	public static AssetBundleCreateRequest LoadFromStreamAsync(Stream stream, uint crc, uint managedReadBufferSize)
	{
		ValidateLoadFromStream(stream);
		return LoadFromStreamAsyncInternal(stream, crc, managedReadBufferSize);
	}

	public static AssetBundleCreateRequest LoadFromStreamAsync(Stream stream, uint crc)
	{
		ValidateLoadFromStream(stream);
		return LoadFromStreamAsyncInternal(stream, crc, 0u);
	}

	public static AssetBundleCreateRequest LoadFromStreamAsync(Stream stream)
	{
		ValidateLoadFromStream(stream);
		return LoadFromStreamAsyncInternal(stream, 0u, 0u);
	}

	public static AssetBundle LoadFromStream(Stream stream, uint crc, uint managedReadBufferSize)
	{
		ValidateLoadFromStream(stream);
		return LoadFromStreamInternal(stream, crc, managedReadBufferSize);
	}

	public static AssetBundle LoadFromStream(Stream stream, uint crc)
	{
		ValidateLoadFromStream(stream);
		return LoadFromStreamInternal(stream, crc, 0u);
	}

	public static AssetBundle LoadFromStream(Stream stream)
	{
		ValidateLoadFromStream(stream);
		return LoadFromStreamInternal(stream, 0u, 0u);
	}

	[FreeFunction("LoadFromStreamAsyncInternal")]
	internal static AssetBundleCreateRequest LoadFromStreamAsyncInternal(Stream stream, uint crc, uint managedReadBufferSize)
	{
		IntPtr intPtr = LoadFromStreamAsyncInternal_Injected(stream, crc, managedReadBufferSize);
		return (intPtr == (IntPtr)0) ? null : AssetBundleCreateRequest.BindingsMarshaller.ConvertToManaged(intPtr);
	}

	[FreeFunction("LoadFromStreamInternal")]
	internal static AssetBundle LoadFromStreamInternal(Stream stream, uint crc, uint managedReadBufferSize)
	{
		return Unmarshal.UnmarshalUnityObject<AssetBundle>(LoadFromStreamInternal_Injected(stream, crc, managedReadBufferSize));
	}

	[NativeMethod("Contains")]
	public unsafe bool Contains(string name)
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
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return Contains_Injected(intPtr, ref managedSpanWrapper);
				}
			}
			return Contains_Injected(intPtr, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Method Load has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAsset instead and check the documentation for details.", true)]
	public Object Load(string name)
	{
		return null;
	}

	[Obsolete("Method Load has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAsset instead and check the documentation for details.", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Object Load<T>(string name)
	{
		return null;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Method Load has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAsset instead and check the documentation for details.", true)]
	private Object Load(string name, Type type)
	{
		return null;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Method LoadAsync has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAssetAsync instead and check the documentation for details.", true)]
	private AssetBundleRequest LoadAsync(string name, Type type)
	{
		return null;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Method LoadAll has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAllAssets instead and check the documentation for details.", true)]
	private Object[] LoadAll(Type type)
	{
		return null;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Method LoadAll has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAllAssets instead and check the documentation for details.", true)]
	public Object[] LoadAll()
	{
		return null;
	}

	[Obsolete("Method LoadAll has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAllAssets instead and check the documentation for details.", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public T[] LoadAll<T>() where T : Object
	{
		return null;
	}

	public Object LoadAsset(string name)
	{
		return LoadAsset(name, typeof(Object));
	}

	public T LoadAsset<T>(string name) where T : Object
	{
		return (T)LoadAsset(name, typeof(T));
	}

	[TypeInferenceRule(TypeInferenceRules.TypeReferencedBySecondArgument)]
	public Object LoadAsset(string name, Type type)
	{
		if (name == null)
		{
			throw new NullReferenceException("The input asset name cannot be null.");
		}
		if (name.Length == 0)
		{
			throw new ArgumentException("The input asset name cannot be empty.");
		}
		if (type == null)
		{
			throw new NullReferenceException("The input type cannot be null.");
		}
		return LoadAsset_Internal(name, type);
	}

	[TypeInferenceRule(TypeInferenceRules.TypeReferencedBySecondArgument)]
	[NativeMethod("LoadAsset_Internal")]
	[NativeThrows]
	private unsafe Object LoadAsset_Internal(string name, Type type)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		IntPtr gcHandlePtr = default(IntPtr);
		Object result;
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					gcHandlePtr = LoadAsset_Internal_Injected(intPtr, ref managedSpanWrapper, type);
				}
			}
			else
			{
				gcHandlePtr = LoadAsset_Internal_Injected(intPtr, ref managedSpanWrapper, type);
			}
		}
		finally
		{
			result = Unmarshal.UnmarshalUnityObject<Object>(gcHandlePtr);
		}
		return result;
	}

	public AssetBundleRequest LoadAssetAsync(string name)
	{
		return LoadAssetAsync(name, typeof(Object));
	}

	public AssetBundleRequest LoadAssetAsync<T>(string name)
	{
		return LoadAssetAsync(name, typeof(T));
	}

	public AssetBundleRequest LoadAssetAsync(string name, Type type)
	{
		if (name == null)
		{
			throw new NullReferenceException("The input asset name cannot be null.");
		}
		if (name.Length == 0)
		{
			throw new ArgumentException("The input asset name cannot be empty.");
		}
		if (type == null)
		{
			throw new NullReferenceException("The input type cannot be null.");
		}
		return LoadAssetAsync_Internal(name, type);
	}

	public Object[] LoadAssetWithSubAssets(string name)
	{
		return LoadAssetWithSubAssets(name, typeof(Object));
	}

	internal static T[] ConvertObjects<T>(Object[] rawObjects) where T : Object
	{
		if (rawObjects == null)
		{
			return null;
		}
		T[] array = new T[rawObjects.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (T)rawObjects[i];
		}
		return array;
	}

	public T[] LoadAssetWithSubAssets<T>(string name) where T : Object
	{
		return ConvertObjects<T>(LoadAssetWithSubAssets(name, typeof(T)));
	}

	public Object[] LoadAssetWithSubAssets(string name, Type type)
	{
		if (name == null)
		{
			throw new NullReferenceException("The input asset name cannot be null.");
		}
		if (name.Length == 0)
		{
			throw new ArgumentException("The input asset name cannot be empty.");
		}
		if (type == null)
		{
			throw new NullReferenceException("The input type cannot be null.");
		}
		return LoadAssetWithSubAssets_Internal(name, type);
	}

	public AssetBundleRequest LoadAssetWithSubAssetsAsync(string name)
	{
		return LoadAssetWithSubAssetsAsync(name, typeof(Object));
	}

	public AssetBundleRequest LoadAssetWithSubAssetsAsync<T>(string name)
	{
		return LoadAssetWithSubAssetsAsync(name, typeof(T));
	}

	public AssetBundleRequest LoadAssetWithSubAssetsAsync(string name, Type type)
	{
		if (name == null)
		{
			throw new NullReferenceException("The input asset name cannot be null.");
		}
		if (name.Length == 0)
		{
			throw new ArgumentException("The input asset name cannot be empty.");
		}
		if (type == null)
		{
			throw new NullReferenceException("The input type cannot be null.");
		}
		return LoadAssetWithSubAssetsAsync_Internal(name, type);
	}

	public Object[] LoadAllAssets()
	{
		return LoadAllAssets(typeof(Object));
	}

	public T[] LoadAllAssets<T>() where T : Object
	{
		return ConvertObjects<T>(LoadAllAssets(typeof(T)));
	}

	public Object[] LoadAllAssets(Type type)
	{
		if (type == null)
		{
			throw new NullReferenceException("The input type cannot be null.");
		}
		return LoadAssetWithSubAssets_Internal("", type);
	}

	public AssetBundleRequest LoadAllAssetsAsync()
	{
		return LoadAllAssetsAsync(typeof(Object));
	}

	public AssetBundleRequest LoadAllAssetsAsync<T>()
	{
		return LoadAllAssetsAsync(typeof(T));
	}

	public AssetBundleRequest LoadAllAssetsAsync(Type type)
	{
		if (type == null)
		{
			throw new NullReferenceException("The input type cannot be null.");
		}
		return LoadAssetWithSubAssetsAsync_Internal("", type);
	}

	[Obsolete("This method is deprecated.Use GetAllAssetNames() instead.", false)]
	public string[] AllAssetNames()
	{
		return GetAllAssetNames();
	}

	[NativeMethod("LoadAssetAsync_Internal")]
	[NativeThrows]
	private unsafe AssetBundleRequest LoadAssetAsync_Internal(string name, Type type)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		IntPtr intPtr2 = default(IntPtr);
		AssetBundleRequest result;
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					intPtr2 = LoadAssetAsync_Internal_Injected(intPtr, ref managedSpanWrapper, type);
				}
			}
			else
			{
				intPtr2 = LoadAssetAsync_Internal_Injected(intPtr, ref managedSpanWrapper, type);
			}
		}
		finally
		{
			IntPtr intPtr3 = intPtr2;
			result = ((intPtr3 == (IntPtr)0) ? null : AssetBundleRequest.BindingsMarshaller.ConvertToManaged(intPtr3));
		}
		return result;
	}

	[NativeMethod("Unload")]
	[NativeThrows]
	public void Unload(bool unloadAllLoadedObjects)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Unload_Injected(intPtr, unloadAllLoadedObjects);
	}

	[NativeMethod("UnloadAsync")]
	[NativeThrows]
	public AssetBundleUnloadOperation UnloadAsync(bool unloadAllLoadedObjects)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		IntPtr intPtr2 = UnloadAsync_Injected(intPtr, unloadAllLoadedObjects);
		return (intPtr2 == (IntPtr)0) ? null : AssetBundleUnloadOperation.BindingsMarshaller.ConvertToManaged(intPtr2);
	}

	[NativeMethod("GetAllAssetNames")]
	public string[] GetAllAssetNames()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetAllAssetNames_Injected(intPtr);
	}

	[NativeMethod("GetAllScenePaths")]
	public string[] GetAllScenePaths()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetAllScenePaths_Injected(intPtr);
	}

	[NativeThrows]
	[NativeMethod("LoadAssetWithSubAssets_Internal")]
	internal unsafe Object[] LoadAssetWithSubAssets_Internal(string name, Type type)
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
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return LoadAssetWithSubAssets_Internal_Injected(intPtr, ref managedSpanWrapper, type);
				}
			}
			return LoadAssetWithSubAssets_Internal_Injected(intPtr, ref managedSpanWrapper, type);
		}
		finally
		{
		}
	}

	[NativeThrows]
	[NativeMethod("LoadAssetWithSubAssetsAsync_Internal")]
	private unsafe AssetBundleRequest LoadAssetWithSubAssetsAsync_Internal(string name, Type type)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		IntPtr intPtr2 = default(IntPtr);
		AssetBundleRequest result;
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					intPtr2 = LoadAssetWithSubAssetsAsync_Internal_Injected(intPtr, ref managedSpanWrapper, type);
				}
			}
			else
			{
				intPtr2 = LoadAssetWithSubAssetsAsync_Internal_Injected(intPtr, ref managedSpanWrapper, type);
			}
		}
		finally
		{
			IntPtr intPtr3 = intPtr2;
			result = ((intPtr3 == (IntPtr)0) ? null : AssetBundleRequest.BindingsMarshaller.ConvertToManaged(intPtr3));
		}
		return result;
	}

	public static AssetBundleRecompressOperation RecompressAssetBundleAsync(string inputPath, string outputPath, BuildCompression method, uint expectedCRC = 0u, ThreadPriority priority = ThreadPriority.Low)
	{
		return RecompressAssetBundleAsync_Internal(inputPath, outputPath, method, expectedCRC, priority);
	}

	[FreeFunction("RecompressAssetBundleAsync_Internal")]
	[NativeThrows]
	internal unsafe static AssetBundleRecompressOperation RecompressAssetBundleAsync_Internal(string inputPath, string outputPath, BuildCompression method, uint expectedCRC, ThreadPriority priority)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		IntPtr intPtr = default(IntPtr);
		AssetBundleRecompressOperation result;
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper inputPath2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(inputPath, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(inputPath);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					inputPath2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(outputPath, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(outputPath);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							intPtr = RecompressAssetBundleAsync_Internal_Injected(ref inputPath2, ref managedSpanWrapper2, ref method, expectedCRC, priority);
						}
					}
					else
					{
						intPtr = RecompressAssetBundleAsync_Internal_Injected(ref inputPath2, ref managedSpanWrapper2, ref method, expectedCRC, priority);
					}
				}
			}
			else
			{
				inputPath2 = ref managedSpanWrapper;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(outputPath, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(outputPath);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						intPtr = RecompressAssetBundleAsync_Internal_Injected(ref inputPath2, ref managedSpanWrapper2, ref method, expectedCRC, priority);
					}
				}
				else
				{
					intPtr = RecompressAssetBundleAsync_Internal_Injected(ref inputPath2, ref managedSpanWrapper2, ref method, expectedCRC, priority);
				}
			}
		}
		finally
		{
			IntPtr intPtr2 = intPtr;
			result = ((intPtr2 == (IntPtr)0) ? null : AssetBundleRecompressOperation.BindingsMarshaller.ConvertToManaged(intPtr2));
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr returnMainAsset_Injected(IntPtr bundle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr LoadFromFileAsync_Internal_Injected(ref ManagedSpanWrapper path, uint crc, ulong offset);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr LoadFromFile_Internal_Injected(ref ManagedSpanWrapper path, uint crc, ulong offset);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr LoadFromMemoryAsync_Internal_Injected(ref ManagedSpanWrapper binary, uint crc);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr LoadFromMemory_Internal_Injected(ref ManagedSpanWrapper binary, uint crc);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr LoadFromStreamAsyncInternal_Injected(Stream stream, uint crc, uint managedReadBufferSize);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr LoadFromStreamInternal_Injected(Stream stream, uint crc, uint managedReadBufferSize);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_isStreamedSceneAssetBundle_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool Contains_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr LoadAsset_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, Type type);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr LoadAssetAsync_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, Type type);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Unload_Injected(IntPtr _unity_self, bool unloadAllLoadedObjects);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr UnloadAsync_Injected(IntPtr _unity_self, bool unloadAllLoadedObjects);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string[] GetAllAssetNames_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string[] GetAllScenePaths_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Object[] LoadAssetWithSubAssets_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, Type type);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr LoadAssetWithSubAssetsAsync_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, Type type);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr RecompressAssetBundleAsync_Internal_Injected(ref ManagedSpanWrapper inputPath, ref ManagedSpanWrapper outputPath, [In] ref BuildCompression method, uint expectedCRC, ThreadPriority priority);
}
