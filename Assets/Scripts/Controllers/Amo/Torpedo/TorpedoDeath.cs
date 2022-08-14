using System;
using UnityEngine;

public class TorpedoDeath
{
    private float _lifeTime;
    private float _timer;

    public Action DeathAction;

    public TorpedoDeath(Torpedo bullet)
    {
        _lifeTime = bullet.LifeTime;
        _timer = _lifeTime;
    }

    public void Execute()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        DeathAction?.Invoke();
    }
}