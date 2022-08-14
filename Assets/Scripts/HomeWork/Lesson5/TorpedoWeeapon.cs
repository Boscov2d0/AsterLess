using System.Collections.Generic;
using UnityEngine;

public class TorpedoWeeapon : IAttack
{
    private Transform _torpedoWeapon;
    private List<TorpedoController> _torpedoControllers;
    private float _reloadTorpedoTime;
    private float _timerTorpedo;
    private bool _canFireTorpedo = true;

    AmoFactory factory;

    public TorpedoWeeapon(Player player)
    {
        factory = new AmoFactory();
        _torpedoWeapon = player.TorpedoWeapon;
        _torpedoControllers = new List<TorpedoController>();
        _reloadTorpedoTime = player.TimeToReloadTorpedo;
        _timerTorpedo = _reloadTorpedoTime;
    }
    public void Execute()
    {
        if (!_canFireTorpedo)
        {
            Reload();
        }

        for (int i = 0; i < _torpedoControllers.Count; i++)
        {
            if (_torpedoControllers[i].IsActive)
            {
                _torpedoControllers[i].Execute();
            }
        }

    }
    public void Reload()
    {
        _timerTorpedo -= Time.deltaTime;
        if (_timerTorpedo <= 0)
        {
            _canFireTorpedo = true;
            _timerTorpedo = _reloadTorpedoTime;
        }
    }
    public void Shoot()
    {
        if (_canFireTorpedo)
        {
            _canFireTorpedo = false;
            TorpedoController torpedoController = factory.CreateTorpedo(_torpedoWeapon);
            _torpedoControllers.Add(torpedoController);
        }
    }
}