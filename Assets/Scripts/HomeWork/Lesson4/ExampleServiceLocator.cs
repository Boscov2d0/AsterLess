using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class ExampleServiceLocator : MonoBehaviour
{
    [SerializeField] float _reloadTime;
    private float _time;
    private List<Turrel.BulletController> _bulletController = new List<Turrel.BulletController>();

    private void Update()
    {
        /*
        Reload();

        for (int i = 0; i < _bulletController.Count; i++)
        {
            if (_bulletController[i].IsActive)
            {
                _bulletController[i].Execute();
            }
        }*/
    }
    private void Shoot()
    {
        //GameObject _object = ServiceLocatorMonoBehaviour.GetService<GameObject>(Resources.Load<GameObject>("Bullet"));
        //ServiceLocator.Resolve<Pool>();
        //Turrel.BulletController bulletController = Create();
        //_bulletController.Add(bulletController);
    }
    private void Reload()
    {
        _time -= Time.deltaTime;
        if (_time <= 0)
        {
            Shoot();
            _time = _reloadTime;
        }
    }
    /*
    public Turrel.BulletController Create()
    {
        //Bullet bullet = viewServices.Instantiate<Bullet>(Resources.Load<GameObject>("Bullet"));
        
        Bullet bullet = ServiceLocator.Resolve<Bullet>();
        bullet.Transform.position = startPosition.position;
        bullet.Transform.rotation = startPosition.rotation;
        BulletController bulletController = new BulletController(bullet);
        bulletController.Destroy += Death;
        bulletController.Init();
        return bulletController;
    }*/
}