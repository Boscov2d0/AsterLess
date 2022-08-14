using UnityEngine;

internal sealed class Muffler : IModification
{
    public Transform BarrelPosition { get; }
    public GameObject Instance { get; }
    public Muffler(Transform barrelPositionMuffler, GameObject mufflerInstance)
    {
        BarrelPosition = barrelPositionMuffler;
        Instance = mufflerInstance;
    }
}