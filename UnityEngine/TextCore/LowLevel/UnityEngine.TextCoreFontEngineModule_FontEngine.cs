using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine.TextCore.LowLevel;

[NativeHeader("Modules/TextCoreFontEngine/Native/FontEngine.h")]
public sealed class FontEngine
{
	private static Glyph[] s_Glyphs = new Glyph[16];

	private static uint[] s_GlyphIndexes_MarshallingArray_A;

	private static uint[] s_GlyphIndexes_MarshallingArray_B;

	private static GlyphMarshallingStruct[] s_GlyphMarshallingStruct_IN = new GlyphMarshallingStruct[16];

	private static GlyphMarshallingStruct[] s_GlyphMarshallingStruct_OUT = new GlyphMarshallingStruct[16];

	private static GlyphRect[] s_FreeGlyphRects = new GlyphRect[16];

	private static GlyphRect[] s_UsedGlyphRects = new GlyphRect[16];

	private static GlyphAdjustmentRecord[] s_SingleAdjustmentRecords_MarshallingArray;

	private static SingleSubstitutionRecord[] s_SingleSubstitutionRecords_MarshallingArray;

	private static MultipleSubstitutionRecord[] s_MultipleSubstitutionRecords_MarshallingArray;

	private static AlternateSubstitutionRecord[] s_AlternateSubstitutionRecords_MarshallingArray;

	private static LigatureSubstitutionRecord[] s_LigatureSubstitutionRecords_MarshallingArray;

	private static ContextualSubstitutionRecord[] s_ContextualSubstitutionRecords_MarshallingArray;

	private static ChainingContextualSubstitutionRecord[] s_ChainingContextualSubstitutionRecords_MarshallingArray;

	private static GlyphPairAdjustmentRecord[] s_PairAdjustmentRecords_MarshallingArray;

	private static MarkToBaseAdjustmentRecord[] s_MarkToBaseAdjustmentRecords_MarshallingArray;

	private static MarkToMarkAdjustmentRecord[] s_MarkToMarkAdjustmentRecords_MarshallingArray;

	private static Dictionary<uint, Glyph> s_GlyphLookupDictionary = new Dictionary<uint, Glyph>();

