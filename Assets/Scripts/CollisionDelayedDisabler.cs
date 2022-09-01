using System.Collections;
using UnityEngine;

public class CollisionDelayedDisabler : MonoBehaviour
{
    [SerializeField] private BlockSpawner _blockSpawner;
    [SerializeField] private Collider _playerCollider;
    [SerializeField] private Collider _blockCollider;
    [SerializeField] private float _beforePushDelay;
    [SerializeField] private float _afterPushDelay;
    [SerializeField] private float _force = 100f;

    private void OnEnable()
    {
        _blockSpawner.StartSpawn += DisableCollision;
    }

    private void OnDisable()
    {
        _blockSpawner.StartSpawn -= DisableCollision;
    }

    public void DisableCollision()
    {
        StartCoroutine(DisableColliderRoutine(_playerCollider, _blockCollider, _beforePushDelay, _afterPushDelay, _force));
    }

    private IEnumerator DisableColliderRoutine(Collider first, Collider second, float beforeDelay, float afterDelay, float force)
    {
        Physics.IgnoreCollision(first, second, true);
        yield return new WaitForSeconds(beforeDelay);
        _playerCollider.GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Acceleration);
        yield return new WaitForSeconds(afterDelay);
        Physics.IgnoreCollision(first, second, false);
    }
}
