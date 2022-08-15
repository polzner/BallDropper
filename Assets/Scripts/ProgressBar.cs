using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Transform _playerPoint;
    [SerializeField] private float _distance;
    [SerializeField] private Transform _finishPoint;

    private Vector3 _startPoint;


    private void Start()
    {
        _startPoint = _finishPoint.position - Vector3.one * _distance;
    }

    private void Update()
    {
        float movedDistance = _playerPoint.position.y - _startPoint.y;
        float normalizedValue = movedDistance / _distance;
        _slider.value = normalizedValue;
    }
}
