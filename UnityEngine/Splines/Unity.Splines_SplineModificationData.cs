namespace UnityEngine.Splines;

internal struct SplineModificationData(Spline spline, SplineModification modification, int knotIndex, float prevCurveLength, float nextCurveLength)
{
	public readonly Spline Spline = spline;

	public readonly SplineModification Modification = modification;

	public readonly int KnotIndex = knotIndex;

	public readonly float PrevCurveLength = prevCurveLength;

	public readonly float NextCurveLength = nextCurveLength;
}
