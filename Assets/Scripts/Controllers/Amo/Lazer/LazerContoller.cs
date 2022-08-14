using System;
using UnityEngine;

public class LazerContoller
{
    private LazerMove _lazerMove;
    private LazerDeath _lazerDeath;
    private LazerShoot _lazerShoot;
    private Lazer _lazer;
    private Transform _transform;
    private Rigidbody _rigidbody;
    private bool _isActive;

    public Transform Transform { get => _transform; set => _transform = value; }
    public bool IsActive { get => _isActive; set => _isActive = value; }
    public Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }

    public Action<GameObject> Destroy;

    public LazerContoller(Lazer lazer)
    {
        _lazer = lazer;
        _isActive = lazer.IsActive;
        _lazer.OnTrigger += Death;
        Transform = lazer.Transform;
        _rigidbody = lazer.Rigidbody;
        _lazerMove = new LazerMove(lazer);
        _lazerMove.Move();
        _lazerDeath = new LazerDeath(lazer);
        _lazerDeath.DeathAction += Death;
        _lazerShoot = new LazerShoot(lazer);
    }
    public void Execute()
    {
        _lazerDeath.Execute();
    }
    public void Death()
    {
        _isActive = false;
        _lazer.gameObject.SetActive(_isActive);
        _rigidbody.isKinematic = true;
        Destroy?.Invoke(_lazer.gameObject);
    }
    public void Shoot(Transform position) 
    {
        _lazerShoot.Shoot(position);
    }
    public void Init()
    {
        _isActive = true;
        _lazer.gameObject.SetActive(_isActive);
        _rigidbody.isKinematic = false;
        _lazerMove.Move();
    }
}