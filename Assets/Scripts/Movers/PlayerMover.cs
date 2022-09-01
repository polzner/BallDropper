using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _moveSpeedScale = 10;
    [SerializeField] private float _maxRightXPosition;
    [SerializeField] private float _maxLeftXPosition;


    public void Move(float xDelta)
    {
        Vector3 nextPosition = _player.transform.localPosition + new Vector3(xDelta * Time.deltaTime * _moveSpeedScale, 0, 0);

        if(nextPosition.x <= _maxRightXPosition && nextPosition.x >= _maxLeftXPosition)
            _player.transform.localPosition = nextPosition;
        //_player.transform.position = new Vector3(Mathf.Clamp(_player.transform.position.x, _maxLeftXPosition, _maxRightXPosition),
        //    _player.transform.position.y, _player.transform.position.z);

        //Vector3 target = _player.transform.position + new Vector3(xDelta * Time.deltaTime * _moveSpeedScale, 0, 0);
        //_player.GetComponent<Rigidbody>().MovePosition(target);
    }
}
