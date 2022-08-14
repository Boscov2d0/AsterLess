using UnityEngine;

namespace Turrel
{
    public class BulletMove
    {
        private Bullet _bullet;
        private Rigidbody _rigidbody;
        private float _speed;
        public BulletMove(Bullet bullet)
        {
            _bullet = bullet;
            _speed = bullet.Speed;
            _rigidbody = bullet.Rigidbody;
            _rigidbody.isKinematic = false;
        }
        public void Move()
        {
            _rigidbody.AddForce(_bullet.transform.forward * _speed, ForceMode.Impulse);
        }
    }
}