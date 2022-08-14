using UnityEngine;

namespace Turrel
{
    public class Turrel : MonoBehaviour
    {
        [SerializeField] private Transform _strartPosition;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _timeToReload;
        public Transform StrartPosition { get => _strartPosition; set => _strartPosition = value; }
        public float BulletSpeed { get => _bulletSpeed; set => _bulletSpeed = value; }
        public float TimeToReload { get => _timeToReload; set => _timeToReload = value; }
    }
}