using UnityEngine;

public class EnemyDisabler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.gameObject.SetActive(false);
        }
    }
}
