using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;

    private bool _isPaused => PauseManager.Instance.IsPaused;

    private void Update()
    {
        if(_isPaused)
            return;

        float xDelta = Input.GetAxisRaw("Mouse X");
        _playerMover.Move(xDelta);
    }
}
