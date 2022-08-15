using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBounce : MonoBehaviour
{
    [SerializeField] private float _depenitrationForce;
    [SerializeField] private float _idleSpeed;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_rigidbody.velocity.y <= _idleSpeed)
        {
            Debug.Log(_rigidbody.velocity.y);
            _rigidbody.AddForce(Vector3.up * _depenitrationForce, ForceMode.VelocityChange);
        }
    }
}
