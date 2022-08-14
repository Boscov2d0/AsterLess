using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turrel
{
    public class BulletController
    {
        private BulletMove _moveController;
        private BulletDeath _bulletDeath;
        private Bullet _bullet;
        private Transform _transform;
        private Rigidbody _rigidbody;
        private bool _isActive;

        public Transform Transform { get => _transform; set => _transform = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }

        public Action<GameObject> Destroy;

        public BulletController(Bullet bullet)
        {
            _bullet = bullet;
            _isActive = bullet.IsActive;
            _bullet.OnTrigger += Death;
            Transform = bullet.Transform;
            _rigidbody = bullet.Rigidbody;
            _moveController = new BulletMove(bullet);
            _moveController.Move();
            _bulletDeath = new BulletDeath(bullet);
            _bulletDeath.DeathAction += Death;
        }
        public void Execute()
        {
            _bulletDeath.Execute();
        }
        public void Death()
        {
            _isActive = false;
            _bullet.gameObject.SetActive(_isActive);
            _rigidbody.isKinematic = true;
            Destroy?.Invoke(_bullet.gameObject);
        }
        public void Init()
        {
            _isActive = true;
            _bullet.gameObject.SetActive(_isActive);
            _rigidbody.isKinematic = false;
            _moveController.Move();
        }
    }
}
