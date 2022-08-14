using System;
using UnityEngine;

using Random = UnityEngine.Random;

public class UFOController : IController
{
    private UFO _ufo;
    private UFOMove _ufoMove;
    private UFOShoot _ufoShoot;
    private UFODeath _ufoDeath;
    private Collider _collider;
    private int _health;
    private bool _isActive;
    
    public Action<GameObject> Destroy;
    public bool IsActive { get => _isActive; set => _isActive = value; }
    public UFOController(UFO ufo)
    {
        _collider = ufo.Collider;
        _health = ufo.Health;
        _ufo = ufo;
        _ufo.CurrentHealth = _health;
        _ufo.Crash += Crash;
        _ufoMove = new UFOMove(_ufo);
        _ufoMove.Move();
        _ufoDeath = new UFODeath(_ufo);
        _ufoShoot = new UFOShoot(_ufo);
    }
    public void Execute()
    {
        if (IsActive)
        {
            _ufoMove.CheckPosition();
            _ufoShoot.Execute();
        }
    }
    private void Crash(int value)
    {
        IsActive = _ufoDeath.Death(value);
        if (!IsActive)
        {
            Destroy?.Invoke(_ufo.Transform.gameObject);
            _collider.enabled = false;
            _ufo.gameObject.SetActive(false);
        }
    }
    public void Init()
    {
        _ufoDeath.Init();
        _ufo.Transform.position = new Vector3(Random.Range(GlobalBase.Left.x, GlobalBase.Right.x), 0, Random.Range(GlobalBase.Top.z, GlobalBase.Down.z));
        IsActive = true;
        _collider.enabled = true;
        _ufo.gameObject.SetActive(true);
    }
}