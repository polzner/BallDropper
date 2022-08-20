using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable, IPauseHandler
{
    [SerializeField] private DelayedObjectDisbler _disabler;
    [SerializeField] private MeshSwitcher _meshesVisibleSwitcher;
    [SerializeField] private List<ParticleSystem> _particleSystems = new List<ParticleSystem>();

    private void Awake()
    {
        PauseManager.Instance.Register(this);
    }

    public void Accept(IDamagableVisitor visitor)
    {
        visitor.Visit(this);
    }

    public void Disable()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        _disabler.Disable();
        _meshesVisibleSwitcher.SetActive(false);
        ActivateEffects(_particleSystems);
    }

    public void Enable()
    {
        gameObject.GetComponent<Collider>().enabled = true;
        _meshesVisibleSwitcher.SetActive(true);
    }

    public void SetPaused(bool isPaused)
    {
        gameObject.GetComponent<Animator>().enabled = !isPaused;
    }

    private void ActivateEffects(List<ParticleSystem> particleSystems)
    {
        foreach (var particle in particleSystems)
        {
            particle.Play();
        }
    }
}
