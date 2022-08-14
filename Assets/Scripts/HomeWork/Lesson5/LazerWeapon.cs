using System.Collections.Generic;
using UnityEngine;

public class LazerWeapon : IAttack
{
    private List<Transform> _lazerWeapon;
    private List<LazerContoller> _lazerContollers;
    private int _index;
    private float _reloadLizerTime;
    private float _timerLazer;
    private bool _canFireLizer = true;

    AmoFactory factory;

    public LazerWeapon(Player player)
    {
        factory = new AmoFactory();
        _lazerWeapon = player.LazerWeapon;
        _lazerContollers = new List<LazerContoller>();
        _reloadLizerTime = player.TimeToReloadLazer;
        _timerLazer = _reloadLizerTime;
    }

    public void Execute()
    {
        if (!_canFireLizer)
        {
            Reload();
        }

        for (int i = 0; i < _lazerContollers.Count; i++)
        {
            if (_lazerContollers[i].IsActive)
            {
                _lazerContollers[i].Execute();
            }
        }
    }
    public void Shoot()
    {
        if (_canFireLizer)
        {
            if (_index >= _lazerWeapon.Count)
            {
                _index = 0;
            }
            _canFireLizer = false;
            LazerContoller lazerContoller = factory.CreateLazer(_lazerWeapon[_index]);
            lazerContoller.Shoot(_lazerWeapon[_index]);
            _index++;
            _lazerContollers.Add(lazerContoller);
        }
    }
    public void Reload()
    {
        _timerLazer -= Time.deltaTime;
        if (_timerLazer <= 0)
        {
            _canFireLizer = true;
            _timerLazer = _reloadLizerTime;
        }
    }
}