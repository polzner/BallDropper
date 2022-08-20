using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _moveSpeedScale = 10;
    [SerializeField] private float _maxRightXPosition;
    [SerializeField] private float _maxLeftXPosition;


    public void Move(float xDelta)
    {        
        _player.transform.position += new Vector3(xDelta * Time.deltaTime * _moveSpeedScale, 0, 0);
        _player.transform.position = new Vector3(Mathf.Clamp(_player.transform.position.x, _maxLeftXPosition, _maxRightXPosition),
            _player.transform.position.y, _player.transform.position.z);
    }
}
