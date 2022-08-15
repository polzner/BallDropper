using UnityEngine;
using Cinemachine;

public class CamerasPriorityChanger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private int _priority;

    public void SwitchCameras()
    {
        _camera.Priority = _priority;
    }
}
