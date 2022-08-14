using System;
using System.Collections.Generic;
using UnityEngine;

namespace Turrel
{

    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, Pool> _service—ontainer =
        new Dictionary<Type, Pool>();
        public static Pool GetService<T>(GameObject prefab) where T : class
        {
            var typeValue = typeof(T);

            if (!_service—ontainer.ContainsKey(typeValue))
            {
                var viewPool = new Pool(prefab);
                _service—ontainer[typeValue] = viewPool;
            }


            return _service—ontainer[typeValue];
        }
        
        public static void Return<T>(GameObject value2)
        {
            var typeValue = typeof(T);
            _service—ontainer[typeValue].Push(value2);

            /*
            var type = typeof(T);
            if (_service—ontainer.ContainsKey(type))
            {
                return (T)_service—ontainer[type];
            }
            else 
            {
                SetService<T>(value);
                Resolve<T>(value);
                return (T)_service—ontainer[type];
            }
            //return default;*/
        }
    }
}