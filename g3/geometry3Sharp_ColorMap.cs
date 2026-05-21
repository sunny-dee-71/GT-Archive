using System.Collections.Generic;

namespace g3;

public class ColorMap
{
	private struct ColorPoint
	{
		public float t;

		public Colorf c;
	}

	private List<ColorPoint> points = new List<ColorPoint>();

	private Interval1d validRange;

	public ColorMap()
	{
		validRange = Interval1d.Empty;
	}

	public ColorMap(float[] t, Colorf[] c)
	{
		validRange = Interval1d.Empty;
		for (int i = 0; i < t.Length; i++)
		{
			AddPoint(t[i], c[i]);
		}
	}

	public void AddPoint(float t, Colorf c)
	{
		ColorPoint colorPoint = new ColorPoint
		{
			t = t,
			c = c
		};
		if (points.Count == 0)
		{
			points.Add(colorPoint);
			validRange.Contain(t);
			return;
		}
		if (t < points[0].t)
		{
			points.Insert(0, colorPoint);
			validRange.Contain(t);
			return;
		}
		for (int i = 0; i < points.Count; i++)
		{
			if (points[i].t == t)
			{
				points[i] = colorPoint;
				return;
			}
			if (points[i].t > t)
			{
				points.Insert(i, colorPoint);
				return;
			}
		}
		points.Add(colorPoint);
		validRange.Contain(t);
	}

	public Colorf Linear(float t)
	{
		if (t <= points[0].t)
		{
			return points[0].c;
		}
		int count = points.Count;
		if (t >= points[count - 1].t)
		{
			return points[count - 1].c;
		}
		for (int i = 1; i < points.Count; i++)
		{
			if (points[i].t > t)
			{
				ColorPoint colorPoint = points[i - 1];
				ColorPoint colorPoint2 = points[i];
				float num = (t - colorPoint.t) / (colorPoint2.t - colorPoint.t);
				return (1f - num) * colorPoint.c + num * colorPoint2.c;
			}
		}
		return points[count - 1].c;
	}
}
