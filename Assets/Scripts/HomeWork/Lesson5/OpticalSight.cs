using UnityEngine;

internal sealed class OpticalSight : IModification, IZoom
{
    public Transform BarrelPosition { get; }
    public GameObject Instance { get; }
    public Camera Camera { get; }
    public OpticalSight(Transform barrelPositionMuffler, GameObject mufflerInstance, Camera camera)
    {
        BarrelPosition = barrelPositionMuffler;
        Instance = mufflerInstance;
        Camera = camera;
    }

    public void Zoom(bool zoom)
    {
        if (zoom)
        {
            Camera.fieldOfView = 30;
        }
        else 
        {
            Camera.fieldOfView = 60;
        }
    }
}