using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 10;

    private bool _isPaused => PauseManager.Instance.IsPaused;

    private void Update()
    {
        if (_isPaused)
            return;

        transform.position += Vector3.up * Time.deltaTime * _speed;
    }
}
