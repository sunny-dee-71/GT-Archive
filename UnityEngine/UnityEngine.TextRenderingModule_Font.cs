using System;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine;

[NativeClass("TextRendering::Font")]
[NativeHeader("Modules/TextRendering/Public/Font.h")]
[NativeHeader("Modules/TextRendering/Public/FontImpl.h")]
[StaticAccessor("TextRenderingPrivate", StaticAccessorType.DoubleColon)]
public sealed class Font : Object
{
	public delegate void FontTextureRebuildCallback();

	public Material material
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Material>(get_material_Injected(intPtr));
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_material_Injected(intPtr, MarshalledUnityObject.Marshal(value));
		}
	}

	public string[] fontNames
	{
		[return: Unmarshalled]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_fontNames_Injected(intPtr);
		}
		[param: Unmarshalled]
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_fontNames_Injected(intPtr, value);
		}
	}

	public bool dynamic
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_dynamic_Injected(intPtr);
		}
	}

	public int ascent
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_ascent_Injected(intPtr);
		}
	}

	public int fontSize
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_fontSize_Injected(intPtr);
		}
	}

	public unsafe CharacterInfo[] characterInfo
	{
		[FreeFunction("TextRenderingPrivate::GetFontCharacterInfo", HasExplicitThis = true)]
		get
		{
			BlittableArrayWrapper ret = default(BlittableArrayWrapper);
			CharacterInfo[] result;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_characterInfo_Injected(intPtr, out ret);
			}
			finally
			{
				CharacterInfo[] array = default(CharacterInfo[]);
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}
		[FreeFunction("TextRenderingPrivate::SetFontCharacterInfo", HasExplicitThis = true)]
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<CharacterInfo> span = new Span<CharacterInfo>(value);
			fixed (CharacterInfo* begin = span)
			{
				ManagedSpanWrapper value2 = new ManagedSpanWrapper(begin, span.Length);
				set_characterInfo_Injected(intPtr, ref value2);
			}
		}
	}

	[NativeProperty("LineSpacing", false, TargetType.Function)]
	public int lineHeight
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_lineHeight_Injected(intPtr);
		}
	}

	[Obsolete("Font.textureRebuildCallback has been deprecated. Use Font.textureRebuilt instead.")]
	public FontTextureRebuildCallback textureRebuildCallback
	{
		get
		{
			return this.m_FontTextureRebuildCallback;
		}
		set
		{
			this.m_FontTextureRebuildCallback = value;
		}
	}

	public static event Action<Font> textureRebuilt;

	private event FontTextureRebuildCallback m_FontTextureRebuildCallback;

	public Font()
	{
		Internal_CreateFont(this, null);
	}

	public Font(string name)
	{
		if (Path.GetDirectoryName(name) == string.Empty)
		{
			Internal_CreateFont(this, name);
		}
		else
		{
			Internal_CreateFontFromPath(this, name);
		}
	}

	private Font(string[] names, int size)
	{
		Internal_CreateDynamicFont(this, names, size);
	}

	public static Font CreateDynamicFontFromOSFont(string fontname, int size)
	{
		return new Font(new string[1] { fontname }, size);
	}

	public static Font CreateDynamicFontFromOSFont(string[] fontnames, int size)
	{
		return new Font(fontnames, size);
	}

	[RequiredByNativeCode]
	internal static void InvokeTextureRebuilt_Internal(Font font)
	{
		Font.textureRebuilt?.Invoke(font);
		font.m_FontTextureRebuildCallback?.Invoke();
	}

	public static int GetMaxVertsForString(string str)
	{
		return str.Length * 4 + 4;
	}

	internal static Font GetDefault()
	{
		return Unmarshal.UnmarshalUnityObject<Font>(GetDefault_Injected());
	}

	public bool HasCharacter(char c)
	{
		return HasCharacter((int)c);
	}

	private bool HasCharacter(int c)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasCharacter_Injected(intPtr, c);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] GetOSInstalledFontNames();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] GetPathsToOSFonts();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static extern string[] GetOSFallbacks();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[ThreadSafe]
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
	internal static extern bool IsFontSmoothingEnabled();

	private unsafe static void Internal_CreateFont([Writable] Font self, string name)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					Internal_CreateFont_Injected(self, ref managedSpanWrapper);
					return;
				}
			}
			Internal_CreateFont_Injected(self, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	private unsafe static void Internal_CreateFontFromPath([Writable] Font self, string fontPath)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(fontPath, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(fontPath);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					Internal_CreateFontFromPath_Injected(self, ref managedSpanWrapper);
					return;
				}
			}
			Internal_CreateFontFromPath_Injected(self, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_CreateDynamicFont([Writable] Font self, [Unmarshalled] string[] _names, int size);

	[FreeFunction("TextRenderingPrivate::GetCharacterInfo", HasExplicitThis = true)]
	public bool GetCharacterInfo(char ch, out CharacterInfo info, [DefaultValue("0")] int size, [DefaultValue("FontStyle.Normal")] FontStyle style)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetCharacterInfo_Injected(intPtr, ch, out info, size, style);
	}

	[ExcludeFromDocs]
	public bool GetCharacterInfo(char ch, out CharacterInfo info, int size)
	{
		return GetCharacterInfo(ch, out info, size, FontStyle.Normal);
	}

	[ExcludeFromDocs]
	public bool GetCharacterInfo(char ch, out CharacterInfo info)
	{
		return GetCharacterInfo(ch, out info, 0, FontStyle.Normal);
	}

	public unsafe void RequestCharactersInTexture(string characters, [DefaultValue("0")] int size, [DefaultValue("FontStyle.Normal")] FontStyle style)
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
			if (!StringMarshaller.TryMarshalEmptyOrNullString(characters, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(characters);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					RequestCharactersInTexture_Injected(intPtr, ref managedSpanWrapper, size, style);
					return;
				}
			}
			RequestCharactersInTexture_Injected(intPtr, ref managedSpanWrapper, size, style);
		}
		finally
		{
		}
	}

	[ExcludeFromDocs]
	public void RequestCharactersInTexture(string characters, int size)
	{
		RequestCharactersInTexture(characters, size, FontStyle.Normal);
	}

	[ExcludeFromDocs]
	public void RequestCharactersInTexture(string characters)
	{
		RequestCharactersInTexture(characters, 0, FontStyle.Normal);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_material_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_material_Injected(IntPtr _unity_self, IntPtr value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string[] get_fontNames_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_fontNames_Injected(IntPtr _unity_self, string[] value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_dynamic_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_ascent_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_fontSize_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_characterInfo_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_characterInfo_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_lineHeight_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetDefault_Injected();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasCharacter_Injected(IntPtr _unity_self, int c);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_CreateFont_Injected([Writable] Font self, ref ManagedSpanWrapper name);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_CreateFontFromPath_Injected([Writable] Font self, ref ManagedSpanWrapper fontPath);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetCharacterInfo_Injected(IntPtr _unity_self, char ch, out CharacterInfo info, [DefaultValue("0")] int size, [DefaultValue("FontStyle.Normal")] FontStyle style);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void RequestCharactersInTexture_Injected(IntPtr _unity_self, ref ManagedSpanWrapper characters, [DefaultValue("0")] int size, [DefaultValue("FontStyle.Normal")] FontStyle style);
}
