using UnityEngine;

public class LazerMove
{
    private Lazer _lazer;
    private Rigidbody _rigidbody;
    private float _speed;
    public LazerMove(Lazer lazer)
    {
        _lazer = lazer;
        _speed = lazer.Speed;
        _rigidbody = lazer.Rigidbody;
        _rigidbody.isKinematic = false;
    }
    public void Move()
    {
        _rigidbody.AddForce(_lazer.transform.forward * _speed, ForceMode.Impulse);
    }
}