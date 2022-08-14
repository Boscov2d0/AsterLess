using UnityEngine;

internal interface IModification
{
    Transform BarrelPosition { get; }
    GameObject Instance { get; }
}