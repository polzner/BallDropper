using System.Collections;
using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private TrailRenderer _trailRenderer;
    [SerializeField] private float _speed = 25;
    [SerializeField] private float _delay = 0.15f;

    private Coroutine _moveCoroutine;

    public Action<IDamagable> Collised;

    public void Move()
    {
        _trailRenderer.emitting = true;
        _moveCoroutine = StartCoroutine(MoveRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        _trailRenderer.emitting = false;
        StartCoroutine(DisableRoutine(_delay));

        if (other.TryGetComponent(out IDamagable damagable))
            Collised?.Invoke(damagable);
    }

    private IEnumerator MoveRoutine()
    {
        Vector3 currentPosition = transform.position;
        Vector3 velocity = -Vector3.up;

        while (true)
        {
            velocity += -Vector3.up * _speed * Time.deltaTime;
            currentPosition += velocity * Time.deltaTime;
            transform.position = currentPosition;
            yield return null;
        }
    }

    private IEnumerator DisableRoutine(float delay)
    {
        float time = 0f;
        Vector3 startScale = transform.localScale;

        while (time <= delay)
        {
            transform.localScale = Vector3.Lerp(startScale, Vector3.zero, time / delay);
            time += Time.deltaTime;
            yield return null;
        }

        if (_moveCoroutine != null)
            StopCoroutine(_moveCoroutine);

        gameObject.SetActive(false);
    }
}
