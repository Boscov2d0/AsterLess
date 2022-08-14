using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turrel
{
    public class Factory : MonoBehaviour
    {
        ViewServices viewServices;

        public Factory()
        {
            viewServices = new ViewServices();
        }

        public BulletController Create(Transform startPosition)
        {
            Bullet bullet = viewServices.Instantiate<Bullet>(Resources.Load<GameObject>("Bullet"));
            bullet.Transform.position = startPosition.position;
            bullet.Transform.rotation = startPosition.rotation;
            BulletController bulletController = new BulletController(bullet);
            bulletController.Destroy += Death;
            bulletController.Init();
            return bulletController;
        }

        private void Death(GameObject objcet)
        {
            viewServices.Destroy(objcet);
        }
    }
}