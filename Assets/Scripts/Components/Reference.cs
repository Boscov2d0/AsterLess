using UnityEngine;
using UnityEngine.UI;

public class Reference
{
    private GameObject _player;
    private GameObject _shield;
    private Camera _camera;
    private Light _directionLight;

    private Canvas _canvas;
    private GameObject _gameUIPanel;
    private GameObject _gameOverPanel;
    private Button _buttonRestart;
    private Text _pointsText;

    public GameObject Player
    {
        get
        {
            if (_player == null)
            {
                GameObject _playerPrefab = Resources.Load<GameObject>("Player");
                _player = Object.Instantiate(_playerPrefab);
            }
            return _player;
        }
    }
    public GameObject Shield
    {
        get
        {
            if (_shield == null)
            {
                GameObject _shieldPrefab = Resources.Load<GameObject>("Shield");
                _shield = Object.Instantiate(_shieldPrefab);
            }
            return _shield;
        }
    }
    public Camera Camera
    {
        get
        {
            if (_camera == null)
            {
                Camera _cameraPrefab = Resources.Load<Camera>("MainCamera");
                _camera = Object.Instantiate(_cameraPrefab);
            }
            return _camera;
        }
    }
    public Light DirectionLight
    {
        get
        {
            if (_directionLight == null)
            {
                Light _directionLightPrefab = Resources.Load<Light>("Directional Light");
                _directionLight = Object.Instantiate(_directionLightPrefab);
            }
            return _directionLight;
        }
    }
    public Canvas Canvas
    {
        get
        {
            if (_canvas == null)
            {
                Canvas _canvasPrefab = Resources.Load<Canvas>("UI/Canvas");
                _canvas = Object.Instantiate(_canvasPrefab);
            }
            return _canvas;
        }
    }
    public GameObject GameUIPanel
    {
        get
        {
            if (_gameUIPanel == null)
            {
                GameObject _gameOUIPanelPrefab = Resources.Load<GameObject>("UI/PanelGameUI");
                _gameUIPanel = Object.Instantiate(_gameOUIPanelPrefab, Canvas.transform);
            }
            return _gameUIPanel;
        }
    }
    public Text PointsText
    {
        get
        {
            if (_pointsText == null)
            {
                Text _pointsTextPrefab = Resources.Load<Text>("UI/PointsNumber");
                _pointsText = Object.Instantiate(_pointsTextPrefab, _gameUIPanel.transform);
            }
            return _pointsText;
        }
    }
    public GameObject GameOverPanel
    {
        get
        {
            if (_gameOverPanel == null)
            {
                GameObject _gameOverPanelPrefab = Resources.Load<GameObject>("UI/GameOverPanel");
                _gameOverPanel = Object.Instantiate(_gameOverPanelPrefab, Canvas.transform);
            }
            return _gameOverPanel;
        }
    }
    public Button ButtonRestart
    {
        get
        {
            if (_buttonRestart == null)
            {
                Button _buttonRestartPrefab = Resources.Load<Button>("UI/RestartButton");
                _buttonRestart = Object.Instantiate(_buttonRestartPrefab, Canvas.transform);
            }
            return _buttonRestart;
        }
    }
}
