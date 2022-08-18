using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

using Random = UnityEngine.Random;
internal sealed class PlayerController : IUnit
{
    private Player _player;
    private PlayerMove _playerMove;
    private PlayerShoot _playerShoot;
    private PlayerLife _playerLife;
    private string[] _type = new string[2];
    private int _index;
    public Action DeathEvent;

    private List<IAbility> _ability;

    Drift _drift;
    ControlFliying _controlFliying;

    public PlayerController(Player player, List<IAbility> ability)
    {
        _player = player;
        _playerMove = new PlayerMove(player);
        _playerShoot = new PlayerShoot(player, new LazerWeapon(player), new TorpedoWeeapon(player));
        _playerLife = new PlayerLife(player);
        _playerLife.Death += Death;
        player.OnTrigger += HealthChange;
        player.Transform.position = Vector3.zero;
        _type[0] = "Lazer";
        _type[1] = "Torpedo";
        _ability = ability;

        _drift = new Drift();
        _controlFliying = new ControlFliying();
    }

    public IAbility this[int index] => _ability[index];
    public int MaxDamage => _ability.Select(a => a.Damage).Max();

    public void Execute()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _playerMove.MoveFront();
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            _playerMove.Rotate(Input.GetAxis("Horizontal"));
        }

        if (Input.GetAxis("Fire1") != 0)
        {
            _playerShoot.Shoot(_type[_index]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            _index = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _index = 1;
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            _drift.Movement(_player);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            _controlFliying.Movement(_player);
        }

        _playerMove.CheckPosition();
        _playerShoot.Execute();
    }

    public void HealthChange(int value) 
    {
        _playerLife.Damage(value);
    }

    public void Death() 
    {
        DeathEvent?.Invoke();
    }

    public IEnumerable<IAbility> GetAbility()
    {
        while (true)
        {
            yield return _ability[Random.Range(0, _ability.Count)];
        }
    }
    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < _ability.Count; i++)
        {
            yield return _ability[i];
        }
    }
    public IEnumerable<IAbility> GetAbility(AbilityType index)
    {
        foreach (IAbility ability in _ability)
        {
            if (ability.AbilityType == index)
            {
                yield return ability;
            }
        }
    }
}