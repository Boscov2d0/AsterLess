using System.Collections.Generic;
using UnityEngine;

internal sealed class UserInterface : MonoBehaviour
{
    [SerializeField] private PanelMenu _panelMenu;
    [SerializeField] private PanelSettings _panelSettings;
    private readonly Stack<StateUI> _stateUi = new Stack<StateUI>();
    private BaseUi _currentWindow;

    private void Start()
    {
        _panelMenu.Cancel();
        _panelSettings.Cancel();
    }
    private void Execute(StateUI stateUI, bool isSave = true)
    {
        if (_currentWindow != null)
        {
            _currentWindow.Cancel();
        }
        switch (stateUI)
        {
            case StateUI.PanelGame:
                _currentWindow = _panelMenu;
                break;
            case StateUI.PanelSettings:
                _currentWindow = _panelSettings;
                break;
            default:
                break;
        }
        _currentWindow.Execute();
        if (isSave)
        {
            _stateUi.Push(stateUI);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            OpenMenu();
        }
    }

    
    public void OpenSettings() 
    {
        _panelMenu.Cancel();
        Execute(StateUI.PanelSettings);
    }
    public void OpenMenu()
    {
        _panelSettings.Cancel();
        Execute(StateUI.PanelGame);
    }
    public void Continue()
    {
        _panelMenu.Cancel();
        Time.timeScale = 1;
    }
}
