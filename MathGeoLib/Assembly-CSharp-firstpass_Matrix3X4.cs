using JetBrains.Annotations;

namespace MathGeoLib;

[PublicAPI]
public struct Matrix3X4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23)
{
	public readonly float M00 = m00;

	public readonly float M01 = m01;

	public readonly float M02 = m02;

	public readonly float M03 = m03;

	public readonly float M10 = m10;

	public readonly float M11 = m11;

	public readonly float M12 = m12;

	public readonly float M13 = m13;

	public readonly float M20 = m20;

	public readonly float M21 = m21;

	public readonly float M22 = m22;

	public readonly float M23 = m23;

	public override string ToString()
	{
		return string.Format("{0}: {1}, ", "M00", M00) + string.Format("{0}: {1}, ", "M01", M01) + string.Format("{0}: {1}, ", "M02", M02) + string.Format("{0}: {1}, ", "M03", M03) + string.Format("{0}: {1}, ", "M10", M10) + string.Format("{0}: {1}, ", "M11", M11) + string.Format("{0}: {1}, ", "M12", M12) + string.Format("{0}: {1}, ", "M13", M13) + string.Format("{0}: {1}, ", "M20", M20) + string.Format("{0}: {1}, ", "M21", M21) + string.Format("{0}: {1}, ", "M22", M22) + string.Format("{0}: {1}", "M23", M23);
	}
}
