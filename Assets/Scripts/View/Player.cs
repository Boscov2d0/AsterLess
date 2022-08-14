using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    [SerializeField] private Transform _torpedoWeapon;
    [SerializeField] private List<Transform> _lazerWeapon;
    [SerializeField] private Transform _transform;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _hitPoints;
    [SerializeField] private float _timeToReloadLazer;
    [SerializeField] private float _timeToReloadTorpedo;
    [SerializeField] private int _damageFromBigAsteroid;
    [SerializeField] private int _damageFromMiddleAsteroid;
    [SerializeField] private int _maxDefense;

    private int _defense;

    public Transform TorpedoWeapon { get => _torpedoWeapon; }
    public List<Transform> LazerWeapon { get => _lazerWeapon; }
    public Transform Transform { get => _transform; }
    public Rigidbody Rigidbody { get => _rigidbody; }
    public float Speed { get => _speed; }
    public float RotationSpeed { get => _rotationSpeed; }
    public float HitPoints { get => _hitPoints; set => _hitPoints = value; }
    public float TimeToReloadLazer { get => _timeToReloadLazer; }
    public float TimeToReloadTorpedo { get => _timeToReloadTorpedo; }
    public int Defense { get => _defense; set => _defense = value; }
    public int MaxDefense { get => _maxDefense; set => _maxDefense = value; }

    public Action<int> OnTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "BigAsteroid")
        {
            OnTrigger?.Invoke(_damageFromBigAsteroid);
        }
        if (other.name == "MiddleAsteroid")
        {
            OnTrigger?.Invoke(_damageFromMiddleAsteroid);
        }
    }
}