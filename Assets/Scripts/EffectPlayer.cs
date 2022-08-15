using UnityEngine;

public class EffectPlayer : MonoBehaviour
{
    [SerializeField] private ParticleSystem _confettiEffect;
    [SerializeField] private GameObject _finishImage;
    [SerializeField] private GameObject _finishButton;

    public void PlayEffect()
    {
        _confettiEffect.Play();
        _finishImage.SetActive(true);
        _finishButton.SetActive(true);
    }
}
