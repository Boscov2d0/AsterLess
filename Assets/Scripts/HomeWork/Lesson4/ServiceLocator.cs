using System;
using System.Collections.Generic;
using UnityEngine;

namespace Turrel
{

    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, Pool> _serviceŅontainer =
        new Dictionary<Type, Pool>();
        public static Pool GetService<T>(GameObject prefab) where T : class
        {
            var typeValue = typeof(T);

            if (!_serviceŅontainer.ContainsKey(typeValue))
            {
                var viewPool = new Pool(prefab);
                _serviceŅontainer[typeValue] = viewPool;
            }


            return _serviceŅontainer[typeValue];
        }
        
        public static void Return<T>(GameObject value2)
        {
            var typeValue = typeof(T);
            _serviceŅontainer[typeValue].Push(value2);

            /*
            var type = typeof(T);
            if (_serviceŅontainer.ContainsKey(type))
            {
                return (T)_serviceŅontainer[type];
            }
            else 
            {
                SetService<T>(value);
                Resolve<T>(value);
                return (T)_serviceŅontainer[type];
            }
            //return default;*/
        }
    }
}