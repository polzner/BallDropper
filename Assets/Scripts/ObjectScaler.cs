using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        Vector3 distanse = _target.position - transform.position;
        transform.localScale = new Vector3(transform.localScale.x, distanse.y, transform.localScale.z);
    }
}
