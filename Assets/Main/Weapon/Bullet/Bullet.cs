using Main.Weapon.SO_Weapon;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Main.Weapon.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Light2D _light2D;
        private WeaponSO _weaponSo;

        private int currentPenetration;

        // Start is called before the first frame update
        public void Init(WeaponSO weaponSO, Vector2 initialSpeed)
        {
            _weaponSo = weaponSO;
            UnityEngine.Debug.Log(initialSpeed);
            _rigidbody2D.AddForce(initialSpeed, ForceMode2D.Impulse);
            _rigidbody2D.AddForce(transform.right.normalized * weaponSO.speed, ForceMode2D.Impulse);
            _spriteRenderer.sprite = weaponSO.sprite;
            _light2D.lightCookieSprite = weaponSO.sprite;

            Destroy(gameObject, weaponSO.range);
        }


        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(tag)) return;

            IDamageable enemy = col.GetComponent<IDamageable>();

            if (enemy == null)
            {
                Destroy(gameObject);
                return;
            }


            enemy.Damage(_weaponSo.damage);

            if (currentPenetration < _weaponSo.penetration)
                currentPenetration++;
            else
                Destroy(gameObject);
        }
    }
}