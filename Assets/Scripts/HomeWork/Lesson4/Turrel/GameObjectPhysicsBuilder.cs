using UnityEngine;

namespace Turrel
{
    internal sealed class GameObjectPhysicsBuilder : GameObjectBuilder
    {
        private Transform _transform;
        private Rigidbody _rigidbody;

        public GameObjectPhysicsBuilder(GameObject gameObject) : base(gameObject) { }
        public GameObjectPhysicsBuilder Collider()
        {
            GetOrAddComponent<CapsuleCollider>();
            return this;
        }
        public GameObjectPhysicsBuilder Transform()
        {
            var component = GetOrAddComponent<Transform>();
            _transform = component;
            return this;
        }
        public GameObjectPhysicsBuilder Rigidbody()
        {
            var component = GetOrAddComponent<Rigidbody>();
            component.useGravity = false;
            _rigidbody = component;
            return this;
        }
        
        public GameObjectPhysicsBuilder Bullet()
        {
            var component = GetOrAddComponent<Bullet>();
            component.Transform = _transform;
            component.Rigidbody = _rigidbody;
            component.Damage = 1;
            component.Speed = 50f;
            component.LifeTime = 5f;
            return this;
        }
        private T GetOrAddComponent<T>() where T : Component
        {
            var result = _gameObject.GetComponent<T>();
            if (!result)
            {
                result = _gameObject.AddComponent<T>();
            }
            return result;
        }
    }
}