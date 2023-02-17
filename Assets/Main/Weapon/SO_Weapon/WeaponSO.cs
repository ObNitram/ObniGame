   using UnityEngine;

   namespace Main.Weapon.SO_Weapon
{
   [CreateAssetMenu(fileName = "New Weapon", menuName = "ScriptableObject/Weapon")]
   public class WeaponSO : ScriptableObject
   {
   
      [Range(0,60)]
      public float speed;
      public int damage;
      public float fireRate;
      [Range (0,10)]
      public float range;
      [Range(1,10)]
      public int numberOfBulletsByShot = 1;
      
      [Header("Ammo")]
      public int maxMagazine;
      

      [Header("Aiming (0=0° | 1=360°)")] 
      [Range(0,1)]
      public float idlAiming;
      [Range(0,1)]
      public float walkAiming;
      [Min(0)]
      public float aimingMultiplierOnShoot;
      
      [Min(0)]
      public int penetration;
      
      
      public Sprite sprite;
   
   }
}

