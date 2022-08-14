using System.Collections.Generic;
using UnityEngine;

public class UFOShoot
{
    private Transform _player;
    private Transform _lazerWeapon;
    private List<LazerContoller> _lazerContollers;
    private float _reloadLizerTime;
    private float _timerLazer;
    private bool _canFireLizer = true;

    AmoFactory factory;

    public UFOShoot(UFO ufo) 
    {
        factory = new AmoFactory();
        _lazerWeapon = ufo.LazerWeapon;
        _lazerContollers = new List<LazerContoller>();
        _reloadLizerTime = ufo.TimeToReloadLazer;
        _timerLazer = _reloadLizerTime;
    }
    public void Execute()
    {
        ShootLazer();

        if (!_canFireLizer)
        {
            ReloadLazer();
        }
    }

    public void ReloadLazer()
    {
        _timerLazer -= Time.deltaTime;
        if (_timerLazer <= 0)
        {
            _canFireLizer = true;
            _timerLazer = _reloadLizerTime;
        }
    }
    private void ShootLazer()
    {
        if (_canFireLizer)
        {
            _canFireLizer = false;
            LazerContoller lazerContoller = factory.CreateLazer(_lazerWeapon);
            lazerContoller.Shoot(_lazerWeapon);
            _lazerContollers.Add(lazerContoller);
        }
    }
}