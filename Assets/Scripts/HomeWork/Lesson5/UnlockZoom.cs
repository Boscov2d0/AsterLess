using UnityEngine;

public sealed class UnlockZoom : MonoBehaviour
{
    public bool IsUnlock { get; set; }
    public UnlockZoom(bool isUnlock)
    {
        IsUnlock = isUnlock;
    }
}