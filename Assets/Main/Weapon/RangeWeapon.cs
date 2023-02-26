using System.Collections;
using Main.Character.Module;
using Main.Weapon.Aiming;
using Main.Weapon.SO_Weapon;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Main.Weapon
{
    public class RangeWeapon : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Bullet.Bullet _bulletPrefab;
        [SerializeField] private AVector2 vector2;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        [SerializeField] private AimingUI _aimingUI;
        //[SerializeField] private AudioSource _audioSource;


        private WeaponSO _weaponSO;

        public WeaponSO WeaponSO
        {
            get => _weaponSO;
            set
            {
                _fireRateWait = new WaitForSeconds(value.fireRate);

                _canShoot = false;
                Invoke(nameof(ResetCanShoot), value.fireRate);

                currentMagazine = value.maxMagazine;

                _weaponSO = value;
            }
        }

        public int currentMagazine;

        [SerializeField] private bool _isAutoFire;

        private float _currentAimingAngle;
        private float _targetAimingAngle;
        [SerializeField] private float _aimingAngleSpeed = 1f;

        private void Update()
        {
            _targetAimingAngle = vector2.GetVector2().magnitude < 0.1f
                ? _weaponSO.idlAiming
                : _weaponSO.walkAiming;

            _currentAimingAngle = _currentAimingAngle > 1f
                ? _currentAimingAngle = 1f
                : _currentAimingAngle = Mathf.Lerp(_currentAimingAngle, _targetAimingAngle,
                    _aimingAngleSpeed * Time.deltaTime);

            _aimingUI.UpdateTargetAngleWithFloat(_currentAimingAngle);
        }


        private WaitForSeconds _fireRateWait;
        private float _delay;
        private bool _canShoot;

        private void Start()
        {
            _canShoot = true;
        }

        public void Reload()
        {
            currentMagazine = _weaponSO.maxMagazine;
        }


        public void StartShoot()
        {
            //Debug.Log("StartShoot");
            StopAllCoroutines();


            if (_canShoot && currentMagazine > 0)
            {
                _canShoot = false;
                Invoke(nameof(ResetCanShoot), _weaponSO.fireRate);

                if (_isAutoFire)
                {
                    StartCoroutine(RapidFire());
                }
                else
                {
                    Shoot();
                }
            }
        }

        private void ResetCanShoot()
        {
            _canShoot = true;
        }

        public void StopShoot()
        {
            //Debug.Log("StopShoot");
            StopAllCoroutines();
        }


        private IEnumerator RapidFire()
        {
            while (_isAutoFire && currentMagazine > 0)
            {
                Shoot();
                yield return _fireRateWait;
            }
        }

        private void Shoot()
        {
            //_audioSource.Play();

            for (int i = 0; i < _weaponSO.numberOfBulletsByShot; i++)
            {
                Quaternion rotation =
                    Quaternion.Euler(0, 0,
                        Random.Range(-_currentAimingAngle * 180, _currentAimingAngle * 180) +
                        90f);
                rotation *= _firePoint.rotation;

                Bullet.Bullet bullet = Instantiate(_bulletPrefab, _firePoint.position, rotation);
                bullet.Init(_weaponSO, _rigidbody2D.velocity);
            }

            _currentAimingAngle *= _weaponSO.aimingMultiplierOnShoot;
            currentMagazine--;
        }
    }
}