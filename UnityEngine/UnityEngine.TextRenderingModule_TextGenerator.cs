using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine;

[StructLayout(LayoutKind.Sequential)]
[UsedByNativeCode]
[NativeHeader("Modules/TextRendering/TextGenerator.h")]
public sealed class TextGenerator : IDisposable
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(TextGenerator textGenerator)
		{
			return textGenerator.m_Ptr;
		}
	}

	internal IntPtr m_Ptr;

	private string m_LastString;

	private TextGenerationSettings m_LastSettings;

	private bool m_HasGenerated;

	private TextGenerationError m_LastValid;

	private readonly List<UIVertex> m_Verts;

	private readonly List<UICharInfo> m_Characters;

	private readonly List<UILineInfo> m_Lines;

	private bool m_CachedVerts;

	private bool m_CachedCharacters;

	private bool m_CachedLines;

	public int characterCountVisible => characterCount - 1;

	public IList<UIVertex> verts
	{
		get
		{
			if (!m_CachedVerts)
			{
				GetVertices(m_Verts);
				m_CachedVerts = true;
			}
			return m_Verts;
		}
	}

	public IList<UICharInfo> characters
	{
		get
		{
			if (!m_CachedCharacters)
			{
				GetCharacters(m_Characters);
				m_CachedCharacters = true;
			}
			return m_Characters;
		}
	}

	public IList<UILineInfo> lines
	{
		get
		{
			if (!m_CachedLines)
			{
				GetLines(m_Lines);
				m_CachedLines = true;
			}
			return m_Lines;
		}
	}

	public Rect rectExtents
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_rectExtents_Injected(intPtr, out var ret);
			return ret;
		}
	}

	public int vertexCount
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_vertexCount_Injected(intPtr);
		}
	}

	public int characterCount
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_characterCount_Injected(intPtr);
		}
	}

	public int lineCount
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_lineCount_Injected(intPtr);
		}
	}

	[NativeProperty("FontSizeFoundForBestFit", false, TargetType.Function)]
	public int fontSizeUsedForBestFit
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_fontSizeUsedForBestFit_Injected(intPtr);
		}
	}

	public TextGenerator()
		: this(50)
	{
	}

	public TextGenerator(int initialCapacity)
	{
		m_Ptr = Internal_Create();
		m_Verts = new List<UIVertex>((initialCapacity + 1) * 4);
		m_Characters = new List<UICharInfo>(initialCapacity + 1);
		m_Lines = new List<UILineInfo>(20);
	}

	~TextGenerator()
	{
		((IDisposable)this).Dispose();
	}

	void IDisposable.Dispose()
	{
		if (m_Ptr != IntPtr.Zero)
		{
			Internal_Destroy(m_Ptr);
			m_Ptr = IntPtr.Zero;
		}
	}

	private TextGenerationSettings ValidatedSettings(TextGenerationSettings settings)
	{
		if (settings.font != null && settings.font.dynamic)
		{
			return settings;
		}
		if (settings.fontSize != 0 || settings.fontStyle != FontStyle.Normal)
		{
			if (settings.font != null)
			{
				Debug.LogWarningFormat(settings.font, "Font size and style overrides are only supported for dynamic fonts. Font '{0}' is not dynamic.", settings.font.name);
			}
			settings.fontSize = 0;
			settings.fontStyle = FontStyle.Normal;
		}
		if (settings.resizeTextForBestFit)
		{
			if (settings.font != null)
			{
				Debug.LogWarningFormat(settings.font, "BestFit is only supported for dynamic fonts. Font '{0}' is not dynamic.", settings.font.name);
			}
			settings.resizeTextForBestFit = false;
		}
		return settings;
	}

	public void Invalidate()
	{
		m_HasGenerated = false;
	}

	public void GetCharacters(List<UICharInfo> characters)
	{
		GetCharactersInternal(characters);
	}

	public void GetLines(List<UILineInfo> lines)
	{
		GetLinesInternal(lines);
	}

	public void GetVertices(List<UIVertex> vertices)
	{
		GetVerticesInternal(vertices);
	}

	public float GetPreferredWidth(string str, TextGenerationSettings settings)
	{
		settings.horizontalOverflow = HorizontalWrapMode.Overflow;
		settings.verticalOverflow = VerticalWrapMode.Overflow;
		settings.updateBounds = true;
		Populate(str, settings);
		return rectExtents.width;
	}

	public float GetPreferredHeight(string str, TextGenerationSettings settings)
	{
		settings.verticalOverflow = VerticalWrapMode.Overflow;
		settings.updateBounds = true;
		Populate(str, settings);
		return rectExtents.height;
	}

	public bool PopulateWithErrors(string str, TextGenerationSettings settings, GameObject context)
	{
		TextGenerationError textGenerationError = PopulateWithError(str, settings);
		if (textGenerationError == TextGenerationError.None)
		{
			return true;
		}
		if ((textGenerationError & TextGenerationError.CustomSizeOnNonDynamicFont) != TextGenerationError.None)
		{
			Debug.LogErrorFormat(context, "Font '{0}' is not dynamic, which is required to override its size", settings.font);
		}
		if ((textGenerationError & TextGenerationError.CustomStyleOnNonDynamicFont) != TextGenerationError.None)
		{
			Debug.LogErrorFormat(context, "Font '{0}' is not dynamic, which is required to override its style", settings.font);
		}
		return false;
	}

	public bool Populate(string str, TextGenerationSettings settings)
	{
		TextGenerationError textGenerationError = PopulateWithError(str, settings);
		return textGenerationError == TextGenerationError.None;
	}

	private TextGenerationError PopulateWithError(string str, TextGenerationSettings settings)
	{
		if (m_HasGenerated && str == m_LastString && settings.Equals(m_LastSettings))
		{
			return m_LastValid;
		}
		m_LastValid = PopulateAlways(str, settings);
		return m_LastValid;
	}

	private TextGenerationError PopulateAlways(string str, TextGenerationSettings settings)
	{
		m_LastString = str;
		m_HasGenerated = true;
		m_CachedVerts = false;
		m_CachedCharacters = false;
		m_CachedLines = false;
		m_LastSettings = settings;
		TextGenerationSettings textGenerationSettings = ValidatedSettings(settings);
		Populate_Internal(str, textGenerationSettings.font, textGenerationSettings.color, textGenerationSettings.fontSize, textGenerationSettings.scaleFactor, textGenerationSettings.lineSpacing, textGenerationSettings.fontStyle, textGenerationSettings.richText, textGenerationSettings.resizeTextForBestFit, textGenerationSettings.resizeTextMinSize, textGenerationSettings.resizeTextMaxSize, textGenerationSettings.verticalOverflow, textGenerationSettings.horizontalOverflow, textGenerationSettings.updateBounds, textGenerationSettings.textAnchor, textGenerationSettings.generationExtents, textGenerationSettings.pivot, textGenerationSettings.generateOutOfBounds, textGenerationSettings.alignByGeometry, out var error);
		m_LastValid = error;
		return error;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(IsThreadSafe = true)]
	private static extern IntPtr Internal_Create();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(IsThreadSafe = true)]
	private static extern void Internal_Destroy(IntPtr ptr);

	internal unsafe bool Populate_Internal(string str, Font font, Color color, int fontSize, float scaleFactor, float lineSpacing, FontStyle style, bool richText, bool resizeTextForBestFit, int resizeTextMinSize, int resizeTextMaxSize, int verticalOverFlow, int horizontalOverflow, bool updateBounds, TextAnchor anchor, float extentsX, float extentsY, float pivotX, float pivotY, bool generateOutOfBounds, bool alignByGeometry, out uint error)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(str, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(str);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return Populate_Internal_Injected(intPtr, ref managedSpanWrapper, Object.MarshalledUnityObject.Marshal(font), ref color, fontSize, scaleFactor, lineSpacing, style, richText, resizeTextForBestFit, resizeTextMinSize, resizeTextMaxSize, verticalOverFlow, horizontalOverflow, updateBounds, anchor, extentsX, extentsY, pivotX, pivotY, generateOutOfBounds, alignByGeometry, out error);
				}
			}
			return Populate_Internal_Injected(intPtr, ref managedSpanWrapper, Object.MarshalledUnityObject.Marshal(font), ref color, fontSize, scaleFactor, lineSpacing, style, richText, resizeTextForBestFit, resizeTextMinSize, resizeTextMaxSize, verticalOverFlow, horizontalOverflow, updateBounds, anchor, extentsX, extentsY, pivotX, pivotY, generateOutOfBounds, alignByGeometry, out error);
		}
		finally
		{
		}
	}

	internal bool Populate_Internal(string str, Font font, Color color, int fontSize, float scaleFactor, float lineSpacing, FontStyle style, bool richText, bool resizeTextForBestFit, int resizeTextMinSize, int resizeTextMaxSize, VerticalWrapMode verticalOverFlow, HorizontalWrapMode horizontalOverflow, bool updateBounds, TextAnchor anchor, Vector2 extents, Vector2 pivot, bool generateOutOfBounds, bool alignByGeometry, out TextGenerationError error)
	{
		if (font == null)
		{
			error = TextGenerationError.NoFont;
			return false;
		}
		uint error2 = 0u;
		bool result = Populate_Internal(str, font, color, fontSize, scaleFactor, lineSpacing, style, richText, resizeTextForBestFit, resizeTextMinSize, resizeTextMaxSize, (int)verticalOverFlow, (int)horizontalOverflow, updateBounds, anchor, extents.x, extents.y, pivot.x, pivot.y, generateOutOfBounds, alignByGeometry, out error2);
		error = (TextGenerationError)error2;
		return result;
	}

	public UIVertex[] GetVerticesArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		UIVertex[] result;
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetVerticesArray_Injected(intPtr, out ret);
		}
		finally
		{
			UIVertex[] array = default(UIVertex[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public UICharInfo[] GetCharactersArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		UICharInfo[] result;
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetCharactersArray_Injected(intPtr, out ret);
		}
		finally
		{
			UICharInfo[] array = default(UICharInfo[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public UILineInfo[] GetLinesArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		UILineInfo[] result;
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetLinesArray_Injected(intPtr, out ret);
		}
		finally
		{
			UILineInfo[] array = default(UILineInfo[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[NativeThrows]
	private void GetVerticesInternal(object vertices)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetVerticesInternal_Injected(intPtr, vertices);
	}

	[NativeThrows]
	private void GetCharactersInternal(object characters)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetCharactersInternal_Injected(intPtr, characters);
	}

	[NativeThrows]
	private void GetLinesInternal(object lines)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetLinesInternal_Injected(intPtr, lines);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_rectExtents_Injected(IntPtr _unity_self, out Rect ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_vertexCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_characterCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_lineCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_fontSizeUsedForBestFit_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool Populate_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper str, IntPtr font, [In] ref Color color, int fontSize, float scaleFactor, float lineSpacing, FontStyle style, bool richText, bool resizeTextForBestFit, int resizeTextMinSize, int resizeTextMaxSize, int verticalOverFlow, int horizontalOverflow, bool updateBounds, TextAnchor anchor, float extentsX, float extentsY, float pivotX, float pivotY, bool generateOutOfBounds, bool alignByGeometry, out uint error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetVerticesArray_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetCharactersArray_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetLinesArray_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetVerticesInternal_Injected(IntPtr _unity_self, object vertices);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetCharactersInternal_Injected(IntPtr _unity_self, object characters);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetLinesInternal_Injected(IntPtr _unity_self, object lines);
}
