using UnityEngine;

public class PlayerMove : ObjectsMoveController
{
    private Transform _transform;
    private Rigidbody _rigidbody;
    private float _speed;
    private float _rotationSpeed;

    public PlayerMove(Player player) : base(player)
    {
        _transform = player.Transform;
        _rigidbody = player.Rigidbody;
        _speed = player.Speed;
        _rotationSpeed = player.RotationSpeed;
    }

    public void Rotate(float axeZ) 
    {
        _transform.Rotate(0, _rotationSpeed * axeZ, 0);
    }
    public void MoveFront()
    {
        _rigidbody.velocity = _transform.forward * _speed;
        _rigidbody.AddForce(_transform.forward * _speed);// = _transform.forward * _speed;
    }
}