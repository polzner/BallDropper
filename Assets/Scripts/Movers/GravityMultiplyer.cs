using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityMultiplyer : MonoBehaviour
{
    [SerializeField] private float _minFallSpeed = -1f;
    [SerializeField] private float _gravityMultiplyer = 3f;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
     
    private void FixedUpdate()
    {
        if (_rigidbody.velocity.y < _minFallSpeed)
            _rigidbody.AddForce(Vector3.down * _gravityMultiplyer * Time.deltaTime, ForceMode.Acceleration);
    }
}
