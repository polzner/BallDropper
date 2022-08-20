using System.Collections;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerBlock;
    [SerializeField] private Rigidbody _player;
    [SerializeField] private GameObject _blockPrefab;
    [SerializeField] private Transform _blockContainer;
    [SerializeField] private float _headBlockDistance = 2f;
    [SerializeField] private float _moveTime = 0.2f;
    [SerializeField] private float _spawnDelay = 0.1f;
    [SerializeField] private float _spawnOffset = 0.2f;
    [SerializeField] private LevelCreator _levelCreator;
    [SerializeField] private AnimationCurve _curve;

    private Transform _previousBlockTransform;
    private Vector3 _nextPosition;
    private bool _canMove = false;

    private void Start()
    {
        _previousBlockTransform = _levelCreator.UpperBlock.transform;
        _nextPosition = _playerBlock.position;
    }

    private void FixedUpdate()
    {
        if(_canMove)
            _playerBlock.MovePosition(_nextPosition);
    }

    public void Spawn()
    {
        StartCoroutine(MovePlayerBlockRoutine(_moveTime));
        StartCoroutine(SpawnBlockRoutine(_spawnDelay));
    }

    private IEnumerator MovePlayerBlockRoutine(float time)
    {
        _canMove = true;

        _playerBlock.useGravity = false;
        _player.useGravity = false;

        Vector3 startPosition = _playerBlock.position;
        Vector3 targetPosition = _playerBlock.position + Vector3.up * _headBlockDistance;
        float currentTime = 0;

        while (currentTime <= time)
        {
            _nextPosition = Vector3.Lerp(startPosition, targetPosition, _curve.Evaluate(currentTime / time));
            currentTime += Time.deltaTime;
            yield return null;
        }
        _playerBlock.useGravity = true;
        _player.useGravity = true;

        _canMove = false;
    }

    private IEnumerator SpawnBlockRoutine(float delay)
    {
        Vector3 blockPosition = _previousBlockTransform.position + Vector3.up * _spawnOffset;
        yield return new WaitForSeconds(delay);
        GameObject block = Instantiate(_blockPrefab, blockPosition, Quaternion.identity, _blockContainer);
        block.GetComponent<Animation>().Play();
        _previousBlockTransform = block.transform;
    }
}