	internal static extern bool isProcessingDone
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextCore::FontEngine::GetIsProcessingDone", IsFreeFunction = true)]
		get;
	}

	internal static extern float generationProgress
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextCore::FontEngine::GetGenerationProgress", IsFreeFunction = true)]
		get;
	}

	internal FontEngine()
	{
	}

	public static FontEngineError InitializeFontEngine()
	{
		return (FontEngineError)InitializeFontEngine_Internal();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::InitFontEngine", IsFreeFunction = true)]
	private static extern int InitializeFontEngine_Internal();

	public static FontEngineError DestroyFontEngine()
	{
		return (FontEngineError)DestroyFontEngine_Internal();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::DestroyFontEngine", IsFreeFunction = true)]
	private static extern int DestroyFontEngine_Internal();

	internal static void SendCancellationRequest()
	{
		SendCancellationRequest_Internal();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::SendCancellationRequest", IsFreeFunction = true)]
	private static extern void SendCancellationRequest_Internal();

	public static FontEngineError LoadFontFace(string filePath)
	{
		return (FontEngineError)LoadFontFace_Internal(filePath);
	}

	[NativeMethod(Name = "TextCore::FontEngine::LoadFontFace", IsFreeFunction = true)]
	private unsafe static int LoadFontFace_Internal(string filePath)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(filePath, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(filePath);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return LoadFontFace_Internal_Injected(ref managedSpanWrapper);
				}
			}
			return LoadFontFace_Internal_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	public static FontEngineError LoadFontFace(string filePath, int pointSize)
	{
		return (FontEngineError)LoadFontFace_With_Size_Internal(filePath, pointSize);
	}

	[NativeMethod(Name = "TextCore::FontEngine::LoadFontFace", IsFreeFunction = true)]
	private unsafe static int LoadFontFace_With_Size_Internal(string filePath, int pointSize)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(filePath, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(filePath);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return LoadFontFace_With_Size_Internal_Injected(ref managedSpanWrapper, pointSize);
				}
			}
			return LoadFontFace_With_Size_Internal_Injected(ref managedSpanWrapper, pointSize);
		}
		finally
		{
		}
	}

	public static FontEngineError LoadFontFace(string filePath, float pointSize, int faceIndex)
	{
		return (FontEngineError)LoadFontFace_With_Size_And_FaceIndex_Internal(filePath, (int)Math.Round(pointSize, MidpointRounding.AwayFromZero), faceIndex);
	}

	[NativeMethod(Name = "TextCore::FontEngine::LoadFontFace", IsFreeFunction = true)]
	private unsafe static int LoadFontFace_With_Size_And_FaceIndex_Internal(string filePath, int pointSize, int faceIndex)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(filePath, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(filePath);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return LoadFontFace_With_Size_And_FaceIndex_Internal_Injected(ref managedSpanWrapper, pointSize, faceIndex);
				}
			}
			return LoadFontFace_With_Size_And_FaceIndex_Internal_Injected(ref managedSpanWrapper, pointSize, faceIndex);
		}
		finally
		{
		}
	}

	public static FontEngineError LoadFontFace(byte[] sourceFontFile)
	{
		if (sourceFontFile.Length == 0)
		{
			return FontEngineError.Invalid_File;
		}
		return (FontEngineError)LoadFontFace_FromSourceFontFile_Internal(sourceFontFile);
	}

	[NativeMethod(Name = "TextCore::FontEngine::LoadFontFace", IsFreeFunction = true)]
	private unsafe static int LoadFontFace_FromSourceFontFile_Internal(byte[] sourceFontFile)
	{
		Span<byte> span = new Span<byte>(sourceFontFile);
		int result;
		fixed (byte* begin = span)
		{
			ManagedSpanWrapper sourceFontFile2 = new ManagedSpanWrapper(begin, span.Length);
			result = LoadFontFace_FromSourceFontFile_Internal_Injected(ref sourceFontFile2);
		}
		return result;
	}

	public static FontEngineError LoadFontFace(byte[] sourceFontFile, int pointSize)
	{
		if (sourceFontFile.Length == 0)
		{
			return FontEngineError.Invalid_File;
		}
		return (FontEngineError)LoadFontFace_With_Size_FromSourceFontFile_Internal(sourceFontFile, pointSize);
	}

	[NativeMethod(Name = "TextCore::FontEngine::LoadFontFace", IsFreeFunction = true)]
	private unsafe static int LoadFontFace_With_Size_FromSourceFontFile_Internal(byte[] sourceFontFile, int pointSize)
	{
		Span<byte> span = new Span<byte>(sourceFontFile);
		int result;
		fixed (byte* begin = span)
		{
			ManagedSpanWrapper sourceFontFile2 = new ManagedSpanWrapper(begin, span.Length);
			result = LoadFontFace_With_Size_FromSourceFontFile_Internal_Injected(ref sourceFontFile2, pointSize);
		}
		return result;
	}

	public static FontEngineError LoadFontFace(byte[] sourceFontFile, float pointSize, int faceIndex)
	{
		if (sourceFontFile.Length == 0)
		{
			return FontEngineError.Invalid_File;
		}
		return (FontEngineError)LoadFontFace_With_Size_And_FaceIndex_FromSourceFontFile_Internal(sourceFontFile, (int)Math.Round(pointSize, MidpointRounding.AwayFromZero), faceIndex);
	}

	[NativeMethod(Name = "TextCore::FontEngine::LoadFontFace", IsFreeFunction = true)]
	private unsafe static int LoadFontFace_With_Size_And_FaceIndex_FromSourceFontFile_Internal(byte[] sourceFontFile, int pointSize, int faceIndex)
	{
		Span<byte> span = new Span<byte>(sourceFontFile);
		int result;
		fixed (byte* begin = span)
		{
			ManagedSpanWrapper sourceFontFile2 = new ManagedSpanWrapper(begin, span.Length);
			result = LoadFontFace_With_Size_And_FaceIndex_FromSourceFontFile_Internal_Injected(ref sourceFontFile2, pointSize, faceIndex);
		}
		return result;
	}

	public static FontEngineError LoadFontFace(Font font)
	{
		return (FontEngineError)LoadFontFace_FromFont_Internal(font);
	}

	[NativeMethod(Name = "TextCore::FontEngine::LoadFontFace", IsFreeFunction = true)]
	private static int LoadFontFace_FromFont_Internal(Font font)
	{
		return LoadFontFace_FromFont_Internal_Injected(Object.MarshalledUnityObject.Marshal(font));
	}

	public static FontEngineError LoadFontFace(Font font, int pointSize)
	{
		return (FontEngineError)LoadFontFace_With_Size_FromFont_Internal(font, pointSize);
	}

	[NativeMethod(Name = "TextCore::FontEngine::LoadFontFace", IsFreeFunction = true)]
	private static int LoadFontFace_With_Size_FromFont_Internal(Font font, int pointSize)
	{
		return LoadFontFace_With_Size_FromFont_Internal_Injected(Object.MarshalledUnityObject.Marshal(font), pointSize);
	}

	public static FontEngineError LoadFontFace(Font font, float pointSize, int faceIndex)
	{
		return (FontEngineError)LoadFontFace_With_Size_and_FaceIndex_FromFont_Internal(font, (int)Math.Round(pointSize, MidpointRounding.AwayFromZero), faceIndex);
	}

	[NativeMethod(Name = "TextCore::FontEngine::LoadFontFace", IsFreeFunction = true)]
	private static int LoadFontFace_With_Size_and_FaceIndex_FromFont_Internal(Font font, int pointSize, int faceIndex)
	{
		return LoadFontFace_With_Size_and_FaceIndex_FromFont_Internal_Injected(Object.MarshalledUnityObject.Marshal(font), pointSize, faceIndex);
	}

	public static FontEngineError LoadFontFace(string familyName, string styleName)
	{
		return (FontEngineError)LoadFontFace_by_FamilyName_and_StyleName_Internal(familyName, styleName);
	}

	[NativeMethod(Name = "TextCore::FontEngine::LoadFontFace", IsFreeFunction = true)]
	private unsafe static int LoadFontFace_by_FamilyName_and_StyleName_Internal(string familyName, string styleName)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper familyName2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(familyName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(familyName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					familyName2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(styleName, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(styleName);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							return LoadFontFace_by_FamilyName_and_StyleName_Internal_Injected(ref familyName2, ref managedSpanWrapper2);
						}
					}
					return LoadFontFace_by_FamilyName_and_StyleName_Internal_Injected(ref familyName2, ref managedSpanWrapper2);
				}
			}
			familyName2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(styleName, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(styleName);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					return LoadFontFace_by_FamilyName_and_StyleName_Internal_Injected(ref familyName2, ref managedSpanWrapper2);
				}
			}
			return LoadFontFace_by_FamilyName_and_StyleName_Internal_Injected(ref familyName2, ref managedSpanWrapper2);
		}
		finally
		{
		}
	}

	public static FontEngineError LoadFontFace(string familyName, string styleName, float pointSize)
	{
		return (FontEngineError)LoadFontFace_With_Size_by_FamilyName_and_StyleName_Internal(familyName, styleName, (int)Math.Round(pointSize, MidpointRounding.AwayFromZero));
	}

	[NativeMethod(Name = "TextCore::FontEngine::LoadFontFace", IsFreeFunction = true)]
	private unsafe static int LoadFontFace_With_Size_by_FamilyName_and_StyleName_Internal(string familyName, string styleName, int pointSize)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper familyName2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(familyName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(familyName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					familyName2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(styleName, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(styleName);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							return LoadFontFace_With_Size_by_FamilyName_and_StyleName_Internal_Injected(ref familyName2, ref managedSpanWrapper2, pointSize);
						}
					}
					return LoadFontFace_With_Size_by_FamilyName_and_StyleName_Internal_Injected(ref familyName2, ref managedSpanWrapper2, pointSize);
				}
			}
			familyName2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(styleName, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(styleName);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					return LoadFontFace_With_Size_by_FamilyName_and_StyleName_Internal_Injected(ref familyName2, ref managedSpanWrapper2, pointSize);
				}
			}
			return LoadFontFace_With_Size_by_FamilyName_and_StyleName_Internal_Injected(ref familyName2, ref managedSpanWrapper2, pointSize);
		}
		finally
		{
		}
	}

	public static FontEngineError UnloadFontFace()
	{
		return (FontEngineError)UnloadFontFace_Internal();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::UnloadFontFace", IsFreeFunction = true)]
	private static extern int UnloadFontFace_Internal();

	public static FontEngineError UnloadAllFontFaces()
	{
		return (FontEngineError)UnloadAllFontFaces_Internal();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::UnloadAllFontFaces", IsFreeFunction = true)]
	private static extern int UnloadAllFontFaces_Internal();

	public static string[] GetSystemFontNames()
	{
		string[] systemFontNames_Internal = GetSystemFontNames_Internal();
		if (systemFontNames_Internal != null && systemFontNames_Internal.Length == 0)
		{
			return null;
		}
		return systemFontNames_Internal;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::GetSystemFontNames", IsThreadSafe = true, IsFreeFunction = true)]
	private static extern string[] GetSystemFontNames_Internal();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::GetSystemFontReferences", IsThreadSafe = true, IsFreeFunction = true)]
	internal static extern FontReference[] GetSystemFontReferences();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static extern bool IsColorFontFace();

	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static bool TryGetSystemFontReference(string familyName, string styleName, out FontReference fontRef)
	{
		return TryGetSystemFontReference_Internal(familyName, styleName, out fontRef);
	}

	[NativeMethod(Name = "TextCore::FontEngine::TryGetSystemFontReference", IsThreadSafe = true, IsFreeFunction = true)]
	private unsafe static bool TryGetSystemFontReference_Internal(string familyName, string styleName, out FontReference fontRef)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper familyName2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(familyName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(familyName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					familyName2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(styleName, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(styleName);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							return TryGetSystemFontReference_Internal_Injected(ref familyName2, ref managedSpanWrapper2, out fontRef);
						}
					}
					return TryGetSystemFontReference_Internal_Injected(ref familyName2, ref managedSpanWrapper2, out fontRef);
				}
			}
			familyName2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(styleName, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(styleName);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					return TryGetSystemFontReference_Internal_Injected(ref familyName2, ref managedSpanWrapper2, out fontRef);
				}
			}
			return TryGetSystemFontReference_Internal_Injected(ref familyName2, ref managedSpanWrapper2, out fontRef);
		}
		finally
		{
		}
	}

	public static FontEngineError SetFaceSize(int pointSize)
	{
		return (FontEngineError)SetFaceSize_Internal(pointSize);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::SetFaceSize", IsThreadSafe = true, IsFreeFunction = true)]
	private static extern int SetFaceSize_Internal(int pointSize);

	public static FaceInfo GetFaceInfo()
	{
		FaceInfo faceInfo = default(FaceInfo);
		GetFaceInfo_Internal(ref faceInfo);
		return faceInfo;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::GetFaceInfo", IsThreadSafe = true, IsFreeFunction = true)]
	private static extern int GetFaceInfo_Internal(ref FaceInfo faceInfo);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::GetFaceCount", IsThreadSafe = true, IsFreeFunction = true)]
	internal static extern int GetFaceCount();

	public static string[] GetFontFaces()
	{
		string[] fontFaces_Internal = GetFontFaces_Internal();
		if (fontFaces_Internal != null && fontFaces_Internal.Length == 0)
		{
			return null;
		}
		return fontFaces_Internal;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::GetFontFaces", IsThreadSafe = true, IsFreeFunction = true)]
	private static extern string[] GetFontFaces_Internal();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	[NativeMethod(Name = "TextCore::FontEngine::GetVariantGlyphIndex", IsThreadSafe = true, IsFreeFunction = true)]
	internal static extern uint GetVariantGlyphIndex(uint unicode, uint variantSelectorUnicode);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	[NativeMethod(Name = "TextCore::FontEngine::GetGlyphIndex", IsThreadSafe = true, IsFreeFunction = true)]
	internal static extern uint GetGlyphIndex(uint unicode);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::TryGetGlyphIndex", IsThreadSafe = true, IsFreeFunction = true)]
	public static extern bool TryGetGlyphIndex(uint unicode, out uint glyphIndex);

	public static bool TryGetGlyphWithUnicodeValue(uint unicode, GlyphLoadFlags flags, out Glyph glyph)
	{
		GlyphMarshallingStruct glyphStruct = default(GlyphMarshallingStruct);
		if (TryGetGlyphWithUnicodeValue_Internal(unicode, flags, ref glyphStruct))
		{
			glyph = new Glyph(glyphStruct);
			return true;
		}
		glyph = null;
		return false;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::TryGetGlyphWithUnicodeValue", IsThreadSafe = true, IsFreeFunction = true)]
	private static extern bool TryGetGlyphWithUnicodeValue_Internal(uint unicode, GlyphLoadFlags loadFlags, ref GlyphMarshallingStruct glyphStruct);

	public static bool TryGetGlyphWithIndexValue(uint glyphIndex, GlyphLoadFlags flags, out Glyph glyph)
	{
		GlyphMarshallingStruct glyphStruct = default(GlyphMarshallingStruct);
		if (TryGetGlyphWithIndexValue_Internal(glyphIndex, flags, ref glyphStruct))
		{
			glyph = new Glyph(glyphStruct);
			return true;
		}
		glyph = null;
		return false;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::TryGetGlyphWithIndexValue", IsThreadSafe = true, IsFreeFunction = true)]
	private static extern bool TryGetGlyphWithIndexValue_Internal(uint glyphIndex, GlyphLoadFlags loadFlags, ref GlyphMarshallingStruct glyphStruct);

	internal static bool TryPackGlyphInAtlas(Glyph glyph, int padding, GlyphPackingMode packingMode, GlyphRenderMode renderMode, int width, int height, List<GlyphRect> freeGlyphRects, List<GlyphRect> usedGlyphRects)
	{
		GlyphMarshallingStruct glyph2 = new GlyphMarshallingStruct(glyph);
		int freeGlyphRectCount = freeGlyphRects.Count;
		int usedGlyphRectCount = usedGlyphRects.Count;
		int num = freeGlyphRectCount + usedGlyphRectCount;
		if (s_FreeGlyphRects.Length < num || s_UsedGlyphRects.Length < num)
		{
			int num2 = Mathf.NextPowerOfTwo(num + 1);
			s_FreeGlyphRects = new GlyphRect[num2];
			s_UsedGlyphRects = new GlyphRect[num2];
		}
		int num3 = Mathf.Max(freeGlyphRectCount, usedGlyphRectCount);
		for (int i = 0; i < num3; i++)
		{
			if (i < freeGlyphRectCount)
			{
				s_FreeGlyphRects[i] = freeGlyphRects[i];
			}
			if (i < usedGlyphRectCount)
			{
				s_UsedGlyphRects[i] = usedGlyphRects[i];
			}
		}
		if (TryPackGlyphInAtlas_Internal(ref glyph2, padding, packingMode, renderMode, width, height, s_FreeGlyphRects, ref freeGlyphRectCount, s_UsedGlyphRects, ref usedGlyphRectCount))
		{
			glyph.glyphRect = glyph2.glyphRect;
			freeGlyphRects.Clear();
			usedGlyphRects.Clear();
			num3 = Mathf.Max(freeGlyphRectCount, usedGlyphRectCount);
			for (int j = 0; j < num3; j++)
			{
				if (j < freeGlyphRectCount)
				{
					freeGlyphRects.Add(s_FreeGlyphRects[j]);
				}
				if (j < usedGlyphRectCount)
				{
					usedGlyphRects.Add(s_UsedGlyphRects[j]);
				}
			}
			return true;
		}
		return false;
	}

	[NativeMethod(Name = "TextCore::FontEngine::TryPackGlyph", IsThreadSafe = true, IsFreeFunction = true)]
	private unsafe static bool TryPackGlyphInAtlas_Internal(ref GlyphMarshallingStruct glyph, int padding, GlyphPackingMode packingMode, GlyphRenderMode renderMode, int width, int height, [Out] GlyphRect[] freeGlyphRects, ref int freeGlyphRectCount, [Out] GlyphRect[] usedGlyphRects, ref int usedGlyphRectCount)
	{
		//The blocks IL_0025, IL_002e, IL_0033, IL_0035, IL_0047 are reachable both inside and outside the pinned region starting at IL_000e. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0047 are reachable both inside and outside the pinned region starting at IL_0030. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper blittableArrayWrapper = default(BlittableArrayWrapper);
		BlittableArrayWrapper usedGlyphRects2 = default(BlittableArrayWrapper);
		try
		{
			ref BlittableArrayWrapper freeGlyphRects2;
			ref int freeGlyphRectCount2;
			if (freeGlyphRects != null)
			{
				fixed (GlyphRect[] array = freeGlyphRects)
				{
					if (array.Length != 0)
					{
						blittableArrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					freeGlyphRects2 = ref blittableArrayWrapper;
					freeGlyphRectCount2 = ref freeGlyphRectCount;
					if (usedGlyphRects != null)
					{
						fixed (GlyphRect[] array2 = usedGlyphRects)
						{
							if (array2.Length != 0)
							{
								usedGlyphRects2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
							}
							return TryPackGlyphInAtlas_Internal_Injected(ref glyph, padding, packingMode, renderMode, width, height, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount);
						}
					}
					return TryPackGlyphInAtlas_Internal_Injected(ref glyph, padding, packingMode, renderMode, width, height, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount);
				}
			}
			freeGlyphRects2 = ref blittableArrayWrapper;
			freeGlyphRectCount2 = ref freeGlyphRectCount;
			if (usedGlyphRects != null)
			{
				array2 = usedGlyphRects;
				if (array2.Length != 0)
				{
					usedGlyphRects2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
				}
			}
			return TryPackGlyphInAtlas_Internal_Injected(ref glyph, padding, packingMode, renderMode, width, height, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount);
		}
		finally
		{
			blittableArrayWrapper.Unmarshal(ref array);
			usedGlyphRects2.Unmarshal(ref array2);
		}
	}

	internal static bool TryPackGlyphsInAtlas(List<Glyph> glyphsToAdd, List<Glyph> glyphsAdded, int padding, GlyphPackingMode packingMode, GlyphRenderMode renderMode, int width, int height, List<GlyphRect> freeGlyphRects, List<GlyphRect> usedGlyphRects)
	{
		int glyphsToAddCount = glyphsToAdd.Count;
		int glyphsAddedCount = glyphsAdded.Count;
		int freeGlyphRectCount = freeGlyphRects.Count;
		int usedGlyphRectCount = usedGlyphRects.Count;
		int num = glyphsToAddCount + glyphsAddedCount + freeGlyphRectCount + usedGlyphRectCount;
		if (s_GlyphMarshallingStruct_IN.Length < num || s_GlyphMarshallingStruct_OUT.Length < num || s_FreeGlyphRects.Length < num || s_UsedGlyphRects.Length < num)
		{
			int num2 = Mathf.NextPowerOfTwo(num + 1);
			s_GlyphMarshallingStruct_IN = new GlyphMarshallingStruct[num2];
			s_GlyphMarshallingStruct_OUT = new GlyphMarshallingStruct[num2];
			s_FreeGlyphRects = new GlyphRect[num2];
			s_UsedGlyphRects = new GlyphRect[num2];
		}
		s_GlyphLookupDictionary.Clear();
		for (int i = 0; i < num; i++)
		{
			if (i < glyphsToAddCount)
			{
				GlyphMarshallingStruct glyphMarshallingStruct = new GlyphMarshallingStruct(glyphsToAdd[i]);
				s_GlyphMarshallingStruct_IN[i] = glyphMarshallingStruct;
				if (!s_GlyphLookupDictionary.ContainsKey(glyphMarshallingStruct.index))
				{
					s_GlyphLookupDictionary.Add(glyphMarshallingStruct.index, glyphsToAdd[i]);
				}
			}
			if (i < glyphsAddedCount)
			{
				GlyphMarshallingStruct glyphMarshallingStruct2 = new GlyphMarshallingStruct(glyphsAdded[i]);
				s_GlyphMarshallingStruct_OUT[i] = glyphMarshallingStruct2;
				if (!s_GlyphLookupDictionary.ContainsKey(glyphMarshallingStruct2.index))
				{
					s_GlyphLookupDictionary.Add(glyphMarshallingStruct2.index, glyphsAdded[i]);
				}
			}
			if (i < freeGlyphRectCount)
			{
				s_FreeGlyphRects[i] = freeGlyphRects[i];
			}
			if (i < usedGlyphRectCount)
			{
				s_UsedGlyphRects[i] = usedGlyphRects[i];
			}
		}
		bool result = TryPackGlyphsInAtlas_Internal(s_GlyphMarshallingStruct_IN, ref glyphsToAddCount, s_GlyphMarshallingStruct_OUT, ref glyphsAddedCount, padding, packingMode, renderMode, width, height, s_FreeGlyphRects, ref freeGlyphRectCount, s_UsedGlyphRects, ref usedGlyphRectCount);
		glyphsToAdd.Clear();
		glyphsAdded.Clear();
		freeGlyphRects.Clear();
		usedGlyphRects.Clear();
		for (int j = 0; j < num; j++)
		{
			if (j < glyphsToAddCount)
			{
				GlyphMarshallingStruct glyphMarshallingStruct3 = s_GlyphMarshallingStruct_IN[j];
				Glyph glyph = s_GlyphLookupDictionary[glyphMarshallingStruct3.index];
				glyph.metrics = glyphMarshallingStruct3.metrics;
				glyph.glyphRect = glyphMarshallingStruct3.glyphRect;
				glyph.scale = glyphMarshallingStruct3.scale;
				glyph.atlasIndex = glyphMarshallingStruct3.atlasIndex;
				glyphsToAdd.Add(glyph);
			}
			if (j < glyphsAddedCount)
			{
				GlyphMarshallingStruct glyphMarshallingStruct4 = s_GlyphMarshallingStruct_OUT[j];
				Glyph glyph2 = s_GlyphLookupDictionary[glyphMarshallingStruct4.index];
				glyph2.metrics = glyphMarshallingStruct4.metrics;
				glyph2.glyphRect = glyphMarshallingStruct4.glyphRect;
				glyph2.scale = glyphMarshallingStruct4.scale;
				glyph2.atlasIndex = glyphMarshallingStruct4.atlasIndex;
				glyphsAdded.Add(glyph2);
			}
			if (j < freeGlyphRectCount)
			{
				freeGlyphRects.Add(s_FreeGlyphRects[j]);
			}
			if (j < usedGlyphRectCount)
			{
				usedGlyphRects.Add(s_UsedGlyphRects[j]);
			}
		}
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::TryPackGlyphs", IsThreadSafe = true, IsFreeFunction = true)]
	private unsafe static bool TryPackGlyphsInAtlas_Internal([Out] GlyphMarshallingStruct[] glyphsToAdd, ref int glyphsToAddCount, [Out] GlyphMarshallingStruct[] glyphsAdded, ref int glyphsAddedCount, int padding, GlyphPackingMode packingMode, GlyphRenderMode renderMode, int width, int height, [Out] GlyphRect[] freeGlyphRects, ref int freeGlyphRectCount, [Out] GlyphRect[] usedGlyphRects, ref int usedGlyphRectCount)
	{
		//The blocks IL_001b, IL_0022, IL_0026, IL_0028, IL_003a, IL_004c, IL_0053, IL_0055, IL_0069, IL_0072, IL_0079, IL_007b, IL_008f are reachable both inside and outside the pinned region starting at IL_0004. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_003a, IL_004c, IL_0053, IL_0055, IL_0069, IL_0072, IL_0079, IL_007b, IL_008f are reachable both inside and outside the pinned region starting at IL_0023. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0069, IL_0072, IL_0079, IL_007b, IL_008f are reachable both inside and outside the pinned region starting at IL_004e. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_008f are reachable both inside and outside the pinned region starting at IL_0074. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper blittableArrayWrapper = default(BlittableArrayWrapper);
		BlittableArrayWrapper blittableArrayWrapper2 = default(BlittableArrayWrapper);
		BlittableArrayWrapper blittableArrayWrapper3 = default(BlittableArrayWrapper);
		BlittableArrayWrapper usedGlyphRects2 = default(BlittableArrayWrapper);
		try
		{
			ref BlittableArrayWrapper glyphsToAdd2;
			ref int glyphsToAddCount2;
			ref BlittableArrayWrapper glyphsAdded2;
			ref int glyphsAddedCount2;
			int padding2;
			GlyphPackingMode packingMode2;
			GlyphRenderMode renderMode2;
			int width2;
			int height2;
			ref BlittableArrayWrapper freeGlyphRects2;
			ref int freeGlyphRectCount2;
			if (glyphsToAdd != null)
			{
				fixed (GlyphMarshallingStruct[] array = glyphsToAdd)
				{
					if (array.Length != 0)
					{
						blittableArrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					glyphsToAdd2 = ref blittableArrayWrapper;
					glyphsToAddCount2 = ref glyphsToAddCount;
					if (glyphsAdded != null)
					{
						fixed (GlyphMarshallingStruct[] array2 = glyphsAdded)
						{
							if (array2.Length != 0)
							{
								blittableArrayWrapper2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
							}
							glyphsAdded2 = ref blittableArrayWrapper2;
							glyphsAddedCount2 = ref glyphsAddedCount;
							padding2 = padding;
							packingMode2 = packingMode;
							renderMode2 = renderMode;
							width2 = width;
							height2 = height;
							if (freeGlyphRects != null)
							{
								fixed (GlyphRect[] array3 = freeGlyphRects)
								{
									if (array3.Length != 0)
									{
										blittableArrayWrapper3 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array3[0]), array3.Length);
									}
									freeGlyphRects2 = ref blittableArrayWrapper3;
									freeGlyphRectCount2 = ref freeGlyphRectCount;
									if (usedGlyphRects != null)
									{
										fixed (GlyphRect[] array4 = usedGlyphRects)
										{
											if (array4.Length != 0)
											{
												usedGlyphRects2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array4[0]), array4.Length);
											}
											return TryPackGlyphsInAtlas_Internal_Injected(out glyphsToAdd2, ref glyphsToAddCount2, out glyphsAdded2, ref glyphsAddedCount2, padding2, packingMode2, renderMode2, width2, height2, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount);
										}
									}
									return TryPackGlyphsInAtlas_Internal_Injected(out glyphsToAdd2, ref glyphsToAddCount2, out glyphsAdded2, ref glyphsAddedCount2, padding2, packingMode2, renderMode2, width2, height2, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount);
								}
							}
							freeGlyphRects2 = ref blittableArrayWrapper3;
							freeGlyphRectCount2 = ref freeGlyphRectCount;
							if (usedGlyphRects != null)
							{
								array4 = usedGlyphRects;
								if (array4.Length != 0)
								{
									usedGlyphRects2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array4[0]), array4.Length);
								}
							}
							return TryPackGlyphsInAtlas_Internal_Injected(out glyphsToAdd2, ref glyphsToAddCount2, out glyphsAdded2, ref glyphsAddedCount2, padding2, packingMode2, renderMode2, width2, height2, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount);
						}
					}
					glyphsAdded2 = ref blittableArrayWrapper2;
					glyphsAddedCount2 = ref glyphsAddedCount;
					padding2 = padding;
					packingMode2 = packingMode;
					renderMode2 = renderMode;
					width2 = width;
					height2 = height;
					if (freeGlyphRects != null)
					{
						array3 = freeGlyphRects;
						if (array3.Length != 0)
						{
							blittableArrayWrapper3 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array3[0]), array3.Length);
						}
					}
					freeGlyphRects2 = ref blittableArrayWrapper3;
					freeGlyphRectCount2 = ref freeGlyphRectCount;
					if (usedGlyphRects != null)
					{
						array4 = usedGlyphRects;
						if (array4.Length != 0)
						{
							usedGlyphRects2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array4[0]), array4.Length);
						}
					}
					return TryPackGlyphsInAtlas_Internal_Injected(out glyphsToAdd2, ref glyphsToAddCount2, out glyphsAdded2, ref glyphsAddedCount2, padding2, packingMode2, renderMode2, width2, height2, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount);
				}
			}
			glyphsToAdd2 = ref blittableArrayWrapper;
			glyphsToAddCount2 = ref glyphsToAddCount;
			if (glyphsAdded != null)
			{
				array2 = glyphsAdded;
				if (array2.Length != 0)
				{
					blittableArrayWrapper2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
				}
			}
			glyphsAdded2 = ref blittableArrayWrapper2;
			glyphsAddedCount2 = ref glyphsAddedCount;
			padding2 = padding;
			packingMode2 = packingMode;
			renderMode2 = renderMode;
			width2 = width;
			height2 = height;
			if (freeGlyphRects != null)
			{
				array3 = freeGlyphRects;
				if (array3.Length != 0)
				{
					blittableArrayWrapper3 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array3[0]), array3.Length);
				}
			}
			freeGlyphRects2 = ref blittableArrayWrapper3;
			freeGlyphRectCount2 = ref freeGlyphRectCount;
			if (usedGlyphRects != null)
			{
				array4 = usedGlyphRects;
				if (array4.Length != 0)
				{
					usedGlyphRects2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array4[0]), array4.Length);
				}
			}
			return TryPackGlyphsInAtlas_Internal_Injected(out glyphsToAdd2, ref glyphsToAddCount2, out glyphsAdded2, ref glyphsAddedCount2, padding2, packingMode2, renderMode2, width2, height2, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount);
		}
		finally
		{
			blittableArrayWrapper.Unmarshal(ref array);
			blittableArrayWrapper2.Unmarshal(ref array2);
			blittableArrayWrapper3.Unmarshal(ref array3);
			usedGlyphRects2.Unmarshal(ref array4);
		}
	}

	internal static FontEngineError RenderGlyphToTexture(Glyph glyph, int padding, GlyphRenderMode renderMode, Texture2D texture)
	{
		GlyphMarshallingStruct glyphStruct = new GlyphMarshallingStruct(glyph);
		return (FontEngineError)RenderGlyphToTexture_Internal(glyphStruct, padding, renderMode, texture);
	}

	[NativeMethod(Name = "TextCore::FontEngine::RenderGlyphToTexture", IsFreeFunction = true)]
	private static int RenderGlyphToTexture_Internal(GlyphMarshallingStruct glyphStruct, int padding, GlyphRenderMode renderMode, Texture2D texture)
	{
		return RenderGlyphToTexture_Internal_Injected(ref glyphStruct, padding, renderMode, Object.MarshalledUnityObject.Marshal(texture));
	}

	internal static FontEngineError RenderGlyphsToTexture(List<Glyph> glyphs, int padding, GlyphRenderMode renderMode, Texture2D texture)
	{
		int count = glyphs.Count;
		if (s_GlyphMarshallingStruct_IN.Length < count)
		{
			int num = Mathf.NextPowerOfTwo(count + 1);
			s_GlyphMarshallingStruct_IN = new GlyphMarshallingStruct[num];
		}
		for (int i = 0; i < count; i++)
		{
			s_GlyphMarshallingStruct_IN[i] = new GlyphMarshallingStruct(glyphs[i]);
		}
		return (FontEngineError)RenderGlyphsToTexture_Internal(s_GlyphMarshallingStruct_IN, count, padding, renderMode, texture);
	}

	[NativeMethod(Name = "TextCore::FontEngine::RenderGlyphsToTexture", IsFreeFunction = true)]
	private unsafe static int RenderGlyphsToTexture_Internal(GlyphMarshallingStruct[] glyphs, int glyphCount, int padding, GlyphRenderMode renderMode, Texture2D texture)
	{
		Span<GlyphMarshallingStruct> span = new Span<GlyphMarshallingStruct>(glyphs);
		int result;
		fixed (GlyphMarshallingStruct* begin = span)
		{
			ManagedSpanWrapper glyphs2 = new ManagedSpanWrapper(begin, span.Length);
			result = RenderGlyphsToTexture_Internal_Injected(ref glyphs2, glyphCount, padding, renderMode, Object.MarshalledUnityObject.Marshal(texture));
		}
		return result;
	}

	internal static FontEngineError RenderGlyphsToTexture(List<Glyph> glyphs, int padding, GlyphRenderMode renderMode, byte[] texBuffer, int texWidth, int texHeight)
	{
		int count = glyphs.Count;
		if (s_GlyphMarshallingStruct_IN.Length < count)
		{
			int num = Mathf.NextPowerOfTwo(count + 1);
			s_GlyphMarshallingStruct_IN = new GlyphMarshallingStruct[num];
		}
		for (int i = 0; i < count; i++)
		{
			s_GlyphMarshallingStruct_IN[i] = new GlyphMarshallingStruct(glyphs[i]);
		}
		return (FontEngineError)RenderGlyphsToTextureBuffer_Internal(s_GlyphMarshallingStruct_IN, count, padding, renderMode, texBuffer, texWidth, texHeight);
	}

	[NativeMethod(Name = "TextCore::FontEngine::RenderGlyphsToTextureBuffer", IsThreadSafe = true, IsFreeFunction = true)]
	private unsafe static int RenderGlyphsToTextureBuffer_Internal(GlyphMarshallingStruct[] glyphs, int glyphCount, int padding, GlyphRenderMode renderMode, [Out] byte[] texBuffer, int texWidth, int texHeight)
	{
		//The blocks IL_0047 are reachable both inside and outside the pinned region starting at IL_002c. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper texBuffer2 = default(BlittableArrayWrapper);
		try
		{
			Span<GlyphMarshallingStruct> span = new Span<GlyphMarshallingStruct>(glyphs);
			fixed (GlyphMarshallingStruct* begin = span)
			{
				ManagedSpanWrapper glyphs2 = new ManagedSpanWrapper(begin, span.Length);
				if (texBuffer != null)
				{
					fixed (byte[] array = texBuffer)
					{
						if (array.Length != 0)
						{
							texBuffer2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						return RenderGlyphsToTextureBuffer_Internal_Injected(ref glyphs2, glyphCount, padding, renderMode, out texBuffer2, texWidth, texHeight);
					}
				}
				return RenderGlyphsToTextureBuffer_Internal_Injected(ref glyphs2, glyphCount, padding, renderMode, out texBuffer2, texWidth, texHeight);
			}
		}
		finally
		{
			texBuffer2.Unmarshal(ref array);
		}
	}

	internal static FontEngineError RenderGlyphsToSharedTexture(List<Glyph> glyphs, int padding, GlyphRenderMode renderMode)
	{
		int count = glyphs.Count;
		if (s_GlyphMarshallingStruct_IN.Length < count)
		{
			int num = Mathf.NextPowerOfTwo(count + 1);
			s_GlyphMarshallingStruct_IN = new GlyphMarshallingStruct[num];
		}
		for (int i = 0; i < count; i++)
		{
			s_GlyphMarshallingStruct_IN[i] = new GlyphMarshallingStruct(glyphs[i]);
		}
		return (FontEngineError)RenderGlyphsToSharedTexture_Internal(s_GlyphMarshallingStruct_IN, count, padding, renderMode);
	}

	[NativeMethod(Name = "TextCore::FontEngine::RenderGlyphsToSharedTexture", IsThreadSafe = true, IsFreeFunction = true)]
	private unsafe static int RenderGlyphsToSharedTexture_Internal(GlyphMarshallingStruct[] glyphs, int glyphCount, int padding, GlyphRenderMode renderMode)
	{
		Span<GlyphMarshallingStruct> span = new Span<GlyphMarshallingStruct>(glyphs);
		int result;
		fixed (GlyphMarshallingStruct* begin = span)
		{
			ManagedSpanWrapper glyphs2 = new ManagedSpanWrapper(begin, span.Length);
			result = RenderGlyphsToSharedTexture_Internal_Injected(ref glyphs2, glyphCount, padding, renderMode);
		}
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::SetSharedTextureData", IsFreeFunction = true)]
	internal static void SetSharedTexture(Texture2D texture)
	{
		SetSharedTexture_Injected(Object.MarshalledUnityObject.Marshal(texture));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::ReleaseSharedTextureData", IsThreadSafe = true, IsFreeFunction = true)]
	internal static extern void ReleaseSharedTexture();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::SetTextureUploadMode", IsThreadSafe = true, IsFreeFunction = true)]
	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static extern void SetTextureUploadMode(bool shouldUploadImmediately);

	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static bool TryAddGlyphToTexture(uint glyphIndex, int padding, GlyphPackingMode packingMode, List<GlyphRect> freeGlyphRects, List<GlyphRect> usedGlyphRects, GlyphRenderMode renderMode, Texture2D texture, out Glyph glyph)
	{
		int freeGlyphRectCount = freeGlyphRects.Count;
		int usedGlyphRectCount = usedGlyphRects.Count;
		int num = freeGlyphRectCount + usedGlyphRectCount;
		if (s_FreeGlyphRects.Length < num || s_UsedGlyphRects.Length < num)
		{
			int num2 = Mathf.NextPowerOfTwo(num + 1);
			s_FreeGlyphRects = new GlyphRect[num2];
			s_UsedGlyphRects = new GlyphRect[num2];
		}
		int num3 = Mathf.Max(freeGlyphRectCount, usedGlyphRectCount);
		for (int i = 0; i < num3; i++)
		{
			if (i < freeGlyphRectCount)
			{
				s_FreeGlyphRects[i] = freeGlyphRects[i];
			}
			if (i < usedGlyphRectCount)
			{
				s_UsedGlyphRects[i] = usedGlyphRects[i];
			}
		}
		if (TryAddGlyphToTexture_Internal(glyphIndex, padding, packingMode, s_FreeGlyphRects, ref freeGlyphRectCount, s_UsedGlyphRects, ref usedGlyphRectCount, renderMode, texture, out var glyph2))
		{
			glyph = new Glyph(glyph2);
			freeGlyphRects.Clear();
			usedGlyphRects.Clear();
			num3 = Mathf.Max(freeGlyphRectCount, usedGlyphRectCount);
			for (int j = 0; j < num3; j++)
			{
				if (j < freeGlyphRectCount)
				{
					freeGlyphRects.Add(s_FreeGlyphRects[j]);
				}
				if (j < usedGlyphRectCount)
				{
					usedGlyphRects.Add(s_UsedGlyphRects[j]);
				}
			}
			return true;
		}
		glyph = null;
		return false;
	}

	[NativeMethod(Name = "TextCore::FontEngine::TryAddGlyphToTexture", IsThreadSafe = true, IsFreeFunction = true)]
	private unsafe static bool TryAddGlyphToTexture_Internal(uint glyphIndex, int padding, GlyphPackingMode packingMode, [Out] GlyphRect[] freeGlyphRects, ref int freeGlyphRectCount, [Out] GlyphRect[] usedGlyphRects, ref int usedGlyphRectCount, GlyphRenderMode renderMode, Texture2D texture, out GlyphMarshallingStruct glyph)
	{
		//The blocks IL_001e, IL_0027, IL_002c, IL_002e, IL_0040 are reachable both inside and outside the pinned region starting at IL_0007. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0040 are reachable both inside and outside the pinned region starting at IL_0029. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper blittableArrayWrapper = default(BlittableArrayWrapper);
		BlittableArrayWrapper usedGlyphRects2 = default(BlittableArrayWrapper);
		try
		{
			ref BlittableArrayWrapper freeGlyphRects2;
			ref int freeGlyphRectCount2;
			if (freeGlyphRects != null)
			{
				fixed (GlyphRect[] array = freeGlyphRects)
				{
					if (array.Length != 0)
					{
						blittableArrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					freeGlyphRects2 = ref blittableArrayWrapper;
					freeGlyphRectCount2 = ref freeGlyphRectCount;
					if (usedGlyphRects != null)
					{
						fixed (GlyphRect[] array2 = usedGlyphRects)
						{
							if (array2.Length != 0)
							{
								usedGlyphRects2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
							}
							return TryAddGlyphToTexture_Internal_Injected(glyphIndex, padding, packingMode, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount, renderMode, Object.MarshalledUnityObject.Marshal(texture), out glyph);
						}
					}
					return TryAddGlyphToTexture_Internal_Injected(glyphIndex, padding, packingMode, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount, renderMode, Object.MarshalledUnityObject.Marshal(texture), out glyph);
				}
			}
			freeGlyphRects2 = ref blittableArrayWrapper;
			freeGlyphRectCount2 = ref freeGlyphRectCount;
			if (usedGlyphRects != null)
			{
				array2 = usedGlyphRects;
				if (array2.Length != 0)
				{
					usedGlyphRects2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
				}
			}
			return TryAddGlyphToTexture_Internal_Injected(glyphIndex, padding, packingMode, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount, renderMode, Object.MarshalledUnityObject.Marshal(texture), out glyph);
		}
		finally
		{
			blittableArrayWrapper.Unmarshal(ref array);
			usedGlyphRects2.Unmarshal(ref array2);
		}
	}

	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static bool TryAddGlyphsToTexture(List<Glyph> glyphsToAdd, List<Glyph> glyphsAdded, int padding, GlyphPackingMode packingMode, List<GlyphRect> freeGlyphRects, List<GlyphRect> usedGlyphRects, GlyphRenderMode renderMode, Texture2D texture)
	{
		int num = 0;
		int glyphsToAddCount = glyphsToAdd.Count;
		int glyphsAddedCount = 0;
		if (s_GlyphMarshallingStruct_IN.Length < glyphsToAddCount || s_GlyphMarshallingStruct_OUT.Length < glyphsToAddCount)
		{
			int newSize = Mathf.NextPowerOfTwo(glyphsToAddCount + 1);
			if (s_GlyphMarshallingStruct_IN.Length < glyphsToAddCount)
			{
				Array.Resize(ref s_GlyphMarshallingStruct_IN, newSize);
			}
			if (s_GlyphMarshallingStruct_OUT.Length < glyphsToAddCount)
			{
				Array.Resize(ref s_GlyphMarshallingStruct_OUT, newSize);
			}
		}
		int freeGlyphRectCount = freeGlyphRects.Count;
		int usedGlyphRectCount = usedGlyphRects.Count;
		int num2 = freeGlyphRectCount + usedGlyphRectCount + glyphsToAddCount;
		if (s_FreeGlyphRects.Length < num2 || s_UsedGlyphRects.Length < num2)
		{
			int newSize2 = Mathf.NextPowerOfTwo(num2 + 1);
			if (s_FreeGlyphRects.Length < num2)
			{
				Array.Resize(ref s_FreeGlyphRects, newSize2);
			}
			if (s_UsedGlyphRects.Length < num2)
			{
				Array.Resize(ref s_UsedGlyphRects, newSize2);
			}
		}
		s_GlyphLookupDictionary.Clear();
		num = 0;
		bool flag = true;
		while (flag)
		{
			flag = false;
			if (num < glyphsToAddCount)
			{
				Glyph glyph = glyphsToAdd[num];
				s_GlyphMarshallingStruct_IN[num] = new GlyphMarshallingStruct(glyph);
				s_GlyphLookupDictionary.Add(glyph.index, glyph);
				flag = true;
			}
			if (num < freeGlyphRectCount)
			{
				s_FreeGlyphRects[num] = freeGlyphRects[num];
				flag = true;
			}
			if (num < usedGlyphRectCount)
			{
				s_UsedGlyphRects[num] = usedGlyphRects[num];
				flag = true;
			}
			num++;
		}
		bool result = TryAddGlyphsToTexture_Internal_MultiThread(s_GlyphMarshallingStruct_IN, ref glyphsToAddCount, s_GlyphMarshallingStruct_OUT, ref glyphsAddedCount, padding, packingMode, s_FreeGlyphRects, ref freeGlyphRectCount, s_UsedGlyphRects, ref usedGlyphRectCount, renderMode, texture);
		glyphsToAdd.Clear();
		glyphsAdded.Clear();
		freeGlyphRects.Clear();
		usedGlyphRects.Clear();
		num = 0;
		flag = true;
		while (flag)
		{
			flag = false;
			if (num < glyphsToAddCount)
			{
				uint index = s_GlyphMarshallingStruct_IN[num].index;
				glyphsToAdd.Add(s_GlyphLookupDictionary[index]);
				flag = true;
			}
			if (num < glyphsAddedCount)
			{
				uint index2 = s_GlyphMarshallingStruct_OUT[num].index;
				Glyph glyph2 = s_GlyphLookupDictionary[index2];
				glyph2.atlasIndex = s_GlyphMarshallingStruct_OUT[num].atlasIndex;
				glyph2.scale = s_GlyphMarshallingStruct_OUT[num].scale;
				glyph2.glyphRect = s_GlyphMarshallingStruct_OUT[num].glyphRect;
				glyph2.metrics = s_GlyphMarshallingStruct_OUT[num].metrics;
				glyphsAdded.Add(glyph2);
				flag = true;
			}
			if (num < freeGlyphRectCount)
			{
				freeGlyphRects.Add(s_FreeGlyphRects[num]);
				flag = true;
			}
			if (num < usedGlyphRectCount)
			{
				usedGlyphRects.Add(s_UsedGlyphRects[num]);
				flag = true;
			}
			num++;
		}
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::TryAddGlyphsToTexture", IsThreadSafe = true, IsFreeFunction = true)]
	private unsafe static bool TryAddGlyphsToTexture_Internal_MultiThread([Out] GlyphMarshallingStruct[] glyphsToAdd, ref int glyphsToAddCount, [Out] GlyphMarshallingStruct[] glyphsAdded, ref int glyphsAddedCount, int padding, GlyphPackingMode packingMode, [Out] GlyphRect[] freeGlyphRects, ref int freeGlyphRectCount, [Out] GlyphRect[] usedGlyphRects, ref int usedGlyphRectCount, GlyphRenderMode renderMode, Texture2D texture)
	{
		//The blocks IL_001b, IL_0022, IL_0026, IL_0028, IL_003a, IL_0046, IL_004d, IL_004f, IL_0063, IL_006c, IL_0073, IL_0075, IL_0089 are reachable both inside and outside the pinned region starting at IL_0004. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_003a, IL_0046, IL_004d, IL_004f, IL_0063, IL_006c, IL_0073, IL_0075, IL_0089 are reachable both inside and outside the pinned region starting at IL_0023. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0063, IL_006c, IL_0073, IL_0075, IL_0089 are reachable both inside and outside the pinned region starting at IL_0048. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0089 are reachable both inside and outside the pinned region starting at IL_006e. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper blittableArrayWrapper = default(BlittableArrayWrapper);
		BlittableArrayWrapper blittableArrayWrapper2 = default(BlittableArrayWrapper);
		BlittableArrayWrapper blittableArrayWrapper3 = default(BlittableArrayWrapper);
		BlittableArrayWrapper usedGlyphRects2 = default(BlittableArrayWrapper);
		try
		{
			ref BlittableArrayWrapper glyphsToAdd2;
			ref int glyphsToAddCount2;
			ref BlittableArrayWrapper glyphsAdded2;
			ref int glyphsAddedCount2;
			int padding2;
			GlyphPackingMode packingMode2;
			ref BlittableArrayWrapper freeGlyphRects2;
			ref int freeGlyphRectCount2;
			if (glyphsToAdd != null)
			{
				fixed (GlyphMarshallingStruct[] array = glyphsToAdd)
				{
					if (array.Length != 0)
					{
						blittableArrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					glyphsToAdd2 = ref blittableArrayWrapper;
					glyphsToAddCount2 = ref glyphsToAddCount;
					if (glyphsAdded != null)
					{
						fixed (GlyphMarshallingStruct[] array2 = glyphsAdded)
						{
							if (array2.Length != 0)
							{
								blittableArrayWrapper2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
							}
							glyphsAdded2 = ref blittableArrayWrapper2;
							glyphsAddedCount2 = ref glyphsAddedCount;
							padding2 = padding;
							packingMode2 = packingMode;
							if (freeGlyphRects != null)
							{
								fixed (GlyphRect[] array3 = freeGlyphRects)
								{
									if (array3.Length != 0)
									{
										blittableArrayWrapper3 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array3[0]), array3.Length);
									}
									freeGlyphRects2 = ref blittableArrayWrapper3;
									freeGlyphRectCount2 = ref freeGlyphRectCount;
									if (usedGlyphRects != null)
									{
										fixed (GlyphRect[] array4 = usedGlyphRects)
										{
											if (array4.Length != 0)
											{
												usedGlyphRects2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array4[0]), array4.Length);
											}
											return TryAddGlyphsToTexture_Internal_MultiThread_Injected(out glyphsToAdd2, ref glyphsToAddCount2, out glyphsAdded2, ref glyphsAddedCount2, padding2, packingMode2, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount, renderMode, Object.MarshalledUnityObject.Marshal(texture));
										}
									}
									return TryAddGlyphsToTexture_Internal_MultiThread_Injected(out glyphsToAdd2, ref glyphsToAddCount2, out glyphsAdded2, ref glyphsAddedCount2, padding2, packingMode2, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount, renderMode, Object.MarshalledUnityObject.Marshal(texture));
								}
							}
							freeGlyphRects2 = ref blittableArrayWrapper3;
							freeGlyphRectCount2 = ref freeGlyphRectCount;
							if (usedGlyphRects != null)
							{
								array4 = usedGlyphRects;
								if (array4.Length != 0)
								{
									usedGlyphRects2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array4[0]), array4.Length);
								}
							}
							return TryAddGlyphsToTexture_Internal_MultiThread_Injected(out glyphsToAdd2, ref glyphsToAddCount2, out glyphsAdded2, ref glyphsAddedCount2, padding2, packingMode2, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount, renderMode, Object.MarshalledUnityObject.Marshal(texture));
						}
					}
					glyphsAdded2 = ref blittableArrayWrapper2;
					glyphsAddedCount2 = ref glyphsAddedCount;
					padding2 = padding;
					packingMode2 = packingMode;
					if (freeGlyphRects != null)
					{
						array3 = freeGlyphRects;
						if (array3.Length != 0)
						{
							blittableArrayWrapper3 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array3[0]), array3.Length);
						}
					}
					freeGlyphRects2 = ref blittableArrayWrapper3;
					freeGlyphRectCount2 = ref freeGlyphRectCount;
					if (usedGlyphRects != null)
					{
						array4 = usedGlyphRects;
						if (array4.Length != 0)
						{
							usedGlyphRects2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array4[0]), array4.Length);
						}
					}
					return TryAddGlyphsToTexture_Internal_MultiThread_Injected(out glyphsToAdd2, ref glyphsToAddCount2, out glyphsAdded2, ref glyphsAddedCount2, padding2, packingMode2, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount, renderMode, Object.MarshalledUnityObject.Marshal(texture));
				}
			}
			glyphsToAdd2 = ref blittableArrayWrapper;
			glyphsToAddCount2 = ref glyphsToAddCount;
			if (glyphsAdded != null)
			{
				array2 = glyphsAdded;
				if (array2.Length != 0)
				{
					blittableArrayWrapper2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
				}
			}
			glyphsAdded2 = ref blittableArrayWrapper2;
			glyphsAddedCount2 = ref glyphsAddedCount;
			padding2 = padding;
			packingMode2 = packingMode;
			if (freeGlyphRects != null)
			{
				array3 = freeGlyphRects;
				if (array3.Length != 0)
				{
					blittableArrayWrapper3 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array3[0]), array3.Length);
				}
			}
			freeGlyphRects2 = ref blittableArrayWrapper3;
			freeGlyphRectCount2 = ref freeGlyphRectCount;
			if (usedGlyphRects != null)
			{
				array4 = usedGlyphRects;
				if (array4.Length != 0)
				{
					usedGlyphRects2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array4[0]), array4.Length);
				}
			}
			return TryAddGlyphsToTexture_Internal_MultiThread_Injected(out glyphsToAdd2, ref glyphsToAddCount2, out glyphsAdded2, ref glyphsAddedCount2, padding2, packingMode2, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount, renderMode, Object.MarshalledUnityObject.Marshal(texture));
		}
		finally
		{
			blittableArrayWrapper.Unmarshal(ref array);
			blittableArrayWrapper2.Unmarshal(ref array2);
			blittableArrayWrapper3.Unmarshal(ref array3);
			usedGlyphRects2.Unmarshal(ref array4);
		}
	}

	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static bool TryAddGlyphsToTexture(List<uint> glyphIndexes, int padding, GlyphPackingMode packingMode, List<GlyphRect> freeGlyphRects, List<GlyphRect> usedGlyphRects, GlyphRenderMode renderMode, Texture2D texture, out Glyph[] glyphs)
	{
		glyphs = null;
		if (glyphIndexes == null || glyphIndexes.Count == 0)
		{
			return false;
		}
		int glyphCount = glyphIndexes.Count;
		if (s_GlyphIndexes_MarshallingArray_A == null || s_GlyphIndexes_MarshallingArray_A.Length < glyphCount)
		{
			s_GlyphIndexes_MarshallingArray_A = new uint[Mathf.NextPowerOfTwo(glyphCount + 1)];
		}
		int freeGlyphRectCount = freeGlyphRects.Count;
		int usedGlyphRectCount = usedGlyphRects.Count;
		int num = freeGlyphRectCount + usedGlyphRectCount + glyphCount;
		if (s_FreeGlyphRects.Length < num || s_UsedGlyphRects.Length < num)
		{
			int num2 = Mathf.NextPowerOfTwo(num + 1);
			s_FreeGlyphRects = new GlyphRect[num2];
			s_UsedGlyphRects = new GlyphRect[num2];
		}
		if (s_GlyphMarshallingStruct_OUT.Length < glyphCount)
		{
			int num3 = Mathf.NextPowerOfTwo(glyphCount + 1);
			s_GlyphMarshallingStruct_OUT = new GlyphMarshallingStruct[num3];
		}
		int num4 = FontEngineUtilities.MaxValue(freeGlyphRectCount, usedGlyphRectCount, glyphCount);
		for (int i = 0; i < num4; i++)
		{
			if (i < glyphCount)
			{
				s_GlyphIndexes_MarshallingArray_A[i] = glyphIndexes[i];
			}
			if (i < freeGlyphRectCount)
			{
				s_FreeGlyphRects[i] = freeGlyphRects[i];
			}
			if (i < usedGlyphRectCount)
			{
				s_UsedGlyphRects[i] = usedGlyphRects[i];
			}
		}
		bool result = TryAddGlyphsToTexture_Internal(s_GlyphIndexes_MarshallingArray_A, padding, packingMode, s_FreeGlyphRects, ref freeGlyphRectCount, s_UsedGlyphRects, ref usedGlyphRectCount, renderMode, texture, s_GlyphMarshallingStruct_OUT, ref glyphCount);
		if (s_Glyphs == null || s_Glyphs.Length <= glyphCount)
		{
			s_Glyphs = new Glyph[Mathf.NextPowerOfTwo(glyphCount + 1)];
		}
		s_Glyphs[glyphCount] = null;
		freeGlyphRects.Clear();
		usedGlyphRects.Clear();
		num4 = FontEngineUtilities.MaxValue(freeGlyphRectCount, usedGlyphRectCount, glyphCount);
		for (int j = 0; j < num4; j++)
		{
			if (j < glyphCount)
			{
				s_Glyphs[j] = new Glyph(s_GlyphMarshallingStruct_OUT[j]);
			}
			if (j < freeGlyphRectCount)
			{
				freeGlyphRects.Add(s_FreeGlyphRects[j]);
			}
			if (j < usedGlyphRectCount)
			{
				usedGlyphRects.Add(s_UsedGlyphRects[j]);
			}
		}
		glyphs = s_Glyphs;
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::TryAddGlyphsToTexture", IsThreadSafe = true, IsFreeFunction = true)]
	private unsafe static bool TryAddGlyphsToTexture_Internal(uint[] glyphIndex, int padding, GlyphPackingMode packingMode, [Out] GlyphRect[] freeGlyphRects, ref int freeGlyphRectCount, [Out] GlyphRect[] usedGlyphRects, ref int usedGlyphRectCount, GlyphRenderMode renderMode, Texture2D texture, [Out] GlyphMarshallingStruct[] glyphs, ref int glyphCount)
	{
		//The blocks IL_0044, IL_004d, IL_0054, IL_0056, IL_006a, IL_007c, IL_0083, IL_0085, IL_0099 are reachable both inside and outside the pinned region starting at IL_0029. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_006a, IL_007c, IL_0083, IL_0085, IL_0099 are reachable both inside and outside the pinned region starting at IL_004f. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0099 are reachable both inside and outside the pinned region starting at IL_007e. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper blittableArrayWrapper = default(BlittableArrayWrapper);
		BlittableArrayWrapper blittableArrayWrapper2 = default(BlittableArrayWrapper);
		BlittableArrayWrapper glyphs2 = default(BlittableArrayWrapper);
		try
		{
			Span<uint> span = new Span<uint>(glyphIndex);
			fixed (uint* begin = span)
			{
				ManagedSpanWrapper glyphIndex2 = new ManagedSpanWrapper(begin, span.Length);
				ref BlittableArrayWrapper freeGlyphRects2;
				ref int freeGlyphRectCount2;
				ref BlittableArrayWrapper usedGlyphRects2;
				ref int usedGlyphRectCount2;
				GlyphRenderMode renderMode2;
				IntPtr texture2;
				if (freeGlyphRects != null)
				{
					fixed (GlyphRect[] array = freeGlyphRects)
					{
						if (array.Length != 0)
						{
							blittableArrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						freeGlyphRects2 = ref blittableArrayWrapper;
						freeGlyphRectCount2 = ref freeGlyphRectCount;
						if (usedGlyphRects != null)
						{
							fixed (GlyphRect[] array2 = usedGlyphRects)
							{
								if (array2.Length != 0)
								{
									blittableArrayWrapper2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
								}
								usedGlyphRects2 = ref blittableArrayWrapper2;
								usedGlyphRectCount2 = ref usedGlyphRectCount;
								renderMode2 = renderMode;
								texture2 = Object.MarshalledUnityObject.Marshal(texture);
								if (glyphs != null)
								{
									fixed (GlyphMarshallingStruct[] array3 = glyphs)
									{
										if (array3.Length != 0)
										{
											glyphs2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array3[0]), array3.Length);
										}
										return TryAddGlyphsToTexture_Internal_Injected(ref glyphIndex2, padding, packingMode, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount2, renderMode2, texture2, out glyphs2, ref glyphCount);
									}
								}
								return TryAddGlyphsToTexture_Internal_Injected(ref glyphIndex2, padding, packingMode, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount2, renderMode2, texture2, out glyphs2, ref glyphCount);
							}
						}
						usedGlyphRects2 = ref blittableArrayWrapper2;
						usedGlyphRectCount2 = ref usedGlyphRectCount;
						renderMode2 = renderMode;
						texture2 = Object.MarshalledUnityObject.Marshal(texture);
						if (glyphs != null)
						{
							array3 = glyphs;
							if (array3.Length != 0)
							{
								glyphs2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array3[0]), array3.Length);
							}
						}
						return TryAddGlyphsToTexture_Internal_Injected(ref glyphIndex2, padding, packingMode, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount2, renderMode2, texture2, out glyphs2, ref glyphCount);
					}
				}
				freeGlyphRects2 = ref blittableArrayWrapper;
				freeGlyphRectCount2 = ref freeGlyphRectCount;
				if (usedGlyphRects != null)
				{
					array2 = usedGlyphRects;
					if (array2.Length != 0)
					{
						blittableArrayWrapper2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
					}
				}
				usedGlyphRects2 = ref blittableArrayWrapper2;
				usedGlyphRectCount2 = ref usedGlyphRectCount;
				renderMode2 = renderMode;
				texture2 = Object.MarshalledUnityObject.Marshal(texture);
				if (glyphs != null)
				{
					array3 = glyphs;
					if (array3.Length != 0)
					{
						glyphs2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array3[0]), array3.Length);
					}
				}
				return TryAddGlyphsToTexture_Internal_Injected(ref glyphIndex2, padding, packingMode, out freeGlyphRects2, ref freeGlyphRectCount2, out usedGlyphRects2, ref usedGlyphRectCount2, renderMode2, texture2, out glyphs2, ref glyphCount);
			}
		}
		finally
		{
			blittableArrayWrapper.Unmarshal(ref array);
			blittableArrayWrapper2.Unmarshal(ref array2);
			glyphs2.Unmarshal(ref array3);
		}
	}

	[NativeMethod(Name = "TextCore::FontEngine::GetOpenTypeLayoutTable", IsFreeFunction = true)]
	internal static OTL_Table GetOpenTypeLayoutTable(OTL_TableType type)
	{
		GetOpenTypeLayoutTable_Injected(type, out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::GetOpenTypeLayoutScripts", IsFreeFunction = true)]
	internal static extern OTL_Script[] GetOpenTypeLayoutScripts();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::GetOpenTypeLayoutFeatures", IsFreeFunction = true)]
	internal static extern OTL_Feature[] GetOpenTypeLayoutFeatures();

	[NativeMethod(Name = "TextCore::FontEngine::GetOpenTypeLayoutLookups", IsFreeFunction = true)]
	internal static OTL_Lookup[] GetOpenTypeLayoutLookups()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		OTL_Lookup[] result;
		try
		{
			GetOpenTypeLayoutLookups_Injected(out ret);
		}
		finally
		{
			OTL_Lookup[] array = default(OTL_Lookup[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	internal static OpenTypeFeature[] GetOpenTypeFontFeatureList()
	{
		throw new NotImplementedException();
	}

	[NativeMethod(Name = "TextCore::FontEngine::GetAllSingleSubstitutionRecords", IsThreadSafe = true, IsFreeFunction = true)]
	internal static SingleSubstitutionRecord[] GetAllSingleSubstitutionRecords()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		SingleSubstitutionRecord[] result;
		try
		{
			GetAllSingleSubstitutionRecords_Injected(out ret);
		}
		finally
		{
			SingleSubstitutionRecord[] array = default(SingleSubstitutionRecord[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	internal static SingleSubstitutionRecord[] GetSingleSubstitutionRecords(int lookupIndex, uint glyphIndex)
	{
		GlyphIndexToMarshallingArray(glyphIndex, ref s_GlyphIndexes_MarshallingArray_A);
		return GetSingleSubstitutionRecords(lookupIndex, s_GlyphIndexes_MarshallingArray_A);
	}

	internal static SingleSubstitutionRecord[] GetSingleSubstitutionRecords(int lookupIndex, List<uint> glyphIndexes)
	{
		GenericListToMarshallingArray(ref glyphIndexes, ref s_GlyphIndexes_MarshallingArray_A);
		return GetSingleSubstitutionRecords(lookupIndex, s_GlyphIndexes_MarshallingArray_A);
	}

	private static SingleSubstitutionRecord[] GetSingleSubstitutionRecords(int lookupIndex, uint[] glyphIndexes)
	{
		PopulateSingleSubstitutionRecordMarshallingArray_from_GlyphIndexes(glyphIndexes, lookupIndex, out var recordCount);
		if (recordCount == 0)
		{
			return null;
		}
		SetMarshallingArraySize(ref s_SingleSubstitutionRecords_MarshallingArray, recordCount);
		GetSingleSubstitutionRecordsFromMarshallingArray(MemoryExtensions.AsSpan(s_SingleSubstitutionRecords_MarshallingArray));
		s_SingleSubstitutionRecords_MarshallingArray[recordCount] = default(SingleSubstitutionRecord);
		return s_SingleSubstitutionRecords_MarshallingArray;
	}

	[NativeMethod(Name = "TextCore::FontEngine::PopulateSingleSubstitutionRecordMarshallingArray", IsFreeFunction = true)]
	private unsafe static int PopulateSingleSubstitutionRecordMarshallingArray_from_GlyphIndexes(uint[] glyphIndexes, int lookupIndex, out int recordCount)
	{
		Span<uint> span = new Span<uint>(glyphIndexes);
		int result;
		fixed (uint* begin = span)
		{
			ManagedSpanWrapper glyphIndexes2 = new ManagedSpanWrapper(begin, span.Length);
			result = PopulateSingleSubstitutionRecordMarshallingArray_from_GlyphIndexes_Injected(ref glyphIndexes2, lookupIndex, out recordCount);
		}
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::GetSingleSubstitutionRecordsFromMarshallingArray", IsFreeFunction = true)]
	private unsafe static int GetSingleSubstitutionRecordsFromMarshallingArray(Span<SingleSubstitutionRecord> singleSubstitutionRecords)
	{
		Span<SingleSubstitutionRecord> span = singleSubstitutionRecords;
		int singleSubstitutionRecordsFromMarshallingArray_Injected;
		fixed (SingleSubstitutionRecord* begin = span)
		{
			ManagedSpanWrapper singleSubstitutionRecords2 = new ManagedSpanWrapper(begin, span.Length);
			singleSubstitutionRecordsFromMarshallingArray_Injected = GetSingleSubstitutionRecordsFromMarshallingArray_Injected(ref singleSubstitutionRecords2);
		}
		return singleSubstitutionRecordsFromMarshallingArray_Injected;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::GetAllMultipleSubstitutionRecords", IsThreadSafe = true, IsFreeFunction = true)]
	internal static extern MultipleSubstitutionRecord[] GetAllMultipleSubstitutionRecords();

	internal static MultipleSubstitutionRecord[] GetMultipleSubstitutionRecords(int lookupIndex, uint glyphIndex)
	{
		GlyphIndexToMarshallingArray(glyphIndex, ref s_GlyphIndexes_MarshallingArray_A);
		return GetMultipleSubstitutionRecords(lookupIndex, s_GlyphIndexes_MarshallingArray_A);
	}

	internal static MultipleSubstitutionRecord[] GetMultipleSubstitutionRecords(int lookupIndex, List<uint> glyphIndexes)
	{
		GenericListToMarshallingArray(ref glyphIndexes, ref s_GlyphIndexes_MarshallingArray_A);
		return GetMultipleSubstitutionRecords(lookupIndex, s_GlyphIndexes_MarshallingArray_A);
	}

	private static MultipleSubstitutionRecord[] GetMultipleSubstitutionRecords(int lookupIndex, uint[] glyphIndexes)
	{
		PopulateMultipleSubstitutionRecordMarshallingArray_from_GlyphIndexes(glyphIndexes, lookupIndex, out var recordCount);
		if (recordCount == 0)
		{
			return null;
		}
		SetMarshallingArraySize(ref s_MultipleSubstitutionRecords_MarshallingArray, recordCount);
		GetMultipleSubstitutionRecordsFromMarshallingArray(s_MultipleSubstitutionRecords_MarshallingArray);
		s_MultipleSubstitutionRecords_MarshallingArray[recordCount] = default(MultipleSubstitutionRecord);
		return s_MultipleSubstitutionRecords_MarshallingArray;
	}

	[NativeMethod(Name = "TextCore::FontEngine::PopulateMultipleSubstitutionRecordMarshallingArray", IsFreeFunction = true)]
	private unsafe static int PopulateMultipleSubstitutionRecordMarshallingArray_from_GlyphIndexes(uint[] glyphIndexes, int lookupIndex, out int recordCount)
	{
		Span<uint> span = new Span<uint>(glyphIndexes);
		int result;
		fixed (uint* begin = span)
		{
			ManagedSpanWrapper glyphIndexes2 = new ManagedSpanWrapper(begin, span.Length);
			result = PopulateMultipleSubstitutionRecordMarshallingArray_from_GlyphIndexes_Injected(ref glyphIndexes2, lookupIndex, out recordCount);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::GetMultipleSubstitutionRecordsFromMarshallingArray", IsFreeFunction = true)]
	private static extern int GetMultipleSubstitutionRecordsFromMarshallingArray([Out] MultipleSubstitutionRecord[] substitutionRecords);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::GetAllAlternateSubstitutionRecords", IsThreadSafe = true, IsFreeFunction = true)]
	internal static extern AlternateSubstitutionRecord[] GetAllAlternateSubstitutionRecords();

	internal static AlternateSubstitutionRecord[] GetAlternateSubstitutionRecords(int lookupIndex, uint glyphIndex)
	{
		GlyphIndexToMarshallingArray(glyphIndex, ref s_GlyphIndexes_MarshallingArray_A);
		return GetAlternateSubstitutionRecords(lookupIndex, s_GlyphIndexes_MarshallingArray_A);
	}

	internal static AlternateSubstitutionRecord[] GetAlternateSubstitutionRecords(int lookupIndex, List<uint> glyphIndexes)
	{
		GenericListToMarshallingArray(ref glyphIndexes, ref s_GlyphIndexes_MarshallingArray_A);
		return GetAlternateSubstitutionRecords(lookupIndex, s_GlyphIndexes_MarshallingArray_A);
	}

	private static AlternateSubstitutionRecord[] GetAlternateSubstitutionRecords(int lookupIndex, uint[] glyphIndexes)
	{
		PopulateAlternateSubstitutionRecordMarshallingArray_from_GlyphIndexes(glyphIndexes, lookupIndex, out var recordCount);
		if (recordCount == 0)
		{
			return null;
		}
		SetMarshallingArraySize(ref s_AlternateSubstitutionRecords_MarshallingArray, recordCount);
		GetAlternateSubstitutionRecordsFromMarshallingArray(s_AlternateSubstitutionRecords_MarshallingArray);
		s_AlternateSubstitutionRecords_MarshallingArray[recordCount] = default(AlternateSubstitutionRecord);
		return s_AlternateSubstitutionRecords_MarshallingArray;
	}

	[NativeMethod(Name = "TextCore::FontEngine::PopulateAlternateSubstitutionRecordMarshallingArray", IsFreeFunction = true)]
	private unsafe static int PopulateAlternateSubstitutionRecordMarshallingArray_from_GlyphIndexes(uint[] glyphIndexes, int lookupIndex, out int recordCount)
	{
		Span<uint> span = new Span<uint>(glyphIndexes);
		int result;
		fixed (uint* begin = span)
		{
			ManagedSpanWrapper glyphIndexes2 = new ManagedSpanWrapper(begin, span.Length);
			result = PopulateAlternateSubstitutionRecordMarshallingArray_from_GlyphIndexes_Injected(ref glyphIndexes2, lookupIndex, out recordCount);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::GetAlternateSubstitutionRecordsFromMarshallingArray", IsFreeFunction = true)]
	private static extern int GetAlternateSubstitutionRecordsFromMarshallingArray([Out] AlternateSubstitutionRecord[] singleSubstitutionRecords);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	[NativeMethod(Name = "TextCore::FontEngine::GetAllLigatureSubstitutionRecords", IsThreadSafe = true, IsFreeFunction = true)]
	internal static extern LigatureSubstitutionRecord[] GetAllLigatureSubstitutionRecords();

	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static LigatureSubstitutionRecord[] GetLigatureSubstitutionRecords(uint glyphIndex)
	{
		GlyphIndexToMarshallingArray(glyphIndex, ref s_GlyphIndexes_MarshallingArray_A);
		return GetLigatureSubstitutionRecords(s_GlyphIndexes_MarshallingArray_A);
	}

	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static LigatureSubstitutionRecord[] GetLigatureSubstitutionRecords(List<uint> glyphIndexes)
	{
		GenericListToMarshallingArray(ref glyphIndexes, ref s_GlyphIndexes_MarshallingArray_A);
		return GetLigatureSubstitutionRecords(s_GlyphIndexes_MarshallingArray_A);
	}

	internal static LigatureSubstitutionRecord[] GetLigatureSubstitutionRecords(int lookupIndex, uint glyphIndex)
	{
		GlyphIndexToMarshallingArray(glyphIndex, ref s_GlyphIndexes_MarshallingArray_A);
		return GetLigatureSubstitutionRecords(lookupIndex, s_GlyphIndexes_MarshallingArray_A);
	}

	internal static LigatureSubstitutionRecord[] GetLigatureSubstitutionRecords(int lookupIndex, List<uint> glyphIndexes)
	{
		GenericListToMarshallingArray(ref glyphIndexes, ref s_GlyphIndexes_MarshallingArray_A);
		return GetLigatureSubstitutionRecords(lookupIndex, s_GlyphIndexes_MarshallingArray_A);
	}

	private static LigatureSubstitutionRecord[] GetLigatureSubstitutionRecords(uint[] glyphIndexes)
	{
		PopulateLigatureSubstitutionRecordMarshallingArray(glyphIndexes, out var recordCount);
		if (recordCount == 0)
		{
			return null;
		}
		SetMarshallingArraySize(ref s_LigatureSubstitutionRecords_MarshallingArray, recordCount);
		GetLigatureSubstitutionRecordsFromMarshallingArray(s_LigatureSubstitutionRecords_MarshallingArray);
		s_LigatureSubstitutionRecords_MarshallingArray[recordCount] = default(LigatureSubstitutionRecord);
		return s_LigatureSubstitutionRecords_MarshallingArray;
	}

	private static LigatureSubstitutionRecord[] GetLigatureSubstitutionRecords(int lookupIndex, uint[] glyphIndexes)
	{
		PopulateLigatureSubstitutionRecordMarshallingArray_for_LookupIndex(glyphIndexes, lookupIndex, out var recordCount);
		if (recordCount == 0)
		{
			return null;
		}
		SetMarshallingArraySize(ref s_LigatureSubstitutionRecords_MarshallingArray, recordCount);
		GetLigatureSubstitutionRecordsFromMarshallingArray(s_LigatureSubstitutionRecords_MarshallingArray);
		s_LigatureSubstitutionRecords_MarshallingArray[recordCount] = default(LigatureSubstitutionRecord);
		return s_LigatureSubstitutionRecords_MarshallingArray;
	}

	[NativeMethod(Name = "TextCore::FontEngine::PopulateLigatureSubstitutionRecordMarshallingArray", IsFreeFunction = true)]
	private unsafe static int PopulateLigatureSubstitutionRecordMarshallingArray(uint[] glyphIndexes, out int recordCount)
	{
		Span<uint> span = new Span<uint>(glyphIndexes);
		int result;
		fixed (uint* begin = span)
		{
			ManagedSpanWrapper glyphIndexes2 = new ManagedSpanWrapper(begin, span.Length);
			result = PopulateLigatureSubstitutionRecordMarshallingArray_Injected(ref glyphIndexes2, out recordCount);
		}
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::PopulateLigatureSubstitutionRecordMarshallingArray", IsFreeFunction = true)]
	private unsafe static int PopulateLigatureSubstitutionRecordMarshallingArray_for_LookupIndex(uint[] glyphIndexes, int lookupIndex, out int recordCount)
	{
		Span<uint> span = new Span<uint>(glyphIndexes);
		int result;
		fixed (uint* begin = span)
		{
			ManagedSpanWrapper glyphIndexes2 = new ManagedSpanWrapper(begin, span.Length);
			result = PopulateLigatureSubstitutionRecordMarshallingArray_for_LookupIndex_Injected(ref glyphIndexes2, lookupIndex, out recordCount);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::GetLigatureSubstitutionRecordsFromMarshallingArray", IsFreeFunction = true)]
	private static extern int GetLigatureSubstitutionRecordsFromMarshallingArray([Out] LigatureSubstitutionRecord[] ligatureSubstitutionRecords);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::GetAllContextualSubstitutionRecords", IsThreadSafe = true, IsFreeFunction = true)]
	internal static extern ContextualSubstitutionRecord[] GetAllContextualSubstitutionRecords();

	internal static ContextualSubstitutionRecord[] GetContextualSubstitutionRecords(int lookupIndex, uint glyphIndex)
	{
		GlyphIndexToMarshallingArray(glyphIndex, ref s_GlyphIndexes_MarshallingArray_A);
		return GetContextualSubstitutionRecords(lookupIndex, s_GlyphIndexes_MarshallingArray_A);
	}

	internal static ContextualSubstitutionRecord[] GetContextualSubstitutionRecords(int lookupIndex, List<uint> glyphIndexes)
	{
		GenericListToMarshallingArray(ref glyphIndexes, ref s_GlyphIndexes_MarshallingArray_A);
		return GetContextualSubstitutionRecords(lookupIndex, s_GlyphIndexes_MarshallingArray_A);
	}

	private static ContextualSubstitutionRecord[] GetContextualSubstitutionRecords(int lookupIndex, uint[] glyphIndexes)
	{
		PopulateContextualSubstitutionRecordMarshallingArray_from_GlyphIndexes(glyphIndexes, lookupIndex, out var recordCount);
		if (recordCount == 0)
		{
			return null;
		}
		SetMarshallingArraySize(ref s_ContextualSubstitutionRecords_MarshallingArray, recordCount);
		GetContextualSubstitutionRecordsFromMarshallingArray(s_ContextualSubstitutionRecords_MarshallingArray);
		s_ContextualSubstitutionRecords_MarshallingArray[recordCount] = default(ContextualSubstitutionRecord);
		return s_ContextualSubstitutionRecords_MarshallingArray;
	}

	[NativeMethod(Name = "TextCore::FontEngine::PopulateContextualSubstitutionRecordMarshallingArray", IsFreeFunction = true)]
	private unsafe static int PopulateContextualSubstitutionRecordMarshallingArray_from_GlyphIndexes(uint[] glyphIndexes, int lookupIndex, out int recordCount)
	{
		Span<uint> span = new Span<uint>(glyphIndexes);
		int result;
		fixed (uint* begin = span)
		{
			ManagedSpanWrapper glyphIndexes2 = new ManagedSpanWrapper(begin, span.Length);
			result = PopulateContextualSubstitutionRecordMarshallingArray_from_GlyphIndexes_Injected(ref glyphIndexes2, lookupIndex, out recordCount);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::GetContextualSubstitutionRecordsFromMarshallingArray", IsFreeFunction = true)]
	private static extern int GetContextualSubstitutionRecordsFromMarshallingArray([Out] ContextualSubstitutionRecord[] substitutionRecords);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::GetAllChainingContextualSubstitutionRecords", IsThreadSafe = true, IsFreeFunction = true)]
	internal static extern ChainingContextualSubstitutionRecord[] GetAllChainingContextualSubstitutionRecords();

	internal static ChainingContextualSubstitutionRecord[] GetChainingContextualSubstitutionRecords(int lookupIndex, uint glyphIndex)
	{
		GlyphIndexToMarshallingArray(glyphIndex, ref s_GlyphIndexes_MarshallingArray_A);
		return GetChainingContextualSubstitutionRecords(lookupIndex, s_GlyphIndexes_MarshallingArray_A);
	}

	internal static ChainingContextualSubstitutionRecord[] GetChainingContextualSubstitutionRecords(int lookupIndex, List<uint> glyphIndexes)
	{
		GenericListToMarshallingArray(ref glyphIndexes, ref s_GlyphIndexes_MarshallingArray_A);
		return GetChainingContextualSubstitutionRecords(lookupIndex, s_GlyphIndexes_MarshallingArray_A);
	}

	private static ChainingContextualSubstitutionRecord[] GetChainingContextualSubstitutionRecords(int lookupIndex, uint[] glyphIndexes)
	{
		PopulateChainingContextualSubstitutionRecordMarshallingArray_from_GlyphIndexes(glyphIndexes, lookupIndex, out var recordCount);
		if (recordCount == 0)
		{
			return null;
		}
		SetMarshallingArraySize(ref s_ChainingContextualSubstitutionRecords_MarshallingArray, recordCount);
		GetChainingContextualSubstitutionRecordsFromMarshallingArray(s_ChainingContextualSubstitutionRecords_MarshallingArray);
		s_ChainingContextualSubstitutionRecords_MarshallingArray[recordCount] = default(ChainingContextualSubstitutionRecord);
		return s_ChainingContextualSubstitutionRecords_MarshallingArray;
	}

	[NativeMethod(Name = "TextCore::FontEngine::PopulateChainingContextualSubstitutionRecordMarshallingArray", IsFreeFunction = true)]
	private unsafe static int PopulateChainingContextualSubstitutionRecordMarshallingArray_from_GlyphIndexes(uint[] glyphIndexes, int lookupIndex, out int recordCount)
	{
		Span<uint> span = new Span<uint>(glyphIndexes);
		int result;
		fixed (uint* begin = span)
		{
			ManagedSpanWrapper glyphIndexes2 = new ManagedSpanWrapper(begin, span.Length);
			result = PopulateChainingContextualSubstitutionRecordMarshallingArray_from_GlyphIndexes_Injected(ref glyphIndexes2, lookupIndex, out recordCount);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::GetChainingContextualSubstitutionRecordsFromMarshallingArray", IsFreeFunction = true)]
	private static extern int GetChainingContextualSubstitutionRecordsFromMarshallingArray([Out] ChainingContextualSubstitutionRecord[] substitutionRecords);

	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static GlyphPairAdjustmentRecord[] GetGlyphPairAdjustmentTable(uint[] glyphIndexes)
	{
		PopulatePairAdjustmentRecordMarshallingArray_from_KernTable(glyphIndexes, out var recordCount);
		if (recordCount == 0)
		{
			return null;
		}
		SetMarshallingArraySize(ref s_PairAdjustmentRecords_MarshallingArray, recordCount);
		GetPairAdjustmentRecordsFromMarshallingArray(s_PairAdjustmentRecords_MarshallingArray);
		s_PairAdjustmentRecords_MarshallingArray[recordCount] = default(GlyphPairAdjustmentRecord);
		return s_PairAdjustmentRecords_MarshallingArray;
	}

	internal static GlyphPairAdjustmentRecord[] GetGlyphPairAdjustmentRecords(List<uint> glyphIndexes, out int recordCount)
	{
		GenericListToMarshallingArray(ref glyphIndexes, ref s_GlyphIndexes_MarshallingArray_A);
		PopulatePairAdjustmentRecordMarshallingArray_from_KernTable(s_GlyphIndexes_MarshallingArray_A, out recordCount);
		if (recordCount == 0)
		{
			return null;
		}
		SetMarshallingArraySize(ref s_PairAdjustmentRecords_MarshallingArray, recordCount);
		GetPairAdjustmentRecordsFromMarshallingArray(s_PairAdjustmentRecords_MarshallingArray);
		s_PairAdjustmentRecords_MarshallingArray[recordCount] = default(GlyphPairAdjustmentRecord);
		return s_PairAdjustmentRecords_MarshallingArray;
	}

	[NativeMethod(Name = "TextCore::FontEngine::PopulatePairAdjustmentRecordMarshallingArrayFromKernTable", IsFreeFunction = true)]
	private unsafe static int PopulatePairAdjustmentRecordMarshallingArray_from_KernTable(uint[] glyphIndexes, out int recordCount)
	{
		Span<uint> span = new Span<uint>(glyphIndexes);
		int result;
		fixed (uint* begin = span)
		{
			ManagedSpanWrapper glyphIndexes2 = new ManagedSpanWrapper(begin, span.Length);
			result = PopulatePairAdjustmentRecordMarshallingArray_from_KernTable_Injected(ref glyphIndexes2, out recordCount);
		}
		return result;
	}

	internal static GlyphPairAdjustmentRecord[] GetGlyphPairAdjustmentRecords(uint glyphIndex, out int recordCount)
	{
		PopulatePairAdjustmentRecordMarshallingArray_from_GlyphIndex(glyphIndex, out recordCount);
		if (recordCount == 0)
		{
			return null;
		}
		SetMarshallingArraySize(ref s_PairAdjustmentRecords_MarshallingArray, recordCount);
		GetPairAdjustmentRecordsFromMarshallingArray(s_PairAdjustmentRecords_MarshallingArray);
		s_PairAdjustmentRecords_MarshallingArray[recordCount] = default(GlyphPairAdjustmentRecord);
		return s_PairAdjustmentRecords_MarshallingArray;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "TextCore::FontEngine::PopulatePairAdjustmentRecordMarshallingArrayFromKernTable", IsFreeFunction = true)]
	private static extern int PopulatePairAdjustmentRecordMarshallingArray_from_GlyphIndex(uint glyphIndex, out int recordCount);

	internal static GlyphPairAdjustmentRecord[] GetGlyphPairAdjustmentRecords(List<uint> newGlyphIndexes, List<uint> allGlyphIndexes)
	{
		GenericListToMarshallingArray(ref newGlyphIndexes, ref s_GlyphIndexes_MarshallingArray_A);
		GenericListToMarshallingArray(ref allGlyphIndexes, ref s_GlyphIndexes_MarshallingArray_B);
		PopulatePairAdjustmentRecordMarshallingArray_for_NewlyAddedGlyphIndexes(s_GlyphIndexes_MarshallingArray_A, s_GlyphIndexes_MarshallingArray_B, out var recordCount);
		if (recordCount == 0)
		{
			return null;
		}
		SetMarshallingArraySize(ref s_PairAdjustmentRecords_MarshallingArray, recordCount);
		GetPairAdjustmentRecordsFromMarshallingArray(s_PairAdjustmentRecords_MarshallingArray);
		s_PairAdjustmentRecords_MarshallingArray[recordCount] = default(GlyphPairAdjustmentRecord);
		return s_PairAdjustmentRecords_MarshallingArray;
	}

	[NativeMethod(Name = "TextCore::FontEngine::PopulatePairAdjustmentRecordMarshallingArrayFromKernTable", IsFreeFunction = true)]
	private unsafe static int PopulatePairAdjustmentRecordMarshallingArray_for_NewlyAddedGlyphIndexes(uint[] newGlyphIndexes, uint[] allGlyphIndexes, out int recordCount)
	{
		Span<uint> span = new Span<uint>(newGlyphIndexes);
		int result;
		fixed (uint* begin = span)
		{
			ManagedSpanWrapper newGlyphIndexes2 = new ManagedSpanWrapper(begin, span.Length);
			Span<uint> span2 = new Span<uint>(allGlyphIndexes);
			fixed (uint* begin2 = span2)
			{
				ManagedSpanWrapper allGlyphIndexes2 = new ManagedSpanWrapper(begin2, span2.Length);
				result = PopulatePairAdjustmentRecordMarshallingArray_for_NewlyAddedGlyphIndexes_Injected(ref newGlyphIndexes2, ref allGlyphIndexes2, out recordCount);
			}
		}
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::GetGlyphPairAdjustmentRecord", IsFreeFunction = true)]
	internal static GlyphPairAdjustmentRecord GetGlyphPairAdjustmentRecord(uint firstGlyphIndex, uint secondGlyphIndex)
	{
		GetGlyphPairAdjustmentRecord_Injected(firstGlyphIndex, secondGlyphIndex, out var ret);
		return ret;
	}

	internal static GlyphAdjustmentRecord[] GetSingleAdjustmentRecords(int lookupIndex, uint glyphIndex)
	{
		if (s_GlyphIndexes_MarshallingArray_A == null)
		{
			s_GlyphIndexes_MarshallingArray_A = new uint[8];
		}
		s_GlyphIndexes_MarshallingArray_A[0] = glyphIndex;
		s_GlyphIndexes_MarshallingArray_A[1] = 0u;
		return GetSingleAdjustmentRecords(lookupIndex, s_GlyphIndexes_MarshallingArray_A);
	}

	internal static GlyphAdjustmentRecord[] GetSingleAdjustmentRecords(int lookupIndex, List<uint> glyphIndexes)
	{
		GenericListToMarshallingArray(ref glyphIndexes, ref s_GlyphIndexes_MarshallingArray_A);
		return GetSingleAdjustmentRecords(lookupIndex, s_GlyphIndexes_MarshallingArray_A);
	}

	private static GlyphAdjustmentRecord[] GetSingleAdjustmentRecords(int lookupIndex, uint[] glyphIndexes)
	{
		PopulateSingleAdjustmentRecordMarshallingArray_from_GlyphIndexes(glyphIndexes, lookupIndex, out var recordCount);
		if (recordCount == 0)
		{
			return null;
		}
		SetMarshallingArraySize(ref s_SingleAdjustmentRecords_MarshallingArray, recordCount);
		GetSingleAdjustmentRecordsFromMarshallingArray(MemoryExtensions.AsSpan(s_SingleAdjustmentRecords_MarshallingArray));
		s_SingleAdjustmentRecords_MarshallingArray[recordCount] = default(GlyphAdjustmentRecord);
		return s_SingleAdjustmentRecords_MarshallingArray;
	}

	[NativeMethod(Name = "TextCore::FontEngine::PopulateSingleAdjustmentRecordMarshallingArray", IsFreeFunction = true)]
	private unsafe static int PopulateSingleAdjustmentRecordMarshallingArray_from_GlyphIndexes(uint[] glyphIndexes, int lookupIndex, out int recordCount)
	{
		Span<uint> span = new Span<uint>(glyphIndexes);
		int result;
		fixed (uint* begin = span)
		{
			ManagedSpanWrapper glyphIndexes2 = new ManagedSpanWrapper(begin, span.Length);
			result = PopulateSingleAdjustmentRecordMarshallingArray_from_GlyphIndexes_Injected(ref glyphIndexes2, lookupIndex, out recordCount);
		}
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::GetSingleAdjustmentRecordsFromMarshallingArray", IsFreeFunction = true)]
	private unsafe static int GetSingleAdjustmentRecordsFromMarshallingArray(Span<GlyphAdjustmentRecord> singleSubstitutionRecords)
	{
		Span<GlyphAdjustmentRecord> span = singleSubstitutionRecords;
		int singleAdjustmentRecordsFromMarshallingArray_Injected;
		fixed (GlyphAdjustmentRecord* begin = span)
		{
			ManagedSpanWrapper singleSubstitutionRecords2 = new ManagedSpanWrapper(begin, span.Length);
			singleAdjustmentRecordsFromMarshallingArray_Injected = GetSingleAdjustmentRecordsFromMarshallingArray_Injected(ref singleSubstitutionRecords2);
		}
		return singleAdjustmentRecordsFromMarshallingArray_Injected;
	}

	[NativeMethod(Name = "TextCore::FontEngine::GetPairAdjustmentRecords", IsThreadSafe = true, IsFreeFunction = true)]
	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static GlyphPairAdjustmentRecord[] GetPairAdjustmentRecords(uint glyphIndex)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		GlyphPairAdjustmentRecord[] result;
		try
		{
			GetPairAdjustmentRecords_Injected(glyphIndex, out ret);
		}
		finally
		{
			GlyphPairAdjustmentRecord[] array = default(GlyphPairAdjustmentRecord[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::GetPairAdjustmentRecord", IsThreadSafe = true, IsFreeFunction = true)]
	internal static GlyphPairAdjustmentRecord GetPairAdjustmentRecord(uint firstGlyphIndex, uint secondGlyphIndex)
	{
		GetPairAdjustmentRecord_Injected(firstGlyphIndex, secondGlyphIndex, out var ret);
		return ret;
	}

	[NativeMethod(Name = "TextCore::FontEngine::GetAllPairAdjustmentRecords", IsThreadSafe = true, IsFreeFunction = true)]
	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static GlyphPairAdjustmentRecord[] GetAllPairAdjustmentRecords()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		GlyphPairAdjustmentRecord[] result;
		try
		{
			GetAllPairAdjustmentRecords_Injected(out ret);
		}
		finally
		{
			GlyphPairAdjustmentRecord[] array = default(GlyphPairAdjustmentRecord[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static GlyphPairAdjustmentRecord[] GetPairAdjustmentRecords(List<uint> glyphIndexes)
	{
		GenericListToMarshallingArray(ref glyphIndexes, ref s_GlyphIndexes_MarshallingArray_A);
		return GetPairAdjustmentRecords(s_GlyphIndexes_MarshallingArray_A);
	}

	internal static GlyphPairAdjustmentRecord[] GetPairAdjustmentRecords(int lookupIndex, uint glyphIndex)
	{
		GlyphIndexToMarshallingArray(glyphIndex, ref s_GlyphIndexes_MarshallingArray_A);
		return GetPairAdjustmentRecords(lookupIndex, s_GlyphIndexes_MarshallingArray_A);
	}

	internal static GlyphPairAdjustmentRecord[] GetPairAdjustmentRecords(int lookupIndex, List<uint> glyphIndexes)
	{
		GenericListToMarshallingArray(ref glyphIndexes, ref s_GlyphIndexes_MarshallingArray_A);
		return GetPairAdjustmentRecords(lookupIndex, s_GlyphIndexes_MarshallingArray_A);
	}

	private static GlyphPairAdjustmentRecord[] GetPairAdjustmentRecords(uint[] glyphIndexes)
	{
		PopulatePairAdjustmentRecordMarshallingArray(glyphIndexes, out var recordCount);
		if (recordCount == 0)
		{
			return null;
		}
		SetMarshallingArraySize(ref s_PairAdjustmentRecords_MarshallingArray, recordCount);
		GetPairAdjustmentRecordsFromMarshallingArray(s_PairAdjustmentRecords_MarshallingArray);
		s_PairAdjustmentRecords_MarshallingArray[recordCount] = default(GlyphPairAdjustmentRecord);
		return s_PairAdjustmentRecords_MarshallingArray;
	}

	private static GlyphPairAdjustmentRecord[] GetPairAdjustmentRecords(int lookupIndex, uint[] glyphIndexes)
	{
		PopulatePairAdjustmentRecordMarshallingArray_for_LookupIndex(glyphIndexes, lookupIndex, out var recordCount);
		if (recordCount == 0)
		{
			return null;
		}
		SetMarshallingArraySize(ref s_PairAdjustmentRecords_MarshallingArray, recordCount);
		GetPairAdjustmentRecordsFromMarshallingArray(s_PairAdjustmentRecords_MarshallingArray);
		s_PairAdjustmentRecords_MarshallingArray[recordCount] = default(GlyphPairAdjustmentRecord);
		return s_PairAdjustmentRecords_MarshallingArray;
	}

	[NativeMethod(Name = "TextCore::FontEngine::PopulatePairAdjustmentRecordMarshallingArray", IsFreeFunction = true)]
	private unsafe static int PopulatePairAdjustmentRecordMarshallingArray(uint[] glyphIndexes, out int recordCount)
	{
		Span<uint> span = new Span<uint>(glyphIndexes);
		int result;
		fixed (uint* begin = span)
		{
			ManagedSpanWrapper glyphIndexes2 = new ManagedSpanWrapper(begin, span.Length);
			result = PopulatePairAdjustmentRecordMarshallingArray_Injected(ref glyphIndexes2, out recordCount);
		}
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::PopulatePairAdjustmentRecordMarshallingArray", IsFreeFunction = true)]
	private unsafe static int PopulatePairAdjustmentRecordMarshallingArray_for_LookupIndex(uint[] glyphIndexes, int lookupIndex, out int recordCount)
	{
		Span<uint> span = new Span<uint>(glyphIndexes);
		int result;
		fixed (uint* begin = span)
		{
			ManagedSpanWrapper glyphIndexes2 = new ManagedSpanWrapper(begin, span.Length);
			result = PopulatePairAdjustmentRecordMarshallingArray_for_LookupIndex_Injected(ref glyphIndexes2, lookupIndex, out recordCount);
		}
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::GetGlyphPairAdjustmentRecordsFromMarshallingArray", IsFreeFunction = true)]
	private unsafe static int GetPairAdjustmentRecordsFromMarshallingArray(Span<GlyphPairAdjustmentRecord> glyphPairAdjustmentRecords)
	{
		Span<GlyphPairAdjustmentRecord> span = glyphPairAdjustmentRecords;
		int pairAdjustmentRecordsFromMarshallingArray_Injected;
		fixed (GlyphPairAdjustmentRecord* begin = span)
		{
			ManagedSpanWrapper glyphPairAdjustmentRecords2 = new ManagedSpanWrapper(begin, span.Length);
			pairAdjustmentRecordsFromMarshallingArray_Injected = GetPairAdjustmentRecordsFromMarshallingArray_Injected(ref glyphPairAdjustmentRecords2);
		}
		return pairAdjustmentRecordsFromMarshallingArray_Injected;
	}

	[NativeMethod(Name = "TextCore::FontEngine::GetAllMarkToBaseAdjustmentRecords", IsThreadSafe = true, IsFreeFunction = true)]
	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static MarkToBaseAdjustmentRecord[] GetAllMarkToBaseAdjustmentRecords()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		MarkToBaseAdjustmentRecord[] result;
		try
		{
			GetAllMarkToBaseAdjustmentRecords_Injected(out ret);
		}
		finally
		{
			MarkToBaseAdjustmentRecord[] array = default(MarkToBaseAdjustmentRecord[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::GetMarkToBaseAdjustmentRecords", IsThreadSafe = true, IsFreeFunction = true)]
	internal static MarkToBaseAdjustmentRecord[] GetMarkToBaseAdjustmentRecords(uint baseGlyphIndex)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		MarkToBaseAdjustmentRecord[] result;
		try
		{
			GetMarkToBaseAdjustmentRecords_Injected(baseGlyphIndex, out ret);
		}
		finally
		{
			MarkToBaseAdjustmentRecord[] array = default(MarkToBaseAdjustmentRecord[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::GetMarkToBaseAdjustmentRecord", IsFreeFunction = true)]
	internal static MarkToBaseAdjustmentRecord GetMarkToBaseAdjustmentRecord(uint baseGlyphIndex, uint markGlyphIndex)
	{
		GetMarkToBaseAdjustmentRecord_Injected(baseGlyphIndex, markGlyphIndex, out var ret);
		return ret;
	}

	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static MarkToBaseAdjustmentRecord[] GetMarkToBaseAdjustmentRecords(List<uint> glyphIndexes)
	{
		GenericListToMarshallingArray(ref glyphIndexes, ref s_GlyphIndexes_MarshallingArray_A);
		return GetMarkToBaseAdjustmentRecords(s_GlyphIndexes_MarshallingArray_A);
	}

	internal static MarkToBaseAdjustmentRecord[] GetMarkToBaseAdjustmentRecords(int lookupIndex, List<uint> glyphIndexes)
	{
		GenericListToMarshallingArray(ref glyphIndexes, ref s_GlyphIndexes_MarshallingArray_A);
		return GetMarkToBaseAdjustmentRecords(lookupIndex, s_GlyphIndexes_MarshallingArray_A);
	}

	private static MarkToBaseAdjustmentRecord[] GetMarkToBaseAdjustmentRecords(uint[] glyphIndexes)
	{
		PopulateMarkToBaseAdjustmentRecordMarshallingArray(glyphIndexes, out var recordCount);
		if (recordCount == 0)
		{
			return null;
		}
		SetMarshallingArraySize(ref s_MarkToBaseAdjustmentRecords_MarshallingArray, recordCount);
		GetMarkToBaseAdjustmentRecordsFromMarshallingArray(s_MarkToBaseAdjustmentRecords_MarshallingArray);
		s_MarkToBaseAdjustmentRecords_MarshallingArray[recordCount] = default(MarkToBaseAdjustmentRecord);
		return s_MarkToBaseAdjustmentRecords_MarshallingArray;
	}

	private static MarkToBaseAdjustmentRecord[] GetMarkToBaseAdjustmentRecords(int lookupIndex, uint[] glyphIndexes)
	{
		PopulateMarkToBaseAdjustmentRecordMarshallingArray_for_LookupIndex(glyphIndexes, lookupIndex, out var recordCount);
		if (recordCount == 0)
		{
			return null;
		}
		SetMarshallingArraySize(ref s_MarkToBaseAdjustmentRecords_MarshallingArray, recordCount);
		GetMarkToBaseAdjustmentRecordsFromMarshallingArray(s_MarkToBaseAdjustmentRecords_MarshallingArray);
		s_MarkToBaseAdjustmentRecords_MarshallingArray[recordCount] = default(MarkToBaseAdjustmentRecord);
		return s_MarkToBaseAdjustmentRecords_MarshallingArray;
	}

	[NativeMethod(Name = "TextCore::FontEngine::PopulateMarkToBaseAdjustmentRecordMarshallingArray", IsFreeFunction = true)]
	private unsafe static int PopulateMarkToBaseAdjustmentRecordMarshallingArray(uint[] glyphIndexes, out int recordCount)
	{
		Span<uint> span = new Span<uint>(glyphIndexes);
		int result;
		fixed (uint* begin = span)
		{
			ManagedSpanWrapper glyphIndexes2 = new ManagedSpanWrapper(begin, span.Length);
			result = PopulateMarkToBaseAdjustmentRecordMarshallingArray_Injected(ref glyphIndexes2, out recordCount);
		}
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::PopulateMarkToBaseAdjustmentRecordMarshallingArray", IsFreeFunction = true)]
	private unsafe static int PopulateMarkToBaseAdjustmentRecordMarshallingArray_for_LookupIndex(uint[] glyphIndexes, int lookupIndex, out int recordCount)
	{
		Span<uint> span = new Span<uint>(glyphIndexes);
		int result;
		fixed (uint* begin = span)
		{
			ManagedSpanWrapper glyphIndexes2 = new ManagedSpanWrapper(begin, span.Length);
			result = PopulateMarkToBaseAdjustmentRecordMarshallingArray_for_LookupIndex_Injected(ref glyphIndexes2, lookupIndex, out recordCount);
		}
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::GetMarkToBaseAdjustmentRecordsFromMarshallingArray", IsFreeFunction = true)]
	private unsafe static int GetMarkToBaseAdjustmentRecordsFromMarshallingArray(Span<MarkToBaseAdjustmentRecord> adjustmentRecords)
	{
		Span<MarkToBaseAdjustmentRecord> span = adjustmentRecords;
		int markToBaseAdjustmentRecordsFromMarshallingArray_Injected;
		fixed (MarkToBaseAdjustmentRecord* begin = span)
		{
			ManagedSpanWrapper adjustmentRecords2 = new ManagedSpanWrapper(begin, span.Length);
			markToBaseAdjustmentRecordsFromMarshallingArray_Injected = GetMarkToBaseAdjustmentRecordsFromMarshallingArray_Injected(ref adjustmentRecords2);
		}
		return markToBaseAdjustmentRecordsFromMarshallingArray_Injected;
	}

	[NativeMethod(Name = "TextCore::FontEngine::GetAllMarkToMarkAdjustmentRecords", IsThreadSafe = true, IsFreeFunction = true)]
	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static MarkToMarkAdjustmentRecord[] GetAllMarkToMarkAdjustmentRecords()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		MarkToMarkAdjustmentRecord[] result;
		try
		{
			GetAllMarkToMarkAdjustmentRecords_Injected(out ret);
		}
		finally
		{
			MarkToMarkAdjustmentRecord[] array = default(MarkToMarkAdjustmentRecord[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::GetMarkToMarkAdjustmentRecords", IsThreadSafe = true, IsFreeFunction = true)]
	internal static MarkToMarkAdjustmentRecord[] GetMarkToMarkAdjustmentRecords(uint baseMarkGlyphIndex)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		MarkToMarkAdjustmentRecord[] result;
		try
		{
			GetMarkToMarkAdjustmentRecords_Injected(baseMarkGlyphIndex, out ret);
		}
		finally
		{
			MarkToMarkAdjustmentRecord[] array = default(MarkToMarkAdjustmentRecord[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::GetMarkToMarkAdjustmentRecord", IsFreeFunction = true)]
	internal static MarkToMarkAdjustmentRecord GetMarkToMarkAdjustmentRecord(uint firstGlyphIndex, uint secondGlyphIndex)
	{
		GetMarkToMarkAdjustmentRecord_Injected(firstGlyphIndex, secondGlyphIndex, out var ret);
		return ret;
	}

	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static MarkToMarkAdjustmentRecord[] GetMarkToMarkAdjustmentRecords(List<uint> glyphIndexes)
	{
		GenericListToMarshallingArray(ref glyphIndexes, ref s_GlyphIndexes_MarshallingArray_A);
		return GetMarkToMarkAdjustmentRecords(s_GlyphIndexes_MarshallingArray_A);
	}

	internal static MarkToMarkAdjustmentRecord[] GetMarkToMarkAdjustmentRecords(int lookupIndex, List<uint> glyphIndexes)
	{
		GenericListToMarshallingArray(ref glyphIndexes, ref s_GlyphIndexes_MarshallingArray_A);
		return GetMarkToMarkAdjustmentRecords(lookupIndex, s_GlyphIndexes_MarshallingArray_A);
	}

	private static MarkToMarkAdjustmentRecord[] GetMarkToMarkAdjustmentRecords(uint[] glyphIndexes)
	{
		PopulateMarkToMarkAdjustmentRecordMarshallingArray(s_GlyphIndexes_MarshallingArray_A, out var recordCount);
		if (recordCount == 0)
		{
			return null;
		}
		SetMarshallingArraySize(ref s_MarkToMarkAdjustmentRecords_MarshallingArray, recordCount);
		GetMarkToMarkAdjustmentRecordsFromMarshallingArray(s_MarkToMarkAdjustmentRecords_MarshallingArray);
		s_MarkToMarkAdjustmentRecords_MarshallingArray[recordCount] = default(MarkToMarkAdjustmentRecord);
		return s_MarkToMarkAdjustmentRecords_MarshallingArray;
	}

	private static MarkToMarkAdjustmentRecord[] GetMarkToMarkAdjustmentRecords(int lookupIndex, uint[] glyphIndexes)
	{
		PopulateMarkToMarkAdjustmentRecordMarshallingArray_for_LookupIndex(s_GlyphIndexes_MarshallingArray_A, lookupIndex, out var recordCount);
		if (recordCount == 0)
		{
			return null;
		}
		SetMarshallingArraySize(ref s_MarkToMarkAdjustmentRecords_MarshallingArray, recordCount);
		GetMarkToMarkAdjustmentRecordsFromMarshallingArray(s_MarkToMarkAdjustmentRecords_MarshallingArray);
		s_MarkToMarkAdjustmentRecords_MarshallingArray[recordCount] = default(MarkToMarkAdjustmentRecord);
		return s_MarkToMarkAdjustmentRecords_MarshallingArray;
	}

	[NativeMethod(Name = "TextCore::FontEngine::PopulateMarkToMarkAdjustmentRecordMarshallingArray", IsFreeFunction = true)]
	private unsafe static int PopulateMarkToMarkAdjustmentRecordMarshallingArray(uint[] glyphIndexes, out int recordCount)
	{
		Span<uint> span = new Span<uint>(glyphIndexes);
		int result;
		fixed (uint* begin = span)
		{
			ManagedSpanWrapper glyphIndexes2 = new ManagedSpanWrapper(begin, span.Length);
			result = PopulateMarkToMarkAdjustmentRecordMarshallingArray_Injected(ref glyphIndexes2, out recordCount);
		}
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::PopulateMarkToMarkAdjustmentRecordMarshallingArray", IsFreeFunction = true)]
	private unsafe static int PopulateMarkToMarkAdjustmentRecordMarshallingArray_for_LookupIndex(uint[] glyphIndexes, int lookupIndex, out int recordCount)
	{
		Span<uint> span = new Span<uint>(glyphIndexes);
		int result;
		fixed (uint* begin = span)
		{
			ManagedSpanWrapper glyphIndexes2 = new ManagedSpanWrapper(begin, span.Length);
			result = PopulateMarkToMarkAdjustmentRecordMarshallingArray_for_LookupIndex_Injected(ref glyphIndexes2, lookupIndex, out recordCount);
		}
		return result;
	}

	[NativeMethod(Name = "TextCore::FontEngine::GetMarkToMarkAdjustmentRecordsFromMarshallingArray", IsFreeFunction = true)]
	private unsafe static int GetMarkToMarkAdjustmentRecordsFromMarshallingArray(Span<MarkToMarkAdjustmentRecord> adjustmentRecords)
	{
		Span<MarkToMarkAdjustmentRecord> span = adjustmentRecords;
		int markToMarkAdjustmentRecordsFromMarshallingArray_Injected;
		fixed (MarkToMarkAdjustmentRecord* begin = span)
		{
			ManagedSpanWrapper adjustmentRecords2 = new ManagedSpanWrapper(begin, span.Length);
			markToMarkAdjustmentRecordsFromMarshallingArray_Injected = GetMarkToMarkAdjustmentRecordsFromMarshallingArray_Injected(ref adjustmentRecords2);
		}
		return markToMarkAdjustmentRecordsFromMarshallingArray_Injected;
	}

	private static void GlyphIndexToMarshallingArray(uint glyphIndex, ref uint[] dstArray)
	{
		if (dstArray == null || dstArray.Length == 1)
		{
			dstArray = new uint[8];
		}
		dstArray[0] = glyphIndex;
		dstArray[1] = 0u;
	}

	private static void GenericListToMarshallingArray<T>(ref List<T> srcList, ref T[] dstArray)
	{
		int count = srcList.Count;
		if (dstArray == null || dstArray.Length <= count)
		{
			int num = Mathf.NextPowerOfTwo(count + 1);
			if (dstArray == null)
			{
				dstArray = new T[num];
			}
			else
			{
				Array.Resize(ref dstArray, num);
			}
		}
		for (int i = 0; i < count; i++)
		{
			dstArray[i] = srcList[i];
		}
		dstArray[count] = default(T);
	}

	private static void SetMarshallingArraySize<T>(ref T[] marshallingArray, int recordCount)
	{
		if (marshallingArray == null || marshallingArray.Length <= recordCount)
		{
			int num = Mathf.NextPowerOfTwo(recordCount + 1);
			if (marshallingArray == null)
			{
				marshallingArray = new T[num];
			}
			else
			{
				Array.Resize(ref marshallingArray, num);
			}
		}
	}

	[NativeMethod(Name = "TextCore::FontEngine::ResetAtlasTexture", IsFreeFunction = true)]
	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static void ResetAtlasTexture(Texture2D texture)
	{
		ResetAtlasTexture_Injected(Object.MarshalledUnityObject.Marshal(texture));
	}

	[NativeMethod(Name = "TextCore::FontEngine::RenderToTexture", IsFreeFunction = true)]
	internal static void RenderBufferToTexture(Texture2D srcTexture, int padding, GlyphRenderMode renderMode, Texture2D dstTexture)
	{
		RenderBufferToTexture_Injected(Object.MarshalledUnityObject.Marshal(srcTexture), padding, renderMode, Object.MarshalledUnityObject.Marshal(dstTexture));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int LoadFontFace_Internal_Injected(ref ManagedSpanWrapper filePath);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int LoadFontFace_With_Size_Internal_Injected(ref ManagedSpanWrapper filePath, int pointSize);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int LoadFontFace_With_Size_And_FaceIndex_Internal_Injected(ref ManagedSpanWrapper filePath, int pointSize, int faceIndex);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int LoadFontFace_FromSourceFontFile_Internal_Injected(ref ManagedSpanWrapper sourceFontFile);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int LoadFontFace_With_Size_FromSourceFontFile_Internal_Injected(ref ManagedSpanWrapper sourceFontFile, int pointSize);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int LoadFontFace_With_Size_And_FaceIndex_FromSourceFontFile_Internal_Injected(ref ManagedSpanWrapper sourceFontFile, int pointSize, int faceIndex);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int LoadFontFace_FromFont_Internal_Injected(IntPtr font);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int LoadFontFace_With_Size_FromFont_Internal_Injected(IntPtr font, int pointSize);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int LoadFontFace_With_Size_and_FaceIndex_FromFont_Internal_Injected(IntPtr font, int pointSize, int faceIndex);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int LoadFontFace_by_FamilyName_and_StyleName_Internal_Injected(ref ManagedSpanWrapper familyName, ref ManagedSpanWrapper styleName);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int LoadFontFace_With_Size_by_FamilyName_and_StyleName_Internal_Injected(ref ManagedSpanWrapper familyName, ref ManagedSpanWrapper styleName, int pointSize);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryGetSystemFontReference_Internal_Injected(ref ManagedSpanWrapper familyName, ref ManagedSpanWrapper styleName, out FontReference fontRef);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryPackGlyphInAtlas_Internal_Injected(ref GlyphMarshallingStruct glyph, int padding, GlyphPackingMode packingMode, GlyphRenderMode renderMode, int width, int height, out BlittableArrayWrapper freeGlyphRects, ref int freeGlyphRectCount, out BlittableArrayWrapper usedGlyphRects, ref int usedGlyphRectCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryPackGlyphsInAtlas_Internal_Injected(out BlittableArrayWrapper glyphsToAdd, ref int glyphsToAddCount, out BlittableArrayWrapper glyphsAdded, ref int glyphsAddedCount, int padding, GlyphPackingMode packingMode, GlyphRenderMode renderMode, int width, int height, out BlittableArrayWrapper freeGlyphRects, ref int freeGlyphRectCount, out BlittableArrayWrapper usedGlyphRects, ref int usedGlyphRectCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int RenderGlyphToTexture_Internal_Injected([In] ref GlyphMarshallingStruct glyphStruct, int padding, GlyphRenderMode renderMode, IntPtr texture);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int RenderGlyphsToTexture_Internal_Injected(ref ManagedSpanWrapper glyphs, int glyphCount, int padding, GlyphRenderMode renderMode, IntPtr texture);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int RenderGlyphsToTextureBuffer_Internal_Injected(ref ManagedSpanWrapper glyphs, int glyphCount, int padding, GlyphRenderMode renderMode, out BlittableArrayWrapper texBuffer, int texWidth, int texHeight);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int RenderGlyphsToSharedTexture_Internal_Injected(ref ManagedSpanWrapper glyphs, int glyphCount, int padding, GlyphRenderMode renderMode);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetSharedTexture_Injected(IntPtr texture);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryAddGlyphToTexture_Internal_Injected(uint glyphIndex, int padding, GlyphPackingMode packingMode, out BlittableArrayWrapper freeGlyphRects, ref int freeGlyphRectCount, out BlittableArrayWrapper usedGlyphRects, ref int usedGlyphRectCount, GlyphRenderMode renderMode, IntPtr texture, out GlyphMarshallingStruct glyph);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryAddGlyphsToTexture_Internal_MultiThread_Injected(out BlittableArrayWrapper glyphsToAdd, ref int glyphsToAddCount, out BlittableArrayWrapper glyphsAdded, ref int glyphsAddedCount, int padding, GlyphPackingMode packingMode, out BlittableArrayWrapper freeGlyphRects, ref int freeGlyphRectCount, out BlittableArrayWrapper usedGlyphRects, ref int usedGlyphRectCount, GlyphRenderMode renderMode, IntPtr texture);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool TryAddGlyphsToTexture_Internal_Injected(ref ManagedSpanWrapper glyphIndex, int padding, GlyphPackingMode packingMode, out BlittableArrayWrapper freeGlyphRects, ref int freeGlyphRectCount, out BlittableArrayWrapper usedGlyphRects, ref int usedGlyphRectCount, GlyphRenderMode renderMode, IntPtr texture, out BlittableArrayWrapper glyphs, ref int glyphCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetOpenTypeLayoutTable_Injected(OTL_TableType type, out OTL_Table ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetOpenTypeLayoutLookups_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetAllSingleSubstitutionRecords_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int PopulateSingleSubstitutionRecordMarshallingArray_from_GlyphIndexes_Injected(ref ManagedSpanWrapper glyphIndexes, int lookupIndex, out int recordCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetSingleSubstitutionRecordsFromMarshallingArray_Injected(ref ManagedSpanWrapper singleSubstitutionRecords);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int PopulateMultipleSubstitutionRecordMarshallingArray_from_GlyphIndexes_Injected(ref ManagedSpanWrapper glyphIndexes, int lookupIndex, out int recordCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int PopulateAlternateSubstitutionRecordMarshallingArray_from_GlyphIndexes_Injected(ref ManagedSpanWrapper glyphIndexes, int lookupIndex, out int recordCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int PopulateLigatureSubstitutionRecordMarshallingArray_Injected(ref ManagedSpanWrapper glyphIndexes, out int recordCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int PopulateLigatureSubstitutionRecordMarshallingArray_for_LookupIndex_Injected(ref ManagedSpanWrapper glyphIndexes, int lookupIndex, out int recordCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int PopulateContextualSubstitutionRecordMarshallingArray_from_GlyphIndexes_Injected(ref ManagedSpanWrapper glyphIndexes, int lookupIndex, out int recordCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int PopulateChainingContextualSubstitutionRecordMarshallingArray_from_GlyphIndexes_Injected(ref ManagedSpanWrapper glyphIndexes, int lookupIndex, out int recordCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int PopulatePairAdjustmentRecordMarshallingArray_from_KernTable_Injected(ref ManagedSpanWrapper glyphIndexes, out int recordCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int PopulatePairAdjustmentRecordMarshallingArray_for_NewlyAddedGlyphIndexes_Injected(ref ManagedSpanWrapper newGlyphIndexes, ref ManagedSpanWrapper allGlyphIndexes, out int recordCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetGlyphPairAdjustmentRecord_Injected(uint firstGlyphIndex, uint secondGlyphIndex, out GlyphPairAdjustmentRecord ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int PopulateSingleAdjustmentRecordMarshallingArray_from_GlyphIndexes_Injected(ref ManagedSpanWrapper glyphIndexes, int lookupIndex, out int recordCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetSingleAdjustmentRecordsFromMarshallingArray_Injected(ref ManagedSpanWrapper singleSubstitutionRecords);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetPairAdjustmentRecords_Injected(uint glyphIndex, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetPairAdjustmentRecord_Injected(uint firstGlyphIndex, uint secondGlyphIndex, out GlyphPairAdjustmentRecord ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetAllPairAdjustmentRecords_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int PopulatePairAdjustmentRecordMarshallingArray_Injected(ref ManagedSpanWrapper glyphIndexes, out int recordCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int PopulatePairAdjustmentRecordMarshallingArray_for_LookupIndex_Injected(ref ManagedSpanWrapper glyphIndexes, int lookupIndex, out int recordCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetPairAdjustmentRecordsFromMarshallingArray_Injected(ref ManagedSpanWrapper glyphPairAdjustmentRecords);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetAllMarkToBaseAdjustmentRecords_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetMarkToBaseAdjustmentRecords_Injected(uint baseGlyphIndex, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetMarkToBaseAdjustmentRecord_Injected(uint baseGlyphIndex, uint markGlyphIndex, out MarkToBaseAdjustmentRecord ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int PopulateMarkToBaseAdjustmentRecordMarshallingArray_Injected(ref ManagedSpanWrapper glyphIndexes, out int recordCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int PopulateMarkToBaseAdjustmentRecordMarshallingArray_for_LookupIndex_Injected(ref ManagedSpanWrapper glyphIndexes, int lookupIndex, out int recordCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetMarkToBaseAdjustmentRecordsFromMarshallingArray_Injected(ref ManagedSpanWrapper adjustmentRecords);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetAllMarkToMarkAdjustmentRecords_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetMarkToMarkAdjustmentRecords_Injected(uint baseMarkGlyphIndex, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetMarkToMarkAdjustmentRecord_Injected(uint firstGlyphIndex, uint secondGlyphIndex, out MarkToMarkAdjustmentRecord ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int PopulateMarkToMarkAdjustmentRecordMarshallingArray_Injected(ref ManagedSpanWrapper glyphIndexes, out int recordCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int PopulateMarkToMarkAdjustmentRecordMarshallingArray_for_LookupIndex_Injected(ref ManagedSpanWrapper glyphIndexes, int lookupIndex, out int recordCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetMarkToMarkAdjustmentRecordsFromMarshallingArray_Injected(ref ManagedSpanWrapper adjustmentRecords);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ResetAtlasTexture_Injected(IntPtr texture);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void RenderBufferToTexture_Injected(IntPtr srcTexture, int padding, GlyphRenderMode renderMode, IntPtr dstTexture);
}
