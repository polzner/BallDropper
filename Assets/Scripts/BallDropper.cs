using System.Collections;
using UnityEngine;

public class BallDropper : MonoBehaviour, IPauseHandler
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private ObjectsPool _ballPool;
    [SerializeField] private float _delay;
    [SerializeField] private float _spawnBallScalingTime = 0.16f;
    [SerializeField] private float _dropBallScalingTime = 0.2f;
    [Range(0,1)] [SerializeField] private float _ballInHandScale = 0.7f;

    private GameObject _ball;
    private Vector3 _standartScale;
    private bool _readyToDrop = true;
    private Coroutine _currentCoroutine;

    private PauseManager _pauseManager => PauseManager.Instance;
    private bool _isPaused => _pauseManager.IsPaused;

    private void Start()
    {
        _pauseManager.Register(this);
        _standartScale = _ballPool.TryGetObject(out GameObject ball) ? ball.transform.localScale : Vector3.one;
        ball.SetActive(false);
        StartCoroutine(SpawnNewBallRoutine(_delay, _standartScale * _ballInHandScale));
    }

    private void Update()
    {
        if (_isPaused)
            return;

        if (Input.GetMouseButtonDown(0) && _readyToDrop && _ball.activeSelf)
        {
            Ball ball = _ball.GetComponent<Ball>();
            StartCoroutine(DropBallRoutine(_dropBallScalingTime, _standartScale, ball));
            ball.Move();
            _readyToDrop = false;
            _currentCoroutine = StartCoroutine(DelayRoutine(_delay, _spawnBallScalingTime));
        }
    }

    private IEnumerator DropBallRoutine(float time, Vector3 scale, Ball ball)
    {
        float currentTime = 0;

        while (currentTime < time + 0.1f)
        {
            ball.transform.localScale = Vector3.Lerp(_ball.transform.localScale, scale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator SpawnNewBallRoutine(float time, Vector3 scale)
    {
        if (_ballPool.TryGetObject(out GameObject ball))
        {
            Vector3 startScale;
            float currentTime = 0;

            _ball = ball;
            _ball.transform.position = _startPoint.position;
            _ball.transform.localScale = startScale = Vector3.zero;

            while (currentTime < time + 0.1f)
            {
                _ball.transform.localScale = Vector3.Lerp(startScale, scale, currentTime / time);
                currentTime += Time.deltaTime;
                yield return null;
            }
        }
    }

    private IEnumerator DelayRoutine(float delay, float spawnBallDelay)
    {
        yield return new WaitForSeconds(delay * 0.8f);
        _currentCoroutine = StartCoroutine(SpawnNewBallRoutine(spawnBallDelay, _standartScale * _ballInHandScale));
        yield return new WaitForSeconds(delay * 0.2f);
        _readyToDrop = true;
    }

    public void SetPaused(bool isPaused)
    {
        if (isPaused)
        {
            if(_currentCoroutine != null)
                StopCoroutine(_currentCoroutine);

            _ball.SetActive(false);
        }
    }
}
