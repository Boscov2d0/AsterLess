using UnityEngine;

public class Asteroid : Unit
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private int _bigDamage;

    private int _currentHealth;
    private bool _isActive;

    public Transform Transform { get => _transform; }
    public Rigidbody Rigidbody { get => _rigidbody; }
    public Collider Collider { get => _collider; }
    public int Health { get => _health; set => _health = value; }
    public float Speed { get => _speed; }
    public int CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public bool IsActive { get => _isActive; set => _isActive = value; }

    public void Test()
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (TryGetComponent(out Unit unit) || TryGetComponent(out Amo amo))
        {
            Crash?.Invoke(_bigDamage);
        }
    }
}