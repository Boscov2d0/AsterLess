using UnityEngine;

internal sealed class ModificationMuffler : ModificationWeapon
{
    private readonly IModification _muffler;
    private readonly Vector3 _mufflerPosition;

    GameObject _mufflerObject;
    public ModificationMuffler(IModification muffler, Vector3 mufflerPosition)
    {
        _muffler = muffler;
        _mufflerPosition = mufflerPosition;

        _mufflerObject = Object.Instantiate(_muffler.Instance, _mufflerPosition, Quaternion.identity);
    }
    protected override Weapon AddModification(Weapon weapon)
    {
        _mufflerObject.SetActive(true);
        weapon.SetBarrelPosition(_muffler.BarrelPosition, 
            new Vector3(_muffler.BarrelPosition.position.x + _muffler.BarrelPosition.localScale.x/2, 
            _muffler.BarrelPosition.position.y,
            _muffler.BarrelPosition.position.z));
        return weapon;
    }
    protected override Weapon RemoveModification(Weapon weapon)
    {
        weapon.SetBarrelPosition(_muffler.BarrelPosition,
            _muffler.BarrelPosition.position);
        _mufflerObject.SetActive(false);
        return weapon;
    }
}