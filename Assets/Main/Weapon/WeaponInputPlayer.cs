    using Main.Weapon.SO_Weapon;
    using UnityEngine;
    using UnityEngine.InputSystem;

    namespace Main.Weapon
{
    public class WeaponInputPlayer : MonoBehaviour
    {
        PlayerInputManager _playerInputManager;
        [SerializeField] private RangeWeapon _rangeWeapon;
        [SerializeField] private WeaponSO _weaponSO;
        
        private void Awake()
        {
            _playerInputManager = new PlayerInputManager();
            _playerInputManager.Player.Shoot.started += StartShoot;
            _playerInputManager.Player.Shoot.canceled += StopShoot;
            _playerInputManager.Player.Reload.started += Reload;
        }
        
        private void StartShoot(InputAction.CallbackContext context)
        {
            _rangeWeapon.StartShoot();
        }
        
        private void StopShoot(InputAction.CallbackContext context)
        {
            _rangeWeapon.StopShoot();
        }
        
        private void Reload(InputAction.CallbackContext context)
        {
            _rangeWeapon.Reload();
        }
        
        
        
        
        
        

        private void OnEnable()
        {
            _playerInputManager.Player.Shoot.Enable();
            _playerInputManager.Player.Reload.Enable();
        }

        private void OnDisable()
        {
            _playerInputManager.Player.Shoot.Disable();
            _playerInputManager.Player.Reload.Disable();
        }

        private void Start()
        {
            _rangeWeapon.WeaponSO = _weaponSO;      
        }
    }
}