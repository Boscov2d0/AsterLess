using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIController
{
    Reference _reference = new Reference();
    private Canvas _canvas;
    private GameObject _GameUIPanel;
    private GameObject _GameOverPanel;
    private Text _pointsText;
    private Button _restartButton;
    private Camera _camera;
    private float _points = 2132.21f;

    public UIController()
    {
        _camera = _reference.Camera;
        _canvas = _reference.Canvas;
        _GameUIPanel = _reference.GameUIPanel;
        _GameUIPanel.transform.SetParent(_canvas.transform);
        _GameOverPanel = _reference.GameOverPanel;
        _GameOverPanel.transform.SetParent(_canvas.transform);
        _GameOverPanel.SetActive(false);
        _pointsText = _reference.PointsText;
        _pointsText.transform.SetParent(_GameUIPanel.transform);
        _restartButton = _reference.ButtonRestart;
        _restartButton.transform.SetParent(_GameOverPanel.transform);
        _restartButton.onClick.AddListener(RestartGame);

        SetScreenBorders();
        ShowPoints();
    }

    public void GameOver()
    {
        _GameOverPanel.SetActive(true);
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    private void SetScreenBorders()
    {
        GlobalBase.Top = _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight + 4, 0));
        GlobalBase.Down = _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth / 2, -4, 0));
        GlobalBase.Left = _camera.ScreenToWorldPoint(new Vector3(-4, _camera.pixelHeight / 2, 0));
        GlobalBase.Right = _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth + 4, _camera.pixelHeight / 2, 0));
    }
    private void ShowPoints()
    {
        _pointsText.text = Interpreter(_points);
    }
    private string Interpreter(float number)
    {
        if ((number < 0) || (number > 999999999999))
            throw new ArgumentOutOfRangeException(nameof(number), "insert value betwheen 1 and 3999");

        if (number < 1) return string.Empty;
        if (number >= 1000000) return Interpreter((int)number / 1000000) + "M";
        if (number >= 1000)
        {
            return Interpreter((int)number / 1000) + "K";
        }
        else 
        {
            return ((int)number).ToString();
        }
        throw new ArgumentOutOfRangeException(nameof(number));
    }
}