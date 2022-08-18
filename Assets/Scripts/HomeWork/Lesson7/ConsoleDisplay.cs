using UnityEngine;

public sealed class ConsoleDisplay : IDealingDamage
{
    public void Visit(AsteroidFactory hit)
    {
        Debug.Log($"Asteroid was create");
    }
    public void Visit(UFOFactory hit)
    {
        Debug.Log($"UFO was create");
    }
}