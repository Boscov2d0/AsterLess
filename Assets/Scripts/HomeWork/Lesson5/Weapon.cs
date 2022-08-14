using UnityEngine;

internal sealed class Weapon : IFire
{
    private Transform _barrelPosition;
    Vector3 _position;
    private IAmmunition _bullet;
    private float _force;

    public Weapon(IAmmunition bullet, Transform barrelPosition, float force)
    {
        _bullet = bullet;
        _barrelPosition = barrelPosition;
        _position = _barrelPosition.position;
        _force = force;
    }
    public void SetBarrelPosition(Transform barrelPosition, Vector3 position)
    {
        _barrelPosition = barrelPosition;
        _position = position;
    }
    public void SetBullet(IAmmunition bullet)
    {
        _bullet = bullet;
    }
    public void SetForce(float force)
    {
        _force = force;
    }
    public void Fire()
    {
        var bullet = Object.Instantiate(_bullet.BulletInstance,
        _position, _barrelPosition.rotation);
        bullet.AddForce(_barrelPosition.forward * _force);
        Object.Destroy(bullet.gameObject, _bullet.TimeToDestroy);
    }
}