using UnityEngine;

public class AsteroidDeath
{
    public Asteroid _asteroid;
    private int _health;
    private int _currentHealth;

    public AsteroidDeath(Asteroid asteroid) 
    {
        _health = asteroid.Health;
        _currentHealth = asteroid.CurrentHealth;
        _currentHealth = _health;
        _asteroid = asteroid;
    }
    public bool Death(int value)
    {
        Debug.Log(_currentHealth);
        _currentHealth -= value;
        if (_currentHealth > 0)
        {
            Debug.Log(">");
            return true;
            
        }
        else
        {
            return false;
        }
    }
    public void Init() 
    {
        _currentHealth = _health;
    }
}