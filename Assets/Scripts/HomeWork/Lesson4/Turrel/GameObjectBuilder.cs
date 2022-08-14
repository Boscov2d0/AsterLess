using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turrel
{
    internal class GameObjectBuilder : MonoBehaviour
    {
        protected GameObject _gameObject;
        public GameObjectBuilder() => _gameObject = new GameObject();
        protected GameObjectBuilder(GameObject gameObject) => _gameObject =
        gameObject;
        public GameObjectVisualBuilder Visual => new GameObjectVisualBuilder(_gameObject);

        public GameObjectPhysicsBuilder Physics => new
        GameObjectPhysicsBuilder(_gameObject);

        public static implicit operator GameObject(GameObjectBuilder builder)
        {
            return builder._gameObject;
        }
    }
}