using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine;

[NativeHeader("Modules/ImageConversion/ScriptBindings/ImageConversion.bindings.h")]
public static class ImageConversion
{
	public static bool EnableLegacyPngGammaRuntimeLoadBehavior
	{
		get
		{
			return GetEnableLegacyPngGammaRuntimeLoadBehavior();
		}
		set
		{
			SetEnableLegacyPngGammaRuntimeLoadBehavior(value);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "ImageConversionBindings::GetEnableLegacyPngGammaRuntimeLoadBehavior", IsFreeFunction = true, ThrowsException = false)]
	private static extern bool GetEnableLegacyPngGammaRuntimeLoadBehavior();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "ImageConversionBindings::SetEnableLegacyPngGammaRuntimeLoadBehavior", IsFreeFunction = true, ThrowsException = false)]
	private static extern void SetEnableLegacyPngGammaRuntimeLoadBehavior(bool enable);

	[NativeMethod(Name = "ImageConversionBindings::EncodeToTGA", IsFreeFunction = true, ThrowsException = true)]
	public static byte[] EncodeToTGA(this Texture2D tex)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeToTGA_Injected(Object.MarshalledUnityObject.Marshal(tex), out ret);
		}
		finally
		{
			byte[] array = default(byte[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[NativeMethod(Name = "ImageConversionBindings::EncodeToPNG", IsFreeFunction = true, ThrowsException = true)]
	public static byte[] EncodeToPNG(this Texture2D tex)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeToPNG_Injected(Object.MarshalledUnityObject.Marshal(tex), out ret);
		}
		finally
		{
			byte[] array = default(byte[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[NativeMethod(Name = "ImageConversionBindings::EncodeToJPG", IsFreeFunction = true, ThrowsException = true)]
	public static byte[] EncodeToJPG(this Texture2D tex, int quality)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeToJPG_Injected(Object.MarshalledUnityObject.Marshal(tex), quality, out ret);
		}
		finally
		{
			byte[] array = default(byte[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static byte[] EncodeToJPG(this Texture2D tex)
	{
		return tex.EncodeToJPG(75);
	}

	[NativeMethod(Name = "ImageConversionBindings::EncodeToEXR", IsFreeFunction = true, ThrowsException = true)]
	public static byte[] EncodeToEXR(this Texture2D tex, Texture2D.EXRFlags flags)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeToEXR_Injected(Object.MarshalledUnityObject.Marshal(tex), flags, out ret);
		}
		finally
		{
			byte[] array = default(byte[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static byte[] EncodeToEXR(this Texture2D tex)
	{
		return tex.EncodeToEXR(Texture2D.EXRFlags.None);
	}

	[NativeMethod(Name = "ImageConversionBindings::EncodeToR2D", IsFreeFunction = true, ThrowsException = true)]
	internal static byte[] EncodeToR2DInternal(this Texture2D tex)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeToR2DInternal_Injected(Object.MarshalledUnityObject.Marshal(tex), out ret);
		}
		finally
		{
			byte[] array = default(byte[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[NativeMethod(Name = "ImageConversionBindings::LoadImage", IsFreeFunction = true)]
	public unsafe static bool LoadImage([NotNull] this Texture2D tex, ReadOnlySpan<byte> data, bool markNonReadable)
	{
		if ((object)tex == null)
		{
			ThrowHelper.ThrowArgumentNullException(tex, "tex");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(tex);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(tex, "tex");
		}
		ReadOnlySpan<byte> readOnlySpan = data;
		bool result;
		fixed (byte* begin = readOnlySpan)
		{
			ManagedSpanWrapper data2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
			result = LoadImage_Injected(intPtr, ref data2, markNonReadable);
		}
		return result;
	}

	public static bool LoadImage(this Texture2D tex, ReadOnlySpan<byte> data)
	{
		return tex.LoadImage(data, markNonReadable: false);
	}

	public static bool LoadImage(this Texture2D tex, byte[] data, bool markNonReadable)
	{
		return tex.LoadImage(new ReadOnlySpan<byte>(data), markNonReadable);
	}

	public static bool LoadImage(this Texture2D tex, byte[] data)
	{
		return tex.LoadImage(new ReadOnlySpan<byte>(data), markNonReadable: false);
	}

	[FreeFunction("ImageConversionBindings::EncodeArrayToTGA", true)]
	public static byte[] EncodeArrayToTGA(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeArrayToTGA_Injected(array, format, width, height, rowBytes, out ret);
		}
		finally
		{
			byte[] array2 = default(byte[]);
			ret.Unmarshal(ref array2);
			result = array2;
		}
		return result;
	}

	[FreeFunction("ImageConversionBindings::EncodeArrayToPNG", true)]
	public static byte[] EncodeArrayToPNG(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeArrayToPNG_Injected(array, format, width, height, rowBytes, out ret);
		}
		finally
		{
			byte[] array2 = default(byte[]);
			ret.Unmarshal(ref array2);
			result = array2;
		}
		return result;
	}

	[FreeFunction("ImageConversionBindings::EncodeArrayToJPG", true)]
	public static byte[] EncodeArrayToJPG(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u, int quality = 75)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeArrayToJPG_Injected(array, format, width, height, rowBytes, quality, out ret);
		}
		finally
		{
			byte[] array2 = default(byte[]);
			ret.Unmarshal(ref array2);
			result = array2;
		}
		return result;
	}

	[FreeFunction("ImageConversionBindings::EncodeArrayToEXR", true)]
	public static byte[] EncodeArrayToEXR(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u, Texture2D.EXRFlags flags = Texture2D.EXRFlags.None)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeArrayToEXR_Injected(array, format, width, height, rowBytes, flags, out ret);
		}
		finally
		{
			byte[] array2 = default(byte[]);
			ret.Unmarshal(ref array2);
			result = array2;
		}
		return result;
	}

	[FreeFunction("ImageConversionBindings::EncodeArrayToR2D", true)]
	internal static byte[] EncodeArrayToR2DInternal(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeArrayToR2DInternal_Injected(array, format, width, height, rowBytes, out ret);
		}
		finally
		{
			byte[] array2 = default(byte[]);
			ret.Unmarshal(ref array2);
			result = array2;
		}
		return result;
	}

	public unsafe static NativeArray<byte> EncodeNativeArrayToTGA<T>(NativeArray<T> input, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u) where T : struct
	{
		int sizeInBytes = input.Length * UnsafeUtility.SizeOf<T>();
		void* dataPointer = UnsafeEncodeNativeArrayToTGA(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(input), ref sizeInBytes, format, width, height, rowBytes);
		return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(dataPointer, sizeInBytes, Allocator.Persistent);
	}

	public unsafe static NativeArray<byte> EncodeNativeArrayToPNG<T>(NativeArray<T> input, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u) where T : struct
	{
		int sizeInBytes = input.Length * UnsafeUtility.SizeOf<T>();
		void* dataPointer = UnsafeEncodeNativeArrayToPNG(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(input), ref sizeInBytes, format, width, height, rowBytes);
		return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(dataPointer, sizeInBytes, Allocator.Persistent);
	}

	public unsafe static NativeArray<byte> EncodeNativeArrayToJPG<T>(NativeArray<T> input, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u, int quality = 75) where T : struct
	{
		int sizeInBytes = input.Length * UnsafeUtility.SizeOf<T>();
		void* dataPointer = UnsafeEncodeNativeArrayToJPG(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(input), ref sizeInBytes, format, width, height, rowBytes, quality);
		return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(dataPointer, sizeInBytes, Allocator.Persistent);
	}

	public unsafe static NativeArray<byte> EncodeNativeArrayToEXR<T>(NativeArray<T> input, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u, Texture2D.EXRFlags flags = Texture2D.EXRFlags.None) where T : struct
	{
		int sizeInBytes = input.Length * UnsafeUtility.SizeOf<T>();
		void* dataPointer = UnsafeEncodeNativeArrayToEXR(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(input), ref sizeInBytes, format, width, height, rowBytes, flags);
		return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(dataPointer, sizeInBytes, Allocator.Persistent);
	}

	internal unsafe static NativeArray<byte> EncodeNativeArrayToR2DInternal<T>(NativeArray<T> input, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u) where T : struct
	{
		int sizeInBytes = input.Length * UnsafeUtility.SizeOf<T>();
		void* dataPointer = UnsafeEncodeNativeArrayToR2D(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(input), ref sizeInBytes, format, width, height, rowBytes);
		return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(dataPointer, sizeInBytes, Allocator.Persistent);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("ImageConversionBindings::UnsafeEncodeNativeArrayToTGA", true)]
	private unsafe static extern void* UnsafeEncodeNativeArrayToTGA(void* array, ref int sizeInBytes, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("ImageConversionBindings::UnsafeEncodeNativeArrayToPNG", true)]
	private unsafe static extern void* UnsafeEncodeNativeArrayToPNG(void* array, ref int sizeInBytes, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("ImageConversionBindings::UnsafeEncodeNativeArrayToJPG", true)]
	private unsafe static extern void* UnsafeEncodeNativeArrayToJPG(void* array, ref int sizeInBytes, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u, int quality = 75);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("ImageConversionBindings::UnsafeEncodeNativeArrayToEXR", true)]
	private unsafe static extern void* UnsafeEncodeNativeArrayToEXR(void* array, ref int sizeInBytes, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u, Texture2D.EXRFlags flags = Texture2D.EXRFlags.None);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("ImageConversionBindings::UnsafeEncodeNativeArrayToR2D", true)]
	private unsafe static extern void* UnsafeEncodeNativeArrayToR2D(void* array, ref int sizeInBytes, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeToTGA_Injected(IntPtr tex, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeToPNG_Injected(IntPtr tex, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeToJPG_Injected(IntPtr tex, int quality, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeToEXR_Injected(IntPtr tex, Texture2D.EXRFlags flags, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeToR2DInternal_Injected(IntPtr tex, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool LoadImage_Injected(IntPtr tex, ref ManagedSpanWrapper data, bool markNonReadable);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeArrayToTGA_Injected(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeArrayToPNG_Injected(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeArrayToJPG_Injected(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes, int quality, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeArrayToEXR_Injected(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes, Texture2D.EXRFlags flags, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeArrayToR2DInternal_Injected(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes, out BlittableArrayWrapper ret);
}
