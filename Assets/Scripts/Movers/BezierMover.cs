using System.Collections;
using UnityEngine;

[ExecuteAlways]
public class BezierMover : MonoBehaviour
{
    [SerializeField] private float _time;

    public void Move(Vector3 firstPoint, Vector3 secondPoint, Vector3 thirdPoint)
    {
        StartCoroutine(MoveBezierCurveRoutine(firstPoint, secondPoint, thirdPoint, _time));
    }

    private IEnumerator MoveBezierCurveRoutine(Vector3 firstPoint, Vector3 secondPoint, Vector3 thirdPoint, float time)
    {
        float currentTime = 0;

        while (currentTime < time + 0.1f)
        {
            float value = Mathf.Clamp01(currentTime / time);
            transform.position = GetBezierCurvePoint(firstPoint, secondPoint, thirdPoint, value);
            currentTime += Time.deltaTime;
            yield return null;
        }
    }

    public Vector3 GetBezierCurvePoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        Vector3 p0p1 = (1 - t) * p0 + t * p1;
        Vector3 p1p2 = (1 - t) * p1 + t * p2;
        Vector3 result = (1 - t) * p0p1 + t * p1p2;
        return result;
    }
}
