using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour, IDamagable
{
    [SerializeField] private ParticleSystem _explodeEffect;
    [SerializeField] private float _delay = 0.10f;

    public void Accept(IDamagableVisitor visitor)
    {
        visitor.Visit(this);
    }

    public void Explode(IDamagableVisitor damagebleVisitor, Vector3 position)
    {
        
        StartCoroutine(ExplodeRoutine(_delay, damagebleVisitor, position));
    }

    private IEnumerator ExplodeRoutine(float delay, IDamagableVisitor damagebleVisitor, Vector3 position)
    {
        yield return new WaitForSeconds(delay);

        _explodeEffect.Play();
        gameObject.SetActive(false);

        Collider[] colliders = Physics.OverlapBox(position, new Vector3(1, 1, 1));

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.TryGetComponent(out IDamagable damageble))
                damageble.Accept(damagebleVisitor);
        }
    }
}
