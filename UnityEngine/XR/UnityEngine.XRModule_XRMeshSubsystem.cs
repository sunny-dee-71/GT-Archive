using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.XR;

[NativeConditional("ENABLE_XR")]
[NativeHeader("Modules/XR/Subsystems/Meshing/XRMeshingSubsystem.h")]
[UsedByNativeCode]
[NativeHeader("Modules/XR/XRPrefix.h")]
public class XRMeshSubsystem : IntegratedSubsystem<XRMeshSubsystemDescriptor>
{
	[NativeConditional("ENABLE_XR")]
	private readonly struct MeshTransformList(IntPtr self) : IDisposable
	{
		private readonly IntPtr m_Self = self;

		public int Count => GetLength(m_Self);

		public IntPtr Data => GetData(m_Self);

		public void Dispose()
		{
			Dispose(m_Self);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("UnityXRMeshTransformList_get_Length")]
		private static extern int GetLength(IntPtr self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("UnityXRMeshTransformList_get_Data")]
		private static extern IntPtr GetData(IntPtr self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("UnityXRMeshTransformList_Dispose")]
		private static extern void Dispose(IntPtr self);
	}

	internal new static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(XRMeshSubsystem subsystem)
		{
			return subsystem.m_Ptr;
		}
	}

	public float meshDensity
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_meshDensity_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_meshDensity_Injected(intPtr, value);
		}
	}

	public bool TryGetMeshInfos(List<MeshInfo> meshInfosOut)
	{
		if (meshInfosOut == null)
		{
			throw new ArgumentNullException("meshInfosOut");
		}
		return GetMeshInfosAsList(meshInfosOut);
	}

	private unsafe bool GetMeshInfosAsList(List<MeshInfo> meshInfos)
	{
		//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<MeshInfo> list = default(List<MeshInfo>);
		BlittableListWrapper meshInfos2 = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			list = meshInfos;
			if (list != null)
			{
				fixed (MeshInfo[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					meshInfos2 = new BlittableListWrapper(arrayWrapper, list.Count);
					return GetMeshInfosAsList_Injected(intPtr, ref meshInfos2);
				}
			}
			return GetMeshInfosAsList_Injected(intPtr, ref meshInfos2);
		}
		finally
		{
			meshInfos2.Unmarshal(list);
		}
	}

	private MeshInfo[] GetMeshInfosAsFixedArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		MeshInfo[] result;
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetMeshInfosAsFixedArray_Injected(intPtr, out ret);
		}
		finally
		{
			MeshInfo[] array = default(MeshInfo[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public void GenerateMeshAsync(MeshId meshId, Mesh mesh, MeshCollider meshCollider, MeshVertexAttributes attributes, Action<MeshGenerationResult> onMeshGenerationComplete)
	{
		GenerateMeshAsync(meshId, mesh, meshCollider, attributes, onMeshGenerationComplete, MeshGenerationOptions.None);
	}

	public void GenerateMeshAsync(MeshId meshId, Mesh mesh, MeshCollider meshCollider, MeshVertexAttributes attributes, Action<MeshGenerationResult> onMeshGenerationComplete, MeshGenerationOptions options)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GenerateMeshAsync_Injected(intPtr, ref meshId, Object.MarshalledUnityObject.Marshal(mesh), Object.MarshalledUnityObject.Marshal(meshCollider), attributes, onMeshGenerationComplete, options);
	}

	[RequiredByNativeCode]
	private void InvokeMeshReadyDelegate(MeshGenerationResult result, Action<MeshGenerationResult> onMeshGenerationComplete)
	{
		onMeshGenerationComplete?.Invoke(result);
	}

	public bool SetBoundingVolume(Vector3 origin, Vector3 extents)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return SetBoundingVolume_Injected(intPtr, ref origin, ref extents);
	}

	public unsafe NativeArray<MeshTransform> GetUpdatedMeshTransforms(Allocator allocator)
	{
		using MeshTransformList meshTransformList = new MeshTransformList(GetUpdatedMeshTransforms());
		NativeArray<MeshTransform> nativeArray = new NativeArray<MeshTransform>(meshTransformList.Count, allocator, NativeArrayOptions.UninitializedMemory);
		UnsafeUtility.MemCpy(nativeArray.GetUnsafePtr(), meshTransformList.Data.ToPointer(), meshTransformList.Count * sizeof(MeshTransform));
		return nativeArray;
	}

	private IntPtr GetUpdatedMeshTransforms()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetUpdatedMeshTransforms_Injected(intPtr);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetMeshInfosAsList_Injected(IntPtr _unity_self, ref BlittableListWrapper meshInfos);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetMeshInfosAsFixedArray_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GenerateMeshAsync_Injected(IntPtr _unity_self, [In] ref MeshId meshId, IntPtr mesh, IntPtr meshCollider, MeshVertexAttributes attributes, Action<MeshGenerationResult> onMeshGenerationComplete, MeshGenerationOptions options);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_meshDensity_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_meshDensity_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool SetBoundingVolume_Injected(IntPtr _unity_self, [In] ref Vector3 origin, [In] ref Vector3 extents);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetUpdatedMeshTransforms_Injected(IntPtr _unity_self);
}
