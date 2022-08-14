using System;
using System.Collections.Generic;
using UnityEngine;

using Object = UnityEngine.Object;

public class Pool : IDisposable
{
    private readonly Stack<GameObject> _stack = new Stack<GameObject>();
    private readonly GameObject _prefab;
    private readonly Transform _root;

    public Pool(GameObject prefab)
    {
        _prefab = prefab;
        _root = new GameObject($"[{_prefab.name}]").transform;
    }

    public GameObject Pop()
    {
        GameObject gameObject;
        if (_stack.Count == 0)
        {
            gameObject = Object.Instantiate(_prefab);
            gameObject.name = _prefab.name;
        }
        else
        {
            gameObject = _stack.Pop();
        }
        gameObject.transform.SetParent(_root);
        return gameObject;
    }

    public void Push(GameObject gameObject)
    {
        _stack.Push(gameObject);
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
