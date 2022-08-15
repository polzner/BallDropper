using System.Collections.Generic;
using UnityEngine;

public class MeshSwitcher : MonoBehaviour
{
    [SerializeField] private List<SkinnedMeshRenderer> _objects = new List<SkinnedMeshRenderer>();

    public void SetActive(bool enabled)
    {
        foreach (var mesh in _objects)
        {
            mesh.enabled = enabled;
        }
    }
}
