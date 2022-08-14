using UnityEngine;

internal sealed class ModificationOpticalSight : ModificationWeapon
{
    private readonly IModification _opticalSight;
    private readonly Transform _opticalSightPosition;

    GameObject _opticalSightObject;
    public ModificationOpticalSight(IModification opticalSight, Transform mufflerPosition)
    {
        _opticalSight = opticalSight;
        _opticalSightPosition = mufflerPosition;

        _opticalSightObject = Object.Instantiate(_opticalSight.Instance, _opticalSightPosition.position, _opticalSightPosition.rotation);
    }
    protected override Weapon AddModification(Weapon weapon)
    {
        _opticalSightObject.SetActive(true);
        return weapon;
    }
    protected override Weapon RemoveModification(Weapon weapon)
    {
        _opticalSightObject.SetActive(false);
        return weapon;
    }
}