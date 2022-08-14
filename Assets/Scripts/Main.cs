using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private float _createAsteroidsTimer;
    [SerializeField] private float _createUFOTimer;

    private Reference _reference;

    private Player _player;
    private Camera _camera;
    private Light _directionLight;

    private Shield _shield;

    private PlayerController _playerController;
    private UIController _UIController;

    private float _asteroidsTimer;
    private float _ufoTimer;

    GameService gameService;

    PlayerModifier root;

    float time = 0;
    int timer = 0;

    private void Awake()
    {
        Time.timeScale = 1;
        _asteroidsTimer = _createAsteroidsTimer;
        _ufoTimer = _createUFOTimer;
        _reference = new Reference();

        _player = _reference.Player.GetComponent<Player>();
        _directionLight = _reference.DirectionLight;
        _shield = _reference.Shield.GetComponent<Shield>();
        _shield.transform.position = new Vector3(10,0,0);
        _shield.GetShield += ModPlayer;

        Ability();


        _UIController = new UIController();

        _playerController.DeathEvent += GameOver;

        gameService = new GameService(_createAsteroidsTimer, _createUFOTimer);

        root = new PlayerModifier(_player);
    }

    void Update()
    {
        _playerController.Execute();
        gameService.Start();
    }
    void TimerTest()
    {
        time += Time.deltaTime;
        timer = (int)time;
        Debug.Log(timer);
        if (timer / _asteroidsTimer == 0)
        {
            Debug.Log("CreateAsteroid");
        }
        if (timer % _ufoTimer == 0)
        {
            Debug.Log("CreateUFO");
        }
    }

    private void ModPlayer()
    {
        root.Add(new AddDefenseModifier(_player, _player.MaxDefense));
        root.Handle();
    }

    private void GameOver()
    {
        _UIController.GameOver();
        Time.timeScale = 0;
    }

    private void Ability()
    {
        var ability = new List<IAbility>
        {
            new Ability("Inner Fire", 100, AbilityType.Magical),
            new Ability("Burning Spear", 200, AbilityType.Magical),
            new Ability("Berserker's Blood", 300, AbilityType.None),
            new Ability("Life Break", 400, AbilityType.Magical),
        };

        _playerController = new PlayerController(_player, ability);
        
        //IUnit enemy = new IUnit(ability);
        Debug.Log(_playerController[0]);
        Debug.Log(new string('+', 50));
        Debug.Log(new string('+', 50));
        Debug.Log(new string('+', 50));
        Debug.Log(_playerController.MaxDamage);
        Debug.Log(new string('+', 50));

        foreach (var item in _playerController)
        {
            Debug.Log(item);
        }

        Debug.Log(new string('+', 50));

        foreach (var item in _playerController.GetAbility().Take(2))
        {
            Debug.Log(item);
        }

        Debug.Log(new string('+', 50));

        foreach (var item in _playerController.GetAbility(AbilityType.Magical))
        {
            Debug.Log(item);
        }
    }
}