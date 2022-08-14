using System.Collections.Generic;
using UnityEngine;

namespace Turrel
{
    public class TurrelController
    {
        Transform _strartPosition;
        GameObject _prefab;
        private float _speed;
        private float _reloadTime;
        private float _time;

        Factory factory;

        List<BulletController> _bulletController = new List<BulletController>();

        public TurrelController(Turrel turrel)
        {
            factory = new Factory();
            _strartPosition = turrel.StrartPosition;
            _speed = turrel.BulletSpeed;
            _prefab = Resources.Load<GameObject>("Bullet");
            _reloadTime = turrel.TimeToReload;
            _time = _reloadTime;
        }
        public void Execute()
        {
            Reload();

            for (int i = 0; i < _bulletController.Count; i++)
            {
                if (_bulletController[i].IsActive)
                {
                    _bulletController[i].Execute();
                }
            }
        }

        private void Shoot()
        {
            BulletController bulletController = factory.Create(_strartPosition);
            _bulletController.Add(bulletController);
        }
        private void Reload()
        {
            _time -= Time.deltaTime;
            if (_time <= 0)
            {
                Shoot();
                _time = _reloadTime;
            }
        }
    }
}