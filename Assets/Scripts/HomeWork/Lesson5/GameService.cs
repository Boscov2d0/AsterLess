using System.Collections.Generic;
using UnityEngine;

internal sealed class GameService
{
    private List<IController> _asteroidList;
    private List<IController> _activeAsteroidList;
    private List<IController> _ufoList;
    private List<IController> _activeUFOList;

    IFactory<AsteroidController> _asteroidFactory;
    IFactory<UFOController> _ufoFactory;

    private float _asteroidsTimer;
    private float _createAsteroidsTimer;
    private float _ufoTimer;
    private float _createUFOTimer;

    public GameService(float createAsteroidsTimer, float createUFOTimer) 
    {
        _asteroidList = new List<IController>();
        _activeAsteroidList = new List<IController>();
        _ufoList = new List<IController>();
        _activeUFOList = new List<IController>();

        _asteroidFactory = new AsteroidFactory();
        _ufoFactory = new UFOFactory();

        _createAsteroidsTimer = createAsteroidsTimer;
        _createUFOTimer = createUFOTimer;
    }

    public void Start()
    {
        CreateAsteroids();
        CreateUFO();
        SortActive(_asteroidList, _activeAsteroidList);
        SortActive(_ufoList, _activeUFOList);
    }
    private void CreateAsteroids()
    {
        if (_activeAsteroidList.Count <= 10)
        {
            _asteroidsTimer -= Time.deltaTime;
            if (_asteroidsTimer <= 0)
            {
                _asteroidList.Add(_asteroidFactory.Create());
                _asteroidsTimer = _createAsteroidsTimer;
            }
        }
    }
    private void CreateUFO()
    {
        if (_activeUFOList.Count < 2)
        {
            _ufoTimer -= Time.deltaTime;
            if (_ufoTimer <= 0)
            {
                _ufoList.Add(_ufoFactory.Create());
                _ufoTimer = _createUFOTimer;
            }
        }
    }
    private void SortActive(List<IController> list, List<IController> activeList)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].IsActive)
            {
                list[i].Execute();
                if (!activeList.Contains(list[i]))
                {
                    activeList.Add(list[i]);
                }
            }
            else
            {
                if (activeList.Contains(list[i]))
                {
                    activeList.Remove(list[i]);
                }
            }
        }
    }
}