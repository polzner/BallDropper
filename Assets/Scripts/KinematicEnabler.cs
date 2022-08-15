using UnityEngine;

public class KinematicEnabler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rigidbody))
            rigidbody.isKinematic = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rigidbody))
            rigidbody.isKinematic = false;
    }
}
