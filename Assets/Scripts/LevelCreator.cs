using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private GameObject _startBlock;
    [SerializeField] private Transform _playerStartPosition;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _finishBlock;
    [SerializeField] private GameObject _blockPrefab;
    [SerializeField] private GameObject _playerBlock;
    [SerializeField] private int _startQuantity;
    [SerializeField] private int _distanceToFinish;
    [SerializeField] private float _yOffset;
    [SerializeField] private float _zOffset;


    private GameObject _upperBlock;

    public GameObject UpperBlock => _upperBlock;

    private void Awake()
    {
        Vector3 yOffset = Vector3.up * _startBlock.GetComponent<Collider>().bounds.size.y;
        Vector3 currentPosition = _startBlock.transform.position + yOffset;
        GameObject block = null;

        for (int i = 0; i < _startQuantity; i++)
        {
            block = Instantiate(_blockPrefab, currentPosition, Quaternion.identity);
            block.transform.SetParent(_startBlock.transform);
            currentPosition = block.transform.position + yOffset;
        }

        _upperBlock = block;
        _playerBlock.transform.position = currentPosition;
        _player.transform.position = _playerStartPosition.position;

        currentPosition += yOffset * _distanceToFinish + (Vector3.up * _startBlock.GetComponent<Collider>().bounds.size.y)
            + (Vector3.forward * _zOffset);
        _finishBlock.transform.position = currentPosition;
    }
}
