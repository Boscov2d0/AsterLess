using UnityEngine;

public class TorpedoMove
{
    private Torpedo _torpedo;
    private Rigidbody _rigidbody;
    private float _speed;
    public TorpedoMove(Torpedo torpedo)
    {
        _torpedo = torpedo;
        _speed = torpedo.Speed;
        _rigidbody = torpedo.Rigidbody;
        _rigidbody.isKinematic = false;
    }
    public void Move()
    {
        _rigidbody.AddForce(_torpedo.transform.forward * _speed, ForceMode.Force);
    }
}