using System;
using UnityEngine;

public class TorpedoController
{
    private TorpedoMove _moveController;
    private TorpedoDeath _bulletDeath;
    private Torpedo _torpedo;
    private Transform _transform;
    private Rigidbody _rigidbody;
    private bool _isActive;

    public Transform Transform { get => _transform; set => _transform = value; }
    public bool IsActive { get => _isActive; set => _isActive = value; }
    public Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }

    public Action<GameObject> Destroy;

    public TorpedoController(Torpedo torpedo) 
    {
        _torpedo = torpedo;
        _isActive = torpedo.IsActive;
        _torpedo.OnTrigger += Death;
        Transform = torpedo.Transform;
        _rigidbody = torpedo.Rigidbody;
        _moveController = new TorpedoMove(torpedo);
        _moveController.Move();
        _bulletDeath = new TorpedoDeath(torpedo);
        _bulletDeath.DeathAction += Death;
    }
    public void Execute() 
    {
        _bulletDeath.Execute();
    }
    public void Death() 
    {
        _isActive = false;
        _torpedo.gameObject.SetActive(_isActive);
        _rigidbody.isKinematic = true;
        Destroy?.Invoke(_torpedo.gameObject);
    }
    public void Init() 
    {
        _isActive = true;
        _torpedo.gameObject.SetActive(_isActive);
        _rigidbody.isKinematic = false;
        _moveController.Move();
    }
}