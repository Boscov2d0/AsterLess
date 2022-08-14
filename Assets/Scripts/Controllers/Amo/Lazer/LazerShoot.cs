using UnityEngine;

public class LazerShoot
{
    private int _damage;
    private RaycastHit _hit;

    public LazerShoot(Lazer lazer) 
    {
        _damage = lazer.Damage;
    }

    public void Shoot(Transform position)
    {
        if (Physics.Raycast(position.position, position.forward, out _hit))
        {
            if (_hit.transform.CompareTag("Enemy") || _hit.transform.CompareTag("Asteroid"))
            {
                if (_hit.transform.GetComponent<Unit>())
                {
                    Debug.Log(_hit.transform.name);
                    _hit.transform.GetComponent<Unit>().Crash?.Invoke(_damage);
                }
            }
        }
    }
}