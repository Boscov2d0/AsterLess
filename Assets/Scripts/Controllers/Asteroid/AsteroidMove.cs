using UnityEngine;

public class AsteroidMove : ObjectsMoveController, IMove
{
    private Rigidbody _rigidbody;
    private float _speed;
    private float _x;
    private float _z;

    public AsteroidMove(Asteroid asteroid) : base(asteroid)
    {
        _rigidbody = asteroid.Rigidbody;
        _speed = asteroid.Speed;
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
