using UnityEngine;

namespace Turrel
{
    internal sealed class GameObjectVisualBuilder : GameObjectBuilder
    {
        public GameObjectVisualBuilder(GameObject gameObject) : base(gameObject)
        { }
        public GameObjectVisualBuilder Name(string name)
        {
            _gameObject.name = name;
            return this;
        }
        public GameObjectVisualBuilder MeshFilter(GameObject prefab)
        {
            var component = GetOrAddComponent<MeshFilter>();
            component.mesh = Instantiate(prefab.GetComponent<MeshFilter>().sharedMesh);
            return this;
        }
        public GameObjectVisualBuilder MeshRenderer()
        {
            var component = GetOrAddComponent<MeshRenderer>();
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