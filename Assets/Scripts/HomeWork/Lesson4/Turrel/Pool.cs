using System;
using System.Collections.Generic;
using UnityEngine;

using Object = UnityEngine.Object;

namespace Turrel
{
    public class Pool : IDisposable
    {
        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _prefab;
        private readonly Transform _root;

        private GameObjectBuilder _objectBuilder;

        public Pool(GameObject prefab)
        {
            _prefab = prefab;
            _root = new GameObject($"[{_prefab.name}]").transform;
            _objectBuilder = new GameObjectBuilder();
        }

        public GameObject Pop()
        {
            GameObject gameObject;
            if (_stack.Count == 0)
            {
                gameObject = _objectBuilder.Visual.Name(_prefab.name).MeshFilter(_prefab).MeshRenderer().Physics.Transform().Rigidbody().Collider().Bullet();
            }
            else
            {
                gameObject = _stack.Pop();
            }
            gameObject.SetActive(true);
            gameObject.transform.SetParent(_root);
            return gameObject;
        }

        public void Push(GameObject gameObject)
        {
            _stack.Push(gameObject);
            gameObject.SetActive(false);
        }

        public void Dispose()
        {
            for (var i = 0; i < _stack.Count; i++)
            {
                GameObject gameObject = _stack.Pop();
                Object.Destroy(gameObject);
            }
            Object.Destroy(_root.gameObject);
        }
    }
}