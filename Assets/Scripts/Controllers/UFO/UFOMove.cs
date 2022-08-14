using UnityEngine;

public class UFOMove : ObjectsMoveController
{
    private Rigidbody _rigidbody;
    private float _speed;
    private float _x;
    private float _z;

    public UFOMove(UFO ufo) : base(ufo)
    {
        _rigidbody = ufo.Rigidbody;
        _speed = ufo.Speed;
    }
    public void Move()
    {
        SetDirection();
        _rigidbody.AddForce(new Vector3(_x, 0, _z) * _speed);
    }
    private void SetDirection()
    {
        _x = Random.Range(-1f, 1f);
        _z = Random.Range(-1f, 1f);
    }
}