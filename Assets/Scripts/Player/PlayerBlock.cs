using UnityEngine;

public class PlayerBlock : MonoBehaviour, IPauseHandler
{
    [SerializeField] private Collider _upCollider;

    private void Awake()
    {
        PauseManager.Instance.Register(this);
    }

    public void SetPaused(bool isPaused)
    {
        _upCollider.enabled = !isPaused;
    }
}
