using System;
using UnityEngine;

using Random = UnityEngine.Random;

internal sealed class AsteroidFactory : IFactory<AsteroidController>
{
    ViewServices viewServices;
    private string[] _type = new string[3];
    private int _index;

    IMessageBroker messageBrokerImpl;
    Asteroid asteroid;

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

        asteroid = viewServices.Instantiate<Asteroid>(Resources.Load<GameObject>(_type[_index]));
        MessagePayload<string> messagePayload = new MessagePayload<string>("Asteroid destroy", asteroid);
        messageBrokerImpl = MessageBrokerImpl.Instance;
        messageBrokerImpl.Subscribe<string>(TestMessage());
        messageBrokerImpl.Publish<string>(asteroid, "AAAAAAAAAAAAA");
        asteroid.action += TestMessage();
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
    private Action<MessagePayload<string>> TestMessage() 
    {
        return asteroid.action;
    }
}