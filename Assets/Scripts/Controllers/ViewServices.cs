using System;
using System.Collections.Generic;
using UnityEngine;

internal sealed class ViewServices : IViewServices
{
    private readonly Dictionary<string, Pool> _viewCache
        = new Dictionary<string, Pool>(12);

    public T Instantiate<T>(GameObject prefab)
    {
        if (!_viewCache.TryGetValue(prefab.name, out Pool viewPool))
        {
            viewPool = new Pool(prefab);
            _viewCache[prefab.name] = viewPool;
        }

        if (viewPool.Pop().TryGetComponent(out T component))
        {
            return component;
        }

        throw new InvalidOperationException($"{typeof(T)} not found");
    }

    public void Destroy(GameObject value)
    {
        _viewCache[value.name].Push(value);
    }
}