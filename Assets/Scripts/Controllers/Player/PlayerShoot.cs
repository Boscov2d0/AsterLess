using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot
{
    IAttack _lazer;
    IAttack _torpedo;

    public PlayerShoot(Player player, IAttack lazer, IAttack torpedo)
    {
        _lazer = lazer;
        _torpedo = torpedo;
    }
    
    public void Execute()
    {
        _lazer.Execute();
        _torpedo.Execute();
    }
    
    public void Shoot(string type)
    {
        if (type == "Lazer")
        {
            _lazer.Shoot();
        }
        if (type == "Torpedo")
        {
            _torpedo.Shoot();
        }
    }
}