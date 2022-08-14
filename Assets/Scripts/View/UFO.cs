using UnityEngine;

public class UFO : Unit
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;
    [SerializeField] private Transform _lazerWeapon;
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToReloadLazer;

    [SerializeField] private int _damageFromObjects;
    [SerializeField] private int _damageFromTorpedo;

    private int _currentHealth;
    private bool _isActive;

    public Transform Transform { get => _transform; }
    public Rigidbody Rigidbody { get => _rigidbody; }
    public Collider Collider { get => _collider; }
    public Transform LazerWeapon { get => _lazerWeapon; }
    public int Health { get => _health; }
    public float Speed { get => _speed; }
    public float TimeToReloadLazer { get => _timeToReloadLazer; }
    public int CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public bool IsActive { get => _isActive; set => _isActive = value; }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Asteroid"))
        {
            Crash?.Invoke(_damageFromObjects);
        }
        if (other.CompareTag("Torpedo"))
        {
            Crash?.Invoke(_damageFromTorpedo);
        }
    }
}
