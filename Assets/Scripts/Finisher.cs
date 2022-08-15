using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Finisher : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private List<Rig> _rigs;
    [SerializeField] private CamerasPriorityChanger _camerasSwitcher;
    [SerializeField] private FinishedPlayerMover _mover;
    [SerializeField] private Transform _finishPoint;
    
    private bool _isFinished = false;

    private PauseManager _pauseManager => PauseManager.Instance;

    private void Update()
    {
        if (transform.position.y >= _finishPoint.position.y && !_isFinished)
        {
            Finish();
        }
    }

    private void Finish()
    {
        StartCoroutine(DelayMoveRoutine(0.2f));
        _camerasSwitcher.SwitchCameras();
        _isFinished = true;
        ResetRigs(_rigs);
        _pauseManager.SetPaused(true);

        void ResetRigs(List<Rig> rigs) => rigs.ForEach((rig) => rig.weight = 0);
    }

    private IEnumerator DelayMoveRoutine(float delay)
    {
        yield return new WaitForSeconds(delay * 2f);
        _playerAnimator.SetTrigger("Flip");
        yield return new WaitForSeconds(delay);
        _mover.Move();
    }
}
