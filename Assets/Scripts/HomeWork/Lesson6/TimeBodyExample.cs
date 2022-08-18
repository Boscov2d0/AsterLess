using UnityEngine;
using UnityEngine.UI;

public class TimeBodyExample : MonoBehaviour
{
    [SerializeField] private Button _buttonP;
    [SerializeField] private Button _buttonN;
    [SerializeField] private float _recordTime;
    [SerializeField] private GameObject _gameObject;

    private TimeBody _timeBody;

    private void Awake()
    {
        _timeBody = new TimeBody(_gameObject, _recordTime, _buttonP, _buttonN);
    }

    private void Update()
    {
        _timeBody.Execute();
    }
    private void FixedUpdate()
    {
        _timeBody.FixedExecute();
    }
}