using UnityEngine;
internal interface IAmmunition
{
    Rigidbody BulletInstance { get; }
    float TimeToDestroy { get; }
}