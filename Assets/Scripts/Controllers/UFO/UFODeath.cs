using UnityEngine;

public class UFODeath
{
    public UFO _ufo;
    private int _health;
    private int _currentHealth;

    public UFODeath(UFO ufo) 
    {
        _health = ufo.Health;
        _currentHealth = ufo.CurrentHealth;
        _currentHealth = _health;
        _ufo = ufo;
    }
    public bool Death(int value)
    {
        _currentHealth -= value;
        if (_currentHealth <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void Init()
    {
        _currentHealth = _health;
    }
}