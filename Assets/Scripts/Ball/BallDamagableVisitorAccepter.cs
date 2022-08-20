using UnityEngine;

public class BallDamagableVisitorAccepter : MonoBehaviour
{
    [SerializeField] private ObjectsPool _ballPool;
    [SerializeField] private DamagableVisitor _damagableVisitor;

    private void OnEnable()
    {
        _ballPool.PoolFilled += OnPoolFilled;
    }

    private void OnDisable()
    {
        foreach (var ball in _ballPool.Objects)
        {
            ball.GetComponent<Ball>().Collised -= OnBallCollised;
        }

        _ballPool.PoolFilled -= OnPoolFilled;
    }

    private void OnPoolFilled()
    {
        foreach (var ball in _ballPool.Objects)
            ball.GetComponent<Ball>().Collised += OnBallCollised;
    }

    private void OnBallCollised(IDamagable damagable)
    {
        damagable.Accept(_damagableVisitor);
    }
}
