using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Block : MonoBehaviour, IDamagable, IPauseHandler
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        PauseManager.Instance.Register(this);
    }

    public void Accept(IDamagableVisitor visitor)
    {
        visitor.Visit(this);
    }

    public void SetPaused(bool isPaused)
    {
        //_rigidbody.isKinematic = isPaused;
    }
}
