using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.U2D;

[MovedFrom("UnityEngine.Experimental.U2D")]
[NativeHeader("Modules/SpriteShape/Public/SpriteShapeUtility.h")]
public class SpriteShapeUtility
{
	[FreeFunction("SpriteShapeUtility::Generate")]
	[NativeThrows]
	public unsafe static int[] Generate(Mesh mesh, SpriteShapeParameters shapeParams, ShapeControlPoint[] points, SpriteShapeMetaData[] metaData, AngleRangeInfo[] angleRange, Sprite[] sprites, Sprite[] corners)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		int[] result;
		try
		{
			IntPtr mesh2 = Object.MarshalledUnityObject.Marshal(mesh);
			Span<ShapeControlPoint> span = new Span<ShapeControlPoint>(points);
			fixed (ShapeControlPoint* begin = span)
			{
				ManagedSpanWrapper points2 = new ManagedSpanWrapper(begin, span.Length);
				Span<SpriteShapeMetaData> span2 = new Span<SpriteShapeMetaData>(metaData);
				fixed (SpriteShapeMetaData* begin2 = span2)
				{
					ManagedSpanWrapper metaData2 = new ManagedSpanWrapper(begin2, span2.Length);
					Generate_Injected(mesh2, ref shapeParams, ref points2, ref metaData2, angleRange, sprites, corners, out ret);
				}
			}
		}
		finally
		{
			int[] array = default(int[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[FreeFunction("SpriteShapeUtility::GenerateSpriteShape")]
	[NativeThrows]
	public unsafe static void GenerateSpriteShape(SpriteShapeRenderer renderer, SpriteShapeParameters shapeParams, ShapeControlPoint[] points, SpriteShapeMetaData[] metaData, AngleRangeInfo[] angleRange, Sprite[] sprites, Sprite[] corners)
	{
		IntPtr renderer2 = Object.MarshalledUnityObject.Marshal(renderer);
		Span<ShapeControlPoint> span = new Span<ShapeControlPoint>(points);
		fixed (ShapeControlPoint* begin = span)
		{
			ManagedSpanWrapper points2 = new ManagedSpanWrapper(begin, span.Length);
			Span<SpriteShapeMetaData> span2 = new Span<SpriteShapeMetaData>(metaData);
			fixed (SpriteShapeMetaData* begin2 = span2)
			{
				ManagedSpanWrapper metaData2 = new ManagedSpanWrapper(begin2, span2.Length);
				GenerateSpriteShape_Injected(renderer2, ref shapeParams, ref points2, ref metaData2, angleRange, sprites, corners);
			}
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Generate_Injected(IntPtr mesh, [In] ref SpriteShapeParameters shapeParams, ref ManagedSpanWrapper points, ref ManagedSpanWrapper metaData, AngleRangeInfo[] angleRange, Sprite[] sprites, Sprite[] corners, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GenerateSpriteShape_Injected(IntPtr renderer, [In] ref SpriteShapeParameters shapeParams, ref ManagedSpanWrapper points, ref ManagedSpanWrapper metaData, AngleRangeInfo[] angleRange, Sprite[] sprites, Sprite[] corners);
}
