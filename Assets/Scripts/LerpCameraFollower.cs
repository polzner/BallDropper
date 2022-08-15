using UnityEngine;

public class LerpCameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _distance;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _radius;

    private Vector3 _focusPoint;

    private void Start()
    {
        _focusPoint = _target.position;
    }

    private void LateUpdate()
    {
        UpdateTarget();
        Vector3 position = _focusPoint - _camera.transform.forward * _distance;
        Vector3 fixedPosition = new Vector3(_camera.transform.localPosition.x, position.y, position.z);
        _camera.transform.localPosition = fixedPosition;
    }

    private void OnValidate()
    {
        Vector3 position = _target.position - _camera.transform.forward * _distance;
        _camera.transform.localPosition = position;
    }

    private void UpdateTarget()
    {
        float distance = Vector3.Distance(_target.position, _focusPoint);
        float t = 1f;

        if (distance > 0.01f)
        {
            t = Mathf.Pow(1f - 0.8f, Time.deltaTime);
        }
        if (distance > _radius)
        {
            t = Mathf.Min(t, _radius / distance);
        }

        _focusPoint = Vector3.Lerp(_target.position, _focusPoint, t);
    }
}
