using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class TimeBody
{
    private Button _buttonP;
    private Button _buttonN;
    private float _recordTime;
    private List<PointInTime> _pointsInTime;
    private Transform _transform;
    private Rigidbody _rb;
    private bool _isRewinding;

    public TimeBody(GameObject gameObject, float recordTime, Button buttonP, Button buttonN) 
    {
        _pointsInTime = new List<PointInTime>();
        _rb = gameObject.GetComponent<Rigidbody>();
        _transform = gameObject.transform;
        _recordTime = recordTime;
        _buttonP = buttonP;
        _buttonN = buttonN;
        _buttonP.onClick.AddListener(Rewind);
        _buttonN.onClick.AddListener(Record);
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartRewind();
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            StopRewind();
        }
    }
    public void FixedExecute()
    {
        if (_isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }
    private void Rewind()
    {
        if (_pointsInTime.Count > 1)
        {
            PointInTime pointInTime = _pointsInTime[0];
            _transform.position = pointInTime.Position;
            _transform.rotation = pointInTime.Rotation;
            _pointsInTime.RemoveAt(0);
        }
        else
        {
            PointInTime pointInTime = _pointsInTime[0];
            _transform.position = pointInTime.Position;
            _transform.rotation = pointInTime.Rotation;
            StopRewind();
        }
    }
    private void Record()
    {
        if (_pointsInTime.Count > Mathf.Round(_recordTime /
        Time.fixedDeltaTime))
        {
            _pointsInTime.RemoveAt(_pointsInTime.Count - 1);
        }
        _pointsInTime.Insert(0, new PointInTime(_transform.position,
        _transform.rotation, _rb.velocity, _rb.angularVelocity));
    }
    private void StartRewind()
    {
        _isRewinding = true;
        _rb.isKinematic = true;
    }
    private void StopRewind()
    {
        _isRewinding = false;
        _rb.isKinematic = false;
        _rb.velocity = _pointsInTime[0].Velocity;
        _rb.angularVelocity = _pointsInTime[0].AngularVelocity;
    }
}