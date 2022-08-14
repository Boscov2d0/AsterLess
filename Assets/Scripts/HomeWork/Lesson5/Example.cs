using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private IFire _fire;
    [Header("Start Gun")]
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private Transform _barrelPosition;

    [Header("Muffler Gun")]
    [SerializeField] private Transform _barrelPositionMuffler;
    [SerializeField] private GameObject _mufflerPrefab;


    [Header("Optical Sight Gun")]
    [SerializeField] private Transform _barrelPositionOpticalSight;
    [SerializeField] private GameObject _opticalSightPrefab;

    ModificationWeapon _modificationWeaponMuffler;
    ModificationWeapon _modificationWeaponOpticalSight;
    
    Weapon _weapon;
    Muffler _muffler;
    OpticalSight _opticalSight;

    UnlockZoom _unlockZoom;
    ZoomProxy _zoomProxy;

    bool _mufflerOn = false;
    bool _opticalSightOn = false;

    private void Start()
    {
        IAmmunition ammunition = new Bullet(_bullet, 3.0f);
        _weapon = new Weapon(ammunition, _barrelPosition, 999.0f);

        _muffler = new Muffler(_barrelPosition, _mufflerPrefab);
        _opticalSight = new OpticalSight(_barrelPositionOpticalSight, _opticalSightPrefab, _camera);
        _modificationWeaponMuffler = new ModificationMuffler(_muffler, _barrelPositionMuffler.position);
        _modificationWeaponOpticalSight = new ModificationOpticalSight(_opticalSight, _barrelPositionOpticalSight);

        _fire = _weapon;

        _unlockZoom = new UnlockZoom(false);
        _zoomProxy = new ZoomProxy(_opticalSight, _unlockZoom);

        SetMuffler();
        SetOpticalSight();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _fire.Fire();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _mufflerOn = !_mufflerOn;
            SetMuffler();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _opticalSightOn = !_opticalSightOn;
            SetOpticalSight();
        }

        ChangeZoom(Input.GetMouseButton(1));
    }
    private void SetMuffler() 
    {
        if (_mufflerOn)
        {
            _modificationWeaponMuffler.ApplyModification(_weapon);
        }
        else 
        {
            _modificationWeaponMuffler.CancelModification(_weapon);
        }
    }
    private void SetOpticalSight()
    {
        if (_opticalSightOn)
        {
            _modificationWeaponOpticalSight.ApplyModification(_weapon);
            _unlockZoom.IsUnlock = true;
        }
        else
        {
            _modificationWeaponOpticalSight.CancelModification(_weapon);
            _unlockZoom.IsUnlock = false;
        }
    }
    private void ChangeZoom(bool zoom) 
    {
        _zoomProxy.Zoom(zoom);
    }
}