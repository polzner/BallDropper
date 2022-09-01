using UnityEngine;
using System.Collections;

public class FinishedPlayerMover : MonoBehaviour
{
    [SerializeField] private BezierMover _mover;
    [SerializeField] private Transform _finishPosePoint;

    public void Move()
    {
        Vector3 secondPoint = transform.position + ((_finishPosePoint.position - transform.position) / 2 + Vector3.up * 5);
        transform.SetParent(null);
        _mover.Move(transform.position, secondPoint, _finishPosePoint.position);
    }

    private void OnDrawGizmos()
    {
        float count = 20f;
        Vector3 previousPoint = transform.position;
        Vector3 secondPoint = transform.position + ((_finishPosePoint.position - transform.position) / 2 + Vector3.up * 5);

        for (int i = 0; i < count; i++)
        {
            Vector3 current = _mover.GetBezierCurvePoint(transform.position, secondPoint, _finishPosePoint.position, (float)i / count);
            Gizmos.DrawLine(previousPoint, current);
            previousPoint = current;
        }
    }
}
