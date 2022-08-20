using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectsPool _enemyPool;
    [SerializeField] private float _maxTime;
    [SerializeField] private float _minTime;
    [SerializeField] private Transform _minPoint;
    [SerializeField] private Transform _maxPoint;

    private bool _isPaused => PauseManager.Instance.IsPaused;

    private void Start()
    {
        StartCoroutine(SpawnRoutine(_maxTime, _minTime));
    }

    private IEnumerator SpawnRoutine(float maxTime, float minTime)
    {
        while (!_isPaused)
        {
            if (_enemyPool.TryGetObject(out GameObject enemy))
            {
                enemy.GetComponent<Enemy>().Enable();
                enemy.transform.position = new Vector3(Random.Range(_minPoint.position.x, _maxPoint.position.x),
                    _minPoint.position.y, _minPoint.position.z);
            }

            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }
}
