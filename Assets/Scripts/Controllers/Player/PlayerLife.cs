using System;

public class PlayerLife
{
    private float _hitPoints;

    public Action Death;
    public PlayerLife(Player player)
    {
        _hitPoints = player.HitPoints;
    }

    public void Damage(float _value) 
    {
        _hitPoints -= _value;
        DeathChecker();
    }
    private void DeathChecker() 
    {
        if (_hitPoints <= 0)
        {
            Death?.Invoke();
        }
    }
}