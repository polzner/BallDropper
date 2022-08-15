using System.Collections.Generic;
using System;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _capacity;
    [SerializeField] private Transform _parent;

    private List<GameObject> _objects = new List<GameObject>();

    public IEnumerable<GameObject> Objects => _objects;

    public Action PoolFilled;

    private void Start()
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject gameObject = Instantiate(_prefab, _parent);
            gameObject.SetActive(false);
            _objects.Add(gameObject);
        }

        PoolFilled?.Invoke();
    }

    public bool TryGetObject(out GameObject gameObject)
    {
        gameObject = null;

        foreach (var item in _objects)
        {
            if (!item.activeSelf)
            {
                gameObject = item;
                gameObject.SetActive(true);
                return true;
            }
        }

        return false;
    }
}
