using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public static IFactory<Unit> Factory;
    public float Health { get; protected set; }
    public static Asteroid CreateAsteroidEnemy()
    {
        var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
        return enemy;
    }
    public void DependencyInjectHealth()
    { 
    }

}
