using System;
using UnityEngine;

using Random = UnityEngine.Random;

public class AsteroidController : IController
{
    private Asteroid _asteroid;
    private AsteroidDeath _asteroidDeath;
    private Collider _collider;
    private int _health;
    private bool _isActive;

    public Action<GameObject> Destroy;
    public bool IsActive { get => _isActive; set => _isActive = value; }

    private IMove _move;

    public AsteroidController(Asteroid asteroid, IMove move)
    {
        _collider = asteroid.Collider;
        _health = asteroid.Health;
        _asteroid = asteroid;
        _asteroid.CurrentHealth = _health;
        _asteroid.Crash += Crash;

        _asteroidDeath = new AsteroidDeath(_asteroid);

        _move = move;
        _move.Move();
    }

    public void Execute()
    {
        if (IsActive)
        {
            _move.CheckPosition();
        }
    }

    private void Crash(int value)
    {
        IsActive = _asteroidDeath.Death(value);
        
        if (!IsActive)
        {
            Debug.Log("FAASLESE");
            _collider.enabled = false;
            _asteroid.gameObject.SetActive(false);
            Destroy?.Invoke(_asteroid.Transform.gameObject);
        }
    }
    public void Init()
    {
        _asteroidDeath.Init();
        _asteroid.Transform.position = new Vector3(Random.Range(GlobalBase.Left.x, GlobalBase.Right.x), 0, Random.Range(GlobalBase.Top.z, GlobalBase.Down.z));
        IsActive = true;
        _collider.enabled = true;
        _asteroid.gameObject.SetActive(true);
    }
}