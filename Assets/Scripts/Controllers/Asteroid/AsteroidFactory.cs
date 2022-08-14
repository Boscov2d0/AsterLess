using UnityEngine;

internal sealed class AsteroidFactory : IFactory<AsteroidController>
{
    ViewServices viewServices;
    private string[] _type = new string[3];
    private int _index;

    public AsteroidFactory() 
    {
        viewServices = new ViewServices();

        _type[0] = "BigAsteroid";
        _type[1] = "MiddleAsteroid";
        _type[2] = "LittleAsteroid";
    }
    public AsteroidController Create()
    {
        SetType();

        Asteroid asteroid = viewServices.Instantiate<Asteroid>(Resources.Load<GameObject>(_type[_index]));
        AsteroidController asteroidController = new AsteroidController(asteroid, new AsteroidMove(asteroid));
        asteroidController.Destroy += Death;
        asteroidController.Init();
        return asteroidController;
    }
    private void SetType() 
    {
        _index = Random.Range(0, 3);
    }
    private void Death(GameObject objcet)
    {
        viewServices.Destroy(objcet);
    }
}