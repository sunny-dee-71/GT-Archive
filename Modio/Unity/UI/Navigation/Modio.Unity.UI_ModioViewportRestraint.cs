using System.Collections;
using UnityEngine;

namespace Modio.Unity.UI.Navigation;

public class ModioViewportRestraint : MonoBehaviour
{
	public float PercentPaddingHorizontal = 0.05f;

	public float PercentPaddingVertical = 0.25f;

	public bool adjustHorizontally;

	public bool adjustVertically = true;

	private static float transitionTime = 0.1f;

	public RectTransform Viewport;

	public RectTransform DefaultViewportContainer;

	public RectTransform HorizontalViewportContainer;

	private static readonly Vector3[] CachedFourCornersArray = new Vector3[4];

	private Vector3 _targetPosition;

	private Coroutine _animCoroutine;

	public void ChildSelected(RectTransform ensureFits)
	{
		GetWorldAABB(ensureFits, out var min, out var max);
		GetWorldAABB(Viewport, out var min2, out var max2);
		Vector3 vector = DefaultViewportContainer.position - _targetPosition;
		min2 += vector;
		max2 += vector;
		Vector3 vector2 = max2 - min2;
		Vector3 vector3 = new Vector3(vector2.x * PercentPaddingHorizontal, vector2.y * PercentPaddingVertical);
		Vector3 vector4 = Vector3.Max(Vector3.zero, max - (max2 - vector3));
		Vector3 vector5 = Vector3.Min(Vector3.zero, min - (min2 + vector3));
		Vector3 vector6 = vector4 + vector5 + vector;
		vector6.z = 0f;
		if (!adjustHorizontally)
		{
			vector6.x = 0f;
		}
		if (!adjustVertically)
		{
			vector6.y = 0f;
		}
		if (!(vector6.sqrMagnitude < 1f))
		{
			_targetPosition = DefaultViewportContainer.position - vector6;
			if (_animCoroutine != null)
			{
				StopCoroutine(_animCoroutine);
			}
			_animCoroutine = StartCoroutine(Transition(DefaultViewportContainer));
		}
		static void GetWorldAABB(RectTransform rectTransform, out Vector3 reference, out Vector3 reference2)
		{
			rectTransform.GetWorldCorners(CachedFourCornersArray);
			reference = Vector3.one * float.MaxValue;
			reference2 = Vector3.one * float.MinValue;
			Vector3[] cachedFourCornersArray = CachedFourCornersArray;
			foreach (Vector3 rhs in cachedFourCornersArray)
			{
				reference = Vector3.Min(reference, rhs);
				reference2 = Vector3.Max(reference2, rhs);
			}
		}
	}

	private IEnumerator Transition(Transform parent)
	{
		Vector2 startPos = parent.position;
		for (float t = 0f; t < 1f; t += Time.unscaledDeltaTime / transitionTime)
		{
			parent.position = Vector3.Lerp(startPos, _targetPosition, t);
			yield return null;
			if (!adjustHorizontally)
			{
				startPos.x = (_targetPosition.x = parent.position.x);
			}
		}
		parent.position = _targetPosition;
		_animCoroutine = null;
	}
}
