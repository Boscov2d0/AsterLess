using System;
using UnityEngine;

public class LazerDeath
{
    private float _lifeTime;
    private float _timer;

    public Action DeathAction;

    public LazerDeath(Lazer lazer)
    {
        _lifeTime = lazer.LifeTime;
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