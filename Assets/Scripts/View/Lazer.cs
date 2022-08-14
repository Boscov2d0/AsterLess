using System;
using UnityEngine;

public class Lazer : Amo
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    private bool _isActive;

    public Transform Transform { get => _transform; }
    public Rigidbody Rigidbody { get => _rigidbody; }
    public float Speed { get => _speed; }
    public int Damage { get => _damage; }
    public float LifeTime { get => _lifeTime; }
    public bool IsActive { get => _isActive; set => _isActive = value; }

    public Action OnTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Asteroid"))
        {
            OnTrigger?.Invoke();
        }
    }
}