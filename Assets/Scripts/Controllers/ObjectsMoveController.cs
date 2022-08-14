using UnityEngine;

public class ObjectsMoveController
{
    private Transform _transform;

    public ObjectsMoveController(Unit unit)
    {
        _transform = unit.transform;
    }
    public void CheckPosition()
    {
        if (_transform.position.x > GlobalBase.Right.x)
        {
            _transform.position = new Vector3(GlobalBase.Left.x, 0, _transform.position.z);
        }
        if (_transform.position.x < GlobalBase.Left.x)
        {
            _transform.position = new Vector3(GlobalBase.Right.x, 0, _transform.position.z);
        }
        if (_transform.position.z > GlobalBase.Top.z)
        {
            _transform.position = new Vector3(_transform.position.x, 0, GlobalBase.Down.z);
        }
        if (_transform.position.z < GlobalBase.Down.z)
        {
            _transform.position = new Vector3(_transform.position.x, 0, GlobalBase.Top.z);
        }
    }
}
