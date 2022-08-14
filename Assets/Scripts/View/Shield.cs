using System;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Action GetShield;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            GetShield?.Invoke();
        }
    }
}