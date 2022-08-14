using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public static IFactory<UFOController> Factory;

    public Action<int> Crash;
}