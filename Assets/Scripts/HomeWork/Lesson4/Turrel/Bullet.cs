using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turrel
{
    public class Bullet : MonoBehaviour
    {  
        private bool _isActive = true;

        public Transform Transform;
        public Rigidbody Rigidbody;
        public float Speed;
        public float Damage;
        public float LifeTime;
        public bool IsActive;

        public Action OnTrigger;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy") || other.CompareTag("Player") || other.CompareTag("Asteroid"))
            {
                OnTrigger?.Invoke();
            }
        }
    }
}