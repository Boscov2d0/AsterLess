public sealed class ZoomProxy : IZoom
{
    private readonly IZoom _zoom;
    private readonly UnlockZoom _unlockZoom;
    public ZoomProxy(IZoom weapon, UnlockZoom unlockWeapon)
    {
        _zoom = weapon;
        _unlockZoom = unlockWeapon;
    }
    public void Zoom(bool zoom)
    {
        if (_unlockZoom.IsUnlock)
        {
            _zoom.Zoom(zoom);
        }
    }
}