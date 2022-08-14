using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Collider _collider;
    [SerializeField] private int _value;

    public Transform Transform { get => _transform; set => _transform = value; }
    public Collider Collider { get => _collider; set => _collider = value; }
    public int Value { get => _value; set => _value = value; }
}
