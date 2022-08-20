using UnityEngine;

public class BlockSpeedModifier : MonoBehaviour
{
    [SerializeField] private float _fallMultiplier = 2.5f;

    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.useGravity = false;
    }

    private void FixedUpdate()
    {
        Vector3 gravity = Physics.gravity.y * _fallMultiplier * Vector3.up;

        
        _rigidBody.AddForce(gravity, ForceMode.Acceleration);
    }
}
