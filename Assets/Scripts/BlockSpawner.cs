using System.Collections;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerBlock;
    [SerializeField] private GameObject _blockPrefab;
    [SerializeField] private Transform _blockContainer;
    [SerializeField] private float _headBlockDistance = 2f;
    [SerializeField] private float _moveTime = 0.2f;
    [SerializeField] private float _spawnDelay = 0.1f;
    [SerializeField] private float _spawnOffset = 0.2f;
    [SerializeField] private LevelCreator _levelCreator;
    [SerializeField] private AnimationCurve _curve;

    private Transform _previousBlockTransform;

    private void Start()
    {
        _previousBlockTransform = _levelCreator.UpperBlock.transform;
    }

    public void Spawn()
    {
        StartCoroutine(MovePlayerBlockRoutine(_moveTime));
        StartCoroutine(SpawnBlockRoutine(_spawnDelay));
    }

    private IEnumerator MovePlayerBlockRoutine(float time)
    {
        _playerBlock.isKinematic = true;
        Vector3 startPosition = _playerBlock.position;
        float currentTime = 0;

        while (currentTime < time + 0.1f)
        {
            _playerBlock.position = Vector3.Lerp(startPosition, _previousBlockTransform.position + Vector3.up * _headBlockDistance, _curve.Evaluate(currentTime/time));
            currentTime += Time.deltaTime;
            yield return null;
        }

        _playerBlock.isKinematic = false;
    }

    private IEnumerator SpawnBlockRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject block = Instantiate(_blockPrefab, (_previousBlockTransform.position +
            Vector3.up * _spawnOffset), Quaternion.identity, _blockContainer);
        block.GetComponent<Animation>().Play();
        _previousBlockTransform = block.GetComponentInChildren<Block>().transform;
    }
}
