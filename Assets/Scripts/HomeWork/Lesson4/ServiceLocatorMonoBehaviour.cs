using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocatorMonoBehaviour
{
    private static readonly Dictionary<object, object> _servicecontainer = new Dictionary<object, object>();

    public static T GetService<T>(GameObject prefab, bool createObjectIfNotFound = true) where
    T : Object
    {
        if (!_servicecontainer.ContainsKey(typeof(T)))
        {
            return FindService<T>(prefab, createObjectIfNotFound);
        }
        var service = (T)_servicecontainer[typeof(T)];
        if (service != null)
        {
            return service;
        }
        _servicecontainer.Remove(typeof(T));
        return FindService<T>(prefab, createObjectIfNotFound);
    }
    private static T FindService<T>(GameObject prefab, bool createObjectIfNotFound = true)
    where T : Object
    {
        T type = Object.FindObjectOfType<T>();
        if (type != null)
        {
            _servicecontainer.Add(typeof(T), type);
        }
        else if (createObjectIfNotFound)
        {
            //var go = new GameObject(typeof(T).Name, typeof(T));
            var go = Object.Instantiate(prefab);
            _servicecontainer.Add(typeof(T), go.GetComponent<T>());
        }
        return (T)_servicecontainer[typeof(T)];
    }
}
