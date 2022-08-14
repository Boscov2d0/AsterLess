using System;
using UnityEngine;

namespace Turrel
{
    public class BulletDeath
    {
        private Bullet _bullet;

        private float _lifeTime;
        private float _timer;

        public Action DeathAction;

        public BulletDeath(Bullet bullet)
        {
            _bullet = bullet;
            _lifeTime = bullet.LifeTime;
            _timer = _lifeTime;
        }

        public void Execute()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                Death();
            }
        }

        public void Death()
        {
            DeathAction?.Invoke();
        }
    }
}