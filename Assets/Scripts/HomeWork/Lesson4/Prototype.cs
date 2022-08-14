using UnityEngine;

internal sealed class Prototype : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Collider _collider;
    [SerializeField] private int _value;

    public Prototype Clone()
    {
        Prototype newObject = default;
        newObject = new GameObject(name).AddComponent<Prototype>();
        if (gameObject.TryGetComponent<SphereCollider>(out var sphereCollider))
        {
            var sphereColliderNew = newObject.gameObject.AddComponent<SphereCollider>();
            sphereColliderNew.radius = sphereCollider.radius;
        }
        if (gameObject.TryGetComponent<MeshRenderer>(out var meshRenderer))
        {
            var meshRendererNew = newObject.gameObject.AddComponent<MeshRenderer>();
            meshRendererNew.material = meshRenderer.material;
        }
        if (gameObject.TryGetComponent<MeshFilter>(out var meshFilter))
        {
            var meshFilterNew = newObject.gameObject.AddComponent<MeshFilter>();
            meshFilterNew.mesh = meshFilter.mesh;
        }

        newObject._value = _value;
        newObject.transform.position = new Vector3(transform.position.x,
            transform.position.y + 1, transform.position.z);
        return newObject;
    }
}
