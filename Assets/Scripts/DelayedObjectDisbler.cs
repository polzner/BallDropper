using System.Collections;
using UnityEngine;

public class DelayedObjectDisbler : MonoBehaviour
{
    [SerializeField] private float _delay;

    public void Disable()
    {
        StartCoroutine(DisableRoutine(_delay));
    }

    private IEnumerator DisableRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
